
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoice));
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            trInvoiceLinesBindingSource = new BindingSource(components);
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            LBL_SalesPersonDesc = new DevExpress.XtraEditors.LabelControl();
            lbl_CurrAccDesc = new DevExpress.XtraEditors.LabelControl();
            lbl_InvoicePaidSum = new DevExpress.XtraEditors.LabelControl();
            gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            col_InvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            col_InvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            col_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            colQtyOut = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriceLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_PriceLoc = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_Price = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            col_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            col_PosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            col_NetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            col_LineDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            col_SalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_SalesPersonCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            col_ProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colNetAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colBenefit = new DevExpress.XtraGrid.Columns.GridColumn();
            colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCost = new DevExpress.XtraGrid.Columns.GridColumn();
            colSerialNumberCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_SerialNumberCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            checkEdit_IsSent = new DevExpress.XtraEditors.CheckEdit();
            trInvoiceHeadersBindingSource = new BindingSource(components);
            checkEdit_IsReturn = new DevExpress.XtraEditors.CheckEdit();
            DocumentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            DocumentTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            CustomsDocumentNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            memoEdit_Desc = new DevExpress.XtraEditors.MemoEdit();
            btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            lUE_StoreCode = new DevExpress.XtraEditors.LookUpEdit();
            lUE_WarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
            lUE_ToWarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_Save = new DevExpress.XtraBars.BarButtonItem();
            bBI_SaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_reportDesign = new DevExpress.XtraBars.BarButtonItem();
            bBI_Payment = new DevExpress.XtraBars.BarButtonItem();
            bBI_New = new DevExpress.XtraBars.BarButtonItem();
            bBI_reportPreview = new DevExpress.XtraBars.BarButtonItem();
            bBI_DeleteInvoice = new DevExpress.XtraBars.BarButtonItem();
            bBI_DeletePayment = new DevExpress.XtraBars.BarButtonItem();
            bBI_SaveAndQuit = new DevExpress.XtraBars.BarButtonItem();
            bBI_CopyInvoice = new DevExpress.XtraBars.BarButtonItem();
            bBI_Whatsapp = new DevExpress.XtraBars.BarButtonItem();
            BBI_ModifyInvoice = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportPriceList = new DevExpress.XtraBars.BarButtonItem();
            BBI_exportXLSX = new DevExpress.XtraBars.BarButtonItem();
            BBI_ImportExcel = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportPrintFast = new DevExpress.XtraBars.BarButtonItem();
            BBI_PrintSettingSave = new DevExpress.XtraBars.BarButtonItem();
            BEI_PrinterName = new DevExpress.XtraBars.BarEditItem();
            repoCBE_PrinterName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            btn_info = new DevExpress.XtraBars.BarButtonItem();
            BBI_picture = new DevExpress.XtraBars.BarButtonItem();
            BBI_Print = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            BSI_ReportProduct = new DevExpress.XtraBars.BarSubItem();
            BBI_InvoiceExpenses = new DevExpress.XtraBars.BarButtonItem();
            BCI_ShowPicture = new DevExpress.XtraBars.BarCheckItem();
            BCI_ShowPrint = new DevExpress.XtraBars.BarCheckItem();
            BCI_ShowCopy = new DevExpress.XtraBars.BarCheckItem();
            BSI_ReportInvoice = new DevExpress.XtraBars.BarSubItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            Faktura = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RPG_Payment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RPG_Control = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            RibbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            repoTxtEdit_TwilioInstance = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            repoTxtEdit_TwilioToken = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            repo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            txtEdit_PrintCount = new DevExpress.XtraEditors.TextEdit();
            btnEdit_SalesPerson = new DevExpress.XtraEditors.ButtonEdit();
            LCI_SalesPerson = new DevExpress.XtraLayout.LayoutControlItem();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForIsReturn = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_GvProductList = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCustomsDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForStoreCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            lbl_Payment = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForToWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            lCI_printCount = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_IsSent = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            LCI_CurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_SalesPersonDesc = new DevExpress.XtraLayout.LayoutControlItem();
            adorneruıManager1 = new DevExpress.Utils.VisualEffects.AdornerUIManager(components);
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLinesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_PriceLoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_Price).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SalesPersonCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SerialNumberCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_IsSent.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_IsReturn.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentTimeTimeSpanEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomsDocumentNumberTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_Desc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_CurrAccCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lUE_StoreCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lUE_WarehouseCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lUE_ToWarehouseCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCBE_PrinterName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioInstance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioToken).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_PrintCount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_SalesPerson.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPerson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsReturn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_GvProductList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCustomsDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForStoreCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWarehouseCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lbl_Payment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForToWarehouseCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_printCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_IsSent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_CurrAccDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPersonDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)adorneruıManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // trInvoiceLinesBindingSource
            // 
            trInvoiceLinesBindingSource.DataSource = typeof(TrInvoiceLine);
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(LBL_SalesPersonDesc);
            dataLayoutControl1.Controls.Add(lbl_CurrAccDesc);
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidSum);
            dataLayoutControl1.Controls.Add(gC_InvoiceLine);
            dataLayoutControl1.Controls.Add(checkEdit_IsSent);
            dataLayoutControl1.Controls.Add(checkEdit_IsReturn);
            dataLayoutControl1.Controls.Add(DocumentDateDateEdit);
            dataLayoutControl1.Controls.Add(DocumentTimeTimeSpanEdit);
            dataLayoutControl1.Controls.Add(CustomsDocumentNumberTextEdit);
            dataLayoutControl1.Controls.Add(btnEdit_DocNum);
            dataLayoutControl1.Controls.Add(memoEdit_Desc);
            dataLayoutControl1.Controls.Add(btnEdit_CurrAccCode);
            dataLayoutControl1.Controls.Add(lUE_StoreCode);
            dataLayoutControl1.Controls.Add(lUE_WarehouseCode);
            dataLayoutControl1.Controls.Add(lUE_ToWarehouseCode);
            dataLayoutControl1.Controls.Add(txtEdit_PrintCount);
            dataLayoutControl1.Controls.Add(btnEdit_SalesPerson);
            dataLayoutControl1.DataSource = trInvoiceHeadersBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCI_SalesPerson });
            dataLayoutControl1.Location = new Point(0, 158);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1187, 260, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(1129, 389);
            dataLayoutControl1.TabIndex = 4;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // LBL_SalesPersonDesc
            // 
            LBL_SalesPersonDesc.Location = new Point(839, 36);
            LBL_SalesPersonDesc.Name = "LBL_SalesPersonDesc";
            LBL_SalesPersonDesc.Size = new Size(278, 20);
            LBL_SalesPersonDesc.StyleController = dataLayoutControl1;
            LBL_SalesPersonDesc.TabIndex = 14;
            // 
            // lbl_CurrAccDesc
            // 
            lbl_CurrAccDesc.Location = new Point(768, 12);
            lbl_CurrAccDesc.Name = "lbl_CurrAccDesc";
            lbl_CurrAccDesc.Size = new Size(349, 20);
            lbl_CurrAccDesc.StyleController = dataLayoutControl1;
            lbl_CurrAccDesc.TabIndex = 1;
            // 
            // lbl_InvoicePaidSum
            // 
            lbl_InvoicePaidSum.Appearance.Font = new Font("Tahoma", 16F);
            lbl_InvoicePaidSum.Appearance.Options.UseFont = true;
            lbl_InvoicePaidSum.Appearance.Options.UseTextOptions = true;
            lbl_InvoicePaidSum.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lbl_InvoicePaidSum.Location = new Point(257, 357);
            lbl_InvoicePaidSum.Name = "lbl_InvoicePaidSum";
            lbl_InvoicePaidSum.Size = new Size(860, 20);
            lbl_InvoicePaidSum.StyleController = dataLayoutControl1;
            lbl_InvoicePaidSum.TabIndex = 1;
            // 
            // gC_InvoiceLine
            // 
            gC_InvoiceLine.DataSource = trInvoiceLinesBindingSource;
            gC_InvoiceLine.Location = new Point(12, 132);
            gC_InvoiceLine.MainView = gV_InvoiceLine;
            gC_InvoiceLine.Name = "gC_InvoiceLine";
            gC_InvoiceLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoBtnEdit_ProductCode, repoBtnEdit_SalesPersonCode, repoCalcEdit_Price, repoLUE_CurrencyCode, repoCalcEdit_PriceLoc, repoBtnEdit_SerialNumberCode });
            gC_InvoiceLine.Size = new Size(1105, 221);
            gC_InvoiceLine.TabIndex = 11;
            gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceLine });
            gC_InvoiceLine.EditorKeyDown += gC_InvoiceLine_KeyDown;
            gC_InvoiceLine.EditorKeyUp += gC_InvoiceLine_EditorKeyUp;
            gC_InvoiceLine.EditorKeyPress += gC_InvoiceLine_EditorKeyPress;
            gC_InvoiceLine.KeyDown += gC_InvoiceLine_KeyDown;
            // 
            // gV_InvoiceLine
            // 
            gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { col_InvoiceLineId, col_InvoiceHeaderId, col_ProductCode, colBalance, colQty, colQtyIn, colQtyOut, colPriceLoc, col_Price, colCurrencyCode, colExchangeRate, col_Amount, col_PosDiscount, col_NetAmount, col_LineDesc, col_SalesPersonCode, col_ProductDesc, colAmountLoc, colNetAmountLoc, colBenefit, colBarcode, colCreatedDate, colCreatedUserName, colLastUpdatedDate, colLastUpdatedUserName, colProductCost, colSerialNumberCode });
            gV_InvoiceLine.CustomizationFormBounds = new Rectangle(760, 456, 264, 272);
            gV_InvoiceLine.GridControl = gC_InvoiceLine;
            gV_InvoiceLine.Name = "gV_InvoiceLine";
            gV_InvoiceLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_InvoiceLine.OptionsSelection.MultiSelect = true;
            gV_InvoiceLine.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            gV_InvoiceLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gV_InvoiceLine.OptionsView.ShowFooter = true;
            gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
            gV_InvoiceLine.RowCellStyle += gV_InvoiceLine_RowCellStyle;
            gV_InvoiceLine.RowStyle += gV_InvoiceLine_RowStyle;
            gV_InvoiceLine.PopupMenuShowing += gV_Report_PopupMenuShowing;
            gV_InvoiceLine.InitNewRow += gV_InvoiceLine_InitNewRow;
            gV_InvoiceLine.HiddenEditor += gV_InvoiceLine_HiddenEditor;
            gV_InvoiceLine.ShownEditor += gV_InvoiceLine_ShownEditor;
            gV_InvoiceLine.FocusedRowChanged += gV_InvoiceLine_FocusedRowChanged;
            gV_InvoiceLine.CellValueChanged += gV_InvoiceLine_CellValueChanged;
            gV_InvoiceLine.CellValueChanging += gV_InvoiceLine_CellValueChanging;
            gV_InvoiceLine.InvalidRowException += gV_InvoiceLine_InvalidRowException;
            gV_InvoiceLine.RowDeleting += gV_InvoiceLine_RowDeleting;
            gV_InvoiceLine.RowDeleted += gV_InvoiceLine_RowDeleted;
            gV_InvoiceLine.ValidateRow += gV_InvoiceLine_ValidateRow;
            gV_InvoiceLine.RowUpdated += gV_InvoiceLine_RowUpdated;
            gV_InvoiceLine.CustomUnboundColumnData += gV_InvoiceLine_CustomUnboundColumnData;
            gV_InvoiceLine.RowLoaded += gV_InvoiceLine_RowLoaded;
            gV_InvoiceLine.AsyncCompleted += gV_InvoiceLine_AsyncCompleted;
            gV_InvoiceLine.KeyDown += gV_InvoiceLine_KeyDown;
            gV_InvoiceLine.DoubleClick += gV_InvoiceLine_DoubleClick;
            gV_InvoiceLine.ValidatingEditor += gV_InvoiceLine_ValidatingEditor;
            gV_InvoiceLine.InvalidValueException += gV_InvoiceLine_InvalidValueException;
            // 
            // col_InvoiceLineId
            // 
            col_InvoiceLineId.FieldName = "InvoiceLineId";
            col_InvoiceLineId.Name = "col_InvoiceLineId";
            col_InvoiceLineId.OptionsEditForm.StartNewRow = true;
            // 
            // col_InvoiceHeaderId
            // 
            col_InvoiceHeaderId.FieldName = "InvoiceHeaderId";
            col_InvoiceHeaderId.Name = "col_InvoiceHeaderId";
            // 
            // col_ProductCode
            // 
            col_ProductCode.ColumnEdit = repoBtnEdit_ProductCode;
            col_ProductCode.FieldName = "ProductCode";
            col_ProductCode.Name = "col_ProductCode";
            col_ProductCode.Visible = true;
            col_ProductCode.VisibleIndex = 1;
            col_ProductCode.Width = 42;
            // 
            // repoBtnEdit_ProductCode
            // 
            repoBtnEdit_ProductCode.AutoHeight = false;
            repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            repoBtnEdit_ProductCode.ButtonPressed += repoBtnEdit_ProductCode_ButtonPressed;
            // 
            // colBalance
            // 
            colBalance.FieldName = "DcProduct.Balance";
            colBalance.Name = "colBalance";
            colBalance.OptionsColumn.AllowEdit = false;
            colBalance.OptionsColumn.ReadOnly = true;
            colBalance.UnboundDataType = typeof(int);
            colBalance.Visible = true;
            colBalance.VisibleIndex = 3;
            colBalance.Width = 33;
            // 
            // colQty
            // 
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 4;
            colQty.Width = 34;
            // 
            // colQtyIn
            // 
            colQtyIn.FieldName = "QtyIn";
            colQtyIn.Name = "colQtyIn";
            colQtyIn.OptionsColumn.AllowEdit = false;
            colQtyIn.Width = 89;
            // 
            // colQtyOut
            // 
            colQtyOut.FieldName = "QtyOut";
            colQtyOut.Name = "colQtyOut";
            colQtyOut.OptionsColumn.AllowEdit = false;
            colQtyOut.Width = 89;
            // 
            // colPriceLoc
            // 
            colPriceLoc.ColumnEdit = repoCalcEdit_PriceLoc;
            colPriceLoc.FieldName = "PriceLoc";
            colPriceLoc.Name = "colPriceLoc";
            // 
            // repoCalcEdit_PriceLoc
            // 
            repoCalcEdit_PriceLoc.AutoHeight = false;
            repoCalcEdit_PriceLoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_PriceLoc.Name = "repoCalcEdit_PriceLoc";
            // 
            // col_Price
            // 
            col_Price.ColumnEdit = repoCalcEdit_Price;
            col_Price.DisplayFormat.FormatString = "{0:n2}";
            col_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_Price.FieldName = "Price";
            col_Price.Name = "col_Price";
            col_Price.Visible = true;
            col_Price.VisibleIndex = 5;
            col_Price.Width = 45;
            // 
            // repoCalcEdit_Price
            // 
            repoCalcEdit_Price.AutoHeight = false;
            repoCalcEdit_Price.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_Price.MaskSettings.Set("mask", "");
            repoCalcEdit_Price.MaskSettings.Set("valueType", typeof(decimal));
            repoCalcEdit_Price.MaskSettings.Set("culture", null);
            repoCalcEdit_Price.MaskSettings.Set("autoHideDecimalSeparator", null);
            repoCalcEdit_Price.Name = "repoCalcEdit_Price";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.ColumnEdit = repoLUE_CurrencyCode;
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 6;
            colCurrencyCode.Width = 45;
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
            repoLUE_CurrencyCode.ShowFooter = false;
            repoLUE_CurrencyCode.ShowHeader = false;
            repoLUE_CurrencyCode.ValueMember = "CurrencyCode";
            repoLUE_CurrencyCode.EditValueChanged += repoLUE_CurrencyCode_EditValueChanged;
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            colExchangeRate.Width = 57;
            // 
            // col_Amount
            // 
            col_Amount.DisplayFormat.FormatString = "{0:n2}";
            col_Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_Amount.FieldName = "Amount";
            col_Amount.Name = "col_Amount";
            col_Amount.OptionsColumn.AllowEdit = false;
            col_Amount.Width = 89;
            // 
            // col_PosDiscount
            // 
            col_PosDiscount.DisplayFormat.FormatString = "{0:n2}";
            col_PosDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_PosDiscount.FieldName = "PosDiscount";
            col_PosDiscount.Name = "col_PosDiscount";
            col_PosDiscount.Visible = true;
            col_PosDiscount.VisibleIndex = 7;
            col_PosDiscount.Width = 89;
            // 
            // col_NetAmount
            // 
            col_NetAmount.DisplayFormat.FormatString = "{0:n2}";
            col_NetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_NetAmount.FieldName = "NetAmount";
            col_NetAmount.Name = "col_NetAmount";
            col_NetAmount.Visible = true;
            col_NetAmount.VisibleIndex = 8;
            col_NetAmount.Width = 42;
            // 
            // col_LineDesc
            // 
            col_LineDesc.FieldName = "LineDescription";
            col_LineDesc.Name = "col_LineDesc";
            col_LineDesc.Visible = true;
            col_LineDesc.VisibleIndex = 9;
            col_LineDesc.Width = 34;
            // 
            // col_SalesPersonCode
            // 
            col_SalesPersonCode.ColumnEdit = repoBtnEdit_SalesPersonCode;
            col_SalesPersonCode.FieldName = "SalesPersonCode";
            col_SalesPersonCode.Name = "col_SalesPersonCode";
            // 
            // repoBtnEdit_SalesPersonCode
            // 
            repoBtnEdit_SalesPersonCode.AutoHeight = false;
            repoBtnEdit_SalesPersonCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_SalesPersonCode.Name = "repoBtnEdit_SalesPersonCode";
            repoBtnEdit_SalesPersonCode.ButtonPressed += repoBtnEdit_SalesPersonCode_ButtonPressed;
            // 
            // col_ProductDesc
            // 
            col_ProductDesc.FieldName = "DcProduct.ProductDesc";
            col_ProductDesc.MinWidth = 100;
            col_ProductDesc.Name = "col_ProductDesc";
            col_ProductDesc.OptionsColumn.AllowEdit = false;
            col_ProductDesc.UnboundDataType = typeof(string);
            col_ProductDesc.Visible = true;
            col_ProductDesc.VisibleIndex = 2;
            col_ProductDesc.Width = 225;
            // 
            // colAmountLoc
            // 
            colAmountLoc.FieldName = "AmountLoc";
            colAmountLoc.Name = "colAmountLoc";
            colAmountLoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountLoc", "{0:n2}") });
            // 
            // colNetAmountLoc
            // 
            colNetAmountLoc.DisplayFormat.FormatString = "{0:n2}";
            colNetAmountLoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colNetAmountLoc.FieldName = "NetAmountLoc";
            colNetAmountLoc.Name = "colNetAmountLoc";
            colNetAmountLoc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmountLoc", "{0:n2}") });
            // 
            // colBenefit
            // 
            colBenefit.DisplayFormat.FormatString = "{0:n2}";
            colBenefit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBenefit.FieldName = "Benefit";
            colBenefit.Name = "colBenefit";
            colBenefit.Visible = true;
            colBenefit.VisibleIndex = 11;
            colBenefit.Width = 71;
            // 
            // colBarcode
            // 
            colBarcode.FieldName = "Barcode";
            colBarcode.Name = "colBarcode";
            colBarcode.Visible = true;
            colBarcode.VisibleIndex = 0;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            colCreatedUserName.OptionsColumn.ReadOnly = true;
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colProductCost
            // 
            colProductCost.FieldName = "ProductCost";
            colProductCost.Name = "colProductCost";
            colProductCost.Visible = true;
            colProductCost.VisibleIndex = 10;
            // 
            // colSerialNumberCode
            // 
            colSerialNumberCode.ColumnEdit = repoBtnEdit_SerialNumberCode;
            colSerialNumberCode.FieldName = "SerialNumberCode";
            colSerialNumberCode.Name = "colSerialNumberCode";
            colSerialNumberCode.Visible = true;
            colSerialNumberCode.VisibleIndex = 12;
            // 
            // repoBtnEdit_SerialNumberCode
            // 
            repoBtnEdit_SerialNumberCode.AutoHeight = false;
            repoBtnEdit_SerialNumberCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_SerialNumberCode.Name = "repoBtnEdit_SerialNumberCode";
            repoBtnEdit_SerialNumberCode.ButtonPressed += repoBtnEdit_SerialNumberCode_ButtonPressed;
            // 
            // checkEdit_IsSent
            // 
            checkEdit_IsSent.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "IsSent", true));
            checkEdit_IsSent.Enabled = false;
            checkEdit_IsSent.Location = new Point(12, 357);
            checkEdit_IsSent.Name = "checkEdit_IsSent";
            checkEdit_IsSent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            checkEdit_IsSent.Size = new Size(91, 20);
            checkEdit_IsSent.StyleController = dataLayoutControl1;
            checkEdit_IsSent.TabIndex = 12;
            // 
            // trInvoiceHeadersBindingSource
            // 
            trInvoiceHeadersBindingSource.AddingNew += trInvoiceHeadersBindingSource_AddingNew;
            trInvoiceHeadersBindingSource.CurrentItemChanged += trInvoiceHeadersBindingSource_CurrentItemChanged;
            // 
            // checkEdit_IsReturn
            // 
            checkEdit_IsReturn.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "IsReturn", true));
            checkEdit_IsReturn.Enabled = false;
            checkEdit_IsReturn.Location = new Point(12, 36);
            checkEdit_IsReturn.Name = "checkEdit_IsReturn";
            checkEdit_IsReturn.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            checkEdit_IsReturn.Size = new Size(119, 20);
            checkEdit_IsReturn.StyleController = dataLayoutControl1;
            checkEdit_IsReturn.TabIndex = 3;
            // 
            // DocumentDateDateEdit
            // 
            DocumentDateDateEdit.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentDate", true));
            DocumentDateDateEdit.EditValue = null;
            DocumentDateDateEdit.Location = new Point(122, 84);
            DocumentDateDateEdit.Name = "DocumentDateDateEdit";
            DocumentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentDateDateEdit.Size = new Size(431, 20);
            DocumentDateDateEdit.StyleController = dataLayoutControl1;
            DocumentDateDateEdit.TabIndex = 7;
            DocumentDateDateEdit.KeyDown += dataLayoutControls_KeyDown;
            // 
            // DocumentTimeTimeSpanEdit
            // 
            DocumentTimeTimeSpanEdit.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentTime", true));
            DocumentTimeTimeSpanEdit.EditValue = TimeSpan.Parse("00:00:00");
            DocumentTimeTimeSpanEdit.Location = new Point(122, 108);
            DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
            DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentTimeTimeSpanEdit.Size = new Size(431, 20);
            DocumentTimeTimeSpanEdit.StyleController = dataLayoutControl1;
            DocumentTimeTimeSpanEdit.TabIndex = 9;
            DocumentTimeTimeSpanEdit.KeyDown += dataLayoutControls_KeyDown;
            // 
            // CustomsDocumentNumberTextEdit
            // 
            CustomsDocumentNumberTextEdit.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "CustomsDocumentNumber", true));
            CustomsDocumentNumberTextEdit.Location = new Point(122, 60);
            CustomsDocumentNumberTextEdit.Name = "CustomsDocumentNumberTextEdit";
            CustomsDocumentNumberTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            CustomsDocumentNumberTextEdit.Size = new Size(431, 20);
            CustomsDocumentNumberTextEdit.StyleController = dataLayoutControl1;
            CustomsDocumentNumberTextEdit.TabIndex = 5;
            CustomsDocumentNumberTextEdit.KeyDown += dataLayoutControls_KeyDown;
            // 
            // btnEdit_DocNum
            // 
            btnEdit_DocNum.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentNumber", true));
            btnEdit_DocNum.Location = new Point(122, 12);
            btnEdit_DocNum.Name = "btnEdit_DocNum";
            btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_DocNum.Size = new Size(431, 20);
            btnEdit_DocNum.StyleController = dataLayoutControl1;
            btnEdit_DocNum.TabIndex = 0;
            btnEdit_DocNum.ButtonPressed += btnEdit_DocNum_ButtonPressed;
            btnEdit_DocNum.DoubleClick += btnEdit_DocNum_DoubleClick;
            btnEdit_DocNum.KeyDown += dataLayoutControls_KeyDown;
            // 
            // memoEdit_Desc
            // 
            memoEdit_Desc.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "Description", true));
            memoEdit_Desc.Location = new Point(667, 108);
            memoEdit_Desc.Name = "memoEdit_Desc";
            memoEdit_Desc.Size = new Size(450, 20);
            memoEdit_Desc.StyleController = dataLayoutControl1;
            memoEdit_Desc.TabIndex = 10;
            memoEdit_Desc.KeyDown += dataLayoutControls_KeyDown;
            // 
            // btnEdit_CurrAccCode
            // 
            btnEdit_CurrAccCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "CurrAccCode", true));
            btnEdit_CurrAccCode.Location = new Point(667, 12);
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_CurrAccCode.Size = new Size(97, 20);
            btnEdit_CurrAccCode.StyleController = dataLayoutControl1;
            btnEdit_CurrAccCode.TabIndex = 2;
            btnEdit_CurrAccCode.ButtonClick += btnEdit_CurrAccCode_ButtonClick;
            btnEdit_CurrAccCode.InvalidValue += btnEdit_CurrAccCode_InvalidValue;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;
            btnEdit_CurrAccCode.DoubleClick += btnEdit_CurrAccCode_DoubleClick;
            btnEdit_CurrAccCode.KeyDown += dataLayoutControls_KeyDown;
            btnEdit_CurrAccCode.Validating += btnEdit_CurrAccCode_Validating;
            // 
            // lUE_StoreCode
            // 
            lUE_StoreCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "StoreCode", true));
            lUE_StoreCode.Location = new Point(667, 60);
            lUE_StoreCode.Name = "lUE_StoreCode";
            lUE_StoreCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            lUE_StoreCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lUE_StoreCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "Mağaza Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "Mağaza Adı") });
            lUE_StoreCode.Properties.DisplayMember = "CurrAccDesc";
            lUE_StoreCode.Properties.NullText = "";
            lUE_StoreCode.Properties.ShowHeader = false;
            lUE_StoreCode.Properties.ValueMember = "CurrAccCode";
            lUE_StoreCode.Size = new Size(450, 20);
            lUE_StoreCode.StyleController = dataLayoutControl1;
            lUE_StoreCode.TabIndex = 6;
            lUE_StoreCode.PopupFilter += lUE_StoreCode_PopupFilter;
            lUE_StoreCode.EditValueChanged += lUE_StoreCode_EditValueChanged;
            lUE_StoreCode.KeyDown += dataLayoutControls_KeyDown;
            // 
            // lUE_WarehouseCode
            // 
            lUE_WarehouseCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "WarehouseCode", true));
            lUE_WarehouseCode.Location = new Point(667, 84);
            lUE_WarehouseCode.Name = "lUE_WarehouseCode";
            lUE_WarehouseCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            lUE_WarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lUE_WarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı") });
            lUE_WarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            lUE_WarehouseCode.Properties.NullText = "";
            lUE_WarehouseCode.Properties.ShowHeader = false;
            lUE_WarehouseCode.Properties.ValueMember = "WarehouseCode";
            lUE_WarehouseCode.Size = new Size(450, 20);
            lUE_WarehouseCode.StyleController = dataLayoutControl1;
            lUE_WarehouseCode.TabIndex = 8;
            lUE_WarehouseCode.PopupFilter += lUE_WarehouseCode_PopupFilter;
            lUE_WarehouseCode.InvalidValue += lUE_WarehouseCode_InvalidValue;
            lUE_WarehouseCode.KeyDown += dataLayoutControls_KeyDown;
            lUE_WarehouseCode.Validating += lUE_WarehouseCode_Validating;
            // 
            // lUE_ToWarehouseCode
            // 
            lUE_ToWarehouseCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "ToWarehouseCode", true));
            lUE_ToWarehouseCode.Location = new Point(667, 36);
            lUE_ToWarehouseCode.MenuManager = ribbonControl1;
            lUE_ToWarehouseCode.Name = "lUE_ToWarehouseCode";
            lUE_ToWarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lUE_ToWarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı") });
            lUE_ToWarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            lUE_ToWarehouseCode.Properties.NullText = "";
            lUE_ToWarehouseCode.Properties.ValueMember = "WarehouseCode";
            lUE_ToWarehouseCode.Size = new Size(168, 20);
            lUE_ToWarehouseCode.StyleController = dataLayoutControl1;
            lUE_ToWarehouseCode.TabIndex = 4;
            lUE_ToWarehouseCode.PopupFilter += lUE_ToWarehouseCode_PopupFilter;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_Save, bBI_SaveAndNew, bBI_reportDesign, bBI_Payment, bBI_New, bBI_reportPreview, bBI_DeleteInvoice, bBI_DeletePayment, bBI_SaveAndQuit, bBI_CopyInvoice, bBI_Whatsapp, BBI_ModifyInvoice, barButtonItem1, BBI_ReportPriceList, BBI_exportXLSX, BBI_ImportExcel, BBI_ReportPrintFast, BBI_PrintSettingSave, BEI_PrinterName, barButtonItem3, btn_info, BBI_picture, BBI_Print, barButtonItem2, barButtonItem4, BSI_ReportProduct, BBI_InvoiceExpenses, BCI_ShowPicture, BCI_ShowPrint, BCI_ShowCopy, BSI_ReportInvoice });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 54;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsTouch.ShowTouchUISelectorInQAT = true;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoTxtEdit_TwilioInstance, repoTxtEdit_TwilioToken, repositoryItemTextEdit1, repo, repoCBE_PrinterName });
            ribbonControl1.Size = new Size(1129, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_Save
            // 
            bBI_Save.Caption = "Yadda Saxla";
            bBI_Save.Id = 1;
            bBI_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Save.ImageOptions.SvgImage");
            bBI_Save.Name = "bBI_Save";
            bBI_Save.ItemClick += bBI_Save_ItemClick;
            // 
            // bBI_SaveAndNew
            // 
            bBI_SaveAndNew.Caption = "Yadda Saxla & Yeni";
            bBI_SaveAndNew.Id = 2;
            bBI_SaveAndNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndNew.ImageOptions.SvgImage");
            bBI_SaveAndNew.Name = "bBI_SaveAndNew";
            bBI_SaveAndNew.ItemClick += bBI_SaveAndNew_ItemClick;
            // 
            // bBI_reportDesign
            // 
            bBI_reportDesign.Caption = "Report Dizayn";
            bBI_reportDesign.Id = 3;
            bBI_reportDesign.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_reportDesign.ImageOptions.SvgImage");
            bBI_reportDesign.Name = "bBI_reportDesign";
            bBI_reportDesign.ItemClick += bBI_reportDesign_ItemClick;
            // 
            // bBI_Payment
            // 
            bBI_Payment.Caption = "Ödəmə";
            bBI_Payment.Id = 5;
            bBI_Payment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Payment.ImageOptions.SvgImage");
            bBI_Payment.Name = "bBI_Payment";
            bBI_Payment.ItemClick += bBI_Payment_ItemClick;
            // 
            // bBI_New
            // 
            bBI_New.Caption = "Yeni";
            bBI_New.Id = 9;
            bBI_New.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_New.ImageOptions.SvgImage");
            bBI_New.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.N);
            bBI_New.Name = "bBI_New";
            bBI_New.ItemClick += bBI_New_ItemClick;
            // 
            // bBI_reportPreview
            // 
            bBI_reportPreview.Caption = "Report Görünüş";
            bBI_reportPreview.Id = 10;
            bBI_reportPreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_reportPreview.ImageOptions.SvgImage");
            bBI_reportPreview.Name = "bBI_reportPreview";
            bBI_reportPreview.ItemClick += bBI_reportPreview_ItemClick;
            // 
            // bBI_DeleteInvoice
            // 
            bBI_DeleteInvoice.Caption = "Fakturanı Sil";
            bBI_DeleteInvoice.Id = 11;
            bBI_DeleteInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_DeleteInvoice.ImageOptions.SvgImage");
            bBI_DeleteInvoice.Name = "bBI_DeleteInvoice";
            bBI_DeleteInvoice.ItemClick += bBI_DeleteInvoice_ItemClick;
            // 
            // bBI_DeletePayment
            // 
            bBI_DeletePayment.Caption = "Ödəməni Sil";
            bBI_DeletePayment.Id = 12;
            bBI_DeletePayment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_DeletePayment.ImageOptions.SvgImage");
            bBI_DeletePayment.Name = "bBI_DeletePayment";
            bBI_DeletePayment.ItemClick += bBI_DeletePayment_ItemClick;
            // 
            // bBI_SaveAndQuit
            // 
            bBI_SaveAndQuit.Caption = "Yadda Saxla Bağla";
            bBI_SaveAndQuit.Id = 13;
            bBI_SaveAndQuit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndQuit.ImageOptions.SvgImage");
            bBI_SaveAndQuit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F12);
            bBI_SaveAndQuit.Name = "bBI_SaveAndQuit";
            bBI_SaveAndQuit.ItemClick += bBI_SaveAndQuit_ItemClick;
            // 
            // bBI_CopyInvoice
            // 
            bBI_CopyInvoice.Caption = "Kopyala";
            bBI_CopyInvoice.Id = 17;
            bBI_CopyInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CopyInvoice.ImageOptions.SvgImage");
            bBI_CopyInvoice.Name = "bBI_CopyInvoice";
            bBI_CopyInvoice.ItemClick += bBI_CopyInvoice_ItemClick;
            // 
            // bBI_Whatsapp
            // 
            bBI_Whatsapp.Caption = "Whatsappdan Göndər";
            bBI_Whatsapp.Id = 18;
            bBI_Whatsapp.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Whatsapp.ImageOptions.SvgImage");
            bBI_Whatsapp.Name = "bBI_Whatsapp";
            bBI_Whatsapp.ItemClick += bBI_Whatsapp_ItemClick;
            // 
            // BBI_ModifyInvoice
            // 
            BBI_ModifyInvoice.Caption = "Dəyiş";
            BBI_ModifyInvoice.Id = 19;
            BBI_ModifyInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ModifyInvoice.ImageOptions.SvgImage");
            BBI_ModifyInvoice.Name = "BBI_ModifyInvoice";
            BBI_ModifyInvoice.ItemClick += BBI_ModifyInvoice_ItemClick;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "bbi";
            barButtonItem1.Id = 20;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += bbi_ItemClick;
            // 
            // BBI_ReportPriceList
            // 
            BBI_ReportPriceList.Caption = "Price List";
            BBI_ReportPriceList.Id = 21;
            BBI_ReportPriceList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportPriceList.ImageOptions.SvgImage");
            BBI_ReportPriceList.Name = "BBI_ReportPriceList";
            BBI_ReportPriceList.ItemClick += BBI_ReportPriceList_ItemClick;
            // 
            // BBI_exportXLSX
            // 
            BBI_exportXLSX.Caption = "Excel'ə Göndər";
            BBI_exportXLSX.Id = 22;
            BBI_exportXLSX.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_exportXLSX.ImageOptions.SvgImage");
            BBI_exportXLSX.Name = "BBI_exportXLSX";
            BBI_exportXLSX.ItemClick += BBI_exportXLSX_ItemClick;
            // 
            // BBI_ImportExcel
            // 
            BBI_ImportExcel.Caption = "Excel'dən Al";
            BBI_ImportExcel.Id = 23;
            BBI_ImportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ImportExcel.ImageOptions.SvgImage");
            BBI_ImportExcel.Name = "BBI_ImportExcel";
            BBI_ImportExcel.ItemClick += BBI_ImportExcel_ItemClick;
            // 
            // BBI_ReportPrintFast
            // 
            BBI_ReportPrintFast.Caption = "Sürətli Çap Et";
            BBI_ReportPrintFast.Id = 30;
            BBI_ReportPrintFast.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportPrintFast.ImageOptions.SvgImage");
            BBI_ReportPrintFast.Name = "BBI_ReportPrintFast";
            BBI_ReportPrintFast.ItemClick += BBI_ReportPrintFast_ItemClick;
            // 
            // BBI_PrintSettingSave
            // 
            BBI_PrintSettingSave.Caption = "Save";
            BBI_PrintSettingSave.Id = 31;
            BBI_PrintSettingSave.Name = "BBI_PrintSettingSave";
            BBI_PrintSettingSave.ItemClick += BBI_PrintSettingSave_ItemClick;
            // 
            // BEI_PrinterName
            // 
            BEI_PrinterName.Caption = "Printer";
            BEI_PrinterName.Edit = repoCBE_PrinterName;
            BEI_PrinterName.Id = 35;
            BEI_PrinterName.Name = "BEI_PrinterName";
            // 
            // repoCBE_PrinterName
            // 
            repoCBE_PrinterName.AutoHeight = false;
            repoCBE_PrinterName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCBE_PrinterName.Name = "repoCBE_PrinterName";
            repoCBE_PrinterName.EditValueChanged += repoCBE_PrinterName_EditValueChanged;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "test";
            barButtonItem3.Id = 36;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            // 
            // btn_info
            // 
            btn_info.Caption = "info";
            btn_info.Id = 39;
            btn_info.ImageOptions.Image = (Image)resources.GetObject("btn_info.ImageOptions.Image");
            btn_info.ImageOptions.LargeImage = (Image)resources.GetObject("btn_info.ImageOptions.LargeImage");
            btn_info.Name = "btn_info";
            btn_info.ItemClick += Btn_info_ItemClick;
            // 
            // BBI_picture
            // 
            BBI_picture.Caption = "Şəkillər";
            BBI_picture.Id = 40;
            BBI_picture.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_picture.ImageOptions.SvgImage");
            BBI_picture.Name = "BBI_picture";
            BBI_picture.ItemClick += BBI_picture_ItemClick;
            // 
            // BBI_Print
            // 
            BBI_Print.Caption = "Çap";
            BBI_Print.Id = 41;
            BBI_Print.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Print.ImageOptions.SvgImage");
            BBI_Print.Name = "BBI_Print";
            BBI_Print.ItemClick += BBI_Print_ItemClick;
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "test";
            barButtonItem2.Id = 42;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick_1;
            // 
            // barButtonItem4
            // 
            barButtonItem4.ActAsDropDown = true;
            barButtonItem4.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            barButtonItem4.Caption = "test02";
            barButtonItem4.DropDownControl = popupMenu1;
            barButtonItem4.Id = 43;
            barButtonItem4.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem4.ImageOptions.SvgImage");
            barButtonItem4.Name = "barButtonItem4";
            barButtonItem4.ItemClick += barButtonItem4_ItemClick;
            // 
            // popupMenu1
            // 
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = ribbonControl1;
            popupMenu1.BeforePopup += popupMenuPrinters_BeforePopup;
            // 
            // BSI_ReportProduct
            // 
            BSI_ReportProduct.Caption = "Hesabat Məhsul";
            BSI_ReportProduct.Id = 44;
            BSI_ReportProduct.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_ReportProduct.ImageOptions.SvgImage");
            BSI_ReportProduct.Name = "BSI_ReportProduct";
            // 
            // BBI_InvoiceExpenses
            // 
            BBI_InvoiceExpenses.Caption = "Xərclər";
            BBI_InvoiceExpenses.Id = 45;
            BBI_InvoiceExpenses.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_InvoiceExpenses.ImageOptions.SvgImage");
            BBI_InvoiceExpenses.Name = "BBI_InvoiceExpenses";
            BBI_InvoiceExpenses.ItemClick += BBI_InvoiceExpenses_ItemClick;
            // 
            // BCI_ShowPicture
            // 
            BCI_ShowPicture.Caption = "Rəsim Göstər";
            BCI_ShowPicture.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            BCI_ShowPicture.Id = 46;
            BCI_ShowPicture.Name = "BCI_ShowPicture";
            BCI_ShowPicture.CheckedChanged += BCI_CheckedChanged;
            // 
            // BCI_ShowPrint
            // 
            BCI_ShowPrint.Caption = "Printer Göstər";
            BCI_ShowPrint.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            BCI_ShowPrint.Id = 47;
            BCI_ShowPrint.Name = "BCI_ShowPrint";
            BCI_ShowPrint.CheckedChanged += BCI_CheckedChanged;
            // 
            // BCI_ShowCopy
            // 
            BCI_ShowCopy.Caption = "Kopya Göstər";
            BCI_ShowCopy.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            BCI_ShowCopy.Id = 49;
            BCI_ShowCopy.Name = "BCI_ShowCopy";
            BCI_ShowCopy.CheckedChanged += BCI_CheckedChanged;
            // 
            // BSI_ReportInvoice
            // 
            BSI_ReportInvoice.Caption = "Hesabat Faktura";
            BSI_ReportInvoice.Id = 51;
            BSI_ReportInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_ReportInvoice.ImageOptions.SvgImage");
            BSI_ReportInvoice.Name = "BSI_ReportInvoice";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { Faktura, RPG_Payment, ribbonPageGroup2, RPG_Control, ribbonPageGroup8 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Faktura";
            // 
            // Faktura
            // 
            Faktura.ItemLinks.Add(bBI_Save);
            Faktura.ItemLinks.Add(bBI_SaveAndQuit);
            Faktura.ItemLinks.Add(bBI_SaveAndNew);
            Faktura.ItemLinks.Add(bBI_New);
            Faktura.ItemLinks.Add(bBI_DeleteInvoice);
            Faktura.Name = "Faktura";
            Faktura.Text = "Əməliyat";
            // 
            // RPG_Payment
            // 
            RPG_Payment.ItemLinks.Add(bBI_Payment);
            RPG_Payment.ItemLinks.Add(bBI_DeletePayment);
            RPG_Payment.Name = "RPG_Payment";
            RPG_Payment.Text = "Ödəmə";
            RPG_Payment.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_reportPreview);
            ribbonPageGroup2.ItemLinks.Add(BBI_Print);
            ribbonPageGroup2.ItemLinks.Add(BBI_ReportPrintFast);
            ribbonPageGroup2.ItemLinks.Add(BSI_ReportProduct);
            ribbonPageGroup2.ItemLinks.Add(BSI_ReportInvoice);
            ribbonPageGroup2.ItemLinks.Add(bBI_CopyInvoice);
            ribbonPageGroup2.ItemLinks.Add(BBI_picture, true);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Print";
            // 
            // RPG_Control
            // 
            RPG_Control.ItemLinks.Add(bBI_Whatsapp);
            RPG_Control.ItemLinks.Add(BBI_ModifyInvoice, true);
            RPG_Control.ItemLinks.Add(BBI_InvoiceExpenses);
            RPG_Control.Name = "RPG_Control";
            RPG_Control.Text = "Nəzarət";
            RPG_Control.Visible = false;
            // 
            // ribbonPageGroup8
            // 
            ribbonPageGroup8.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            ribbonPageGroup8.ItemLinks.Add(btn_info);
            ribbonPageGroup8.Name = "ribbonPageGroup8";
            ribbonPageGroup8.Text = "Məlumat";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { RibbonPageGroup5, ribbonPageGroup6, ribbonPageGroup9, ribbonPageGroup1 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Ayarlar";
            // 
            // RibbonPageGroup5
            // 
            RibbonPageGroup5.ItemLinks.Add(bBI_reportDesign);
            RibbonPageGroup5.ItemLinks.Add(BBI_ReportPriceList);
            RibbonPageGroup5.ItemLinks.Add(barButtonItem1);
            RibbonPageGroup5.ItemLinks.Add(BBI_ImportExcel);
            RibbonPageGroup5.ItemLinks.Add(BBI_exportXLSX);
            RibbonPageGroup5.Name = "RibbonPageGroup5";
            RibbonPageGroup5.Text = "Hesabat";
            // 
            // ribbonPageGroup6
            // 
            ribbonPageGroup6.ItemLinks.Add(barButtonItem4);
            ribbonPageGroup6.ItemLinks.Add(BEI_PrinterName);
            ribbonPageGroup6.ItemLinks.Add(BBI_PrintSettingSave);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "Print";
            // 
            // ribbonPageGroup9
            // 
            ribbonPageGroup9.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup9.Name = "ribbonPageGroup9";
            ribbonPageGroup9.Text = "Test";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BCI_ShowPicture);
            ribbonPageGroup1.ItemLinks.Add(BCI_ShowPrint);
            ribbonPageGroup1.ItemLinks.Add(BCI_ShowCopy);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Show";
            // 
            // repoTxtEdit_TwilioInstance
            // 
            repoTxtEdit_TwilioInstance.AutoHeight = false;
            repoTxtEdit_TwilioInstance.Name = "repoTxtEdit_TwilioInstance";
            // 
            // repoTxtEdit_TwilioToken
            // 
            repoTxtEdit_TwilioToken.AutoHeight = false;
            repoTxtEdit_TwilioToken.Name = "repoTxtEdit_TwilioToken";
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repo
            // 
            repo.AutoHeight = false;
            repo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repo.Name = "repo";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 547);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1129, 24);
            // 
            // txtEdit_PrintCount
            // 
            txtEdit_PrintCount.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "PrintCount", true));
            txtEdit_PrintCount.Enabled = false;
            txtEdit_PrintCount.Location = new Point(192, 357);
            txtEdit_PrintCount.MenuManager = ribbonControl1;
            txtEdit_PrintCount.Name = "txtEdit_PrintCount";
            txtEdit_PrintCount.Properties.Appearance.Options.UseFont = true;
            txtEdit_PrintCount.Properties.Appearance.Options.UseTextOptions = true;
            txtEdit_PrintCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            txtEdit_PrintCount.Size = new Size(61, 20);
            txtEdit_PrintCount.StyleController = dataLayoutControl1;
            txtEdit_PrintCount.TabIndex = 13;
            // 
            // btnEdit_SalesPerson
            // 
            btnEdit_SalesPerson.Location = new Point(667, 60);
            btnEdit_SalesPerson.MenuManager = ribbonControl1;
            btnEdit_SalesPerson.Name = "btnEdit_SalesPerson";
            btnEdit_SalesPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_SalesPerson.Size = new Size(450, 20);
            btnEdit_SalesPerson.StyleController = dataLayoutControl1;
            btnEdit_SalesPerson.TabIndex = 1;
            btnEdit_SalesPerson.ButtonPressed += btnEdit_SalesPerson_ButtonPressed;
            btnEdit_SalesPerson.EditValueChanged += btnEdit_SalesPerson_EditValueChanged;
            // 
            // LCI_SalesPerson
            // 
            LCI_SalesPerson.Control = btnEdit_SalesPerson;
            LCI_SalesPerson.Location = new Point(545, 48);
            LCI_SalesPerson.Name = "LCI_SalesPerson";
            LCI_SalesPerson.Size = new Size(564, 24);
            LCI_SalesPerson.Text = "Satıcı";
            LCI_SalesPerson.TextSize = new Size(50, 20);
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(1129, 389);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForIsReturn, ItemForDocumentDate, ItemForDocumentTime, LCI_GvProductList, ItemForDocumentNumber, ItemForCurrAccCode, ItemForCustomsDocumentNumber, ItemForStoreCode, ItemForWarehouseCode, ItemForDescription, lbl_Payment, ItemForToWarehouseCode, emptySpaceItem1, lCI_printCount, lCI_IsSent, splitterItem1, LCI_CurrAccDesc, LCI_SalesPersonDesc });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(1109, 369);
            // 
            // ItemForIsReturn
            // 
            ItemForIsReturn.Control = checkEdit_IsReturn;
            ItemForIsReturn.Location = new Point(0, 24);
            ItemForIsReturn.Name = "ItemForIsReturn";
            ItemForIsReturn.Size = new Size(123, 24);
            ItemForIsReturn.Text = "Qaytarılmadır";
            ItemForIsReturn.TextSize = new Size(0, 0);
            ItemForIsReturn.TextVisible = false;
            // 
            // ItemForDocumentDate
            // 
            ItemForDocumentDate.Control = DocumentDateDateEdit;
            ItemForDocumentDate.Location = new Point(0, 72);
            ItemForDocumentDate.Name = "ItemForDocumentDate";
            ItemForDocumentDate.Size = new Size(545, 24);
            ItemForDocumentDate.Text = "Sənəd Tarixi";
            ItemForDocumentDate.TextSize = new Size(98, 13);
            // 
            // ItemForDocumentTime
            // 
            ItemForDocumentTime.Control = DocumentTimeTimeSpanEdit;
            ItemForDocumentTime.Location = new Point(0, 96);
            ItemForDocumentTime.Name = "ItemForDocumentTime";
            ItemForDocumentTime.Size = new Size(545, 24);
            ItemForDocumentTime.Text = "Sənəd Vaxtı";
            ItemForDocumentTime.TextSize = new Size(98, 13);
            // 
            // LCI_GvProductList
            // 
            LCI_GvProductList.Control = gC_InvoiceLine;
            LCI_GvProductList.Location = new Point(0, 120);
            LCI_GvProductList.Name = "LCI_GvProductList";
            LCI_GvProductList.Size = new Size(1109, 225);
            LCI_GvProductList.TextSize = new Size(0, 0);
            LCI_GvProductList.TextVisible = false;
            // 
            // ItemForDocumentNumber
            // 
            ItemForDocumentNumber.Control = btnEdit_DocNum;
            ItemForDocumentNumber.Location = new Point(0, 0);
            ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            ItemForDocumentNumber.Size = new Size(545, 24);
            ItemForDocumentNumber.Text = "Sənəd Nömrəsi";
            ItemForDocumentNumber.TextSize = new Size(98, 13);
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = btnEdit_CurrAccCode;
            ItemForCurrAccCode.Location = new Point(545, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(211, 24);
            ItemForCurrAccCode.Text = "Cari Hesab";
            ItemForCurrAccCode.TextSize = new Size(98, 13);
            // 
            // ItemForCustomsDocumentNumber
            // 
            ItemForCustomsDocumentNumber.Control = CustomsDocumentNumberTextEdit;
            ItemForCustomsDocumentNumber.Location = new Point(0, 48);
            ItemForCustomsDocumentNumber.Name = "ItemForCustomsDocumentNumber";
            ItemForCustomsDocumentNumber.Size = new Size(545, 24);
            ItemForCustomsDocumentNumber.Text = "Fərdi Sənəd Nömrəsi";
            ItemForCustomsDocumentNumber.TextSize = new Size(98, 13);
            // 
            // ItemForStoreCode
            // 
            ItemForStoreCode.Control = lUE_StoreCode;
            ItemForStoreCode.Location = new Point(545, 48);
            ItemForStoreCode.Name = "ItemForStoreCode";
            ItemForStoreCode.Size = new Size(564, 24);
            ItemForStoreCode.Text = "Mağaza";
            ItemForStoreCode.TextSize = new Size(98, 13);
            // 
            // ItemForWarehouseCode
            // 
            ItemForWarehouseCode.Control = lUE_WarehouseCode;
            ItemForWarehouseCode.Location = new Point(545, 72);
            ItemForWarehouseCode.Name = "ItemForWarehouseCode";
            ItemForWarehouseCode.Size = new Size(564, 24);
            ItemForWarehouseCode.Text = "Depodan";
            ItemForWarehouseCode.TextSize = new Size(98, 13);
            // 
            // ItemForDescription
            // 
            ItemForDescription.Control = memoEdit_Desc;
            ItemForDescription.Location = new Point(545, 96);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new Size(564, 24);
            ItemForDescription.Text = "Açıqlama";
            ItemForDescription.TextSize = new Size(98, 13);
            // 
            // lbl_Payment
            // 
            lbl_Payment.Control = lbl_InvoicePaidSum;
            lbl_Payment.Location = new Point(245, 345);
            lbl_Payment.MinSize = new Size(67, 17);
            lbl_Payment.Name = "lbl_Payment";
            lbl_Payment.Size = new Size(864, 24);
            lbl_Payment.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lbl_Payment.TextSize = new Size(0, 0);
            lbl_Payment.TextVisible = false;
            // 
            // ItemForToWarehouseCode
            // 
            ItemForToWarehouseCode.Control = lUE_ToWarehouseCode;
            ItemForToWarehouseCode.Location = new Point(545, 24);
            ItemForToWarehouseCode.Name = "ItemForToWarehouseCode";
            ItemForToWarehouseCode.Size = new Size(282, 24);
            ItemForToWarehouseCode.Text = "Depoya";
            ItemForToWarehouseCode.TextSize = new Size(98, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(123, 24);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(422, 24);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // lCI_printCount
            // 
            lCI_printCount.Control = txtEdit_PrintCount;
            lCI_printCount.Location = new Point(105, 345);
            lCI_printCount.MinSize = new Size(50, 18);
            lCI_printCount.Name = "lCI_printCount";
            lCI_printCount.Size = new Size(140, 24);
            lCI_printCount.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lCI_printCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            lCI_printCount.TextSize = new Size(70, 13);
            lCI_printCount.TextToControlDistance = 5;
            // 
            // lCI_IsSent
            // 
            lCI_IsSent.Control = checkEdit_IsSent;
            lCI_IsSent.Location = new Point(0, 345);
            lCI_IsSent.Name = "lCI_IsSent";
            lCI_IsSent.Size = new Size(95, 24);
            lCI_IsSent.TextSize = new Size(0, 0);
            lCI_IsSent.TextVisible = false;
            // 
            // splitterItem1
            // 
            splitterItem1.AllowHotTrack = true;
            splitterItem1.Location = new Point(95, 345);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new Size(10, 24);
            // 
            // LCI_CurrAccDesc
            // 
            LCI_CurrAccDesc.Control = lbl_CurrAccDesc;
            LCI_CurrAccDesc.Location = new Point(756, 0);
            LCI_CurrAccDesc.MinSize = new Size(67, 17);
            LCI_CurrAccDesc.Name = "LCI_CurrAccDesc";
            LCI_CurrAccDesc.Size = new Size(353, 24);
            LCI_CurrAccDesc.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            LCI_CurrAccDesc.Text = "CurrAccDesc";
            LCI_CurrAccDesc.TextSize = new Size(0, 0);
            LCI_CurrAccDesc.TextVisible = false;
            // 
            // LCI_SalesPersonDesc
            // 
            LCI_SalesPersonDesc.Control = LBL_SalesPersonDesc;
            LCI_SalesPersonDesc.Location = new Point(827, 24);
            LCI_SalesPersonDesc.MinSize = new Size(4, 17);
            LCI_SalesPersonDesc.Name = "LCI_SalesPersonDesc";
            LCI_SalesPersonDesc.Size = new Size(282, 24);
            LCI_SalesPersonDesc.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            LCI_SalesPersonDesc.TextSize = new Size(0, 0);
            LCI_SalesPersonDesc.TextVisible = false;
            // 
            // adorneruıManager1
            // 
            adorneruıManager1.Owner = this;
            // 
            // alertControl1
            // 
            alertControl1.AutoFormDelay = 3000;
            alertControl1.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Fast;
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("print", "image://svgimages/print/print.svg");
            svgImageCollection1.Add("report", "image://svgimages/business objects/bo_report.svg");
            svgImageCollection1.Add("setting", "image://svgimages/dashboards/scatterchartlabeloptions.svg");
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1129, 571);
            Controls.Add(dataLayoutControl1);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormInvoice";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "Faktura";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormInvoice_FormClosing;
            Load += FormInvoice_Load;
            Shown += FormInvoice_Shown;
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLinesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_PriceLoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_Price).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SalesPersonCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SerialNumberCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_IsSent.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_IsReturn.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentTimeTimeSpanEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomsDocumentNumberTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_Desc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_CurrAccCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lUE_StoreCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lUE_WarehouseCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lUE_ToWarehouseCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCBE_PrinterName).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioInstance).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioToken).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repo).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_PrintCount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_SalesPerson.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPerson).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsReturn).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_GvProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCustomsDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForStoreCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWarehouseCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)lbl_Payment).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForToWarehouseCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_printCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_IsSent).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_CurrAccDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPersonDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)adorneruıManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.BindingSource trInvoiceLinesBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource trInvoiceHeadersBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.CheckEdit checkEdit_IsReturn;
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
        private DevExpress.XtraLayout.LayoutControlItem LCI_GvProductList;
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
        private DevExpress.XtraLayout.LayoutControlItem LCI_CurrAccDesc;
        private DevExpress.Utils.VisualEffects.AdornerUIManager adorneruıManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colBenefit;
        private DevExpress.XtraBars.BarButtonItem bBI_reportPreviewAzn;
        private DevExpress.XtraBars.BarButtonItem bBI_CopyInvoice;
        private DevExpress.XtraBars.BarButtonItem bBI_Whatsapp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForToWarehouseCode;
        private DevExpress.XtraEditors.LookUpEdit lUE_ToWarehouseCode;
        private DevExpress.XtraEditors.LabelControl lbl_PrintCount;
        private DevExpress.XtraBars.BarButtonItem BBI_ModifyInvoice;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportPriceList;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem BBI_exportXLSX;
        private DevExpress.XtraBars.BarButtonItem BBI_ImportExcel;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit_TwilioInstance;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit_TwilioToken;
        private DevExpress.XtraEditors.CheckEdit checkEdit_IsSent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportPrintFast;
        private DevExpress.XtraBars.BarButtonItem BBI_PrintSettingSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repo;
        private DevExpress.XtraBars.BarEditItem BEI_PrinterName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoCBE_PrinterName;
        private DevExpress.XtraEditors.SimpleButton Btn_EditInvoice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtEdit_PrintCount;
        private DevExpress.XtraLayout.LayoutControlItem lCI_printCount;
        private DevExpress.XtraLayout.LayoutControlItem lCI_IsSent;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraBars.BarButtonItem btn_info;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem BBI_picture;
        private DevExpress.XtraBars.BarButtonItem BBI_Print;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.PopupMenu popupMenuPrinters;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarSubItem BSI_ReportProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraBars.BarButtonItem BBI_InvoiceExpenses;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_Payment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_Control;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCost;
        private DevExpress.XtraBars.BarCheckItem BCI_ShowPicture;
        private DevExpress.XtraBars.BarCheckItem BCI_ShowPrint;
        private DevExpress.XtraBars.BarCheckItem BCI_ShowCopy;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_SerialNumberCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumberCode;
        private DevExpress.XtraBars.BarSubItem BSI_ReportInvoice;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_SalesPerson;
        private DevExpress.XtraLayout.LayoutControlItem LCI_SalesPerson;
        private DevExpress.XtraEditors.LabelControl LBL_SalesPersonDesc;
        private DevExpress.XtraLayout.LayoutControlItem LCI_SalesPersonDesc;
    }
}