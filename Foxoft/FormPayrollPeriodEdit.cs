// File: Forms/Hr/FormPayrollPeriodEdit.cs
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public class FormPayrollPeriodEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcPayrollPeriod entity;

        LayoutControl layout;
        SpinEdit spYear, spMonth;
        CheckEdit chkClosed;
        SimpleButton btnSave, btnCancel;

        public FormPayrollPeriodEdit(Guid? periodId)
        {
            id = periodId;

            Text = id == null ? "New Payroll Period" : "Edit Payroll Period";
            Width = 520;
            Height = 320;
            StartPosition = FormStartPosition.CenterParent;

            layout = new LayoutControl { Dock = DockStyle.Fill };
            layout.Root = new LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            spYear = new SpinEdit();
            spYear.Properties.MinValue = 2000;
            spYear.Properties.MaxValue = 2100;

            spMonth = new SpinEdit();
            spMonth.Properties.MinValue = 1;
            spMonth.Properties.MaxValue = 12;

            chkClosed = new CheckEdit { Text = "Closed" };

            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.AddItem("Year", spYear);
            layout.AddItem("Month", spMonth);
            layout.AddItem("", chkClosed);

            var btnGroup = layout.Root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", btnSave);
            btnGroup.AddItem("", btnCancel);

            Controls.Add(layout);
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            if (id == null)
            {
                entity = new DcPayrollPeriod
                {
                    Id = Guid.NewGuid(),
                    PeriodYear = DateTime.Today.Year,
                    PeriodMonth = DateTime.Today.Month,
                    IsClosed = false
                };
            }
            else
            {
                entity = db.DcPayrollPeriods.First(x => x.Id == id.Value);
            }

            spYear.Value = entity.PeriodYear;
            spMonth.Value = entity.PeriodMonth;
            chkClosed.Checked = entity.IsClosed;
        }

        private void Save()
        {
            entity.PeriodYear = (int)spYear.Value;
            entity.PeriodMonth = (int)spMonth.Value;
            entity.IsClosed = chkClosed.Checked;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcPayrollPeriods.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
