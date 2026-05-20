using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormEmploymentTypeEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcEmploymentType entity;

        public FormEmploymentTypeEdit(Guid? employmentTypeId)
        {
            InitializeComponent();
            id = employmentTypeId;

            Text = id == null ? Properties.Resources.Form_EmploymentTypeEdit_Caption_New : Properties.Resources.Form_EmploymentTypeEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            if (id == null)
            {
                entity = new DcEmploymentType { Id = Guid.NewGuid(), IsActive = true };
            }
            else
            {
                entity = db.DcEmploymentTypes.First(x => x.Id == id.Value);
            }

            txtCode.Text = entity.TypeCode;
            txtName.Text = entity.TypeName;
            chkActive.Checked = entity.IsActive;
        }

        private void Save()
        {
            entity.TypeCode = txtCode.Text?.Trim() ?? "";
            entity.TypeName = txtName.Text?.Trim() ?? "";
            entity.IsActive = chkActive.Checked;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcEmploymentTypes.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
