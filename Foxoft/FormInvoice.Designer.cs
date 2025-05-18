
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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
            lbl_InvoicePaidCashlessSum = new DevExpress.XtraEditors.LabelControl();
            lbl_InvoicePaidCashSum = new DevExpress.XtraEditors.LabelControl();
            lbl_InvoicePaidCashlessSumTxt = new DevExpress.XtraEditors.LabelControl();
            lbl_InvoicePaidCashSumTxt = new DevExpress.XtraEditors.LabelControl();
            lbl_InvoicePaidTotalSum = new DevExpress.XtraEditors.LabelControl();
            lbl_InstallmentTotalSum = new DevExpress.XtraEditors.LabelControl();
            lbl_InstallmentCommissionSum = new DevExpress.XtraEditors.LabelControl();
            lbl_InstallmentSum = new DevExpress.XtraEditors.LabelControl();
            lbl_InstallmentSumTxt = new DevExpress.XtraEditors.LabelControl();
            lbl_InstallmentCommissionSumTxt = new DevExpress.XtraEditors.LabelControl();
            LBL_SalesPersonDesc = new DevExpress.XtraEditors.LabelControl();
            lbl_CurrAccDesc = new DevExpress.XtraEditors.LabelControl();
            lbl_InstallmentTotalSumTxt = new DevExpress.XtraEditors.LabelControl();
            lbl_InvoicePaidTotalSumTxt = new DevExpress.XtraEditors.LabelControl();
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
            bBI_Save = new BarButtonItem();
            popupMenu1 = new PopupMenu(components);
            bBI_SaveAndNew = new BarButtonItem();
            bBI_SaveAndQuit = new BarButtonItem();
            bBI_Payment = new BarButtonItem();
            bBI_New = new BarButtonItem();
            bBI_reportPreview = new BarButtonItem();
            bBI_DeleteInvoice = new BarButtonItem();
            bBI_PaymentDelete = new BarButtonItem();
            bBI_CopyInvoice = new BarButtonItem();
            bBI_Whatsapp = new BarButtonItem();
            BBI_EditInvoice = new BarButtonItem();
            BBI_exportXLSX = new BarButtonItem();
            BBI_ImportExcel = new BarButtonItem();
            BBI_ReportPrintFast = new BarButtonItem();
            popupMenuPrinters = new PopupMenu(components);
            BBI_PrintSettingSave = new BarButtonItem();
            BEI_PrinterName = new BarEditItem();
            repoCBE_PrinterName = new RepositoryItemComboBox();
            barButtonItem3 = new BarButtonItem();
            btn_info = new BarButtonItem();
            BBI_picture = new BarButtonItem();
            barButtonItem2 = new BarButtonItem();
            BBI_InvoiceExpenses = new BarButtonItem();
            BCI_ShowPicture = new BarCheckItem();
            BCI_ShowPrint = new BarCheckItem();
            BCI_ShowCopy = new BarCheckItem();
            barButtonItem6 = new BarButtonItem();
            BSI_Reports = new BarSubItem();
            BBI_InstallmentDelete = new BarButtonItem();
            barButtonItem4 = new BarButtonItem();
            barButtonItem5 = new BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            Faktura = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RPG_Payment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RPG_Installment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RPG_Control = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            RibbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            repoTxtEdit_TwilioInstance = new RepositoryItemTextEdit();
            repoTxtEdit_TwilioToken = new RepositoryItemTextEdit();
            repo = new RepositoryItemCheckedComboBoxEdit();
            txtEdit_PrintCount = new DevExpress.XtraEditors.TextEdit();
            btnEdit_SalesPerson = new DevExpress.XtraEditors.ButtonEdit();
            gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            col_InvoiceLineId = new GridColumn();
            col_InvoiceHeaderId = new GridColumn();
            col_ProductCode = new GridColumn();
            repoBtnEdit_ProductCode = new RepositoryItemButtonEdit();
            colBalance = new GridColumn();
            colQty = new GridColumn();
            colQtyIn = new GridColumn();
            colQtyOut = new GridColumn();
            colPriceLoc = new GridColumn();
            repoCalcEdit_PriceLoc = new RepositoryItemCalcEdit();
            col_Price = new GridColumn();
            repoCalcEdit_Price = new RepositoryItemCalcEdit();
            colCurrencyCode = new GridColumn();
            repoLUE_CurrencyCode = new RepositoryItemLookUpEdit();
            colExchangeRate = new GridColumn();
            col_Amount = new GridColumn();
            col_PosDiscount = new GridColumn();
            col_NetAmount = new GridColumn();
            col_LineDesc = new GridColumn();
            col_SalesPersonCode = new GridColumn();
            repoBtnEdit_SalesPersonCode = new RepositoryItemButtonEdit();
            col_ProductDesc = new GridColumn();
            colAmountLoc = new GridColumn();
            colNetAmountLoc = new GridColumn();
            colBenefit = new GridColumn();
            colBarcode = new GridColumn();
            colCreatedDate = new GridColumn();
            colCreatedUserName = new GridColumn();
            colLastUpdatedDate = new GridColumn();
            colLastUpdatedUserName = new GridColumn();
            colProductCost = new GridColumn();
            colSerialNumberCode = new GridColumn();
            repoBtnEdit_SerialNumberCode = new RepositoryItemButtonEdit();
            colUnitOfMeasureId = new GridColumn();
            repoLUE_UnitOfMeasure = new RepositoryItemLookUpEdit();
            col_TotalBenefit = new GridColumn();
            colWorkerCode = new GridColumn();
            repoBtnEdit_WorkerCode = new RepositoryItemButtonEdit();
            repoBtnEdit_UnitOfMeasure = new RepositoryItemButtonEdit();
            LCI_SalesPerson = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_SalesPersonDesc = new DevExpress.XtraLayout.LayoutControlItem();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            LCG_Invoice = new DevExpress.XtraLayout.LayoutControlGroup();
            LCI_GvProductList = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            LCG_InfoInstallment = new DevExpress.XtraLayout.LayoutControlGroup();
            LCI_InstallmentSum = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InstallmentCommissionSum = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InstallmentTotalSum = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InstallmentCommissionSumTxt = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InstallmentSumTxt = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InstallmentTotalSumTxt = new DevExpress.XtraLayout.LayoutControlItem();
            LCG_InfoPayment = new DevExpress.XtraLayout.LayoutControlGroup();
            LCI_InvoicePaidSum = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InvoicePaidCashSum = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InvoicePaidSumTxt = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InvoicePaidCashlessSumTxt = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InvoicePaidCashSumTxt = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_InvoicePaidCashlessSum = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_CurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForStoreCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCustomsDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForToWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForWarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsReturn = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_printCount = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_IsSent = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            adorneruıManager1 = new DevExpress.Utils.VisualEffects.AdornerUIManager(components);
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLinesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuPrinters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCBE_PrinterName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioInstance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioToken).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_PrintCount.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_SalesPerson.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_PriceLoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_Price).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SalesPersonCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SerialNumberCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_UnitOfMeasure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_WorkerCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_UnitOfMeasure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPerson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPersonDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCG_Invoice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_GvProductList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCG_InfoInstallment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentCommissionSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentTotalSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentCommissionSumTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentSumTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentTotalSumTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCG_InfoPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidSumTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashlessSumTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashSumTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashlessSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_CurrAccDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForStoreCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCustomsDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForToWarehouseCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWarehouseCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsReturn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_printCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_IsSent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)adorneruıManager1).BeginInit();
            SuspendLayout();
            // 
            // trInvoiceLinesBindingSource
            // 
            trInvoiceLinesBindingSource.DataSource = typeof(TrInvoiceLine);
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidCashlessSum);
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidCashSum);
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidCashlessSumTxt);
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidCashSumTxt);
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidTotalSum);
            dataLayoutControl1.Controls.Add(lbl_InstallmentTotalSum);
            dataLayoutControl1.Controls.Add(lbl_InstallmentCommissionSum);
            dataLayoutControl1.Controls.Add(lbl_InstallmentSum);
            dataLayoutControl1.Controls.Add(lbl_InstallmentSumTxt);
            dataLayoutControl1.Controls.Add(lbl_InstallmentCommissionSumTxt);
            dataLayoutControl1.Controls.Add(LBL_SalesPersonDesc);
            dataLayoutControl1.Controls.Add(lbl_CurrAccDesc);
            dataLayoutControl1.Controls.Add(lbl_InstallmentTotalSumTxt);
            dataLayoutControl1.Controls.Add(lbl_InvoicePaidTotalSumTxt);
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
            dataLayoutControl1.Controls.Add(gC_InvoiceLine);
            dataLayoutControl1.DataSource = trInvoiceHeadersBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCI_SalesPerson, LCI_SalesPersonDesc });
            dataLayoutControl1.Location = new Point(0, 158);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(670, 403, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(1146, 446);
            dataLayoutControl1.TabIndex = 4;
            dataLayoutControl1.Text = "dataLayoutControl1";
            dataLayoutControl1.Changed += dataLayoutControl1_Changed;
            // 
            // lbl_InvoicePaidCashlessSum
            // 
            lbl_InvoicePaidCashlessSum.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InvoicePaidCashlessSum.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashlessSum.Location = new Point(1017, 386);
            lbl_InvoicePaidCashlessSum.Margin = new Padding(3, 2, 3, 2);
            lbl_InvoicePaidCashlessSum.Name = "lbl_InvoicePaidCashlessSum";
            lbl_InvoicePaidCashlessSum.Size = new Size(52, 16);
            lbl_InvoicePaidCashlessSum.StyleController = dataLayoutControl1;
            lbl_InvoicePaidCashlessSum.TabIndex = 1;
            lbl_InvoicePaidCashlessSum.Text = "0.00 AZN";
            // 
            // lbl_InvoicePaidCashSum
            // 
            lbl_InvoicePaidCashSum.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InvoicePaidCashSum.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashSum.Location = new Point(1017, 366);
            lbl_InvoicePaidCashSum.Margin = new Padding(3, 2, 3, 2);
            lbl_InvoicePaidCashSum.Name = "lbl_InvoicePaidCashSum";
            lbl_InvoicePaidCashSum.Size = new Size(52, 16);
            lbl_InvoicePaidCashSum.StyleController = dataLayoutControl1;
            lbl_InvoicePaidCashSum.TabIndex = 1;
            lbl_InvoicePaidCashSum.Text = "0.00 AZN";
            // 
            // lbl_InvoicePaidCashlessSumTxt
            // 
            lbl_InvoicePaidCashlessSumTxt.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InvoicePaidCashlessSumTxt.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashlessSumTxt.Location = new Point(960, 386);
            lbl_InvoicePaidCashlessSumTxt.Margin = new Padding(3, 2, 3, 2);
            lbl_InvoicePaidCashlessSumTxt.Name = "lbl_InvoicePaidCashlessSumTxt";
            lbl_InvoicePaidCashlessSumTxt.Size = new Size(53, 16);
            lbl_InvoicePaidCashlessSumTxt.StyleController = dataLayoutControl1;
            lbl_InvoicePaidCashlessSumTxt.TabIndex = 1;
            lbl_InvoicePaidCashlessSumTxt.Text = "Nağdsız: ";
            // 
            // lbl_InvoicePaidCashSumTxt
            // 
            lbl_InvoicePaidCashSumTxt.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InvoicePaidCashSumTxt.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashSumTxt.Location = new Point(975, 366);
            lbl_InvoicePaidCashSumTxt.Margin = new Padding(3, 2, 3, 2);
            lbl_InvoicePaidCashSumTxt.Name = "lbl_InvoicePaidCashSumTxt";
            lbl_InvoicePaidCashSumTxt.Size = new Size(38, 16);
            lbl_InvoicePaidCashSumTxt.StyleController = dataLayoutControl1;
            lbl_InvoicePaidCashSumTxt.TabIndex = 1;
            lbl_InvoicePaidCashSumTxt.Text = "Nağd: ";
            // 
            // lbl_InvoicePaidTotalSum
            // 
            lbl_InvoicePaidTotalSum.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InvoicePaidTotalSum.Appearance.Options.UseFont = true;
            lbl_InvoicePaidTotalSum.Location = new Point(1017, 406);
            lbl_InvoicePaidTotalSum.Name = "lbl_InvoicePaidTotalSum";
            lbl_InvoicePaidTotalSum.Size = new Size(52, 16);
            lbl_InvoicePaidTotalSum.StyleController = dataLayoutControl1;
            lbl_InvoicePaidTotalSum.TabIndex = 1;
            lbl_InvoicePaidTotalSum.Text = "0.00 AZN";
            // 
            // lbl_InstallmentTotalSum
            // 
            lbl_InstallmentTotalSum.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InstallmentTotalSum.Appearance.Options.UseFont = true;
            lbl_InstallmentTotalSum.Location = new Point(822, 406);
            lbl_InstallmentTotalSum.Name = "lbl_InstallmentTotalSum";
            lbl_InstallmentTotalSum.Size = new Size(52, 16);
            lbl_InstallmentTotalSum.StyleController = dataLayoutControl1;
            lbl_InstallmentTotalSum.TabIndex = 1;
            lbl_InstallmentTotalSum.Text = "0.00 AZN";
            // 
            // lbl_InstallmentCommissionSum
            // 
            lbl_InstallmentCommissionSum.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InstallmentCommissionSum.Appearance.Options.UseFont = true;
            lbl_InstallmentCommissionSum.Location = new Point(822, 386);
            lbl_InstallmentCommissionSum.Name = "lbl_InstallmentCommissionSum";
            lbl_InstallmentCommissionSum.Size = new Size(52, 16);
            lbl_InstallmentCommissionSum.StyleController = dataLayoutControl1;
            lbl_InstallmentCommissionSum.TabIndex = 1;
            lbl_InstallmentCommissionSum.Text = "0.00 AZN";
            // 
            // lbl_InstallmentSum
            // 
            lbl_InstallmentSum.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InstallmentSum.Appearance.Options.UseFont = true;
            lbl_InstallmentSum.Location = new Point(822, 366);
            lbl_InstallmentSum.Name = "lbl_InstallmentSum";
            lbl_InstallmentSum.Size = new Size(52, 16);
            lbl_InstallmentSum.StyleController = dataLayoutControl1;
            lbl_InstallmentSum.TabIndex = 1;
            lbl_InstallmentSum.Text = "0.00 AZN";
            // 
            // lbl_InstallmentSumTxt
            // 
            lbl_InstallmentSumTxt.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InstallmentSumTxt.Appearance.Options.UseFont = true;
            lbl_InstallmentSumTxt.Location = new Point(776, 366);
            lbl_InstallmentSumTxt.Name = "lbl_InstallmentSumTxt";
            lbl_InstallmentSumTxt.Size = new Size(42, 16);
            lbl_InstallmentSumTxt.StyleController = dataLayoutControl1;
            lbl_InstallmentSumTxt.TabIndex = 1;
            lbl_InstallmentSumTxt.Text = "Kredit: ";
            // 
            // lbl_InstallmentCommissionSumTxt
            // 
            lbl_InstallmentCommissionSumTxt.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InstallmentCommissionSumTxt.Appearance.Options.UseFont = true;
            lbl_InstallmentCommissionSumTxt.Location = new Point(753, 386);
            lbl_InstallmentCommissionSumTxt.Name = "lbl_InstallmentCommissionSumTxt";
            lbl_InstallmentCommissionSumTxt.Size = new Size(65, 16);
            lbl_InstallmentCommissionSumTxt.StyleController = dataLayoutControl1;
            lbl_InstallmentCommissionSumTxt.TabIndex = 1;
            lbl_InstallmentCommissionSumTxt.Text = "Komissiya: ";
            // 
            // LBL_SalesPersonDesc
            // 
            LBL_SalesPersonDesc.Location = new Point(1014, 36);
            LBL_SalesPersonDesc.Name = "LBL_SalesPersonDesc";
            LBL_SalesPersonDesc.Size = new Size(120, 20);
            LBL_SalesPersonDesc.StyleController = dataLayoutControl1;
            LBL_SalesPersonDesc.TabIndex = 1;
            // 
            // lbl_CurrAccDesc
            // 
            lbl_CurrAccDesc.Location = new Point(806, 12);
            lbl_CurrAccDesc.Name = "lbl_CurrAccDesc";
            lbl_CurrAccDesc.Size = new Size(328, 20);
            lbl_CurrAccDesc.StyleController = dataLayoutControl1;
            lbl_CurrAccDesc.TabIndex = 1;
            // 
            // lbl_InstallmentTotalSumTxt
            // 
            lbl_InstallmentTotalSumTxt.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InstallmentTotalSumTxt.Appearance.Options.UseFont = true;
            lbl_InstallmentTotalSumTxt.Location = new Point(729, 406);
            lbl_InstallmentTotalSumTxt.Name = "lbl_InstallmentTotalSumTxt";
            lbl_InstallmentTotalSumTxt.Size = new Size(89, 16);
            lbl_InstallmentTotalSumTxt.StyleController = dataLayoutControl1;
            lbl_InstallmentTotalSumTxt.TabIndex = 1;
            lbl_InstallmentTotalSumTxt.Text = "Toplam Kredit: ";
            // 
            // lbl_InvoicePaidTotalSumTxt
            // 
            lbl_InvoicePaidTotalSumTxt.Appearance.Font = new Font("Tahoma", 10F);
            lbl_InvoicePaidTotalSumTxt.Appearance.Options.UseFont = true;
            lbl_InvoicePaidTotalSumTxt.Appearance.Options.UseTextOptions = true;
            lbl_InvoicePaidTotalSumTxt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lbl_InvoicePaidTotalSumTxt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            lbl_InvoicePaidTotalSumTxt.Location = new Point(958, 406);
            lbl_InvoicePaidTotalSumTxt.Name = "lbl_InvoicePaidTotalSumTxt";
            lbl_InvoicePaidTotalSumTxt.Size = new Size(55, 16);
            lbl_InvoicePaidTotalSumTxt.StyleController = dataLayoutControl1;
            lbl_InvoicePaidTotalSumTxt.TabIndex = 1;
            lbl_InvoicePaidTotalSumTxt.Text = "Ödənilib: ";
            // 
            // checkEdit_IsSent
            // 
            checkEdit_IsSent.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "IsSent", true));
            checkEdit_IsSent.Enabled = false;
            checkEdit_IsSent.Location = new Point(116, 354);
            checkEdit_IsSent.Name = "checkEdit_IsSent";
            checkEdit_IsSent.Properties.Caption = "Göndərilib";
            checkEdit_IsSent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            checkEdit_IsSent.Size = new Size(70, 20);
            checkEdit_IsSent.StyleController = dataLayoutControl1;
            checkEdit_IsSent.TabIndex = 11;
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
            checkEdit_IsReturn.Location = new Point(12, 354);
            checkEdit_IsReturn.Name = "checkEdit_IsReturn";
            checkEdit_IsReturn.Properties.Appearance.Options.UseForeColor = true;
            checkEdit_IsReturn.Properties.Caption = "Geri Qaytarma";
            checkEdit_IsReturn.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            checkEdit_IsReturn.Size = new Size(100, 20);
            checkEdit_IsReturn.StyleController = dataLayoutControl1;
            checkEdit_IsReturn.TabIndex = 1;
            // 
            // DocumentDateDateEdit
            // 
            DocumentDateDateEdit.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentDate", true));
            DocumentDateDateEdit.EditValue = null;
            DocumentDateDateEdit.Location = new Point(122, 60);
            DocumentDateDateEdit.Name = "DocumentDateDateEdit";
            DocumentDateDateEdit.Properties.AllowMouseWheel = false;
            DocumentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentDateDateEdit.Size = new Size(318, 20);
            DocumentDateDateEdit.StyleController = dataLayoutControl1;
            DocumentDateDateEdit.TabIndex = 7;
            DocumentDateDateEdit.KeyDown += dataLayoutControls_KeyDown;
            // 
            // DocumentTimeTimeSpanEdit
            // 
            DocumentTimeTimeSpanEdit.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentTime", true));
            DocumentTimeTimeSpanEdit.EditValue = TimeSpan.Parse("00:00:00");
            DocumentTimeTimeSpanEdit.Location = new Point(444, 60);
            DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
            DocumentTimeTimeSpanEdit.Properties.AllowMouseWheel = false;
            DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentTimeTimeSpanEdit.Size = new Size(137, 20);
            DocumentTimeTimeSpanEdit.StyleController = dataLayoutControl1;
            DocumentTimeTimeSpanEdit.TabIndex = 8;
            DocumentTimeTimeSpanEdit.KeyDown += dataLayoutControls_KeyDown;
            // 
            // CustomsDocumentNumberTextEdit
            // 
            CustomsDocumentNumberTextEdit.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "CustomsDocumentNumber", true));
            CustomsDocumentNumberTextEdit.Location = new Point(122, 36);
            CustomsDocumentNumberTextEdit.Name = "CustomsDocumentNumberTextEdit";
            CustomsDocumentNumberTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            CustomsDocumentNumberTextEdit.Size = new Size(459, 20);
            CustomsDocumentNumberTextEdit.StyleController = dataLayoutControl1;
            CustomsDocumentNumberTextEdit.TabIndex = 4;
            CustomsDocumentNumberTextEdit.KeyDown += dataLayoutControls_KeyDown;
            // 
            // btnEdit_DocNum
            // 
            btnEdit_DocNum.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentNumber", true));
            btnEdit_DocNum.Location = new Point(122, 12);
            btnEdit_DocNum.Name = "btnEdit_DocNum";
            btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_DocNum.Size = new Size(459, 20);
            btnEdit_DocNum.StyleController = dataLayoutControl1;
            btnEdit_DocNum.TabIndex = 0;
            btnEdit_DocNum.ButtonPressed += btnEdit_DocNum_ButtonPressed;
            btnEdit_DocNum.DoubleClick += btnEdit_DocNum_DoubleClick;
            btnEdit_DocNum.KeyDown += dataLayoutControls_KeyDown;
            // 
            // memoEdit_Desc
            // 
            memoEdit_Desc.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "Description", true));
            memoEdit_Desc.Location = new Point(122, 84);
            memoEdit_Desc.Name = "memoEdit_Desc";
            memoEdit_Desc.Properties.AllowMouseWheel = false;
            memoEdit_Desc.Size = new Size(459, 20);
            memoEdit_Desc.StyleController = dataLayoutControl1;
            memoEdit_Desc.TabIndex = 9;
            memoEdit_Desc.KeyDown += dataLayoutControls_KeyDown;
            // 
            // btnEdit_CurrAccCode
            // 
            btnEdit_CurrAccCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "CurrAccCode", true));
            btnEdit_CurrAccCode.Location = new Point(695, 12);
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_CurrAccCode.Size = new Size(107, 20);
            btnEdit_CurrAccCode.StyleController = dataLayoutControl1;
            btnEdit_CurrAccCode.TabIndex = 2;
            btnEdit_CurrAccCode.ButtonClick += btnEdit_CurrAccCode_ButtonClick;
            btnEdit_CurrAccCode.InvalidValue += btnEdit_CurrAccCode_InvalidValue;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;
            btnEdit_CurrAccCode.EditValueChanging += btnEdit_CurrAccCode_EditValueChanging;
            btnEdit_CurrAccCode.DoubleClick += btnEdit_CurrAccCode_DoubleClick;
            btnEdit_CurrAccCode.KeyDown += dataLayoutControls_KeyDown;
            btnEdit_CurrAccCode.Validating += btnEdit_CurrAccCode_Validating;
            // 
            // lUE_StoreCode
            // 
            lUE_StoreCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "StoreCode", true));
            lUE_StoreCode.Location = new Point(695, 60);
            lUE_StoreCode.Name = "lUE_StoreCode";
            lUE_StoreCode.Properties.AllowMouseWheel = false;
            lUE_StoreCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            lUE_StoreCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lUE_StoreCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "Mağaza Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "Mağaza Adı") });
            lUE_StoreCode.Properties.DisplayMember = "CurrAccDesc";
            lUE_StoreCode.Properties.NullText = "";
            lUE_StoreCode.Properties.ShowHeader = false;
            lUE_StoreCode.Properties.ValueMember = "CurrAccCode";
            lUE_StoreCode.Size = new Size(439, 20);
            lUE_StoreCode.StyleController = dataLayoutControl1;
            lUE_StoreCode.TabIndex = 5;
            lUE_StoreCode.PopupFilter += lUE_StoreCode_PopupFilter;
            lUE_StoreCode.EditValueChanged += lUE_StoreCode_EditValueChanged;
            lUE_StoreCode.KeyDown += dataLayoutControls_KeyDown;
            // 
            // lUE_WarehouseCode
            // 
            lUE_WarehouseCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "WarehouseCode", true));
            lUE_WarehouseCode.Location = new Point(695, 84);
            lUE_WarehouseCode.Name = "lUE_WarehouseCode";
            lUE_WarehouseCode.Properties.AllowMouseWheel = false;
            lUE_WarehouseCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            lUE_WarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lUE_WarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı") });
            lUE_WarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            lUE_WarehouseCode.Properties.NullText = "";
            lUE_WarehouseCode.Properties.ShowHeader = false;
            lUE_WarehouseCode.Properties.ValueMember = "WarehouseCode";
            lUE_WarehouseCode.Size = new Size(439, 20);
            lUE_WarehouseCode.StyleController = dataLayoutControl1;
            lUE_WarehouseCode.TabIndex = 6;
            lUE_WarehouseCode.PopupFilter += lUE_WarehouseCode_PopupFilter;
            lUE_WarehouseCode.InvalidValue += lUE_WarehouseCode_InvalidValue;
            lUE_WarehouseCode.KeyDown += dataLayoutControls_KeyDown;
            lUE_WarehouseCode.Validating += lUE_WarehouseCode_Validating;
            // 
            // lUE_ToWarehouseCode
            // 
            lUE_ToWarehouseCode.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "ToWarehouseCode", true));
            lUE_ToWarehouseCode.Location = new Point(695, 36);
            lUE_ToWarehouseCode.MenuManager = ribbonControl1;
            lUE_ToWarehouseCode.Name = "lUE_ToWarehouseCode";
            lUE_ToWarehouseCode.Properties.AllowMouseWheel = false;
            lUE_ToWarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lUE_ToWarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı") });
            lUE_ToWarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            lUE_ToWarehouseCode.Properties.NullText = "";
            lUE_ToWarehouseCode.Properties.ValueMember = "WarehouseCode";
            lUE_ToWarehouseCode.Size = new Size(439, 20);
            lUE_ToWarehouseCode.StyleController = dataLayoutControl1;
            lUE_ToWarehouseCode.TabIndex = 3;
            lUE_ToWarehouseCode.PopupFilter += lUE_ToWarehouseCode_PopupFilter;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_Save, bBI_SaveAndNew, bBI_Payment, bBI_New, bBI_reportPreview, bBI_DeleteInvoice, bBI_PaymentDelete, bBI_SaveAndQuit, bBI_CopyInvoice, bBI_Whatsapp, BBI_EditInvoice, BBI_exportXLSX, BBI_ImportExcel, BBI_ReportPrintFast, BBI_PrintSettingSave, BEI_PrinterName, barButtonItem3, btn_info, BBI_picture, barButtonItem2, BBI_InvoiceExpenses, BCI_ShowPicture, BCI_ShowPrint, BCI_ShowCopy, barButtonItem6, BSI_Reports, BBI_InstallmentDelete, barButtonItem4, barButtonItem5 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 62;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsTouch.ShowTouchUISelectorInQAT = true;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbonControl1.RepositoryItems.AddRange(new RepositoryItem[] { repoTxtEdit_TwilioInstance, repoTxtEdit_TwilioToken, repo, repoCBE_PrinterName });
            ribbonControl1.Size = new Size(1146, 158);
            // 
            // bBI_Save
            // 
            bBI_Save.ButtonStyle = BarButtonStyle.DropDown;
            bBI_Save.Caption = "Yadda Saxla";
            bBI_Save.DropDownControl = popupMenu1;
            bBI_Save.Id = 1;
            bBI_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Save.ImageOptions.SvgImage");
            bBI_Save.Name = "bBI_Save";
            bBI_Save.ItemClick += bBI_Save_ItemClick;
            // 
            // popupMenu1
            // 
            popupMenu1.ItemLinks.Add(bBI_SaveAndNew);
            popupMenu1.ItemLinks.Add(bBI_SaveAndQuit);
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = ribbonControl1;
            // 
            // bBI_SaveAndNew
            // 
            bBI_SaveAndNew.Caption = "Yadda Saxla Yeni";
            bBI_SaveAndNew.Id = 2;
            bBI_SaveAndNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndNew.ImageOptions.SvgImage");
            bBI_SaveAndNew.Name = "bBI_SaveAndNew";
            bBI_SaveAndNew.ItemClick += bBI_SaveAndNew_ItemClick;
            // 
            // bBI_SaveAndQuit
            // 
            bBI_SaveAndQuit.Caption = "Yadda Saxla Bağla";
            bBI_SaveAndQuit.Id = 13;
            bBI_SaveAndQuit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndQuit.ImageOptions.SvgImage");
            bBI_SaveAndQuit.ItemShortcut = new BarShortcut(Keys.F12);
            bBI_SaveAndQuit.Name = "bBI_SaveAndQuit";
            bBI_SaveAndQuit.ItemClick += bBI_SaveAndQuit_ItemClick;
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
            bBI_New.ItemShortcut = new BarShortcut(Keys.Control | Keys.N);
            bBI_New.Name = "bBI_New";
            bBI_New.ItemClick += bBI_New_ItemClick;
            // 
            // bBI_reportPreview
            // 
            bBI_reportPreview.Caption = "Faktura Görünüş";
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
            // bBI_PaymentDelete
            // 
            bBI_PaymentDelete.Caption = "Ödəməni Sil";
            bBI_PaymentDelete.Id = 12;
            bBI_PaymentDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_PaymentDelete.ImageOptions.SvgImage");
            bBI_PaymentDelete.Name = "bBI_PaymentDelete";
            bBI_PaymentDelete.ItemClick += bBI_PaymentDelete_ItemClick;
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
            // BBI_EditInvoice
            // 
            BBI_EditInvoice.Caption = "Dəyiş";
            BBI_EditInvoice.Id = 19;
            BBI_EditInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_EditInvoice.ImageOptions.SvgImage");
            BBI_EditInvoice.Name = "BBI_EditInvoice";
            BBI_EditInvoice.ItemClick += BBI_ModifyInvoice_ItemClick;
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
            BBI_ReportPrintFast.ButtonStyle = BarButtonStyle.DropDown;
            BBI_ReportPrintFast.Caption = "Sürətli Çap Et";
            BBI_ReportPrintFast.DropDownControl = popupMenuPrinters;
            BBI_ReportPrintFast.Id = 30;
            BBI_ReportPrintFast.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportPrintFast.ImageOptions.SvgImage");
            BBI_ReportPrintFast.Name = "BBI_ReportPrintFast";
            BBI_ReportPrintFast.ItemClick += BBI_ReportPrintFast_ItemClick;
            // 
            // popupMenuPrinters
            // 
            popupMenuPrinters.Name = "popupMenuPrinters";
            popupMenuPrinters.Ribbon = ribbonControl1;
            popupMenuPrinters.BeforePopup += popupMenuPrinters_BeforePopup;
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
            btn_info.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_info.ImageOptions.SvgImage");
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
            // barButtonItem2
            // 
            barButtonItem2.Caption = "test";
            barButtonItem2.Id = 42;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick_1;
            // 
            // BBI_InvoiceExpenses
            // 
            BBI_InvoiceExpenses.Caption = "Xərclər";
            BBI_InvoiceExpenses.Id = 45;
            BBI_InvoiceExpenses.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_InvoiceExpenses.ImageOptions.SvgImage");
            BBI_InvoiceExpenses.Name = "BBI_InvoiceExpenses";
            BBI_InvoiceExpenses.Visibility = BarItemVisibility.Never;
            BBI_InvoiceExpenses.ItemClick += BBI_InvoiceExpenses_ItemClick;
            // 
            // BCI_ShowPicture
            // 
            BCI_ShowPicture.Caption = "Rəsim Göstər";
            BCI_ShowPicture.CheckBoxVisibility = CheckBoxVisibility.BeforeText;
            BCI_ShowPicture.Id = 46;
            BCI_ShowPicture.Name = "BCI_ShowPicture";
            BCI_ShowPicture.CheckedChanged += BCI_CheckedChanged;
            // 
            // BCI_ShowPrint
            // 
            BCI_ShowPrint.Caption = "Printer Göstər";
            BCI_ShowPrint.CheckBoxVisibility = CheckBoxVisibility.BeforeText;
            BCI_ShowPrint.Id = 47;
            BCI_ShowPrint.Name = "BCI_ShowPrint";
            BCI_ShowPrint.CheckedChanged += BCI_CheckedChanged;
            // 
            // BCI_ShowCopy
            // 
            BCI_ShowCopy.Caption = "Kopya Göstər";
            BCI_ShowCopy.CheckBoxVisibility = CheckBoxVisibility.BeforeText;
            BCI_ShowCopy.Id = 49;
            BCI_ShowCopy.Name = "BCI_ShowCopy";
            BCI_ShowCopy.CheckedChanged += BCI_CheckedChanged;
            // 
            // barButtonItem6
            // 
            barButtonItem6.Caption = "barButtonItem6";
            barButtonItem6.Id = 55;
            barButtonItem6.Name = "barButtonItem6";
            // 
            // BSI_Reports
            // 
            BSI_Reports.Caption = "Hesabat";
            BSI_Reports.Id = 58;
            BSI_Reports.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Reports.ImageOptions.SvgImage");
            BSI_Reports.Name = "BSI_Reports";
            // 
            // BBI_InstallmentDelete
            // 
            BBI_InstallmentDelete.Caption = "Krediti Sil";
            BBI_InstallmentDelete.Id = 59;
            BBI_InstallmentDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_InstallmentDelete.ImageOptions.SvgImage");
            BBI_InstallmentDelete.Name = "BBI_InstallmentDelete";
            BBI_InstallmentDelete.ItemClick += BBI_InstallmentDelete_ItemClick;
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "barButtonItem4";
            barButtonItem4.Id = 60;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "barButtonItem5";
            barButtonItem5.Id = 61;
            barButtonItem5.Name = "barButtonItem5";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { Faktura, RPG_Payment, RPG_Installment, ribbonPageGroup2, RPG_Control, ribbonPageGroup8 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Faktura";
            // 
            // Faktura
            // 
            Faktura.ItemLinks.Add(bBI_Save);
            Faktura.ItemLinks.Add(bBI_New);
            Faktura.ItemLinks.Add(bBI_DeleteInvoice);
            Faktura.Name = "Faktura";
            Faktura.Text = "Əməliyat";
            // 
            // RPG_Payment
            // 
            RPG_Payment.ItemLinks.Add(bBI_Payment);
            RPG_Payment.ItemLinks.Add(bBI_PaymentDelete);
            RPG_Payment.Name = "RPG_Payment";
            RPG_Payment.Text = "Ödəmə";
            RPG_Payment.Visible = false;
            // 
            // RPG_Installment
            // 
            RPG_Installment.ItemLinks.Add(BBI_InstallmentDelete);
            RPG_Installment.Name = "RPG_Installment";
            RPG_Installment.Text = "Kredit";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_reportPreview);
            ribbonPageGroup2.ItemLinks.Add(BBI_ReportPrintFast);
            ribbonPageGroup2.ItemLinks.Add(bBI_CopyInvoice);
            ribbonPageGroup2.ItemLinks.Add(bBI_Whatsapp);
            ribbonPageGroup2.ItemLinks.Add(BSI_Reports, true);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Print";
            // 
            // RPG_Control
            // 
            RPG_Control.ItemLinks.Add(BBI_picture);
            RPG_Control.ItemLinks.Add(BBI_EditInvoice, true);
            RPG_Control.ItemLinks.Add(BBI_InvoiceExpenses);
            RPG_Control.Name = "RPG_Control";
            RPG_Control.Text = "Nəzarət";
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
            RibbonPageGroup5.ItemLinks.Add(BBI_ImportExcel);
            RibbonPageGroup5.ItemLinks.Add(BBI_exportXLSX);
            RibbonPageGroup5.Name = "RibbonPageGroup5";
            RibbonPageGroup5.Text = "Hesabat";
            // 
            // ribbonPageGroup6
            // 
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
            // repo
            // 
            repo.AutoHeight = false;
            repo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repo.Name = "repo";
            // 
            // txtEdit_PrintCount
            // 
            txtEdit_PrintCount.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "PrintCount", true));
            txtEdit_PrintCount.Enabled = false;
            txtEdit_PrintCount.Location = new Point(240, 354);
            txtEdit_PrintCount.MenuManager = ribbonControl1;
            txtEdit_PrintCount.Name = "txtEdit_PrintCount";
            txtEdit_PrintCount.Properties.Appearance.Options.UseFont = true;
            txtEdit_PrintCount.Properties.Appearance.Options.UseTextOptions = true;
            txtEdit_PrintCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            txtEdit_PrintCount.Size = new Size(50, 20);
            txtEdit_PrintCount.StyleController = dataLayoutControl1;
            txtEdit_PrintCount.TabIndex = 12;
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
            // gC_InvoiceLine
            // 
            gC_InvoiceLine.DataSource = trInvoiceLinesBindingSource;
            gC_InvoiceLine.Location = new Point(12, 108);
            gC_InvoiceLine.MainView = gV_InvoiceLine;
            gC_InvoiceLine.Name = "gC_InvoiceLine";
            gC_InvoiceLine.RepositoryItems.AddRange(new RepositoryItem[] { repoBtnEdit_ProductCode, repoBtnEdit_SalesPersonCode, repoCalcEdit_Price, repoLUE_CurrencyCode, repoCalcEdit_PriceLoc, repoBtnEdit_SerialNumberCode, repoBtnEdit_UnitOfMeasure, repoLUE_UnitOfMeasure, repoBtnEdit_WorkerCode });
            gC_InvoiceLine.Size = new Size(1122, 242);
            gC_InvoiceLine.TabIndex = 10;
            gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceLine });
            gC_InvoiceLine.EditorKeyDown += gC_InvoiceLine_KeyDown;
            gC_InvoiceLine.EditorKeyUp += gC_InvoiceLine_EditorKeyUp;
            gC_InvoiceLine.EditorKeyPress += gC_InvoiceLine_EditorKeyPress;
            gC_InvoiceLine.KeyDown += gC_InvoiceLine_KeyDown;
            // 
            // gV_InvoiceLine
            // 
            gV_InvoiceLine.Columns.AddRange(new GridColumn[] { col_InvoiceLineId, col_InvoiceHeaderId, col_ProductCode, colBalance, colQty, colQtyIn, colQtyOut, colPriceLoc, col_Price, colCurrencyCode, colExchangeRate, col_Amount, col_PosDiscount, col_NetAmount, col_LineDesc, col_SalesPersonCode, col_ProductDesc, colAmountLoc, colNetAmountLoc, colBenefit, colBarcode, colCreatedDate, colCreatedUserName, colLastUpdatedDate, colLastUpdatedUserName, colProductCost, colSerialNumberCode, colUnitOfMeasureId, col_TotalBenefit, colWorkerCode });
            gV_InvoiceLine.CustomizationFormBounds = new Rectangle(760, 184, 264, 272);
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
            gV_InvoiceLine.CustomRowCellEdit += gV_InvoiceLine_CustomRowCellEdit;
            gV_InvoiceLine.PopupMenuShowing += gV_InvoiceLine_PopupMenuShowing;
            gV_InvoiceLine.ShowingEditor += gV_InvoiceLine_ShowingEditor;
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
            gV_InvoiceLine.CustomColumnDisplayText += gV_InvoiceLine_CustomColumnDisplayText;
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
            col_ProductCode.VisibleIndex = 0;
            col_ProductCode.Width = 83;
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
            colBalance.UnboundDataType = typeof(decimal);
            colBalance.Width = 116;
            // 
            // colQty
            // 
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n2}") });
            colQty.Visible = true;
            colQty.VisibleIndex = 2;
            colQty.Width = 41;
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
            col_Price.VisibleIndex = 3;
            col_Price.Width = 57;
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
            colCurrencyCode.VisibleIndex = 4;
            colCurrencyCode.Width = 59;
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
            col_PosDiscount.VisibleIndex = 5;
            col_PosDiscount.Width = 89;
            // 
            // col_NetAmount
            // 
            col_NetAmount.DisplayFormat.FormatString = "{0:n2}";
            col_NetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_NetAmount.FieldName = "NetAmount";
            col_NetAmount.Name = "col_NetAmount";
            col_NetAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmount", "{0:n2}") });
            col_NetAmount.Visible = true;
            col_NetAmount.VisibleIndex = 6;
            col_NetAmount.Width = 69;
            // 
            // col_LineDesc
            // 
            col_LineDesc.FieldName = "LineDescription";
            col_LineDesc.Name = "col_LineDesc";
            col_LineDesc.Visible = true;
            col_LineDesc.VisibleIndex = 7;
            col_LineDesc.Width = 97;
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
            col_ProductDesc.VisibleIndex = 1;
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
            colBenefit.Width = 71;
            // 
            // colBarcode
            // 
            colBarcode.FieldName = "Barcode";
            colBarcode.Name = "colBarcode";
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
            // 
            // colSerialNumberCode
            // 
            colSerialNumberCode.ColumnEdit = repoBtnEdit_SerialNumberCode;
            colSerialNumberCode.FieldName = "SerialNumberCode";
            colSerialNumberCode.Name = "colSerialNumberCode";
            colSerialNumberCode.Width = 88;
            // 
            // repoBtnEdit_SerialNumberCode
            // 
            repoBtnEdit_SerialNumberCode.AutoHeight = false;
            repoBtnEdit_SerialNumberCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_SerialNumberCode.Name = "repoBtnEdit_SerialNumberCode";
            repoBtnEdit_SerialNumberCode.ButtonPressed += repoBtnEdit_SerialNumberCode_ButtonPressed;
            // 
            // colUnitOfMeasureId
            // 
            colUnitOfMeasureId.ColumnEdit = repoLUE_UnitOfMeasure;
            colUnitOfMeasureId.FieldName = "UnitOfMeasureId";
            colUnitOfMeasureId.Name = "colUnitOfMeasureId";
            // 
            // repoLUE_UnitOfMeasure
            // 
            repoLUE_UnitOfMeasure.AutoHeight = false;
            repoLUE_UnitOfMeasure.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_UnitOfMeasure.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ConversionRate", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureId", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureDesc", "") });
            repoLUE_UnitOfMeasure.DisplayMember = "UnitOfMeasureDesc";
            repoLUE_UnitOfMeasure.Name = "repoLUE_UnitOfMeasure";
            repoLUE_UnitOfMeasure.NullText = "";
            repoLUE_UnitOfMeasure.ValueMember = "UnitOfMeasureId";
            repoLUE_UnitOfMeasure.PopupFilter += repoLUE_UnitOfMeasure_PopupFilter;
            // 
            // col_TotalBenefit
            // 
            col_TotalBenefit.FieldName = "TotalBenefit";
            col_TotalBenefit.Name = "col_TotalBenefit";
            // 
            // colWorkerCode
            // 
            colWorkerCode.ColumnEdit = repoBtnEdit_WorkerCode;
            colWorkerCode.FieldName = "WorkerCode";
            colWorkerCode.Name = "colWorkerCode";
            // 
            // repoBtnEdit_WorkerCode
            // 
            repoBtnEdit_WorkerCode.AutoHeight = false;
            repoBtnEdit_WorkerCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_WorkerCode.Name = "repoBtnEdit_WorkerCode";
            repoBtnEdit_WorkerCode.ButtonPressed += repoBtnEdit_WorkerCode_ButtonPressed;
            // 
            // repoBtnEdit_UnitOfMeasure
            // 
            repoBtnEdit_UnitOfMeasure.AutoHeight = false;
            repoBtnEdit_UnitOfMeasure.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_UnitOfMeasure.Name = "repoBtnEdit_UnitOfMeasure";
            repoBtnEdit_UnitOfMeasure.ButtonPressed += repoBtnEdit_UnitOfMeasure_ButtonPressed;
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
            // LCI_SalesPersonDesc
            // 
            LCI_SalesPersonDesc.Control = LBL_SalesPersonDesc;
            LCI_SalesPersonDesc.Location = new Point(1002, 24);
            LCI_SalesPersonDesc.MinSize = new Size(4, 17);
            LCI_SalesPersonDesc.Name = "LCI_SalesPersonDesc";
            LCI_SalesPersonDesc.Size = new Size(124, 24);
            LCI_SalesPersonDesc.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            LCI_SalesPersonDesc.TextSize = new Size(0, 0);
            LCI_SalesPersonDesc.TextVisible = false;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCG_Invoice });
            Root.Name = "Root";
            Root.Size = new Size(1146, 446);
            Root.TextVisible = false;
            // 
            // LCG_Invoice
            // 
            LCG_Invoice.AllowDrawBackground = false;
            LCG_Invoice.GroupBordersVisible = false;
            LCG_Invoice.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCI_GvProductList, ItemForDocumentNumber, ItemForCurrAccCode, splitterItem1, splitterItem2, emptySpaceItem3, emptySpaceItem4, LCG_InfoInstallment, LCG_InfoPayment, LCI_CurrAccDesc, ItemForStoreCode, ItemForCustomsDocumentNumber, ItemForDocumentDate, ItemForDocumentTime, ItemForToWarehouseCode, ItemForWarehouseCode, ItemForDescription, ItemForIsReturn, lCI_printCount, lCI_IsSent, emptySpaceItem2 });
            LCG_Invoice.Location = new Point(0, 0);
            LCG_Invoice.Name = "LCG_Invoice";
            LCG_Invoice.Size = new Size(1126, 426);
            // 
            // LCI_GvProductList
            // 
            LCI_GvProductList.Control = gC_InvoiceLine;
            LCI_GvProductList.Location = new Point(0, 96);
            LCI_GvProductList.Name = "LCI_GvProductList";
            LCI_GvProductList.Size = new Size(1126, 246);
            LCI_GvProductList.TextSize = new Size(0, 0);
            LCI_GvProductList.TextVisible = false;
            // 
            // ItemForDocumentNumber
            // 
            ItemForDocumentNumber.Control = btnEdit_DocNum;
            ItemForDocumentNumber.Location = new Point(0, 0);
            ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            ItemForDocumentNumber.Size = new Size(573, 24);
            ItemForDocumentNumber.Text = "Sənəd Nömrəsi";
            ItemForDocumentNumber.TextSize = new Size(98, 13);
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = btnEdit_CurrAccCode;
            ItemForCurrAccCode.Location = new Point(573, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(221, 24);
            ItemForCurrAccCode.Text = "Cari Hesab";
            ItemForCurrAccCode.TextSize = new Size(98, 13);
            // 
            // splitterItem1
            // 
            splitterItem1.AllowHotTrack = true;
            splitterItem1.Location = new Point(695, 342);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new Size(10, 84);
            // 
            // splitterItem2
            // 
            splitterItem2.AllowHotTrack = true;
            splitterItem2.Location = new Point(924, 342);
            splitterItem2.Name = "splitterItem2";
            splitterItem2.Size = new Size(10, 84);
            // 
            // emptySpaceItem3
            // 
            emptySpaceItem3.AllowHotTrack = false;
            emptySpaceItem3.Location = new Point(878, 342);
            emptySpaceItem3.Name = "emptySpaceItem3";
            emptySpaceItem3.Size = new Size(46, 84);
            emptySpaceItem3.TextSize = new Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            emptySpaceItem4.AllowHotTrack = false;
            emptySpaceItem4.Location = new Point(1073, 342);
            emptySpaceItem4.Name = "emptySpaceItem4";
            emptySpaceItem4.Size = new Size(53, 84);
            emptySpaceItem4.TextSize = new Size(0, 0);
            // 
            // LCG_InfoInstallment
            // 
            LCG_InfoInstallment.CustomizationFormText = "Kredit";
            LCG_InfoInstallment.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            LCG_InfoInstallment.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCI_InstallmentSum, LCI_InstallmentCommissionSum, LCI_InstallmentTotalSum, LCI_InstallmentCommissionSumTxt, LCI_InstallmentSumTxt, LCI_InstallmentTotalSumTxt });
            LCG_InfoInstallment.Location = new Point(705, 342);
            LCG_InfoInstallment.Name = "LCG_InfoInstallment";
            LCG_InfoInstallment.OptionsItemText.TextToControlDistance = 0;
            LCG_InfoInstallment.Size = new Size(173, 84);
            LCG_InfoInstallment.Text = "Kredit";
            LCG_InfoInstallment.TextLocation = DevExpress.Utils.Locations.Left;
            LCG_InfoInstallment.TextVisible = false;
            // 
            // LCI_InstallmentSum
            // 
            LCI_InstallmentSum.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InstallmentSum.Control = lbl_InstallmentSum;
            LCI_InstallmentSum.Location = new Point(93, 0);
            LCI_InstallmentSum.Name = "LCI_InstallmentSum";
            LCI_InstallmentSum.Size = new Size(56, 20);
            LCI_InstallmentSum.TextSize = new Size(0, 0);
            LCI_InstallmentSum.TextVisible = false;
            // 
            // LCI_InstallmentCommissionSum
            // 
            LCI_InstallmentCommissionSum.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InstallmentCommissionSum.Control = lbl_InstallmentCommissionSum;
            LCI_InstallmentCommissionSum.Location = new Point(93, 20);
            LCI_InstallmentCommissionSum.Name = "LCI_InstallmentCommissionSum";
            LCI_InstallmentCommissionSum.Size = new Size(56, 20);
            LCI_InstallmentCommissionSum.TextSize = new Size(0, 0);
            LCI_InstallmentCommissionSum.TextVisible = false;
            // 
            // LCI_InstallmentTotalSum
            // 
            LCI_InstallmentTotalSum.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InstallmentTotalSum.Control = lbl_InstallmentTotalSum;
            LCI_InstallmentTotalSum.Location = new Point(93, 40);
            LCI_InstallmentTotalSum.Name = "LCI_InstallmentTotalSum";
            LCI_InstallmentTotalSum.Size = new Size(56, 20);
            LCI_InstallmentTotalSum.TextSize = new Size(0, 0);
            LCI_InstallmentTotalSum.TextVisible = false;
            // 
            // LCI_InstallmentCommissionSumTxt
            // 
            LCI_InstallmentCommissionSumTxt.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InstallmentCommissionSumTxt.Control = lbl_InstallmentCommissionSumTxt;
            LCI_InstallmentCommissionSumTxt.Location = new Point(0, 20);
            LCI_InstallmentCommissionSumTxt.Name = "LCI_InstallmentCommissionSumTxt";
            LCI_InstallmentCommissionSumTxt.Size = new Size(93, 20);
            LCI_InstallmentCommissionSumTxt.TextSize = new Size(0, 0);
            LCI_InstallmentCommissionSumTxt.TextVisible = false;
            // 
            // LCI_InstallmentSumTxt
            // 
            LCI_InstallmentSumTxt.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InstallmentSumTxt.Control = lbl_InstallmentSumTxt;
            LCI_InstallmentSumTxt.Location = new Point(0, 0);
            LCI_InstallmentSumTxt.Name = "LCI_InstallmentSumTxt";
            LCI_InstallmentSumTxt.Size = new Size(93, 20);
            LCI_InstallmentSumTxt.TextSize = new Size(0, 0);
            LCI_InstallmentSumTxt.TextVisible = false;
            // 
            // LCI_InstallmentTotalSumTxt
            // 
            LCI_InstallmentTotalSumTxt.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InstallmentTotalSumTxt.Control = lbl_InstallmentTotalSumTxt;
            LCI_InstallmentTotalSumTxt.Location = new Point(0, 40);
            LCI_InstallmentTotalSumTxt.Name = "LCI_InstallmentTotalSumTxt";
            LCI_InstallmentTotalSumTxt.Size = new Size(93, 20);
            LCI_InstallmentTotalSumTxt.TextSize = new Size(0, 0);
            LCI_InstallmentTotalSumTxt.TextVisible = false;
            // 
            // LCG_InfoPayment
            // 
            LCG_InfoPayment.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            LCG_InfoPayment.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCI_InvoicePaidSum, LCI_InvoicePaidCashSum, LCI_InvoicePaidSumTxt, LCI_InvoicePaidCashlessSumTxt, LCI_InvoicePaidCashSumTxt, LCI_InvoicePaidCashlessSum });
            LCG_InfoPayment.Location = new Point(934, 342);
            LCG_InfoPayment.Name = "LCG_InfoPayment";
            LCG_InfoPayment.Size = new Size(139, 84);
            LCG_InfoPayment.Text = "Ödəniş";
            LCG_InfoPayment.TextLocation = DevExpress.Utils.Locations.Left;
            LCG_InfoPayment.TextVisible = false;
            // 
            // LCI_InvoicePaidSum
            // 
            LCI_InvoicePaidSum.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InvoicePaidSum.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            LCI_InvoicePaidSum.Control = lbl_InvoicePaidTotalSum;
            LCI_InvoicePaidSum.Location = new Point(59, 40);
            LCI_InvoicePaidSum.Name = "LCI_InvoicePaidSum";
            LCI_InvoicePaidSum.Size = new Size(56, 20);
            LCI_InvoicePaidSum.Text = "0.00";
            LCI_InvoicePaidSum.TextSize = new Size(0, 0);
            LCI_InvoicePaidSum.TextVisible = false;
            // 
            // LCI_InvoicePaidCashSum
            // 
            LCI_InvoicePaidCashSum.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InvoicePaidCashSum.Control = lbl_InvoicePaidCashSum;
            LCI_InvoicePaidCashSum.Location = new Point(59, 0);
            LCI_InvoicePaidCashSum.Name = "LCI_InvoicePaidCashSum";
            LCI_InvoicePaidCashSum.Size = new Size(56, 20);
            LCI_InvoicePaidCashSum.TextSize = new Size(0, 0);
            LCI_InvoicePaidCashSum.TextVisible = false;
            // 
            // LCI_InvoicePaidSumTxt
            // 
            LCI_InvoicePaidSumTxt.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InvoicePaidSumTxt.Control = lbl_InvoicePaidTotalSumTxt;
            LCI_InvoicePaidSumTxt.Location = new Point(0, 40);
            LCI_InvoicePaidSumTxt.Name = "LCI_InvoicePaidSumTxt";
            LCI_InvoicePaidSumTxt.Size = new Size(59, 20);
            LCI_InvoicePaidSumTxt.TextSize = new Size(0, 0);
            LCI_InvoicePaidSumTxt.TextVisible = false;
            // 
            // LCI_InvoicePaidCashlessSumTxt
            // 
            LCI_InvoicePaidCashlessSumTxt.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InvoicePaidCashlessSumTxt.Control = lbl_InvoicePaidCashlessSumTxt;
            LCI_InvoicePaidCashlessSumTxt.Location = new Point(0, 20);
            LCI_InvoicePaidCashlessSumTxt.Name = "LCI_InvoicePaidCashlessSumTxt";
            LCI_InvoicePaidCashlessSumTxt.Size = new Size(59, 20);
            LCI_InvoicePaidCashlessSumTxt.TextSize = new Size(0, 0);
            LCI_InvoicePaidCashlessSumTxt.TextVisible = false;
            // 
            // LCI_InvoicePaidCashSumTxt
            // 
            LCI_InvoicePaidCashSumTxt.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InvoicePaidCashSumTxt.Control = lbl_InvoicePaidCashSumTxt;
            LCI_InvoicePaidCashSumTxt.Location = new Point(0, 0);
            LCI_InvoicePaidCashSumTxt.Name = "LCI_InvoicePaidCashSumTxt";
            LCI_InvoicePaidCashSumTxt.Size = new Size(59, 20);
            LCI_InvoicePaidCashSumTxt.TextSize = new Size(0, 0);
            LCI_InvoicePaidCashSumTxt.TextVisible = false;
            // 
            // LCI_InvoicePaidCashlessSum
            // 
            LCI_InvoicePaidCashlessSum.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            LCI_InvoicePaidCashlessSum.Control = lbl_InvoicePaidCashlessSum;
            LCI_InvoicePaidCashlessSum.Location = new Point(59, 20);
            LCI_InvoicePaidCashlessSum.Name = "LCI_InvoicePaidCashlessSum";
            LCI_InvoicePaidCashlessSum.Size = new Size(56, 20);
            LCI_InvoicePaidCashlessSum.TextSize = new Size(0, 0);
            LCI_InvoicePaidCashlessSum.TextVisible = false;
            // 
            // LCI_CurrAccDesc
            // 
            LCI_CurrAccDesc.Control = lbl_CurrAccDesc;
            LCI_CurrAccDesc.Location = new Point(794, 0);
            LCI_CurrAccDesc.MinSize = new Size(67, 17);
            LCI_CurrAccDesc.Name = "LCI_CurrAccDesc";
            LCI_CurrAccDesc.Size = new Size(332, 24);
            LCI_CurrAccDesc.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            LCI_CurrAccDesc.Text = "CurrAccDesc";
            LCI_CurrAccDesc.TextSize = new Size(0, 0);
            LCI_CurrAccDesc.TextVisible = false;
            // 
            // ItemForStoreCode
            // 
            ItemForStoreCode.Control = lUE_StoreCode;
            ItemForStoreCode.Location = new Point(573, 48);
            ItemForStoreCode.Name = "ItemForStoreCode";
            ItemForStoreCode.Size = new Size(553, 24);
            ItemForStoreCode.Text = "Mağaza";
            ItemForStoreCode.TextSize = new Size(98, 13);
            // 
            // ItemForCustomsDocumentNumber
            // 
            ItemForCustomsDocumentNumber.Control = CustomsDocumentNumberTextEdit;
            ItemForCustomsDocumentNumber.Location = new Point(0, 24);
            ItemForCustomsDocumentNumber.Name = "ItemForCustomsDocumentNumber";
            ItemForCustomsDocumentNumber.Size = new Size(573, 24);
            ItemForCustomsDocumentNumber.Text = "Fərdi Sənəd Nömrəsi";
            ItemForCustomsDocumentNumber.TextSize = new Size(98, 13);
            // 
            // ItemForDocumentDate
            // 
            ItemForDocumentDate.Control = DocumentDateDateEdit;
            ItemForDocumentDate.Location = new Point(0, 48);
            ItemForDocumentDate.Name = "ItemForDocumentDate";
            ItemForDocumentDate.Size = new Size(432, 24);
            ItemForDocumentDate.Text = "Sənəd Tarixi";
            ItemForDocumentDate.TextSize = new Size(98, 13);
            // 
            // ItemForDocumentTime
            // 
            ItemForDocumentTime.Control = DocumentTimeTimeSpanEdit;
            ItemForDocumentTime.Location = new Point(432, 48);
            ItemForDocumentTime.Name = "ItemForDocumentTime";
            ItemForDocumentTime.Size = new Size(141, 24);
            ItemForDocumentTime.Text = "Sənəd Vaxtı";
            ItemForDocumentTime.TextSize = new Size(0, 0);
            ItemForDocumentTime.TextVisible = false;
            // 
            // ItemForToWarehouseCode
            // 
            ItemForToWarehouseCode.Control = lUE_ToWarehouseCode;
            ItemForToWarehouseCode.Location = new Point(573, 24);
            ItemForToWarehouseCode.Name = "ItemForToWarehouseCode";
            ItemForToWarehouseCode.Size = new Size(553, 24);
            ItemForToWarehouseCode.Text = "Depoya";
            ItemForToWarehouseCode.TextSize = new Size(98, 13);
            // 
            // ItemForWarehouseCode
            // 
            ItemForWarehouseCode.Control = lUE_WarehouseCode;
            ItemForWarehouseCode.Location = new Point(573, 72);
            ItemForWarehouseCode.Name = "ItemForWarehouseCode";
            ItemForWarehouseCode.Size = new Size(553, 24);
            ItemForWarehouseCode.Text = "Depodan";
            ItemForWarehouseCode.TextSize = new Size(98, 13);
            // 
            // ItemForDescription
            // 
            ItemForDescription.Control = memoEdit_Desc;
            ItemForDescription.Location = new Point(0, 72);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new Size(573, 24);
            ItemForDescription.Text = "Açıqlama";
            ItemForDescription.TextSize = new Size(98, 13);
            // 
            // ItemForIsReturn
            // 
            ItemForIsReturn.Control = checkEdit_IsReturn;
            ItemForIsReturn.Location = new Point(0, 342);
            ItemForIsReturn.Name = "ItemForIsReturn";
            ItemForIsReturn.Size = new Size(104, 84);
            ItemForIsReturn.TextSize = new Size(0, 0);
            ItemForIsReturn.TextVisible = false;
            // 
            // lCI_printCount
            // 
            lCI_printCount.Control = txtEdit_PrintCount;
            lCI_printCount.Location = new Point(178, 342);
            lCI_printCount.Name = "lCI_printCount";
            lCI_printCount.Size = new Size(104, 84);
            lCI_printCount.Text = "Print Sayı";
            lCI_printCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            lCI_printCount.TextSize = new Size(45, 13);
            lCI_printCount.TextToControlDistance = 5;
            // 
            // lCI_IsSent
            // 
            lCI_IsSent.Control = checkEdit_IsSent;
            lCI_IsSent.Location = new Point(104, 342);
            lCI_IsSent.Name = "lCI_IsSent";
            lCI_IsSent.Size = new Size(74, 84);
            lCI_IsSent.TextSize = new Size(0, 0);
            lCI_IsSent.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(282, 342);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(413, 84);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("print", "image://svgimages/print/print.svg");
            svgImageCollection1.Add("report", "image://svgimages/business objects/bo_report.svg");
            svgImageCollection1.Add("setting", "image://svgimages/dashboards/scatterchartlabeloptions.svg");
            svgImageCollection1.Add("DeleteInvoiceIS", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.DeleteInvoiceIS"));
            svgImageCollection1.Add("DeletePayment", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.DeletePayment"));
            svgImageCollection1.Add("DeleteExpenses", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.DeleteExpenses"));
            svgImageCollection1.Add("DeleteInvoice", (DevExpress.Utils.Svg.SvgImage)resources.GetObject("svgImageCollection1.DeleteInvoice"));
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
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1146, 604);
            Controls.Add(dataLayoutControl1);
            Controls.Add(ribbonControl1);
            Name = "FormInvoice";
            Ribbon = ribbonControl1;
            Text = "Faktura";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormInvoice_FormClosing;
            Load += FormInvoice_Load;
            Shown += FormInvoice_Shown;
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLinesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuPrinters).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCBE_PrinterName).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioInstance).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoTxtEdit_TwilioToken).EndInit();
            ((System.ComponentModel.ISupportInitialize)repo).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_PrintCount.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_SalesPerson.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_PriceLoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_Price).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SalesPersonCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SerialNumberCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_UnitOfMeasure).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_WorkerCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_UnitOfMeasure).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPerson).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SalesPersonDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCG_Invoice).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_GvProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCG_InfoInstallment).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentCommissionSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentTotalSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentCommissionSumTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentSumTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InstallmentTotalSumTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCG_InfoPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidSumTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashlessSumTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashSumTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_InvoicePaidCashlessSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_CurrAccDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForStoreCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCustomsDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForToWarehouseCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForWarehouseCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsReturn).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_printCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_IsSent).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)adorneruıManager1).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlGroup LCG_Invoice;
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bBI_Payment;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidSum;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InvoicePaidSum;
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
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem BBI_exportXLSX;
        private DevExpress.XtraBars.BarButtonItem BBI_ImportExcel;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit_TwilioInstance;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoTxtEdit_TwilioToken;
        private DevExpress.XtraEditors.CheckEdit checkEdit_IsSent;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportPrintFast;
        private DevExpress.XtraBars.BarButtonItem BBI_PrintSettingSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repo;
        private DevExpress.XtraBars.BarEditItem BEI_PrinterName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoCBE_PrinterName;
        private DevExpress.XtraEditors.SimpleButton Btn_EditInvoice;
        private DevExpress.XtraEditors.TextEdit txtEdit_PrintCount;
        private DevExpress.XtraLayout.LayoutControlItem lCI_printCount;
        private DevExpress.XtraLayout.LayoutControlItem lCI_IsSent;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraBars.BarButtonItem btn_info;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem BBI_picture;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
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
        private DevExpress.XtraEditors.ButtonEdit btnEdit_SalesPerson;
        private DevExpress.XtraLayout.LayoutControlItem LCI_SalesPerson;
        private DevExpress.XtraEditors.LabelControl LBL_SalesPersonDesc;
        private DevExpress.XtraLayout.LayoutControlItem LCI_SalesPersonDesc;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem BBI_Reports;
        private BarSubItem BSI_Reports;
        private PopupMenu popupMenuPrinters;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMeasureId;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_UnitOfMeasure;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_UnitOfMeasure;
        private DevExpress.XtraEditors.LabelControl lbl_InstallmentSum;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InstallmentTotalSumTxt;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InstallmentCommissionSumTxt;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InstallmentSumTxt;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InstallmentSum;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InstallmentCommissionSum;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InstallmentTotalSum;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InvoicePaidSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InstallmentTotalSum;
        private DevExpress.XtraEditors.LabelControl lbl_InstallmentCommissionSum;
        private DevExpress.XtraEditors.LabelControl lbl_InstallmentSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InstallmentCommissionSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InstallmentTotalSumTxt;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InvoicePaidCashSumTxt;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InvoicePaidCashlessSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidTotalSum;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidTotalSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidCashlessSumTxt;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidCashSumTxt;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InvoicePaidCashSum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlItem LCI_InvoicePaidCashlessSum;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidCashlessSum;
        private DevExpress.XtraEditors.LabelControl lbl_InvoicePaidCashSum;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlGroup LCG_InfoInstallment;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup LCG_InfoPayment;
        private GridColumn col_TotalBenefit;
        private BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_Installment;
        private BarButtonItem BBI_InstallmentDelete;
        private BarButtonItem bBI_PaymentDelete;
        private BarButtonItem barButtonItem4;
        private PopupMenu popupMenu1;
        private BarButtonItem barButtonItem5;
        private BarButtonItem BBI_EditInvoice;
        private GridColumn colWorkerCode;
        private RepositoryItemButtonEdit repoBtnEdit_WorkerCode;
    }
}