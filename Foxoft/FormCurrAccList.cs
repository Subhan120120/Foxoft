using DevExpress.Data.Filtering;
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCurrAccList : RibbonForm
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        public DcCurrAcc dcCurrAcc { get; set; }
        public byte[] currAccTypeArr;
        public string currAccCode;

        public FormCurrAccList()
        {
            InitializeComponent();
            colCurrAccCode = gV_CurrAccList.Columns["CurrAccCode"];

            AddReports();

            bBI_quit.ItemShortcut = new BarShortcut(Keys.Escape);
        }

        public FormCurrAccList(byte[] currAccTypeArr)
            : this()
        {
            this.currAccTypeArr = currAccTypeArr;
            UpdateGridViewData();
            gV_CurrAccList.PopulateColumns();
            LoadLayout();
        }

        public FormCurrAccList(byte[] currAccTypeArr, string currAccCode)
      : this(currAccTypeArr)
        {
            this.currAccCode = currAccCode;
        }

        private void FormCurrAccList_Load(object sender, EventArgs e)
        {
            //Focus Special Row
            int rowHandle = gV_CurrAccList.LocateByValue(0, colCurrAccCode, currAccCode);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gV_CurrAccList.FocusedRowHandle = rowHandle;
                gV_CurrAccList.MakeRowVisible(rowHandle);
            }
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
        }

        private void LoadCurrAccs(byte[] currAccTypeArr)
        {
            object dataSource = null;

            DcReport dcReport = null;

            if (currAccTypeArr.Contains((byte)5))
                dcReport = efMethods.SelectReportByName("FormCashRegList");
            else if (currAccTypeArr.Contains((byte)1) || currAccTypeArr.Contains((byte)2) || currAccTypeArr.Contains((byte)3) || currAccTypeArr.Contains((byte)4))
                dcReport = efMethods.SelectReportByName("FormCurrAccList");

            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    string ts = String.Join(",", currAccTypeArr);
                    string where = " Where CurrAccTypeCode in (" + ts + ") ";
                    string qryMaster = "select * from (" + dcReport.ReportQuery + ") as Master " + where;
                    //+ " order by CurrAccDesc";
                    DataTable dt = adoMethods.SqlGetDt(qryMaster);
                    if (dt.Rows.Count > 0)
                        dataSource = dt;
                }
            }

            if (dataSource is null)
            {
                if (currAccTypeArr != null && currAccTypeArr.Length > 0)
                    dataSource = efMethods.SelectProductsByTypeByFilter(currAccTypeArr, gV_CurrAccList.ActiveFilterCriteria);
                else if (currAccTypeArr == null)
                    dataSource = efMethods.SelectCurrAccs(new byte[] { 1, 2, 3, 4, 5 });
            }

            dcCurrAccsBindingSource.DataSource = dataSource;

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


        private void AddReports()
        {
            ComponentResourceManager resources = new(typeof(FormCurrAccList));

            List<TrFormReport> trFormReports = efMethods.SelectFormReports("CurrAccs");

            foreach (TrFormReport report in trFormReports)
            {

                BarButtonItem BBI = new();
                BBI.Caption = report.DcReport.ReportName;
                BBI.Id = 57;
                BBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Report.ImageOptions.SvgImage");
                BBI.Name = report.DcReport.ReportId.ToString();
                BSI_Report.LinksPersistInfo.Add(new LinkPersistInfo(BBI));

                ((ISupportInitialize)ribbonControl1).BeginInit();
                ribbonControl1.Items.Add(BBI);
                ((ISupportInitialize)ribbonControl1).EndInit();

                BBI.ItemClick += (sender, e) =>
                {
                    DcReport dcReport = efMethods.SelectReport(report.DcReport.ReportId);

                    string columnName = "[CurrAccCode]";
                    string dateFilter = "";
                    if (currAccTypeArr.Contains((byte)5))
                    {
                        columnName = "[CashRegisterCode]";
                        dateFilter = $" AND [OperationDate] Between(#{DateTime.Now.ToString("yyyy-MM-dd")}#, #{DateTime.Now.ToString("yyyy-MM-dd")}#) ";
                    }

                    string filter = "";
                    if (dcCurrAcc is not null)
                        filter = columnName + " = '" + dcCurrAcc.CurrAccCode + "' ";
                    else
                    {
                        List<DataRowView> mydata = GetFilteredData<DataRowView>(gV_CurrAccList).ToList();
                        var combined = "";
                        foreach (DataRowView rowView in mydata)
                            combined += "'" + rowView["CurrAccCode"].ToString() + "',";

                        combined = combined.Substring(0, combined.Length - 1);
                        filter = columnName + " In (" + combined + ")";
                    }

                    string activeFilterStr = filter + dateFilter;

                    if (dcReport.ReportTypeId == 1)
                    {
                        FormReportGrid formGrid = new(dcReport.ReportQuery, dcReport, activeFilterStr);
                        formGrid.Show();
                    }
                    else if (dcReport.ReportTypeId == 2)
                    {
                        FormReportPreview form = new(dcReport.ReportQuery + filter, dcReport);
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                    }
                };
            }
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
            string layoutFileDir = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);
            //CreateDirectory(layoutFileDir, Environment.UserName);

            //string fullName = Path.Combine(layoutFileDir, fileName);
            //
            //DirectoryInfo dInfo = new DirectoryInfo(fullName);
            //DirectorySecurity dSecurity = dInfo.GetAccessControl();
            //dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            //dInfo.SetAccessControl(dSecurity);

            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_CurrAccList.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName), option);
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
            string layoutFilePath = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files", fileName);

            if (File.Exists(layoutFilePath))
                gV_CurrAccList.RestoreLayoutFromXml(layoutFilePath, option);
            else
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
                MemoryStream stream = new(byteArray);
                gV_CurrAccList.RestoreLayoutFromStream(stream, option);
            }

            colPhoneNum = gV_CurrAccList.Columns["PhoneNum"];
            RepositoryItemTextEdit repoPhoneNum = new();
            repoPhoneNum.MaskSettings.Set("MaskManagerType", typeof(RegularMaskManager));
            repoPhoneNum.MaskSettings.Set("mask", "(\\d?\\d?) \\d\\d\\d-\\d\\d-\\d\\d");
            repoPhoneNum.UseMaskAsDisplayFormat = true;
            gC_CurrAccList.RepositoryItems.AddRange(new RepositoryItem[] { repoPhoneNum });
            colPhoneNum.ColumnEdit = repoPhoneNum;

            colBalance = gV_CurrAccList.Columns["Balance"];
            RepositoryItemTextEdit repoMoney = new();
            repoMoney.MaskSettings.Set("MaskManagerType", typeof(NumericMaskManager));
            repoMoney.MaskSettings.Set("mask", "f2");
            repoMoney.UseMaskAsDisplayFormat = true;
            gC_CurrAccList.RepositoryItems.AddRange(new RepositoryItem[] { repoMoney });
            colBalance.ColumnEdit = repoMoney;
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
            #region comment
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if (info.InRow || info.InRowCell)
            //{
            //    //info.RowHandle
            //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    dcCurrAcc = new DcCurrAcc();
            //    string CurrAccCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CurrAccCode"]).ToString();
            //    dcCurrAcc = efMethods.SelectCurrAcc(CurrAccCode);

            //    DialogResult = DialogResult.OK;
            //} 
            #endregion

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
            FormCurrAcc form = new(currAccTypeArr.FirstOrDefault());
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();

        }

        private void bBI_CurrAccEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ApplySelectedCurrAcc();

            if (dcCurrAcc is not null)
            {
                FormCurrAcc form = new(dcCurrAcc.CurrAccCode);
                if (form.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
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

        private void LoadCurrAc()
        {
            //if (currAccTypeCode != 0)
            //    dcCurrAccsBindingSource.DataSource = efMethods.SelectCurrAccs(new byte[] { currAccTypeCode });
            //else
            //    dcCurrAccsBindingSource.DataSource = efMethods.SelectCurrAccs(new byte[] { 1, 2, 3, 4 });
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
                    string cellValue = gV_CurrAccList.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        // AutoFocus FindPanel
        bool isFirstPaint = true;
        private void gC_CurrAccList_Paint(object sender, PaintEventArgs e)
        {
            //GridControl gC = sender as GridControl;
            //GridView gV = gC.MainView as GridView;

            //if (isFirstPaint)
            //{
            //   if (!gV.FindPanelVisible)
            //      gV.ShowFindPanel();
            //   gV.ShowFindPanel();

            //   gV.OptionsFind.FindFilterColumns = "CurrAccDesc";
            //   gV.OptionsFind.FindNullPrompt = "Axtarın...";
            //}
            //isFirstPaint = false;
        }

        private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
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

        private void bBI_Report1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReport(1003);
            object currAccCode = gV_CurrAccList.GetFocusedRowCellValue(colCurrAccCode);

            if (currAccCode is not null)
            {
                efMethods.UpdateDcReportFilter_Value(dcReport.ReportId, "CurrAccCode", currAccCode.ToString());

                dcReport = efMethods.SelectReport(dcReport.ReportId);

                string reportQuery = dcReport.ReportQuery;

                ICollection<DcReportFilter> dcReportFilters = dcReport.DcReportFilters;
                CriteriaOperator[] criteriaOperators = new CriteriaOperator[dcReportFilters.Count];
                int index = 0;
                foreach (DcReportFilter rf in dcReportFilters)
                {
                    BinaryOperatorType operatorType = ConvertOperatorType(rf.FilterOperatorType);

                    criteriaOperators[index] = new BinaryOperator(rf.FilterProperty, rf.FilterValue, operatorType);

                    string filterSql = CriteriaToWhereClauseHelper.GetMsSqlWhere(criteriaOperators[index]);
                    reportQuery = reportQuery.Replace(rf.Representative, " and " + filterSql); //filter sorgunun icinde temsilci ile deyisdirilir

                    index++;
                }
                //CriteriaOperator groupOperator = new GroupOperator(GroupOperatorType.And, criteriaOperators);
                string qryMaster = "Select * from ( " + reportQuery + ") as master";

                string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

                FormReportGrid formGrid = new(qryMaster, dcReport, activeFilterStr);
                formGrid.Show();
            }
        }

        private BinaryOperatorType ConvertOperatorType(string filterOperatorType)
        {
            return filterOperatorType switch
            {
                "+" => BinaryOperatorType.Plus,
                "&" => BinaryOperatorType.BitwiseAnd,
                "/" => BinaryOperatorType.Divide,
                "==" => BinaryOperatorType.Equal,
                ">" => BinaryOperatorType.Greater,
                ">=" => BinaryOperatorType.GreaterOrEqual,
                "<" => BinaryOperatorType.Less,
                "<=" => BinaryOperatorType.LessOrEqual,
                "%" => BinaryOperatorType.Modulo,
                "*" => BinaryOperatorType.Multiply,
                "!=" => BinaryOperatorType.NotEqual,
                "|" => BinaryOperatorType.BitwiseOr,
                "-" => BinaryOperatorType.Minus,
                "^" => BinaryOperatorType.BitwiseXor,
                _ => BinaryOperatorType.Equal,
            };
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraSaveFileDialog sFD = new();
            sFD.Filter = "Excel Faylı|*.xlsx";
            sFD.Title = "Excel Faylı Yadda Saxla";
            sFD.FileName = this.Text;
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sFD.DefaultExt = "*.xlsx";

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_CurrAccList.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                        p.Start();
                    }

                    return "Ok";
                }
                else
                    return "Fail";
            }));
        }

        private void bBI_CurrAccDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcCurrAcc is not null)
            {
                if (efMethods.CurrAccExist(dcCurrAcc.CurrAccCode))
                {
                    if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + dcCurrAcc.CurrAccDesc, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        efMethods.DeleteCurrAcc(dcCurrAcc);

                        LoadCurrAccs(currAccTypeArr);
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
            //GridControl gC = sender as GridControl;
            //GridView gV = gC.MainView as GridView;
            //if (gV is not null)
            //{
            //    gV_CurrAccList.OptionsFind.FindFilterColumns = "CurrAccDesc";
            //    gV_CurrAccList.OptionsFind.FindNullPrompt = "Axtarın...";
            //
            //    //if (!gV.FindPanelVisible)
            //    gC.BeginInvoke(new Action(gV.ShowFindPanel));
            //}
            //
            //int rowHandle = gV_CurrAccList.LocateByValue(0, colCurrAccCode, currAccCode);
            //if (rowHandle != GridControl.InvalidRowHandle)
            //{
            //    gV_CurrAccList.FocusedRowHandle = rowHandle;
            //    gV_CurrAccList.MakeRowVisible(rowHandle);
            //}
            //
            //gV_CurrAccList.BestFitColumns();
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

        // Menu item click handler.
        void DXMenuCheckItem_ItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            SaveLayout();

            //GridColumn col = gV_Report.Columns.AddVisible("Unbound" + gV_Report.Columns.Count);
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

        private void BBI_ReportCashReg_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DcReport dcReport = efMethods.SelectReport(1006);
            //object currAccCode = gV_CurrAccList.GetFocusedRowCellValue(colCurrAccCode);

            //if (currAccCode is not null && dcReport is not null)
            //{
            //    string qryMaster = "Select * from ( " + dcReport.ReportQuery + ") as master";
            //    string columnName = "[CurrAccCode]";
            //    string dateFilter = "";

            //    if (currAccTypeArr.Contains((byte)5))
            //    {
            //        columnName = "[CashRegisterCode]";
            //        dateFilter = $" AND [OperationDate] Between(#{DateTime.Now.ToString("yyyy-MM-dd")}#, #{DateTime.Now.ToString("yyyy-MM-dd")}#) ";
            //    }

            //    string activeFilterStr = $"{columnName} = \'{currAccCode}\'" + dateFilter;

            //    FormReportGrid formGrid = new(qryMaster, dcReport, activeFilterStr);
            //    formGrid.Show();
            //}
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
                    gC_CurrAccList.ExportToXlsx(sFD.FileName);

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

            if (currAccTypeArr.Contains((byte)5))
                dcReport = efMethods.SelectReportByName("FormCashRegList");
            else if (currAccTypeArr.Contains((byte)1) || currAccTypeArr.Contains((byte)2) || currAccTypeArr.Contains((byte)3))
                dcReport = efMethods.SelectReportByName("FormCurrAccList");

            if (dcReport is not null)
            {
                int id = dcReport.ReportId;
                FormReportEditor formQueryEditor = new(id);
                if (formQueryEditor.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }
    }
}