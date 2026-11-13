using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormLeaveRequestEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private HrLeaveRequest entity;

        public FormLeaveRequestEdit(Guid? requestId)
        {
            InitializeComponent();
            id = requestId;

            Text = id == null ? Properties.Resources.Form_LeaveRequest_Caption_New : Properties.Resources.Form_LeaveRequest_Caption_Edit;

            InitDropdowns();
            LoadEntity();

            btnEmployee.ButtonClick += BtnEmployee_ButtonClick;
            chkIsHourly.CheckedChanged += ChkIsHourly_CheckedChanged;
            dtStartDate.EditValueChanged += CalculateDuration;
            dtEndDate.EditValueChanged += CalculateDuration;
            timeStart.EditValueChanged += CalculateDuration;
            timeEnd.EditValueChanged += CalculateDuration;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => Close();
        }

        private void InitDropdowns()
        {
            var types = db.HrLeaveTypes.AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new { x.Id, x.TypeName, x.IsHourly })
                .ToList();
            lkpLeaveType.Properties.DataSource = types;
            lkpLeaveType.Properties.DisplayMember = "TypeName";
            lkpLeaveType.Properties.ValueMember = "Id";

            cmbStatus.Properties.Items.Clear();
            foreach (LeaveStatus s in Enum.GetValues(typeof(LeaveStatus)))
                cmbStatus.Properties.Items.Add(s);
        }

        private void BtnEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, btnEmployee.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                btnEmployee.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
                string name = $"{formCommonList.dcCurrAcc.FirstName} {formCommonList.dcCurrAcc.LastName}".Trim();
                if (string.IsNullOrWhiteSpace(name))
                    name = formCommonList.dcCurrAcc.CurrAccDesc ?? string.Empty;
                txtEmployeeName.Text = name;
            }
        }

        private void ChkIsHourly_CheckedChanged(object sender, EventArgs e)
        {
            bool isHourly = chkIsHourly.Checked;
            timeStart.Enabled = isHourly;
            timeEnd.Enabled = isHourly;
            CalculateDuration(sender, e);
        }

        private void CalculateDuration(object sender, EventArgs e)
        {
            if (dtStartDate.EditValue is not DateTime sDate || dtEndDate.EditValue is not DateTime eDate)
                return;

            if (chkIsHourly.Checked)
            {
                var tStart = timeStart.Time.TimeOfDay;
                var tEnd = timeEnd.Time.TimeOfDay;
                var diffHours = Math.Max(0, (decimal)(tEnd - tStart).TotalHours);

                spTotalDays.Value = 0;
                spTotalHours.Value = Math.Round(diffHours, 2);
            }
            else
            {
                var totalDays = Math.Max(1, (decimal)(eDate.Date - sDate.Date).TotalDays + 1);
                spTotalDays.Value = totalDays;
                spTotalHours.Value = totalDays * 8.0m;
            }
        }

        private void LoadEntity()
        {
            if (id == null)
            {
                entity = new HrLeaveRequest
                {
                    Id = Guid.NewGuid(),
                    RequestNumber = "REQ-" + DateTime.Now.ToString("yyMMddHHmm"),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,
                    Status = LeaveStatus.Submitted,
                    TotalDays = 1,
                    TotalHours = 8
                };
            }
            else
            {
                entity = db.HrLeaveRequests
                    .Include(x => x.RequestDays)
                    .Include(x => x.DcCurrAcc)
                    .First(x => x.Id == id.Value);

                btnEmployee.EditValue = entity.CurrAccCode;
                txtEmployeeName.Text = (!string.IsNullOrWhiteSpace(entity.DcCurrAcc?.CurrAccDesc)
                    ? entity.DcCurrAcc.CurrAccDesc
                    : $"{entity.DcCurrAcc?.FirstName} {entity.DcCurrAcc?.LastName}".Trim());
            }

            lkpLeaveType.EditValue = entity.LeaveTypeId;
            dtStartDate.DateTime = entity.StartDate.Date;
            dtEndDate.DateTime = entity.EndDate.Date;
            spTotalDays.Value = entity.TotalDays;
            spTotalHours.Value = entity.TotalHours;
            txtReason.Text = entity.Reason;
            cmbStatus.SelectedItem = entity.Status;

            var firstDay = entity.RequestDays.FirstOrDefault();
            if (firstDay != null && firstDay.StartTime.HasValue && firstDay.EndTime.HasValue)
            {
                chkIsHourly.Checked = true;
                timeStart.Time = DateTime.Today.Add(firstDay.StartTime.Value);
                timeEnd.Time = DateTime.Today.Add(firstDay.EndTime.Value);
            }
            else
            {
                chkIsHourly.Checked = false;
            }
        }

        private void Save()
        {
            if (btnEmployee.EditValue == null || string.IsNullOrWhiteSpace(btnEmployee.EditValue.ToString()))
            {
                XtraMessageBox.Show(this, "İşçi seçilməlidir.", Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lkpLeaveType.EditValue is not Guid leaveTypeId)
            {
                XtraMessageBox.Show(this, "İcazə növü seçilməlidir.", Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = btnEmployee.EditValue.ToString()!;
            entity.LeaveTypeId = leaveTypeId;
            entity.StartDate = dtStartDate.DateTime.Date;
            entity.EndDate = dtEndDate.DateTime.Date;
            entity.TotalDays = spTotalDays.Value;
            entity.TotalHours = spTotalHours.Value;
            entity.Reason = txtReason.Text;
            entity.Status = cmbStatus.SelectedItem is LeaveStatus ls ? ls : LeaveStatus.Submitted;

            // Günləri yenilə
            entity.RequestDays.Clear();

            if (chkIsHourly.Checked)
            {
                var tStart = timeStart.Time.TimeOfDay;
                var tEnd = timeEnd.Time.TimeOfDay;

                entity.RequestDays.Add(new HrLeaveRequestDay
                {
                    Id = Guid.NewGuid(),
                    LeaveRequestId = entity.Id,
                    Date = entity.StartDate.Date,
                    StartTime = tStart,
                    EndTime = tEnd,
                    DurationHours = spTotalHours.Value,
                    IsHalfDay = true,
                    IsPaid = true
                });
            }
            else
            {
                for (var d = entity.StartDate.Date; d <= entity.EndDate.Date; d = d.AddDays(1))
                {
                    entity.RequestDays.Add(new HrLeaveRequestDay
                    {
                        Id = Guid.NewGuid(),
                        LeaveRequestId = entity.Id,
                        Date = d,
                        DurationHours = 8.0m,
                        IsHalfDay = false,
                        IsPaid = true
                    });
                }
            }

            if (id == null)
                db.HrLeaveRequests.Add(entity);

            db.SaveChanges();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
