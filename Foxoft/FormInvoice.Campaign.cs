using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormInvoice
    {
        private TextEdit txtEdit_PromoCodeCampaign;
        private LayoutControlItem lCI_PromoCodeCampaign;
        private bool campaignUiInitialized;

        private void InitializeCampaignArea()
        {
            if (campaignUiInitialized)
                return;

            campaignUiInitialized = true;

            txtEdit_PromoCodeCampaign = new TextEdit();
            txtEdit_PromoCodeCampaign.Name = "txtEdit_PromoCodeCampaign";
            txtEdit_PromoCodeCampaign.EnterMoveNextControl = true;
            txtEdit_PromoCodeCampaign.KeyDown += txtEdit_PromoCodeCampaign_KeyDown;

            dataLayoutControl1.Controls.Add(txtEdit_PromoCodeCampaign);

            lCI_PromoCodeCampaign = new LayoutControlItem();
            lCI_PromoCodeCampaign.Control = txtEdit_PromoCodeCampaign;
            lCI_PromoCodeCampaign.Name = "lCI_PromoCodeCampaign";
            lCI_PromoCodeCampaign.Text = "Promo code";
            lCI_PromoCodeCampaign.TextVisible = true;

            LCG_Invoice.AddItem(lCI_PromoCodeCampaign);

            EnsureInvoiceCampaignGridColumn();
            EnsureInvoiceCampaignRibbonButtons();
        }

        private void EnsureInvoiceCampaignRibbonButtons()
        {
        }

        private void EnsureInvoiceCampaignGridColumn()
        {
            GridColumn? column = gV_InvoiceLine.Columns.ColumnByFieldName(nameof(TrInvoiceLine.DiscountCampaign));
            if (column is not null)
                return;

            column = gV_InvoiceLine.Columns.AddField(nameof(TrInvoiceLine.DiscountCampaign));
            column.Caption = "Kampaniya endirimi";
            column.Visible = true;
            column.VisibleIndex = col_NetAmount.VisibleIndex;
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "n2";
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.ReadOnly = true;
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n2}";
        }

        private void LoadInvoiceCampaignState()
        {
            InitializeCampaignArea();

            using var db = new subContext();

            TrInvoiceCampaignHeader? campaignHeader = db.TrInvoiceCampaignHeaders
                .AsNoTracking()
                .FirstOrDefault(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId);

            txtEdit_PromoCodeCampaign.EditValue = campaignHeader?.PromoCode;
            gV_InvoiceLine.RefreshData();
        }

        private void ClearInvoiceCampaignState()
        {
            InitializeCampaignArea();
            txtEdit_PromoCodeCampaign.EditValue = null;
            gV_InvoiceLine.RefreshData();
        }

        private void ApplyCampaignsFromForm(bool showMessage)
        {
            if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty)
                return;

            if (dbContext is null)
                return;

            try
            {
                Validate();
                trInvoiceLinesBindingSource?.EndEdit();
                trInvoiceHeadersBindingSource?.EndEdit();

                List<int> paymentMethodIds = GetInvoicePaymentMethodIds();
                string? promoCode = txtEdit_PromoCodeCampaign?.EditValue?.ToString();

                CampaignService campaignService = new();
                CampaignApplyResult result = campaignService.Apply(
                    trInvoiceHeader.InvoiceHeaderId,
                    Authorization.CurrAccCode,
                    paymentMethodIds,
                    promoCode);

                ReloadInvoiceCampaignValues();

                if (showMessage)
                {
                    string msg = result.AppliedCampaignCodes.Count == 0
                        ? "Uyğun kampaniya tapılmadı."
                        : $"Tətbiq olunan kampaniyalar: {string.Join(", ", result.AppliedCampaignCodes)}\nCəmi endirim: {Math.Round(result.TotalDiscount, 2)}";

                    XtraMessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Kampaniya", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReloadInvoiceCampaignValues()
        {
            if (dbContext is null)
                return;

            List<TrInvoiceLine> trackedLines = dbContext.TrInvoiceLines
                .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                .ToList();

            foreach (TrInvoiceLine line in trackedLines)
            {
                try
                {
                    dbContext.Entry(line).Reload();
                }
                catch
                {
                }
            }

            trInvoiceLinesBindingSource?.ResetBindings(false);
            gV_InvoiceLine.RefreshData();
        }

        private List<int> GetInvoicePaymentMethodIds()
        {
            using var db = new subContext();

            List<Guid> paymentHeaderIds = db.TrPaymentHeaders
                .AsNoTracking()
                .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                .Select(x => x.PaymentHeaderId)
                .ToList();

            if (paymentHeaderIds.Count == 0)
                return new List<int>();

            return db.TrPaymentLines
                .AsNoTracking()
                .Where(x => paymentHeaderIds.Contains(x.PaymentHeaderId))
                .Select(x => x.PaymentMethodId)
                .Distinct()
                .ToList();
        }

        private void txtEdit_PromoCodeCampaign_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyCampaignsFromForm(true);
                e.Handled = true;
            }
        }

    }
}