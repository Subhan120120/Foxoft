namespace Foxoft
{
    partial class FormAttendanceEdit
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
            this.layout = new DevExpress.XtraLayout.LayoutControl();
            this.btnEmployee = new DevExpress.XtraEditors.ButtonEdit();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.dtWorkDate = new DevExpress.XtraEditors.DateEdit();
            this.dtCheckIn = new DevExpress.XtraEditors.DateEdit();
            this.dtCheckOut = new DevExpress.XtraEditors.DateEdit();
            this.spMinutes = new DevExpress.XtraEditors.SpinEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtWorkDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtWorkDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckIn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckOut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinutes.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.btnEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            this.txtEmployeeName.Properties.ReadOnly = true;

            this.dtWorkDate.Properties.NullText = "";
            this.dtWorkDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtWorkDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.dtCheckIn.Properties.NullText = "";
            this.dtCheckIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtCheckIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.dtCheckOut.Properties.NullText = "";
            this.dtCheckOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtCheckOut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.dtCheckIn.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dtCheckOut.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;

            this.dtCheckIn.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtCheckIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCheckIn.Properties.EditFormat.FormatString = "HH:mm";
            this.dtCheckIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCheckIn.Properties.EditMask = "HH:mm";

            this.dtCheckOut.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtCheckOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCheckOut.Properties.EditFormat.FormatString = "HH:mm";
            this.dtCheckOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCheckOut.Properties.EditMask = "HH:mm";

            this.spMinutes.Properties.MinValue = 0;
            this.spMinutes.Properties.MaxValue = 24 * 60;
            this.spMinutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrAttendance_CurrAccCode, this.btnEmployee);
            this.layout.AddItem(Foxoft.Properties.Resources.Common_EmployeeName, this.txtEmployeeName);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrAttendance_WorkDate, this.dtWorkDate);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrAttendance_CheckInTime, this.dtCheckIn);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrAttendance_CheckOutTime, this.dtCheckOut);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrAttendance_WorkedMinutes, this.spMinutes);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnSave);
            btnGroup.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormAttendanceEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Name = "FormAttendanceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtWorkDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtWorkDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckIn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckOut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCheckOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMinutes.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.ButtonEdit btnEmployee;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.DateEdit dtWorkDate;
        private DevExpress.XtraEditors.DateEdit dtCheckIn;
        private DevExpress.XtraEditors.DateEdit dtCheckOut;
        private DevExpress.XtraEditors.SpinEdit spMinutes;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
