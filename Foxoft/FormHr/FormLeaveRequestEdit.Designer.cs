namespace Foxoft
{
    partial class FormLeaveRequestEdit
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
            this.btnEmployee = new DevExpress.XtraEditors.ButtonEdit();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.lkpLeaveType = new DevExpress.XtraEditors.LookUpEdit();
            this.dtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.dtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.chkIsHourly = new DevExpress.XtraEditors.CheckEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.spTotalDays = new DevExpress.XtraEditors.SpinEdit();
            this.spTotalHours = new DevExpress.XtraEditors.SpinEdit();
            this.txtReason = new DevExpress.XtraEditors.TextEdit();
            this.cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemEmp = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemEmpName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemLeaveType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemIsHourly = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemTimeStart = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemTimeEnd = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemHours = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemReason = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpLeaveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsHourly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEmpName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLeaveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemIsHourly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTimeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnEmployee);
            this.layoutControl1.Controls.Add(this.txtEmployeeName);
            this.layoutControl1.Controls.Add(this.lkpLeaveType);
            this.layoutControl1.Controls.Add(this.dtStartDate);
            this.layoutControl1.Controls.Add(this.dtEndDate);
            this.layoutControl1.Controls.Add(this.chkIsHourly);
            this.layoutControl1.Controls.Add(this.timeStart);
            this.layoutControl1.Controls.Add(this.timeEnd);
            this.layoutControl1.Controls.Add(this.spTotalDays);
            this.layoutControl1.Controls.Add(this.spTotalHours);
            this.layoutControl1.Controls.Add(this.txtReason);
            this.layoutControl1.Controls.Add(this.cmbStatus);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroupRoot;
            this.layoutControl1.Size = new System.Drawing.Size(600, 360);
            this.layoutControl1.TabIndex = 0;
            // 
            // btnEmployee
            // 
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Properties.ReadOnly = true;
            // 
            // lkpLeaveType
            // 
            this.lkpLeaveType.Name = "lkpLeaveType";
            this.lkpLeaveType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            // 
            // dtStartDate
            // 
            this.dtStartDate.EditValue = null;
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            // 
            // dtEndDate
            // 
            this.dtEndDate.EditValue = null;
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            // 
            // chkIsHourly
            // 
            this.chkIsHourly.Name = "chkIsHourly";
            this.chkIsHourly.Properties.Caption = "Saatlıq İcazə (İş gününün bir hissəsi)";
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2026, 1, 1, 9, 0, 0, 0);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2026, 1, 1, 18, 0, 0, 0);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            // 
            // spTotalDays
            // 
            this.spTotalDays.EditValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spTotalDays.Name = "spTotalDays";
            // 
            // spTotalHours
            // 
            this.spTotalHours.EditValue = new decimal(new int[] { 8, 0, 0, 0 });
            this.spTotalHours.Name = "spTotalHours";
            // 
            // txtReason
            // 
            this.txtReason.Name = "txtReason";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.cmbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
                this.layoutItemEmp,
                this.layoutItemEmpName,
                this.layoutItemLeaveType,
                this.layoutItemStatus,
                this.layoutItemStartDate,
                this.layoutItemEndDate,
                this.layoutItemIsHourly,
                this.layoutItemTimeStart,
                this.layoutItemTimeEnd,
                this.layoutItemDays,
                this.layoutItemHours,
                this.layoutItemReason,
                this.layoutItemSave,
                this.layoutItemCancel
            });
            this.layoutControlGroupRoot.Name = "layoutControlGroupRoot";
            this.layoutControlGroupRoot.Size = new System.Drawing.Size(600, 360);
            this.layoutControlGroupRoot.TextVisible = false;
            // 
            // layoutItemEmp
            // 
            this.layoutItemEmp.Control = this.btnEmployee;
            this.layoutItemEmp.Location = new System.Drawing.Point(0, 0);
            this.layoutItemEmp.Name = "layoutItemEmp";
            this.layoutItemEmp.Size = new System.Drawing.Size(290, 24);
            this.layoutItemEmp.Text = "İşçi Kodu:";
            this.layoutItemEmp.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemEmpName
            // 
            this.layoutItemEmpName.Control = this.txtEmployeeName;
            this.layoutItemEmpName.Location = new System.Drawing.Point(290, 0);
            this.layoutItemEmpName.Name = "layoutItemEmpName";
            this.layoutItemEmpName.Size = new System.Drawing.Size(290, 24);
            this.layoutItemEmpName.Text = "İşçi Adı:";
            this.layoutItemEmpName.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemLeaveType
            // 
            this.layoutItemLeaveType.Control = this.lkpLeaveType;
            this.layoutItemLeaveType.Location = new System.Drawing.Point(0, 24);
            this.layoutItemLeaveType.Name = "layoutItemLeaveType";
            this.layoutItemLeaveType.Size = new System.Drawing.Size(290, 24);
            this.layoutItemLeaveType.Text = "İcazə Növü:";
            this.layoutItemLeaveType.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemStatus
            // 
            this.layoutItemStatus.Control = this.cmbStatus;
            this.layoutItemStatus.Location = new System.Drawing.Point(290, 24);
            this.layoutItemStatus.Name = "layoutItemStatus";
            this.layoutItemStatus.Size = new System.Drawing.Size(290, 24);
            this.layoutItemStatus.Text = "Status:";
            this.layoutItemStatus.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemStartDate
            // 
            this.layoutItemStartDate.Control = this.dtStartDate;
            this.layoutItemStartDate.Location = new System.Drawing.Point(0, 48);
            this.layoutItemStartDate.Name = "layoutItemStartDate";
            this.layoutItemStartDate.Size = new System.Drawing.Size(290, 24);
            this.layoutItemStartDate.Text = "Başlanğıc Tarixi:";
            this.layoutItemStartDate.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemEndDate
            // 
            this.layoutItemEndDate.Control = this.dtEndDate;
            this.layoutItemEndDate.Location = new System.Drawing.Point(290, 48);
            this.layoutItemEndDate.Name = "layoutItemEndDate";
            this.layoutItemEndDate.Size = new System.Drawing.Size(290, 24);
            this.layoutItemEndDate.Text = "Bitmə Tarixi:";
            this.layoutItemEndDate.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemIsHourly
            // 
            this.layoutItemIsHourly.Control = this.chkIsHourly;
            this.layoutItemIsHourly.Location = new System.Drawing.Point(0, 72);
            this.layoutItemIsHourly.Name = "layoutItemIsHourly";
            this.layoutItemIsHourly.Size = new System.Drawing.Size(580, 24);
            this.layoutItemIsHourly.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemIsHourly.TextVisible = false;
            // 
            // layoutItemTimeStart
            // 
            this.layoutItemTimeStart.Control = this.timeStart;
            this.layoutItemTimeStart.Location = new System.Drawing.Point(0, 96);
            this.layoutItemTimeStart.Name = "layoutItemTimeStart";
            this.layoutItemTimeStart.Size = new System.Drawing.Size(290, 24);
            this.layoutItemTimeStart.Text = "Başlama Saatı:";
            this.layoutItemTimeStart.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemTimeEnd
            // 
            this.layoutItemTimeEnd.Control = this.timeEnd;
            this.layoutItemTimeEnd.Location = new System.Drawing.Point(290, 96);
            this.layoutItemTimeEnd.Name = "layoutItemTimeEnd";
            this.layoutItemTimeEnd.Size = new System.Drawing.Size(290, 24);
            this.layoutItemTimeEnd.Text = "Bitmə Saatı:";
            this.layoutItemTimeEnd.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemDays
            // 
            this.layoutItemDays.Control = this.spTotalDays;
            this.layoutItemDays.Location = new System.Drawing.Point(0, 120);
            this.layoutItemDays.Name = "layoutItemDays";
            this.layoutItemDays.Size = new System.Drawing.Size(290, 24);
            this.layoutItemDays.Text = "Toplam Gün:";
            this.layoutItemDays.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemHours
            // 
            this.layoutItemHours.Control = this.spTotalHours;
            this.layoutItemHours.Location = new System.Drawing.Point(290, 120);
            this.layoutItemHours.Name = "layoutItemHours";
            this.layoutItemHours.Size = new System.Drawing.Size(290, 24);
            this.layoutItemHours.Text = "Toplam Saat:";
            this.layoutItemHours.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemReason
            // 
            this.layoutItemReason.Control = this.txtReason;
            this.layoutItemReason.Location = new System.Drawing.Point(0, 144);
            this.layoutItemReason.Name = "layoutItemReason";
            this.layoutItemReason.Size = new System.Drawing.Size(580, 150);
            this.layoutItemReason.Text = "Səbəb / Qeyd:";
            this.layoutItemReason.TextSize = new System.Drawing.Size(100, 13);
            // 
            // layoutItemSave
            // 
            this.layoutItemSave.Control = this.btnSave;
            this.layoutItemSave.Location = new System.Drawing.Point(0, 294);
            this.layoutItemSave.Name = "layoutItemSave";
            this.layoutItemSave.Size = new System.Drawing.Size(290, 46);
            this.layoutItemSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemSave.TextVisible = false;
            // 
            // layoutItemCancel
            // 
            this.layoutItemCancel.Control = this.btnCancel;
            this.layoutItemCancel.Location = new System.Drawing.Point(290, 294);
            this.layoutItemCancel.Name = "layoutItemCancel";
            this.layoutItemCancel.Size = new System.Drawing.Size(290, 46);
            this.layoutItemCancel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemCancel.TextVisible = false;
            // 
            // FormLeaveRequestEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormLeaveRequestEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_LeaveRequest_Caption_New;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpLeaveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsHourly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTotalHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEmpName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemLeaveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemIsHourly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTimeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemCancel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        private DevExpress.XtraEditors.ButtonEdit btnEmployee;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.LookUpEdit lkpLeaveType;
        private DevExpress.XtraEditors.DateEdit dtStartDate;
        private DevExpress.XtraEditors.DateEdit dtEndDate;
        private DevExpress.XtraEditors.CheckEdit chkIsHourly;
        private DevExpress.XtraEditors.TimeEdit timeStart;
        private DevExpress.XtraEditors.TimeEdit timeEnd;
        private DevExpress.XtraEditors.SpinEdit spTotalDays;
        private DevExpress.XtraEditors.SpinEdit spTotalHours;
        private DevExpress.XtraEditors.TextEdit txtReason;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatus;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemEmp;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemEmpName;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemLeaveType;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemStartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemEndDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemIsHourly;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemTimeStart;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemTimeEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemHours;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemReason;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemCancel;
    }
}
