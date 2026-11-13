using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormLeaveRequestList : RibbonForm
    {
        private readonly subContext db = new();

        public FormLeaveRequestList()
        {
            InitializeComponent();

            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnApprove.ItemClick += (_, __) => SetStatus(LeaveStatus.Approved);
            btnReject.ItemClick += (_, __) => SetStatus(LeaveStatus.Rejected);
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => EditItem();
        }

        private void LoadData()
        {
            var list = db.HrLeaveRequests.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.LeaveType)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new
                {
                    x.Id,
                    x.RequestNumber,
                    x.CurrAccCode,
                    EmployeeName = (!string.IsNullOrWhiteSpace(x.DcCurrAcc.CurrAccDesc)
                        ? x.DcCurrAcc.CurrAccDesc
                        : $"{x.DcCurrAcc.FirstName} {x.DcCurrAcc.LastName}".Trim()),
                    LeaveType = x.LeaveType.TypeName,
                    x.StartDate,
                    x.EndDate,
                    x.TotalDays,
                    x.TotalHours,
                    x.Reason,
                    Status = x.Status.ToString(),
                    x.CreatedDate
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;
            if (gridView1.Columns["RequestNumber"] != null) gridView1.Columns["RequestNumber"].Caption = "Müraciət №";
            if (gridView1.Columns["CurrAccCode"] != null) gridView1.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_CurrAcc_Code;
            if (gridView1.Columns["EmployeeName"] != null) gridView1.Columns["EmployeeName"].Caption = Properties.Resources.Common_EmployeeName;
            if (gridView1.Columns["LeaveType"] != null) gridView1.Columns["LeaveType"].Caption = "İcazə Növü";
            if (gridView1.Columns["StartDate"] != null) gridView1.Columns["StartDate"].Caption = "Başlanğıc";
            if (gridView1.Columns["EndDate"] != null) gridView1.Columns["EndDate"].Caption = "Bitmə";
            if (gridView1.Columns["TotalDays"] != null) gridView1.Columns["TotalDays"].Caption = "Gün Sayı";
            if (gridView1.Columns["TotalHours"] != null) gridView1.Columns["TotalHours"].Caption = "Saat";
            if (gridView1.Columns["Reason"] != null) gridView1.Columns["Reason"].Caption = Properties.Resources.Common_Note;
            if (gridView1.Columns["Status"] != null) gridView1.Columns["Status"].Caption = "Status";
            if (gridView1.Columns["CreatedDate"] != null) gridView1.Columns["CreatedDate"].Caption = "Müraciət Tarixi";

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
            using var f = new FormLeaveRequestEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormLeaveRequestEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, "Seçilmiş müraciəti silmək istədiyinizə əminsiniz?", Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.HrLeaveRequests.Include(x => x.RequestDays).Include(x => x.Approvals).FirstOrDefault(x => x.Id == id.Value);
            if (entity != null)
            {
                db.HrLeaveRequests.Remove(entity);
                db.SaveChanges();
                LoadData();
            }
        }

        private void SetStatus(LeaveStatus status)
        {
            var id = FocusedId();
            if (id == null) return;

            var entity = db.HrLeaveRequests.FirstOrDefault(x => x.Id == id.Value);
            if (entity != null)
            {
                entity.Status = status;

                // Təsdiq qeydi əlavə et
                var approval = new HrLeaveApproval
                {
                    Id = Guid.NewGuid(),
                    LeaveRequestId = entity.Id,
                    ApprovalDate = DateTime.Now,
                    Status = status,
                    Comment = status == LeaveStatus.Approved ? "Təsdiqləndi" : "İmtina edildi"
                };
                db.HrLeaveApprovals.Add(approval);

                db.SaveChanges();
                LoadData();
            }
        }
    }
}
