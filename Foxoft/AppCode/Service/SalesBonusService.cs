using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using static Foxoft.AppCode.Service.SalesBonusCalculator;

namespace Foxoft.AppCode.Service
{
    /// <summary>Bonus sinxronizasiyasının nəticəsi.</summary>
    public sealed record SalesBonusSyncResult(int PostedCount, decimal PostedAmount, List<string> Messages)
    {
        public static SalesBonusSyncResult Empty => new(0, 0m, new List<string>());
    }

    /// <summary>Manual hesablama formasında göstərilən önizləmə sətri.</summary>
    public sealed class SalesBonusPreviewItem
    {
        public Guid SalesBonusPlanId { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public string SalesPersonCode { get; set; } = string.Empty;
        public string SalesPersonName { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public decimal BaseAmount { get; set; }
        public decimal Expected { get; set; }
        public decimal Posted { get; set; }
        public decimal Delta { get; set; }
    }

    /// <summary>
    /// Satıcı bonusunun hesablanması və jurnala (TrSalesBonusTxns) yazılması üçün ayrıca servis.
    ///
    /// Prinsip: "gözlənilən − yazılmış = fərq" (delta accrual).
    /// Hər açar üçün (plan, satıcı, faktura) və ya (plan, satıcı, dövr) cari məlumatlara görə gözlənilən bonus hesablanır,
    /// jurnalda artıq yazılmış cəmlə müqayisə edilir və yalnız fərq yeni sətir kimi yazılır. Mövcud sətirlər heç vaxt silinmir:
    /// qaytarma / düzəliş / ləğv həmişə mənfi (Reverse) sətir yaradır. Beləliklə jurnal tam audit edilə biləndir.
    ///
    /// Biznes qaydaları:
    ///  - Bonus endirimdən sonrakı xalis məbləğ (NetAmountLoc) əsasında hesablanır.
    ///  - Mənfəət üçün maya dəyəri satış anındakı TrInvoiceLine.ProductCost-dan götürülür (sonradan dəyişmir).
    ///  - Qaytarma sənədləri (RelatedInvoiceId) əsas fakturaya "netləşdirilir": tam qaytarmada bonus 0-a enir, fərq mənfi yazılır.
    ///  - "Müştəri ödəniş etdikdə" rejimində bonus ödənilmiş hissəyə mütənasib açılır (10.000-in 4.000-i ödənilib → 2% × 4.000 = 80).
    ///  - Manual rejimli planlar yalnız manual hesablama ilə işlənir.
    /// </summary>
    public sealed class SalesBonusService
    {
        /// <summary>Bonusa daxil ola bilən satış prosesləri.</summary>
        public static readonly string[] SalesProcessCodes = { "RS", "WS", "IS" };

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        #region Public API

        /// <summary>Aktiv plan var? Hook-larda sürətli çıxış üçün.</summary>
        public bool AnyActivePlans(BonusTriggerType? trigger = null)
        {
            using subContext db = new();
            IQueryable<DcSalesBonusPlan> q = db.DcSalesBonusPlans.AsNoTracking().Where(p => p.IsActive);
            if (trigger.HasValue)
                q = q.Where(p => p.TriggerType == trigger.Value);
            return q.Any();
        }

        /// <summary>
        /// Faktura saxlanılanda / təsdiqlənəndə çağırılır. Qaytarma sənədi verilərsə əsas fakturaya yönləndirilir.
        /// </summary>
        public SalesBonusSyncResult SyncInvoice(Guid invoiceHeaderId, string actor)
        {
            if (!AnyActivePlans())
                return SalesBonusSyncResult.Empty;

            return RunSession(actor, s =>
            {
                TrInvoiceHeader? inv = s.Db.TrInvoiceHeaders.AsNoTracking().FirstOrDefault(h => h.InvoiceHeaderId == invoiceHeaderId);
                if (inv == null)
                    return;

                s.Event = new SyncEvent(inv.DocumentDate,
                    inv.IsReturn ? string.Format(Resources.SalesBonus_Note_Return, inv.DocumentNumber)
                                 : string.Format(Resources.SalesBonus_Note_Invoice, inv.DocumentNumber),
                    actor);

                s.SyncInvoice(invoiceHeaderId, excludeInvoiceId: null, onlyPlanId: null);
            });
        }

        /// <summary>
        /// Faktura silinməzdən ƏVVƏL çağırılır: həmin fakturaya aid bonuslar mənfi sətirlərlə ləğv edilir.
        /// Faktura silindikdən sonra FK avtomatik NULL olur, sənəd nömrəsi mətn kimi jurnalda qalır.
        /// </summary>
        public SalesBonusSyncResult ReverseInvoiceBeforeDelete(Guid invoiceHeaderId, string actor)
        {
            return RunSession(actor, s =>
            {
                TrInvoiceHeader? inv = s.Db.TrInvoiceHeaders.AsNoTracking().FirstOrDefault(h => h.InvoiceHeaderId == invoiceHeaderId);
                if (inv == null)
                    return;

                bool anyTxn = s.Db.TrSalesBonusTxns.Any(t => t.InvoiceHeaderId == invoiceHeaderId);
                bool isFoldedReturn = inv.IsReturn && inv.RelatedInvoiceId.HasValue;
                if (!anyTxn && !isFoldedReturn && !AnyActivePlans())
                    return;

                s.Event = new SyncEvent(DateTime.Today, string.Format(Resources.SalesBonus_Note_InvoiceDeleted, inv.DocumentNumber), actor);

                // Silinən sənəd hesablamadan xaric edilir (hələ DB-dədir).
                s.SyncInvoice(invoiceHeaderId, excludeInvoiceId: invoiceHeaderId, onlyPlanId: null);
            });
        }

        /// <summary>
        /// Ödəniş sənədi saxlanılanda çağırılır. Yalnız "Müştəri ödəniş etdikdə" rejimli planlar üçün işləyir.
        /// Fakturaya bağlı ödəniş → həmin faktura; müştərinin bağlı olmayan ödənişləri (FIFO) → müştərinin bütün satış fakturaları.
        /// </summary>
        public SalesBonusSyncResult SyncPayment(Guid paymentHeaderId, string actor)
        {
            if (!AnyActivePlans(BonusTriggerType.OnCustomerPayment))
                return SalesBonusSyncResult.Empty;

            return RunSession(actor, s =>
            {
                TrPaymentHeader? ph = s.Db.TrPaymentHeaders.AsNoTracking().FirstOrDefault(h => h.PaymentHeaderId == paymentHeaderId);
                if (ph == null)
                    return;

                s.Event = new SyncEvent(ph.DocumentDate, string.Format(Resources.SalesBonus_Note_Payment, ph.DocumentNumber), actor,
                                        ph.PaymentHeaderId, ph.DocumentNumber);

                if (ph.InvoiceHeaderId.HasValue)
                    s.SyncInvoice(ph.InvoiceHeaderId.Value, excludeInvoiceId: null, onlyPlanId: null);

                if (!string.IsNullOrWhiteSpace(ph.CurrAccCode))
                    s.SyncCustomerInvoices(ph.CurrAccCode);
            });
        }

        /// <summary>Müştərinin bütün satış fakturalarını yenidən sinxronlaşdırır (ödəniş silinəndə / dəyişəndə).</summary>
        public SalesBonusSyncResult SyncCustomer(string currAccCode, string actor)
        {
            if (!AnyActivePlans(BonusTriggerType.OnCustomerPayment))
                return SalesBonusSyncResult.Empty;

            return RunSession(actor, s =>
            {
                s.Event = new SyncEvent(DateTime.Today, string.Format(Resources.SalesBonus_Note_Payment, currAccCode), actor);
                s.SyncCustomerInvoices(currAccCode, force: true);
            });
        }

        /// <summary>Manual hesablama: seçilmiş ay üçün gözlənilən/yazılmış/fərq önizləməsi (heç nə yazılmır).</summary>
        public List<SalesBonusPreviewItem> PreviewPeriod(int year, int month, string? salesPersonCode, Guid? planId, bool includeAutomaticPlans, string actor)
        {
            using subContext db = new();
            SyncSession s = new(db, actor) { PreviewOnly = true };
            s.RunManualPeriod(year, month, salesPersonCode, planId, includeAutomaticPlans);
            return s.PreviewItems;
        }

        /// <summary>Manual hesablama: seçilmiş ay üçün fərqləri jurnala yazır.</summary>
        public SalesBonusSyncResult PostPeriod(int year, int month, string? salesPersonCode, Guid? planId, bool includeAutomaticPlans, string actor)
        {
            return RunSession(actor, s => s.RunManualPeriod(year, month, salesPersonCode, planId, includeAutomaticPlans));
        }

        /// <summary>Manual düzəliş (+/-). Avtomatik yenidən hesablamalarda nəzərə alınmır.</summary>
        public TrSalesBonusTxn AddAdjustment(string salesPersonCode, Guid planId, DateTime date, decimal amount, string note, string actor)
        {
            using subContext db = new();
            DcSalesBonusPlan plan = db.DcSalesBonusPlans.AsNoTracking().First(p => p.SalesBonusPlanId == planId);
            (int year, int no) = PeriodOf(date, plan.PeriodType);

            TrSalesBonusTxn txn = new()
            {
                SalesBonusTxnId = Guid.NewGuid(),
                SalesBonusPlanId = planId,
                SalesPersonCode = salesPersonCode,
                TxnType = BonusTxnType.Adjust,
                CalcMethod = plan.CalcMethod,
                TriggerType = BonusTriggerType.Manual,
                DocumentDate = date.Date,
                PeriodYear = year,
                PeriodNo = no,
                BaseAmount = 0m,
                Rate = 0m,
                Amount = Round2(amount),
                Note = note,
                CalcDetails = JsonSerializer.Serialize(new { Type = "Adjust", Amount = Round2(amount), Note = note, Actor = actor }, JsonOptions),
                CreatedUserName = actor,
                CreatedDate = DateTime.Now,
                LastUpdatedUserName = actor,
                LastUpdatedDate = DateTime.Now
            };

            db.TrSalesBonusTxns.Add(txn);
            db.SaveChanges();
            return txn;
        }

        #endregion

        #region Payroll integration

        /// <summary>Hələ heç bir əməkhaqqı sənədinə daxil edilməmiş, tarixi dövr sonuna qədər olan bonusların cəmi (yerli valyuta).</summary>
        public static decimal GetPendingBonusTotal(subContext db, string salesPersonCode, DateTime periodEnd)
        {
            DateTime end = periodEnd.Date;
            return db.TrSalesBonusTxns
                     .Where(t => t.SalesPersonCode == salesPersonCode && t.PayrollHeaderId == null && t.DocumentDate <= end)
                     .Sum(t => (decimal?)t.Amount) ?? 0m;
        }

        public static List<TrSalesBonusTxn> GetPendingTxns(subContext db, string salesPersonCode, DateTime periodEnd)
        {
            DateTime end = periodEnd.Date;
            return db.TrSalesBonusTxns
                     .Where(t => t.SalesPersonCode == salesPersonCode && t.PayrollHeaderId == null && t.DocumentDate <= end)
                     .OrderBy(t => t.DocumentDate)
                     .ToList();
        }

        /// <summary>Gözləyən bonus sətirlərini əməkhaqqı sənədinə bağlayır (SaveChanges çağıran tərəfindədir). Qaytarır: bağlanan sətir sayı.</summary>
        public static int AttachPendingToPayroll(subContext db, string salesPersonCode, DateTime periodEnd, Guid payrollHeaderId)
        {
            List<TrSalesBonusTxn> pending = GetPendingTxns(db, salesPersonCode, periodEnd);
            foreach (TrSalesBonusTxn txn in pending)
                txn.PayrollHeaderId = payrollHeaderId;
            return pending.Count;
        }

        /// <summary>Əməkhaqqı sənədinə bağlı bonusların cəmi.</summary>
        public static decimal GetAttachedBonusTotal(subContext db, Guid payrollHeaderId)
        {
            return db.TrSalesBonusTxns
                     .Where(t => t.PayrollHeaderId == payrollHeaderId)
                     .Sum(t => (decimal?)t.Amount) ?? 0m;
        }

        /// <summary>Əməkhaqqı sənədindən bonusları ayırır (sətir silinəndə).</summary>
        public static int DetachFromPayroll(subContext db, Guid payrollHeaderId)
        {
            List<TrSalesBonusTxn> attached = db.TrSalesBonusTxns.Where(t => t.PayrollHeaderId == payrollHeaderId).ToList();
            foreach (TrSalesBonusTxn txn in attached)
                txn.PayrollHeaderId = null;
            return attached.Count;
        }

        #endregion

        #region Session plumbing

        private static SalesBonusSyncResult RunSession(string actor, Action<SyncSession> work)
        {
            using subContext db = new();
            SyncSession session = new(db, actor);

            var strategy = db.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using var tx = db.Database.BeginTransaction();
                session.Reset();
                work(session);
                db.SaveChanges();
                tx.Commit();
            });

            return new SalesBonusSyncResult(session.Created.Count, Round2(session.Created.Sum(t => t.Amount)), session.Messages);
        }

        private sealed record SyncEvent(DateTime Date, string Note, string Actor, Guid? PaymentHeaderId = null, string? PaymentDocumentNumber = null, bool IsManual = false);

        /// <summary>Bir sinxronizasiya seansı: cache-lər, hadisə məlumatı və yaradılan sətirlər.</summary>
        private sealed class SyncSession
        {
            public readonly subContext Db;
            public readonly string Actor;
            public SyncEvent Event;
            public bool PreviewOnly;
            public readonly List<TrSalesBonusTxn> Created = new();
            public readonly List<string> Messages = new();
            public readonly List<SalesBonusPreviewItem> PreviewItems = new();

            private readonly Dictionary<Guid, PlanContext> _plans = new();
            private readonly Dictionary<string, List<(PlanContext Plan, TrSalesBonusAssignment Assignment)>> _assignments = new();
            private readonly Dictionary<string, Dictionary<Guid, decimal>> _fifoByCustomer = new();
            private readonly HashSet<Guid> _visitedInvoices = new();
            private readonly HashSet<string> _doneKeys = new();
            private Dictionary<string, string?>? _hierarchyParents;
            private Dictionary<string, string>? _salesPersonNames;

            public SyncSession(subContext db, string actor)
            {
                Db = db;
                Actor = actor;
                Event = new SyncEvent(DateTime.Today, string.Empty, actor);
            }

            public void Reset()
            {
                // Retry strategy eyni seansı təkrar icra edə bilər: yarımçıq qalan Added entity-lər təmizlənir.
                Db.ChangeTracker.Clear();
                Created.Clear();
                Messages.Clear();
                PreviewItems.Clear();
                _visitedInvoices.Clear();
                _doneKeys.Clear();
            }

            // ---------- Invoice level ----------

            public void SyncInvoice(Guid invoiceHeaderId, Guid? excludeInvoiceId, Guid? onlyPlanId)
            {
                TrInvoiceHeader? inv = Db.TrInvoiceHeaders.AsNoTracking().FirstOrDefault(h => h.InvoiceHeaderId == invoiceHeaderId);
                if (inv == null)
                    return;

                // Qaytarma sənədi əsas fakturaya netləşdirilir.
                if (inv.IsReturn && inv.RelatedInvoiceId.HasValue)
                {
                    SyncInvoice(inv.RelatedInvoiceId.Value, excludeInvoiceId, onlyPlanId);
                    return;
                }

                if (!SalesProcessCodes.Contains(inv.ProcessCode))
                    return;

                if (!_visitedInvoices.Add(invoiceHeaderId))
                    return;

                InvoiceData data = LoadInvoiceData(invoiceHeaderId, excludeInvoiceId);
                if (data.Header == null)
                    return;

                bool confirmed = data.Header.IsCompleted && !data.Header.IsSuspended && data.Header.InvoiceHeaderId != excludeInvoiceId;

                var existing = Db.TrSalesBonusTxns.AsNoTracking()
                                 .Where(t => t.InvoiceHeaderId == invoiceHeaderId && t.TxnType != BonusTxnType.Adjust)
                                 .Select(t => new { t.SalesBonusPlanId, t.SalesPersonCode })
                                 .Distinct()
                                 .ToList();

                HashSet<string> salesPersons = data.Lines
                    .Where(l => !string.IsNullOrWhiteSpace(l.SalesPersonCode))
                    .Select(l => l.SalesPersonCode!)
                    .Concat(existing.Select(e => e.SalesPersonCode))
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                foreach (string sp in salesPersons)
                {
                    List<(PlanContext Plan, TrSalesBonusAssignment Assignment)> active = GetActiveAssignments(sp, data.Header.DocumentDate);

                    HashSet<Guid> planIds = active.Select(a => a.Plan.Plan.SalesBonusPlanId)
                        .Concat(existing.Where(e => string.Equals(e.SalesPersonCode, sp, StringComparison.OrdinalIgnoreCase)).Select(e => e.SalesBonusPlanId))
                        .ToHashSet();

                    foreach (Guid planId in planIds)
                    {
                        if (onlyPlanId.HasValue && planId != onlyPlanId.Value)
                            continue;

                        PlanContext ctx = GetPlan(planId);
                        TrSalesBonusAssignment? assignment = active.FirstOrDefault(a => a.Plan.Plan.SalesBonusPlanId == planId).Assignment;

                        if (ctx.Plan.TriggerType == BonusTriggerType.Manual && !Event.IsManual)
                            continue;

                        if (assignment != null && !ctx.AppliesToProcess(data.Header.ProcessCode))
                            assignment = null;

                        SyncInvoiceForPlan(ctx, assignment, sp, data, confirmed, excludeInvoiceId);
                    }
                }
            }

            private void SyncInvoiceForPlan(PlanContext ctx, TrSalesBonusAssignment? assignment, string sp, InvoiceData data, bool confirmed, Guid? excludeInvoiceId)
            {
                if (IsPeriodScoped(ctx.Plan.CalcMethod))
                {
                    (int year, int no) = PeriodOf(data.Header!.DocumentDate, ctx.Plan.PeriodType);
                    SyncPeriodKey(ctx, assignment, sp, year, no, data.Header, excludeInvoiceId);
                    return;
                }

                CalcResult calc = confirmed && assignment != null
                    ? ComputeInvoiceExpected(ctx, data, sp)
                    : CalcResult.Zero(confirmed ? "not assigned" : "not confirmed");

                (int py, int pn) = PeriodOf(data.Header!.DocumentDate, ctx.Plan.PeriodType);
                PostDelta(ctx, assignment, sp, isPeriodScope: false, calc, py, pn, data.Header);
            }

            /// <summary>Faktura səviyyəli metodlar (satış %, mənfəət %, say, yığım %) üçün gözlənilən bonus.</summary>
            private CalcResult ComputeInvoiceExpected(PlanContext ctx, InvoiceData data, string sp)
            {
                DcSalesBonusPlan plan = ctx.Plan;
                decimal baseSum = 0m;
                decimal amount = 0m;
                List<object> traces = new();

                foreach (EffLine l in data.Lines.Where(x => string.Equals(x.SalesPersonCode, sp, StringComparison.OrdinalIgnoreCase)))
                {
                    decimal? rate = ctx.RateFor(l.ProductCode, l.HierarchyCode);
                    if (rate == null)
                        continue;

                    decimal lineBase;
                    decimal lineBonus;
                    switch (plan.CalcMethod)
                    {
                        case BonusCalcMethod.GrossProfitPercent:
                            lineBase = l.NetLoc - l.Qty * l.Cost;
                            lineBonus = lineBase * rate.Value / 100m;
                            break;
                        case BonusCalcMethod.PerUnitSold:
                            lineBase = l.Qty;
                            lineBonus = lineBase * rate.Value;
                            break;
                        default: // SalesAmountPercent, CollectionPercent
                            lineBase = l.NetLoc;
                            lineBonus = lineBase * rate.Value / 100m;
                            break;
                    }

                    baseSum += lineBase;
                    amount += lineBonus;
                    traces.Add(new { Doc = l.DocNum, Product = l.ProductCode, Qty = l.Qty, Net = Round2(l.NetLoc), Cost = l.Cost, Base = Round2(lineBase), Rate = rate.Value, Bonus = Round2(lineBonus) });
                }

                decimal ratio = 1m;
                if (plan.TriggerType == BonusTriggerType.OnCustomerPayment)
                {
                    ratio = GetPaidRatio(data);
                    baseSum *= ratio;
                    amount *= ratio;
                }

                string? note = null;
                if (plan.MinBaseAmount > 0 && baseSum < plan.MinBaseAmount)
                {
                    amount = 0m;
                    note = "below MinBaseAmount";
                }

                if (!data.Header!.IsReturn)
                    amount = Math.Max(0m, amount);

                amount = ApplyCap(Round2(amount), plan.MaxBonusAmount);
                baseSum = Round2(baseSum);

                decimal effRate = plan.CalcMethod == BonusCalcMethod.PerUnitSold
                    ? (baseSum != 0 ? Math.Round(amount / baseSum, 4) : plan.Rate)
                    : (baseSum != 0 ? Math.Round(amount / baseSum * 100m, 4) : plan.Rate);

                return new CalcResult(amount, baseSum, effRate, new
                {
                    Scope = "Invoice",
                    Invoice = data.Header.DocumentNumber,
                    PaidRatio = Math.Round(ratio, 4),
                    PaidLoc = data.PaidLoc,
                    NetLocAfterReturns = Round2(data.NetLocTotal),
                    MinBase = plan.MinBaseAmount,
                    Cap = plan.MaxBonusAmount,
                    Remark = note,
                    Lines = traces
                });
            }

            // ---------- Period level ----------

            private void SyncPeriodKey(PlanContext ctx, TrSalesBonusAssignment? assignment, string sp, int year, int no, TrInvoiceHeader? trigger, Guid? excludeInvoiceId)
            {
                string key = $"{ctx.Plan.SalesBonusPlanId}|{sp}|{year}|{no}";
                if (!_doneKeys.Add(key))
                    return;

                PeriodAggregate agg = AggregatePeriodBase(ctx, sp, year, no, excludeInvoiceId);
                CalcResult calc = assignment != null
                    ? ComputePeriodExpected(ctx, assignment, agg, year, no)
                    : CalcResult.Zero("not assigned");

                PostDelta(ctx, assignment, sp, isPeriodScope: true, calc, year, no, trigger);
            }

            private PeriodAggregate AggregatePeriodBase(PlanContext ctx, string sp, int year, int no, Guid? excludeInvoiceId)
            {
                (DateTime start, DateTime end) = PeriodRange(year, no, ctx.Plan.PeriodType);
                string[] processes = SalesProcessCodes;

                List<TrInvoiceHeader> headers = Db.TrInvoiceHeaders.AsNoTracking()
                    .Include(h => h.TrInvoiceLines).ThenInclude(l => l.DcProduct)
                    .Where(h => h.IsCompleted && !h.IsSuspended
                             && processes.Contains(h.ProcessCode)
                             && h.DocumentDate >= start && h.DocumentDate <= end
                             && (!h.IsReturn || h.RelatedInvoiceId == null)
                             && h.InvoiceHeaderId != excludeInvoiceId
                             && h.TrInvoiceLines.Any(l => l.SalesPersonCode == sp))
                    .ToList();

                List<Guid> ids = headers.Select(h => h.InvoiceHeaderId).ToList();
                Dictionary<Guid, List<TrInvoiceHeader>> returnsByInvoice = LoadReturns(ids, excludeInvoiceId);

                decimal baseSum = 0m;
                int count = 0;
                List<object> traces = new();

                foreach (TrInvoiceHeader h in headers)
                {
                    if (!ctx.AppliesToProcess(h.ProcessCode))
                        continue;

                    returnsByInvoice.TryGetValue(h.InvoiceHeaderId, out List<TrInvoiceHeader>? returns);
                    InvoiceData data = BuildInvoiceData(h, returns ?? new List<TrInvoiceHeader>());

                    decimal invBase = 0m;
                    bool any = false;
                    foreach (EffLine l in data.Lines.Where(x => string.Equals(x.SalesPersonCode, sp, StringComparison.OrdinalIgnoreCase)))
                    {
                        decimal? rate = ctx.RateFor(l.ProductCode, l.HierarchyCode);
                        if (rate == null)
                            continue;

                        any = true;
                        invBase += ctx.Plan.CalcMethod switch
                        {
                            BonusCalcMethod.GrossProfitPercent => l.NetLoc - l.Qty * l.Cost,
                            BonusCalcMethod.PerUnitSold => l.Qty,
                            _ => l.NetLoc
                        };
                    }

                    if (!any)
                        continue;

                    decimal ratio = 1m;
                    if (ctx.Plan.TriggerType == BonusTriggerType.OnCustomerPayment)
                    {
                        ratio = GetPaidRatio(data);
                        invBase *= ratio;
                    }

                    count++;
                    baseSum += invBase;
                    traces.Add(new { Doc = h.DocumentNumber, Date = h.DocumentDate.ToString("yyyy-MM-dd"), Base = Round2(invBase), PaidRatio = Math.Round(ratio, 4) });
                }

                return new PeriodAggregate(Round2(baseSum), count, traces);
            }

            private CalcResult ComputePeriodExpected(PlanContext ctx, TrSalesBonusAssignment assignment, PeriodAggregate agg, int year, int no)
            {
                DcSalesBonusPlan plan = ctx.Plan;
                decimal baseSum = agg.Base;
                List<TierTrace> tierTrace = new();
                decimal amount;
                decimal achievement = 0m;
                decimal target = 0m;
                string? remark = null;

                if (plan.MinBaseAmount > 0 && baseSum < plan.MinBaseAmount)
                {
                    amount = 0m;
                    remark = "below MinBaseAmount";
                }
                else
                {
                    switch (plan.CalcMethod)
                    {
                        case BonusCalcMethod.TieredSalesPercent:
                            amount = CalcTiered(baseSum, ctx.Tiers, plan.TierMode, tierTrace);
                            break;
                        case BonusCalcMethod.SalesTargetAchievement:
                            target = assignment.TargetAmount ?? plan.TargetAmount;
                            amount = CalcTarget(baseSum, target, plan.TargetMinAchievementPercent, plan.Rate, plan.FixedAmount, ctx.Tiers, out achievement, tierTrace);
                            break;
                        case BonusCalcMethod.FixedAmount:
                            amount = CalcFixed(plan.FixedAmount, agg.Count);
                            break;
                        default:
                            amount = 0m;
                            break;
                    }
                }

                amount = ApplyCap(amount, plan.MaxBonusAmount);
                decimal effRate = baseSum > 0 ? Math.Round(amount / baseSum * 100m, 4) : 0m;

                return new CalcResult(amount, baseSum, effRate, new
                {
                    Scope = "Period",
                    Period = PeriodText(year, no, plan.PeriodType),
                    TierMode = plan.CalcMethod == BonusCalcMethod.TieredSalesPercent ? plan.TierMode.ToString() : null,
                    Target = target,
                    Achievement = achievement,
                    DocumentCount = agg.Count,
                    MinBase = plan.MinBaseAmount,
                    Cap = plan.MaxBonusAmount,
                    Remark = remark,
                    Tiers = tierTrace,
                    Invoices = agg.Traces
                });
            }

            // ---------- Posting ----------

            private void PostDelta(PlanContext ctx, TrSalesBonusAssignment? assignment, string sp, bool isPeriodScope, CalcResult calc, int year, int no, TrInvoiceHeader? invoice)
            {
                Guid planId = ctx.Plan.SalesBonusPlanId;
                IQueryable<TrSalesBonusTxn> q = Db.TrSalesBonusTxns
                    .Where(t => t.SalesBonusPlanId == planId && t.SalesPersonCode == sp && t.TxnType != BonusTxnType.Adjust);

                q = isPeriodScope
                    ? q.Where(t => t.PeriodYear == year && t.PeriodNo == no)
                    : q.Where(t => t.InvoiceHeaderId == invoice!.InvoiceHeaderId);

                decimal posted = q.Sum(t => (decimal?)t.Amount) ?? 0m;

                posted += Created.Where(t => t.SalesBonusPlanId == planId
                                          && string.Equals(t.SalesPersonCode, sp, StringComparison.OrdinalIgnoreCase)
                                          && (isPeriodScope ? (t.PeriodYear == year && t.PeriodNo == no)
                                                            : t.InvoiceHeaderId == invoice!.InvoiceHeaderId))
                                 .Sum(t => t.Amount);

                decimal delta = Round2(calc.Expected - posted);

                if (PreviewOnly)
                {
                    PreviewItems.Add(new SalesBonusPreviewItem
                    {
                        SalesBonusPlanId = planId,
                        PlanName = ctx.Plan.PlanName,
                        SalesPersonCode = sp,
                        SalesPersonName = GetSalesPersonName(sp),
                        Scope = isPeriodScope ? PeriodText(year, no, ctx.Plan.PeriodType) : (invoice?.DocumentNumber ?? string.Empty),
                        BaseAmount = calc.Base,
                        Expected = calc.Expected,
                        Posted = Round2(posted),
                        Delta = delta
                    });
                    return;
                }

                if (Math.Abs(delta) < 0.01m)
                    return;

                Guid? relatedId = q.OrderByDescending(t => t.CreatedDate).Select(t => (Guid?)t.SalesBonusTxnId).FirstOrDefault();

                string details = JsonSerializer.Serialize(new
                {
                    Method = ctx.Plan.CalcMethod.ToString(),
                    Trigger = ctx.Plan.TriggerType.ToString(),
                    Event = Event.Note,
                    EventDate = Event.Date.ToString("yyyy-MM-dd"),
                    Expected = calc.Expected,
                    Posted = Round2(posted),
                    Delta = delta,
                    Base = calc.Base,
                    Rate = calc.Rate,
                    Assignment = assignment?.SalesBonusAssignmentId,
                    Detail = calc.Details
                }, JsonOptions);

                TrSalesBonusTxn txn = new()
                {
                    SalesBonusTxnId = Guid.NewGuid(),
                    SalesBonusPlanId = planId,
                    SalesBonusAssignmentId = assignment?.SalesBonusAssignmentId,
                    SalesPersonCode = sp,
                    TxnType = delta > 0 ? BonusTxnType.Earn : BonusTxnType.Reverse,
                    CalcMethod = ctx.Plan.CalcMethod,
                    TriggerType = Event.IsManual ? BonusTriggerType.Manual : ctx.Plan.TriggerType,
                    DocumentDate = Event.Date.Date,
                    PeriodYear = year,
                    PeriodNo = no,
                    BaseAmount = calc.Base,
                    Rate = calc.Rate,
                    Amount = delta,
                    InvoiceHeaderId = invoice?.InvoiceHeaderId,
                    InvoiceDocumentNumber = invoice?.DocumentNumber,
                    PaymentHeaderId = Event.PaymentHeaderId,
                    PaymentDocumentNumber = Event.PaymentDocumentNumber,
                    RelatedTxnId = relatedId,
                    Note = Event.Note,
                    CalcDetails = details,
                    CreatedUserName = Actor,
                    CreatedDate = DateTime.Now,
                    LastUpdatedUserName = Actor,
                    LastUpdatedDate = DateTime.Now
                };

                Db.TrSalesBonusTxns.Add(txn);
                Created.Add(txn);
            }

            // ---------- Manual period run ----------

            public void RunManualPeriod(int year, int month, string? salesPersonCode, Guid? planId, bool includeAutomaticPlans)
            {
                DateTime start = new(year, month, 1);
                DateTime end = start.AddMonths(1).AddDays(-1);
                DateTime eventDate = end < DateTime.Today ? end : DateTime.Today;

                Event = new SyncEvent(eventDate, Resources.SalesBonus_Note_Manual, Actor, IsManual: true);

                IQueryable<TrSalesBonusAssignment> q = Db.TrSalesBonusAssignments.AsNoTracking()
                    .Include(a => a.DcSalesBonusPlan)
                    .Where(a => a.IsActive && a.DcSalesBonusPlan.IsActive
                             && a.StartDate <= end && (a.EndDate == null || a.EndDate >= start));

                if (!string.IsNullOrWhiteSpace(salesPersonCode))
                    q = q.Where(a => a.SalesPersonCode == salesPersonCode);
                if (planId.HasValue)
                    q = q.Where(a => a.SalesBonusPlanId == planId.Value);
                if (!includeAutomaticPlans)
                    q = q.Where(a => a.DcSalesBonusPlan.TriggerType == BonusTriggerType.Manual);

                List<TrSalesBonusAssignment> assignments = q.ToList();

                foreach (var group in assignments.GroupBy(a => new { a.SalesBonusPlanId, Sp = a.SalesPersonCode.ToUpperInvariant() }))
                {
                    PlanContext ctx = GetPlan(group.Key.SalesBonusPlanId);
                    string sp = group.First().SalesPersonCode;

                    if (IsPeriodScoped(ctx.Plan.CalcMethod))
                    {
                        (int py, int pn) = PeriodOf(start, ctx.Plan.PeriodType);
                        (DateTime ps, DateTime pe) = PeriodRange(py, pn, ctx.Plan.PeriodType);
                        TrSalesBonusAssignment? assignment = group
                            .Where(a => a.StartDate <= pe && (a.EndDate == null || a.EndDate >= ps))
                            .OrderByDescending(a => a.StartDate)
                            .FirstOrDefault();

                        SyncPeriodKey(ctx, assignment, sp, py, pn, null, null);
                        continue;
                    }

                    string[] processes = SalesProcessCodes;
                    List<Guid> invoiceIds = Db.TrInvoiceHeaders.AsNoTracking()
                        .Where(h => processes.Contains(h.ProcessCode)
                                 && h.DocumentDate >= start && h.DocumentDate <= end
                                 && (!h.IsReturn || h.RelatedInvoiceId == null)
                                 && h.TrInvoiceLines.Any(l => l.SalesPersonCode == sp))
                        .Select(h => h.InvoiceHeaderId)
                        .ToList();

                    foreach (Guid invoiceId in invoiceIds)
                    {
                        InvoiceData data = LoadInvoiceData(invoiceId, null);
                        if (data.Header == null)
                            continue;

                        TrSalesBonusAssignment? assignment = group
                            .Where(a => a.StartDate <= data.Header.DocumentDate && (a.EndDate == null || a.EndDate >= data.Header.DocumentDate))
                            .OrderByDescending(a => a.StartDate)
                            .FirstOrDefault();

                        if (assignment != null && !ctx.AppliesToProcess(data.Header.ProcessCode))
                            assignment = null;

                        bool confirmed = data.Header.IsCompleted && !data.Header.IsSuspended;
                        SyncInvoiceForPlan(ctx, assignment, sp, data, confirmed, null);
                    }
                }
            }

            // ---------- Customer (payment based) ----------

            public void SyncCustomerInvoices(string currAccCode, bool force = false)
            {
                DateTime? minStart = Db.TrSalesBonusAssignments.AsNoTracking()
                    .Where(a => a.IsActive && a.DcSalesBonusPlan.IsActive && a.DcSalesBonusPlan.TriggerType == BonusTriggerType.OnCustomerPayment)
                    .Min(a => (DateTime?)a.StartDate);

                if (minStart == null)
                    return;

                // Fakturaya bağlı olmayan ödəniş yoxdursa yalnız bağlı faktura təsirlənir (artıq sinxronlaşdırılıb).
                if (!force && GetUnlinkedPaidLoc(currAccCode) == 0m)
                    return;

                string[] processes = SalesProcessCodes;
                List<Guid> ids = Db.TrInvoiceHeaders.AsNoTracking()
                    .Where(h => h.CurrAccCode == currAccCode && !h.IsReturn && h.IsCompleted
                             && processes.Contains(h.ProcessCode)
                             && h.DocumentDate >= minStart.Value
                             && h.TrInvoiceLines.Any(l => l.SalesPersonCode != null && l.SalesPersonCode != ""))
                    .Select(h => h.InvoiceHeaderId)
                    .ToList();

                foreach (Guid id in ids)
                    SyncInvoice(id, null, null);
            }

            private decimal GetUnlinkedPaidLoc(string currAccCode)
            {
                return Db.TrPaymentLines.AsNoTracking()
                         .Where(l => l.TrPaymentHeader.CurrAccCode == currAccCode
                                  && l.TrPaymentHeader.InvoiceHeaderId == null
                                  && l.TrPaymentHeader.ProcessCode == "PA")
                         .Sum(l => (decimal?)l.PaymentLoc) ?? 0m;
            }

            /// <summary>
            /// Ödənilmiş hissənin nisbəti: fakturaya (və onun qaytarmalarına) bağlı ödənişlər + müştərinin bağlı olmayan
            /// ödənişlərinin FIFO (ən köhnə fakturadan) bölüşdürülməsi.
            /// </summary>
            private decimal GetPaidRatio(InvoiceData data)
            {
                if (data.PaidRatio.HasValue)
                    return data.PaidRatio.Value;

                List<Guid> ids = new() { data.Header!.InvoiceHeaderId };
                ids.AddRange(data.ReturnIds);

                decimal linked = Db.TrPaymentLines.AsNoTracking()
                    .Where(l => l.TrPaymentHeader.InvoiceHeaderId != null && ids.Contains(l.TrPaymentHeader.InvoiceHeaderId.Value))
                    .Sum(l => (decimal?)l.PaymentLoc) ?? 0m;

                decimal fifo = 0m;
                if (!string.IsNullOrWhiteSpace(data.Header.CurrAccCode))
                {
                    Dictionary<Guid, decimal> map = GetFifoAllocation(data.Header.CurrAccCode);
                    map.TryGetValue(data.Header.InvoiceHeaderId, out fifo);
                }

                data.PaidLoc = Round2(linked + fifo);
                data.PaidRatio = PaidRatio(data.NetLocTotal, linked + fifo);
                return data.PaidRatio.Value;
            }

            private Dictionary<Guid, decimal> GetFifoAllocation(string currAccCode)
            {
                if (_fifoByCustomer.TryGetValue(currAccCode, out Dictionary<Guid, decimal>? cached))
                    return cached;

                Dictionary<Guid, decimal> result = new();
                _fifoByCustomer[currAccCode] = result;

                decimal unlinked = GetUnlinkedPaidLoc(currAccCode);
                if (unlinked <= 0m)
                    return result;

                string[] processes = SalesProcessCodes;

                var invoices = Db.TrInvoiceHeaders.AsNoTracking()
                    .Where(h => h.CurrAccCode == currAccCode && !h.IsReturn && h.IsCompleted && !h.IsSuspended && processes.Contains(h.ProcessCode))
                    .OrderBy(h => h.DocumentDate).ThenBy(h => h.DocumentTime).ThenBy(h => h.CreatedDate)
                    .Select(h => new { h.InvoiceHeaderId, Net = h.TrInvoiceLines.Sum(l => (decimal?)l.NetAmountLoc) ?? 0m })
                    .ToList();

                List<Guid> invoiceIds = invoices.Select(i => i.InvoiceHeaderId).ToList();

                var returnMap = Db.TrInvoiceHeaders.AsNoTracking()
                    .Where(h => h.IsReturn && h.RelatedInvoiceId != null && invoiceIds.Contains(h.RelatedInvoiceId.Value) && h.IsCompleted)
                    .Select(h => new { h.InvoiceHeaderId, Original = h.RelatedInvoiceId!.Value, Net = h.TrInvoiceLines.Sum(l => (decimal?)l.NetAmountLoc) ?? 0m })
                    .ToList();

                Dictionary<Guid, Guid> returnToOriginal = returnMap.ToDictionary(r => r.InvoiceHeaderId, r => r.Original);
                Dictionary<Guid, decimal> netAfterReturns = invoices.ToDictionary(i => i.InvoiceHeaderId, i => i.Net);
                foreach (var r in returnMap)
                    netAfterReturns[r.Original] = netAfterReturns.GetValueOrDefault(r.Original) + r.Net;

                List<Guid> allIds = invoiceIds.Concat(returnToOriginal.Keys).ToList();
                var linkedRaw = Db.TrPaymentLines.AsNoTracking()
                    .Where(l => l.TrPaymentHeader.InvoiceHeaderId != null && allIds.Contains(l.TrPaymentHeader.InvoiceHeaderId.Value))
                    .GroupBy(l => l.TrPaymentHeader.InvoiceHeaderId!.Value)
                    .Select(g => new { InvoiceId = g.Key, Paid = g.Sum(l => l.PaymentLoc) })
                    .ToList();

                Dictionary<Guid, decimal> linkedPaid = new();
                foreach (var lp in linkedRaw)
                {
                    Guid target = returnToOriginal.TryGetValue(lp.InvoiceId, out Guid orig) ? orig : lp.InvoiceId;
                    linkedPaid[target] = linkedPaid.GetValueOrDefault(target) + lp.Paid;
                }

                decimal remaining = unlinked;
                foreach (var inv in invoices)
                {
                    if (remaining <= 0m)
                        break;

                    decimal due = netAfterReturns.GetValueOrDefault(inv.InvoiceHeaderId) - linkedPaid.GetValueOrDefault(inv.InvoiceHeaderId);
                    if (due <= 0m)
                        continue;

                    decimal alloc = Math.Min(due, remaining);
                    result[inv.InvoiceHeaderId] = alloc;
                    remaining -= alloc;
                }

                return result;
            }

            // ---------- Loading helpers ----------

            private InvoiceData LoadInvoiceData(Guid invoiceHeaderId, Guid? excludeInvoiceId)
            {
                TrInvoiceHeader? header = Db.TrInvoiceHeaders.AsNoTracking()
                    .Include(h => h.TrInvoiceLines).ThenInclude(l => l.DcProduct)
                    .FirstOrDefault(h => h.InvoiceHeaderId == invoiceHeaderId);

                if (header == null)
                    return new InvoiceData();

                Dictionary<Guid, List<TrInvoiceHeader>> returns = LoadReturns(new List<Guid> { invoiceHeaderId }, excludeInvoiceId);
                returns.TryGetValue(invoiceHeaderId, out List<TrInvoiceHeader>? list);
                return BuildInvoiceData(header, list ?? new List<TrInvoiceHeader>());
            }

            private Dictionary<Guid, List<TrInvoiceHeader>> LoadReturns(List<Guid> originalIds, Guid? excludeInvoiceId)
            {
                if (originalIds.Count == 0)
                    return new Dictionary<Guid, List<TrInvoiceHeader>>();

                List<TrInvoiceHeader> returns = Db.TrInvoiceHeaders.AsNoTracking()
                    .Include(h => h.TrInvoiceLines).ThenInclude(l => l.DcProduct)
                    .Where(h => h.IsReturn && h.RelatedInvoiceId != null && originalIds.Contains(h.RelatedInvoiceId.Value)
                             && h.IsCompleted && !h.IsSuspended
                             && h.InvoiceHeaderId != excludeInvoiceId)
                    .ToList();

                return returns.GroupBy(r => r.RelatedInvoiceId!.Value).ToDictionary(g => g.Key, g => g.ToList());
            }

            private InvoiceData BuildInvoiceData(TrInvoiceHeader header, List<TrInvoiceHeader> returns)
            {
                InvoiceData data = new() { Header = header };
                Dictionary<Guid, TrInvoiceLine> originalLines = header.TrInvoiceLines.ToDictionary(l => l.InvoiceLineId);

                foreach (TrInvoiceLine l in header.TrInvoiceLines)
                    data.Lines.Add(ToEffLine(l, header.DocumentNumber, l.SalesPersonCode));

                foreach (TrInvoiceHeader r in returns)
                {
                    data.ReturnIds.Add(r.InvoiceHeaderId);
                    foreach (TrInvoiceLine l in r.TrInvoiceLines)
                    {
                        string? sp = l.SalesPersonCode;
                        if (string.IsNullOrWhiteSpace(sp) && l.RelatedLineId.HasValue && originalLines.TryGetValue(l.RelatedLineId.Value, out TrInvoiceLine? orig))
                            sp = orig.SalesPersonCode;

                        data.Lines.Add(ToEffLine(l, r.DocumentNumber, sp));
                    }
                }

                data.NetLocTotal = data.Lines.Sum(l => l.NetLoc);
                return data;
            }

            private static EffLine ToEffLine(TrInvoiceLine l, string docNum, string? salesPersonCode)
            {
                decimal qty = l.QtyIn + l.QtyOut;
                decimal cost = l.ProductCost ?? l.DcProduct?.PurchasePrice ?? 0m;
                return new EffLine
                {
                    LineId = l.InvoiceLineId,
                    ProductCode = l.ProductCode,
                    HierarchyCode = l.DcProduct?.HierarchyCode,
                    Qty = qty,
                    NetLoc = l.NetAmountLoc,
                    Cost = cost,
                    SalesPersonCode = salesPersonCode,
                    DocNum = docNum
                };
            }

            private List<(PlanContext Plan, TrSalesBonusAssignment Assignment)> GetActiveAssignments(string sp, DateTime date)
            {
                string key = $"{sp.ToUpperInvariant()}|{date:yyyyMMdd}";
                if (_assignments.TryGetValue(key, out var cached))
                    return cached;

                DateTime d = date.Date;
                List<TrSalesBonusAssignment> rows = Db.TrSalesBonusAssignments.AsNoTracking()
                    .Include(a => a.DcSalesBonusPlan)
                    .Where(a => a.SalesPersonCode == sp && a.IsActive && a.DcSalesBonusPlan.IsActive
                             && a.StartDate <= d && (a.EndDate == null || a.EndDate >= d))
                    .ToList();

                List<(PlanContext, TrSalesBonusAssignment)> result = rows
                    .GroupBy(a => a.SalesBonusPlanId)
                    .Select(g => g.OrderByDescending(a => a.StartDate).First())
                    .Select(a => (GetPlan(a.SalesBonusPlanId), a))
                    .ToList();

                _assignments[key] = result;
                return result;
            }

            private PlanContext GetPlan(Guid planId)
            {
                if (_plans.TryGetValue(planId, out PlanContext? ctx))
                    return ctx;

                DcSalesBonusPlan plan = Db.DcSalesBonusPlans.AsNoTracking()
                    .Include(p => p.Tiers)
                    .Include(p => p.Products)
                    .Include(p => p.Categories)
                    .First(p => p.SalesBonusPlanId == planId);

                ctx = new PlanContext(plan, GetHierarchyParents());
                _plans[planId] = ctx;
                return ctx;
            }

            private Dictionary<string, string?> GetHierarchyParents()
            {
                _hierarchyParents ??= Db.DcHierarchies.AsNoTracking()
                    .Select(h => new { h.HierarchyCode, h.HierarchyParentCode })
                    .ToList()
                    .ToDictionary(h => h.HierarchyCode, h => h.HierarchyParentCode, StringComparer.OrdinalIgnoreCase);
                return _hierarchyParents;
            }

            private string GetSalesPersonName(string sp)
            {
                _salesPersonNames ??= Db.DcCurrAccs.AsNoTracking()
                    .Where(c => c.CurrAccTypeCode == CurrAccType.Personnel)
                    .Select(c => new { c.CurrAccCode, Name = c.CurrAccDesc ?? ((c.FirstName ?? "") + " " + (c.LastName ?? "")) })
                    .ToList()
                    .ToDictionary(c => c.CurrAccCode, c => c.Name.Trim(), StringComparer.OrdinalIgnoreCase);

                return _salesPersonNames.TryGetValue(sp, out string? name) ? name : sp;
            }
        }

        #endregion

        #region Internal models

        private sealed record CalcResult(decimal Expected, decimal Base, decimal Rate, object Details)
        {
            public static CalcResult Zero(string reason) => new(0m, 0m, 0m, new { Reason = reason });
        }

        private sealed record PeriodAggregate(decimal Base, int Count, List<object> Traces);

        private sealed class EffLine
        {
            public Guid LineId;
            public string ProductCode = string.Empty;
            public string? HierarchyCode;
            public decimal Qty;
            public decimal NetLoc;
            public decimal Cost;
            public string? SalesPersonCode;
            public string DocNum = string.Empty;
        }

        private sealed class InvoiceData
        {
            public TrInvoiceHeader? Header;
            public readonly List<EffLine> Lines = new();
            public readonly List<Guid> ReturnIds = new();
            public decimal NetLocTotal;
            public decimal? PaidRatio;
            public decimal PaidLoc;
        }

        /// <summary>Plan + intervallar + məhsul/kateqoriya filtri (alt kateqoriyalar daxil).</summary>
        private sealed class PlanContext
        {
            public readonly DcSalesBonusPlan Plan;
            public readonly List<TierDef> Tiers;
            private readonly HashSet<string> _processCodes;
            private readonly Dictionary<string, decimal?> _productRates;
            private readonly Dictionary<string, decimal?> _categoryRates;

            public PlanContext(DcSalesBonusPlan plan, Dictionary<string, string?> hierarchyParents)
            {
                Plan = plan;
                Tiers = plan.Tiers.OrderBy(t => t.FromValue).Select(t => new TierDef(t.FromValue, t.ToValue, t.Rate, t.FixedAmount)).ToList();

                _processCodes = (plan.ProcessCodes ?? string.Empty)
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(x => x.ToUpperInvariant())
                    .ToHashSet();

                _productRates = plan.Products.ToDictionary(p => p.ProductCode, p => p.RateOverride, StringComparer.OrdinalIgnoreCase);

                _categoryRates = new Dictionary<string, decimal?>(StringComparer.OrdinalIgnoreCase);
                foreach (DcSalesBonusPlanCategory c in plan.Categories)
                {
                    foreach (string code in hierarchyParents.Keys)
                    {
                        if (IsSelfOrDescendant(code, c.HierarchyCode, hierarchyParents))
                            _categoryRates[code] = c.RateOverride;
                    }
                    _categoryRates[c.HierarchyCode] = c.RateOverride;
                }
            }

            private static bool IsSelfOrDescendant(string code, string ancestor, Dictionary<string, string?> parents)
            {
                string? current = code;
                int guard = 0;
                while (current != null && guard++ < 50)
                {
                    if (string.Equals(current, ancestor, StringComparison.OrdinalIgnoreCase))
                        return true;
                    parents.TryGetValue(current, out current);
                }
                return false;
            }

            public bool HasFilter => _productRates.Count > 0 || _categoryRates.Count > 0;

            public bool AppliesToProcess(string processCode) => _processCodes.Count == 0 || _processCodes.Contains(processCode.ToUpperInvariant());

            /// <summary>Məhsul filtrə uyğundursa tətbiq olunan dərəcə, uyğun deyilsə null.</summary>
            public decimal? RateFor(string productCode, string? hierarchyCode)
            {
                if (!HasFilter)
                    return Plan.Rate;

                if (_productRates.TryGetValue(productCode, out decimal? pr))
                    return pr ?? Plan.Rate;

                if (!string.IsNullOrEmpty(hierarchyCode) && _categoryRates.TryGetValue(hierarchyCode, out decimal? cr))
                    return cr ?? Plan.Rate;

                return null;
            }
        }

        #endregion
    }
}
