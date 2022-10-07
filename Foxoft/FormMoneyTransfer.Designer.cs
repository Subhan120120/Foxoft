
namespace Foxoft
{
   partial class FormMoneyTransfer
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
         this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_DeletePayment = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_SendWhatsapp = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_NewPayment = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CopyPayment = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
         this.lbl_CurrAccBalansBefore = new DevExpress.XtraEditors.LabelControl();
         this.lbl_CurrAccBalansAfter = new DevExpress.XtraEditors.LabelControl();
         this.lbl_FromCashRegDesc = new DevExpress.XtraEditors.LabelControl();
         this.lbl_ToCashRegDesc = new DevExpress.XtraEditors.LabelControl();
         this.gC_PaymentLine = new DevExpress.XtraGrid.GridControl();
         this.trPaymentLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_PaymentLine = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colPaymentLineId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoLUE_PaymentTypeCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
         this.colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoCalcEdit_ReceivePayment = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
         this.colPaymentLoc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoCalcEdit_MakePayment = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
         this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
         this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCashRegisterCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoBtnEdit_CashregisterCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
         this.colBalanceBefor = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colBalanceAfter = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colReceivePayment = new DevExpress.XtraGrid.Columns.GridColumn();
         this.OperationDateDateEdit = new DevExpress.XtraEditors.DateEdit();
         this.trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.OperationTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
         this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
         this.CurrAccCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
         this.btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
         this.ToCashRegCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
         this.FromCashRegCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
         this.ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForToCashRegCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForOperationTime = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForFromCashRegCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForOperationDate = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
         this.dataLayoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentLine)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentLine)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLUE_PaymentTypeCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_ReceivePayment)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_MakePayment)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLUE_CurrencyCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_CashregisterCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.OperationTimeTimeSpanEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.CurrAccCodeButtonEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ToCashRegCodeButtonEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FromCashRegCodeButtonEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForToCashRegCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationTime)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForFromCashRegCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationDate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         this.SuspendLayout();
         // 
         // ribbon
         // 
         this.ribbon.ExpandCollapseItem.Id = 0;
         this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.bBI_DeletePayment,
            this.bBI_SaveAndClose,
            this.bBI_SendWhatsapp,
            this.bBI_NewPayment,
            this.bBI_CopyPayment});
         this.ribbon.Location = new System.Drawing.Point(0, 0);
         this.ribbon.MaxItemId = 7;
         this.ribbon.Name = "ribbon";
         this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbon.Size = new System.Drawing.Size(899, 158);
         this.ribbon.StatusBar = this.ribbonStatusBar;
         // 
         // bBI_DeletePayment
         // 
         this.bBI_DeletePayment.Caption = "Ödənişi Sil";
         this.bBI_DeletePayment.Id = 1;
         this.bBI_DeletePayment.Name = "bBI_DeletePayment";
         this.bBI_DeletePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DeletePayment_ItemClick);
         // 
         // bBI_SaveAndClose
         // 
         this.bBI_SaveAndClose.Caption = "Yadda Saxla Bağla";
         this.bBI_SaveAndClose.Id = 2;
         this.bBI_SaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
         this.bBI_SaveAndClose.Name = "bBI_SaveAndClose";
         this.bBI_SaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SaveAndClose_ItemClick);
         // 
         // bBI_SendWhatsapp
         // 
         this.bBI_SendWhatsapp.Caption = "Whatsapa Göndər";
         this.bBI_SendWhatsapp.Id = 3;
         this.bBI_SendWhatsapp.Name = "bBI_SendWhatsapp";
         this.bBI_SendWhatsapp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SendWhatsapp_ItemClick);
         // 
         // bBI_NewPayment
         // 
         this.bBI_NewPayment.Caption = "Yeni Ödəniş";
         this.bBI_NewPayment.Id = 5;
         this.bBI_NewPayment.Name = "bBI_NewPayment";
         this.bBI_NewPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_NewPayment_ItemClick);
         // 
         // bBI_CopyPayment
         // 
         this.bBI_CopyPayment.Caption = "Kopyala";
         this.bBI_CopyPayment.Id = 6;
         this.bBI_CopyPayment.Name = "bBI_CopyPayment";
         this.bBI_CopyPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CopyPayment_ItemClick);
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
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_SaveAndClose);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_NewPayment);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_DeletePayment);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "Ödəmə";
         // 
         // ribbonPageGroup2
         // 
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_SendWhatsapp);
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_CopyPayment);
         this.ribbonPageGroup2.Name = "ribbonPageGroup2";
         this.ribbonPageGroup2.Text = "Alət";
         // 
         // ribbonStatusBar
         // 
         this.ribbonStatusBar.Location = new System.Drawing.Point(0, 554);
         this.ribbonStatusBar.Name = "ribbonStatusBar";
         this.ribbonStatusBar.Ribbon = this.ribbon;
         this.ribbonStatusBar.Size = new System.Drawing.Size(899, 24);
         // 
         // dataLayoutControl1
         // 
         this.dataLayoutControl1.Controls.Add(this.lbl_CurrAccBalansBefore);
         this.dataLayoutControl1.Controls.Add(this.lbl_CurrAccBalansAfter);
         this.dataLayoutControl1.Controls.Add(this.lbl_FromCashRegDesc);
         this.dataLayoutControl1.Controls.Add(this.lbl_ToCashRegDesc);
         this.dataLayoutControl1.Controls.Add(this.gC_PaymentLine);
         this.dataLayoutControl1.Controls.Add(this.OperationDateDateEdit);
         this.dataLayoutControl1.Controls.Add(this.OperationTimeTimeSpanEdit);
         this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
         this.dataLayoutControl1.Controls.Add(this.CurrAccCodeButtonEdit);
         this.dataLayoutControl1.Controls.Add(this.btnEdit_DocNum);
         this.dataLayoutControl1.Controls.Add(this.ToCashRegCodeButtonEdit);
         this.dataLayoutControl1.Controls.Add(this.FromCashRegCodeButtonEdit);
         this.dataLayoutControl1.DataSource = this.trPaymentHeadersBindingSource;
         this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCurrAccCode});
         this.dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
         this.dataLayoutControl1.Name = "dataLayoutControl1";
         this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1249, 262, 650, 400);
         this.dataLayoutControl1.Root = this.Root;
         this.dataLayoutControl1.Size = new System.Drawing.Size(899, 396);
         this.dataLayoutControl1.TabIndex = 2;
         this.dataLayoutControl1.Text = "Kassadan";
         // 
         // lbl_CurrAccBalansBefore
         // 
         this.lbl_CurrAccBalansBefore.Location = new System.Drawing.Point(12, 369);
         this.lbl_CurrAccBalansBefore.Name = "lbl_CurrAccBalansBefore";
         this.lbl_CurrAccBalansBefore.Size = new System.Drawing.Size(435, 15);
         this.lbl_CurrAccBalansBefore.StyleController = this.dataLayoutControl1;
         this.lbl_CurrAccBalansBefore.TabIndex = 1;
         this.lbl_CurrAccBalansBefore.Text = "Cari Hesab Əvvəlki Borc: ";
         // 
         // lbl_CurrAccBalansAfter
         // 
         this.lbl_CurrAccBalansAfter.Location = new System.Drawing.Point(451, 369);
         this.lbl_CurrAccBalansAfter.Name = "lbl_CurrAccBalansAfter";
         this.lbl_CurrAccBalansAfter.Size = new System.Drawing.Size(436, 15);
         this.lbl_CurrAccBalansAfter.StyleController = this.dataLayoutControl1;
         this.lbl_CurrAccBalansAfter.TabIndex = 1;
         this.lbl_CurrAccBalansAfter.Text = "Cari Hesab Sonrakı Borc: ";
         // 
         // lbl_FromCashRegDesc
         // 
         this.lbl_FromCashRegDesc.Location = new System.Drawing.Point(623, 12);
         this.lbl_FromCashRegDesc.Name = "lbl_FromCashRegDesc";
         this.lbl_FromCashRegDesc.Size = new System.Drawing.Size(264, 20);
         this.lbl_FromCashRegDesc.StyleController = this.dataLayoutControl1;
         this.lbl_FromCashRegDesc.TabIndex = 1;
         // 
         // lbl_ToCashRegDesc
         // 
         this.lbl_ToCashRegDesc.Location = new System.Drawing.Point(623, 36);
         this.lbl_ToCashRegDesc.Name = "lbl_ToCashRegDesc";
         this.lbl_ToCashRegDesc.Size = new System.Drawing.Size(264, 20);
         this.lbl_ToCashRegDesc.StyleController = this.dataLayoutControl1;
         this.lbl_ToCashRegDesc.TabIndex = 1;
         // 
         // gC_PaymentLine
         // 
         this.gC_PaymentLine.DataSource = this.trPaymentLinesBindingSource;
         this.gC_PaymentLine.Location = new System.Drawing.Point(12, 84);
         this.gC_PaymentLine.MainView = this.gV_PaymentLine;
         this.gC_PaymentLine.MenuManager = this.ribbon;
         this.gC_PaymentLine.Name = "gC_PaymentLine";
         this.gC_PaymentLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoLUE_CurrencyCode,
            this.repoCalcEdit_ReceivePayment,
            this.repoCalcEdit_MakePayment,
            this.repoBtnEdit_CashregisterCode,
            this.repoLUE_PaymentTypeCode});
         this.gC_PaymentLine.Size = new System.Drawing.Size(875, 281);
         this.gC_PaymentLine.TabIndex = 7;
         this.gC_PaymentLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_PaymentLine});
         this.gC_PaymentLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gC_PaymentLine_KeyDown);
         // 
         // trPaymentLinesBindingSource
         // 
         this.trPaymentLinesBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentLine);
         // 
         // gV_PaymentLine
         // 
         this.gV_PaymentLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentLineId,
            this.colPaymentHeaderId,
            this.colPaymentTypeCode,
            this.colPayment,
            this.colPaymentLoc,
            this.colCurrencyCode,
            this.colLineDescription,
            this.colExchangeRate,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate,
            this.colCashRegisterCode,
            this.colBalanceBefor,
            this.colBalanceAfter,
            this.colReceivePayment});
         this.gV_PaymentLine.CustomizationFormBounds = new System.Drawing.Rectangle(953, 390, 264, 272);
         this.gV_PaymentLine.GridControl = this.gC_PaymentLine;
         this.gV_PaymentLine.Name = "gV_PaymentLine";
         this.gV_PaymentLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
         this.gV_PaymentLine.OptionsNavigation.AutoFocusNewRow = true;
         this.gV_PaymentLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
         this.gV_PaymentLine.OptionsView.ShowGroupPanel = false;
         this.gV_PaymentLine.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gV_PaymentLine_InitNewRow);
         this.gV_PaymentLine.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_PaymentLine_CellValueChanging);
         this.gV_PaymentLine.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gV_PaymentLine_RowDeleted);
         this.gV_PaymentLine.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gV_PaymentLine_RowUpdated);
         // 
         // colPaymentLineId
         // 
         this.colPaymentLineId.FieldName = "PaymentLineId";
         this.colPaymentLineId.Name = "colPaymentLineId";
         // 
         // colPaymentHeaderId
         // 
         this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
         this.colPaymentHeaderId.Name = "colPaymentHeaderId";
         // 
         // colPaymentTypeCode
         // 
         this.colPaymentTypeCode.ColumnEdit = this.repoLUE_PaymentTypeCode;
         this.colPaymentTypeCode.FieldName = "PaymentTypeCode";
         this.colPaymentTypeCode.Name = "colPaymentTypeCode";
         this.colPaymentTypeCode.Visible = true;
         this.colPaymentTypeCode.VisibleIndex = 0;
         this.colPaymentTypeCode.Width = 136;
         // 
         // repoLUE_PaymentTypeCode
         // 
         this.repoLUE_PaymentTypeCode.AutoHeight = false;
         this.repoLUE_PaymentTypeCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
         this.repoLUE_PaymentTypeCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repoLUE_PaymentTypeCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentTypeCode", ""),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentTypeDesc", "")});
         this.repoLUE_PaymentTypeCode.DisplayMember = "PaymentTypeDesc";
         this.repoLUE_PaymentTypeCode.Name = "repoLUE_PaymentTypeCode";
         this.repoLUE_PaymentTypeCode.NullText = "";
         this.repoLUE_PaymentTypeCode.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
         this.repoLUE_PaymentTypeCode.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
         this.repoLUE_PaymentTypeCode.ValueMember = "PaymentTypeCode";
         // 
         // colPayment
         // 
         this.colPayment.ColumnEdit = this.repoCalcEdit_ReceivePayment;
         this.colPayment.FieldName = "Payment";
         this.colPayment.Name = "colPayment";
         this.colPayment.Visible = true;
         this.colPayment.VisibleIndex = 1;
         this.colPayment.Width = 136;
         // 
         // repoCalcEdit_ReceivePayment
         // 
         this.repoCalcEdit_ReceivePayment.AutoHeight = false;
         this.repoCalcEdit_ReceivePayment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repoCalcEdit_ReceivePayment.Name = "repoCalcEdit_ReceivePayment";
         // 
         // colPaymentLoc
         // 
         this.colPaymentLoc.ColumnEdit = this.repoCalcEdit_MakePayment;
         this.colPaymentLoc.FieldName = "PaymentLoc";
         this.colPaymentLoc.Name = "colPaymentLoc";
         // 
         // repoCalcEdit_MakePayment
         // 
         this.repoCalcEdit_MakePayment.AutoHeight = false;
         this.repoCalcEdit_MakePayment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repoCalcEdit_MakePayment.Name = "repoCalcEdit_MakePayment";
         // 
         // colCurrencyCode
         // 
         this.colCurrencyCode.ColumnEdit = this.repoLUE_CurrencyCode;
         this.colCurrencyCode.FieldName = "CurrencyCode";
         this.colCurrencyCode.Name = "colCurrencyCode";
         this.colCurrencyCode.Visible = true;
         this.colCurrencyCode.VisibleIndex = 2;
         this.colCurrencyCode.Width = 155;
         // 
         // repoLUE_CurrencyCode
         // 
         this.repoLUE_CurrencyCode.AutoHeight = false;
         this.repoLUE_CurrencyCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
         this.repoLUE_CurrencyCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repoLUE_CurrencyCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", ""),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyDesc", "")});
         this.repoLUE_CurrencyCode.DisplayMember = "CurrencyDesc";
         this.repoLUE_CurrencyCode.Name = "repoLUE_CurrencyCode";
         this.repoLUE_CurrencyCode.NullText = "";
         this.repoLUE_CurrencyCode.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
         this.repoLUE_CurrencyCode.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
         this.repoLUE_CurrencyCode.ValueMember = "CurrencyCode";
         this.repoLUE_CurrencyCode.EditValueChanged += new System.EventHandler(this.repoLUE_CurrencyCode_EditValueChanged);
         // 
         // colLineDescription
         // 
         this.colLineDescription.FieldName = "LineDescription";
         this.colLineDescription.Name = "colLineDescription";
         this.colLineDescription.Visible = true;
         this.colLineDescription.VisibleIndex = 4;
         this.colLineDescription.Width = 97;
         // 
         // colExchangeRate
         // 
         this.colExchangeRate.FieldName = "ExchangeRate";
         this.colExchangeRate.Name = "colExchangeRate";
         this.colExchangeRate.Visible = true;
         this.colExchangeRate.VisibleIndex = 3;
         this.colExchangeRate.Width = 157;
         // 
         // colCreatedUserName
         // 
         this.colCreatedUserName.FieldName = "CreatedUserName";
         this.colCreatedUserName.Name = "colCreatedUserName";
         // 
         // colCreatedDate
         // 
         this.colCreatedDate.FieldName = "CreatedDate";
         this.colCreatedDate.Name = "colCreatedDate";
         // 
         // colLastUpdatedUserName
         // 
         this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
         this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
         // 
         // colLastUpdatedDate
         // 
         this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
         this.colLastUpdatedDate.Name = "colLastUpdatedDate";
         // 
         // colCashRegisterCode
         // 
         this.colCashRegisterCode.ColumnEdit = this.repoBtnEdit_CashregisterCode;
         this.colCashRegisterCode.FieldName = "CashRegisterCode";
         this.colCashRegisterCode.Name = "colCashRegisterCode";
         // 
         // repoBtnEdit_CashregisterCode
         // 
         this.repoBtnEdit_CashregisterCode.AutoHeight = false;
         this.repoBtnEdit_CashregisterCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.repoBtnEdit_CashregisterCode.Name = "repoBtnEdit_CashregisterCode";
         // 
         // colBalanceBefor
         // 
         this.colBalanceBefor.FieldName = "BalanceBefor";
         this.colBalanceBefor.Name = "colBalanceBefor";
         this.colBalanceBefor.Visible = true;
         this.colBalanceBefor.VisibleIndex = 5;
         // 
         // colBalanceAfter
         // 
         this.colBalanceAfter.FieldName = "BalanceAfter";
         this.colBalanceAfter.Name = "colBalanceAfter";
         this.colBalanceAfter.Visible = true;
         this.colBalanceAfter.VisibleIndex = 6;
         // 
         // colReceivePayment
         // 
         this.colReceivePayment.FieldName = "ReceivePayment";
         this.colReceivePayment.Name = "colReceivePayment";
         // 
         // OperationDateDateEdit
         // 
         this.OperationDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "OperationDate", true));
         this.OperationDateDateEdit.EditValue = null;
         this.OperationDateDateEdit.Location = new System.Drawing.Point(98, 36);
         this.OperationDateDateEdit.MenuManager = this.ribbon;
         this.OperationDateDateEdit.Name = "OperationDateDateEdit";
         this.OperationDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.OperationDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.OperationDateDateEdit.Size = new System.Drawing.Size(349, 20);
         this.OperationDateDateEdit.StyleController = this.dataLayoutControl1;
         this.OperationDateDateEdit.TabIndex = 5;
         this.OperationDateDateEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayout_KeyDown);
         // 
         // trPaymentHeadersBindingSource
         // 
         this.trPaymentHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentHeader);
         this.trPaymentHeadersBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.trPaymentHeadersBindingSource_AddingNew);
         this.trPaymentHeadersBindingSource.CurrentItemChanged += new System.EventHandler(this.trPaymentHeadersBindingSource_CurrentItemChanged);
         // 
         // OperationTimeTimeSpanEdit
         // 
         this.OperationTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "OperationTime", true));
         this.OperationTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
         this.OperationTimeTimeSpanEdit.Location = new System.Drawing.Point(98, 60);
         this.OperationTimeTimeSpanEdit.MenuManager = this.ribbon;
         this.OperationTimeTimeSpanEdit.Name = "OperationTimeTimeSpanEdit";
         this.OperationTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.OperationTimeTimeSpanEdit.Size = new System.Drawing.Size(349, 20);
         this.OperationTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
         this.OperationTimeTimeSpanEdit.TabIndex = 4;
         this.OperationTimeTimeSpanEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayout_KeyDown);
         // 
         // DescriptionTextEdit
         // 
         this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "Description", true));
         this.DescriptionTextEdit.Location = new System.Drawing.Point(537, 60);
         this.DescriptionTextEdit.MenuManager = this.ribbon;
         this.DescriptionTextEdit.Name = "DescriptionTextEdit";
         this.DescriptionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
         this.DescriptionTextEdit.Size = new System.Drawing.Size(350, 20);
         this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
         this.DescriptionTextEdit.TabIndex = 6;
         this.DescriptionTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayout_KeyDown);
         // 
         // CurrAccCodeButtonEdit
         // 
         this.CurrAccCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "CurrAccCode", true));
         this.CurrAccCodeButtonEdit.Location = new System.Drawing.Point(537, 36);
         this.CurrAccCodeButtonEdit.MenuManager = this.ribbon;
         this.CurrAccCodeButtonEdit.Name = "CurrAccCodeButtonEdit";
         this.CurrAccCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.CurrAccCodeButtonEdit.Size = new System.Drawing.Size(67, 20);
         this.CurrAccCodeButtonEdit.StyleController = this.dataLayoutControl1;
         this.CurrAccCodeButtonEdit.TabIndex = 1;
         this.CurrAccCodeButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.CurrAccCodeButtonEdit_ButtonClick);
         this.CurrAccCodeButtonEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayout_KeyDown);
         // 
         // btnEdit_DocNum
         // 
         this.btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "DocumentNumber", true));
         this.btnEdit_DocNum.Location = new System.Drawing.Point(98, 12);
         this.btnEdit_DocNum.MenuManager = this.ribbon;
         this.btnEdit_DocNum.Name = "btnEdit_DocNum";
         this.btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
         this.btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.btnEdit_DocNum.Size = new System.Drawing.Size(349, 20);
         this.btnEdit_DocNum.StyleController = this.dataLayoutControl1;
         this.btnEdit_DocNum.TabIndex = 0;
         this.btnEdit_DocNum.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_DocNum_ButtonPressed);
         this.btnEdit_DocNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayout_KeyDown);
         // 
         // ToCashRegCodeButtonEdit
         // 
         this.ToCashRegCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "ToCashRegCode", true));
         this.ToCashRegCodeButtonEdit.Location = new System.Drawing.Point(537, 36);
         this.ToCashRegCodeButtonEdit.MenuManager = this.ribbon;
         this.ToCashRegCodeButtonEdit.Name = "ToCashRegCodeButtonEdit";
         this.ToCashRegCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.ToCashRegCodeButtonEdit.Size = new System.Drawing.Size(82, 20);
         this.ToCashRegCodeButtonEdit.StyleController = this.dataLayoutControl1;
         this.ToCashRegCodeButtonEdit.TabIndex = 3;
         this.ToCashRegCodeButtonEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ToCashRegCodeButtonEdit_ButtonPressed);
         // 
         // FromCashRegCodeButtonEdit
         // 
         this.FromCashRegCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "FromCashRegCode", true));
         this.FromCashRegCodeButtonEdit.Location = new System.Drawing.Point(537, 12);
         this.FromCashRegCodeButtonEdit.MenuManager = this.ribbon;
         this.FromCashRegCodeButtonEdit.Name = "FromCashRegCodeButtonEdit";
         this.FromCashRegCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.FromCashRegCodeButtonEdit.Size = new System.Drawing.Size(82, 20);
         this.FromCashRegCodeButtonEdit.StyleController = this.dataLayoutControl1;
         this.FromCashRegCodeButtonEdit.TabIndex = 2;
         this.FromCashRegCodeButtonEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.FromCashRegCodeButtonEdit_ButtonPressed);
         // 
         // ItemForCurrAccCode
         // 
         this.ItemForCurrAccCode.Control = this.CurrAccCodeButtonEdit;
         this.ItemForCurrAccCode.Location = new System.Drawing.Point(439, 24);
         this.ItemForCurrAccCode.Name = "ItemForCurrAccCode";
         this.ItemForCurrAccCode.Size = new System.Drawing.Size(157, 24);
         this.ItemForCurrAccCode.Text = "Cari Hesab";
         this.ItemForCurrAccCode.TextSize = new System.Drawing.Size(74, 13);
         // 
         // Root
         // 
         this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.Root.GroupBordersVisible = false;
         this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
         this.Root.Name = "Root";
         this.Root.Size = new System.Drawing.Size(899, 396);
         this.Root.TextVisible = false;
         // 
         // layoutControlGroup1
         // 
         this.layoutControlGroup1.AllowDrawBackground = false;
         this.layoutControlGroup1.GroupBordersVisible = false;
         this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.ItemForDocumentNumber,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.ItemForToCashRegCode,
            this.ItemForOperationTime,
            this.ItemForDescription,
            this.ItemForFromCashRegCode,
            this.ItemForOperationDate,
            this.layoutControlItem2,
            this.layoutControlItem3});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "autoGeneratedGroup0";
         this.layoutControlGroup1.Size = new System.Drawing.Size(879, 376);
         // 
         // layoutControlItem1
         // 
         this.layoutControlItem1.Control = this.gC_PaymentLine;
         this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
         this.layoutControlItem1.Name = "layoutControlItem1";
         this.layoutControlItem1.Size = new System.Drawing.Size(879, 285);
         this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem1.TextVisible = false;
         // 
         // ItemForDocumentNumber
         // 
         this.ItemForDocumentNumber.Control = this.btnEdit_DocNum;
         this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
         this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
         this.ItemForDocumentNumber.Size = new System.Drawing.Size(439, 24);
         this.ItemForDocumentNumber.Text = "Ödəniş Nömrəsi";
         this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(74, 13);
         // 
         // layoutControlItem4
         // 
         this.layoutControlItem4.Control = this.lbl_CurrAccBalansAfter;
         this.layoutControlItem4.Location = new System.Drawing.Point(439, 357);
         this.layoutControlItem4.MinSize = new System.Drawing.Size(125, 17);
         this.layoutControlItem4.Name = "layoutControlItem4";
         this.layoutControlItem4.Size = new System.Drawing.Size(440, 19);
         this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem4.TextVisible = false;
         // 
         // layoutControlItem5
         // 
         this.layoutControlItem5.Control = this.lbl_CurrAccBalansBefore;
         this.layoutControlItem5.Location = new System.Drawing.Point(0, 357);
         this.layoutControlItem5.MinSize = new System.Drawing.Size(125, 17);
         this.layoutControlItem5.Name = "layoutControlItem5";
         this.layoutControlItem5.Size = new System.Drawing.Size(439, 19);
         this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem5.TextVisible = false;
         // 
         // ItemForToCashRegCode
         // 
         this.ItemForToCashRegCode.Control = this.ToCashRegCodeButtonEdit;
         this.ItemForToCashRegCode.Location = new System.Drawing.Point(439, 24);
         this.ItemForToCashRegCode.Name = "ItemForToCashRegCode";
         this.ItemForToCashRegCode.Size = new System.Drawing.Size(172, 24);
         this.ItemForToCashRegCode.Text = "Kassaya";
         this.ItemForToCashRegCode.TextSize = new System.Drawing.Size(74, 13);
         // 
         // ItemForOperationTime
         // 
         this.ItemForOperationTime.Control = this.OperationTimeTimeSpanEdit;
         this.ItemForOperationTime.Location = new System.Drawing.Point(0, 48);
         this.ItemForOperationTime.Name = "ItemForOperationTime";
         this.ItemForOperationTime.Size = new System.Drawing.Size(439, 24);
         this.ItemForOperationTime.Text = "Sənəd Vaxtı";
         this.ItemForOperationTime.TextSize = new System.Drawing.Size(74, 13);
         // 
         // ItemForDescription
         // 
         this.ItemForDescription.Control = this.DescriptionTextEdit;
         this.ItemForDescription.Location = new System.Drawing.Point(439, 48);
         this.ItemForDescription.Name = "ItemForDescription";
         this.ItemForDescription.Size = new System.Drawing.Size(440, 24);
         this.ItemForDescription.Text = "Açıqlama";
         this.ItemForDescription.TextSize = new System.Drawing.Size(74, 13);
         // 
         // ItemForFromCashRegCode
         // 
         this.ItemForFromCashRegCode.Control = this.FromCashRegCodeButtonEdit;
         this.ItemForFromCashRegCode.Location = new System.Drawing.Point(439, 0);
         this.ItemForFromCashRegCode.Name = "ItemForFromCashRegCode";
         this.ItemForFromCashRegCode.Size = new System.Drawing.Size(172, 24);
         this.ItemForFromCashRegCode.Text = "Kassadan";
         this.ItemForFromCashRegCode.TextSize = new System.Drawing.Size(74, 13);
         // 
         // ItemForOperationDate
         // 
         this.ItemForOperationDate.Control = this.OperationDateDateEdit;
         this.ItemForOperationDate.Location = new System.Drawing.Point(0, 24);
         this.ItemForOperationDate.Name = "ItemForOperationDate";
         this.ItemForOperationDate.Size = new System.Drawing.Size(439, 24);
         this.ItemForOperationDate.Text = "Sənəd Tarixi";
         this.ItemForOperationDate.TextSize = new System.Drawing.Size(74, 13);
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.lbl_FromCashRegDesc;
         this.layoutControlItem2.Location = new System.Drawing.Point(611, 0);
         this.layoutControlItem2.MinSize = new System.Drawing.Size(4, 17);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(268, 24);
         this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem2.TextVisible = false;
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.lbl_ToCashRegDesc;
         this.layoutControlItem3.Location = new System.Drawing.Point(611, 24);
         this.layoutControlItem3.MinSize = new System.Drawing.Size(67, 17);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(268, 24);
         this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         // 
         // FormMoneyTransfer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(899, 578);
         this.Controls.Add(this.dataLayoutControl1);
         this.Controls.Add(this.ribbonStatusBar);
         this.Controls.Add(this.ribbon);
         this.Name = "FormMoneyTransfer";
         this.Ribbon = this.ribbon;
         this.StatusBar = this.ribbonStatusBar;
         this.Text = "Kassalar Arası Transfer";
         ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
         this.dataLayoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentLine)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentLine)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLUE_PaymentTypeCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_ReceivePayment)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_MakePayment)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLUE_CurrencyCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_CashregisterCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.OperationTimeTimeSpanEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.CurrAccCodeButtonEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ToCashRegCodeButtonEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FromCashRegCodeButtonEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForToCashRegCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationTime)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForFromCashRegCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationDate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

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
      private DevExpress.XtraEditors.ButtonEdit CurrAccCodeButtonEdit;
      private DevExpress.XtraGrid.Columns.GridColumn colPaymentLoc;
      private DevExpress.XtraGrid.Columns.GridColumn colCashRegisterCode;
      private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_PaymentTypeCode;
      private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_CurrencyCode;
      private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_CashregisterCode;
      private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
      private DevExpress.XtraBars.BarButtonItem bBI_SaveAndClose;
      private DevExpress.XtraEditors.ButtonEdit btnEdit_DocNum;
      private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_ReceivePayment;
      private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_MakePayment;
      private DevExpress.XtraEditors.LabelControl lbl_ToCashRegDesc;
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
      private DevExpress.XtraEditors.LabelControl lbl_FromCashRegDesc;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      private DevExpress.XtraLayout.LayoutControlItem ItemForToCashRegCode;
      private DevExpress.XtraLayout.LayoutControlItem ItemForFromCashRegCode;
      private DevExpress.XtraEditors.ButtonEdit ToCashRegCodeButtonEdit;
      private DevExpress.XtraEditors.ButtonEdit FromCashRegCodeButtonEdit;
      private DevExpress.XtraGrid.Columns.GridColumn colReceivePayment;
   }
}