using DevExpress.XtraBars;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;

namespace Foxoft
{
    public partial class FormCrmActivityList : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private subContext dbContext;
        private bool layoutLoaded;

        public FormCrmActivityList()
        {
            InitializeComponent();
        }

        private void FormCrmActivityList_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLayout();
        }

        private void LoadData()
        {
            dbContext?.Dispose();
            dbContext = new subContext();

            var list = dbContext.TrCrmActivities
                .AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.DcCrmActivityType)
                .OrderByDescending(x => x.ActivityDate)
                .ThenByDescending(x => x.CreatedDate)
                .ToList();

            crmActivitiesBindingSource.DataSource = list;

            if (!layoutLoaded)
                gV_CrmActivityList.BestFitColumns();
        }

        private void LoadLayout()
        {
            string fileName = "FormCrmActivityListLayout.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_CrmActivityList.RestoreLayoutFromXml(layoutFilePath);
                layoutLoaded = true;
            }
        }

        private void SaveLayout()
        {
            string fileName = "FormCrmActivityListLayout.xml";
            string layoutFileDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);

            gV_CrmActivityList.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
            layoutLoaded = true;
        }

        private TrCrmActivity GetFocusedRow()
        {
            return gV_CrmActivityList.GetFocusedRow() as TrCrmActivity;
        }

        private void OpenSelected()
        {
            TrCrmActivity row = GetFocusedRow();

            if (row is null)
                return;

            using FormCrmActivity form = new(row.ActivityId);

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void CreateNew()
        {
            using FormCrmActivity form = new();

            if (form.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteSelected()
        {
            TrCrmActivity row = GetFocusedRow();

            if (row is null)
                return;

            if (XtraMessageBox.Show(
                    "Seçilmiş CRM aktivliyi silinsin?",
                    Resources.Common_Confirm,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (var db = new subContext())
            {
                TrCrmActivity entity = db.TrCrmActivities.FirstOrDefault(x => x.ActivityId == row.ActivityId);

                if (entity is null)
                    return;

                db.TrCrmActivities.Remove(entity);
                db.SaveChanges();
            }

            LoadData();
        }

        private static string GetEnumDescription<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

            if (member is null)
                return value.ToString();

            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            return attr?.Description ?? value.ToString();
        }

        private void bBI_CrmActivityNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateNew();
        }

        private void bBI_CrmActivityEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenSelected();
        }

        private void bBI_CrmActivityDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteSelected();
        }

        private void bBI_CrmActivityRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, "CRM Aktivlikləri", gC_CrmActivityList);
        }

        private void gC_CrmActivityList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenSelected();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.F5)
            {
                LoadData();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelected();
                e.Handled = true;
            }
        }

        private void gC_CrmActivityList_Paint(object sender, PaintEventArgs e)
        {
        }

        private void gV_CrmActivityList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Clicks == 2 && e.RowHandle >= 0)
                OpenSelected();
        }

        private void gV_CrmActivityList_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colStatus && e.Value is CrmActivityStatus status)
                e.DisplayText = GetEnumDescription(status);

            if (e.Column == colPriority && e.Value is CrmActivityPriority priority)
                e.DisplayText = GetEnumDescription(priority);
        }

        private void gV_CrmActivityList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
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

        private void FormCrmActivityList_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext?.Dispose();
        }
    }
}
