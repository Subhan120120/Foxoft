using Foxoft.Properties;

namespace Foxoft
{
    partial class FormPaymentLineList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaymentLineList));
            this.gC_PaymentLineList = new DevExpress.XtraGrid.GridControl();
            this.trPaymentLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_PaymentLineList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoHLE_DocNum = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoHLE_InvoiceNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceivePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMakePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCashRegisterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_ReceivePayment = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_MakePayment = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Reload = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.test = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentLineList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentLineList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoHLE_DocNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoHLE_InvoiceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_PaymentLineList
            // 
            this.gC_PaymentLineList.DataSource = this.trPaymentLinesBindingSource;
            this.gC_PaymentLineList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_PaymentLineList.Location = new System.Drawing.Point(0, 158);
            this.gC_PaymentLineList.MainView = this.gV_PaymentLineList;
            this.gC_PaymentLineList.Name = "gC_PaymentLineList";
            this.gC_PaymentLineList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoHLE_InvoiceNumber,
            this.repoHLE_DocNum});
            this.gC_PaymentLineList.Size = new System.Drawing.Size(1012, 352);
            this.gC_PaymentLineList.TabIndex = 0;
            this.gC_PaymentLineList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_PaymentLineList});
            this.gC_PaymentLineList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_ProductList_Paint);
            this.gC_PaymentLineList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_PaymentLineList_ProcessGridKey);
            // 
            // trPaymentLinesBindingSource
            // 
            this.trPaymentLinesBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentLine);
            // 
            // gV_PaymentLineList
            // 
            this.gV_PaymentLineList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentHeaderId,
            this.colInvoiceHeaderId,
            this.colPaymentLineId,
            this.colDocumentNumber,
            this.colInvoiceNumber,
            this.colDocumentDate,
            this.colCurrAccCode,
            this.colCurrAccDesc,
            this.colPaymentTypeCode,
            this.colPayment,
            this.colCurrencyCode,
            this.colExchangeRate,
            this.colReceivePayment,
            this.colMakePayment,
            this.colPaymentLoc,
            this.colLineDescription,
            this.colCreatedDate,
            this.colCreatedUserName,
            this.colCashRegisterCode});
            this.gV_PaymentLineList.GridControl = this.gC_PaymentLineList;
            this.gV_PaymentLineList.Name = "gV_PaymentLineList";
            this.gV_PaymentLineList.OptionsView.ShowFooter = true;
            this.gV_PaymentLineList.OptionsView.ShowGroupPanel = false;
            this.gV_PaymentLineList.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gV_PaymentLineList_ShowingEditor);
            this.gV_PaymentLineList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_PaymentLineList_FocusedRowChanged);
            this.gV_PaymentLineList.ColumnFilterChanged += new System.EventHandler(this.gV_PaymentLineList_ColumnFilterChanged);
            this.gV_PaymentLineList.DoubleClick += new System.EventHandler(this.gV_PaymentLineList_DoubleClick);
            // 
            // colPaymentHeaderId
            // 
            this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
            this.colPaymentHeaderId.Name = "colPaymentHeaderId";
            // 
            // colInvoiceHeaderId
            // 
            this.colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colPaymentLineId
            // 
            this.colPaymentLineId.FieldName = "PaymentLineId";
            this.colPaymentLineId.Name = "colPaymentLineId";
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.Caption = Resources.Entity_PaymentHeader_DocumentNumber;
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
            this.colInvoiceNumber.Caption = Resources.Entity_InvoiceHeader_DocumentNumber;
            this.colInvoiceNumber.ColumnEdit = this.repoHLE_InvoiceNumber;
            this.colInvoiceNumber.FieldName = "InvoiceNumber";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
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
            // colDocumentDate
            // 
            this.colDocumentDate.Caption = Resources.Entity_PaymentHeader_DocumentDate;
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 2;
            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.Caption = Resources.Entity_PaymentHeader_CurrAccCode;
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            // 
            // colCurrAccDesc
            // 
            this.colCurrAccDesc.Caption = Resources.Entity_PaymentHeader_CurrAccDesc;
            this.colCurrAccDesc.FieldName = "CurrAccDesc";
            this.colCurrAccDesc.Name = "colCurrAccDesc";
            this.colCurrAccDesc.Visible = true;
            this.colCurrAccDesc.VisibleIndex = 3;
            // 
            // colPaymentTypeCode
            // 
            this.colPaymentTypeCode.Caption = Resources.Entity_PaymentLine_PaymentTypeCode;
            this.colPaymentTypeCode.FieldName = "PaymentTypeCode";
            this.colPaymentTypeCode.Name = "colPaymentTypeCode";
            this.colPaymentTypeCode.Visible = true;
            this.colPaymentTypeCode.VisibleIndex = 4;
            // 
            // colPayment
            // 
            this.colPayment.Caption = Resources.Entity_PaymentLine_Payment;
            this.colPayment.FieldName = "Payment";
            this.colPayment.Name = "colPayment";
            this.colPayment.Visible = true;
            this.colPayment.VisibleIndex = 5;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.Caption = Resources.Entity_PaymentLine_CurrencyCode;
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 6;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.FieldName = "ExchangeRate";
            this.colExchangeRate.Name = "colExchangeRate";
            // 
            // colReceivePayment
            // 
            this.colReceivePayment.Caption = Resources.Entity_PaymentLine_ReceivePayment;
            this.colReceivePayment.FieldName = "ReceivePayment";
            this.colReceivePayment.Name = "colReceivePayment";
            this.colReceivePayment.Visible = true;
            this.colReceivePayment.VisibleIndex = 7;
            // 
            // colMakePayment
            // 
            this.colMakePayment.Caption = Resources.Entity_PaymentLine_MakePayment;
            this.colMakePayment.FieldName = "MakePayment";
            this.colMakePayment.Name = "colMakePayment";
            this.colMakePayment.Visible = true;
            this.colMakePayment.VisibleIndex = 8;
            // 
            // colPaymentLoc
            // 
            this.colPaymentLoc.FieldName = "PaymentLoc";
            this.colPaymentLoc.Name = "colPaymentLoc";
            // 
            // colLineDescription
            // 
            this.colLineDescription.Caption = Resources.Entity_PaymentLine_LineDescription;
            this.colLineDescription.FieldName = "LineDescription";
            this.colLineDescription.Name = "colLineDescription";
            this.colLineDescription.Visible = true;
            this.colLineDescription.VisibleIndex = 9;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.Caption = Resources.Entity_Base_CreatedUserName;
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCashRegisterCode
            // 
            this.colCashRegisterCode.Caption = Resources.Entity_PaymentLine_CashRegisterCode;
            this.colCashRegisterCode.FieldName = "CashRegisterCode";
            this.colCashRegisterCode.Name = "colCashRegisterCode";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_ReceivePayment,
            this.bBI_MakePayment,
            this.bBI_Reload,
            this.bBI_ExportXlsx,
            this.test});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1012, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // bBI_ReceivePayment
            // 
            this.bBI_ReceivePayment.Caption = Resources.Form_PaymentLineList_Button_ReceivePayment;
            this.bBI_ReceivePayment.Id = 1;
            this.bBI_ReceivePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ReceivePayment.ImageOptions.SvgImage")));
            this.bBI_ReceivePayment.Name = "bBI_ReceivePayment";
            this.bBI_ReceivePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ReceivePayment_ItemClick);
            // 
            // bBI_MakePayment
            // 
            this.bBI_MakePayment.Caption = Resources.Form_PaymentLineList_Button_MakePayment;
            this.bBI_MakePayment.Id = 2;
            this.bBI_MakePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_MakePayment.ImageOptions.SvgImage")));
            this.bBI_MakePayment.Name = "bBI_MakePayment";
            this.bBI_MakePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_MakePayment_ItemClick);
            // 
            // bBI_Reload
            // 
            this.bBI_Reload.Caption = Resources.Form_PaymentLineList_Button_Reload;
            this.bBI_Reload.Id = 4;
            this.bBI_Reload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Reload.ImageOptions.SvgImage")));
            this.bBI_Reload.Name = "bBI_Reload";
            this.bBI_Reload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Reload_ItemClick);
            // 
            // bBI_ExportXlsx
            // 
            this.bBI_ExportXlsx.Caption = Resources.Form_PaymentLineList_Button_ExportXlsx;
            this.bBI_ExportXlsx.Id = 5;
            this.bBI_ExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage")));
            this.bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            this.bBI_ExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportXlsx_ItemClick);
            // 
            // test
            // 
            this.test.Caption = Resources.Form_PaymentLineList_Button_Test;
            this.test.Id = 6;
            this.test.Name = "test";
            this.test.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.test_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Resources.Form_PaymentLineList_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_ReceivePayment);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_MakePayment);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = Resources.Form_PaymentLineList_RibbonGroup_Operations;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bBI_Reload);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = Resources.Form_PaymentLineList_RibbonGroup_Control;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bBI_ExportXlsx);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = Resources.Form_PaymentLineList_RibbonGroup_Export;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.test);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = Resources.Form_PaymentLineList_RibbonGroup_Test;
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
            // FormPaymentLineList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 534);
            this.Controls.Add(this.gC_PaymentLineList);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormPaymentLineList";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = Resources.Form_PaymentLineList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentLineList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentLineList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoHLE_DocNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoHLE_InvoiceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_PaymentLineList;
        private System.Windows.Forms.BindingSource trPaymentLinesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PaymentLineList;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoHLE_InvoiceNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoHLE_DocNum;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_ReceivePayment;
        private DevExpress.XtraBars.BarButtonItem bBI_MakePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colMakePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colCashRegisterCode;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraBars.BarButtonItem bBI_Reload;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem test;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}
