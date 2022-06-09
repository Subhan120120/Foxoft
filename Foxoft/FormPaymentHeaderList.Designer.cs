
namespace Foxoft
{
    partial class FormPaymentHeaderList
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
            this.components = new System.ComponentModel.Container();
            this.gC_PaymentHeaderList = new DevExpress.XtraGrid.GridControl();
            this.gV_PaymentHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosterminalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentHeaderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentHeaderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_PaymentHeaderList
            // 
            this.gC_PaymentHeaderList.DataSource = this.trPaymentHeadersBindingSource;
            this.gC_PaymentHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_PaymentHeaderList.Location = new System.Drawing.Point(0, 0);
            this.gC_PaymentHeaderList.MainView = this.gV_PaymentHeaderList;
            this.gC_PaymentHeaderList.Name = "gC_PaymentHeaderList";
            this.gC_PaymentHeaderList.Size = new System.Drawing.Size(521, 268);
            this.gC_PaymentHeaderList.TabIndex = 0;
            this.gC_PaymentHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_PaymentHeaderList});
            this.gC_PaymentHeaderList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_PaymentHeaderList_ProcessGridKey);
            // 
            // gV_PaymentHeaderList
            // 
            this.gV_PaymentHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentHeaderId,
            this.colDocumentNumber,
            this.colOperationDate,
            this.colOperationTime,
            this.colInvoiceNumber,
            this.colCurrAccCode,
            this.colDescription,
            this.colOfficeCode,
            this.colStoreCode,
            this.colPosterminalId,
            this.colCurrencyCode,
            this.colExchangeRate});
            this.gV_PaymentHeaderList.GridControl = this.gC_PaymentHeaderList;
            this.gV_PaymentHeaderList.Name = "gV_PaymentHeaderList";
            this.gV_PaymentHeaderList.DoubleClick += new System.EventHandler(this.gV_PaymentHeaderList_DoubleClick);
            // 
            // trPaymentHeadersBindingSource
            // 
            this.trPaymentHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentHeader);
            // 
            // colPaymentHeaderId
            // 
            this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
            this.colPaymentHeaderId.Name = "colPaymentHeaderId";
            this.colPaymentHeaderId.Visible = true;
            this.colPaymentHeaderId.VisibleIndex = 0;
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 2;
            // 
            // colOperationDate
            // 
            this.colOperationDate.FieldName = "OperationDate";
            this.colOperationDate.Name = "colOperationDate";
            this.colOperationDate.Visible = true;
            this.colOperationDate.VisibleIndex = 5;
            // 
            // colOperationTime
            // 
            this.colOperationTime.FieldName = "OperationTime";
            this.colOperationTime.Name = "colOperationTime";
            this.colOperationTime.Visible = true;
            this.colOperationTime.VisibleIndex = 6;
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.FieldName = "InvoiceNumber";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
            this.colInvoiceNumber.Visible = true;
            this.colInvoiceNumber.VisibleIndex = 7;
            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 8;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 9;
            // 
            // colOfficeCode
            // 
            this.colOfficeCode.FieldName = "OfficeCode";
            this.colOfficeCode.Name = "colOfficeCode";
            this.colOfficeCode.Visible = true;
            this.colOfficeCode.VisibleIndex = 12;
            // 
            // colStoreCode
            // 
            this.colStoreCode.FieldName = "StoreCode";
            this.colStoreCode.Name = "colStoreCode";
            this.colStoreCode.Visible = true;
            this.colStoreCode.VisibleIndex = 13;
            // 
            // colPosterminalId
            // 
            this.colPosterminalId.FieldName = "PosterminalId";
            this.colPosterminalId.Name = "colPosterminalId";
            this.colPosterminalId.Visible = true;
            this.colPosterminalId.VisibleIndex = 14;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 15;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.FieldName = "ExchangeRate";
            this.colExchangeRate.Name = "colExchangeRate";
            this.colExchangeRate.Visible = true;
            this.colExchangeRate.VisibleIndex = 16;
            // 
            // FormPaymentHeaderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 268);
            this.Controls.Add(this.gC_PaymentHeaderList);
            this.Name = "FormPaymentHeaderList";
            this.Text = "FormPaymentHeaderList";
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentHeaderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentHeaderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_PaymentHeaderList;
        private System.Windows.Forms.BindingSource trPaymentHeadersBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PaymentHeaderList;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationTime;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationType;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPosterminalId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colTrPaymentLines;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
    }
}