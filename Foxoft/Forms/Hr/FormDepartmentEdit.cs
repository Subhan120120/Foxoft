using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormDepartmentEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcDepartment entity = null!;

        public FormDepartmentEdit(Guid? departmentId)
        {
            InitializeComponent();
            id = departmentId;

            Text = id == null ? Properties.Resources.Form_DepartmentEdit_Caption_New : Properties.Resources.Form_DepartmentEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            var parents = db.DcDepartments.AsNoTracking()
                .OrderBy(x => x.DepartmentName)
                .Select(x => new { x.Id, x.DepartmentCode, x.DepartmentName })
                .ToList();

            if (id == null)
            {
                entity = new DcDepartment
                {
                    Id = Guid.NewGuid(),
                    IsActive = true
                };
            }
            else
            {
                entity = db.DcDepartments.First(x => x.Id == id.Value);
                parents = parents.Where(x => x.Id != entity.Id).ToList();
            }

            lkpParent.Properties.DataSource = parents;

            txtCode.Text = entity.DepartmentCode;
            txtName.Text = entity.DepartmentName;
            lkpParent.EditValue = entity.ParentDepartmentId;
            chkActive.Checked = entity.IsActive;
        }

        private void Save()
        {
            entity.DepartmentCode = txtCode.Text?.Trim() ?? "";
            entity.DepartmentName = txtName.Text?.Trim() ?? "";
            entity.ParentDepartmentId = (Guid?)lkpParent.EditValue;
            entity.IsActive = chkActive.Checked;

            if (entity.ParentDepartmentId == entity.Id)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_ParentDepartmentSelf, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcDepartments.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
