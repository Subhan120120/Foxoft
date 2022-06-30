﻿
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaymentDetail));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_DeletePayment = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gC_PaymentLine = new DevExpress.XtraGrid.GridControl();
            this.trPaymentLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_PaymentLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDcPaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperationDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OperationTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PosterminalIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DocumentNumberButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.StoreCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.OfficeCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.CurrAccCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForOperationTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOperationDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPosterminalId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOfficeCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.colPaymentLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationTimeTimeSpanEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosterminalIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentNumberButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfficeCodeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrAccCodeButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPosterminalId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOfficeCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.bBI_DeletePayment});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(730, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bBI_DeletePayment
            // 
            this.bBI_DeletePayment.Caption = "Ödənişi Sil";
            this.bBI_DeletePayment.Id = 1;
            this.bBI_DeletePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_DeletePayment.ImageOptions.SvgImage")));
            this.bBI_DeletePayment.Name = "bBI_DeletePayment";
            this.bBI_DeletePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DeletePayment_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_DeletePayment);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 425);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(730, 24);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gC_PaymentLine);
            this.dataLayoutControl1.Controls.Add(this.OperationDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.OperationTimeTimeSpanEdit);
            this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PosterminalIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DocumentNumberButtonEdit);
            this.dataLayoutControl1.Controls.Add(this.StoreCodeLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.OfficeCodeLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.CurrAccCodeButtonEdit);
            this.dataLayoutControl1.DataSource = this.trPaymentHeadersBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(730, 267);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gC_PaymentLine
            // 
            this.gC_PaymentLine.DataSource = this.trPaymentLinesBindingSource;
            this.gC_PaymentLine.Location = new System.Drawing.Point(12, 108);
            this.gC_PaymentLine.MainView = this.gV_PaymentLine;
            this.gC_PaymentLine.MenuManager = this.ribbon;
            this.gC_PaymentLine.Name = "gC_PaymentLine";
            this.gC_PaymentLine.Size = new System.Drawing.Size(706, 147);
            this.gC_PaymentLine.TabIndex = 9;
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
            this.colLineDescription,
            this.colCurrencyCode,
            this.colExchangeRate,
            this.colDcPaymentType,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate,
            this.colPayment,
            this.colPaymentLoc});
            this.gV_PaymentLine.GridControl = this.gC_PaymentLine;
            this.gV_PaymentLine.Name = "gV_PaymentLine";
            this.gV_PaymentLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gV_PaymentLine.OptionsNavigation.AutoFocusNewRow = true;
            this.gV_PaymentLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gV_PaymentLine.OptionsView.ShowGroupPanel = false;
            this.gV_PaymentLine.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_PaymentLine_CellValueChanging);
            this.gV_PaymentLine.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gV_PaymentLine_RowDeleted);
            this.gV_PaymentLine.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gV_PaymentLine_RowUpdated);
            // 
            // colPaymentLineId
            // 
            this.colPaymentLineId.FieldName = "PaymentLineId";
            this.colPaymentLineId.Name = "colPaymentLineId";
            this.colPaymentLineId.Visible = true;
            this.colPaymentLineId.VisibleIndex = 0;
            // 
            // colPaymentHeaderId
            // 
            this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
            this.colPaymentHeaderId.Name = "colPaymentHeaderId";
            this.colPaymentHeaderId.Visible = true;
            this.colPaymentHeaderId.VisibleIndex = 1;
            // 
            // colPaymentTypeCode
            // 
            this.colPaymentTypeCode.FieldName = "PaymentTypeCode";
            this.colPaymentTypeCode.Name = "colPaymentTypeCode";
            this.colPaymentTypeCode.Visible = true;
            this.colPaymentTypeCode.VisibleIndex = 2;
            // 
            // colLineDescription
            // 
            this.colLineDescription.FieldName = "LineDescription";
            this.colLineDescription.Name = "colLineDescription";
            this.colLineDescription.Visible = true;
            this.colLineDescription.VisibleIndex = 4;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 5;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.FieldName = "ExchangeRate";
            this.colExchangeRate.Name = "colExchangeRate";
            this.colExchangeRate.Visible = true;
            this.colExchangeRate.VisibleIndex = 6;
            // 
            // colDcPaymentType
            // 
            this.colDcPaymentType.FieldName = "DcPaymentType";
            this.colDcPaymentType.Name = "colDcPaymentType";
            this.colDcPaymentType.Visible = true;
            this.colDcPaymentType.VisibleIndex = 7;
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 8;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 9;
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            this.colLastUpdatedUserName.Visible = true;
            this.colLastUpdatedUserName.VisibleIndex = 10;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 11;
            // 
            // colPayment
            // 
            this.colPayment.FieldName = "Payment";
            this.colPayment.Name = "colPayment";
            this.colPayment.Visible = true;
            this.colPayment.VisibleIndex = 3;
            // 
            // OperationDateDateEdit
            // 
            this.OperationDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "OperationDate", true));
            this.OperationDateDateEdit.EditValue = null;
            this.OperationDateDateEdit.Location = new System.Drawing.Point(95, 60);
            this.OperationDateDateEdit.MenuManager = this.ribbon;
            this.OperationDateDateEdit.Name = "OperationDateDateEdit";
            this.OperationDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OperationDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OperationDateDateEdit.Size = new System.Drawing.Size(268, 20);
            this.OperationDateDateEdit.StyleController = this.dataLayoutControl1;
            this.OperationDateDateEdit.TabIndex = 5;
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
            this.OperationTimeTimeSpanEdit.Location = new System.Drawing.Point(95, 84);
            this.OperationTimeTimeSpanEdit.MenuManager = this.ribbon;
            this.OperationTimeTimeSpanEdit.Name = "OperationTimeTimeSpanEdit";
            this.OperationTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OperationTimeTimeSpanEdit.Size = new System.Drawing.Size(268, 20);
            this.OperationTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
            this.OperationTimeTimeSpanEdit.TabIndex = 7;
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "Description", true));
            this.DescriptionTextEdit.Location = new System.Drawing.Point(450, 84);
            this.DescriptionTextEdit.MenuManager = this.ribbon;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DescriptionTextEdit.Size = new System.Drawing.Size(268, 20);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionTextEdit.TabIndex = 8;
            // 
            // PosterminalIdTextEdit
            // 
            this.PosterminalIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "PosterminalId", true));
            this.PosterminalIdTextEdit.Location = new System.Drawing.Point(95, 36);
            this.PosterminalIdTextEdit.MenuManager = this.ribbon;
            this.PosterminalIdTextEdit.Name = "PosterminalIdTextEdit";
            this.PosterminalIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PosterminalIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PosterminalIdTextEdit.Properties.Mask.EditMask = "N0";
            this.PosterminalIdTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PosterminalIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PosterminalIdTextEdit.Size = new System.Drawing.Size(268, 20);
            this.PosterminalIdTextEdit.StyleController = this.dataLayoutControl1;
            this.PosterminalIdTextEdit.TabIndex = 3;
            // 
            // DocumentNumberButtonEdit
            // 
            this.DocumentNumberButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "DocumentNumber", true));
            this.DocumentNumberButtonEdit.Location = new System.Drawing.Point(95, 12);
            this.DocumentNumberButtonEdit.MenuManager = this.ribbon;
            this.DocumentNumberButtonEdit.Name = "DocumentNumberButtonEdit";
            this.DocumentNumberButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DocumentNumberButtonEdit.Size = new System.Drawing.Size(268, 20);
            this.DocumentNumberButtonEdit.StyleController = this.dataLayoutControl1;
            this.DocumentNumberButtonEdit.TabIndex = 0;
            this.DocumentNumberButtonEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_DocNum_ButtonPressed);
            // 
            // StoreCodeLookUpEdit
            // 
            this.StoreCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "StoreCode", true));
            this.StoreCodeLookUpEdit.Location = new System.Drawing.Point(450, 36);
            this.StoreCodeLookUpEdit.MenuManager = this.ribbon;
            this.StoreCodeLookUpEdit.Name = "StoreCodeLookUpEdit";
            this.StoreCodeLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.StoreCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StoreCodeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "Mağaza Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "Mağaza Adı")});
            this.StoreCodeLookUpEdit.Properties.DisplayMember = "CurrAccDesc";
            this.StoreCodeLookUpEdit.Properties.NullText = "";
            this.StoreCodeLookUpEdit.Properties.ValueMember = "CurrAccCode";
            this.StoreCodeLookUpEdit.Size = new System.Drawing.Size(268, 20);
            this.StoreCodeLookUpEdit.StyleController = this.dataLayoutControl1;
            this.StoreCodeLookUpEdit.TabIndex = 4;
            // 
            // OfficeCodeLookUpEdit
            // 
            this.OfficeCodeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "OfficeCode", true));
            this.OfficeCodeLookUpEdit.Location = new System.Drawing.Point(450, 60);
            this.OfficeCodeLookUpEdit.MenuManager = this.ribbon;
            this.OfficeCodeLookUpEdit.Name = "OfficeCodeLookUpEdit";
            this.OfficeCodeLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.OfficeCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OfficeCodeLookUpEdit.Properties.NullText = "";
            this.OfficeCodeLookUpEdit.Size = new System.Drawing.Size(268, 20);
            this.OfficeCodeLookUpEdit.StyleController = this.dataLayoutControl1;
            this.OfficeCodeLookUpEdit.TabIndex = 6;
            // 
            // CurrAccCodeButtonEdit
            // 
            this.CurrAccCodeButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "CurrAccCode", true));
            this.CurrAccCodeButtonEdit.Location = new System.Drawing.Point(450, 12);
            this.CurrAccCodeButtonEdit.MenuManager = this.ribbon;
            this.CurrAccCodeButtonEdit.Name = "CurrAccCodeButtonEdit";
            this.CurrAccCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CurrAccCodeButtonEdit.Size = new System.Drawing.Size(268, 20);
            this.CurrAccCodeButtonEdit.StyleController = this.dataLayoutControl1;
            this.CurrAccCodeButtonEdit.TabIndex = 2;
            this.CurrAccCodeButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.CurrAccCodeButtonEdit_ButtonClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(730, 267);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForOperationTime,
            this.ItemForCurrAccCode,
            this.ItemForDocumentNumber,
            this.layoutControlItem1,
            this.ItemForDescription,
            this.layoutControlItem2,
            this.ItemForOperationDate,
            this.ItemForPosterminalId,
            this.ItemForOfficeCode});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(710, 247);
            // 
            // ItemForOperationTime
            // 
            this.ItemForOperationTime.Control = this.OperationTimeTimeSpanEdit;
            this.ItemForOperationTime.Location = new System.Drawing.Point(0, 72);
            this.ItemForOperationTime.Name = "ItemForOperationTime";
            this.ItemForOperationTime.Size = new System.Drawing.Size(355, 24);
            this.ItemForOperationTime.Text = "Sənəd Vaxtı";
            this.ItemForOperationTime.TextSize = new System.Drawing.Size(71, 13);
            // 
            // ItemForCurrAccCode
            // 
            this.ItemForCurrAccCode.Control = this.CurrAccCodeButtonEdit;
            this.ItemForCurrAccCode.Location = new System.Drawing.Point(355, 0);
            this.ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            this.ItemForCurrAccCode.Size = new System.Drawing.Size(355, 24);
            this.ItemForCurrAccCode.Text = "Cari Hesab";
            this.ItemForCurrAccCode.TextSize = new System.Drawing.Size(71, 13);
            // 
            // ItemForDocumentNumber
            // 
            this.ItemForDocumentNumber.Control = this.DocumentNumberButtonEdit;
            this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
            this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            this.ItemForDocumentNumber.Size = new System.Drawing.Size(355, 24);
            this.ItemForDocumentNumber.Text = "Sənəd Nömrəsi";
            this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gC_PaymentLine;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(710, 151);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(355, 72);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(355, 24);
            this.ItemForDescription.Text = "Açıqlama";
            this.ItemForDescription.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.StoreCodeLookUpEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(355, 24);
            this.layoutControlItem2.Name = "ItemForStoreCode";
            this.layoutControlItem2.Size = new System.Drawing.Size(355, 24);
            this.layoutControlItem2.Text = "Mağaza";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 13);
            // 
            // ItemForOperationDate
            // 
            this.ItemForOperationDate.Control = this.OperationDateDateEdit;
            this.ItemForOperationDate.Location = new System.Drawing.Point(0, 48);
            this.ItemForOperationDate.Name = "ItemForOperationDate";
            this.ItemForOperationDate.Size = new System.Drawing.Size(355, 24);
            this.ItemForOperationDate.Text = "Sənəd Tarixi";
            this.ItemForOperationDate.TextSize = new System.Drawing.Size(71, 13);
            // 
            // ItemForPosterminalId
            // 
            this.ItemForPosterminalId.Control = this.PosterminalIdTextEdit;
            this.ItemForPosterminalId.Location = new System.Drawing.Point(0, 24);
            this.ItemForPosterminalId.Name = "ItemForPosterminalId";
            this.ItemForPosterminalId.Size = new System.Drawing.Size(355, 24);
            this.ItemForPosterminalId.Text = "POS Terminal";
            this.ItemForPosterminalId.TextSize = new System.Drawing.Size(71, 13);
            // 
            // ItemForOfficeCode
            // 
            this.ItemForOfficeCode.Control = this.OfficeCodeLookUpEdit;
            this.ItemForOfficeCode.Location = new System.Drawing.Point(355, 48);
            this.ItemForOfficeCode.Name = "ItemForOfficeCode";
            this.ItemForOfficeCode.Size = new System.Drawing.Size(355, 24);
            this.ItemForOfficeCode.Text = "Ofis";
            this.ItemForOfficeCode.TextSize = new System.Drawing.Size(71, 13);
            // 
            // colPaymentLoc
            // 
            this.colPaymentLoc.FieldName = "PaymentLoc";
            this.colPaymentLoc.Name = "colPaymentLoc";
            // 
            // FormPaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 449);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FormPaymentDetail";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FormPaymentDetail";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gC_PaymentLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PaymentLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationTimeTimeSpanEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosterminalIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentNumberButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfficeCodeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrAccCodeButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOperationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPosterminalId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOfficeCode)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit CurrAccCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.TextEdit OfficeCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit StoreCodeTextEdit;
        private DevExpress.XtraEditors.ButtonEdit DocumentNumberButtonEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOperationTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOfficeCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOperationDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreCode;
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
        private DevExpress.XtraGrid.Columns.GridColumn colBankId;
        private DevExpress.XtraGrid.Columns.GridColumn colDcPaymentType;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bBI_DeletePayment;
        private DevExpress.XtraEditors.TextEdit PosterminalIdTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPosterminalId;
        private DevExpress.XtraEditors.LookUpEdit StoreCodeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit CurrAccCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit OfficeCodeLookUpEdit;
        private DevExpress.XtraEditors.ButtonEdit CurrAccCodeButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentLoc;
    }
}