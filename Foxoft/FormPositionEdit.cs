// File: Forms/Hr/FormPositionEdit.cs
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
    public class FormPositionEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcPosition entity = null!;

        private LayoutControl layout = null!;
        private TextEdit txtCode = null!;
        private TextEdit txtName = null!;
        private LookUpEdit lkpDept = null!;
        private CheckEdit chkManager = null!;
        private CheckEdit chkActive = null!;
        private SimpleButton btnSave = null!;
        private SimpleButton btnCancel = null!;

        public FormPositionEdit(Guid? positionId)
        {
            id = positionId;

            Text = id == null ? "New Position" : "Edit Position";
            Width = 520;
            Height = 340;
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

            lkpDept = new LookUpEdit();
            lkpDept.Properties.DisplayMember = "DepartmentName";
            lkpDept.Properties.ValueMember = "Id";
            lkpDept.Properties.NullText = "";
            lkpDept.Properties.ShowHeader = false;

            chkManager = new CheckEdit { Text = "Managerial" };
            chkActive = new CheckEdit { Text = "Active" };

            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            layout.Root = root;
            layout.AddItem("Position Code", txtCode);
            layout.AddItem("Position Name", txtName);
            layout.AddItem("Department", lkpDept);
            layout.AddItem("", chkManager);
            layout.AddItem("", chkActive);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", btnSave);
            btnGroup.AddItem("", btnCancel);

            Controls.Add(layout);
        }

        private void LoadEntity()
        {
            var depts = db.DcDepartments.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new { x.Id, x.DepartmentName })
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
                XtraMessageBox.Show(this, "Department is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.DepartmentId = (Guid)lkpDept.EditValue;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcPositions.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
