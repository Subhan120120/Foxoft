using DevExpress.XtraEditors;

namespace Foxoft
{
    partial class FormEmployeePositionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeePositionEdit));
            layout = new DevExpress.XtraLayout.LayoutControl();
            btnEmployee = new ButtonEdit();
            txtEmployeeName = new TextEdit();
            lkpPosition = new LookUpEdit();
            dtStart = new DateEdit();
            dtEnd = new DateEdit();
            btnSave = new SimpleButton();
            btnCancel = new SimpleButton();
            root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layout).BeginInit();
            layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnEmployee.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployeeName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkpPosition.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtEnd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtEnd.Properties.CalendarTimeProperties).BeginInit();
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
            layout.Controls.Add(btnEmployee);
            layout.Controls.Add(txtEmployeeName);
            layout.Controls.Add(lkpPosition);
            layout.Controls.Add(dtStart);
            layout.Controls.Add(dtEnd);
            layout.Controls.Add(btnSave);
            layout.Controls.Add(btnCancel);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(731, 161, 650, 400);
            layout.Root = root;
            layout.Size = new Size(560, 219);
            layout.TabIndex = 0;
            // 
            // btnEmployee
            // 
            btnEmployee.Location = new Point(100, 33);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            btnEmployee.Size = new Size(448, 20);
            btnEmployee.StyleController = layout;
            btnEmployee.TabIndex = 4;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(100, 57);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Properties.ReadOnly = true;
            txtEmployeeName.Size = new Size(448, 20);
            txtEmployeeName.StyleController = layout;
            txtEmployeeName.TabIndex = 5;
            // 
            // lkpPosition
            // 
            lkpPosition.Location = new Point(100, 81);
            lkpPosition.Name = "lkpPosition";
            lkpPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkpPosition.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionCode", Properties.Resources.Entity_DcPosition_PositionCode), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PositionName", Properties.Resources.Entity_DcPosition_PositionName), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", Properties.Resources.Entity_DcDepartment_DepartmentName) });
            lkpPosition.Properties.DisplayMember = "PositionName";
            lkpPosition.Properties.NullText = "";
            lkpPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            lkpPosition.Properties.ValueMember = "Id";
            lkpPosition.Size = new Size(448, 20);
            lkpPosition.StyleController = layout;
            lkpPosition.TabIndex = 6;
            // 
            // dtStart
            // 
            dtStart.EditValue = new DateTime(2026, 5, 19, 0, 0, 0, 0);
            dtStart.Location = new Point(100, 105);
            dtStart.Name = "dtStart";
            dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtStart.Size = new Size(448, 20);
            dtStart.StyleController = layout;
            dtStart.TabIndex = 7;
            // 
            // dtEnd
            // 
            dtEnd.EditValue = new DateTime(2026, 5, 19, 0, 0, 0, 0);
            dtEnd.Location = new Point(100, 129);
            dtEnd.Name = "dtEnd";
            dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtEnd.Size = new Size(448, 20);
            dtEnd.StyleController = layout;
            dtEnd.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.ImageOptions.Location = ImageLocation.MiddleCenter;
            btnSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSave.ImageOptions.SvgImage");
            btnSave.Location = new Point(282, 153);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(266, 54);
            btnSave.StyleController = layout;
            btnSave.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.ImageOptions.Location = ImageLocation.MiddleCenter;
            btnCancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancel.ImageOptions.SvgImage");
            btnCancel.Location = new Point(12, 153);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(266, 54);
            btnCancel.StyleController = layout;
            btnCancel.TabIndex = 0;
            // 
            // root
            // 
            root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7 });
            root.Name = "Root";
            root.Size = new Size(560, 219);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnEmployee;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(540, 24);
            layoutControlItem1.Text = Properties.Resources.Entity_TrEmployeePosition_CurrAccCode;
            layoutControlItem1.TextSize = new Size(76, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtEmployeeName;
            layoutControlItem2.Location = new Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(540, 24);
            layoutControlItem2.Text = Properties.Resources.Common_EmployeeName;
            layoutControlItem2.TextSize = new Size(76, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = lkpPosition;
            layoutControlItem3.Location = new Point(0, 48);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(540, 24);
            layoutControlItem3.Text = Properties.Resources.Entity_TrEmployeePosition_PositionId;
            layoutControlItem3.TextSize = new Size(76, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = dtStart;
            layoutControlItem4.Location = new Point(0, 72);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(540, 24);
            layoutControlItem4.Text = Properties.Resources.Entity_TrEmployeePosition_StartDate;
            layoutControlItem4.TextSize = new Size(76, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = dtEnd;
            layoutControlItem5.Location = new Point(0, 96);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(540, 24);
            layoutControlItem5.Text = Properties.Resources.Entity_TrEmployeePosition_EndDate;
            layoutControlItem5.TextSize = new Size(76, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = btnSave;
            layoutControlItem6.Location = new Point(270, 120);
            layoutControlItem6.MinSize = new Size(35, 26);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(270, 58);
            layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = btnCancel;
            layoutControlItem7.Location = new Point(0, 120);
            layoutControlItem7.MinSize = new Size(43, 26);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new Size(270, 58);
            layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem7.TextVisible = false;
            // 
            // FormEmployeePositionEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 219);
            Controls.Add(layout);
            Name = "FormEmployeePositionEdit";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)layout).EndInit();
            layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnEmployee.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployeeName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkpPosition.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtStart.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtEnd.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtEnd.Properties).EndInit();
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
        private DevExpress.XtraEditors.ButtonEdit btnEmployee;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.LookUpEdit lkpPosition;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
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
