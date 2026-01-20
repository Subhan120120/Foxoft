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
using Foxoft.Models.Entity.Report;
using Foxoft.Properties; // Resources üçün
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public partial class FormCurrAccList : RibbonForm
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        ReportClass reportClass = new();
        public DcCurrAcc dcCurrAcc { get; set; }
        public byte[] currAccTypeArr;
        public byte[] personalTypes;
        public byte cashRegPaymentTypeCode;
        public string currAccCode;
        public bool? isDisabled { get; set; }

        public FormCurrAccList()
        {
            InitializeComponent();

            colCurrAccCode = gV_CurrAccList.Columns["CurrAccCode"];
        }

        public FormCurrAccList(byte[] currAccTypeArr, bool? isDisabled)
            : this()
        {
            this.currAccTypeArr = currAccTypeArr;
            this.isDisabled = isDisabled;

            //string activeFilterStr = "[StoreCode] = '" + Authorization.StoreCode + "'";

            reportClass.AddReports(BSI_Reports, "CurrAccs", nameof(DcCurrAcc.CurrAccCode), gV_CurrAccList);

            gV_CurrAccList.PopulateColumns();

        }

        public FormCurrAccList(byte[] currAccTypeArr, bool? isDisabled, string currAccCode)
            : this(currAccTypeArr, isDisabled)
        {
            this.currAccCode = currAccCode;
        }

        public FormCurrAccList(byte[] currAccTypeArr, bool? isDisabled, string currAccCode, byte[] personalTypes)
            : this(currAccTypeArr, isDisabled, currAccCode)
        {
            this.personalTypes = personalTypes;
        }

        public FormCurrAccList(byte[] currAccTypeArr, bool? isDisabled, byte[] personalTypes)
            : this(currAccTypeArr, isDisabled)
        {
            this.personalTypes = personalTypes;
        }

        private void FormCurrAccList_Load(object sender, EventArgs e)
        {
        }

        private void FormCurrAccList_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (gV_CurrAccList is not null)
            {
                gV_CurrAccList.FindPanelVisible = false;
                if (!gV_CurrAccList.FindPanelVisible)
                    gC_CurrAccList.BeginInvoke(new Action(gV_CurrAccList.ShowFindPanel));
            }

            LoadCurrAccs(currAccTypeArr);
            LoadLayout();

            //Focus Special Row
            int rowHandle = gV_CurrAccList.LocateByValue(0, colCurrAccCode, currAccCode);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gV_CurrAccList.FocusedRowHandle = rowHandle;
                gV_CurrAccList.MakeRowVisible(rowHandle);
            }
        }

        private void LoadCurrAccs(byte[] currAccTypeArr)
        {
            object dataSource = null;

            DcReport dcReport = null;

            dcReport = efMethods.SelectReportByName("Report_Embedded_CurrAccList");

            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    string typeArr = String.Join(",", currAccTypeArr);
                    string clause = " CurrAccTypeCode in (" + typeArr + ") ";

                    string pattern = @"(?i)\bselect\b[\s\S]*?\bPersonalTypeCode\b";
                    bool columnExists = Regex.IsMatch(dcReport.ReportQuery, pattern);

                    if (columnExists && personalTypes is not null && personalTypes.Length > 0)
                    {
                        string subTypeArr = String.Join(",", personalTypes);
                        clause += "AND PersonalTypeCode in (" + subTypeArr + ") ";
                    }
                    if (isDisabled is bool value)
                    {
                        clause += $" AND IsDisabled = {(value ? 1 : 0)}";
                    }

                    SqlParameter[] sqlParameters;
                    string qryMaster = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, clause, out sqlParameters);

                    DataTable dt = adoMethods.SqlGetDt(qryMaster, sqlParameters);
                    if (dt.Rows.Count > 0)
                        dcCurrAccsBindingSource.DataSource = dt;
                }
            }

            if (gV_CurrAccList.FocusedRowHandle >= 0)
            {
                object currAccCode = gV_CurrAccList.GetFocusedRowCellValue("CurrAccCode");
                if (currAccCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                dcCurrAcc = null;

            gV_CurrAccList.BestFitColumns();
            gV_CurrAccList.MakeRowVisible(gV_CurrAccList.FocusedRowHandle);
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
                resp.Add((T)view.GetRow(i));

            return resp;
        }

        private void SaveLayout()
        {
            string fileName = "FormCurrAccList.xml";

            string layoutFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files");

            if (!Directory.Exists(layoutFilePath))
                Directory.CreateDirectory(layoutFilePath);

            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_CurrAccList.SaveLayoutToXml(Path.Combine(layoutFilePath, fileName), option);
        }

        public void CreateDirectory(string DirectoryName, string UserAccount)
        {
            if (!Directory.Exists(DirectoryName))
                Directory.CreateDirectory(DirectoryName);
            // Calls the another function to add users and permissions
            AddUsersAndPermissions(DirectoryName, UserAccount, FileSystemRights.FullControl, AccessControlType.Allow);
        }

        public void AddUsersAndPermissions(string DirectoryName, string UserAccount, FileSystemRights UserRights, AccessControlType AccessType)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryName);
            DirectorySecurity dirSecurity = directoryInfo.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(UserAccount, UserRights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessType));
            directoryInfo.SetAccessControl(dirSecurity);
        }

        private void LoadLayout()
        {
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            string fileName = "FormCurrAccList.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", fileName);

            if (File.Exists(layoutFilePath))
            {
                gV_CurrAccList.RestoreLayoutFromXml(layoutFilePath, option);
            }
            else
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
                using MemoryStream stream = new(byteArray);
                gV_CurrAccList.RestoreLayoutFromStream(stream, option);
            }

            if (colPhoneNum is not null)
            {
                RepositoryItemTextEdit repoPhoneNum = new();
                repoPhoneNum.MaskSettings.Set("MaskManagerType", typeof(RegularMaskManager));
                repoPhoneNum.MaskSettings.Set("mask", "(\\d?\\d?) \\d\\d\\d-\\d\\d-\\d\\d");
                repoPhoneNum.UseMaskAsDisplayFormat = true;
                gC_CurrAccList.RepositoryItems.Add(repoPhoneNum);
                colPhoneNum.ColumnEdit = repoPhoneNum;
            }

            colBalance = gV_CurrAccList.Columns["Balance"];
            if (colBalance is not null)
            {
                RepositoryItemTextEdit repoMoney = new();
                repoMoney.MaskSettings.Set("MaskManagerType", typeof(NumericMaskManager));
                repoMoney.MaskSettings.Set("mask", "f2");
                repoMoney.UseMaskAsDisplayFormat = true;
                gC_CurrAccList.RepositoryItems.Add(repoMoney);
                colBalance.ColumnEdit = repoMoney;
            }
        }


        private void gV_CurrAccList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
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
            using FormCurrAcc form = new(currAccTypeArr.FirstOrDefault());
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void bBI_CurrAccEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcCurrAcc is null) return;
            using FormCurrAcc form = new(dcCurrAcc.CurrAccCode);
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }


        private void UpdateGridViewData()
        {
            int fr = gV_CurrAccList.FocusedRowHandle;

            LoadCurrAccs(currAccTypeArr);

            if (fr > 0)
                gV_CurrAccList.FocusedRowHandle = fr;
            else
                gV_CurrAccList.MoveLast();


            if (gV_CurrAccList.FocusedRowHandle >= 0)
            {
                object currAccCode = gV_CurrAccList.GetFocusedRowCellValue(nameof(dcCurrAcc.CurrAccCode));
                if (currAccCode is not null)
                    dcCurrAcc = efMethods.SelectCurrAcc(currAccCode.ToString());
            }
            else
                dcCurrAcc = null;
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
                    string cellValue = gV_CurrAccList.GetFocusedValue()?.ToString() ?? string.Empty;
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        // AutoFocus FindPanel
        bool isFirstPaint = true;
        private void gC_CurrAccList_Paint(object sender, PaintEventArgs e)
        {
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
            CustomExtensions.ExportToExcel(this, Text, gC_CurrAccList);
        }

        private void bBI_CurrAccDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcCurrAcc is not null)
            {
                if (efMethods.CurrAccExist(dcCurrAcc.CurrAccCode))
                {
                    if (XtraMessageBox.Show(Resources.Common_DeleteConfirm + " \n " + dcCurrAcc.CurrAccDesc, Resources.Common_Attention, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        efMethods.DeleteEntity(dcCurrAcc);

                        LoadCurrAccs(currAccTypeArr);
                    }
                }
                else
                    XtraMessageBox.Show(Resources.Form_CurrAccList_NoAccountToDelete);
            }
            else
                XtraMessageBox.Show(Resources.Form_CurrAccList_SelectAccount);
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
                    // "Save Layout" -> resx
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

        // Menu item click handler.
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

        private void FormCurrAccList_VisibleChanged(object sender, EventArgs e)
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
            sFD.Filter = Resources.Common_File_ExcelFilter;
            sFD.Title = Resources.Common_File_SaveExcel;
            sFD.FileName = this.Text;
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sFD.DefaultExt = "*.xlsx";

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_CurrAccList.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, Resources.Common_OpenQuestion, Resources.Common_Attention, MessageBoxButtons.OKCancel) == DialogResult.OK)
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

            dcReport = efMethods.SelectReportByName("Report_Embedded_CurrAccList");

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

        private void FormCurrAccList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadLayout();
        }
    }
}
