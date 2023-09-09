
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaymentHeaderList));
            gC_PaymentHeaderList = new DevExpress.XtraGrid.GridControl();
            trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_PaymentHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            repoHLE_DocNum = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            repoHLE_InvoiceNumber = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOperationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPosterminalId = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            colFromCashRegCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colToCashRegCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsSent = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_ReceivePayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_MakePayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)gC_PaymentHeaderList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPaymentHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentHeaderList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoHLE_DocNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoHLE_InvoiceNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_PaymentHeaderList
            // 
            gC_PaymentHeaderList.DataSource = trPaymentHeadersBindingSource;
            gC_PaymentHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_PaymentHeaderList.Location = new System.Drawing.Point(0, 158);
            gC_PaymentHeaderList.MainView = gV_PaymentHeaderList;
            gC_PaymentHeaderList.Name = "gC_PaymentHeaderList";
            gC_PaymentHeaderList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoHLE_InvoiceNumber, repoHLE_DocNum });
            gC_PaymentHeaderList.Size = new System.Drawing.Size(1012, 352);
            gC_PaymentHeaderList.TabIndex = 0;
            gC_PaymentHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentHeaderList });
            gC_PaymentHeaderList.Paint += gC_ProductList_Paint;
            gC_PaymentHeaderList.ProcessGridKey += gC_PaymentHeaderList_ProcessGridKey;
            // 
            // trPaymentHeadersBindingSource
            // 
            trPaymentHeadersBindingSource.DataSource = typeof(Models.TrPaymentHeader);
            // 
            // gV_PaymentHeaderList
            // 
            gV_PaymentHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPaymentHeaderId, colDocumentNumber, colInvoiceNumber, colOperationDate, colOperationTime, colCurrAccCode, colCurrAccDesc, colDescription, colStoreCode, colPosterminalId, colInvoiceHeaderId, colTotalPayment, colFromCashRegCode, colToCashRegCode, colIsSent });
            gV_PaymentHeaderList.CustomizationFormBounds = new System.Drawing.Rectangle(796, 370, 264, 272);
            gV_PaymentHeaderList.GridControl = gC_PaymentHeaderList;
            gV_PaymentHeaderList.Name = "gV_PaymentHeaderList";
            gV_PaymentHeaderList.OptionsFind.FindDelay = 100;
            gV_PaymentHeaderList.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            gV_PaymentHeaderList.OptionsView.ShowFooter = true;
            gV_PaymentHeaderList.OptionsView.ShowGroupPanel = false;
            gV_PaymentHeaderList.ShowingEditor += gV_PaymentHeaderList_ShowingEditor;
            gV_PaymentHeaderList.FocusedRowChanged += gV_PaymentHeaderList_FocusedRowChanged;
            gV_PaymentHeaderList.ColumnFilterChanged += gV_PaymentHeaderList_ColumnFilterChanged;
            gV_PaymentHeaderList.DoubleClick += gV_PaymentHeaderList_DoubleClick;
            // 
            // colPaymentHeaderId
            // 
            colPaymentHeaderId.FieldName = "PaymentHeaderId";
            colPaymentHeaderId.Name = "colPaymentHeaderId";
            // 
            // colDocumentNumber
            // 
            colDocumentNumber.ColumnEdit = repoHLE_DocNum;
            colDocumentNumber.FieldName = "DocumentNumber";
            colDocumentNumber.Name = "colDocumentNumber";
            colDocumentNumber.Visible = true;
            colDocumentNumber.VisibleIndex = 0;
            // 
            // repoHLE_DocNum
            // 
            repoHLE_DocNum.AutoHeight = false;
            repoHLE_DocNum.Name = "repoHLE_DocNum";
            repoHLE_DocNum.SingleClick = true;
            repoHLE_DocNum.OpenLink += repoHLE_DocNum_OpenLink;
            repoHLE_DocNum.ButtonClick += repoHLE_DocNum_ButtonClick;
            // 
            // colInvoiceNumber
            // 
            colInvoiceNumber.ColumnEdit = repoHLE_InvoiceNumber;
            colInvoiceNumber.FieldName = "TrInvoiceHeader.DocumentNumber";
            colInvoiceNumber.Name = "colInvoiceNumber";
            colInvoiceNumber.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            colInvoiceNumber.Visible = true;
            colInvoiceNumber.VisibleIndex = 1;
            // 
            // repoHLE_InvoiceNumber
            // 
            repoHLE_InvoiceNumber.AutoHeight = false;
            repoHLE_InvoiceNumber.Name = "repoHLE_InvoiceNumber";
            repoHLE_InvoiceNumber.SingleClick = true;
            repoHLE_InvoiceNumber.OpenLink += repoHLE_InvoiceNumber_OpenLink;
            repoHLE_InvoiceNumber.ButtonClick += repoHLE_InvoiceNumber_ButtonClick;
            // 
            // colOperationDate
            // 
            colOperationDate.FieldName = "OperationDate";
            colOperationDate.Name = "colOperationDate";
            colOperationDate.Visible = true;
            colOperationDate.VisibleIndex = 2;
            // 
            // colOperationTime
            // 
            colOperationTime.FieldName = "OperationTime";
            colOperationTime.Name = "colOperationTime";
            colOperationTime.Visible = true;
            colOperationTime.VisibleIndex = 3;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 4;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 5;
            // 
            // colDescription
            // 
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 7;
            // 
            // colStoreCode
            // 
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            // 
            // colPosterminalId
            // 
            colPosterminalId.FieldName = "PosterminalId";
            colPosterminalId.Name = "colPosterminalId";
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colTotalPayment
            // 
            colTotalPayment.FieldName = "TotalPayment";
            colTotalPayment.Name = "colTotalPayment";
            colTotalPayment.Visible = true;
            colTotalPayment.VisibleIndex = 6;
            // 
            // colFromCashRegCode
            // 
            colFromCashRegCode.FieldName = "FromCashRegCode";
            colFromCashRegCode.Name = "colFromCashRegCode";
            colFromCashRegCode.Visible = true;
            colFromCashRegCode.VisibleIndex = 8;
            // 
            // colToCashRegCode
            // 
            colToCashRegCode.FieldName = "ToCashRegCode";
            colToCashRegCode.Name = "colToCashRegCode";
            colToCashRegCode.Visible = true;
            colToCashRegCode.VisibleIndex = 9;
            // 
            // colIsSent
            // 
            colIsSent.FieldName = "IsSent";
            colIsSent.Name = "colIsSent";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, bBI_ReceivePayment, bBI_MakePayment, bBI_ExportXlsx });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 4;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(1012, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_ReceivePayment
            // 
            bBI_ReceivePayment.Caption = "Ödəniş Al";
            bBI_ReceivePayment.Id = 1;
            bBI_ReceivePayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ReceivePayment.ImageOptions.SvgImage");
            bBI_ReceivePayment.Name = "bBI_ReceivePayment";
            bBI_ReceivePayment.ItemClick += bBI_ReceivePayment_ItemClick;
            // 
            // bBI_MakePayment
            // 
            bBI_MakePayment.Caption = "Ödəniş Et";
            bBI_MakePayment.Id = 2;
            bBI_MakePayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_MakePayment.ImageOptions.SvgImage");
            bBI_MakePayment.Name = "bBI_MakePayment";
            bBI_MakePayment.ItemClick += bBI_MakePayment_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = "Excelə İxrac";
            bBI_ExportXlsx.Id = 3;
            bBI_ExportXlsx.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Ödəmə";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_ReceivePayment);
            ribbonPageGroup1.ItemLinks.Add(bBI_MakePayment);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyat";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Export";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 510);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new System.Drawing.Size(1012, 24);
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // FormPaymentHeaderList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1012, 534);
            Controls.Add(gC_PaymentHeaderList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormPaymentHeaderList";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Ödəmələr";
            ((System.ComponentModel.ISupportInitialize)gC_PaymentHeaderList).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPaymentHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentHeaderList).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoHLE_DocNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoHLE_InvoiceNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoHLE_InvoiceNumber;
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
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPayment;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn colToCashRegCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFromCashRegCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSent;
    }
}