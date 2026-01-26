// File: Forms/Hr/FormDepartmentEdit.cs
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
    public class FormDepartmentEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcDepartment entity = null!;

        private LayoutControl layout = null!;
        private TextEdit txtCode = null!;
        private TextEdit txtName = null!;
        private LookUpEdit lkpParent = null!;
        private CheckEdit chkActive = null!;
        private SimpleButton btnSave = null!;
        private SimpleButton btnCancel = null!;

        public FormDepartmentEdit(Guid? departmentId)
        {
            id = departmentId;

            Text = id == null ? "New Department" : "Edit Department";
            Width = 520;
            Height = 320;
            StartPosition = FormStartPosition.CenterParent;

            BuildUi();
            Load += (_, __) => LoadEntity();
        }

        private void BuildUi()
        {
            layout = new LayoutControl { Dock = DockStyle.Fill };
            var root = new LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            txtCode = new TextEdit();
            txtName = new TextEdit();

            lkpParent = new LookUpEdit();
            lkpParent.Properties.DisplayMember = "DepartmentName";
            lkpParent.Properties.ValueMember = "Id";
            lkpParent.Properties.NullText = "";
            lkpParent.Properties.ShowHeader = false;

            chkActive = new CheckEdit { Text = "Active" };
            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.Root = root;
            layout.AddItem("Department Code", txtCode);
            layout.AddItem("Department Name", txtName);
            layout.AddItem("Parent Department", lkpParent);
            layout.AddItem("", chkActive);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", btnSave);
            btnGroup.AddItem("", btnCancel);

            Controls.Add(layout);
        }

        private void LoadEntity()
        {
            // parent lookup (exclude self later)
            var parents = db.DcDepartments.AsNoTracking()
                .OrderBy(x => x.DepartmentName)
                .Select(x => new { x.Id, x.DepartmentName })
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
                XtraMessageBox.Show(this, "Parent department cannot be itself.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcDepartments.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
