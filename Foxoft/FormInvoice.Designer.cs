
using Foxoft.Models;
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
         this.lbl_PrintCount = new DevExpress.XtraEditors.LabelControl();
         this.lbl_CurrAccDesc = new DevExpress.XtraEditors.LabelControl();
         this.lbl_InvoicePaidSum = new DevExpress.XtraEditors.LabelControl();
         this.gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
         this.gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.col_InvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_InvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
         this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQtyOut = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPriceLoc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoCalcEdit_PriceLoc = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
         this.col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoCalcEdit_Price = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
         this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
         this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_PosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_NetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_LineDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_SalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoBtnEdit_SalesPersonCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
         this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_ProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colNetAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colBenefit = new DevExpress.XtraGrid.Columns.GridColumn();
         this.CheckEdit_IsReturn = new DevExpress.XtraEditors.CheckEdit();
         this.trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.DocumentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
         this.DocumentTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
         this.CustomsDocumentNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
         this.btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
         this.memoEdit_Desc = new DevExpress.XtraEditors.MemoEdit();
         this.btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
         this.lUE_StoreCode = new DevExpress.XtraEditors.LookUpEdit();
         this.lUE_WarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
         this.lUE_ToWarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_Save = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_SaveAndNew = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_reportDesign = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Payment = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_New = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_reportPreview = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_DeleteInvoice = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_DeletePayment = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_SaveAndQuit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_reportPreviewAzn = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CopyInvoice = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Whatsapp = new DevExpress.XtraBars.BarButtonItem();
         this.BBI_ModifyInvoice = new DevExpress.XtraBars.BarButtonItem();
         this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.Faktura = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
         this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
         this.ItemForIsReturn = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForCustomsDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForStoreCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
         this.lbl_Payment = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.ItemForToWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
         this.adorneruıManager1 = new DevExpress.Utils.VisualEffects.AdornerUIManager(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
         this.dataLayoutControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_PriceLoc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_Price)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLUE_CurrencyCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_SalesPersonCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_IsReturn.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.CustomsDocumentNumberTextEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Desc.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lUE_StoreCode.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lUE_WarehouseCode.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lUE_ToWarehouseCode.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForIsReturn)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomsDocumentNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForWarehouseCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lbl_Payment)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForToWarehouseCode)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.adorneruıManager1)).BeginInit();
         this.SuspendLayout();
         // 
         // dataLayoutControl1
         // 
         this.dataLayoutControl1.Controls.Add(this.lbl_PrintCount);
         this.dataLayoutControl1.Controls.Add(this.lbl_CurrAccDesc);
         this.dataLayoutControl1.Controls.Add(this.lbl_InvoicePaidSum);
         this.dataLayoutControl1.Controls.Add(this.gC_InvoiceLine);
         this.dataLayoutControl1.Controls.Add(this.CheckEdit_IsReturn);
         this.dataLayoutControl1.Controls.Add(this.DocumentDateDateEdit);
         this.dataLayoutControl1.Controls.Add(this.DocumentTimeTimeSpanEdit);
         this.dataLayoutControl1.Controls.Add(this.CustomsDocumentNumberTextEdit);
         this.dataLayoutControl1.Controls.Add(this.btnEdit_DocNum);
         this.dataLayoutControl1.Controls.Add(this.memoEdit_Desc);
         this.dataLayoutControl1.Controls.Add(this.btnEdit_CurrAccCode);
         this.dataLayoutControl1.Controls.Add(this.lUE_StoreCode);
         this.dataLayoutControl1.Controls.Add(this.lUE_WarehouseCode);
         this.dataLayoutControl1.Controls.Add(this.lUE_ToWarehouseCode);
         this.dataLayoutControl1.DataSource = this.trInvoiceHeadersBindingSource;
         this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
         this.dataLayoutControl1.Name = "dataLayoutControl1";
         this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(374, 328, 650, 400);
         this.dataLayoutControl1.Root = this.Root;
         this.dataLayoutControl1.Size = new System.Drawing.Size(886, 389);
         this.dataLayoutControl1.TabIndex = 4;
         this.dataLayoutControl1.Text = "dataLayoutControl1";
         // 
         // lbl_PrintCount
         // 
         this.lbl_PrintCount.Location = new System.Drawing.Point(12, 355);
         this.lbl_PrintCount.Name = "lbl_PrintCount";
         this.lbl_PrintCount.Size = new System.Drawing.Size(128, 22);
         this.lbl_PrintCount.StyleController = this.dataLayoutControl1;
         this.lbl_PrintCount.TabIndex = 12;
         this.lbl_PrintCount.Text = "Print Edilib: 0 ";
         // 
         // lbl_CurrAccDesc
         // 
         this.lbl_CurrAccDesc.Location = new System.Drawing.Point(626, 12);
         this.lbl_CurrAccDesc.Name = "lbl_CurrAccDesc";
         this.lbl_CurrAccDesc.Size = new System.Drawing.Size(248, 20);
         this.lbl_CurrAccDesc.StyleController = this.dataLayoutControl1;
         this.lbl_CurrAccDesc.TabIndex = 1;
         // 
         // lbl_InvoicePaidSum
         // 
         this.lbl_InvoicePaidSum.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.lbl_InvoicePaidSum.Appearance.Options.UseFont = true;
         this.lbl_InvoicePaidSum.Appearance.Options.UseTextOptions = true;
         this.lbl_InvoicePaidSum.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.lbl_InvoicePaidSum.Location = new System.Drawing.Point(144, 355);
         this.lbl_InvoicePaidSum.Name = "lbl_InvoicePaidSum";
         this.lbl_InvoicePaidSum.Size = new System.Drawing.Size(730, 22);
         this.lbl_InvoicePaidSum.StyleController = this.dataLayoutControl1;
         this.lbl_InvoicePaidSum.TabIndex = 1;
         this.lbl_InvoicePaidSum.Text = "Ödənilib: 0.00 USD";
         // 
         // gC_InvoiceLine
         // 
         this.gC_InvoiceLine.DataSource = this.trInvoiceLinesBindingSource;
         this.gC_InvoiceLine.Location = new System.Drawing.Point(12, 132);
         this.gC_InvoiceLine.MainView = this.gV_InvoiceLine;
         this.gC_InvoiceLine.Name = "gC_InvoiceLine";
         this.gC_InvoiceLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoBtnEdit_ProductCode,
            this.repoBtnEdit_SalesPersonCode,
            this.repoCalcEdit_Price,
            this.repoLUE_CurrencyCode,
            this.repoCalcEdit_PriceLoc});
         this.gC_InvoiceLine.Size = new System.Drawing.Size(862, 219);
         this.gC_InvoiceLine.TabIndex = 11;
         this.gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceLine});
         this.gC_InvoiceLine.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.gC_InvoiceLine_KeyDown);
         this.gC_InvoiceLine.EditorKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gC_InvoiceLine_EditorKeyPress);
         this.gC_InvoiceLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gC_InvoiceLine_KeyDown);
         // 
         // gV_InvoiceLine
         // 
         this.gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_InvoiceLineId,
            this.col_InvoiceHeaderId,
            this.col_ProductCode,
            this.colBalance,
            this.colQty,
            this.colQtyIn,
            this.colQtyOut,
            this.colPriceLoc,
            this.col_Price,
            this.colCurrencyCode,
            this.colExchangeRate,
            this.col_Amount,
            this.col_PosDiscount,
            this.col_NetAmount,
            this.col_LineDesc,
            this.col_SalesPersonCode,
            this.colCreatedDate,
            this.col_ProductDesc,
            this.colAmountLoc,
            this.colNetAmountLoc,
            this.colCreatedUserName,
            this.colLastPurchasePrice,
            this.colBenefit});
         this.gV_InvoiceLine.CustomizationFormBounds = new System.Drawing.Rectangle(760, 456, 264, 272);
         this.gV_InvoiceLine.GridControl = this.gC_InvoiceLine;
         this.gV_InvoiceLine.Name = "gV_InvoiceLine";
         this.gV_InvoiceLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
         this.gV_InvoiceLine.OptionsSelection.MultiSelect = true;
         this.gV_InvoiceLine.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
         this.gV_InvoiceLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
         this.gV_InvoiceLine.OptionsView.ShowFooter = true;
         this.gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
         this.gV_InvoiceLine.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gV_InvoiceLine_RowCellStyle);
         this.gV_InvoiceLine.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gV_InvoiceLine_InitNewRow);
         this.gV_InvoiceLine.HiddenEditor += new System.EventHandler(this.gV_InvoiceLine_HiddenEditor);
         this.gV_InvoiceLine.ShownEditor += new System.EventHandler(this.gV_InvoiceLine_ShownEditor);
         this.gV_InvoiceLine.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_InvoiceLine_CellValueChanging);
         this.gV_InvoiceLine.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gV_InvoiceLine_InvalidRowException);
         this.gV_InvoiceLine.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gV_InvoiceLine_RowDeleted);
         this.gV_InvoiceLine.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gV_InvoiceLine_ValidateRow);
         this.gV_InvoiceLine.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gV_InvoiceLine_RowUpdated);
         this.gV_InvoiceLine.RowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.gV_InvoiceLine_RowLoaded);
         this.gV_InvoiceLine.AsyncCompleted += new System.EventHandler(this.gV_InvoiceLine_AsyncCompleted);
         this.gV_InvoiceLine.DoubleClick += new System.EventHandler(this.gV_InvoiceLine_DoubleClick);
         this.gV_InvoiceLine.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gV_InvoiceLine_ValidatingEditor);
         this.gV_InvoiceLine.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gV_InvoiceLine_InvalidValueException);
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
         this.col_ProductCode.Width = 42;
         // 
         // repoBtnEdit_ProductCode
         // 
         this.repoBtnEdit_ProductCode.AutoHeight = false;
         this.repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
         this.repoBtnEdit_ProductCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoBtnEdit_ProductCode_ButtonPressed);
         // 
         // colBalance
         // 
         this.colBalance.FieldName = "Balance";
         this.colBalance.Name = "colBalance";
         this.colBalance.Visible = true;
         this.colBalance.VisibleIndex = 2;
         this.colBalance.Width = 33;
         // 
         // colQty
         // 
         this.colQty.FieldName = "Qty";
         this.colQty.Name = "colQty";
         this.colQty.Visible = true;
         this.colQty.VisibleIndex = 3;
         this.colQty.Width = 34;
         // 
         // colQtyIn
         // 
         this.colQtyIn.FieldName = "QtyIn";
         this.colQtyIn.Name = "colQtyIn";
         this.colQtyIn.Width = 89;
         // 
         // colQtyOut
         // 
         this.colQtyOut.FieldName = "QtyOut";
         this.colQtyOut.Name = "colQtyOut";
         this.colQtyOut.Width = 89;
         // 
         // colPriceLoc
         // 
         this.colPriceLoc.ColumnEdit = this.repoCalcEdit_PriceLoc;
         this.colPriceLoc.FieldName = "PriceLoc";
         this.colPriceLoc.Name = "colPriceLoc";
         // 
         // repoCalcEdit_PriceLoc
         // 
         this.repoCalcEdit_PriceLoc.AutoHeight = false;
         this.repoCalcEdit_PriceLoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repoCalcEdit_PriceLoc.Name = "repoCalcEdit_PriceLoc";
         // 
         // col_Price
         // 
         this.col_Price.Caption = "Qiymət";
         this.col_Price.ColumnEdit = this.repoCalcEdit_Price;
         this.col_Price.DisplayFormat.FormatString = "{0:n2}";
         this.col_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.col_Price.FieldName = "Price";
         this.col_Price.Name = "col_Price";
         this.col_Price.Visible = true;
         this.col_Price.VisibleIndex = 4;
         this.col_Price.Width = 45;
         // 
         // repoCalcEdit_Price
         // 
         this.repoCalcEdit_Price.AutoHeight = false;
         this.repoCalcEdit_Price.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.repoCalcEdit_Price.MaskSettings.Set("mask", "");
         this.repoCalcEdit_Price.MaskSettings.Set("valueType", typeof(decimal));
         this.repoCalcEdit_Price.MaskSettings.Set("culture", null);
         this.repoCalcEdit_Price.MaskSettings.Set("autoHideDecimalSeparator", null);
         this.repoCalcEdit_Price.Name = "repoCalcEdit_Price";
         // 
         // colCurrencyCode
         // 
         this.colCurrencyCode.ColumnEdit = this.repoLUE_CurrencyCode;
         this.colCurrencyCode.FieldName = "CurrencyCode";
         this.colCurrencyCode.Name = "colCurrencyCode";
         this.colCurrencyCode.Visible = true;
         this.colCurrencyCode.VisibleIndex = 5;
         this.colCurrencyCode.Width = 45;
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
         this.repoLUE_CurrencyCode.ShowFooter = false;
         this.repoLUE_CurrencyCode.ShowHeader = false;
         this.repoLUE_CurrencyCode.ValueMember = "CurrencyCode";
         this.repoLUE_CurrencyCode.EditValueChanged += new System.EventHandler(this.repoLUE_CurrencyCode_EditValueChanged);
         // 
         // colExchangeRate
         // 
         this.colExchangeRate.FieldName = "ExchangeRate";
         this.colExchangeRate.Name = "colExchangeRate";
         this.colExchangeRate.Width = 57;
         // 
         // col_Amount
         // 
         this.col_Amount.Caption = "Tutar";
         this.col_Amount.DisplayFormat.FormatString = "{0:n2}";
         this.col_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.col_Amount.FieldName = "Amount";
         this.col_Amount.Name = "col_Amount";
         this.col_Amount.OptionsColumn.AllowEdit = false;
         this.col_Amount.Width = 89;
         // 
         // col_PosDiscount
         // 
         this.col_PosDiscount.DisplayFormat.FormatString = "{0:n2}";
         this.col_PosDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.col_PosDiscount.FieldName = "PosDiscount";
         this.col_PosDiscount.Name = "col_PosDiscount";
         this.col_PosDiscount.Visible = true;
         this.col_PosDiscount.VisibleIndex = 6;
         this.col_PosDiscount.Width = 89;
         // 
         // col_NetAmount
         // 
         this.col_NetAmount.Caption = "Net Tutar";
         this.col_NetAmount.DisplayFormat.FormatString = "{0:n2}";
         this.col_NetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.col_NetAmount.FieldName = "NetAmount";
         this.col_NetAmount.Name = "col_NetAmount";
         this.col_NetAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmount", "{0:n2}")});
         this.col_NetAmount.Visible = true;
         this.col_NetAmount.VisibleIndex = 7;
         this.col_NetAmount.Width = 42;
         // 
         // col_LineDesc
         // 
         this.col_LineDesc.Caption = "Qeyd";
         this.col_LineDesc.FieldName = "LineDescription";
         this.col_LineDesc.Name = "col_LineDesc";
         this.col_LineDesc.Visible = true;
         this.col_LineDesc.VisibleIndex = 8;
         this.col_LineDesc.Width = 34;
         // 
         // col_SalesPersonCode
         // 
         this.col_SalesPersonCode.ColumnEdit = this.repoBtnEdit_SalesPersonCode;
         this.col_SalesPersonCode.FieldName = "SalesPersonCode";
         this.col_SalesPersonCode.Name = "col_SalesPersonCode";
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
         this.col_ProductDesc.FieldName = "ProductDesc";
         this.col_ProductDesc.MinWidth = 100;
         this.col_ProductDesc.Name = "col_ProductDesc";
         this.col_ProductDesc.OptionsColumn.AllowEdit = false;
         this.col_ProductDesc.Visible = true;
         this.col_ProductDesc.VisibleIndex = 1;
         this.col_ProductDesc.Width = 225;
         // 
         // colAmountLoc
         // 
         this.colAmountLoc.FieldName = "AmountLoc";
         this.colAmountLoc.Name = "colAmountLoc";
         // 
         // colNetAmountLoc
         // 
         this.colNetAmountLoc.DisplayFormat.FormatString = "{0:n2}";
         this.colNetAmountLoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colNetAmountLoc.FieldName = "NetAmountLoc";
         this.colNetAmountLoc.Name = "colNetAmountLoc";
         this.colNetAmountLoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmountLoc", "Toplam={0:n2}")});
         // 
         // colCreatedUserName
         // 
         this.colCreatedUserName.FieldName = "CreatedUserName";
         this.colCreatedUserName.Name = "colCreatedUserName";
         this.colCreatedUserName.OptionsColumn.ReadOnly = true;
         // 
         // colLastPurchasePrice
         // 
         this.colLastPurchasePrice.DisplayFormat.FormatString = "{0:n2}";
         this.colLastPurchasePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colLastPurchasePrice.FieldName = "LastPurchasePrice";
         this.colLastPurchasePrice.Name = "colLastPurchasePrice";
         this.colLastPurchasePrice.Visible = true;
         this.colLastPurchasePrice.VisibleIndex = 9;
         this.colLastPurchasePrice.Width = 57;
         // 
         // colBenefit
         // 
         this.colBenefit.DisplayFormat.FormatString = "{0:n2}";
         this.colBenefit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colBenefit.FieldName = "Benefit";
         this.colBenefit.Name = "colBenefit";
         this.colBenefit.Visible = true;
         this.colBenefit.VisibleIndex = 10;
         this.colBenefit.Width = 71;
         // 
         // CheckEdit_IsReturn
         // 
         this.CheckEdit_IsReturn.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "IsReturn", true));
         this.CheckEdit_IsReturn.Enabled = false;
         this.CheckEdit_IsReturn.Location = new System.Drawing.Point(12, 36);
         this.CheckEdit_IsReturn.Name = "CheckEdit_IsReturn";
         this.CheckEdit_IsReturn.Properties.Caption = "Qaytarılmadır";
         this.CheckEdit_IsReturn.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
         this.CheckEdit_IsReturn.Size = new System.Drawing.Size(411, 20);
         this.CheckEdit_IsReturn.StyleController = this.dataLayoutControl1;
         this.CheckEdit_IsReturn.TabIndex = 3;
         // 
         // trInvoiceHeadersBindingSource
         // 
         this.trInvoiceHeadersBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.trInvoiceHeadersBindingSource_AddingNew);
         this.trInvoiceHeadersBindingSource.CurrentItemChanged += new System.EventHandler(this.trInvoiceHeadersBindingSource_CurrentItemChanged);
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
         this.DocumentDateDateEdit.Size = new System.Drawing.Size(301, 20);
         this.DocumentDateDateEdit.StyleController = this.dataLayoutControl1;
         this.DocumentDateDateEdit.TabIndex = 7;
         this.DocumentDateDateEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // DocumentTimeTimeSpanEdit
         // 
         this.DocumentTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentTime", true));
         this.DocumentTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
         this.DocumentTimeTimeSpanEdit.Location = new System.Drawing.Point(122, 108);
         this.DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
         this.DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.DocumentTimeTimeSpanEdit.Size = new System.Drawing.Size(301, 20);
         this.DocumentTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
         this.DocumentTimeTimeSpanEdit.TabIndex = 9;
         this.DocumentTimeTimeSpanEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // CustomsDocumentNumberTextEdit
         // 
         this.CustomsDocumentNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "CustomsDocumentNumber", true));
         this.CustomsDocumentNumberTextEdit.Location = new System.Drawing.Point(122, 60);
         this.CustomsDocumentNumberTextEdit.Name = "CustomsDocumentNumberTextEdit";
         this.CustomsDocumentNumberTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
         this.CustomsDocumentNumberTextEdit.Size = new System.Drawing.Size(301, 20);
         this.CustomsDocumentNumberTextEdit.StyleController = this.dataLayoutControl1;
         this.CustomsDocumentNumberTextEdit.TabIndex = 5;
         this.CustomsDocumentNumberTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // btnEdit_DocNum
         // 
         this.btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentNumber", true));
         this.btnEdit_DocNum.Location = new System.Drawing.Point(122, 12);
         this.btnEdit_DocNum.Name = "btnEdit_DocNum";
         this.btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
         this.btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.btnEdit_DocNum.Size = new System.Drawing.Size(301, 20);
         this.btnEdit_DocNum.StyleController = this.dataLayoutControl1;
         this.btnEdit_DocNum.TabIndex = 0;
         this.btnEdit_DocNum.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_DocNum_ButtonPressed);
         this.btnEdit_DocNum.DoubleClick += new System.EventHandler(this.btnEdit_DocNum_DoubleClick);
         this.btnEdit_DocNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // memoEdit_Desc
         // 
         this.memoEdit_Desc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "Description", true));
         this.memoEdit_Desc.Location = new System.Drawing.Point(537, 108);
         this.memoEdit_Desc.Name = "memoEdit_Desc";
         this.memoEdit_Desc.Size = new System.Drawing.Size(337, 20);
         this.memoEdit_Desc.StyleController = this.dataLayoutControl1;
         this.memoEdit_Desc.TabIndex = 10;
         this.memoEdit_Desc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // btnEdit_CurrAccCode
         // 
         this.btnEdit_CurrAccCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "CurrAccCode", true));
         this.btnEdit_CurrAccCode.Location = new System.Drawing.Point(537, 12);
         this.btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
         this.btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.btnEdit_CurrAccCode.Size = new System.Drawing.Size(85, 20);
         this.btnEdit_CurrAccCode.StyleController = this.dataLayoutControl1;
         this.btnEdit_CurrAccCode.TabIndex = 2;
         this.btnEdit_CurrAccCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_CurrAccCode_ButtonClick);
         this.btnEdit_CurrAccCode.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.btnEdit_CurrAccCode_InvalidValue);
         this.btnEdit_CurrAccCode.DoubleClick += new System.EventHandler(this.btnEdit_CurrAccCode_DoubleClick);
         this.btnEdit_CurrAccCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         this.btnEdit_CurrAccCode.Validating += new System.ComponentModel.CancelEventHandler(this.btnEdit_CurrAccCode_Validating);
         // 
         // lUE_StoreCode
         // 
         this.lUE_StoreCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "StoreCode", true));
         this.lUE_StoreCode.Location = new System.Drawing.Point(537, 60);
         this.lUE_StoreCode.Name = "lUE_StoreCode";
         this.lUE_StoreCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
         this.lUE_StoreCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.lUE_StoreCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "Mağaza Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "Mağaza Adı")});
         this.lUE_StoreCode.Properties.DisplayMember = "CurrAccDesc";
         this.lUE_StoreCode.Properties.NullText = "";
         this.lUE_StoreCode.Properties.ShowHeader = false;
         this.lUE_StoreCode.Properties.ValueMember = "CurrAccCode";
         this.lUE_StoreCode.Size = new System.Drawing.Size(337, 20);
         this.lUE_StoreCode.StyleController = this.dataLayoutControl1;
         this.lUE_StoreCode.TabIndex = 6;
         this.lUE_StoreCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // lUE_WarehouseCode
         // 
         this.lUE_WarehouseCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "WarehouseCode", true));
         this.lUE_WarehouseCode.Location = new System.Drawing.Point(537, 84);
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
         this.lUE_WarehouseCode.Size = new System.Drawing.Size(337, 20);
         this.lUE_WarehouseCode.StyleController = this.dataLayoutControl1;
         this.lUE_WarehouseCode.TabIndex = 8;
         this.lUE_WarehouseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataLayoutControls_KeyDown);
         // 
         // lUE_ToWarehouseCode
         // 
         this.lUE_ToWarehouseCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "ToWarehouseCode", true));
         this.lUE_ToWarehouseCode.Location = new System.Drawing.Point(537, 36);
         this.lUE_ToWarehouseCode.MenuManager = this.ribbonControl1;
         this.lUE_ToWarehouseCode.Name = "lUE_ToWarehouseCode";
         this.lUE_ToWarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.lUE_ToWarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı")});
         this.lUE_ToWarehouseCode.Properties.DisplayMember = "WarehouseDesc";
         this.lUE_ToWarehouseCode.Properties.NullText = "";
         this.lUE_ToWarehouseCode.Properties.ValueMember = "WarehouseCode";
         this.lUE_ToWarehouseCode.Size = new System.Drawing.Size(337, 20);
         this.lUE_ToWarehouseCode.StyleController = this.dataLayoutControl1;
         this.lUE_ToWarehouseCode.TabIndex = 4;
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
            this.bBI_Payment,
            this.bBI_New,
            this.bBI_reportPreview,
            this.bBI_DeleteInvoice,
            this.bBI_DeletePayment,
            this.bBI_SaveAndQuit,
            this.bBI_reportPreviewAzn,
            this.bBI_CopyInvoice,
            this.bBI_Whatsapp,
            this.BBI_ModifyInvoice,
            this.barButtonItem1});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 21;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.OptionsTouch.ShowTouchUISelectorInQAT = true;
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(886, 158);
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
         // bBI_Payment
         // 
         this.bBI_Payment.Caption = "Ödəmə";
         this.bBI_Payment.Id = 5;
         this.bBI_Payment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Payment.ImageOptions.SvgImage")));
         this.bBI_Payment.Name = "bBI_Payment";
         this.bBI_Payment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Payment_ItemClick);
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
         // bBI_DeleteInvoice
         // 
         this.bBI_DeleteInvoice.Caption = "Fakturanı Sil";
         this.bBI_DeleteInvoice.Id = 11;
         this.bBI_DeleteInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_DeleteInvoice.ImageOptions.SvgImage")));
         this.bBI_DeleteInvoice.Name = "bBI_DeleteInvoice";
         this.bBI_DeleteInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DeleteInvoice_ItemClick);
         // 
         // bBI_DeletePayment
         // 
         this.bBI_DeletePayment.Caption = "Ödəməni Sil";
         this.bBI_DeletePayment.Id = 12;
         this.bBI_DeletePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_DeletePayment.ImageOptions.SvgImage")));
         this.bBI_DeletePayment.Name = "bBI_DeletePayment";
         this.bBI_DeletePayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DeletePayment_ItemClick);
         // 
         // bBI_SaveAndQuit
         // 
         this.bBI_SaveAndQuit.Caption = "Yadda Saxla Bağla";
         this.bBI_SaveAndQuit.Id = 13;
         this.bBI_SaveAndQuit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_SaveAndQuit.ImageOptions.SvgImage")));
         this.bBI_SaveAndQuit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
         this.bBI_SaveAndQuit.Name = "bBI_SaveAndQuit";
         this.bBI_SaveAndQuit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SaveAndQuit_ItemClick);
         // 
         // bBI_reportPreviewAzn
         // 
         this.bBI_reportPreviewAzn.Caption = "Report Görünüş Azn";
         this.bBI_reportPreviewAzn.Id = 16;
         this.bBI_reportPreviewAzn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_reportPreviewAzn.ImageOptions.SvgImage")));
         this.bBI_reportPreviewAzn.Name = "bBI_reportPreviewAzn";
         this.bBI_reportPreviewAzn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_reportPreviewAzn_ItemClick);
         // 
         // bBI_CopyInvoice
         // 
         this.bBI_CopyInvoice.Caption = "Kopyala";
         this.bBI_CopyInvoice.Id = 17;
         this.bBI_CopyInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CopyInvoice.ImageOptions.SvgImage")));
         this.bBI_CopyInvoice.Name = "bBI_CopyInvoice";
         this.bBI_CopyInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CopyInvoice_ItemClick);
         // 
         // bBI_Whatsapp
         // 
         this.bBI_Whatsapp.Caption = "Whatsappdan Göndər";
         this.bBI_Whatsapp.Id = 18;
         this.bBI_Whatsapp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Whatsapp.ImageOptions.SvgImage")));
         this.bBI_Whatsapp.Name = "bBI_Whatsapp";
         this.bBI_Whatsapp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Whatsapp_ItemClick);
         // 
         // BBI_ModifyInvoice
         // 
         this.BBI_ModifyInvoice.Caption = "Dəyiş";
         this.BBI_ModifyInvoice.Id = 19;
         this.BBI_ModifyInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ModifyInvoice.ImageOptions.SvgImage")));
         this.BBI_ModifyInvoice.Name = "BBI_ModifyInvoice";
         this.BBI_ModifyInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_ModifyInvoice_ItemClick);
         // 
         // barButtonItem1
         // 
         this.barButtonItem1.Caption = "bbi";
         this.barButtonItem1.Id = 20;
         this.barButtonItem1.Name = "barButtonItem1";
         this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.Faktura,
            this.ribbonPageGroup3,
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Faktura";
         // 
         // Faktura
         // 
         this.Faktura.ItemLinks.Add(this.bBI_Save);
         this.Faktura.ItemLinks.Add(this.bBI_SaveAndQuit);
         this.Faktura.ItemLinks.Add(this.bBI_SaveAndNew);
         this.Faktura.ItemLinks.Add(this.bBI_New);
         this.Faktura.ItemLinks.Add(this.bBI_DeleteInvoice);
         this.Faktura.Name = "Faktura";
         this.Faktura.Text = "Faktura";
         // 
         // ribbonPageGroup3
         // 
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_Payment);
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_DeletePayment);
         this.ribbonPageGroup3.Name = "ribbonPageGroup3";
         this.ribbonPageGroup3.Text = "Ödəmə";
         // 
         // ribbonPageGroup2
         // 
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_reportDesign);
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_reportPreview);
         this.ribbonPageGroup2.ItemLinks.Add(this.bBI_reportPreviewAzn);
         this.ribbonPageGroup2.Name = "ribbonPageGroup2";
         this.ribbonPageGroup2.Text = "Print";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CopyInvoice);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_Whatsapp);
         this.ribbonPageGroup1.ItemLinks.Add(this.BBI_ModifyInvoice);
         this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "Nəzarət";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 547);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(886, 24);
         // 
         // Root
         // 
         this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.Root.GroupBordersVisible = false;
         this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
         this.Root.Name = "Root";
         this.Root.Size = new System.Drawing.Size(886, 389);
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
            this.ItemForCustomsDocumentNumber,
            this.ItemForStoreCode,
            this.ItemForWarehouseCode,
            this.ItemForDescription,
            this.lbl_Payment,
            this.layoutControlItem2,
            this.ItemForToWarehouseCode,
            this.layoutControlItem3});
         this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
         this.layoutControlGroup1.Name = "autoGeneratedGroup0";
         this.layoutControlGroup1.Size = new System.Drawing.Size(866, 369);
         // 
         // ItemForIsReturn
         // 
         this.ItemForIsReturn.Control = this.CheckEdit_IsReturn;
         this.ItemForIsReturn.Location = new System.Drawing.Point(0, 24);
         this.ItemForIsReturn.Name = "ItemForIsReturn";
         this.ItemForIsReturn.Size = new System.Drawing.Size(415, 24);
         this.ItemForIsReturn.Text = "Qaytarılmadır";
         this.ItemForIsReturn.TextSize = new System.Drawing.Size(0, 0);
         this.ItemForIsReturn.TextVisible = false;
         // 
         // ItemForDocumentDate
         // 
         this.ItemForDocumentDate.Control = this.DocumentDateDateEdit;
         this.ItemForDocumentDate.Location = new System.Drawing.Point(0, 72);
         this.ItemForDocumentDate.Name = "ItemForDocumentDate";
         this.ItemForDocumentDate.Size = new System.Drawing.Size(415, 24);
         this.ItemForDocumentDate.Text = "Sənəd Tarixi";
         this.ItemForDocumentDate.TextSize = new System.Drawing.Size(98, 13);
         // 
         // ItemForDocumentTime
         // 
         this.ItemForDocumentTime.Control = this.DocumentTimeTimeSpanEdit;
         this.ItemForDocumentTime.Location = new System.Drawing.Point(0, 96);
         this.ItemForDocumentTime.Name = "ItemForDocumentTime";
         this.ItemForDocumentTime.Size = new System.Drawing.Size(415, 24);
         this.ItemForDocumentTime.Text = "Sənəd Vaxtı";
         this.ItemForDocumentTime.TextSize = new System.Drawing.Size(98, 13);
         // 
         // layoutControlItem1
         // 
         this.layoutControlItem1.Control = this.gC_InvoiceLine;
         this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
         this.layoutControlItem1.Name = "layoutControlItem1";
         this.layoutControlItem1.Size = new System.Drawing.Size(866, 223);
         this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem1.TextVisible = false;
         // 
         // ItemForDocumentNumber
         // 
         this.ItemForDocumentNumber.Control = this.btnEdit_DocNum;
         this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
         this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
         this.ItemForDocumentNumber.Size = new System.Drawing.Size(415, 24);
         this.ItemForDocumentNumber.Text = "Sənəd Nömrəsi";
         this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(98, 13);
         // 
         // ItemForCurrAccCode
         // 
         this.ItemForCurrAccCode.Control = this.btnEdit_CurrAccCode;
         this.ItemForCurrAccCode.Location = new System.Drawing.Point(415, 0);
         this.ItemForCurrAccCode.Name = "ItemForCurrAccCode";
         this.ItemForCurrAccCode.Size = new System.Drawing.Size(199, 24);
         this.ItemForCurrAccCode.Text = "Cari Hesab";
         this.ItemForCurrAccCode.TextSize = new System.Drawing.Size(98, 13);
         // 
         // ItemForCustomsDocumentNumber
         // 
         this.ItemForCustomsDocumentNumber.Control = this.CustomsDocumentNumberTextEdit;
         this.ItemForCustomsDocumentNumber.Location = new System.Drawing.Point(0, 48);
         this.ItemForCustomsDocumentNumber.Name = "ItemForCustomsDocumentNumber";
         this.ItemForCustomsDocumentNumber.Size = new System.Drawing.Size(415, 24);
         this.ItemForCustomsDocumentNumber.Text = "Fərdi Sənəd Nömrəsi";
         this.ItemForCustomsDocumentNumber.TextSize = new System.Drawing.Size(98, 13);
         // 
         // ItemForStoreCode
         // 
         this.ItemForStoreCode.Control = this.lUE_StoreCode;
         this.ItemForStoreCode.Location = new System.Drawing.Point(415, 48);
         this.ItemForStoreCode.Name = "ItemForStoreCode";
         this.ItemForStoreCode.Size = new System.Drawing.Size(451, 24);
         this.ItemForStoreCode.Text = "Mağaza";
         this.ItemForStoreCode.TextSize = new System.Drawing.Size(98, 13);
         // 
         // ItemForWarehouseCode
         // 
         this.ItemForWarehouseCode.Control = this.lUE_WarehouseCode;
         this.ItemForWarehouseCode.Location = new System.Drawing.Point(415, 72);
         this.ItemForWarehouseCode.Name = "ItemForWarehouseCode";
         this.ItemForWarehouseCode.Size = new System.Drawing.Size(451, 24);
         this.ItemForWarehouseCode.Text = "Depodan";
         this.ItemForWarehouseCode.TextSize = new System.Drawing.Size(98, 13);
         // 
         // ItemForDescription
         // 
         this.ItemForDescription.Control = this.memoEdit_Desc;
         this.ItemForDescription.Location = new System.Drawing.Point(415, 96);
         this.ItemForDescription.Name = "ItemForDescription";
         this.ItemForDescription.Size = new System.Drawing.Size(451, 24);
         this.ItemForDescription.Text = "Açıqlama";
         this.ItemForDescription.TextSize = new System.Drawing.Size(98, 13);
         // 
         // lbl_Payment
         // 
         this.lbl_Payment.Control = this.lbl_InvoicePaidSum;
         this.lbl_Payment.Location = new System.Drawing.Point(132, 343);
         this.lbl_Payment.MinSize = new System.Drawing.Size(67, 17);
         this.lbl_Payment.Name = "lbl_Payment";
         this.lbl_Payment.Size = new System.Drawing.Size(734, 26);
         this.lbl_Payment.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.lbl_Payment.TextSize = new System.Drawing.Size(0, 0);
         this.lbl_Payment.TextVisible = false;
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.lbl_CurrAccDesc;
         this.layoutControlItem2.Location = new System.Drawing.Point(614, 0);
         this.layoutControlItem2.MinSize = new System.Drawing.Size(67, 17);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(252, 24);
         this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem2.TextVisible = false;
         // 
         // ItemForToWarehouseCode
         // 
         this.ItemForToWarehouseCode.Control = this.lUE_ToWarehouseCode;
         this.ItemForToWarehouseCode.Location = new System.Drawing.Point(415, 24);
         this.ItemForToWarehouseCode.Name = "ItemForToWarehouseCode";
         this.ItemForToWarehouseCode.Size = new System.Drawing.Size(451, 24);
         this.ItemForToWarehouseCode.Text = "Depoya";
         this.ItemForToWarehouseCode.TextSize = new System.Drawing.Size(98, 13);
         // 
         // layoutControlItem3
         // 
         this.layoutControlItem3.Control = this.lbl_PrintCount;
         this.layoutControlItem3.Location = new System.Drawing.Point(0, 343);
         this.layoutControlItem3.MinSize = new System.Drawing.Size(67, 17);
         this.layoutControlItem3.Name = "layoutControlItem3";
         this.layoutControlItem3.Size = new System.Drawing.Size(132, 26);
         this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem3.TextVisible = false;
         // 
         // adorneruıManager1
         // 
         this.adorneruıManager1.Owner = this;
         // 
         // FormInvoice
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
         this.ClientSize = new System.Drawing.Size(886, 571);
         this.Controls.Add(this.dataLayoutControl1);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "FormInvoice";
         this.Ribbon = this.ribbonControl1;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "Faktura";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.FormInvoice_Load);
         this.Shown += new System.EventHandler(this.FormInvoice_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
         this.dataLayoutControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_PriceLoc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_Price)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLUE_CurrencyCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_SalesPersonCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_IsReturn.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.CustomsDocumentNumberTextEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Desc.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lUE_StoreCode.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lUE_WarehouseCode.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lUE_ToWarehouseCode.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForIsReturn)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomsDocumentNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForWarehouseCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lbl_Payment)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemForToWarehouseCode)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.adorneruıManager1)).EndInit();
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
      private DevExpress.XtraBars.BarButtonItem bBI_Payment;
      private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidSum;
      private DevExpress.XtraLayout.LayoutControlItem lbl_Payment;
      private DevExpress.XtraGrid.Columns.GridColumn colQtyIn;
      private DevExpress.XtraGrid.Columns.GridColumn colQtyOut;
      private DevExpress.XtraBars.BarButtonItem bBI_New;
      private DevExpress.XtraBars.BarButtonItem bBI_reportPreview;
      private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
      private DevExpress.XtraGrid.Columns.GridColumn col_ProductDesc;
      private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_Price;
      private DevExpress.XtraBars.BarButtonItem bBI_DeleteInvoice;
      private DevExpress.XtraBars.BarButtonItem bBI_DeletePayment;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
      private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
      private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_CurrencyCode;
      private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
      private DevExpress.XtraGrid.Columns.GridColumn colPriceLoc;
      private DevExpress.XtraGrid.Columns.GridColumn colAmountLoc;
      private DevExpress.XtraGrid.Columns.GridColumn colNetAmountLoc;
      private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_PriceLoc;
      private DevExpress.XtraBars.BarButtonItem bBI_SaveAndQuit;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup Faktura;
      private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
      private DevExpress.XtraGrid.Columns.GridColumn colQty;
      private DevExpress.XtraEditors.LabelControl lbl_CurrAccDesc;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
      private DevExpress.Utils.VisualEffects.AdornerUIManager adorneruıManager1;
      private DevExpress.XtraGrid.Columns.GridColumn colLastPurchasePrice;
      private DevExpress.XtraGrid.Columns.GridColumn colBalance;
      private DevExpress.XtraGrid.Columns.GridColumn colBenefit;
      private DevExpress.XtraBars.BarButtonItem bBI_reportPreviewAzn;
      private DevExpress.XtraBars.BarButtonItem bBI_CopyInvoice;
      private DevExpress.XtraBars.BarButtonItem bBI_Whatsapp;
      private DevExpress.XtraLayout.LayoutControlItem ItemForToWarehouseCode;
      private DevExpress.XtraEditors.LookUpEdit lUE_ToWarehouseCode;
      private DevExpress.XtraEditors.LabelControl lbl_PrintCount;
      private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
      private DevExpress.XtraBars.BarButtonItem BBI_ModifyInvoice;
      private DevExpress.XtraBars.BarButtonItem barButtonItem1;
   }
}