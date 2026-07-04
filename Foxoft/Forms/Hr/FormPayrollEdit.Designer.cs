namespace Foxoft
{
    partial class FormPayrollEdit
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
            this.btnEditEmployee = new DevExpress.XtraEditors.ButtonEdit();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.lkpPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.gridLines = new MyGridControl();
            this.viewLines = new MyGridView();
            this.btnAddLine = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveLine = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.spGrossSalary = new DevExpress.XtraEditors.SpinEdit();
            this.spNetSalary = new DevExpress.XtraEditors.SpinEdit();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGrossSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNetSalary.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.btnEditEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnEditEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            this.txtEmployeeName.Properties.ReadOnly = true;

            this.lkpPeriod.Properties.DisplayMember = "PeriodName";
            this.lkpPeriod.Properties.ValueMember = "Id";
            this.lkpPeriod.Properties.NullText = "";
            this.lkpPeriod.Properties.ShowHeader = true;
            this.lkpPeriod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpPeriod.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodYear", Foxoft.Properties.Resources.Entity_TrPayrollPeriod_PeriodYear),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodMonth", Foxoft.Properties.Resources.Entity_TrPayrollPeriod_PeriodMonth)});

            this.spGrossSalary.Properties.ReadOnly = true;
            this.spGrossSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spGrossSalary.Properties.DisplayFormat.FormatString = "N2";
            this.spNetSalary.Properties.ReadOnly = true;
            this.spNetSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spNetSalary.Properties.DisplayFormat.FormatString = "N2";

            this.layout.Controls.Add(this.spGrossSalary);
            this.layout.Controls.Add(this.spNetSalary);

            this.btnAddLine.Text = Foxoft.Properties.Resources.Common_New;
            this.btnRemoveLine.Text = Foxoft.Properties.Resources.Common_Delete;
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            this.gridLines.MainView = this.viewLines;
            this.viewLines.GridControl = this.gridLines;
            this.viewLines.OptionsView.ShowGroupPanel = false;
            this.viewLines.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.viewLines.OptionsBehavior.Editable = true;
            this.viewLines.OptionsView.ColumnAutoWidth = false;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_CurrAccCode, this.btnEditEmployee);
            this.layout.AddItem(Foxoft.Properties.Resources.Common_EmployeeName, this.txtEmployeeName);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_PeriodId, this.lkpPeriod);

            var grpLines = root.AddGroup();
            grpLines.Text = Foxoft.Properties.Resources.Form_PayrollEdit_Lines;
            grpLines.AddItem("", this.gridLines);

            var grpLineButtons = root.AddGroup();
            grpLineButtons.GroupBordersVisible = false;
            grpLineButtons.AddItem("", this.btnAddLine);
            grpLineButtons.AddItem("", this.btnRemoveLine);

            var grpTotals = root.AddGroup();
            grpTotals.Text = Foxoft.Properties.Resources.Form_PayrollEdit_Totals;
            grpTotals.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_GrossSalary, this.spGrossSalary);
            grpTotals.AddItem(Foxoft.Properties.Resources.Entity_TrPayrollHeader_NetSalary, this.spNetSalary);

            var grpButtons = root.AddGroup();
            grpButtons.GroupBordersVisible = false;
            grpButtons.AddItem("", this.btnSave);
            grpButtons.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormPayrollEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 720);
            this.Name = "FormPayrollEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

             ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGrossSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spNetSalary.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.ButtonEdit btnEditEmployee;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.LookUpEdit lkpPeriod;
        private MyGridControl gridLines;
        private MyGridView viewLines;
        private DevExpress.XtraEditors.SimpleButton btnAddLine;
        private DevExpress.XtraEditors.SimpleButton btnRemoveLine;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SpinEdit spGrossSalary;
        private DevExpress.XtraEditors.SpinEdit spNetSalary;
    }
}
