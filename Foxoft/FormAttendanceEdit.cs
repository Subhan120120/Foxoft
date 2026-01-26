// File: Forms/Hr/FormAttendanceEdit.cs
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public class FormAttendanceEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrAttendance entity;

        LayoutControl layout;
        LookUpEdit lkpEmployee;
        DateEdit dtWorkDate;
        DateEdit dtCheckIn;
        DateEdit dtCheckOut;
        SpinEdit spMinutes;
        SimpleButton btnSave, btnCancel;

        public FormAttendanceEdit(Guid? attendanceId)
        {
            id = attendanceId;

            Text = id == null ? "New Attendance" : "Edit Attendance";
            Width = 600;
            Height = 420;
            StartPosition = FormStartPosition.CenterParent;

            layout = new LayoutControl { Dock = DockStyle.Fill };
            layout.Root = new LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            lkpEmployee = new LookUpEdit();
            lkpEmployee.Properties.DisplayMember = "Text";
            lkpEmployee.Properties.ValueMember = "Id";
            lkpEmployee.Properties.NullText = "";
            lkpEmployee.Properties.ShowHeader = false;

            dtWorkDate = new DateEdit { Properties = { NullText = "" } };
            dtCheckIn = new DateEdit { Properties = { NullText = "" } };
            dtCheckOut = new DateEdit { Properties = { NullText = "" } };

            // time editing enabled
            dtCheckIn.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            dtCheckOut.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;

            spMinutes = new SpinEdit();
            spMinutes.Properties.MinValue = 0;
            spMinutes.Properties.MaxValue = 24 * 60;

            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.AddItem("Employee", lkpEmployee);
            layout.AddItem("Work Date", dtWorkDate);
            layout.AddItem("Check In", dtCheckIn);
            layout.AddItem("Check Out", dtCheckOut);
            layout.AddItem("Worked Minutes", spMinutes);

            var btnGroup = layout.Root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", btnSave);
            btnGroup.AddItem("", btnCancel);

            Controls.Add(layout);
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            var employees = db.DcCurrAccs.AsNoTracking()
                .Where(x => !x.IsDisabled)
                .Where(x => x.CurrAccTypeCode == 3)
                .OrderBy(x => x.CurrAccCode)
                .Select(x => new { x.CurrAccCode, Text = x.CurrAccCode + " - " + x.FirstName + " " + x.LastName })
                .ToList();

            lkpEmployee.Properties.DataSource = employees;

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
            }

            lkpEmployee.EditValue = entity.CurrAccCode;
            dtWorkDate.DateTime = entity.WorkDate.Date;
            dtCheckIn.EditValue = entity.CheckInTime;
            dtCheckOut.EditValue = entity.CheckOutTime;
            spMinutes.Value = entity.WorkedMinutes;
        }

        private void Save()
        {
            if (lkpEmployee.EditValue == null)
            {
                XtraMessageBox.Show(this, "Employee is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = lkpEmployee.EditValue?.ToString();
            entity.WorkDate = dtWorkDate.DateTime.Date;
            entity.CheckInTime = dtCheckIn.EditValue == null ? null : (DateTime?)dtCheckIn.DateTime;
            entity.CheckOutTime = dtCheckOut.EditValue == null ? null : (DateTime?)dtCheckOut.DateTime;
            entity.WorkedMinutes = (int)spMinutes.Value;

            if (entity.CheckInTime != null && entity.CheckOutTime != null && entity.CheckOutTime < entity.CheckInTime)
            {
                XtraMessageBox.Show(this, "Check Out cannot be earlier than Check In.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, "Validation",
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
