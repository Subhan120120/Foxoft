// File: Forms/Hr/FormEmploymentTypeEdit.cs
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public class FormEmploymentTypeEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcEmploymentType entity;

        LayoutControl layout;
        TextEdit txtCode, txtName;
        CheckEdit chkActive;
        SimpleButton btnSave, btnCancel;

        public FormEmploymentTypeEdit(Guid? employmentTypeId)
        {
            id = employmentTypeId;

            Text = id == null ? "New Employment Type" : "Edit Employment Type";
            Width = 520;
            Height = 300;
            StartPosition = FormStartPosition.CenterParent;

            layout = new LayoutControl { Dock = DockStyle.Fill };
            layout.Root = new LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            txtCode = new TextEdit();
            txtName = new TextEdit();
            chkActive = new CheckEdit { Text = "Active" };

            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.AddItem("Type Code", txtCode);
            layout.AddItem("Type Name", txtName);
            layout.AddItem("", chkActive);

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
                XtraMessageBox.Show(this, msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcEmploymentTypes.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
