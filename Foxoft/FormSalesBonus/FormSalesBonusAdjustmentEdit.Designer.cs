namespace Foxoft
{
    partial class FormSalesBonusAdjustmentEdit
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
            this.btnSalesPerson = new DevExpress.XtraEditors.ButtonEdit();
            this.txtSalesPersonName = new DevExpress.XtraEditors.TextEdit();
            this.lkpPlan = new DevExpress.XtraEditors.LookUpEdit();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.spinAmount = new DevExpress.XtraEditors.SpinEdit();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesPersonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.btnSalesPerson.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnSalesPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            this.txtSalesPersonName.Properties.ReadOnly = true;

            this.lkpPlan.Properties.DisplayMember = "PlanName";
            this.lkpPlan.Properties.ValueMember = "SalesBonusPlanId";
            this.lkpPlan.Properties.NullText = "";
            this.lkpPlan.Properties.ShowHeader = false;
            this.lkpPlan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpPlan.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpPlan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpPlan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PlanName", "") });

            this.dtDate.Properties.NullText = "";
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.spinAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinAmount.Properties.DisplayFormat.FormatString = "n2";
            this.spinAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinAmount.Properties.EditFormat.FormatString = "n2";
            this.spinAmount.Properties.Mask.EditMask = "n2";
            this.spinAmount.Properties.MinValue = -100000000m;
            this.spinAmount.Properties.MaxValue = 100000000m;

            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_SalesPersonCode, this.btnSalesPerson);
            this.layout.AddItem(Foxoft.Properties.Resources.Common_EmployeeName, this.txtSalesPersonName);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusAssignment_PlanId, this.lkpPlan);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusTxn_DocumentDate, this.dtDate);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusTxn_Amount, this.spinAmount);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_SalesBonusTxn_Note, this.txtNote);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnSave);
            btnGroup.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormSalesBonusAdjustmentEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 330);
            this.Name = "FormSalesBonusAdjustmentEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Foxoft.Properties.Resources.Form_SalesBonusAdjustment_Caption;

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalesPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesPersonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.ButtonEdit btnSalesPerson;
        private DevExpress.XtraEditors.TextEdit txtSalesPersonName;
        private DevExpress.XtraEditors.LookUpEdit lkpPlan;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.SpinEdit spinAmount;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
