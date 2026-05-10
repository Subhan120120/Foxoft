using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Foxoft
{
    public partial class FormWhatsAppMessageLog : RibbonForm
    {
        private subContext dbContext;

        public FormWhatsAppMessageLog()
        {
            InitializeComponent();
        }

        private void FormWhatsAppMessageLog_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dbContext?.Dispose();
            dbContext = new subContext();

            var list = dbContext.TrWhatsAppMessageLogs
                .AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.DcSender)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            trWhatsAppMessageLogBindingSource.DataSource = list;
            gV_WhatsAppMessageLogList.BestFitColumns();
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Resources.Form_WhatsAppMessageLog, gC_WhatsAppMessageLogList);
        }

        private void gC_WhatsAppMessageLogList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadData();
                e.Handled = true;
            }
        }
    }
}
