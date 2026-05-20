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
                txtEmployeeName.Text = $"{formCommonList.dcCurrAcc.FirstName} {formCommonList.dcCurrAcc.LastName}".Trim();
            }
        }

        private void CalculateMinutes(object sender, EventArgs e)
        {
            if (dtCheckIn.EditValue is DateTime inTime && dtCheckOut.EditValue is DateTime outTime)
            {
                if (outTime >= inTime)
                {
                    spMinutes.Value = (decimal)(outTime - inTime).TotalMinutes;
                }
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
                    txtEmployeeName.Text = $"{emp.FirstName} {emp.LastName}".Trim();
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

            entity.CurrAccCode = btnEmployee.EditValue?.ToString();
            entity.WorkDate = dtWorkDate.DateTime.Date;
            entity.CheckInTime = dtCheckIn.EditValue == null ? null : (DateTime?)dtCheckIn.DateTime;
            entity.CheckOutTime = dtCheckOut.EditValue == null ? null : (DateTime?)dtCheckOut.DateTime;
            entity.WorkedMinutes = (int)spMinutes.Value;

            if (entity.CheckInTime != null && entity.CheckOutTime != null && entity.CheckOutTime < entity.CheckInTime)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_CheckOutBeforeCheckIn, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
