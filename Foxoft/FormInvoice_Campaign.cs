// ============================================================
//  FormInvoice_Campaign.cs
//  Kampaniya məntiqi üçün FormInvoice partial uzantısı.
//
//  FormInvoice.cs-də aşağıdakı DƏYİŞİKLİKLƏR lazımdır:
//  ➊  bBI_Payment_ItemClick metodunu bu fayldakı versiya ilə əvəz edin.
//  ➋  Sinif daxilindəki  private string promoCode = null;  sətri
//      artıq bu fayldadır — FormInvoice.cs-dəki dublikatı silin.
// ============================================================

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
        // ── Kampaniya xidməti ──────────────────────────────────────
        private CampaignService? _campaignService;
        private CampaignApplyResult? _pendingCampaignResult;

        private CampaignService GetCampaignService()
            => _campaignService ??= new CampaignService(dbContext, efMethods);

        // ──────────────────────────────────────────────────────────
        //  RİBBON DÜYMƏ HADİSƏLƏRİ
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// "Kampaniya Tətbiq Et" düyməsi — IsCashOnly olmayan kampaniyaları tətbiq edir.
        /// </summary>
        private void bBI_CampaignApply_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplyCampaignsManually(cashOnly: false);
        }

        /// <summary>Kampaniya loqlarını göstər.</summary>
        private void bBI_CampaignLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowCampaignLog();
        }

        /// <summary>Promo kodu ilə kampaniya tətbiq et.</summary>
        private void BBI_PromoCodeCampaign_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplyPromoCode();
        }

        // ──────────────────────────────────────────────────────────
        //  ÖDƏNİŞ AXINI  (bBI_Payment_ItemClick)
        //  Bu metod FormInvoice.cs-dəki eyni adlı metodu ƏVƏZ EDİR.
        // ──────────────────────────────────────────────────────────

        private void bBI_Payment_ItemClick(object sender, ItemClickEventArgs e)
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
                XtraMessageBox.Show(
                    "Ödəniləcək məbləğ qalmayıb.",
                    "Ödəniş",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // ── IsCashOnly kampaniya yoxlanması ──────────────────
            IEnumerable<int>? allowedPaymentMethodIds = null;

            if (!TryApplyCashOnlyCampaignBeforePayment(out allowedPaymentMethodIds))
                return; // istifadəçi prosesi ləğv etdi

            // Yalnız nağd kampaniya tətbiq edilibsə ödəniş tipini nağd aç
            PaymentType paymentType = allowedPaymentMethodIds?.Any() == true
                ? PaymentType.Cash
                : ResolvePaymentTypeByAllowedMethods(allowedPaymentMethodIds, PaymentType.Cash);

            using FormPayment form = new(paymentType, pay, trInvoiceHeader, allowedPaymentMethodIds);

            if (form.ShowDialog(this) != DialogResult.OK)
            {
                OnPaymentCancelled(); // kampaniya varsa rollback et
                return;
            }

            // Ödəniş uğurlu — pending kampaniya artıq qəbul edildi
            _pendingCampaignResult = null;

            UpdatePaidLabels();
        }

        // ──────────────────────────────────────────────────────────
        //  IsCashOnly KAMPANIYA MƏNTIQI
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// Ödəniş formu açılmadan əvvəl IsCashOnly kampaniyaları yoxlayır.
        /// İstifadəçi kampaniyanı qəbul edib şifrəni düzgün girərsə:
        ///   – endirim dərhal sətirlərinə tətbiq edilir;
        ///   – allowedPaymentMethodIds yalnız nağd metodlarla doldurulur.
        /// Qaytarma dəyəri: false → proses tamamilə dayandırılsın.
        /// </summary>
        private bool TryApplyCashOnlyCampaignBeforePayment(
            out IEnumerable<int>? allowedPaymentMethodIds)
        {
            allowedPaymentMethodIds = null;

            var lines = GetInvoiceLines();
            if (!lines.Any()) return true;

            var svc = GetCampaignService();
            var cashOnlyCampaigns = svc.GetApplicableCashOnlyCampaigns(trInvoiceHeader, lines);

            if (!cashOnlyCampaigns.Any()) return true; // kampaniya yoxdur, normal davam et

            // Ən yüksək prioritetli kampaniya seçilir
            var campaign = cashOnlyCampaigns.OrderByDescending(c => c.Priority).First();

            // ─── İstifadəçiyə soruş ──────────────────────────────
            var answer = XtraMessageBox.Show(
                $"'{campaign.CampaignDesc}' kampaniyası mövcuddur.\n" +
                $"Bu kampaniya yalnız nağd ödənişdə keçərlidir.\n\n" +
                $"Endirim dəyəri: {FormatDiscount(campaign)}\n\n" +
                "Kampaniya tətbiq edilsin?",
                "Kampaniya",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.No)
                return true; // kampaniyasız normal ödənişə keç

            // ─── Şifrə yoxlanması ───────────────────────────────
            if (!string.IsNullOrEmpty(campaign.CampaignPassword))
            {
                var pwd = XtraInputBox.Show(
                    "Kampaniya şifrəsini daxil edin:",
                    "Kampaniya Şifrəsi",
                    "");

                if (string.IsNullOrEmpty(pwd) || pwd != campaign.CampaignPassword)
                {
                    XtraMessageBox.Show(
                        "Şifrə yanlışdır. Kampaniya tətbiq edilmədi.",
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return true; // kampaniyasız normal ödənişə keç
                }
            }

            // ─── Kampaniyanı tətbiq et ──────────────────────────
            var result = svc.ApplyCampaign(campaign, trInvoiceHeader, lines);

            if (!result.Success)
            {
                XtraMessageBox.Show(
                    result.Message,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return true; // kampaniyasız normal ödənişə keç
            }

            // Rollback üçün nəticəni yadda saxla
            _pendingCampaignResult = result;
            gV_InvoiceLine.RefreshData();

            // Nağd ödəniş metodlarını müəyyən et
            var cashMethodIds = efMethods
                .SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cash })
                .Select(x => x.PaymentMethodId)
                .ToList();

            allowedPaymentMethodIds = cashMethodIds;

            XtraMessageBox.Show(
                result.Message,
                "Kampaniya Tətbiq Edildi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

        // ──────────────────────────────────────────────────────────
        //  ROLLBACK — ödəniş formu ləğv edildikdə
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// FormPayment ləğv edildikdə çağırılır.
        /// Əgər IsCashOnly kampaniyası tətbiq edilibsə — geri alınır.
        /// </summary>
        private void OnPaymentCancelled()
        {
            if (_pendingCampaignResult == null) return;

            var lines = GetInvoiceLines();
            GetCampaignService().RollbackCampaign(_pendingCampaignResult, lines);
            _pendingCampaignResult = null;

            gV_InvoiceLine.RefreshData();
            SaveInvoice();

            XtraMessageBox.Show(
                "Ödəniş ləğv edildi. Tətbiq olunmuş kampaniya endirimi geri alındı.",
                Resources.Common_Attention,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ──────────────────────────────────────────────────────────
        //  MANUAL KAMPANIYA TƏTBİQİ (ribbon düyməsi)
        // ──────────────────────────────────────────────────────────

        private void ApplyCampaignsManually(bool cashOnly)
        {
            if (trInvoiceHeader == null || gV_InvoiceLine.DataRowCount == 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_Invoice_NoLines,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var lines = GetInvoiceLines();
            var svc = GetCampaignService();

            var campaigns = svc.GetApplicableCampaigns(trInvoiceHeader, lines)
                               .Where(c => c.IsCashOnly == cashOnly)
                               .OrderByDescending(c => c.Priority)
                               .ToList();

            if (!campaigns.Any())
            {
                XtraMessageBox.Show(
                    "Tətbiq oluna biləcək kampaniya tapılmadı.",
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            bool anyApplied = false;

            foreach (var campaign in campaigns)
            {
                // Şifrə yoxlanması
                if (!string.IsNullOrEmpty(campaign.CampaignPassword))
                {
                    var pwd = XtraInputBox.Show(
                        $"'{campaign.CampaignDesc}' kampaniyasının şifrəsini daxil edin:",
                        "Kampaniya Şifrəsi",
                        "");

                    if (string.IsNullOrEmpty(pwd) || pwd != campaign.CampaignPassword)
                    {
                        XtraMessageBox.Show(
                            "Şifrə yanlışdır. Kampaniya keçildi.",
                            Resources.Common_Attention,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        continue;
                    }
                }

                var result = svc.ApplyCampaign(campaign, trInvoiceHeader, lines);

                XtraMessageBox.Show(
                    result.Message,
                    "Kampaniya",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result.Success)
                {
                    anyApplied = true;

                    // IsCombinable=false olarsa ilk uğurlu kampaniyadan sonra dayanır
                    if (!campaign.IsCombinable) break;
                }
            }

            if (anyApplied)
            {
                gV_InvoiceLine.RefreshData();
                SaveInvoice();
            }
        }

        // ──────────────────────────────────────────────────────────
        //  PROMO KOD
        // ──────────────────────────────────────────────────────────

        private void ApplyPromoCode()
        {
            var code = XtraInputBox.Show("Promo kodu daxil edin:", "Promo Kod", "");
            if (string.IsNullOrWhiteSpace(code)) return;

            var lines = GetInvoiceLines();
            var svc = GetCampaignService();
            var campaigns = svc.GetApplicableCampaigns(trInvoiceHeader, lines, promoCode: code)
                               .OrderByDescending(c => c.Priority)
                               .ToList();

            if (!campaigns.Any())
            {
                XtraMessageBox.Show(
                    "Bu promo kod üçün uyğun kampaniya tapılmadı.",
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            bool anyApplied = false;

            foreach (var campaign in campaigns)
            {
                var result = svc.ApplyCampaign(campaign, trInvoiceHeader, lines);

                XtraMessageBox.Show(
                    result.Message,
                    "Promo Kod",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result.Success)
                {
                    anyApplied = true;
                    if (!campaign.IsCombinable) break;
                }
            }

            if (anyApplied)
            {
                SavePromoCodeToHeader(code);
                gV_InvoiceLine.RefreshData();
                SaveInvoice();
            }
        }

        private void SavePromoCodeToHeader(string code)
        {
            // Mövcud header yoxlanması (Local cache-dən)
            var existing = dbContext.TrInvoiceCampaignHeaders.Local
                .FirstOrDefault(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId);

            if (existing == null)
            {
                // DB-dən yoxla (başqa context tərəfindən yazılmış ola bilər)
                existing = dbContext.TrInvoiceCampaignHeaders
                    .FirstOrDefault(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId);
            }

            if (existing == null)
            {
                dbContext.TrInvoiceCampaignHeaders.Add(new TrInvoiceCampaignHeader
                {
                    InvoiceCampaignHeaderId = Guid.NewGuid(),
                    InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId,
                    PromoCode = code
                });
            }
            else
            {
                existing.PromoCode = code;
            }

            dbContext.SaveChanges();
        }

        // ──────────────────────────────────────────────────────────
        //  KAMPANIYA LOQU
        // ──────────────────────────────────────────────────────────

        private void ShowCampaignLog()
        {
            if (trInvoiceHeader == null) return;

            var logs = dbContext.TrInvoiceCampaignLogs
                .Where(l => l.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                .ToList();

            if (!logs.Any())
            {
                XtraMessageBox.Show(
                    "Bu faktura üçün kampaniya loqu tapılmadı.",
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var form = new FormCampaignLog(logs);
            form.ShowDialog(this);
        }

        // ──────────────────────────────────────────────────────────
        //  YÜKLƏNƏNDƏ SERVİSİ SIFIRLA (yeni faktura açılanda)
        // ──────────────────────────────────────────────────────────

        /// <summary>
        /// ClearControlsAddNew çağırıldıqda campaign service-i yenilə.
        /// Bu metodu ClearControlsAddNew-da çağırın.
        ///
        ///   // FormInvoice.cs → ClearControlsAddNew metodu sonuna əlavə edin:
        ///   ResetCampaignState();
        /// </summary>
        private void ResetCampaignState()
        {
            _pendingCampaignResult = null;
            _campaignService = null; // dbContext dəyişdiyindən yenidən yaradılacaq
        }

        // ──────────────────────────────────────────────────────────
        //  YARDIMÇI
        // ──────────────────────────────────────────────────────────

        private IList<TrInvoiceLine> GetInvoiceLines()
            => dbContext.TrInvoiceLines.Local
                        .Where(l => l.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                        .ToList();

        private static string FormatDiscount(DcCampaign c)
            => c.DiscountTypeCode == DiscountTypeCode.Percent
                ? $"{c.DiscountValue:n2}%"
                : $"{c.DiscountValue:n2}";
    }
}
