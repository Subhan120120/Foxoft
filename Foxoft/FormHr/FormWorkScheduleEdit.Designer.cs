namespace Foxoft
{
    partial class FormWorkScheduleEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtScheduleCode = new DevExpress.XtraEditors.TextEdit();
            this.txtScheduleName = new DevExpress.XtraEditors.TextEdit();
            this.cmbScheduleType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spWeeklyHours = new DevExpress.XtraEditors.SpinEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.gridControlDays = new DevExpress.XtraGrid.GridControl();
            this.gridViewDays = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemHours = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbScheduleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spWeeklyHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtScheduleCode);
            this.layoutControl1.Controls.Add(this.txtScheduleName);
            this.layoutControl1.Controls.Add(this.cmbScheduleType);
            this.layoutControl1.Controls.Add(this.spWeeklyHours);
            this.layoutControl1.Controls.Add(this.chkIsActive);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.gridControlDays);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroupRoot;
            this.layoutControl1.Size = new System.Drawing.Size(780, 500);
            this.layoutControl1.TabIndex = 0;
            // 
            // txtScheduleCode
            // 
            this.txtScheduleCode.Name = "txtScheduleCode";
            // 
            // txtScheduleName
            // 
            this.txtScheduleName.Name = "txtScheduleName";
            // 
            // cmbScheduleType
            // 
            this.cmbScheduleType.Name = "cmbScheduleType";
            this.cmbScheduleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.cmbScheduleType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // spWeeklyHours
            // 
            this.spWeeklyHours.EditValue = new decimal(new int[] { 40, 0, 0, 0 });
            this.spWeeklyHours.Name = "spWeeklyHours";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Aktivdir";
            // 
            // txtDescription
            // 
            this.txtDescription.Name = "txtDescription";
            // 
            // gridControlDays
            // 
            this.gridControlDays.Location = new System.Drawing.Point(12, 108);
            this.gridControlDays.MainView = this.gridViewDays;
            this.gridControlDays.Name = "gridControlDays";
            this.gridControlDays.Size = new System.Drawing.Size(756, 342);
            this.gridControlDays.TabIndex = 6;
            this.gridControlDays.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewDays
            });
            // 
            // gridViewDays
            // 
            this.gridViewDays.GridControl = this.gridControlDays;
            this.gridViewDays.Name = "gridViewDays";
            this.gridViewDays.OptionsView.ShowGroupPanel = false;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            // 
            // btnCancel
            // 
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;
            // 
            // layoutControlGroupRoot
            // 
            this.layoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupRoot.GroupBordersVisible = false;
            this.layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemCode,
                this.layoutItemName,
                this.layoutItemType,
                this.layoutItemHours,
                this.layoutItemActive,
                this.layoutItemDesc,
                this.layoutItemDays,
                this.layoutItemSave,
                this.layoutItemCancel
            });
            this.layoutControlGroupRoot.Name = "layoutControlGroupRoot";
            this.layoutControlGroupRoot.Size = new System.Drawing.Size(780, 500);
            this.layoutControlGroupRoot.TextVisible = false;
            // 
            // layoutItemCode
            // 
            this.layoutItemCode.Control = this.txtScheduleCode;
            this.layoutItemCode.Location = new System.Drawing.Point(0, 0);
            this.layoutItemCode.Name = "layoutItemCode";
            this.layoutItemCode.Size = new System.Drawing.Size(380, 24);
            this.layoutItemCode.Text = "Qrafik Kodu:";
            this.layoutItemCode.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemName
            // 
            this.layoutItemName.Control = this.txtScheduleName;
            this.layoutItemName.Location = new System.Drawing.Point(380, 0);
            this.layoutItemName.Name = "layoutItemName";
            this.layoutItemName.Size = new System.Drawing.Size(380, 24);
            this.layoutItemName.Text = "Qrafik Adı:";
            this.layoutItemName.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemType
            // 
            this.layoutItemType.Control = this.cmbScheduleType;
            this.layoutItemType.Location = new System.Drawing.Point(0, 24);
            this.layoutItemType.Name = "layoutItemType";
            this.layoutItemType.Size = new System.Drawing.Size(380, 24);
            this.layoutItemType.Text = "Rejim Növü:";
            this.layoutItemType.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemHours
            // 
            this.layoutItemHours.Control = this.spWeeklyHours;
            this.layoutItemHours.Location = new System.Drawing.Point(380, 24);
            this.layoutItemHours.Name = "layoutItemHours";
            this.layoutItemHours.Size = new System.Drawing.Size(380, 24);
            this.layoutItemHours.Text = "Həftəlik Saat:";
            this.layoutItemHours.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemDesc
            // 
            this.layoutItemDesc.Control = this.txtDescription;
            this.layoutItemDesc.Location = new System.Drawing.Point(0, 48);
            this.layoutItemDesc.Name = "layoutItemDesc";
            this.layoutItemDesc.Size = new System.Drawing.Size(580, 24);
            this.layoutItemDesc.Text = Foxoft.Properties.Resources.Common_Note + ":";
            this.layoutItemDesc.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemActive
            // 
            this.layoutItemActive.Control = this.chkIsActive;
            this.layoutItemActive.Location = new System.Drawing.Point(580, 48);
            this.layoutItemActive.Name = "layoutItemActive";
            this.layoutItemActive.Size = new System.Drawing.Size(180, 24);
            this.layoutItemActive.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemActive.TextVisible = false;
            // 
            // layoutItemDays
            // 
            this.layoutItemDays.Control = this.gridControlDays;
            this.layoutItemDays.Location = new System.Drawing.Point(0, 72);
            this.layoutItemDays.Name = "layoutItemDays";
            this.layoutItemDays.Size = new System.Drawing.Size(760, 370);
            this.layoutItemDays.Text = "Həftənin Günləri:";
            this.layoutItemDays.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutItemDays.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemSave
            // 
            this.layoutItemSave.Control = this.btnSave;
            this.layoutItemSave.Location = new System.Drawing.Point(0, 442);
            this.layoutItemSave.Name = "layoutItemSave";
            this.layoutItemSave.Size = new System.Drawing.Size(380, 38);
            this.layoutItemSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemSave.TextVisible = false;
            // 
            // layoutItemCancel
            // 
            this.layoutItemCancel.Control = this.btnCancel;
            this.layoutItemCancel.Location = new System.Drawing.Point(380, 442);
            this.layoutItemCancel.Name = "layoutItemCancel";
            this.layoutItemCancel.Size = new System.Drawing.Size(380, 38);
            this.layoutItemCancel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemCancel.TextVisible = false;
            // 
            // FormWorkScheduleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 500);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormWorkScheduleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_WorkSchedule_Caption_New;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbScheduleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spWeeklyHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCancel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        private DevExpress.XtraEditors.TextEdit txtScheduleCode;
        private DevExpress.XtraEditors.TextEdit txtScheduleName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbScheduleType;
        private DevExpress.XtraEditors.SpinEdit spWeeklyHours;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraGrid.GridControl gridControlDays;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDays;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemName;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemType;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemHours;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemCancel;
    }
}
