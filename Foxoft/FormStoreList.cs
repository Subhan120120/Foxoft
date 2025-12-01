using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormStoreList : RibbonForm
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        ReportClass reportClass = new();
        public DcCurrAcc dcCurrAcc { get; set; }
        public string storeCode;

        public FormStoreList()
        {
            InitializeComponent();

            colCurrAccCode = gV_StoreList.Columns[nameof(DcCurrAcc.CurrAccCode)];

            //string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            reportClass.AddReports(BSI_Reports, "Stores", nameof(DcCurrAcc.CurrAccCode), gV_StoreList);

            UpdateGridViewData();
            gV_StoreList.PopulateColumns();
            LoadLayout();
        }

        public FormStoreList(string storeCode)
            : this()
        {
            this.storeCode = storeCode; // Focus Selected currAccCode
        }

        private void FormStoreList_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (gV_StoreList is not null)
            {
                gV_StoreList.FindPanelVisible = false;
                if (!gV_StoreList.FindPanelVisible)
                    gC_StoreList.BeginInvoke(new Action(gV_StoreList.ShowFindPanel));
            }

            LoadCurrAccs();

            //Focus Special Row
            int rowHandle = gV_StoreList.LocateByValue(0, colCurrAccCode, storeCode);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gV_StoreList.FocusedRowHandle = rowHandle;
                gV_StoreList.MakeRowVisible(rowHandle);
            }
        }

        private void LoadCurrAccs()
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_StoreList");

            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    SqlParameter[] sqlParameters;
                    string qryMaster = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(qryMaster, sqlParameters);
                    if (dt.Rows.Count > 0)
                        dcCurrAccsBindingSource.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show(Resources.Form_StoreList_ReportNotFound, Resources.Common_Attention);
            }

            if (gV_StoreList.FocusedRowHandle >= 0)
            {
                object storeCode = gV_StoreList.GetFocusedRowCellValue(nameof(DcCurrAcc.CurrAccCode));
                if (storeCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(storeCode.ToString());
            }
            else
                dcCurrAcc = null;

            gV_StoreList.BestFitColumns();
            gV_StoreList.MakeRowVisible(gV_StoreList.FocusedRowHandle);
        }

        private void SaveLayout()
        {
            string fileName = "FormStoreList.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");

            if (!Directory.Exists(layoutFilePath))
                Directory.CreateDirectory(layoutFilePath);

            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_StoreList.SaveLayoutToXml(Path.Combine(layoutFilePath, fileName), option);
        }

        private void LoadLayout()
        {
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            string fileName = "FormStoreList.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
                gV_StoreList.RestoreLayoutFromXml(layoutFilePath, option);
            else
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
                MemoryStream stream = new(byteArray);
                gV_StoreList.RestoreLayoutFromStream(stream, option);
            }

            colBalance = gV_StoreList.Columns[nameof(DcCurrAcc.Balance)];
            if (colBalance is not null)
            {
                RepositoryItemTextEdit repoMoney = new();
                repoMoney.MaskSettings.Set("MaskManagerType", typeof(NumericMaskManager));
                repoMoney.MaskSettings.Set("mask", "f2");
                repoMoney.UseMaskAsDisplayFormat = true;
                gC_StoreList.RepositoryItems.AddRange(new RepositoryItem[] { repoMoney });
                colBalance.ColumnEdit = repoMoney;
            }
        }

        private void gV_StoreList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object currAccCode = view.GetFocusedRowCellValue(nameof(DcCurrAcc.StoreCode));
                if (currAccCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                dcCurrAcc = null;
        }

        private void gV_CurrAccList_DoubleClick(object sender, EventArgs e)
        {
            if (dcCurrAcc is not null)
                AcceptForm();
        }

        private void AcceptForm()
        {
            DialogResult = DialogResult.OK;
        }

        private void bBI_CurrAccNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            dcCurrAcc = new DcCurrAcc();
            FormStore form = new(4);
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void bBI_CurrAccEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcCurrAcc is not null)
            {
                FormStore form = new(dcCurrAcc.CurrAccCode);
                if (form.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }

        private void UpdateGridViewData()
        {
            int fr = gV_StoreList.FocusedRowHandle;

            LoadCurrAccs();

            if (fr > 0)
                gV_StoreList.FocusedRowHandle = fr;
            else
                gV_StoreList.MoveLast();

            if (gV_StoreList.FocusedRowHandle >= 0)
            {
                object currAccCode = gV_StoreList.GetFocusedRowCellValue(nameof(DcCurrAcc.CurrAccCode));
                if (currAccCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                dcCurrAcc = null;
        }

        private void bBI_refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        private void gC_CurrAccList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (dcCurrAcc is not null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = gV_StoreList.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }
            }
        }

        private void gV_CurrAccList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object currAccCode = view.GetRowCellValue(view.FocusedRowHandle, nameof(DcCurrAcc.CurrAccCode));
                if (currAccCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                dcCurrAcc = null;
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_StoreList);
        }

        private void bBI_CurrAccDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcCurrAcc is not null)
            {
                if (efMethods.CurrAccExist(dcCurrAcc.CurrAccCode))
                {
                    string msg = Resources.Common_DeleteConfirm + Environment.NewLine + dcCurrAcc.CurrAccDesc;
                    if (XtraMessageBox.Show(msg, Resources.Common_Attention, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        efMethods.DeleteEntity(dcCurrAcc);
                        LoadCurrAccs();
                    }
                }
                else
                    XtraMessageBox.Show(Resources.Form_StoreList_Message_NoStoreToDelete, Resources.Common_Attention);
            }
            else
                XtraMessageBox.Show(Resources.Form_StoreList_Message_SelectStore, Resources.Common_Attention);
        }

        private void bBI_CurAccRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        //AutoFocus FindPanel 
        private void gC_CurrAccList_Load(object sender, EventArgs e)
        {
        }

        private void gV_CurrAccList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu.Column != null)
                {
                    menu.Items.Add(CreateItem(Resources.Common_SaveLayout, menu.Column, null));
                }
            }
        }

        DXMenuItem CreateItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuCheckItem_ItemClick), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        void DXMenuCheckItem_ItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            SaveLayout();
        }

        class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                this.Column = column;
            }
            public GridColumn Column;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void BBI_test_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sFD = new()
            {
                Filter = Resources.Common_File_ExcelFilter,
                Title = Resources.Common_File_SaveExcel,
                FileName = this.Text,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = "*.xlsx"
            };

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_StoreList.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(
                            this,
                            Resources.Form_ReportGrid_Message_OpenExportedFileQuestion,
                            Resources.Common_Attention,
                            MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process p = new();
                        p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                        p.Start();
                    }

                    return "Ok";
                }
                else
                    return "Fail";
            }));
        }

        private void BBI_query_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_StoreList");

            if (dcReport is not null)
            {
                int id = dcReport.ReportId;
                FormReportEditor formQueryEditor = new(id);
                if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }

        private void popupMenuReports_BeforePopup(object sender, CancelEventArgs e)
        {
        }

        private void FormStoreList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
