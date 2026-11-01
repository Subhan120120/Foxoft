namespace Foxoft
{
    partial class FormEmployeeContractAddendumEdit
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
            this.txtContractInfo = new DevExpress.XtraEditors.TextEdit();
            this.txtAddendumNumber = new DevExpress.XtraEditors.TextEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.calcSalary = new DevExpress.XtraEditors.CalcEdit();
            this.lkpCurrency = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddendumNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();

            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            var root = new DevExpress.XtraLayout.LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            this.txtContractInfo.Properties.ReadOnly = true;

            this.lkpCurrency.Properties.DisplayMember = "CurrencyCode";
            this.lkpCurrency.Properties.ValueMember = "CurrencyCode";
            this.lkpCurrency.Properties.NullText = "";
            this.lkpCurrency.Properties.ShowHeader = true;
            this.lkpCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpCurrency.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.lkpCurrency.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", Foxoft.Properties.Resources.Entity_TrEmployeeContract_CurrencyCode),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyDesc", Foxoft.Properties.Resources.Entity_PaymentHeader_Description)
            });

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
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_CurrAccCode, this.txtContractInfo);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContractAddendum_AddendumNumber, this.txtAddendumNumber);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContractAddendum_StartDate, this.dtStart);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContractAddendum_EndDate, this.dtEnd);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContractAddendum_BaseSalary, this.calcSalary);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContract_CurrencyCode, this.lkpCurrency);
            this.layout.AddItem(Foxoft.Properties.Resources.Entity_TrEmployeeContractAddendum_Description, this.txtDescription);

            var btnGroup = root.AddGroup();
            btnGroup.GroupBordersVisible = false;
            btnGroup.AddItem("", this.btnSave);
            btnGroup.AddItem("", this.btnCancel);

            this.Controls.Add(this.layout);

            // FormEmployeeContractAddendumEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 360);
            this.Name = "FormEmployeeContractAddendumEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";

            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtContractInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddendumNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraEditors.TextEdit txtContractInfo;
        private DevExpress.XtraEditors.TextEdit txtAddendumNumber;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.CalcEdit calcSalary;
        private DevExpress.XtraEditors.LookUpEdit lkpCurrency;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
