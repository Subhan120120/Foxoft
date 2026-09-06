namespace Foxoft
{
    partial class FormEmployeeContractEdit
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
            this.lkpType = new DevExpress.XtraEditors.LookUpEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.calcSalary = new DevExpress.XtraEditors.CalcEdit();
            this.lkpCurrency = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCurrency.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.btnEmployee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            this.txtEmployeeName.Properties.ReadOnly = true;

            this.lkpType.Properties.DisplayMember = "TypeName";
            this.lkpType.Properties.ValueMember = "Id";
            this.lkpType.Properties.NullText = "";
            this.lkpType.Properties.ShowHeader = true;
            this.lkpType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpType.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeCode", Foxoft.Properties.Resources.Entity_DcEmploymentType_TypeCode),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", Foxoft.Properties.Resources.Entity_DcEmploymentType_TypeName)});

            this.lkpCurrency.Properties.DisplayMember = "CurrencyCode";
            this.lkpCurrency.Properties.ValueMember = "CurrencyCode";
            this.lkpCurrency.Properties.NullText = "";
            this.lkpCurrency.Properties.ShowHeader = true;
            this.lkpCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpCurrency.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpCurrency.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", Foxoft.Properties.Resources.Entity_TrEmployeeContract_CurrencyCode),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyDesc", Foxoft.Properties.Resources.Entity_PaymentHeader_Description)});

            this.dtStart.Properties.NullText = "";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.dtEnd.Properties.NullText = "";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.dtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.calcSalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });

            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;

            this.layout.Root = root;
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_CurrAccCode, this.btnEmployee);
            this.layout.AddItem(Foxoft.Properties.Resources.Common_EmployeeName, this.txtEmployeeName);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_EmploymentTypeId, this.lkpType);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_StartDate, this.dtStart);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_EndDate, this.dtEnd);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_BaseSalary, this.calcSalary);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_CurrencyCode, this.lkpCurrency);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnSave);
            btnGroup.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormEmployeeContractEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Name = "FormEmployeeContractEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCurrency.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.ButtonEdit btnEmployee;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.LookUpEdit lkpType;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.CalcEdit calcSalary;
        private DevExpress.XtraEditors.LookUpEdit lkpCurrency;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
