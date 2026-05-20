namespace Foxoft
{
    partial class FormPayrollPeriodEdit
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
            this.spYear = new DevExpress.XtraEditors.SpinEdit();
            this.spMonth = new DevExpress.XtraEditors.SpinEdit();
            this.chkClosed = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClosed.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.spYear.Properties.MinValue = 2000;
            this.spYear.Properties.MaxValue = 2100;
            
            this.spMonth.Properties.MinValue = 1;
            this.spMonth.Properties.MaxValue = 12;

            this.chkClosed.Text = Foxoft.Properties.Resources.Entity_TrPayrollPeriod_IsClosed;
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollPeriod_StartDate + " (Year)", this.spYear);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollPeriod_StartDate + " (Month)", this.spMonth);
            this.layout.AddItem("", this.chkClosed);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnSave);
            btnGroup.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormPayrollPeriodEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 320);
            this.Name = "FormPayrollPeriodEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClosed.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.SpinEdit spYear;
        private DevExpress.XtraEditors.SpinEdit spMonth;
        private DevExpress.XtraEditors.CheckEdit chkClosed;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
