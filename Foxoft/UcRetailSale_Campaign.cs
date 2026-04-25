// UcRetailSale_Campaign.cs
// Partial class — bütün kampaniya inteqrasiyası burada cəmlənmişdir.
//
// ── UcRetailSale.cs-də DƏYİŞİKLİKLƏR ──────────────────────────────────────
//  1. Mövcud sahələri SİLİN:
//       private string? promoCode = null;
//       private bool _isApplyingCampaign = false;
//     (Bu fayl onları yenidən elan edir)
//
//  2. ClearControlsAddNew() içinə əlavə edin:
//       InitCampaignService();
//       _cashOnlyCampaignApplied = false;
//
//  3. LoadInvoice() sonuna əlavə edin:
//       InitCampaignService();
//       _cashOnlyCampaignApplied = _campaignService.HasCashOnlyCampaignApplied(InvoiceHeaderId);
//
//  4. SaveInvoice()-dən sonra çağırılan hər yerdə (AddNewRow, barcode scan,
//     btn_DeleteLine, gC_Sale_DoubleClick, btn_InvoiceDiscount, btn_LineDiscount):
//       RecalcCampaignsIfNeeded();
//       AutoApplyCampaignsIfConfigured();
//
//  5. btn_Payment_Click metodunu SİLİN → bu fayl onu tam yenidən yazır.
//
//  6. ApplyCampaignsFromForm, GetAvailablePaymentMethodCampaignIds,
//     AskApplyPaymentMethodCampaign metodlarını SİLİN
//     (bu fayl həmin funksionallığı CampaignService vasitəsilə yerinə yetirir)
//
//  7. Designer-də (UcRetailSale_Designer.cs) 4 yeni SimpleButton əlavə edin:
//       btn_CampaignApply   → Click += btn_CampaignApply_Click
//       btn_CampaignDelete  → Click += btn_CampaignDelete_Click
//       btn_CampaignLog     → Click += btn_CampaignLog_Click
//       btn_PromoCode       → Click += btn_PromoCode_Click
//     (aşağıda tam Designer snippet verilmişdir)
// ───────────────────────────────────────────────────────────────────────────

using DevExpress.XtraEditors;
using Foxoft.AppCode.Services;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Foxoft
{
    public partial class UcRetailSale
    {
        // ══════════════════════════════════════════════════════
        //  SAHƏLƏR
        // ══════════════════════════════════════════════════════
        private CampaignService _campaignService = null!;
        private string? _promoCode = null;
        private bool _cashOnlyCampaignApplied = false;
        private bool _isApplyingCampaign = false;

        // ══════════════════════════════════════════════════════
        //  İNİSİALİZASİYA
        // ══════════════════════════════════════════════════════

        private void InitCampaignService()
        {
            _campaignService = new CampaignService(dbContext);
        }

        // ══════════════════════════════════════════════════════
        //  YARDIMÇI
        // ══════════════════════════════════════════════════════

        private List<TrInvoiceLine> GetInvoiceLines()
        {
            var lines = new List<TrInvoiceLine>();
            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                if (gV_InvoiceLine.GetRow(i) is TrInvoiceLine line)
                    lines.Add(line);
            return lines;
        }

        // ══════════════════════════════════════════════════════
        //  DÜYMƏ HADİSƏLƏRİ
        // ══════════════════════════════════════════════════════

        /// <summary>"Kampaniya Tətbiq Et" düyməsi</summary>
        private void btn_CampaignApply_Click(object sender, EventArgs e)
            => ApplyRegularCampaigns();

        private void ApplyRegularCampaigns(bool silentIfNone = false)
        {
            if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty) return;
            if (gV_InvoiceLine.DataRowCount <= 0)
            {
                if (!silentIfNone)
                    XtraMessageBox.Show("Fakturada məhsul yoxdur.",
                        Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();
            trInvoiceLinesBindingSource.EndEdit();

            InitCampaignService();
            var result = _campaignService.ApplyCampaigns(
                trInvoiceHeader, GetInvoiceLines(), _promoCode, CampaignFilter.RegularOnly);

            gV_InvoiceLine.RefreshData();
            if (result.Success) SaveInvoice();

            if (!silentIfNone || result.Success)
                XtraMessageBox.Show(result.Message, "Kampaniya",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        /// <summary>"Kampaniyaları Sil" düyməsi</summary>
        private void btn_CampaignDelete_Click(object sender, EventArgs e)
        {
            if (trInvoiceHeader is null) return;

            if (XtraMessageBox.Show(
                "Tətbiq edilmiş bütün kampaniya endirimi silinsin?",
                Resources.Common_Attention,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            InitCampaignService();
            var lines = GetInvoiceLines();
            _campaignService.RemoveAllCampaigns(trInvoiceHeader, lines);
            _cashOnlyCampaignApplied = false;
            _promoCode = null;

            gV_InvoiceLine.RefreshData();
            SaveInvoice();

            XtraMessageBox.Show("Kampaniya endirimi silindi.",
                "Kampaniya", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>"Kampaniya Log" düyməsi</summary>
        private void btn_CampaignLog_Click(object sender, EventArgs e)
        {
            if (trInvoiceHeader is null) return;
            InitCampaignService();

            var logs = _campaignService.GetCampaignLogs(trInvoiceHeader.InvoiceHeaderId);
            if (!logs.Any())
            {
                XtraMessageBox.Show("Heç bir kampaniya tətbiq edilməyib.",
                    "Kampaniya Loqu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var text = string.Join("\n\n", logs
                .GroupBy(l => new { l.CampaignCode, l.CampaignDesc })
                .Select(g =>
                    $"{g.Key.CampaignCode} – {g.Key.CampaignDesc}\n" +
                    $"  Sətir sayı : {g.Count()}\n" +
                    $"  Endirim    : {g.Sum(l => l.DiscountAmount):n2}  ({g.Sum(l => l.DiscountAmountLoc):n2} AZN)"));

            XtraMessageBox.Show(text, "Kampaniya Loqu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>"Promo Kod" düyməsi</summary>
        private void btn_PromoCode_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Promo kodu daxil edin:", "Promo Kod",
                _promoCode ?? "").Trim();

            if (string.IsNullOrEmpty(input)) return;

            InitCampaignService();
            var lines = GetInvoiceLines();

            // Mövcud kampaniyaları sil
            _campaignService.RemoveAllCampaigns(trInvoiceHeader, lines);
            _cashOnlyCampaignApplied = false;
            _promoCode = input;

            var result = _campaignService.ApplyCampaigns(
                trInvoiceHeader, lines, _promoCode, CampaignFilter.RegularOnly);

            gV_InvoiceLine.RefreshData();
            if (result.Success) SaveInvoice();

            XtraMessageBox.Show(result.Message, "Promo Kod",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        // ══════════════════════════════════════════════════════
        //  ÖDƏNİŞ DÜYMƏSİ  (mövcud btn_Payment_Click ƏVƏZİNƏ)
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// Cash / Cashless / Bonus ödəniş düymələri üçün ortaq handler.
        /// IsCashOnly kampaniya yoxlaması daxildir.
        /// Mövcud btn_Payment_Click metodunu SİLİB bu metodu istifadə edin:
        ///   btn_Cash.Click         += btn_Payment_Click;
        ///   btn_Cashless.Click     += btn_Payment_Click;
        ///   btn_CustomerBonus.Click += btn_Payment_Click;
        /// </summary>
        private void btn_Payment_Click(object sender, EventArgs e)
        {
            if (trInvoiceHeader is null) return;

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();
            trInvoiceLinesBindingSource.EndEdit();

            if (gV_InvoiceLine.DataRowCount <= 0) return;

            SaveInvoice();

            // ── Temel ödəniş növü ──────────────────────────────
            PaymentType paymentType = PaymentType.Cash;
            if (sender == btn_Cashless) paymentType = PaymentType.Cashless;
            else if (sender == btn_CustomerBonus) paymentType = PaymentType.Bonus;

            // ── IsCashOnly kampaniya yoxlaması ─────────────────
            IEnumerable<int>? allowedPaymentMethodIds = null;

            bool cashOnlyApplied = false;
            if (IsCampaignEnabled)
                cashOnlyApplied = TryApplyCashOnlyCampaign(ref paymentType, out allowedPaymentMethodIds);

            decimal pay = Math.Abs(efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId));

            // ── FormPayment ────────────────────────────────────
            using FormPayment formPayment = allowedPaymentMethodIds != null
                ? new FormPayment(paymentType, pay, trInvoiceHeader, allowedPaymentMethodIds)
                : new FormPayment(paymentType, pay, trInvoiceHeader);

            if (formPayment.ShowDialog(this) == DialogResult.OK)
            {
                if (IsCampaignEnabled)
                {
                    ReloadInvoiceCampaignValues();
                }
                CalcPaidAmount();
            }
            else
            {
                if (IsCampaignEnabled)
                {
                    // İstifadəçi ləğv etdi → IsCashOnly geri al
                    if (cashOnlyApplied)
                        RollbackCashOnlyCampaign();
                }
            }

            ActiveControl = txtEdit_Barcode;
        }

        // ── IsCashOnly kampaniya sihirbazı ──────────────────────────────
        private bool TryApplyCashOnlyCampaign(
            ref PaymentType paymentType,
            out IEnumerable<int>? allowedPaymentMethodIds)
        {
            allowedPaymentMethodIds = null;

            InitCampaignService();
            var lines = GetInvoiceLines();
            var cashOnlyCampaigns = _campaignService.GetEligibleCampaigns(
                trInvoiceHeader, lines, null, CampaignFilter.CashOnlyOnly);

            if (!cashOnlyCampaigns.Any()) return false;

            var campaign = cashOnlyCampaigns.First();

            // 1) İstifadəçiyə soruş
            string discountStr = campaign.DiscountTypeCode == DiscountTypeCode.Percent
                ? $"{campaign.DiscountValue}%"
                : $"{campaign.DiscountValue:n2} AZN";

            var answer = XtraMessageBox.Show(
                $"«{campaign.CampaignDesc}» kampaniyası tətbiq edilə bilər.\n\n" +
                $"Endirim: {discountStr}\n" +
                "⚠  Bu kampaniya yalnız nağd ödənişdə keçərlidir.\n\n" +
                "Tətbiq edilsin?",
                "Kampaniya",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return false;

            // 2) Şifrə yoxla
            if (!string.IsNullOrEmpty(campaign.CampaignPassword))
            {
                string pwd = Interaction.InputBox("Kampaniya şifrəsini daxil edin:", "Şifrə", "");
                if (pwd != campaign.CampaignPassword)
                {
                    XtraMessageBox.Show("Şifrə yanlışdır! Kampaniya tətbiq edilmədi.",
                        Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // 3) Tətbiq et
            var result = _campaignService.ApplyCampaigns(
                trInvoiceHeader, lines, null, CampaignFilter.CashOnlyOnly);

            if (!result.Success)
            {
                XtraMessageBox.Show("Kampaniya tətbiq edilmədi.",
                    Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            gV_InvoiceLine.RefreshData();
            SaveInvoice();
            _cashOnlyCampaignApplied = true;

            // Yalnız nağd ödəniş metodları
            paymentType = PaymentType.Cash;
            allowedPaymentMethodIds = efMethods
                .SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cash })
                .Select(m => m.PaymentMethodId);

            return true;
        }

        // ── IsCashOnly geri alma ─────────────────────────────────────────
        private void RollbackCashOnlyCampaign()
        {
            try
            {
                var cashOnlyLogs = dbContext.TrInvoiceCampaignLogs
                    .Include(l => l.DcCampaign)
                    .Where(l => l.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId
                                && l.DcCampaign.IsCashOnly)
                    .ToList();

                foreach (var log in cashOnlyLogs)
                {
                    var line = GetInvoiceLines()
                        .FirstOrDefault(l => l.InvoiceLineId == log.InvoiceLineId);
                    if (line != null)
                        line.DiscountCampaign = Math.Max(0, line.DiscountCampaign - log.DiscountAmount);
                }

                dbContext.TrInvoiceCampaignLogs.RemoveRange(cashOnlyLogs);

                gV_InvoiceLine.RefreshData();
                SaveInvoice();
                _cashOnlyCampaignApplied = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RollbackCashOnlyCampaign: {ex.Message}");
            }
        }

        // ══════════════════════════════════════════════════════
        //  SƏTİR DƏYİŞİKLİYİ – yenidən hesablama
        //  SaveInvoice()-dən SONRA hər yerdə çağırın
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// Kampaniya tətbiq edilibsə sətir dəyişikliyindən (qty/qiymət/məhsul)
        /// sonra avtomatik yenidən hesabla.
        /// SaveInvoice()-dən sonra çağırın.
        /// </summary>
        private void RecalcCampaignsIfNeeded()
        {
            if (_isApplyingCampaign) return;
            if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty) return;

            InitCampaignService();
            if (!_campaignService.HasCampaignApplied(trInvoiceHeader.InvoiceHeaderId)) return;

            _isApplyingCampaign = true;
            try
            {
                var recalcResult = _campaignService.RecalculateCampaigns(
                    trInvoiceHeader,
                    GetInvoiceLines(),
                    _promoCode,
                    _cashOnlyCampaignApplied);

                gV_InvoiceLine.RefreshData();
                if (recalcResult.Success) SaveInvoice();
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        // ══════════════════════════════════════════════════════
        //  OTOMATİK TƏTBİQ (IsAutoApply)
        //  SaveInvoice()-dən sonra çağırın
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// IsAutoApply=true kampaniyaları məhsul əlavə/silindikdə avtomatik tətbiq edir.
        /// Kampaniya artıq tətbiq edilibsə yenidən tətbiq etmir.
        /// </summary>
        private void AutoApplyCampaignsIfConfigured()
        {
            if (_isApplyingCampaign) return;
            if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty) return;

            InitCampaignService();
            var lines = GetInvoiceLines();
            var eligible = _campaignService.GetEligibleCampaigns(
                trInvoiceHeader, lines, _promoCode, CampaignFilter.RegularOnly);

            if (!eligible.Any(c => c.IsAutoApply)) return;

            _isApplyingCampaign = true;
            try
            {
                var result = _campaignService.ApplyCampaigns(
                    trInvoiceHeader, lines, _promoCode, CampaignFilter.RegularOnly);

                if (result.Success)
                {
                    gV_InvoiceLine.RefreshData();
                    SaveInvoice();
                }
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        // ══════════════════════════════════════════════════════
        //  KÖHNƏLMİŞ METODLARIN YERİNİ TUTUR
        //  (UcRetailSale.cs-dən bu metodları silin)
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// ReloadInvoiceCampaignValues — mövcud metod saxlanır,
        /// ancaq CampaignService-ə uyğunlaşdırılır.
        /// </summary>
        private void ReloadInvoiceCampaignValues()
        {
            if (dbContext is null || trInvoiceHeader is null) return;

            var trackedLines = dbContext.TrInvoiceLines
                .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                .ToList();

            foreach (var line in trackedLines)
            {
                try { dbContext.Entry(line).Reload(); }
                catch { /* log */ }
            }

            trInvoiceLinesBindingSource?.ResetBindings(false);
            gV_InvoiceLine.RefreshData();
        }
    }
}
