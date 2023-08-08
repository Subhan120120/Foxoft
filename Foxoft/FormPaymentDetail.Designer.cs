
namespace Foxoft
{
    partial class FormPaymentDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaymentDetail));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_DeletePayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            bBI_SendWhatsapp = new DevExpress.XtraBars.BarButtonItem();
            bBI_NewPayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_CopyPayment = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            BBI_Info = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RPG_Report = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            checkEdit_IsSent = new DevExpress.XtraEditors.CheckEdit();
            trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(components);
            lbl_CurrAccBalansBefore = new DevExpress.XtraEditors.LabelControl();
            lbl_CurrAccBalansAfter = new DevExpress.XtraEditors.LabelControl();
            lbl_CurrAccDesc = new DevExpress.XtraEditors.LabelControl();
            gC_PaymentLine = new DevExpress.XtraGrid.GridControl();
            trPaymentLinesBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_PaymentLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPaymentLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_PaymentTypeCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colReceivePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_ReceivePayment = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colMakePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_MakePayment = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCashRegisterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_CashregisterCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceBefor = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceAfter = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            OperationDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            OperationTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            StoreCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            CurrAccCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForOperationTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForOperationDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkEdit_IsSent.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPaymentHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gC_PaymentLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPaymentLinesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_PaymentTypeCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_ReceivePayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_MakePayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_CashregisterCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperationDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperationDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperationTimeTimeSpanEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DescriptionTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StoreCodeLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, ribbon.SearchEditItem, bBI_DeletePayment, bBI_SaveAndClose, bBI_SendWhatsapp, bBI_NewPayment, bBI_CopyPayment, barButtonItem1, barButtonItem2, barButtonItem3, BBI_Info });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 11;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new System.Drawing.Size(899, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // bBI_DeletePayment
            // 
            bBI_DeletePayment.Caption = "Ödənişi Sil";
            bBI_DeletePayment.Id = 1;
            bBI_DeletePayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_DeletePayment.ImageOptions.SvgImage");
            bBI_DeletePayment.Name = "bBI_DeletePayment";
            bBI_DeletePayment.ItemClick += bBI_DeletePayment_ItemClick;
            // 
            // bBI_SaveAndClose
            // 
            bBI_SaveAndClose.Caption = "Yadda Saxla Bağla";
            bBI_SaveAndClose.Id = 2;
            bBI_SaveAndClose.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndClose.ImageOptions.SvgImage");
            bBI_SaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            bBI_SaveAndClose.Name = "bBI_SaveAndClose";
            bBI_SaveAndClose.ItemClick += bBI_SaveAndClose_ItemClick;
            // 
            // bBI_SendWhatsapp
            // 
            bBI_SendWhatsapp.Caption = "Whatsapa Göndər";
            bBI_SendWhatsapp.Id = 3;
            bBI_SendWhatsapp.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SendWhatsapp.ImageOptions.SvgImage");
            bBI_SendWhatsapp.Name = "bBI_SendWhatsapp";
            bBI_SendWhatsapp.ItemClick += bBI_SendWhatsapp_ItemClick;
            // 
            // bBI_NewPayment
            // 
            bBI_NewPayment.Caption = "Yeni Ödəniş";
            bBI_NewPayment.Id = 5;
            bBI_NewPayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_NewPayment.ImageOptions.SvgImage");
            bBI_NewPayment.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N);
            bBI_NewPayment.Name = "bBI_NewPayment";
            bBI_NewPayment.ItemClick += bBI_NewPayment_ItemClick;
            // 
            // bBI_CopyPayment
            // 
            bBI_CopyPayment.Caption = "Kopyala";
            bBI_CopyPayment.Id = 6;
            bBI_CopyPayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CopyPayment.ImageOptions.SvgImage");
            bBI_CopyPayment.Name = "bBI_CopyPayment";
            bBI_CopyPayment.ItemClick += bBI_CopyPayment_ItemClick;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Pulun Bütün Hərəkətləri";
            barButtonItem1.Id = 7;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Wp";
            barButtonItem2.Id = 8;
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "test";
            barButtonItem3.Id = 9;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            // 
            // BBI_Info
            // 
            BBI_Info.Caption = "İnfo";
            BBI_Info.Id = 10;
            BBI_Info.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Info.ImageOptions.SvgImage");
            BBI_Info.Name = "BBI_Info";
            BBI_Info.ItemClick += BBI_Info_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, RPG_Report, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Ödəmə";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_SaveAndClose);
            ribbonPageGroup1.ItemLinks.Add(bBI_NewPayment);
            ribbonPageGroup1.ItemLinks.Add(bBI_DeletePayment);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Ödəmə";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_SendWhatsapp);
            ribbonPageGroup2.ItemLinks.Add(bBI_CopyPayment);
            ribbonPageGroup2.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Alət";
            // 
            // RPG_Report
            // 
            RPG_Report.ItemLinks.Add(barButtonItem1);
            RPG_Report.ItemLinks.Add(barButtonItem3);
            RPG_Report.Name = "RPG_Report";
            RPG_Report.Text = "Hesabat";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            ribbonPageGroup3.ItemLinks.Add(BBI_Info);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Məlumat";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 554);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new System.Drawing.Size(899, 24);
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(checkEdit_IsSent);
            dataLayoutControl1.Controls.Add(lbl_CurrAccBalansBefore);
            dataLayoutControl1.Controls.Add(lbl_CurrAccBalansAfter);
            dataLayoutControl1.Controls.Add(lbl_CurrAccDesc);
            dataLayoutControl1.Controls.Add(gC_PaymentLine);
            dataLayoutControl1.Controls.Add(OperationDateDateEdit);
            dataLayoutControl1.Controls.Add(OperationTimeTimeSpanEdit);
            dataLayoutControl1.Controls.Add(DescriptionTextEdit);
            dataLayoutControl1.Controls.Add(StoreCodeLookUpEdit);
            dataLayoutControl1.Controls.Add(CurrAccCodeButtonEdit);
            dataLayoutControl1.Controls.Add(btnEdit_DocNum);
            dataLayoutControl1.DataSource = trPaymentHeadersBindingSource;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(899, 396);
            dataLayoutControl1.TabIndex = 2;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // checkEdit_IsSent
            // 
            checkEdit_IsSent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "IsSent", true));
            checkEdit_IsSent.Enabled = false;
            checkEdit_IsSent.Location = new System.Drawing.Point(367, 364);
            checkEdit_IsSent.Name = "checkEdit_IsSent";
            checkEdit_IsSent.Properties.Caption = "Göndərilib";
            checkEdit_IsSent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            checkEdit_IsSent.Size = new System.Drawing.Size(106, 20);
            checkEdit_IsSent.StyleController = dataLayoutControl1;
            checkEdit_IsSent.TabIndex = 6;
            // 
            // trPaymentHeadersBindingSource
            // 
            trPaymentHeadersBindingSource.AddingNew += trPaymentHeadersBindingSource_AddingNew;
            trPaymentHeadersBindingSource.CurrentItemChanged += trPaymentHeadersBindingSource_CurrentItemChanged;
            // 
            // lbl_CurrAccBalansBefore
            // 
            lbl_CurrAccBalansBefore.Location = new System.Drawing.Point(12, 364);
            lbl_CurrAccBalansBefore.Name = "lbl_CurrAccBalansBefore";
            lbl_CurrAccBalansBefore.Size = new System.Drawing.Size(351, 20);
            lbl_CurrAccBalansBefore.StyleController = dataLayoutControl1;
            lbl_CurrAccBalansBefore.TabIndex = 1;
            lbl_CurrAccBalansBefore.Text = "Cari Hesab Əvvəlki Borc: ";
            // 
            // lbl_CurrAccBalansAfter
            // 
            lbl_CurrAccBalansAfter.Location = new System.Drawing.Point(477, 364);
            lbl_CurrAccBalansAfter.Name = "lbl_CurrAccBalansAfter";
            lbl_CurrAccBalansAfter.Size = new System.Drawing.Size(410, 20);
            lbl_CurrAccBalansAfter.StyleController = dataLayoutControl1;
            lbl_CurrAccBalansAfter.TabIndex = 1;
            lbl_CurrAccBalansAfter.Text = "Cari Hesab Sonrakı Borc: ";
            // 
            // lbl_CurrAccDesc
            // 
            lbl_CurrAccDesc.Location = new System.Drawing.Point(615, 12);
            lbl_CurrAccDesc.Name = "lbl_CurrAccDesc";
            lbl_CurrAccDesc.Size = new System.Drawing.Size(272, 20);
            lbl_CurrAccDesc.StyleController = dataLayoutControl1;
            lbl_CurrAccDesc.TabIndex = 1;
            // 
            // gC_PaymentLine
            // 
            gC_PaymentLine.DataSource = trPaymentLinesBindingSource;
            gC_PaymentLine.Location = new System.Drawing.Point(12, 84);
            gC_PaymentLine.MainView = gV_PaymentLine;
            gC_PaymentLine.MenuManager = ribbon;
            gC_PaymentLine.Name = "gC_PaymentLine";
            gC_PaymentLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoLUE_CurrencyCode, repoCalcEdit_ReceivePayment, repoCalcEdit_MakePayment, repoBtnEdit_CashregisterCode, repoLUE_PaymentTypeCode });
            gC_PaymentLine.Size = new System.Drawing.Size(875, 276);
            gC_PaymentLine.TabIndex = 6;
            gC_PaymentLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentLine });
            gC_PaymentLine.KeyDown += gC_PaymentLine_KeyDown;
            // 
            // gV_PaymentLine
            // 
            gV_PaymentLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPaymentLineId, colPaymentHeaderId, colPaymentTypeCode, colReceivePayment, colMakePayment, colPayment, colPaymentLoc, colCurrencyCode, colLineDescription, colExchangeRate, colCashRegisterCode, colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate, colBalanceBefor, colBalanceAfter, colPaymentMethodId });
            gV_PaymentLine.CustomizationFormBounds = new System.Drawing.Rectangle(760, 390, 264, 272);
            gV_PaymentLine.GridControl = gC_PaymentLine;
            gV_PaymentLine.Name = "gV_PaymentLine";
            gV_PaymentLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_PaymentLine.OptionsNavigation.AutoFocusNewRow = true;
            gV_PaymentLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gV_PaymentLine.OptionsView.ShowGroupPanel = false;
            gV_PaymentLine.InitNewRow += gV_PaymentLine_InitNewRow;
            gV_PaymentLine.CellValueChanging += gV_PaymentLine_CellValueChanging;
            gV_PaymentLine.RowDeleted += gV_PaymentLine_RowDeleted;
            gV_PaymentLine.RowUpdated += gV_PaymentLine_RowUpdated;
            // 
            // colPaymentLineId
            // 
            colPaymentLineId.FieldName = "PaymentLineId";
            colPaymentLineId.Name = "colPaymentLineId";
            // 
            // colPaymentHeaderId
            // 
            colPaymentHeaderId.FieldName = "PaymentHeaderId";
            colPaymentHeaderId.Name = "colPaymentHeaderId";
            // 
            // colPaymentTypeCode
            // 
            colPaymentTypeCode.ColumnEdit = repoLUE_PaymentTypeCode;
            colPaymentTypeCode.FieldName = "PaymentTypeCode";
            colPaymentTypeCode.Name = "colPaymentTypeCode";
            colPaymentTypeCode.Visible = true;
            colPaymentTypeCode.VisibleIndex = 0;
            colPaymentTypeCode.Width = 136;
            // 
            // repoLUE_PaymentTypeCode
            // 
            repoLUE_PaymentTypeCode.AutoHeight = false;
            repoLUE_PaymentTypeCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoLUE_PaymentTypeCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_PaymentTypeCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentTypeCode", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentTypeDesc", "") });
            repoLUE_PaymentTypeCode.DisplayMember = "PaymentTypeDesc";
            repoLUE_PaymentTypeCode.Name = "repoLUE_PaymentTypeCode";
            repoLUE_PaymentTypeCode.NullText = "";
            repoLUE_PaymentTypeCode.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repoLUE_PaymentTypeCode.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            repoLUE_PaymentTypeCode.ValueMember = "PaymentTypeCode";
            // 
            // colReceivePayment
            // 
            colReceivePayment.ColumnEdit = repoCalcEdit_ReceivePayment;
            colReceivePayment.FieldName = "ReceivePayment";
            colReceivePayment.Name = "colReceivePayment";
            colReceivePayment.Visible = true;
            colReceivePayment.VisibleIndex = 1;
            colReceivePayment.Width = 106;
            // 
            // repoCalcEdit_ReceivePayment
            // 
            repoCalcEdit_ReceivePayment.AutoHeight = false;
            repoCalcEdit_ReceivePayment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_ReceivePayment.Name = "repoCalcEdit_ReceivePayment";
            // 
            // colMakePayment
            // 
            colMakePayment.ColumnEdit = repoCalcEdit_MakePayment;
            colMakePayment.FieldName = "MakePayment";
            colMakePayment.Name = "colMakePayment";
            colMakePayment.Visible = true;
            colMakePayment.VisibleIndex = 2;
            colMakePayment.Width = 93;
            // 
            // repoCalcEdit_MakePayment
            // 
            repoCalcEdit_MakePayment.AutoHeight = false;
            repoCalcEdit_MakePayment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_MakePayment.Name = "repoCalcEdit_MakePayment";
            // 
            // colPayment
            // 
            colPayment.ColumnEdit = repoCalcEdit_ReceivePayment;
            colPayment.FieldName = "Payment";
            colPayment.Name = "colPayment";
            colPayment.Width = 136;
            // 
            // colPaymentLoc
            // 
            colPaymentLoc.ColumnEdit = repoCalcEdit_MakePayment;
            colPaymentLoc.FieldName = "PaymentLoc";
            colPaymentLoc.Name = "colPaymentLoc";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.ColumnEdit = repoLUE_CurrencyCode;
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 3;
            colCurrencyCode.Width = 155;
            // 
            // repoLUE_CurrencyCode
            // 
            repoLUE_CurrencyCode.AutoHeight = false;
            repoLUE_CurrencyCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoLUE_CurrencyCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_CurrencyCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyDesc", "") });
            repoLUE_CurrencyCode.DisplayMember = "CurrencyDesc";
            repoLUE_CurrencyCode.Name = "repoLUE_CurrencyCode";
            repoLUE_CurrencyCode.NullText = "";
            repoLUE_CurrencyCode.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repoLUE_CurrencyCode.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            repoLUE_CurrencyCode.ValueMember = "CurrencyCode";
            repoLUE_CurrencyCode.EditValueChanged += repoLUE_CurrencyCode_EditValueChanged;
            // 
            // colLineDescription
            // 
            colLineDescription.FieldName = "LineDescription";
            colLineDescription.Name = "colLineDescription";
            colLineDescription.Visible = true;
            colLineDescription.VisibleIndex = 6;
            colLineDescription.Width = 98;
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            colExchangeRate.Visible = true;
            colExchangeRate.VisibleIndex = 4;
            colExchangeRate.Width = 157;
            // 
            // colCashRegisterCode
            // 
            colCashRegisterCode.ColumnEdit = repoBtnEdit_CashregisterCode;
            colCashRegisterCode.FieldName = "CashRegisterCode";
            colCashRegisterCode.Name = "colCashRegisterCode";
            colCashRegisterCode.Visible = true;
            colCashRegisterCode.VisibleIndex = 5;
            colCashRegisterCode.Width = 118;
            // 
            // repoBtnEdit_CashregisterCode
            // 
            repoBtnEdit_CashregisterCode.AutoHeight = false;
            repoBtnEdit_CashregisterCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_CashregisterCode.Name = "repoBtnEdit_CashregisterCode";
            repoBtnEdit_CashregisterCode.ButtonPressed += repoBtnEdit_CashregisterCode_ButtonPressed;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colBalanceBefor
            // 
            colBalanceBefor.FieldName = "BalanceBefor";
            colBalanceBefor.Name = "colBalanceBefor";
            colBalanceBefor.Visible = true;
            colBalanceBefor.VisibleIndex = 7;
            colBalanceBefor.Width = 89;
            // 
            // colBalanceAfter
            // 
            colBalanceAfter.FieldName = "BalanceAfter";
            colBalanceAfter.Name = "colBalanceAfter";
            colBalanceAfter.Visible = true;
            colBalanceAfter.VisibleIndex = 8;
            colBalanceAfter.Width = 88;
            // 
            // colPaymentMethodId
            // 
            colPaymentMethodId.Caption = "PaymentMethodCode";
            colPaymentMethodId.FieldName = "PaymentMethodId";
            colPaymentMethodId.Name = "colPaymentMethodId";
            // 
            // OperationDateDateEdit
            // 
            OperationDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "OperationDate", true));
            OperationDateDateEdit.EditValue = null;
            OperationDateDateEdit.Location = new System.Drawing.Point(98, 36);
            OperationDateDateEdit.MenuManager = ribbon;
            OperationDateDateEdit.Name = "OperationDateDateEdit";
            OperationDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            OperationDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            OperationDateDateEdit.Size = new System.Drawing.Size(349, 20);
            OperationDateDateEdit.StyleController = dataLayoutControl1;
            OperationDateDateEdit.TabIndex = 3;
            OperationDateDateEdit.KeyDown += dataLayout_KeyDown;
            // 
            // OperationTimeTimeSpanEdit
            // 
            OperationTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "OperationTime", true));
            OperationTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            OperationTimeTimeSpanEdit.Location = new System.Drawing.Point(98, 60);
            OperationTimeTimeSpanEdit.MenuManager = ribbon;
            OperationTimeTimeSpanEdit.Name = "OperationTimeTimeSpanEdit";
            OperationTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            OperationTimeTimeSpanEdit.Size = new System.Drawing.Size(349, 20);
            OperationTimeTimeSpanEdit.StyleController = dataLayoutControl1;
            OperationTimeTimeSpanEdit.TabIndex = 5;
            OperationTimeTimeSpanEdit.KeyDown += dataLayout_KeyDown;
            // 
            // DescriptionTextEdit
            // 
            DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "Description", true));
            DescriptionTextEdit.Location = new System.Drawing.Point(537, 60);
            DescriptionTextEdit.MenuManager = ribbon;
            DescriptionTextEdit.Name = "DescriptionTextEdit";
            DescriptionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            DescriptionTextEdit.Size = new System.Drawing.Size(350, 20);
            DescriptionTextEdit.StyleController = dataLayoutControl1;
            DescriptionTextEdit.TabIndex = 4;
            DescriptionTextEdit.KeyDown += dataLayout_KeyDown;
            // 
            // StoreCodeLookUpEdit
            // 
            StoreCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "StoreCode", true));
            StoreCodeLookUpEdit.Location = new System.Drawing.Point(537, 36);
            StoreCodeLookUpEdit.MenuManager = ribbon;
            StoreCodeLookUpEdit.Name = "StoreCodeLookUpEdit";
            StoreCodeLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            StoreCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StoreCodeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "Mağaza Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "Mağaza Adı") });
            StoreCodeLookUpEdit.Properties.DisplayMember = "CurrAccDesc";
            StoreCodeLookUpEdit.Properties.NullText = "";
            StoreCodeLookUpEdit.Properties.ValueMember = "CurrAccCode";
            StoreCodeLookUpEdit.Size = new System.Drawing.Size(350, 20);
            StoreCodeLookUpEdit.StyleController = dataLayoutControl1;
            StoreCodeLookUpEdit.TabIndex = 7;
            StoreCodeLookUpEdit.KeyDown += dataLayout_KeyDown;
            // 
            // CurrAccCodeButtonEdit
            // 
            CurrAccCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "CurrAccCode", true));
            CurrAccCodeButtonEdit.Location = new System.Drawing.Point(537, 12);
            CurrAccCodeButtonEdit.MenuManager = ribbon;
            CurrAccCodeButtonEdit.Name = "CurrAccCodeButtonEdit";
            CurrAccCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            CurrAccCodeButtonEdit.Size = new System.Drawing.Size(74, 20);
            CurrAccCodeButtonEdit.StyleController = dataLayoutControl1;
            CurrAccCodeButtonEdit.TabIndex = 2;
            CurrAccCodeButtonEdit.ButtonClick += CurrAccCodeButtonEdit_ButtonClick;
            CurrAccCodeButtonEdit.KeyDown += dataLayout_KeyDown;
            // 
            // btnEdit_DocNum
            // 
            btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "DocumentNumber", true));
            btnEdit_DocNum.Location = new System.Drawing.Point(98, 12);
            btnEdit_DocNum.MenuManager = ribbon;
            btnEdit_DocNum.Name = "btnEdit_DocNum";
            btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_DocNum.Size = new System.Drawing.Size(349, 20);
            btnEdit_DocNum.StyleController = dataLayoutControl1;
            btnEdit_DocNum.TabIndex = 0;
            btnEdit_DocNum.ButtonPressed += btnEdit_DocNum_ButtonPressed;
            btnEdit_DocNum.KeyDown += dataLayout_KeyDown;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(899, 396);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForOperationTime, ItemForCurrAccCode, layoutControlItem1, ItemForDescription, ItemForOperationDate, ItemForDocumentNumber, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem2, layoutControlItem6 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(879, 376);
            // 
            // ItemForOperationTime
            // 
            ItemForOperationTime.Control = OperationTimeTimeSpanEdit;
            ItemForOperationTime.Location = new System.Drawing.Point(0, 48);
            ItemForOperationTime.Name = "ItemForOperationTime";
            ItemForOperationTime.Size = new System.Drawing.Size(439, 24);
            ItemForOperationTime.Text = "Sənəd Vaxtı";
            ItemForOperationTime.TextSize = new System.Drawing.Size(74, 13);
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = CurrAccCodeButtonEdit;
            ItemForCurrAccCode.Location = new System.Drawing.Point(439, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new System.Drawing.Size(164, 24);
            ItemForCurrAccCode.Text = "Cari Hesab";
            ItemForCurrAccCode.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gC_PaymentLine;
            layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(879, 280);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // ItemForDescription
            // 
            ItemForDescription.Control = DescriptionTextEdit;
            ItemForDescription.Location = new System.Drawing.Point(439, 48);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new System.Drawing.Size(440, 24);
            ItemForDescription.Text = "Açıqlama";
            ItemForDescription.TextSize = new System.Drawing.Size(74, 13);
            // 
            // ItemForOperationDate
            // 
            ItemForOperationDate.Control = OperationDateDateEdit;
            ItemForOperationDate.Location = new System.Drawing.Point(0, 24);
            ItemForOperationDate.Name = "ItemForOperationDate";
            ItemForOperationDate.Size = new System.Drawing.Size(439, 24);
            ItemForOperationDate.Text = "Sənəd Tarixi";
            ItemForOperationDate.TextSize = new System.Drawing.Size(74, 13);
            // 
            // ItemForDocumentNumber
            // 
            ItemForDocumentNumber.Control = btnEdit_DocNum;
            ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
            ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            ItemForDocumentNumber.Size = new System.Drawing.Size(439, 24);
            ItemForDocumentNumber.Text = "Ödəniş Nömrəsi";
            ItemForDocumentNumber.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = lbl_CurrAccDesc;
            layoutControlItem3.Location = new System.Drawing.Point(603, 0);
            layoutControlItem3.MinSize = new System.Drawing.Size(67, 17);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(276, 24);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = lbl_CurrAccBalansAfter;
            layoutControlItem4.Location = new System.Drawing.Point(465, 352);
            layoutControlItem4.MinSize = new System.Drawing.Size(125, 17);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(414, 24);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = lbl_CurrAccBalansBefore;
            layoutControlItem5.Location = new System.Drawing.Point(0, 352);
            layoutControlItem5.MinSize = new System.Drawing.Size(125, 17);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(355, 24);
            layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = StoreCodeLookUpEdit;
            layoutControlItem2.Location = new System.Drawing.Point(439, 24);
            layoutControlItem2.Name = "ItemForStoreCode";
            layoutControlItem2.Size = new System.Drawing.Size(440, 24);
            layoutControlItem2.Text = "Mağaza";
            layoutControlItem2.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = checkEdit_IsSent;
            layoutControlItem6.Location = new System.Drawing.Point(355, 352);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(110, 24);
            layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem6.TextVisible = false;
            // 
            // FormPaymentDetail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(899, 578);
            Controls.Add(dataLayoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormPaymentDetail";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "Ödəmə";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)checkEdit_IsSent.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPaymentHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gC_PaymentLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPaymentLinesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_PaymentLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_PaymentTypeCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_ReceivePayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_MakePayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_CashregisterCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperationDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperationDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperationTimeTimeSpanEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DescriptionTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StoreCodeLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource trPaymentHeadersBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit OperationDateDateEdit;
        private DevExpress.XtraEditors.TimeSpanEdit OperationTimeTimeSpanEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOperationTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOperationDate;
        private DevExpress.XtraGrid.GridControl gC_PaymentLine;
        private System.Windows.Forms.BindingSource trPaymentLinesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PaymentLine;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bBI_DeletePayment;
        private DevExpress.XtraEditors.LookUpEdit StoreCodeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ButtonEdit CurrAccCodeButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colCashRegisterCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_PaymentTypeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_CurrencyCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_CashregisterCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
        private DevExpress.XtraBars.BarButtonItem bBI_SaveAndClose;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colMakePayment;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_DocNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_ReceivePayment;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_MakePayment;
        private DevExpress.XtraEditors.LabelControl lbl_CurrAccDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lbl_CurrAccBalansBefore;
        private DevExpress.XtraEditors.LabelControl lbl_CurrAccBalansAfter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.BarButtonItem bBI_SendWhatsapp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceBefor;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceAfter;
        private DevExpress.XtraBars.BarButtonItem bBI_NewPayment;
        private DevExpress.XtraBars.BarButtonItem bBI_CopyPayment;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_Report;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.CheckEdit checkEdit_IsSent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem BBI_Info;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodId;
    }
}