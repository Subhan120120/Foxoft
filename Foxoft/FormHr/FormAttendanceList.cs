using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormAttendanceList : RibbonForm
    {
        private readonly subContext db = new();

        public FormAttendanceList()
        {
            InitializeComponent();
            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => EditItem();
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }

        private void LoadData()
        {
            var list = db.TrAttendances.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .OrderBy(x => x.WorkDate)
                .Select(x => new
                {
                    x.Id,
                    x.CurrAccCode,
                    EmployeeName = (!string.IsNullOrEmpty(x.DcCurrAcc.CurrAccDesc)
                        ? x.DcCurrAcc.CurrAccDesc
                        : ((x.DcCurrAcc.FirstName ?? "") + " " + (x.DcCurrAcc.LastName ?? "")).Trim()),
                    x.WorkDate,
                    x.CheckInTime,
                    x.CheckOutTime,
                    x.WorkedMinutes
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;
            if (gridView1.Columns["CurrAccCode"] != null) gridView1.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_TrAttendance_CurrAccCode;
            if (gridView1.Columns["EmployeeName"] != null) gridView1.Columns["EmployeeName"].Caption = Properties.Resources.Common_EmployeeName;
            if (gridView1.Columns["WorkDate"] != null) gridView1.Columns["WorkDate"].Caption = Properties.Resources.Entity_TrAttendance_WorkDate;
            if (gridView1.Columns["CheckInTime"] != null) gridView1.Columns["CheckInTime"].Caption = Properties.Resources.Entity_TrAttendance_CheckInTime;
            if (gridView1.Columns["CheckOutTime"] != null) gridView1.Columns["CheckOutTime"].Caption = Properties.Resources.Entity_TrAttendance_CheckOutTime;
            if (gridView1.Columns["WorkedMinutes"] != null) gridView1.Columns["WorkedMinutes"].Caption = Properties.Resources.Entity_TrAttendance_WorkedMinutes;

            gridView1.BestFitColumns();
        }

        public Guid? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
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
                var focused = FocusedId();
                if (focused.HasValue)
                    ids.Add(focused.Value);
            }
            return ids;
        }

        private void NewItem()
        {
            using var f = new FormAttendanceEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormAttendanceEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var ids = GetSelectedIds();
            if (!ids.Any())
            {
                XtraMessageBox.Show(this,
                    Properties.Resources.Common_SelectRowToDelete,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string message = ids.Count == 1
                ? Properties.Resources.Form_AttendanceList_DeleteConfirm
                : string.Format(Properties.Resources.Form_AttendanceList_DeleteMultipleConfirm, ids.Count);

            if (XtraMessageBox.Show(this, message, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entities = db.TrAttendances.Where(x => ids.Contains(x.Id)).ToList();
            if (entities.Any())
            {
                db.TrAttendances.RemoveRange(entities);
                db.SaveChanges();
            }

            LoadData();
        }
    }
}
