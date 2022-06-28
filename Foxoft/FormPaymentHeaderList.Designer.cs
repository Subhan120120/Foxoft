
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
            this.trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_PaymentHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosterminalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoHLE_InvoiceNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colCurrAccFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentHeaderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentHeaderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoHLE_InvoiceNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_PaymentHeaderList
            // 
            this.gC_PaymentHeaderList.DataSource = this.trPaymentHeadersBindingSource;
            this.gC_PaymentHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_PaymentHeaderList.Location = new System.Drawing.Point(0, 0);
            this.gC_PaymentHeaderList.MainView = this.gV_PaymentHeaderList;
            this.gC_PaymentHeaderList.Name = "gC_PaymentHeaderList";
            this.gC_PaymentHeaderList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoHLE_InvoiceNumber});
            this.gC_PaymentHeaderList.Size = new System.Drawing.Size(980, 268);
            this.gC_PaymentHeaderList.TabIndex = 0;
            this.gC_PaymentHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_PaymentHeaderList});
            this.gC_PaymentHeaderList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_ProductList_Paint);
            this.gC_PaymentHeaderList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_PaymentHeaderList_ProcessGridKey);
            // 
            // trPaymentHeadersBindingSource
            // 
            this.trPaymentHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentHeader);
            // 
            // gV_PaymentHeaderList
            // 
            this.gV_PaymentHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentHeaderId,
            this.colOperationDate,
            this.colOperationTime,
            this.colCurrAccCode,
            this.colDescription,
            this.colStoreCode,
            this.colPosterminalId,
            this.colInvoiceHeaderId,
            this.colInvoiceNumber,
            this.colCurrAccFirstName,
            this.colTotalNetAmount});
            this.gV_PaymentHeaderList.GridControl = this.gC_PaymentHeaderList;
            this.gV_PaymentHeaderList.Name = "gV_PaymentHeaderList";
            this.gV_PaymentHeaderList.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gV_PaymentHeaderList_ShowingEditor);
            this.gV_PaymentHeaderList.DoubleClick += new System.EventHandler(this.gV_PaymentHeaderList_DoubleClick);
            // 
            // colPaymentHeaderId
            // 
            this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
            this.colPaymentHeaderId.Name = "colPaymentHeaderId";
            // 
            // colOperationDate
            // 
            this.colOperationDate.FieldName = "OperationDate";
            this.colOperationDate.Name = "colOperationDate";
            this.colOperationDate.Visible = true;
            this.colOperationDate.VisibleIndex = 0;
            // 
            // colOperationTime
            // 
            this.colOperationTime.FieldName = "OperationTime";
            this.colOperationTime.Name = "colOperationTime";
            this.colOperationTime.Visible = true;
            this.colOperationTime.VisibleIndex = 1;
            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 2;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colStoreCode
            // 
            this.colStoreCode.FieldName = "CurrAccCode";
            this.colStoreCode.Name = "colStoreCode";
            // 
            // colPosterminalId
            // 
            this.colPosterminalId.FieldName = "PosterminalId";
            this.colPosterminalId.Name = "colPosterminalId";
            // 
            // colInvoiceHeaderId
            // 
            this.colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.ColumnEdit = this.repoHLE_InvoiceNumber;
            this.colInvoiceNumber.FieldName = "TrInvoiceHeader.DocumentNumber";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
            this.colInvoiceNumber.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colInvoiceNumber.Visible = true;
            this.colInvoiceNumber.VisibleIndex = 5;
            // 
            // repoHLE_InvoiceNumber
            // 
            this.repoHLE_InvoiceNumber.AutoHeight = false;
            this.repoHLE_InvoiceNumber.Name = "repoHLE_InvoiceNumber";
            this.repoHLE_InvoiceNumber.SingleClick = true;
            this.repoHLE_InvoiceNumber.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.repoHLE_InvoiceNumber_OpenLink);
            this.repoHLE_InvoiceNumber.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemHyperLinkEdit1_ButtonClick);
            // 
            // colCurrAccFirstName
            // 
            this.colCurrAccFirstName.FieldName = "DcCurrAcc.FirstName";
            this.colCurrAccFirstName.Name = "colCurrAccFirstName";
            this.colCurrAccFirstName.Visible = true;
            this.colCurrAccFirstName.VisibleIndex = 3;
            // 
            // colTotalNetAmount
            // 
            this.colTotalNetAmount.FieldName = "TotalNetAmount";
            this.colTotalNetAmount.Name = "colTotalNetAmount";
            this.colTotalNetAmount.Visible = true;
            this.colTotalNetAmount.VisibleIndex = 4;
            // 
            // FormPaymentHeaderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 268);
            this.Controls.Add(this.gC_PaymentHeaderList);
            this.Name = "FormPaymentHeaderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPaymentHeaderList";
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentHeaderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentHeaderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoHLE_InvoiceNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_PaymentHeaderList;
        private System.Windows.Forms.BindingSource trPaymentHeadersBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PaymentHeaderList;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPosterminalId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoHLE_InvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalNetAmount;
    }
}