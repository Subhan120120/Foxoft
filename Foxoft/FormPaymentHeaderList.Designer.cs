
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaymentHeaderList));
         this.gC_PaymentHeaderList = new DevExpress.XtraGrid.GridControl();
         this.trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_PaymentHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoHLE_DocNum = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
         this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoHLE_InvoiceNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
         this.colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colOperationTime = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPosterminalId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTotalPayment = new DevExpress.XtraGrid.Columns.GridColumn();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_ReceivePayment = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_MakePayment = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentHeaderList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentHeaderList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoHLE_DocNum)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoHLE_InvoiceNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_PaymentHeaderList
         // 
         this.gC_PaymentHeaderList.DataSource = this.trPaymentHeadersBindingSource;
         this.gC_PaymentHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_PaymentHeaderList.Location = new System.Drawing.Point(0, 158);
         this.gC_PaymentHeaderList.MainView = this.gV_PaymentHeaderList;
         this.gC_PaymentHeaderList.Name = "gC_PaymentHeaderList";
         this.gC_PaymentHeaderList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoHLE_InvoiceNumber,
            this.repoHLE_DocNum});
         this.gC_PaymentHeaderList.Size = new System.Drawing.Size(1012, 352);
         this.gC_PaymentHeaderList.TabIndex = 0;
         this.gC_PaymentHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_PaymentHeaderList});
         this.gC_PaymentHeaderList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_ProductList_Paint);
         this.gC_PaymentHeaderList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_PaymentHeaderList_ProcessGridKey);
         // 
         // gV_PaymentHeaderList
         // 
         this.gV_PaymentHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentHeaderId,
            this.colDocumentNumber,
            this.colInvoiceNumber,
            this.colOperationDate,
            this.colOperationTime,
            this.colCurrAccCode,
            this.colCurrAccDesc,
            this.colDescription,
            this.colStoreCode,
            this.colPosterminalId,
            this.colInvoiceHeaderId,
            this.colTotalPayment});
         this.gV_PaymentHeaderList.GridControl = this.gC_PaymentHeaderList;
         this.gV_PaymentHeaderList.Name = "gV_PaymentHeaderList";
         this.gV_PaymentHeaderList.OptionsView.ShowFooter = true;
         this.gV_PaymentHeaderList.OptionsView.ShowGroupPanel = false;
         this.gV_PaymentHeaderList.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gV_PaymentHeaderList_ShowingEditor);
         this.gV_PaymentHeaderList.DoubleClick += new System.EventHandler(this.gV_PaymentHeaderList_DoubleClick);
         // 
         // colPaymentHeaderId
         // 
         this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
         this.colPaymentHeaderId.Name = "colPaymentHeaderId";
         // 
         // colDocumentNumber
         // 
         this.colDocumentNumber.ColumnEdit = this.repoHLE_DocNum;
         this.colDocumentNumber.FieldName = "DocumentNumber";
         this.colDocumentNumber.Name = "colDocumentNumber";
         this.colDocumentNumber.Visible = true;
         this.colDocumentNumber.VisibleIndex = 0;
         // 
         // repoHLE_DocNum
         // 
         this.repoHLE_DocNum.AutoHeight = false;
         this.repoHLE_DocNum.Name = "repoHLE_DocNum";
         this.repoHLE_DocNum.SingleClick = true;
         this.repoHLE_DocNum.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.repoHLE_DocNum_OpenLink);
         this.repoHLE_DocNum.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoHLE_DocNum_ButtonClick);
         // 
         // colInvoiceNumber
         // 
         this.colInvoiceNumber.ColumnEdit = this.repoHLE_InvoiceNumber;
         this.colInvoiceNumber.FieldName = "TrInvoiceHeader.DocumentNumber";
         this.colInvoiceNumber.Name = "colInvoiceNumber";
         this.colInvoiceNumber.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
         this.colInvoiceNumber.Visible = true;
         this.colInvoiceNumber.VisibleIndex = 1;
         // 
         // repoHLE_InvoiceNumber
         // 
         this.repoHLE_InvoiceNumber.AutoHeight = false;
         this.repoHLE_InvoiceNumber.Name = "repoHLE_InvoiceNumber";
         this.repoHLE_InvoiceNumber.SingleClick = true;
         this.repoHLE_InvoiceNumber.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.repoHLE_InvoiceNumber_OpenLink);
         this.repoHLE_InvoiceNumber.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoHLE_InvoiceNumber_ButtonClick);
         // 
         // colOperationDate
         // 
         this.colOperationDate.FieldName = "OperationDate";
         this.colOperationDate.Name = "colOperationDate";
         this.colOperationDate.Visible = true;
         this.colOperationDate.VisibleIndex = 2;
         // 
         // colOperationTime
         // 
         this.colOperationTime.FieldName = "OperationTime";
         this.colOperationTime.Name = "colOperationTime";
         this.colOperationTime.Visible = true;
         this.colOperationTime.VisibleIndex = 3;
         // 
         // colCurrAccCode
         // 
         this.colCurrAccCode.FieldName = "CurrAccCode";
         this.colCurrAccCode.Name = "colCurrAccCode";
         this.colCurrAccCode.Visible = true;
         this.colCurrAccCode.VisibleIndex = 4;
         // 
         // colCurrAccDesc
         // 
         this.colCurrAccDesc.FieldName = "CurrAccDesc";
         this.colCurrAccDesc.Name = "colCurrAccDesc";
         this.colCurrAccDesc.Visible = true;
         this.colCurrAccDesc.VisibleIndex = 5;
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
         // colTotalPayment
         // 
         this.colTotalPayment.FieldName = "TotalPayment";
         this.colTotalPayment.Name = "colTotalPayment";
         this.colTotalPayment.Visible = true;
         this.colTotalPayment.VisibleIndex = 6;
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_ReceivePayment,
            this.bBI_MakePayment,
            this.bBI_ExportXlsx});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 4;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(1012, 158);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
         // 
         // bBI_ReceivePayment
         // 
         this.bBI_ReceivePayment.Caption = "Ödəniş Al";
         this.bBI_ReceivePayment.Id = 1;
         this.bBI_ReceivePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ReceivePayment.ImageOptions.SvgImage")));
         this.bBI_ReceivePayment.Name = "bBI_ReceivePayment";
         this.bBI_ReceivePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ReceivePayment_ItemClick);
         // 
         // bBI_MakePayment
         // 
         this.bBI_MakePayment.Caption = "Ödəniş Et";
         this.bBI_MakePayment.Id = 2;
         this.bBI_MakePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_MakePayment.ImageOptions.SvgImage")));
         this.bBI_MakePayment.Name = "bBI_MakePayment";
         this.bBI_MakePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_MakePayment_ItemClick);
         // 
         // bBI_ExportXlsx
         // 
         this.bBI_ExportXlsx.Caption = "Excelə İxrac";
         this.bBI_ExportXlsx.Id = 3;
         this.bBI_ExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage")));
         this.bBI_ExportXlsx.Name = "bBI_ExportXlsx";
         this.bBI_ExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportXlsx_ItemClick);
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Ödəmə";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_ReceivePayment);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_MakePayment);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "Əməliyat";
         // 
         // ribbonPageGroup2
         // 
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_ExportXlsx);
         this.ribbonPageGroup2.Name = "ribbonPageGroup2";
         this.ribbonPageGroup2.Text = "Export";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 510);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(1012, 24);
         // 
         // ribbonPage2
         // 
         this.ribbonPage2.Name = "ribbonPage2";
         this.ribbonPage2.Text = "ribbonPage2";
         // 
         // FormPaymentHeaderList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1012, 534);
         this.Controls.Add(this.gC_PaymentHeaderList);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "FormPaymentHeaderList";
         this.Ribbon = this.ribbonControl1;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "FormPaymentHeaderList";
         ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentHeaderList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentHeaderList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoHLE_DocNum)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoHLE_InvoiceNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

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
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoHLE_DocNum;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_ReceivePayment;
        private DevExpress.XtraBars.BarButtonItem bBI_MakePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn col_TotalPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPayment;
      private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
   }
}