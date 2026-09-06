using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace Foxoft
{
    public partial class FormPayrollList : RibbonForm
    {
        EfMethods efMethods = new();

        public FormPayrollList()
        {
            InitializeComponent();
        }

        private void View_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void LoadData()
        {
            object list = efMethods.SelectPayrolList();

            grid.DataSource = list;

            if (view.Columns["Id"] != null) view.Columns["Id"].Visible = false;
            if (view.Columns["CurrAccCode"] != null) view.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_TrPayrollHeader_CurrAccCode;
            if (view.Columns["Employee"] != null) view.Columns["Employee"].Caption = Properties.Resources.Common_EmployeeName;
            if (view.Columns["Period"] != null) view.Columns["Period"].Caption = Properties.Resources.Entity_TrPayrollHeader_PeriodId;
            if (view.Columns["GrossSalary"] != null) view.Columns["GrossSalary"].Caption = Properties.Resources.Entity_TrPayrollHeader_GrossSalary;
            if (view.Columns["NetSalary"] != null) view.Columns["NetSalary"].Caption = Properties.Resources.Entity_TrPayrollHeader_NetSalary;

            HyperLinkColumns();

            view.BestFitColumns();
        }

        private void HyperLinkColumns()
        {
            GridColumn col_CurrAccCode = view.Columns["CurrAccCode"];
            if (col_CurrAccCode != null)
            {
                RepositoryItemHyperLinkEdit HLE_CurrAccCode = new();
                HLE_CurrAccCode.SingleClick = true;
                HLE_CurrAccCode.OpenLink += RepoHLE_CurrAccCode_OpenLink;
                col_CurrAccCode.ColumnEdit = HLE_CurrAccCode;
            }
        }

        private void RepoHLE_CurrAccCode_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objCurrAccCode = view.GetFocusedRowCellValue("CurrAccCode");
            string currAccCode = objCurrAccCode?.ToString();
            if (!string.IsNullOrEmpty(currAccCode))
                OpenFormCurrAcc(currAccCode);
        }

        private void OpenFormCurrAcc(string currAccCode)
        {
            using FormCurrAcc formCurrAcc = new(currAccCode);
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (view.FocusedColumn?.FieldName != "CurrAccCode")
                e.Cancel = true;
        }

        private void View_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            if (ea == null) return;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if (info.Column?.FieldName != "CurrAccCode")
                {
                    var id = FocusedId();
                    if (id.HasValue)
                    {
                        using var f = new FormPayrollEdit(id.Value);
                        if (f.ShowDialog(this) == DialogResult.OK) LoadData();
                    }
                }
            }
        }

        private void View_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                e.Menu.Items.Clear();

                CreateMenuItemEdit(e);

                DXSubMenuItem menuSubItem = CreateSubMenuReports(e.HitInfo.Column, e.HitInfo.RowHandle);
                menuSubItem.BeginGroup = true;

                if (menuSubItem.Items.Count > 0)
                    e.Menu.Items.Add(menuSubItem);
            }
        }

        private DXMenuItem CreateMenuItemEdit(PopupMenuShowingEventArgs eMenu)
        {
            int rowHandle = eMenu.HitInfo.RowHandle;
            GridColumn gridColumn = eMenu.HitInfo.Column;

            DXMenuItem menuItem = new(Properties.Resources.Common_Edit);

            if (gridColumn != null && gridColumn.FieldName == "CurrAccCode")
            {
                object objCellValue = view.GetRowCellValue(rowHandle, gridColumn);
                string cellValue = objCellValue?.ToString();

                if (!string.IsNullOrEmpty(cellValue))
                {
                    menuItem.Click += (sender, e) =>
                    {
                        OpenFormCurrAcc(cellValue);
                    };
                    eMenu.Menu.Items.Add(menuItem);
                }
            }
            else
            {
                var row = view.GetRow(rowHandle);
                if (row != null)
                {
                    var p = row.GetType().GetProperty("Id");
                    if (p?.GetValue(row) is Guid id)
                    {
                        menuItem.Click += (sender, e) =>
                        {
                            using var f = new FormPayrollEdit(id);
                            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
                        };
                        eMenu.Menu.Items.Add(menuItem);
                    }
                }
            }

            return menuItem;
        }

        private DXSubMenuItem CreateSubMenuReports(GridColumn gridColumn, int rowHandle)
        {
            DXSubMenuItem subMenu = new(Properties.Resources.ERP_BSI_Reports);

            List<TrFormReport> trFormReports = new();
            if (gridColumn?.FieldName == "CurrAccCode")
                trFormReports = efMethods.SelectFormReports("CurrAccs");

            foreach (TrFormReport report in trFormReports)
            {
                DXMenuItem dxItem = new(report.DcReport.ReportName);
                subMenu.Items.Add(dxItem);

                dxItem.Click += (sender, e) =>
                {
                    DcReport dcReport = efMethods.SelectReport(report.DcReport.ReportId);

                    string filter = "";
                    string columnValue = view.GetRowCellValue(rowHandle, gridColumn)?.ToString();

                    if (rowHandle >= 0)
                        filter = gridColumn.FieldName + " = '" + columnValue + "' ";

                    if (dcReport.DcReportVariables != null)
                    {
                        foreach (var item in dcReport.DcReportVariables.Where(x => x.ReportId == report.DcReport.ReportId))
                        {
                            if (item.VariableProperty == gridColumn?.FieldName && !string.IsNullOrEmpty(columnValue))
                            {
                                item.VariableValue = columnValue;
                            }
                        }
                    }

                    if (dcReport.ReportTypeId == 1)
                    {
                        FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport);
                        formGrid.Show();
                    }
                    else if (dcReport.ReportTypeId == 2)
                    {
                        FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();
                    }
                };
            }

            return subMenu;
        }

        private Guid? FocusedId()
        {
            var row = view.GetFocusedRow();
            if (row == null) return null;
            var p = row.GetType().GetProperty("Id");
            return p == null ? null : (Guid?)p.GetValue(row);
        }

        private List<Guid> GetSelectedIds()
        {
            var selectedRowHandles = view.GetSelectedRows();
            var list = new List<Guid>();

            foreach (var rowHandle in selectedRowHandles)
            {
                if (rowHandle < 0) continue;
                var row = view.GetRow(rowHandle);
                if (row == null) continue;
                var p = row.GetType().GetProperty("Id");
                if (p?.GetValue(row) is Guid id)
                    list.Add(id);
            }

            if (list.Count == 0)
            {
                var focusedId = FocusedId();
                if (focusedId.HasValue)
                    list.Add(focusedId.Value);
            }

            return list.Distinct().ToList();
        }

        private void FormPayrollList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var f = new FormPayrollEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void BtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var selectedIds = GetSelectedIds();
            if (selectedIds.Count == 0) return;

            string confirmMsg = selectedIds.Count == 1
                ? Properties.Resources.Form_PayrollList_DeleteConfirm
                : string.Format(Properties.Resources.Form_PayrollList_DeleteMultipleConfirm, selectedIds.Count);

            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using var db = new subContext();
                var entities = db.TrPayrollHeaders
                    .Include(x => x.Lines)
                    .Where(x => selectedIds.Contains(x.Id))
                    .ToList();

                if (entities.Count == 0) return;

                db.TrPayrollHeaders.RemoveRange(entities);
                db.SaveChanges();
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormPayrollEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void BtnWizard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var wizard = new FormPayrollWizard();
            if (wizard.ShowDialog(this) == DialogResult.OK) LoadData();
        }
    }
}
