using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormAttendanceLogList : RibbonForm
    {
        private readonly subContext db = new();
        private readonly AttendanceLogExcelService excelService = new();
        private readonly AttendanceCalculationService calcService = new();

        public FormAttendanceLogList(DateTime? initialDate = null)
        {
            InitializeComponent();

            if (initialDate.HasValue)
            {
                barEditDateFrom.EditValue = initialDate.Value.Date;
                barEditDateTo.EditValue = initialDate.Value.Date;
            }
            else
            {
                barEditDateFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                barEditDateTo.EditValue = DateTime.Today;
            }

            InitStoreFilter();

            Load += (_, __) => LoadData();
            btnRefresh.ItemClick += (_, __) => LoadData();
            barEditDateFrom.EditValueChanged += (_, __) => LoadData();
            barEditDateTo.EditValueChanged += (_, __) => LoadData();
            barEditStore.EditValueChanged += (_, __) => LoadData();

            btnImportExcel.ItemClick += (_, __) => ImportExcel();
            btnDelete.ItemClick += (_, __) => DeleteSelected();
            btnClose.ItemClick += (_, __) => Close();
        }

        private void InitStoreFilter()
        {
            var stores = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Store)
                .Select(x => new { x.CurrAccCode, x.CurrAccDesc })
                .ToList();

            repoStore.DataSource = stores;
            repoStore.DisplayMember = "CurrAccDesc";
            repoStore.ValueMember = "CurrAccCode";
        }

        private void LoadData()
        {
            DateTime dateFrom = barEditDateFrom.EditValue is DateTime df ? df.Date : DateTime.Today.AddDays(-30);
            DateTime dateTo = barEditDateTo.EditValue is DateTime dt ? dt.Date.AddDays(1).AddTicks(-1) : DateTime.Today.AddDays(1).AddTicks(-1);
            string? storeCode = barEditStore.EditValue?.ToString();

            var query = db.TrAttendanceLogs.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Where(x => x.LogDateTime >= dateFrom && x.LogDateTime <= dateTo);

            if (!string.IsNullOrWhiteSpace(storeCode))
                query = query.Where(x => x.DcCurrAcc.StoreCode == storeCode);

            var list = query
                .OrderByDescending(x => x.LogDateTime)
                .Select(x => new
                {
                    x.Id,
                    x.CurrAccCode,
                    EmployeeName = (!string.IsNullOrEmpty(x.DcCurrAcc.CurrAccDesc)
                        ? x.DcCurrAcc.CurrAccDesc
                        : ((x.DcCurrAcc.FirstName ?? "") + " " + (x.DcCurrAcc.LastName ?? "")).Trim()),
                    x.DcCurrAcc.StoreCode,
                    x.LogDateTime,
                    x.DeviceCode,
                    PunchTypeDesc = x.PunchType.ToString(),
                    SourceMethodDesc = x.SourceMethod.ToString(),
                    x.IsIgnored,
                    x.IgnoreReason,
                    x.CreatedDate,
                    x.CreatedUserName
                })
                .ToList();

            gridControl1.DataSource = list;

            FormatGrid();
        }

        private void FormatGrid()
        {
            if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;

            if (gridView1.Columns["CurrAccCode"] != null) gridView1.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_CurrAcc_Code;
            if (gridView1.Columns["EmployeeName"] != null) gridView1.Columns["EmployeeName"].Caption = Properties.Resources.Common_EmployeeName;
            if (gridView1.Columns["StoreCode"] != null) gridView1.Columns["StoreCode"].Caption = Properties.Resources.Common_Store;

            if (gridView1.Columns["LogDateTime"] != null)
            {
                gridView1.Columns["LogDateTime"].Caption = Properties.Resources.Common_Date;
                gridView1.Columns["LogDateTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["LogDateTime"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            }

            if (gridView1.Columns["DeviceCode"] != null) gridView1.Columns["DeviceCode"].Caption = "Cihaz Kodu";
            if (gridView1.Columns["PunchTypeDesc"] != null) gridView1.Columns["PunchTypeDesc"].Caption = "Vuruş Növü";
            if (gridView1.Columns["SourceMethodDesc"] != null) gridView1.Columns["SourceMethodDesc"].Caption = "Mənbə";
            if (gridView1.Columns["IsIgnored"] != null) gridView1.Columns["IsIgnored"].Caption = "Nəzərə Alınmır";
            if (gridView1.Columns["IgnoreReason"] != null) gridView1.Columns["IgnoreReason"].Caption = "Səbəb";

            if (gridView1.Columns["CreatedDate"] != null)
            {
                gridView1.Columns["CreatedDate"].Caption = Properties.Resources.Common_CreatedDate;
                gridView1.Columns["CreatedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView1.Columns["CreatedDate"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            }

            if (gridView1.Columns["CreatedUserName"] != null) gridView1.Columns["CreatedUserName"].Caption = Properties.Resources.Common_Author;

            gridView1.BestFitColumns();
        }

        private void ImportExcel()
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Excel Faylları (*.xlsx;*.xls)|*.xlsx;*.xls|Bütün Fayllar (*.*)|*.*",
                Title = Properties.Resources.Form_AttendanceLogList_ImportExcel
            };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var result = excelService.Import(ofd.FileName);

                string summary = string.Format(Properties.Resources.Form_AttendanceLogList_ImportSuccess,
                    result.ImportedCount, result.SkippedDuplicateCount, result.ErrorCount);

                XtraMessageBox.Show(this, summary, Properties.Resources.Common_Success,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                if (result.ImportedCount > 0 && result.MinDate.HasValue && result.MaxDate.HasValue)
                {
                    string askMsg = string.Format(Properties.Resources.Form_AttendanceLogList_AskRecalculate,
                        result.MinDate.Value, result.MaxDate.Value);

                    if (XtraMessageBox.Show(this, askMsg, Properties.Resources.Common_Confirm,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        calcService.CalculateAttendance(result.MinDate.Value, result.MaxDate.Value, null, null, null, null, true);
                        XtraMessageBox.Show(this, Properties.Resources.Form_DailyAttendance_RecalculatedSuccess,
                            Properties.Resources.Common_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "Xəta baş verdi: " + ex.Message, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Guid> GetSelectedIds()
        {
            var ids = new List<Guid>();
            var rowHandles = gridView1.GetSelectedRows();
            foreach (var handle in rowHandles)
            {
                if (handle >= 0)
                {
                    var row = gridView1.GetRow(handle);
                    if (row != null)
                    {
                        var prop = row.GetType().GetProperty("Id");
                        if (prop?.GetValue(row) is Guid g)
                            ids.Add(g);
                    }
                }
            }

            if (!ids.Any())
            {
                var focused = gridView1.GetFocusedRow();
                if (focused != null)
                {
                    var prop = focused.GetType().GetProperty("Id");
                    if (prop?.GetValue(focused) is Guid g)
                        ids.Add(g);
                }
            }

            return ids;
        }

        private void DeleteSelected()
        {
            var ids = GetSelectedIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_AttendanceLogList_SelectRowsToDelete,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string confirmMsg = string.Format(Properties.Resources.Form_AttendanceLogList_DeleteConfirm, ids.Count);
            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entities = db.TrAttendanceLogs.Where(x => ids.Contains(x.Id)).ToList();
            if (entities.Any())
            {
                db.TrAttendanceLogs.RemoveRange(entities);
                db.SaveChanges();
            }

            LoadData();

            XtraMessageBox.Show(this, Properties.Resources.Form_AttendanceLogList_DeleteSuccess,
                Properties.Resources.Common_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
