using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormFormReport : RibbonForm
    {
        private readonly string? formCode;
        private subContext dbContext = new();
        private bool isFirstPaint = true;

        public bool IsChanged { get; private set; }
        public TrFormReport? TrFormReport { get; private set; }

        public FormFormReport()
            : this(null)
        {
        }

        public FormFormReport(string? formCode)
        {
            this.formCode = formCode;

            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_FormReportList.RestoreLayoutFromStream(stream, option);

            if (!string.IsNullOrWhiteSpace(formCode))
                colFormCode.OptionsColumn.AllowEdit = false;

            FormClosed += (_, __) => dbContext.Dispose();

            UpdateGridViewData();
        }

        private void UpdateGridViewData()
        {
            int focusedRowHandle = gV_FormReportList.FocusedRowHandle;

            LoadData();

            if (focusedRowHandle > 0)
                gV_FormReportList.FocusedRowHandle = focusedRowHandle;
            else
                gV_FormReportList.MoveLast();

            SetFocusedEntity();
        }

        private void LoadData()
        {
            dbContext.Dispose();
            dbContext = new subContext();

            LoadLookups();

            IQueryable<TrFormReport> query = dbContext.TrFormReports
                .Include(x => x.DcForm)
                .Include(x => x.DcReport);

            if (!string.IsNullOrWhiteSpace(formCode))
                query = query.Where(x => x.FormCode == formCode);

            query
                .OrderBy(x => x.FormCode)
                .ThenBy(x => x.ReportId)
                .Load();

            trFormReportsBindingSource.DataSource = dbContext.TrFormReports.Local.ToBindingList();

            gV_FormReportList.BestFitColumns();
        }

        private void LoadLookups()
        {
            repoLUE_FormCode.DataSource = dbContext.DcForms
                .AsNoTracking()
                .OrderBy(x => x.FormCode)
                .Select(x => new
                {
                    x.FormCode,
                    x.FormDesc
                })
                .ToList();

            repoLUE_ReportId.DataSource = dbContext.DcReports
                .AsNoTracking()
                .OrderBy(x => x.ReportName)
                .Select(x => new
                {
                    x.ReportId,
                    x.ReportName
                })
                .ToList();
        }

        private void SetFocusedEntity()
        {
            if (gV_FormReportList.FocusedRowHandle >= 0)
                TrFormReport = gV_FormReportList.GetFocusedRow() as TrFormReport;
            else
                TrFormReport = null;
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            gV_FormReportList.AddNewRow();
            gV_FormReportList.FocusedColumn = string.IsNullOrWhiteSpace(formCode) ? colFormCode : colReportId;
            gV_FormReportList.ShowEditor();
        }

        private void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            Validate();
            gV_FormReportList.PostEditor();
            gV_FormReportList.UpdateCurrentRow();
            trFormReportsBindingSource.EndEdit();

            if (!ValidateRows())
                return;

            try
            {
                dbContext.SaveChanges();
                IsChanged = true;
                UpdateGridViewData();
                XtraMessageBox.Show(this, Resources.Common_SavedSuccessfully, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.GetBaseException().Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRows()
        {
            List<TrFormReport> rows = dbContext.TrFormReports.Local
                .Where(x => dbContext.Entry(x).State != EntityState.Deleted)
                .ToList();

            if (rows.Any(x => string.IsNullOrWhiteSpace(x.FormCode) || x.ReportId <= 0))
            {
                XtraMessageBox.Show(this, Resources.Form_PriceListDetail_Message_InvalidData, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool hasDuplicate = rows
                .GroupBy(x => new { x.FormCode, x.ReportId })
                .Any(x => x.Count() > 1);

            if (hasDuplicate)
            {
                XtraMessageBox.Show(this, Resources.Form_Common_Exists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TrFormReport is null)
            {
                XtraMessageBox.Show(this, Resources.Message_NoRowSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deleteText = $"{TrFormReport.FormCode} - {TrFormReport.DcReport?.ReportName ?? TrFormReport.ReportId.ToString()}";

            if (XtraMessageBox.Show(
                this,
                string.Format(Resources.Message_DeleteConfirm, deleteText),
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                return;

            dbContext.TrFormReports.Remove(TrFormReport);
            dbContext.SaveChanges();
            IsChanged = true;
            UpdateGridViewData();
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_FormReportList);
        }

        private void bBI_Close_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gV_FormReportList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            SetFocusedEntity();
        }

        private void gV_FormReportList_ColumnFilterChanged(object sender, EventArgs e)
        {
            SetFocusedEntity();
        }

        private void gV_FormReportList_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = (GridView)sender;

            if (!string.IsNullOrWhiteSpace(formCode))
                view.SetRowCellValue(e.RowHandle, colFormCode, formCode);

            view.SetRowCellValue(e.RowHandle, colCopyToClipboard, false);
        }

        private void gV_FormReportList_ShowingEditor(object sender, CancelEventArgs e)
        {
            bool isKeyColumn = gV_FormReportList.FocusedColumn == colFormCode || gV_FormReportList.FocusedColumn == colReportId;

            if (isKeyColumn && !gV_FormReportList.IsNewItemRow(gV_FormReportList.FocusedRowHandle))
                e.Cancel = true;
        }

        private void gC_FormReportList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl)?.FocusedView as ColumnView;
            if (view is null)
                return;

            if (e.KeyCode == Keys.C && e.Control)
            {
                string cellValue = view.GetFocusedValue()?.ToString();
                if (!string.IsNullOrEmpty(cellValue))
                {
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }
            }
        }

        private void gC_FormReportList_Paint(object sender, PaintEventArgs e)
        {
            if (!isFirstPaint)
                return;

            if (!gV_FormReportList.FindPanelVisible)
                gV_FormReportList.ShowFindPanel();

            gV_FormReportList.OptionsFind.FindNullPrompt = Resources.Common_Search;
            isFirstPaint = false;
        }

        private void FormTrFormReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
