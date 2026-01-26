// File: Forms/Hr/FormEmployeePositionEdit.cs
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
    public class FormEmployeePositionEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrEmployeePosition entity;

        LayoutControl layout;
        LookUpEdit lkpEmployee, lkpPosition;
        DateEdit dtStart, dtEnd;
        SimpleButton btnSave, btnCancel;

        public FormEmployeePositionEdit(Guid? employeePositionId)
        {
            id = employeePositionId;

            Text = id == null ? "New Employee Position" : "Edit Employee Position";
            Width = 560;
            Height = 360;
            StartPosition = FormStartPosition.CenterParent;

            layout = new LayoutControl { Dock = DockStyle.Fill };
            layout.Root = new LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            lkpEmployee = new LookUpEdit();
            lkpEmployee.Properties.DisplayMember = "Text";
            lkpEmployee.Properties.ValueMember = "Id";
            lkpEmployee.Properties.NullText = "";
            lkpEmployee.Properties.ShowHeader = false;

            lkpPosition = new LookUpEdit();
            lkpPosition.Properties.DisplayMember = "Text";
            lkpPosition.Properties.ValueMember = "Id";
            lkpPosition.Properties.NullText = "";
            lkpPosition.Properties.ShowHeader = false;

            dtStart = new DateEdit { Properties = { NullText = "" } };
            dtEnd = new DateEdit { Properties = { NullText = "" } };

            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.AddItem("Employee", lkpEmployee);
            layout.AddItem("Position", lkpPosition);
            layout.AddItem("Start Date", dtStart);
            layout.AddItem("End Date", dtEnd);

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

            var positions = db.DcPositions.AsNoTracking()
                .Include(x => x.Department)
                .Where(x => x.IsActive)
                .OrderBy(x => x.PositionCode)
                .Select(x => new { x.Id, Text = x.Department.DepartmentName + " / " + x.PositionName })
                .ToList();

            lkpEmployee.Properties.DataSource = employees;
            lkpPosition.Properties.DataSource = positions;

            if (id == null)
            {
                entity = new TrEmployeePosition
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Today
                };
            }
            else
            {
                entity = db.TrEmployeePositions.First(x => x.Id == id.Value);
            }

            lkpEmployee.EditValue = entity.CurrAccCode;
            lkpPosition.EditValue = entity.PositionId;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;
        }

        private void Save()
        {
            if (lkpEmployee.EditValue == null)
            {
                XtraMessageBox.Show(this, "Employee is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkpPosition.EditValue == null)
            {
                XtraMessageBox.Show(this, "Position is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = lkpEmployee.EditValue?.ToString();
            entity.PositionId = (Guid)lkpPosition.EditValue;
            entity.StartDate = dtStart.DateTime.Date;
            entity.EndDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;

            if (entity.EndDate != null && entity.EndDate < entity.StartDate)
            {
                XtraMessageBox.Show(this, "End Date cannot be earlier than Start Date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.TrEmployeePositions.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
