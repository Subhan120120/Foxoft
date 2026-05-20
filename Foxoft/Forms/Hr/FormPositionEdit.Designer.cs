namespace Foxoft
{
    partial class FormPositionEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPositionEdit));
            layout = new DevExpress.XtraLayout.LayoutControl();
            txtCode = new DevExpress.XtraEditors.TextEdit();
            txtName = new DevExpress.XtraEditors.TextEdit();
            lkpDept = new DevExpress.XtraEditors.LookUpEdit();
            chkManager = new DevExpress.XtraEditors.CheckEdit();
            chkActive = new DevExpress.XtraEditors.CheckEdit();
            root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)layout).BeginInit();
            layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkpDept.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkManager.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            SuspendLayout();
            // 
            // layout
            // 
            layout.Controls.Add(txtCode);
            layout.Controls.Add(txtName);
            layout.Controls.Add(lkpDept);
            layout.Controls.Add(chkManager);
            layout.Controls.Add(chkActive);
            layout.Controls.Add(btnCancel);
            layout.Controls.Add(btnSave);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(568, 79, 650, 400);
            layout.Root = root;
            layout.Size = new Size(520, 217);
            layout.TabIndex = 0;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(91, 33);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(417, 20);
            txtCode.StyleController = layout;
            txtCode.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(91, 57);
            txtName.Name = "txtName";
            txtName.Size = new Size(417, 20);
            txtName.StyleController = layout;
            txtName.TabIndex = 5;
            // 
            // lkpDept
            // 
            lkpDept.Location = new Point(91, 81);
            lkpDept.Name = "lkpDept";
            lkpDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpDept.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentCode", Properties.Resources.Entity_DcDepartment_DepartmentCode), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", Properties.Resources.Entity_DcDepartment_DepartmentName) });
            lkpDept.Properties.DisplayMember = "DepartmentName";
            lkpDept.Properties.NullText = "";
            lkpDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkpDept.Properties.ValueMember = "Id";
            lkpDept.Size = new Size(417, 20);
            lkpDept.StyleController = layout;
            lkpDept.TabIndex = 6;
            // 
            // chkManager
            // 
            chkManager.Location = new Point(12, 105);
            chkManager.Name = "chkManager";
            chkManager.Properties.Caption = Properties.Resources.Entity_DcPosition_IsManagerial;
            chkManager.Size = new Size(496, 20);
            chkManager.StyleController = layout;
            chkManager.TabIndex = 7;
            // 
            // chkActive
            // 
            chkActive.Location = new Point(12, 129);
            chkActive.Name = "chkActive";
            chkActive.Properties.Caption = Properties.Resources.Entity_DcPosition_IsActive;
            chkActive.Size = new Size(496, 20);
            chkActive.StyleController = layout;
            chkActive.TabIndex = 8;
            // 
            // root
            // 
            root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7 });
            root.Name = "Root";
            root.Size = new Size(520, 217);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtCode;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(500, 24);
            layoutControlItem1.Text = Properties.Resources.Entity_DcPosition_PositionCode;
            layoutControlItem1.TextSize = new Size(67, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtName;
            layoutControlItem2.Location = new Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(500, 24);
            layoutControlItem2.Text = Properties.Resources.Entity_DcPosition_PositionName;
            layoutControlItem2.TextSize = new Size(67, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = lkpDept;
            layoutControlItem3.Location = new Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(500, 24);
            layoutControlItem3.Text = Properties.Resources.Entity_DcPosition_DepartmentId;
            layoutControlItem3.TextSize = new Size(67, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = chkManager;
            layoutControlItem4.Location = new Point(0, 72);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(500, 24);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = chkActive;
            layoutControlItem5.Location = new Point(0, 96);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(500, 24);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = btnCancel;
            layoutControlItem6.Location = new Point(0, 120);
            layoutControlItem6.MinSize = new Size(43, 26);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(250, 56);
            layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem6.TextVisible = false;
            // 
            // btnCancel
            // 
            btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btnCancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancel.ImageOptions.SvgImage");
            btnCancel.Location = new Point(12, 153);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(246, 52);
            btnCancel.StyleController = layout;
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = btnSave;
            layoutControlItem7.Location = new Point(250, 120);
            layoutControlItem7.MinSize = new Size(35, 26);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(250, 56);
            layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem7.TextVisible = false;
            // 
            // btnSave
            // 
            btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btnSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSave.ImageOptions.SvgImage");
            btnSave.Location = new Point(262, 153);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(246, 52);
            btnSave.StyleController = layout;
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            // 
            // FormPositionEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 217);
            Controls.Add(layout);
            Name = "FormPositionEdit";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)layout).EndInit();
            layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkpDept.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkManager.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LookUpEdit lkpDept;
        private DevExpress.XtraEditors.CheckEdit chkManager;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlGroup root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
