using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace Foxoft
{
    public partial class FormWhatsAppMessageLog : RibbonForm
    {
        private subContext dbContext;
        private bool layoutLoaded;

        public FormWhatsAppMessageLog()
        {
            InitializeComponent();
        }

        private void FormWhatsAppMessageLog_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLayout();
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

            if (!layoutLoaded)
                gV_WhatsAppMessageLogList.BestFitColumns();
        }

        private void LoadLayout()
        {
            string fileName = "FormWhatsAppMessageLogLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_WhatsAppMessageLogList.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }
        }

        private void SaveLayout()
        {
            string fileName = "FormWhatsAppMessageLogLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_WhatsAppMessageLogList.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
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

        private void gV_WhatsAppMessageLogList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;

                if (menu?.Column != null)
                    menu.Items.Add(CreateItem("Save Layout", menu.Column, null));
            }
        }

        private DXMenuItem CreateItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_Click), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        private void DXMenuItem_Click(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item?.Tag as MenuColumnInfo;

            if (info == null)
                return;

            SaveLayout();
        }

        class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                Column = column;
            }

            public GridColumn Column;
        }

        private void FormWhatsAppMessageLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext?.Dispose();
        }
    }
}
