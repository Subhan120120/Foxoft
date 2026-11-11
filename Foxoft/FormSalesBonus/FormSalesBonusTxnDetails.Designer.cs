namespace Foxoft
{
    partial class FormSalesBonusTxnDetails
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
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.memoDetails = new DevExpress.XtraEditors.MemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDetails.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.txtNote.Properties.ReadOnly = true;
            this.memoDetails.Properties.ReadOnly = true;
            this.memoDetails.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memoDetails.Properties.WordWrap = false;
            this.memoDetails.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 9F);
            this.memoDetails.Properties.Appearance.Options.UseFont = true;

            this.btnClose.Text = Foxoft.Properties.Resources.Common_Close;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusTxn_Note, this.txtNote);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusTxn_CalcDetails, this.memoDetails).TextLocation = DevExpress.Utils.Locations.Top;

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnClose).TextVisible = false;

            this.Controls.Add(this.layout);

            // FormSalesBonusTxnDetails
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Name = "FormSalesBonusTxnDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusTxnDetails_Caption;

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDetails.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.MemoEdit memoDetails;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
