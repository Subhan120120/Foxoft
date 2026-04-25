// FormInvoice_Campaign.cs
// Partial class – bütün kampaniya inteqrasiyası bu faylda toplanmışdır.
//
// FormInvoice.cs-də edilməli dəyişikliklər:
//   1. Sahələr əlavə et:
//        private CampaignService _campaignService = null!;
//        private bool   _cashOnlyCampaignApplied  = false;
//        private string? _appliedPromoCode         = null;
//   2. ClearControlsAddNew() sonuna:  InitCampaignService();
//   3. LoadInvoiceAsync()    sonuna:  InitCampaignService();
//                                    _cashOnlyCampaignApplied = _campaignService.HasCashOnlyCampaignApplied(invoiceHeaderId);
//   4. bBI_Payment_ItemClick       →  bBI_Payment_ItemClick_WithCampaign ilə ƏVƏZLƏYİN
//   5. bBI_PaymentDelete_ItemClick →  bBI_PaymentDelete_ItemClick_WithCampaign ilə ƏVƏZLƏYİN
//   6. gV_InvoiceLine_RowUpdated   → SaveInvoice()-dən SONRA əlavə et:
//        RecalcCampaignsIfNeeded();
//        AutoApplyCampaignsIfConfigured();
//   7. Designer-də bBI_CampaignDelete.ItemClick → bBI_CampaignDelete_ItemClick

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Foxoft.AppCode.Services;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormInvoice
    {
        // ══════════════════════════════════════════════════════
        //  YENİ SAHƏLƏR  (FormInvoice.cs-ə əlavə edilməlidir)
        // ══════════════════════════════════════════════════════
        private CampaignService _campaignService = null!;
        private bool _cashOnlyCampaignApplied = false;
        private string? _appliedPromoCode = null;

        // ══════════════════════════════════════════════════════
        //  İNİSİALİZASİYA
        // ══════════════════════════════════════════════════════
        private void InitCampaignIfEnabled()
        {
            if (!IsCampaignEnabled)
            {
                _cashOnlyCampaignApplied = false;
                _appliedPromoCode = null;
                return;
            }

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
        //  RIBBON DÜYMƏLƏRİ
        // ══════════════════════════════════════════════════════

        /// <summary>"Kampaniya Tətbiq Et" düyməsi</summary>
        private void bBI_CampaignApply_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsCampaignEnabled)
                return;

            ApplyRegularCampaigns();
        }

        private void ApplyRegularCampaigns()
        {
            if (trInvoiceHeader is null) return;
            if (gV_InvoiceLine.DataRowCount <= 0)
            {
                XtraMessageBox.Show("Fakturada məhsul yoxdur.",
                    Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();

            InitCampaignIfEnabled();
            var result = _campaignService.ApplyCampaigns(
                trInvoiceHeader, GetInvoiceLines(), _appliedPromoCode, CampaignFilter.RegularOnly);

            gV_InvoiceLine.RefreshData();
            if (result.Success) SaveInvoice();

            XtraMessageBox.Show(result.Message, "Kampaniya",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        /// <summary>"Kampaniya Log" düyməsi – tətbiq edilmiş kampaniyaları göstər</summary>
        private void bBI_CampaignLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;
            InitCampaignIfEnabled();

            var logs = _campaignService.GetCampaignLogs(trInvoiceHeader.InvoiceHeaderId);
            if (!logs.Any())
            {
                XtraMessageBox.Show("Heç bir kampaniya tətbiq edilməyib.",
                    "Kampaniya Loqu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var grouped = logs
                .GroupBy(l => new { l.CampaignCode, l.CampaignDesc })
                .Select(g => new
                {
                    g.Key.CampaignCode,
                    g.Key.CampaignDesc,
                    TotalDiscount = g.Sum(l => l.DiscountAmount),
                    TotalDiscountLoc = g.Sum(l => l.DiscountAmountLoc),
                    Lines = g.Count()
                });

            string text = string.Join("\n\n", grouped.Select(g =>
                $"{g.CampaignCode} – {g.CampaignDesc}\n" +
                $"  Sətir sayı : {g.Lines}\n" +
                $"  Endirim    : {g.TotalDiscount:n2}  ({g.TotalDiscountLoc:n2} AZN)"));

            XtraMessageBox.Show(text, "Kampaniya Loqu",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>"Promo Kod" düyməsi</summary>
        private void BBI_PromoCodeCampaign_ItemClick(object sender, ItemClickEventArgs e)
        {
            var input = XtraInputBox.Show("Promo kodu daxil edin:", "Promo Kod",
                _appliedPromoCode ?? "");
            if (input == null) return;

            string code = input.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(code)) return;

            InitCampaignIfEnabled();
            var lines = GetInvoiceLines();

            // Mövcud endirimləri sil
            _campaignService.RemoveAllCampaigns(trInvoiceHeader, lines);
            _cashOnlyCampaignApplied = false;
            _appliedPromoCode = code;

            var result = _campaignService.ApplyCampaigns(
                trInvoiceHeader, lines, _appliedPromoCode, CampaignFilter.RegularOnly);

            gV_InvoiceLine.RefreshData();
            if (result.Success) SaveInvoice();

            XtraMessageBox.Show(result.Message, "Promo Kod",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        /// <summary>"Kampaniyaları Sil" düyməsi</summary>
        private void bBI_CampaignDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;

            if (XtraMessageBox.Show(
                "Tətbiq edilmiş bütün kampaniya endirimi silinsin?",
                Resources.Common_Attention,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            InitCampaignIfEnabled();
            var lines = GetInvoiceLines();
            _campaignService.RemoveAllCampaigns(trInvoiceHeader, lines);
            _cashOnlyCampaignApplied = false;
            _appliedPromoCode = null;

            gV_InvoiceLine.RefreshData();
            SaveInvoice();

            XtraMessageBox.Show("Kampaniya endirimi silindi.",
                "Kampaniya", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ══════════════════════════════════════════════════════
        //  ÖDƏNİŞ DÜYMƏSİ  (mövcud bBI_Payment_ItemClick ƏVƏZİNƏ)
        // ══════════════════════════════════════════════════════
        private void bBI_Payment_ItemClick_WithCampaign(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();
            dataLayoutControl1.Validate();

            if (!dataLayoutControl1.IsValid(out _)) return;
            if (gV_InvoiceLine.DataRowCount <= 0) return;

            SaveInvoice();

            decimal pay = GetRemainingPaymentAmount();
            if (pay <= 0)
            {
                XtraMessageBox.Show("Ödəniləcək məbləğ qalmayıb.", "Ödəniş",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IEnumerable<int>? allowedPaymentMethodIds = null;
            if (IsCampaignEnabled)
            {
                // IsCashOnly kampaniya yoxlaması
                TryApplyCashOnlyCampaign(ref pay, out allowedPaymentMethodIds);
            }

            // FormPayment açılır
            using FormPayment form = new(PaymentType.Cash, pay, trInvoiceHeader, allowedPaymentMethodIds);

            if (form.ShowDialog(this) != DialogResult.OK)
            {
                if (IsCampaignEnabled)
                    if (_cashOnlyCampaignApplied)
                    {
                        // İstifadəçi ödənişi ləğv etdi → IsCashOnly geri al
                        RollbackCashOnlyCampaign();
                    }

                return;
            }

            UpdatePaidLabels();
        }

        // ── IsCashOnly kampaniya sihirbazı ──────────────────────────────
        private bool TryApplyCashOnlyCampaign(
            ref decimal remainingPay,
            out IEnumerable<int>? allowedPaymentMethodIds)
        {
            allowedPaymentMethodIds = null;

            InitCampaignIfEnabled();
            var lines = GetInvoiceLines();
            var cashOnlyCampaigns = _campaignService.GetEligibleCampaigns(
                trInvoiceHeader, lines, null, CampaignFilter.CashOnlyOnly);

            if (!cashOnlyCampaigns.Any()) return false;

            var campaign = cashOnlyCampaigns.First(); // ən yüksək prioritet

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
                var pwd = XtraInputBox.Show("Kampaniya şifrəsini daxil edin:", "Şifrə", "");
                if (pwd?.ToString() != campaign.CampaignPassword)
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

            // Yenilənmiş ödəniləcək məbləğ
            remainingPay = GetRemainingPaymentAmount();

            // Yalnız nağd ödəniş metodlarını icazəli et
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
                // CashOnly logları tap
                var cashOnlyLogs = dbContext.TrInvoiceCampaignLogs
                    .Include(l => l.DcCampaign)
                    .Where(l => l.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId
                                && l.DcCampaign.IsCashOnly)
                    .ToList();

                // Hər sətirdəki CashOnly endirimi geri al
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
        //  ÖDƏNİŞ SİLMƏ  (mövcud bBI_PaymentDelete_ItemClick ƏVƏZİNƏ)
        // ══════════════════════════════════════════════════════
        private void bBI_PaymentDelete_ItemClick_WithCampaign(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;

            if (IsCampaignEnabled)
            {
                // IsCashOnly kampaniya tətbiq edilibsə – silinməyə icazə verma
                InitCampaignIfEnabled();

                if (_campaignService.HasCashOnlyCampaignApplied(trInvoiceHeader.InvoiceHeaderId))
                {
                    XtraMessageBox.Show(
                        "Bu fakturaya nağd ödəniş kampaniyası (IsCashOnly) tətbiq edilib.\n" +
                        "Ödənişi silmədən öncə kampaniya endirimi ləğv edilməlidir.\n\n" +
                        "Bunun üçün «Kampaniyaları Sil» düyməsindən istifadə edin.",
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

            }
            if (MessageBox.Show(
                Resources.Form_Invoice_DeletePaymentsQuestion,
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                UpdatePaidLabels();
            }
        }

        // ══════════════════════════════════════════════════════
        //  SƏTİR YENİLƏNMƏSİ – kampaniya yenidən hesablama
        //  gV_InvoiceLine_RowUpdated içinə SaveInvoice()-dən SONRA əlavə et
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// Kampaniya tətbiq edilmişsə sətir dəyişikliyindən sonra yenidən hesabla.
        /// </summary>
        private void RecalcCampaignsIfNeeded()
        {
            if (!IsCampaignEnabled)
                return;

            if (trInvoiceHeader is null) return;
            InitCampaignIfEnabled();

            if (!_campaignService.HasCampaignApplied(trInvoiceHeader.InvoiceHeaderId))
                return;

            var recalcResult = _campaignService.RecalculateCampaigns(
                trInvoiceHeader,
                GetInvoiceLines(),
                _appliedPromoCode,
                _cashOnlyCampaignApplied);

            gV_InvoiceLine.RefreshData();

            if (recalcResult.Success)
                SaveInvoice();
        }

        // ══════════════════════════════════════════════════════
        //  OTOMATİK TƏTBİQ (IsAutoApply)
        //  gV_InvoiceLine_RowUpdated içindən çağırılabilər
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// IsAutoApply=true olan kampaniyaları məhsul əlavə edildikdə avtomatik tətbiq edir.
        /// Kampaniya artıq tətbiq edilibsə yenidən tətbiq etmir.
        /// </summary>
        private void AutoApplyCampaignsIfConfigured()
        {
            if (trInvoiceHeader is null) return;
            InitCampaignIfEnabled();

            var lines = GetInvoiceLines();
            var eligible = _campaignService.GetEligibleCampaigns(
                trInvoiceHeader, lines, _appliedPromoCode, CampaignFilter.RegularOnly);

            if (!eligible.Any(c => c.IsAutoApply)) return;

            var result = _campaignService.ApplyCampaigns(
                trInvoiceHeader, lines, _appliedPromoCode, CampaignFilter.RegularOnly);

            if (result.Success)
                gV_InvoiceLine.RefreshData();
        }
    }
}
