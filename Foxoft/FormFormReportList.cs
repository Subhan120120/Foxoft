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
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormFormReportList : RibbonForm
    {
        private readonly string? formCode;
        private bool isFirstPaint = true;

        public bool IsChanged { get; private set; }
        public TrFormReport? trFormReport { get; private set; }

        public FormFormReportList()
            : this(null)
        {
        }

        public FormFormReportList(string? formCode)
        {
            this.formCode = formCode;

            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_FormReportList.RestoreLayoutFromStream(stream, option);

            LoadLookups();
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
            using subContext dbContext = new();

            IQueryable<TrFormReport> query = dbContext.TrFormReports
                .Include(x => x.DcForm)
                .Include(x => x.DcReport);

            if (!string.IsNullOrWhiteSpace(formCode))
                query = query.Where(x => x.FormCode == formCode);

            trFormReportsBindingSource.DataSource = query
                .OrderBy(x => x.FormCode)
                .ThenBy(x => x.ReportId)
                .AsNoTracking()
                .ToList();

            gV_FormReportList.BestFitColumns();
        }

        private void LoadLookups()
        {
            using subContext dbContext = new();

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

            repoLUE_UseReportAs.DataSource = new[]
            {
                new { UseReportAs = UseReportAs.CopyToClipboard, UseReportAsDesc = Resources.Entity_FormReport_UseReportAs_CopyToClipboard },
                new { UseReportAs = UseReportAs.OpenPreview, UseReportAsDesc = Resources.Entity_FormReport_UseReportAs_OpenPreview },
                new { UseReportAs = UseReportAs.CopyToClipboardAndOpenPreview, UseReportAsDesc = Resources.Entity_FormReport_UseReportAs_CopyToClipboardAndOpenPreview }
            };
        }

        private void SetFocusedEntity()
        {
            if (gV_FormReportList.FocusedRowHandle >= 0)
                trFormReport = gV_FormReportList.GetFocusedRow() as TrFormReport;
            else
                trFormReport = null;
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormFormReport form = new(formCode);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                IsChanged = true;
                UpdateGridViewData();
            }
        }

        private void bBI_Edit_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditCurrent();
        }

        private void EditCurrent()
        {
            if (trFormReport is null)
            {
                XtraMessageBox.Show(this, Resources.Message_NoRowSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using FormFormReport form = new(trFormReport.FormCode, trFormReport.ReportId);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                IsChanged = true;
                UpdateGridViewData();
            }
        }

        private void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trFormReport is null)
            {
                XtraMessageBox.Show(this, Resources.Message_NoRowSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deleteText = $"{trFormReport.FormCode} - {trFormReport.DcReport?.ReportName ?? trFormReport.ReportId.ToString()}";

            if (XtraMessageBox.Show(
                this,
                string.Format(Resources.Message_DeleteConfirm, deleteText),
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                return;

            using subContext dbContext = new();
            TrFormReport? entity = dbContext.TrFormReports
                .FirstOrDefault(x => x.FormCode == trFormReport.FormCode && x.ReportId == trFormReport.ReportId);

            if (entity is not null)
            {
                dbContext.TrFormReports.Remove(entity);
                dbContext.SaveChanges();
                IsChanged = true;
                UpdateGridViewData();
            }
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

        private void gV_FormReportList_DoubleClick(object sender, EventArgs e)
        {
            EditCurrent();
        }

        private void gC_FormReportList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl)?.FocusedView as ColumnView;
            if (view is null)
                return;

            if (trFormReport is not null && e.KeyCode == Keys.Enter)
            {
                EditCurrent();
                e.Handled = true;
                return;
            }

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

        private void FormFormReportList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
