using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormAttendanceEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrAttendance entity;

        public FormAttendanceEdit(Guid? attendanceId)
        {
            InitializeComponent();
            id = attendanceId;

            Text = id == null ? Properties.Resources.Form_AttendanceEdit_Caption_New : Properties.Resources.Form_AttendanceEdit_Caption_Edit;

            btnEmployee.ButtonClick += BtnEmployee_ButtonClick;

            dtCheckIn.EditValueChanged += CalculateMinutes;
            dtCheckOut.EditValueChanged += CalculateMinutes;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
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

        private void CalculateMinutes(object sender, EventArgs e)
        {
            if (dtCheckIn.EditValue is DateTime inTime && dtCheckOut.EditValue is DateTime outTime)
            {
                var span = outTime.TimeOfDay - inTime.TimeOfDay;
                if (span < TimeSpan.Zero)
                    span = span.Add(TimeSpan.FromDays(1));
                spMinutes.Value = (decimal)span.TotalMinutes;
            }
        }

        private void LoadEntity()
        {
            if (id == null)
            {
                entity = new TrAttendance
                {
                    Id = Guid.NewGuid(),
                    WorkDate = DateTime.Today,
                    WorkedMinutes = 0
                };
            }
            else
            {
                entity = db.TrAttendances.First(x => x.Id == id.Value);
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.CurrAccCode);
                if (emp != null)
                {
                    string name = $"{emp.FirstName} {emp.LastName}".Trim();
                    if (string.IsNullOrWhiteSpace(name))
                        name = emp.CurrAccDesc ?? string.Empty;
                    txtEmployeeName.Text = name;
                }
            }

            btnEmployee.EditValue = entity.CurrAccCode;
            dtWorkDate.DateTime = entity.WorkDate.Date;
            dtCheckIn.EditValue = entity.CheckInTime;
            dtCheckOut.EditValue = entity.CheckOutTime;
            spMinutes.Value = entity.WorkedMinutes;
        }

        private void Save()
        {
            if (btnEmployee.EditValue == null || string.IsNullOrWhiteSpace(btnEmployee.EditValue.ToString()))
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrAttendance_CurrAccCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime workDate = dtWorkDate.DateTime.Date;
            entity.CurrAccCode = btnEmployee.EditValue?.ToString();
            entity.WorkDate = workDate;

            if (dtCheckIn.EditValue is DateTime inTime)
            {
                entity.CheckInTime = workDate.AddHours(inTime.Hour).AddMinutes(inTime.Minute).AddSeconds(inTime.Second);
            }
            else
            {
                entity.CheckInTime = null;
            }

            if (dtCheckOut.EditValue is DateTime outTime)
            {
                var outDate = workDate.AddHours(outTime.Hour).AddMinutes(outTime.Minute).AddSeconds(outTime.Second);
                if (entity.CheckInTime != null && outDate < entity.CheckInTime)
                {
                    outDate = outDate.AddDays(1);
                }
                entity.CheckOutTime = outDate;
            }
            else
            {
                entity.CheckOutTime = null;
            }

            entity.WorkedMinutes = (int)spMinutes.Value;
            entity.IsManualOverride = true;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.TrAttendances.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
