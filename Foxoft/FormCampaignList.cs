using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormCampaignList : RibbonForm
    {
        private subContext dbContext = new();
        public DcCampaign? dcCampaign;

        public FormCampaignList()
        {
            InitializeComponent();
        }

        private void FormCampaignList_Load(object sender, EventArgs e)
        {
            LoadCampaigns();
        }

        private void LoadCampaigns()
        {
            dbContext = new subContext();

            dcCampaignsBindingSource.DataSource = dbContext.DcCampaigns
                .AsNoTracking()
                .OrderByDescending(x => x.IsActive)
                .ThenByDescending(x => x.Priority)
                .ThenBy(x => x.CampaignCode)
                .ToList();

            gV_CampaignList.BestFitColumns();
        }

        private Guid? GetFocusedCampaignId()
        {
            object? value = gV_CampaignList.GetFocusedRowCellValue(colCampaignId);
            if (value is Guid guid && guid != Guid.Empty)
                return guid;

            return null;
        }

        private void bBI_CampaignNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormCampaign form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
                LoadCampaigns();
        }

        private void bBI_CampaignEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Guid? id = GetFocusedCampaignId();
            if (!id.HasValue)
                return;

            using FormCampaign form = new(id.Value);
            if (form.ShowDialog(this) == DialogResult.OK)
                LoadCampaigns();
        }

        private void bBI_CampaignDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Guid? id = GetFocusedCampaignId();
            if (!id.HasValue)
                return;

            if (XtraMessageBox.Show("Seçilmiş kampaniya silinsin?", "Diqqət", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using subContext ctx = new();

            DcCampaign? entity = ctx.DcCampaigns.FirstOrDefault(x => x.CampaignId == id.Value);
            if (entity is null)
                return;

            bool hasLogs = ctx.TrInvoiceCampaignLogs.Any(x => x.CampaignId == id.Value);
            if (hasLogs)
            {
                XtraMessageBox.Show("Bu kampaniya artıq fakturalarda istifadə olunub. Silmək əvəzinə deaktiv edin.");
                return;
            }

            ctx.DcCampaigns.Remove(entity);
            ctx.SaveChanges(Authorization.CurrAccCode);
            LoadCampaigns();
        }

        private void bBI_CampaignRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadCampaigns();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, "Kampaniyalar", gC_CampaignList);
        }

        private void gV_CampaignList_DoubleClick(object sender, EventArgs e)
        {
            bBI_CampaignEdit_ItemClick(sender, null);
        }

        private void gC_CampaignList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bBI_CampaignEdit_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                bBI_CampaignNew_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                bBI_CampaignDelete_ItemClick(sender, null);
                e.Handled = true;
            }
        }

        private void FormCampaignList_KeyDown(object sender, KeyEventArgs e)
        {
            gC_CampaignList_ProcessGridKey(sender, e);
        }
    }
}