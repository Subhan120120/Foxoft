using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormInvoiceCampaignLogList : RibbonForm
    {
        private readonly Guid invoiceHeaderId;

        public FormInvoiceCampaignLogList(Guid invoiceHeaderId)
        {
            InitializeComponent();
            this.invoiceHeaderId = invoiceHeaderId;
        }

        private void FormInvoiceCampaignLogList_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void LoadLogs()
        {
            using subContext db = new();

            var rows = db.TrInvoiceCampaignLogs
                .AsNoTracking()
                .Include(x => x.TrInvoiceLine)
                .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new InvoiceCampaignLogRow
                {
                    CreatedDate = x.CreatedDate,
                    CampaignCode = x.CampaignCode,
                    CampaignDesc = x.CampaignDesc,
                    CampaignTypeCode = x.CampaignTypeCode,
                    PromoCode = x.PromoCode,
                    ProductCode = x.TrInvoiceLine != null ? x.TrInvoiceLine.ProductCode : null,
                    DiscountAmount = x.DiscountAmount,
                    DiscountAmountLoc = x.DiscountAmountLoc,
                    BaseAmount = x.BaseAmount,
                    BaseAmountLoc = x.BaseAmountLoc,
                    DiscountPercent = x.DiscountPercent,
                    PaymentMethodId = x.PaymentMethodId
                })
                .ToList();

            invoiceCampaignLogRowsBindingSource.DataSource = rows;
            gV_Log.BestFitColumns();
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadLogs();
        }

        private void bBI_Export_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, "Kampaniya log", gC_Log);
        }

        private sealed class InvoiceCampaignLogRow
        {
            public DateTime CreatedDate { get; set; }
            public string? CampaignCode { get; set; }
            public string? CampaignDesc { get; set; }
            public CampaignTypeCode? CampaignTypeCode { get; set; }
            public string? PromoCode { get; set; }
            public string? ProductCode { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal DiscountAmountLoc { get; set; }
            public decimal BaseAmount { get; set; }
            public decimal BaseAmountLoc { get; set; }
            public decimal DiscountPercent { get; set; }
            public int? PaymentMethodId { get; set; }
        }
    }
}