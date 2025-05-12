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
using Foxoft.AppCode;
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
    public partial class FormCashRegisterList : RibbonForm
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        CustomMethods cM = new();
        public DcCurrAcc dcCurrAcc { get; set; }
        public byte cashRegPaymentTypeCode;
        public string cashRegCode;

        public FormCashRegisterList()
        {
            InitializeComponent();

            colCurrAccCode = gV_CashRegList.Columns["CurrAccCode"];

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            cM.AddReports(BSI_Reports, "CashRegisters", nameof(TrPaymentLine.CashRegisterCode), gV_CashRegList);

            UpdateGridViewData();
            gV_CashRegList.PopulateColumns();
            LoadLayout();
        }

        public FormCashRegisterList(string cashRegCode)
            : this()
        {
            this.cashRegCode = cashRegCode; // Focus Selected currAccCode
        }

        public FormCashRegisterList(string currAccCode, byte cashRegPaymentTypeCode)
            : this(currAccCode)
        {
            this.cashRegPaymentTypeCode = cashRegPaymentTypeCode;
        }

        private void FormCashRegisterList_Load(object sender, EventArgs e)
        {
        }

        private void FormCashRegisterList_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (gV_CashRegList is not null)
            {
                gV_CashRegList.FindPanelVisible = false;
                if (!gV_CashRegList.FindPanelVisible)
                    gC_CashRegList.BeginInvoke(new Action(gV_CashRegList.ShowFindPanel));
            }

            LoadCurrAccs();

            //Focus Special Row
            int rowHandle = gV_CashRegList.LocateByValue(0, colCurrAccCode, cashRegCode);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gV_CashRegList.FocusedRowHandle = rowHandle;
                gV_CashRegList.MakeRowVisible(rowHandle);
            }
        }

        private void LoadCurrAccs()
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_CashRegList");

            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    SqlParameter[] sqlParameters;
                    string qryMaster = cM.ApplyFilter(dcReport, dcReport.ReportQuery, null, out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(qryMaster, sqlParameters);
                    if (dt.Rows.Count > 0)
                        dcCurrAccsBindingSource.DataSource = dt;
                }
            }
            else MessageBox.Show("Report_Embedded_CashRegList sorğusu DcReports cədvəlində tapılmadı");

            if (gV_CashRegList.FocusedRowHandle >= 0)
            {
                object cashRegCode = gV_CashRegList.GetFocusedRowCellValue("CurrAccCode");
                if (cashRegCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(cashRegCode.ToString());
            }
            else
                dcCurrAcc = null;

            gV_CashRegList.BestFitColumns();
            gV_CashRegList.MakeRowVisible(gV_CashRegList.FocusedRowHandle);
        }

        private void SaveLayout()
        {
            string fileName = "FormCashRegisterList.xml";
            //string layoutFileDir = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files");
            string layoutFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files");

            if (!Directory.Exists(layoutFilePath))
                Directory.CreateDirectory(layoutFilePath);

            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_CashRegList.SaveLayoutToXml(Path.Combine(layoutFilePath, fileName), option);
        }

        private void LoadLayout()
        {
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            string fileName = "FormCashRegisterList.xml";
            //string layoutFilePath = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files", fileName);
            string layoutFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", fileName);

            if (File.Exists(layoutFilePath))
                gV_CashRegList.RestoreLayoutFromXml(layoutFilePath, option);
            else
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
                MemoryStream stream = new(byteArray);
                gV_CashRegList.RestoreLayoutFromStream(stream, option);
            }

            colBalance = gV_CashRegList.Columns["Balance"];
            if (colBalance is not null)
            {
                RepositoryItemTextEdit repoMoney = new();
                repoMoney.MaskSettings.Set("MaskManagerType", typeof(NumericMaskManager));
                repoMoney.MaskSettings.Set("mask", "f2");
                repoMoney.UseMaskAsDisplayFormat = true;
                gC_CashRegList.RepositoryItems.AddRange(new RepositoryItem[] { repoMoney });
                colBalance.ColumnEdit = repoMoney;
            }
        }

        private void gV_CashRegList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                object currAccCode = view.GetFocusedRowCellValue("CashRegisterCode");
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
            FormCashRegister form = new(5);
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();

        }

        private void bBI_CurrAccEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ApplySelectedCurrAcc();

            if (dcCurrAcc is not null)
            {
                FormCashRegister form = new(dcCurrAcc.CurrAccCode);
                if (form.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }

        private void UpdateGridViewData()
        {
            int fr = gV_CashRegList.FocusedRowHandle;

            LoadCurrAccs();

            if (fr > 0)
                gV_CashRegList.FocusedRowHandle = fr;
            else
                gV_CashRegList.MoveLast();


            if (gV_CashRegList.FocusedRowHandle >= 0)
            {
                object currAccCode = gV_CashRegList.GetFocusedRowCellValue(nameof(dcCurrAcc.CurrAccCode));
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
                    string cellValue = gV_CashRegList.GetFocusedValue().ToString();
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
                object currAccCode = view.GetFocusedRowCellValue(nameof(dcCurrAcc.CurrAccCode));
                if (currAccCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                dcCurrAcc = null;
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_CashRegList);
        }

        private void bBI_CurrAccDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcCurrAcc is not null)
            {
                if (efMethods.CurrAccExist(dcCurrAcc.CurrAccCode))
                {
                    if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + dcCurrAcc.CurrAccDesc, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        efMethods.DeleteEntity<DcCurrAcc>(dcCurrAcc);

                        LoadCurrAccs();
                    }
                }
                else
                    XtraMessageBox.Show("Silinmeli olan cari yoxdur");
            }
            else
                XtraMessageBox.Show("Məhsul seçin");
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
                //menu.Items.Clear();
                if (menu.Column != null)
                {
                    menu.Items.Add(CreateItem("Save Layout", menu.Column, null));
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

        private void FormCashRegisterList_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void BBI_test_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sFD = new();
            sFD.Filter = "Excel Faylı|*.xlsx";
            sFD.Title = "Excel Faylı Yadda Saxla";
            sFD.FileName = this.Text;
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sFD.DefaultExt = "*.xlsx";

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_CashRegList.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
            DcReport dcReport = null;

            dcReport = efMethods.SelectReportByName("Report_Embedded_CashRegList");

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

        private void FormCashRegisterList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}