using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
                    EmployeeName = (x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName).Trim(),
                    x.WorkDate,
                    x.CheckInTime,
                    x.CheckOutTime,
                    x.WorkedMinutes
                })
                .ToList();

            gridControl1.DataSource = list;

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
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_AttendanceList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.TrAttendances.FirstOrDefault(x => x.Id == id.Value);
            if (entity == null) return;

            db.TrAttendances.Remove(entity);
            db.SaveChanges();
            LoadData();
        }
    }
}
