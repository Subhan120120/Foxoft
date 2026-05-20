using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormEmployeePositionEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrEmployeePosition entity;

        public FormEmployeePositionEdit(Guid? employeePositionId)
        {
            InitializeComponent();
            id = employeePositionId;

            Text = id == null ? Properties.Resources.Form_EmployeePositionEdit_Caption_New : Properties.Resources.Form_EmployeePositionEdit_Caption_Edit;

            btnEmployee.ButtonClick += BtnEmployee_ButtonClick;

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

        private void LoadEntity()
        {
            var positions = db.DcPositions.AsNoTracking()
                .Include(x => x.Department)
                .Where(x => x.IsActive)
                .OrderBy(x => x.PositionCode)
                .Select(x => new 
                { 
                    x.Id, 
                    x.PositionCode, 
                    x.PositionName, 
                    DepartmentName = x.Department != null ? x.Department.DepartmentName : "" 
                })
                .ToList();

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
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.CurrAccCode);
                if (emp != null)
                {
                    txtEmployeeName.Text = $"{emp.FirstName} {emp.LastName}".Trim();
                }
            }

            btnEmployee.EditValue = entity.CurrAccCode;
            lkpPosition.EditValue = entity.PositionId;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;
        }

        private void Save()
        {
            if (btnEmployee.EditValue == null || string.IsNullOrWhiteSpace(btnEmployee.EditValue.ToString()))
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrEmployeePosition_CurrAccCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkpPosition.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrEmployeePosition_PositionId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = btnEmployee.EditValue?.ToString();
            entity.PositionId = (Guid)lkpPosition.EditValue;
            entity.StartDate = dtStart.DateTime.Date;
            entity.EndDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;

            if (entity.EndDate != null && entity.EndDate < entity.StartDate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_EndDateBeforeStartDate, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention,
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
