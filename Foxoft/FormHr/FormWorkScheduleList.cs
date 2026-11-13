using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormWorkScheduleList : RibbonForm
    {
        private readonly subContext db = new();

        public FormWorkScheduleList()
        {
            InitializeComponent();

            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => EditItem();
        }

        private void LoadData()
        {
            var list = db.DcWorkSchedules.AsNoTracking()
                .OrderBy(x => x.ScheduleCode)
                .Select(x => new
                {
                    x.Id,
                    x.ScheduleCode,
                    x.ScheduleName,
                    ScheduleType = x.ScheduleType.ToString(),
                    x.WeeklyHours,
                    x.IsActive,
                    x.Description
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;
            if (gridView1.Columns["ScheduleCode"] != null) gridView1.Columns["ScheduleCode"].Caption = "Qrafik Kodu";
            if (gridView1.Columns["ScheduleName"] != null) gridView1.Columns["ScheduleName"].Caption = "Qrafik Adı";
            if (gridView1.Columns["ScheduleType"] != null) gridView1.Columns["ScheduleType"].Caption = "Rejim Növü";
            if (gridView1.Columns["WeeklyHours"] != null) gridView1.Columns["WeeklyHours"].Caption = "Həftəlik Saat";
            if (gridView1.Columns["IsActive"] != null) gridView1.Columns["IsActive"].Caption = "Aktivdir";
            if (gridView1.Columns["Description"] != null) gridView1.Columns["Description"].Caption = Properties.Resources.Common_Note;

            gridView1.BestFitColumns();
        }

        private Guid? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private void NewItem()
        {
            using var f = new FormWorkScheduleEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormWorkScheduleEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, "Seçilmiş iş qrafikini silmək istədiyinizə əminsiniz?", Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcWorkSchedules.Include(x => x.Days).FirstOrDefault(x => x.Id == id.Value);
            if (entity != null)
            {
                db.DcWorkSchedules.Remove(entity);
                db.SaveChanges();
                LoadData();
            }
        }
    }
}
