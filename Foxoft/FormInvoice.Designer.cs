
using System;

namespace Foxoft
{
    partial class FormInvoice
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoice));
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.trInvoiceLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lC_CurrAccDesc = new DevExpress.XtraEditors.LabelControl();
            this.trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            this.gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_InvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_InvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LineDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBtnEdit_SalesPersonCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckEdit_IsReturn = new DevExpress.XtraEditors.CheckEdit();
            this.DocumentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.DocumentTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            this.CustomsDocumentNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            this.memoEdit_Desc = new DevExpress.XtraEditors.MemoEdit();
            this.btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            this.lUE_OfficeCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lUE_StoreCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lUE_WarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForIsReturn = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOfficeCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCustomsDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStoreCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl_Payment = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_Save = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_SaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_reportDesign = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_New = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_reportPreview = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_SalesPersonCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_IsReturn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomsDocumentNumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUE_OfficeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUE_StoreCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUE_WarehouseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOfficeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomsDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // trInvoiceLinesBindingSource
            // 
            this.trInvoiceLinesBindingSource.DataSource = typeof(Foxoft.Models.TrInvoiceLine);
            this.trInvoiceLinesBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.trInvoiceLinesBindingSource_AddingNew);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lC_CurrAccDesc);
            this.dataLayoutControl1.Controls.Add(this.labelControl1);
            this.dataLayoutControl1.Controls.Add(this.gC_InvoiceLine);
            this.dataLayoutControl1.Controls.Add(this.CheckEdit_IsReturn);
            this.dataLayoutControl1.Controls.Add(this.DocumentDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.DocumentTimeTimeSpanEdit);
            this.dataLayoutControl1.Controls.Add(this.CustomsDocumentNumberTextEdit);
            this.dataLayoutControl1.Controls.Add(this.btnEdit_DocNum);
            this.dataLayoutControl1.Controls.Add(this.memoEdit_Desc);
            this.dataLayoutControl1.Controls.Add(this.btnEdit_CurrAccCode);
            this.dataLayoutControl1.Controls.Add(this.lUE_OfficeCode);
            this.dataLayoutControl1.Controls.Add(this.lUE_StoreCode);
            this.dataLayoutControl1.Controls.Add(this.lUE_WarehouseCode);
            this.dataLayoutControl1.DataSource = this.trInvoiceHeadersBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 352, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(871, 462);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // lC_CurrAccDesc
            // 
            this.lC_CurrAccDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.trInvoiceHeadersBindingSource, "CurrAccDesc", true));
            this.lC_CurrAccDesc.Location = new System.Drawing.Point(622, 12);
            this.lC_CurrAccDesc.Name = "lC_CurrAccDesc";
            this.lC_CurrAccDesc.Size = new System.Drawing.Size(237, 20);
            this.lC_CurrAccDesc.StyleController = this.dataLayoutControl1;
            this.lC_CurrAccDesc.TabIndex = 16;
            this.lC_CurrAccDesc.Text = "labelControl2";
            // 
            // trInvoiceHeadersBindingSource
            // 
            this.trInvoiceHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrInvoiceHeader);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Location = new System.Drawing.Point(12, 425);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(847, 25);
            this.labelControl1.StyleController = this.dataLayoutControl1;
            this.labelControl1.TabIndex = 15;
            // 
            // gC_InvoiceLine
            // 
            this.gC_InvoiceLine.DataSource = this.trInvoiceLinesBindingSource;
            this.gC_InvoiceLine.Location = new System.Drawing.Point(12, 132);
            this.gC_InvoiceLine.MainView = this.gV_InvoiceLine;
            this.gC_InvoiceLine.Name = "gC_InvoiceLine";
            this.gC_InvoiceLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoBtnEdit_ProductCode,
            this.repoBtnEdit_SalesPersonCode});
            this.gC_InvoiceLine.Size = new System.Drawing.Size(847, 289);
            this.gC_InvoiceLine.TabIndex = 13;
            this.gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceLine});
            // 
            // gV_InvoiceLine
            // 
            this.gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_InvoiceLineId,
            this.col_InvoiceHeaderId,
            this.col_ProductCode,
            this.colQtyIn,
            this.colQtyOut,
            this.col_Price,
            this.col_Amount,
            this.col_PosDiscount,
            this.col_NetAmount,
            this.col_LineDesc,
            this.col_SalesPersonCode,
            this.colCreatedDate,
            this.col_ProductDesc});
            this.gV_InvoiceLine.CustomizationFormBounds = new System.Drawing.Rectangle(1141, 456, 264, 272);
            this.gV_InvoiceLine.GridControl = this.gC_InvoiceLine;
            this.gV_InvoiceLine.Name = "gV_InvoiceLine";
            this.gV_InvoiceLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gV_InvoiceLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gV_InvoiceLine.OptionsView.ShowFooter = true;
            this.gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
            this.gV_InvoiceLine.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gV_InvoiceLine_InitNewRow);
            this.gV_InvoiceLine.HiddenEditor += new System.EventHandler(this.gridView_HiddenEditor);
            this.gV_InvoiceLine.ShownEditor += new System.EventHandler(this.gridView_ShownEditor);
            this.gV_InvoiceLine.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_InvoiceLine_CellValueChanging);
            this.gV_InvoiceLine.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gV_InvoiceLine_RowDeleted);
            this.gV_InvoiceLine.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gV_InvoiceLine_RowUpdated);
            this.gV_InvoiceLine.RowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.gV_InvoiceLine_RowLoaded);
            this.gV_InvoiceLine.AsyncCompleted += new System.EventHandler(this.gV_InvoiceLine_AsyncCompleted);
            this.gV_InvoiceLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gV_InvoiceLine_KeyDown);
            this.gV_InvoiceLine.DoubleClick += new System.EventHandler(this.gV_InvoiceLine_DoubleClick);
            // 
            // col_InvoiceLineId
            // 
            this.col_InvoiceLineId.Caption = "InvoiceLineId";
            this.col_InvoiceLineId.FieldName = "InvoiceLineId";
            this.col_InvoiceLineId.Name = "col_InvoiceLineId";
            this.col_InvoiceLineId.OptionsEditForm.StartNewRow = true;
            // 
            // col_InvoiceHeaderId
            // 
            this.col_InvoiceHeaderId.Caption = "InvoiceHeaderId";
            this.col_InvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.col_InvoiceHeaderId.Name = "col_InvoiceHeaderId";
            // 
            // col_ProductCode
            // 
            this.col_ProductCode.Caption = "Məhsul";
            this.col_ProductCode.ColumnEdit = this.repoBtnEdit_ProductCode;
            this.col_ProductCode.FieldName = "ProductCode";
            this.col_ProductCode.Name = "col_ProductCode";
            this.col_ProductCode.Visible = true;
            this.col_ProductCode.VisibleIndex = 0;
            // 
            // repoBtnEdit_ProductCode
            // 
            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoBtnEdit_ProductCode_ButtonPressed);
            // 
            // colQtyIn
            // 
            this.colQtyIn.FieldName = "QtyIn";
            this.colQtyIn.Name = "colQtyIn";
            this.colQtyIn.Visible = true;
            this.colQtyIn.VisibleIndex = 2;
            // 
            // colQtyOut
            // 
            this.colQtyOut.FieldName = "QtyOut";
            this.colQtyOut.Name = "colQtyOut";
            this.colQtyOut.Visible = true;
            this.colQtyOut.VisibleIndex = 3;
            // 
            // col_Price
            // 
            this.col_Price.Caption = "Qiymət";
            this.col_Price.FieldName = "Price";
            this.col_Price.Name = "col_Price";
            this.col_Price.Visible = true;
            this.col_Price.VisibleIndex = 4;
            // 
            // col_Amount
            // 
            this.col_Amount.Caption = "Tutar";
            this.col_Amount.FieldName = "Amount";
            this.col_Amount.Name = "col_Amount";
            this.col_Amount.OptionsColumn.AllowEdit = false;
            this.col_Amount.Visible = true;
            this.col_Amount.VisibleIndex = 7;
            // 
            // col_PosDiscount
            // 
            this.col_PosDiscount.Caption = "Endirim";
            this.col_PosDiscount.FieldName = "PosDiscount";
            this.col_PosDiscount.Name = "col_PosDiscount";
            this.col_PosDiscount.Visible = true;
            this.col_PosDiscount.VisibleIndex = 8;
            // 
            // col_NetAmount
            // 
            this.col_NetAmount.Caption = "Net Tutar";
            this.col_NetAmount.FieldName = "NetAmount";
            this.col_NetAmount.Name = "col_NetAmount";
            this.col_NetAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmount", "SUM={0:0.##}")});
            this.col_NetAmount.Visible = true;
            this.col_NetAmount.VisibleIndex = 9;
            // 
            // col_LineDesc
            // 
            this.col_LineDesc.Caption = "Qeyd";
            this.col_LineDesc.FieldName = "LineDescription";
            this.col_LineDesc.Name = "col_LineDesc";
            this.col_LineDesc.Visible = true;
            this.col_LineDesc.VisibleIndex = 6;
            // 
            // col_SalesPersonCode
            // 
            this.col_SalesPersonCode.ColumnEdit = this.repoBtnEdit_SalesPersonCode;
            this.col_SalesPersonCode.FieldName = "SalesPersonCode";
            this.col_SalesPersonCode.Name = "col_SalesPersonCode";
            this.col_SalesPersonCode.Visible = true;
            this.col_SalesPersonCode.VisibleIndex = 5;
            // 
            // repoBtnEdit_SalesPersonCode
            // 
            this.repoBtnEdit_SalesPersonCode.AutoHeight = false;
            this.repoBtnEdit_SalesPersonCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repoBtnEdit_SalesPersonCode.Name = "repoBtnEdit_SalesPersonCode";
            this.repoBtnEdit_SalesPersonCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoBtnEdit_SalesPersonCode_ButtonPressed);
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // col_ProductDesc
            // 
            this.col_ProductDesc.FieldName = "ProductDescription";
            this.col_ProductDesc.Name = "col_ProductDesc";
            this.col_ProductDesc.OptionsColumn.AllowEdit = false;
            this.col_ProductDesc.Visible = true;
            this.col_ProductDesc.VisibleIndex = 1;
            // 
            // CheckEdit_IsReturn
            // 
            this.CheckEdit_IsReturn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "IsReturn", true));
            this.CheckEdit_IsReturn.Location = new System.Drawing.Point(12, 36);
            this.CheckEdit_IsReturn.Name = "CheckEdit_IsReturn";
            this.CheckEdit_IsReturn.Properties.Caption = "Qaytarılmadır";
            this.CheckEdit_IsReturn.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.CheckEdit_IsReturn.Size = new System.Drawing.Size(421, 20);
            this.CheckEdit_IsReturn.StyleController = this.dataLayoutControl1;
            this.CheckEdit_IsReturn.TabIndex = 4;
            // 
            // DocumentDateDateEdit
            // 
            this.DocumentDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentDate", true));
            this.DocumentDateDateEdit.EditValue = null;
            this.DocumentDateDateEdit.Location = new System.Drawing.Point(122, 84);
            this.DocumentDateDateEdit.Name = "DocumentDateDateEdit";
            this.DocumentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentDateDateEdit.Size = new System.Drawing.Size(311, 20);
            this.DocumentDateDateEdit.StyleController = this.dataLayoutControl1;
            this.DocumentDateDateEdit.TabIndex = 5;
            // 
            // DocumentTimeTimeSpanEdit
            // 
            this.DocumentTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentTime", true));
            this.DocumentTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            this.DocumentTimeTimeSpanEdit.Location = new System.Drawing.Point(122, 108);
            this.DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
            this.DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentTimeTimeSpanEdit.Size = new System.Drawing.Size(311, 20);
            this.DocumentTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
            this.DocumentTimeTimeSpanEdit.TabIndex = 6;
            // 
            // CustomsDocumentNumberTextEdit
            // 
            this.CustomsDocumentNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "CustomsDocumentNumber", true));
            this.CustomsDocumentNumberTextEdit.Location = new System.Drawing.Point(122, 60);
            this.CustomsDocumentNumberTextEdit.Name = "CustomsDocumentNumberTextEdit";
            this.CustomsDocumentNumberTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.CustomsDocumentNumberTextEdit.Size = new System.Drawing.Size(311, 20);
            this.CustomsDocumentNumberTextEdit.StyleController = this.dataLayoutControl1;
            this.CustomsDocumentNumberTextEdit.TabIndex = 12;
            // 
            // btnEdit_DocNum
            // 
            this.btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentNumber", true));
            this.btnEdit_DocNum.Location = new System.Drawing.Point(122, 12);
            this.btnEdit_DocNum.Name = "btnEdit_DocNum";
            this.btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_DocNum.Size = new System.Drawing.Size(311, 20);
            this.btnEdit_DocNum.StyleController = this.dataLayoutControl1;
            this.btnEdit_DocNum.TabIndex = 14;
            this.btnEdit_DocNum.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_DocNum_ButtonPressed);
            this.btnEdit_DocNum.DoubleClick += new System.EventHandler(this.btnEdit_DocNum_DoubleClick);
            // 
            // memoEdit_Desc
            // 
            this.memoEdit_Desc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "Description", true));
            this.memoEdit_Desc.Location = new System.Drawing.Point(547, 108);
            this.memoEdit_Desc.Name = "memoEdit_Desc";
            this.memoEdit_Desc.Size = new System.Drawing.Size(312, 20);
            this.memoEdit_Desc.StyleController = this.dataLayoutControl1;
            this.memoEdit_Desc.TabIndex = 7;
            // 
            // btnEdit_CurrAccCode
            // 
            this.btnEdit_CurrAccCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "CurrAccCode", true));
            this.btnEdit_CurrAccCode.Location = new System.Drawing.Point(547, 12);
            this.btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            this.btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_CurrAccCode.Size = new System.Drawing.Size(71, 20);
            this.btnEdit_CurrAccCode.StyleController = this.dataLayoutControl1;
            this.btnEdit_CurrAccCode.TabIndex = 8;
            this.btnEdit_CurrAccCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_CurrAccCode_ButtonClick);
            // 
            // lUE_OfficeCode
            // 
            this.lUE_OfficeCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "OfficeCode", true));
            this.lUE_OfficeCode.Location = new System.Drawing.Point(547, 36);
            this.lUE_OfficeCode.Name = "lUE_OfficeCode";
            this.lUE_OfficeCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lUE_OfficeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lUE_OfficeCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OfficeCode", "Ofis kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OfficeDesc", "Ofis Adı")});
            this.lUE_OfficeCode.Properties.DisplayMember = "OfficeDesc";
            this.lUE_OfficeCode.Properties.NullText = "";
            this.lUE_OfficeCode.Properties.ShowHeader = false;
            this.lUE_OfficeCode.Properties.ValueMember = "OfficeCode";
            this.lUE_OfficeCode.Size = new System.Drawing.Size(312, 20);
            this.lUE_OfficeCode.StyleController = this.dataLayoutControl1;
            this.lUE_OfficeCode.TabIndex = 9;
            // 
            // lUE_StoreCode
            // 
            this.lUE_StoreCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "StoreCode", true));
            this.lUE_StoreCode.Location = new System.Drawing.Point(547, 60);
            this.lUE_StoreCode.Name = "lUE_StoreCode";
            this.lUE_StoreCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lUE_StoreCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lUE_StoreCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreCode", "Mağaza Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDesc", "Mağaza Adı")});
            this.lUE_StoreCode.Properties.DisplayMember = "StoreDesc";
            this.lUE_StoreCode.Properties.NullText = "";
            this.lUE_StoreCode.Properties.ShowHeader = false;
            this.lUE_StoreCode.Properties.ValueMember = "StoreCode";
            this.lUE_StoreCode.Size = new System.Drawing.Size(312, 20);
            this.lUE_StoreCode.StyleController = this.dataLayoutControl1;
            this.lUE_StoreCode.TabIndex = 10;
            // 
            // lUE_WarehouseCode
            // 
            this.lUE_WarehouseCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "WarehouseCode", true));
            this.lUE_WarehouseCode.Location = new System.Drawing.Point(547, 84);
            this.lUE_WarehouseCode.Name = "lUE_WarehouseCode";
            this.lUE_WarehouseCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lUE_WarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lUE_WarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı")});
            this.lUE_WarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            this.lUE_WarehouseCode.Properties.NullText = "";
            this.lUE_WarehouseCode.Properties.ShowHeader = false;
            this.lUE_WarehouseCode.Properties.ValueMember = "WarehouseCode";
            this.lUE_WarehouseCode.Size = new System.Drawing.Size(312, 20);
            this.lUE_WarehouseCode.StyleController = this.dataLayoutControl1;
            this.lUE_WarehouseCode.TabIndex = 11;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(871, 462);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForIsReturn,
            this.ItemForDocumentDate,
            this.ItemForDocumentTime,
            this.layoutControlItem1,
            this.ItemForDocumentNumber,
            this.ItemForCurrAccCode,
            this.ItemForOfficeCode,
            this.ItemForCustomsDocumentNumber,
            this.ItemForStoreCode,
            this.ItemForWarehouseCode,
            this.ItemForDescription,
            this.lbl_Payment,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(851, 442);
            // 
            // ItemForIsReturn
            // 
            this.ItemForIsReturn.Control = this.CheckEdit_IsReturn;
            this.ItemForIsReturn.Location = new System.Drawing.Point(0, 24);
            this.ItemForIsReturn.Name = "ItemForIsReturn";
            this.ItemForIsReturn.Size = new System.Drawing.Size(425, 24);
            this.ItemForIsReturn.Text = "Qaytarılmadır";
            this.ItemForIsReturn.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForIsReturn.TextVisible = false;
            // 
            // ItemForDocumentDate
            // 
            this.ItemForDocumentDate.Control = this.DocumentDateDateEdit;
            this.ItemForDocumentDate.Location = new System.Drawing.Point(0, 72);
            this.ItemForDocumentDate.Name = "ItemForDocumentDate";
            this.ItemForDocumentDate.Size = new System.Drawing.Size(425, 24);
            this.ItemForDocumentDate.Text = "Sənəd Tarixi";
            this.ItemForDocumentDate.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForDocumentTime
            // 
            this.ItemForDocumentTime.Control = this.DocumentTimeTimeSpanEdit;
            this.ItemForDocumentTime.Location = new System.Drawing.Point(0, 96);
            this.ItemForDocumentTime.Name = "ItemForDocumentTime";
            this.ItemForDocumentTime.Size = new System.Drawing.Size(425, 24);
            this.ItemForDocumentTime.Text = "Sənəd Vaxtı";
            this.ItemForDocumentTime.TextSize = new System.Drawing.Size(98, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gC_InvoiceLine;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(851, 293);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForDocumentNumber
            // 
            this.ItemForDocumentNumber.Control = this.btnEdit_DocNum;
            this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
            this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            this.ItemForDocumentNumber.Size = new System.Drawing.Size(425, 24);
            this.ItemForDocumentNumber.Text = "Sənəd Nömrəsi";
            this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForCurrAccCode
            // 
            this.ItemForCurrAccCode.Control = this.btnEdit_CurrAccCode;
            this.ItemForCurrAccCode.Location = new System.Drawing.Point(425, 0);
            this.ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            this.ItemForCurrAccCode.Size = new System.Drawing.Size(185, 24);
            this.ItemForCurrAccCode.Text = "Cari Hesab";
            this.ItemForCurrAccCode.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForOfficeCode
            // 
            this.ItemForOfficeCode.Control = this.lUE_OfficeCode;
            this.ItemForOfficeCode.Location = new System.Drawing.Point(425, 24);
            this.ItemForOfficeCode.Name = "ItemForOfficeCode";
            this.ItemForOfficeCode.Size = new System.Drawing.Size(426, 24);
            this.ItemForOfficeCode.Text = "Ofis";
            this.ItemForOfficeCode.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForCustomsDocumentNumber
            // 
            this.ItemForCustomsDocumentNumber.Control = this.CustomsDocumentNumberTextEdit;
            this.ItemForCustomsDocumentNumber.Location = new System.Drawing.Point(0, 48);
            this.ItemForCustomsDocumentNumber.Name = "ItemForCustomsDocumentNumber";
            this.ItemForCustomsDocumentNumber.Size = new System.Drawing.Size(425, 24);
            this.ItemForCustomsDocumentNumber.Text = "Fərdi Sənəd Nömrəsi";
            this.ItemForCustomsDocumentNumber.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForStoreCode
            // 
            this.ItemForStoreCode.Control = this.lUE_StoreCode;
            this.ItemForStoreCode.Location = new System.Drawing.Point(425, 48);
            this.ItemForStoreCode.Name = "ItemForStoreCode";
            this.ItemForStoreCode.Size = new System.Drawing.Size(426, 24);
            this.ItemForStoreCode.Text = "Mağaza";
            this.ItemForStoreCode.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForWarehouseCode
            // 
            this.ItemForWarehouseCode.Control = this.lUE_WarehouseCode;
            this.ItemForWarehouseCode.Location = new System.Drawing.Point(425, 72);
            this.ItemForWarehouseCode.Name = "ItemForWarehouseCode";
            this.ItemForWarehouseCode.Size = new System.Drawing.Size(426, 24);
            this.ItemForWarehouseCode.Text = "Depo";
            this.ItemForWarehouseCode.TextSize = new System.Drawing.Size(98, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.memoEdit_Desc;
            this.ItemForDescription.Location = new System.Drawing.Point(425, 96);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(426, 24);
            this.ItemForDescription.Text = "Açıqlama";
            this.ItemForDescription.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lbl_Payment
            // 
            this.lbl_Payment.Control = this.labelControl1;
            this.lbl_Payment.Location = new System.Drawing.Point(0, 413);
            this.lbl_Payment.MinSize = new System.Drawing.Size(67, 17);
            this.lbl_Payment.Name = "lbl_Payment";
            this.lbl_Payment.Size = new System.Drawing.Size(851, 29);
            this.lbl_Payment.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lbl_Payment.TextSize = new System.Drawing.Size(0, 0);
            this.lbl_Payment.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lC_CurrAccDesc;
            this.layoutControlItem2.Location = new System.Drawing.Point(610, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(241, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_Save,
            this.bBI_SaveAndNew,
            this.bBI_reportDesign,
            this.barButtonItem1,
            this.bBI_New,
            this.bBI_reportPreview});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsTouch.ShowTouchUISelectorInQAT = true;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(871, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // bBI_Save
            // 
            this.bBI_Save.Caption = "Yadda Saxla";
            this.bBI_Save.Id = 1;
            this.bBI_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Save.ImageOptions.SvgImage")));
            this.bBI_Save.Name = "bBI_Save";
            this.bBI_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Save_ItemClick);
            // 
            // bBI_SaveAndNew
            // 
            this.bBI_SaveAndNew.Caption = "Yadda Saxla & Yeni";
            this.bBI_SaveAndNew.Id = 2;
            this.bBI_SaveAndNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_SaveAndNew.ImageOptions.SvgImage")));
            this.bBI_SaveAndNew.Name = "bBI_SaveAndNew";
            this.bBI_SaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SaveAndNew_ItemClick);
            // 
            // bBI_reportDesign
            // 
            this.bBI_reportDesign.Caption = "Report Dizayn";
            this.bBI_reportDesign.Id = 3;
            this.bBI_reportDesign.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_reportDesign.ImageOptions.SvgImage")));
            this.bBI_reportDesign.Name = "bBI_reportDesign";
            this.bBI_reportDesign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_reportDesign_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ödəmə";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bBI_New
            // 
            this.bBI_New.Caption = "Yeni";
            this.bBI_New.Id = 9;
            this.bBI_New.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_New.ImageOptions.SvgImage")));
            this.bBI_New.Name = "bBI_New";
            this.bBI_New.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_New_ItemClick);
            // 
            // bBI_reportPreview
            // 
            this.bBI_reportPreview.Caption = "Report Görünüş";
            this.bBI_reportPreview.Id = 10;
            this.bBI_reportPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_reportPreview.ImageOptions.SvgImage")));
            this.bBI_reportPreview.Name = "bBI_reportPreview";
            this.bBI_reportPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_reportPreview_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Faktura";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_Save);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_SaveAndNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_New);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Yadda Saxla";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bBI_reportDesign);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.bBI_reportPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 620);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(871, 24);
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(871, 644);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormInvoice";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Faktura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_SalesPersonCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_IsReturn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomsDocumentNumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUE_OfficeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUE_StoreCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lUE_WarehouseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOfficeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomsDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.BindingSource trInvoiceLinesBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource trInvoiceHeadersBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.CheckEdit CheckEdit_IsReturn;
        private DevExpress.XtraEditors.DateEdit DocumentDateDateEdit;
        private DevExpress.XtraEditors.TimeSpanEdit DocumentTimeTimeSpanEdit;
        private DevExpress.XtraEditors.TextEdit CustomsDocumentNumberTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsReturn;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOfficeCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWarehouseCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCustomsDocumentNumber;
        private DevExpress.XtraGrid.GridControl gC_InvoiceLine;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_InvoiceLine;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceLineId;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Price;
        private DevExpress.XtraGrid.Columns.GridColumn col_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn col_PosDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn col_NetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_LineDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_DocNum;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Desc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_CurrAccCode;
        private DevExpress.XtraEditors.LookUpEdit lUE_OfficeCode;
        private DevExpress.XtraEditors.LookUpEdit lUE_StoreCode;
        private DevExpress.XtraEditors.LookUpEdit lUE_WarehouseCode;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bBI_Save;
        private DevExpress.XtraBars.BarButtonItem bBI_SaveAndNew;
        private DevExpress.XtraGrid.Columns.GridColumn col_SalesPersonCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_SalesPersonCode;
        private DevExpress.XtraBars.BarButtonItem bBI_reportDesign;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem lbl_Payment;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyIn;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyOut;
        private DevExpress.XtraBars.BarButtonItem bBI_New;
        private DevExpress.XtraBars.BarButtonItem bBI_reportPreview;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductDesc;
        private DevExpress.XtraEditors.LabelControl lC_CurrAccDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}