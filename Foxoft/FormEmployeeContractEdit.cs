// File: Forms/Hr/FormEmployeeContractEdit.cs
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
    public class FormEmployeeContractEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrEmployeeContract entity;

        LayoutControl layout;
        LookUpEdit lkpEmployee, lkpType;
        DateEdit dtStart, dtEnd;
        CalcEdit calcSalary;
        TextEdit txtCurrency;
        SimpleButton btnSave, btnCancel;

        public FormEmployeeContractEdit(Guid? contractId)
        {
            id = contractId;

            Text = id == null ? "New Contract" : "Edit Contract";
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

            lkpType = new LookUpEdit();
            lkpType.Properties.DisplayMember = "TypeName";
            lkpType.Properties.ValueMember = "Id";
            lkpType.Properties.NullText = "";
            lkpType.Properties.ShowHeader = false;

            dtStart = new DateEdit { Properties = { NullText = "" } };
            dtEnd = new DateEdit { Properties = { NullText = "" } };
            calcSalary = new CalcEdit();
            txtCurrency = new TextEdit();

            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.AddItem("Employee", lkpEmployee);
            layout.AddItem("Employment Type", lkpType);
            layout.AddItem("Start Date", dtStart);
            layout.AddItem("End Date", dtEnd);
            layout.AddItem("Base Salary", calcSalary);
            layout.AddItem("Currency Code", txtCurrency);

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

            var types = db.DcEmploymentTypes.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.TypeCode)
                .Select(x => new { x.Id, x.TypeName })
                .ToList();

            lkpEmployee.Properties.DataSource = employees;
            lkpType.Properties.DataSource = types;

            if (id == null)
            {
                entity = new TrEmployeeContract
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Today,
                    BaseSalary = 0
                };
            }
            else
            {
                entity = db.TrEmployeeContracts.First(x => x.Id == id.Value);
            }

            lkpEmployee.EditValue = entity.CurrAccCode;
            lkpType.EditValue = entity.EmploymentTypeId;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;
            calcSalary.EditValue = entity.BaseSalary;
            txtCurrency.Text = entity.CurrencyCode;
        }

        private void Save()
        {
            if (lkpEmployee.EditValue == null)
            {
                XtraMessageBox.Show(this, "Employee is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkpType.EditValue == null)
            {
                XtraMessageBox.Show(this, "Employment Type is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = lkpEmployee.EditValue?.ToString();
            entity.EmploymentTypeId = (Guid)lkpType.EditValue;
            entity.StartDate = dtStart.DateTime.Date;
            entity.EndDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;
            entity.BaseSalary = calcSalary.Value;
            entity.CurrencyCode = string.IsNullOrWhiteSpace(txtCurrency.Text) ? null : txtCurrency.Text.Trim().ToUpperInvariant();

            if (entity.CurrencyCode != null && entity.CurrencyCode.Length > 3)
            {
                XtraMessageBox.Show(this, "Currency Code max length is 3 (e.g. AZN).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            if (id == null) db.TrEmployeeContracts.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
