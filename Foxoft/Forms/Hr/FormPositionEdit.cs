using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPositionEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcPosition entity = null!;

        public FormPositionEdit(Guid? positionId)
        {
            InitializeComponent();
            id = positionId;

            Text = id == null ? Properties.Resources.Form_PositionEdit_Caption_New : Properties.Resources.Form_PositionEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            var depts = db.DcDepartments.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new { x.Id, x.DepartmentCode, x.DepartmentName })
                .ToList();

            lkpDept.Properties.DataSource = depts;

            if (id == null)
            {
                entity = new DcPosition
                {
                    Id = Guid.NewGuid(),
                    IsActive = true
                };
            }
            else
            {
                entity = db.DcPositions.First(x => x.Id == id.Value);
            }

            txtCode.Text = entity.PositionCode;
            txtName.Text = entity.PositionName;
            lkpDept.EditValue = entity.DepartmentId;
            chkManager.Checked = entity.IsManagerial;
            chkActive.Checked = entity.IsActive;
        }

        private void Save()
        {
            entity.PositionCode = txtCode.Text?.Trim() ?? "";
            entity.PositionName = txtName.Text?.Trim() ?? "";
            entity.IsManagerial = chkManager.Checked;
            entity.IsActive = chkActive.Checked;

            if (lkpDept.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_DcPosition_DepartmentId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.DepartmentId = (Guid)lkpDept.EditValue;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcPositions.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
