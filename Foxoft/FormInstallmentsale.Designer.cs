using DevExpress.Dialogs.Core.View;

namespace Foxoft
{
    partial class FormInstallmentsale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstallmentsale));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSourceTrInstallmentsale = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colInstallmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentPlanCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            PaidAmout = new DevExpress.XtraGrid.Columns.GridColumn();
            RemainingBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            MonthlyPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            DueAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            col_Pay = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_Payment = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentsale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSourceTrInstallmentsale;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoBtnEdit_Payment });
            gridControl1.Size = new Size(954, 526);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInstallmentId, colInvoiceHeaderId, colPaymentPlanCode, colCurrencyCode, colExchangeRate, colDocumentDate, colAmount, colCommission, PaidAmout, RemainingBalance, MonthlyPayment, DueAmount, col_Pay });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.RowHeight = 35;
            // 
            // colInstallmentId
            // 
            colInstallmentId.FieldName = "InstallmentId";
            colInstallmentId.Name = "colInstallmentId";
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colPaymentPlanCode
            // 
            colPaymentPlanCode.FieldName = "PaymentPlanCode";
            colPaymentPlanCode.Name = "colPaymentPlanCode";
            colPaymentPlanCode.Visible = true;
            colPaymentPlanCode.VisibleIndex = 0;
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 3;
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            colExchangeRate.Visible = true;
            colExchangeRate.VisibleIndex = 5;
            // 
            // colDocumentDate
            // 
            colDocumentDate.FieldName = "DocumentDate";
            colDocumentDate.Name = "colDocumentDate";
            colDocumentDate.Visible = true;
            colDocumentDate.VisibleIndex = 2;
            // 
            // colAmount
            // 
            colAmount.DisplayFormat.FormatString = "{0:n2}";
            colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            colAmount.Visible = true;
            colAmount.VisibleIndex = 4;
            // 
            // colCommission
            // 
            colCommission.DisplayFormat.FormatString = "{0:n2}";
            colCommission.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCommission.FieldName = "Commission";
            colCommission.Name = "colCommission";
            colCommission.Visible = true;
            colCommission.VisibleIndex = 1;
            // 
            // PaidAmout
            // 
            PaidAmout.Caption = "PaidAmout";
            PaidAmout.DisplayFormat.FormatString = "{0:n2}";
            PaidAmout.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            PaidAmout.FieldName = "PaidAmount";
            PaidAmout.Name = "PaidAmout";
            PaidAmout.Visible = true;
            PaidAmout.VisibleIndex = 6;
            // 
            // RemainingBalance
            // 
            RemainingBalance.Caption = "RemainingBalance";
            RemainingBalance.DisplayFormat.FormatString = "{0:n2}";
            RemainingBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            RemainingBalance.FieldName = "RemainingBalance";
            RemainingBalance.Name = "RemainingBalance";
            RemainingBalance.Visible = true;
            RemainingBalance.VisibleIndex = 7;
            // 
            // MonthlyPayment
            // 
            MonthlyPayment.Caption = "MonthlyPayment";
            MonthlyPayment.DisplayFormat.FormatString = "{0:n2}";
            MonthlyPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            MonthlyPayment.FieldName = "MonthlyPayment";
            MonthlyPayment.Name = "MonthlyPayment";
            MonthlyPayment.Visible = true;
            MonthlyPayment.VisibleIndex = 8;
            // 
            // DueAmount
            // 
            DueAmount.Caption = "DueAmount";
            DueAmount.DisplayFormat.FormatString = "{0:n2}";
            DueAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            DueAmount.FieldName = "DueAmount";
            DueAmount.Name = "DueAmount";
            DueAmount.Visible = true;
            DueAmount.VisibleIndex = 9;
            // 
            // col_Pay
            // 
            col_Pay.Caption = "Buttons";
            col_Pay.ColumnEdit = repoBtnEdit_Payment;
            col_Pay.Name = "col_Pay";
            col_Pay.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            col_Pay.Visible = true;
            col_Pay.VisibleIndex = 10;
            // 
            // repoBtnEdit_Payment
            // 
            repoBtnEdit_Payment.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions1.SvgImage");
            repoBtnEdit_Payment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            repoBtnEdit_Payment.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            repoBtnEdit_Payment.Name = "repoBtnEdit_Payment";
            repoBtnEdit_Payment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repoBtnEdit_Payment.ButtonPressed += RepoBtnEdit_Payment_ButtonPressed;
            // 
            // FormInstallmentsale
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 526);
            Controls.Add(gridControl1);
            Name = "FormInstallmentsale";
            Text = "FormInstallmentsale";
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentsale).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BindingSource bindingSourceTrInstallmentsale;
        private DevExpress.XtraGrid.Columns.GridColumn colInstallmentId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentPlanCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCommission;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colDcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colTrInvoiceHeader;
        private DevExpress.XtraGrid.Columns.GridColumn colDcPaymentPlan;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn PaidAmout;
        private DevExpress.XtraGrid.Columns.GridColumn RemainingBalance;
        private DevExpress.XtraGrid.Columns.GridColumn MonthlyPayment;
        private DevExpress.XtraGrid.Columns.GridColumn DueAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_Pay;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_Payment;
    }
}