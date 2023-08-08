
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
            components = new System.ComponentModel.Container();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_DeletePayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            bBI_SendWhatsapp = new DevExpress.XtraBars.BarButtonItem();
            bBI_NewPayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_CopyPayment = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            lbl_CurrAccBalansBefore = new DevExpress.XtraEditors.LabelControl();
            lbl_CurrAccBalansAfter = new DevExpress.XtraEditors.LabelControl();
            lbl_FromCashRegDesc = new DevExpress.XtraEditors.LabelControl();
            lbl_ToCashRegDesc = new DevExpress.XtraEditors.LabelControl();
            gC_PaymentLine = new DevExpress.XtraGrid.GridControl();
            trPaymentLinesBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_PaymentLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPaymentLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_PaymentTypeCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_ReceivePayment = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colPaymentLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_MakePayment = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCashRegisterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_CashregisterCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colBalanceBefor = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalanceAfter = new DevExpress.XtraGrid.Columns.GridColumn();
            colReceivePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            OperationDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(components);
            OperationTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            CurrAccCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            ToCashRegCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            FromCashRegCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForToCashRegCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForOperationTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForFromCashRegCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForOperationDate = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            colPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)trPaymentHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperationTimeTimeSpanEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DescriptionTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ToCashRegCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FromCashRegCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForToCashRegCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForFromCashRegCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, ribbon.SearchEditItem, bBI_DeletePayment, bBI_SaveAndClose, bBI_SendWhatsapp, bBI_NewPayment, bBI_CopyPayment });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 7;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new System.Drawing.Size(899, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // bBI_DeletePayment
            // 
            bBI_DeletePayment.Caption = "Ödənişi Sil";
            bBI_DeletePayment.Id = 1;
            bBI_DeletePayment.Name = "bBI_DeletePayment";
            bBI_DeletePayment.ItemClick += bBI_DeletePayment_ItemClick;
            // 
            // bBI_SaveAndClose
            // 
            bBI_SaveAndClose.Caption = "Yadda Saxla Bağla";
            bBI_SaveAndClose.Id = 2;
            bBI_SaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            bBI_SaveAndClose.Name = "bBI_SaveAndClose";
            bBI_SaveAndClose.ItemClick += bBI_SaveAndClose_ItemClick;
            // 
            // bBI_SendWhatsapp
            // 
            bBI_SendWhatsapp.Caption = "Whatsapa Göndər";
            bBI_SendWhatsapp.Id = 3;
            bBI_SendWhatsapp.Name = "bBI_SendWhatsapp";
            bBI_SendWhatsapp.ItemClick += bBI_SendWhatsapp_ItemClick;
            // 
            // bBI_NewPayment
            // 
            bBI_NewPayment.Caption = "Yeni Ödəniş";
            bBI_NewPayment.Id = 5;
            bBI_NewPayment.Name = "bBI_NewPayment";
            bBI_NewPayment.ItemClick += bBI_NewPayment_ItemClick;
            // 
            // bBI_CopyPayment
            // 
            bBI_CopyPayment.Caption = "Kopyala";
            bBI_CopyPayment.Id = 6;
            bBI_CopyPayment.Name = "bBI_CopyPayment";
            bBI_CopyPayment.ItemClick += bBI_CopyPayment_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
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
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Alət";
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
            dataLayoutControl1.Controls.Add(lbl_CurrAccBalansBefore);
            dataLayoutControl1.Controls.Add(lbl_CurrAccBalansAfter);
            dataLayoutControl1.Controls.Add(lbl_FromCashRegDesc);
            dataLayoutControl1.Controls.Add(lbl_ToCashRegDesc);
            dataLayoutControl1.Controls.Add(gC_PaymentLine);
            dataLayoutControl1.Controls.Add(OperationDateDateEdit);
            dataLayoutControl1.Controls.Add(OperationTimeTimeSpanEdit);
            dataLayoutControl1.Controls.Add(DescriptionTextEdit);
            dataLayoutControl1.Controls.Add(CurrAccCodeButtonEdit);
            dataLayoutControl1.Controls.Add(btnEdit_DocNum);
            dataLayoutControl1.Controls.Add(ToCashRegCodeButtonEdit);
            dataLayoutControl1.Controls.Add(FromCashRegCodeButtonEdit);
            dataLayoutControl1.DataSource = trPaymentHeadersBindingSource;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForCurrAccCode });
            dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1249, 262, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(899, 396);
            dataLayoutControl1.TabIndex = 2;
            dataLayoutControl1.Text = "Kassadan";
            // 
            // lbl_CurrAccBalansBefore
            // 
            lbl_CurrAccBalansBefore.Location = new System.Drawing.Point(12, 369);
            lbl_CurrAccBalansBefore.Name = "lbl_CurrAccBalansBefore";
            lbl_CurrAccBalansBefore.Size = new System.Drawing.Size(435, 15);
            lbl_CurrAccBalansBefore.StyleController = dataLayoutControl1;
            lbl_CurrAccBalansBefore.TabIndex = 1;
            lbl_CurrAccBalansBefore.Text = "Cari Hesab Əvvəlki Borc: ";
            // 
            // lbl_CurrAccBalansAfter
            // 
            lbl_CurrAccBalansAfter.Location = new System.Drawing.Point(451, 369);
            lbl_CurrAccBalansAfter.Name = "lbl_CurrAccBalansAfter";
            lbl_CurrAccBalansAfter.Size = new System.Drawing.Size(436, 15);
            lbl_CurrAccBalansAfter.StyleController = dataLayoutControl1;
            lbl_CurrAccBalansAfter.TabIndex = 1;
            lbl_CurrAccBalansAfter.Text = "Cari Hesab Sonrakı Borc: ";
            // 
            // lbl_FromCashRegDesc
            // 
            lbl_FromCashRegDesc.Location = new System.Drawing.Point(623, 12);
            lbl_FromCashRegDesc.Name = "lbl_FromCashRegDesc";
            lbl_FromCashRegDesc.Size = new System.Drawing.Size(264, 20);
            lbl_FromCashRegDesc.StyleController = dataLayoutControl1;
            lbl_FromCashRegDesc.TabIndex = 1;
            // 
            // lbl_ToCashRegDesc
            // 
            lbl_ToCashRegDesc.Location = new System.Drawing.Point(623, 36);
            lbl_ToCashRegDesc.Name = "lbl_ToCashRegDesc";
            lbl_ToCashRegDesc.Size = new System.Drawing.Size(264, 20);
            lbl_ToCashRegDesc.StyleController = dataLayoutControl1;
            lbl_ToCashRegDesc.TabIndex = 1;
            // 
            // gC_PaymentLine
            // 
            gC_PaymentLine.DataSource = trPaymentLinesBindingSource;
            gC_PaymentLine.Location = new System.Drawing.Point(12, 84);
            gC_PaymentLine.MainView = gV_PaymentLine;
            gC_PaymentLine.MenuManager = ribbon;
            gC_PaymentLine.Name = "gC_PaymentLine";
            gC_PaymentLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoLUE_CurrencyCode, repoCalcEdit_ReceivePayment, repoCalcEdit_MakePayment, repoBtnEdit_CashregisterCode, repoLUE_PaymentTypeCode });
            gC_PaymentLine.Size = new System.Drawing.Size(875, 281);
            gC_PaymentLine.TabIndex = 7;
            gC_PaymentLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentLine });
            gC_PaymentLine.KeyDown += gC_PaymentLine_KeyDown;
            // 
            // trPaymentLinesBindingSource
            // 
            trPaymentLinesBindingSource.DataSource = typeof(Models.TrPaymentLine);
            // 
            // gV_PaymentLine
            // 
            gV_PaymentLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPaymentLineId, colPaymentHeaderId, colPaymentTypeCode, colPayment, colPaymentLoc, colCurrencyCode, colLineDescription, colExchangeRate, colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate, colCashRegisterCode, colBalanceBefor, colBalanceAfter, colReceivePayment, colPaymentMethodId });
            gV_PaymentLine.CustomizationFormBounds = new System.Drawing.Rectangle(953, 390, 264, 272);
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
            // colPayment
            // 
            colPayment.ColumnEdit = repoCalcEdit_ReceivePayment;
            colPayment.FieldName = "Payment";
            colPayment.Name = "colPayment";
            colPayment.Visible = true;
            colPayment.VisibleIndex = 1;
            colPayment.Width = 136;
            // 
            // repoCalcEdit_ReceivePayment
            // 
            repoCalcEdit_ReceivePayment.AutoHeight = false;
            repoCalcEdit_ReceivePayment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_ReceivePayment.Name = "repoCalcEdit_ReceivePayment";
            // 
            // colPaymentLoc
            // 
            colPaymentLoc.ColumnEdit = repoCalcEdit_MakePayment;
            colPaymentLoc.FieldName = "PaymentLoc";
            colPaymentLoc.Name = "colPaymentLoc";
            // 
            // repoCalcEdit_MakePayment
            // 
            repoCalcEdit_MakePayment.AutoHeight = false;
            repoCalcEdit_MakePayment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_MakePayment.Name = "repoCalcEdit_MakePayment";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.ColumnEdit = repoLUE_CurrencyCode;
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 2;
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
            colLineDescription.VisibleIndex = 4;
            colLineDescription.Width = 97;
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            colExchangeRate.Visible = true;
            colExchangeRate.VisibleIndex = 3;
            colExchangeRate.Width = 157;
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
            // colCashRegisterCode
            // 
            colCashRegisterCode.ColumnEdit = repoBtnEdit_CashregisterCode;
            colCashRegisterCode.FieldName = "CashRegisterCode";
            colCashRegisterCode.Name = "colCashRegisterCode";
            // 
            // repoBtnEdit_CashregisterCode
            // 
            repoBtnEdit_CashregisterCode.AutoHeight = false;
            repoBtnEdit_CashregisterCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_CashregisterCode.Name = "repoBtnEdit_CashregisterCode";
            // 
            // colBalanceBefor
            // 
            colBalanceBefor.FieldName = "BalanceBefor";
            colBalanceBefor.Name = "colBalanceBefor";
            colBalanceBefor.Visible = true;
            colBalanceBefor.VisibleIndex = 5;
            // 
            // colBalanceAfter
            // 
            colBalanceAfter.FieldName = "BalanceAfter";
            colBalanceAfter.Name = "colBalanceAfter";
            colBalanceAfter.Visible = true;
            colBalanceAfter.VisibleIndex = 6;
            // 
            // colReceivePayment
            // 
            colReceivePayment.FieldName = "ReceivePayment";
            colReceivePayment.Name = "colReceivePayment";
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
            OperationDateDateEdit.TabIndex = 5;
            OperationDateDateEdit.KeyDown += dataLayout_KeyDown;
            // 
            // trPaymentHeadersBindingSource
            // 
            trPaymentHeadersBindingSource.DataSource = typeof(Models.TrPaymentHeader);
            trPaymentHeadersBindingSource.AddingNew += trPaymentHeadersBindingSource_AddingNew;
            trPaymentHeadersBindingSource.CurrentItemChanged += trPaymentHeadersBindingSource_CurrentItemChanged;
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
            OperationTimeTimeSpanEdit.TabIndex = 4;
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
            DescriptionTextEdit.TabIndex = 6;
            DescriptionTextEdit.KeyDown += dataLayout_KeyDown;
            // 
            // CurrAccCodeButtonEdit
            // 
            CurrAccCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "CurrAccCode", true));
            CurrAccCodeButtonEdit.Location = new System.Drawing.Point(537, 36);
            CurrAccCodeButtonEdit.MenuManager = ribbon;
            CurrAccCodeButtonEdit.Name = "CurrAccCodeButtonEdit";
            CurrAccCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            CurrAccCodeButtonEdit.Size = new System.Drawing.Size(67, 20);
            CurrAccCodeButtonEdit.StyleController = dataLayoutControl1;
            CurrAccCodeButtonEdit.TabIndex = 1;
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
            // ToCashRegCodeButtonEdit
            // 
            ToCashRegCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "ToCashRegCode", true));
            ToCashRegCodeButtonEdit.Location = new System.Drawing.Point(537, 36);
            ToCashRegCodeButtonEdit.MenuManager = ribbon;
            ToCashRegCodeButtonEdit.Name = "ToCashRegCodeButtonEdit";
            ToCashRegCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            ToCashRegCodeButtonEdit.Size = new System.Drawing.Size(82, 20);
            ToCashRegCodeButtonEdit.StyleController = dataLayoutControl1;
            ToCashRegCodeButtonEdit.TabIndex = 3;
            ToCashRegCodeButtonEdit.ButtonPressed += ToCashRegCodeButtonEdit_ButtonPressed;
            // 
            // FromCashRegCodeButtonEdit
            // 
            FromCashRegCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPaymentHeadersBindingSource, "FromCashRegCode", true));
            FromCashRegCodeButtonEdit.Location = new System.Drawing.Point(537, 12);
            FromCashRegCodeButtonEdit.MenuManager = ribbon;
            FromCashRegCodeButtonEdit.Name = "FromCashRegCodeButtonEdit";
            FromCashRegCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            FromCashRegCodeButtonEdit.Size = new System.Drawing.Size(82, 20);
            FromCashRegCodeButtonEdit.StyleController = dataLayoutControl1;
            FromCashRegCodeButtonEdit.TabIndex = 2;
            FromCashRegCodeButtonEdit.ButtonPressed += FromCashRegCodeButtonEdit_ButtonPressed;
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = CurrAccCodeButtonEdit;
            ItemForCurrAccCode.Location = new System.Drawing.Point(439, 24);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new System.Drawing.Size(157, 24);
            ItemForCurrAccCode.Text = "Cari Hesab";
            ItemForCurrAccCode.TextSize = new System.Drawing.Size(74, 13);
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
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, ItemForDocumentNumber, layoutControlItem4, layoutControlItem5, ItemForToCashRegCode, ItemForOperationTime, ItemForDescription, ItemForFromCashRegCode, ItemForOperationDate, layoutControlItem2, layoutControlItem3 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(879, 376);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gC_PaymentLine;
            layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(879, 285);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
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
            // layoutControlItem4
            // 
            layoutControlItem4.Control = lbl_CurrAccBalansAfter;
            layoutControlItem4.Location = new System.Drawing.Point(439, 357);
            layoutControlItem4.MinSize = new System.Drawing.Size(125, 17);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(440, 19);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = lbl_CurrAccBalansBefore;
            layoutControlItem5.Location = new System.Drawing.Point(0, 357);
            layoutControlItem5.MinSize = new System.Drawing.Size(125, 17);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(439, 19);
            layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // ItemForToCashRegCode
            // 
            ItemForToCashRegCode.Control = ToCashRegCodeButtonEdit;
            ItemForToCashRegCode.Location = new System.Drawing.Point(439, 24);
            ItemForToCashRegCode.Name = "ItemForToCashRegCode";
            ItemForToCashRegCode.Size = new System.Drawing.Size(172, 24);
            ItemForToCashRegCode.Text = "Kassaya";
            ItemForToCashRegCode.TextSize = new System.Drawing.Size(74, 13);
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
            // ItemForDescription
            // 
            ItemForDescription.Control = DescriptionTextEdit;
            ItemForDescription.Location = new System.Drawing.Point(439, 48);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new System.Drawing.Size(440, 24);
            ItemForDescription.Text = "Açıqlama";
            ItemForDescription.TextSize = new System.Drawing.Size(74, 13);
            // 
            // ItemForFromCashRegCode
            // 
            ItemForFromCashRegCode.Control = FromCashRegCodeButtonEdit;
            ItemForFromCashRegCode.Location = new System.Drawing.Point(439, 0);
            ItemForFromCashRegCode.Name = "ItemForFromCashRegCode";
            ItemForFromCashRegCode.Size = new System.Drawing.Size(172, 24);
            ItemForFromCashRegCode.Text = "Kassadan";
            ItemForFromCashRegCode.TextSize = new System.Drawing.Size(74, 13);
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
            // layoutControlItem2
            // 
            layoutControlItem2.Control = lbl_FromCashRegDesc;
            layoutControlItem2.Location = new System.Drawing.Point(611, 0);
            layoutControlItem2.MinSize = new System.Drawing.Size(4, 17);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(268, 24);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = lbl_ToCashRegDesc;
            layoutControlItem3.Location = new System.Drawing.Point(611, 24);
            layoutControlItem3.MinSize = new System.Drawing.Size(67, 17);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(268, 24);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // colPaymentMethodId
            // 
            colPaymentMethodId.FieldName = "PaymentMethodId";
            colPaymentMethodId.Name = "colPaymentMethodId";
            // 
            // FormMoneyTransfer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(899, 578);
            Controls.Add(dataLayoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormMoneyTransfer";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "Kassalar Arası Transfer";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)trPaymentHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperationTimeTimeSpanEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DescriptionTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ToCashRegCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)FromCashRegCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForToCashRegCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForFromCashRegCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOperationDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodId;
    }
}