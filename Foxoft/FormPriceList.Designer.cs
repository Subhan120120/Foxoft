
using Foxoft.Models;

namespace Foxoft
{
    partial class FormPriceListDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPriceListDetail));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_DeletePriceList = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_NewPriceList = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_Info = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_ImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.BBI_exportXLSX = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gC_PriceListLine = new DevExpress.XtraGrid.GridControl();
            this.trPriceListLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_PriceListLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriceListLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceListHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCalcEdit_ReceivePriceList = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repoCalcEdit_MakePriceList = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.DocumentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.trPriceListHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DocumentTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            this.DueDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.DueTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IsDisabledCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.IsConfirmedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            this.btnEdit_PriceTypeCode = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDueDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDueTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsConfirmed = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gC_PriceListLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPriceListLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PriceListLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLUE_CurrencyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_ReceivePriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_MakePriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPriceListHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DueDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DueDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DueTimeTimeSpanEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsDisabledCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsConfirmedCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_PriceTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDueTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsConfirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bBI_DeletePriceList,
            this.bBI_SaveAndClose,
            this.bBI_NewPriceList,
            this.BBI_Info,
            this.BBI_ImportExcel,
            this.BBI_exportXLSX});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(948, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bBI_DeletePriceList
            // 
            this.bBI_DeletePriceList.Caption = "Qiymət Siyahısını Sil";
            this.bBI_DeletePriceList.Id = 1;
            this.bBI_DeletePriceList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_DeletePriceList.ImageOptions.SvgImage")));
            this.bBI_DeletePriceList.Name = "bBI_DeletePriceList";
            this.bBI_DeletePriceList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_DeletePriceList_ItemClick);
            // 
            // bBI_SaveAndClose
            // 
            this.bBI_SaveAndClose.Caption = "Yadda Saxla Bağla";
            this.bBI_SaveAndClose.Id = 2;
            this.bBI_SaveAndClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_SaveAndClose.ImageOptions.SvgImage")));
            this.bBI_SaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            this.bBI_SaveAndClose.Name = "bBI_SaveAndClose";
            this.bBI_SaveAndClose.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_SaveAndClose_ItemClick);
            // 
            // bBI_NewPriceList
            // 
            this.bBI_NewPriceList.Caption = "Yeni Qiymət Siyahısı";
            this.bBI_NewPriceList.Id = 5;
            this.bBI_NewPriceList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_NewPriceList.ImageOptions.SvgImage")));
            this.bBI_NewPriceList.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.bBI_NewPriceList.Name = "bBI_NewPriceList";
            this.bBI_NewPriceList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_NewPriceList_ItemClick);
            // 
            // BBI_Info
            // 
            this.BBI_Info.Caption = "İnfo";
            this.BBI_Info.Id = 10;
            this.BBI_Info.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_Info.ImageOptions.SvgImage")));
            this.BBI_Info.Name = "BBI_Info";
            // 
            // BBI_ImportExcel
            // 
            this.BBI_ImportExcel.Caption = "Excel\'dən Al";
            this.BBI_ImportExcel.Id = 11;
            this.BBI_ImportExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_ImportExcel.ImageOptions.SvgImage")));
            this.BBI_ImportExcel.Name = "BBI_ImportExcel";
            this.BBI_ImportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_ImportExcel_ItemClick);
            // 
            // BBI_exportXLSX
            // 
            this.BBI_exportXLSX.Caption = "Excel\'ə Göndər";
            this.BBI_exportXLSX.Id = 22;
            this.BBI_exportXLSX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BBI_exportXLSX.ImageOptions.SvgImage")));
            this.BBI_exportXLSX.Name = "BBI_exportXLSX";
            this.BBI_exportXLSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBI_exportXLSX_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ödəmə";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_SaveAndClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_NewPriceList);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_DeletePriceList);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Ödəmə";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup3.ItemLinks.Add(this.BBI_Info);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Məlumat";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BBI_ImportExcel);
            this.ribbonPageGroup2.ItemLinks.Add(this.BBI_exportXLSX);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Excel";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 623);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(948, 24);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gC_PriceListLine);
            this.dataLayoutControl1.Controls.Add(this.DocumentDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.DocumentTimeTimeSpanEdit);
            this.dataLayoutControl1.Controls.Add(this.DueDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.DueTimeTimeSpanEdit);
            this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.IsDisabledCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.IsConfirmedCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.btnEdit_DocNum);
            this.dataLayoutControl1.Controls.Add(this.btnEdit_PriceTypeCode);
            this.dataLayoutControl1.DataSource = this.trPriceListHeadersBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(947, 331, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(948, 465);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gC_PriceListLine
            // 
            this.gC_PriceListLine.DataSource = this.trPriceListLinesBindingSource;
            this.gC_PriceListLine.Location = new System.Drawing.Point(12, 108);
            this.gC_PriceListLine.MainView = this.gV_PriceListLine;
            this.gC_PriceListLine.MenuManager = this.ribbon;
            this.gC_PriceListLine.Name = "gC_PriceListLine";
            this.gC_PriceListLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoLUE_CurrencyCode,
            this.repoCalcEdit_ReceivePriceList,
            this.repoCalcEdit_MakePriceList,
            this.repoBtnEdit_ProductCode});
            this.gC_PriceListLine.Size = new System.Drawing.Size(924, 345);
            this.gC_PriceListLine.TabIndex = 9;
            this.gC_PriceListLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_PriceListLine});
            this.gC_PriceListLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gC_PriceListLine_KeyDown);
            // 
            // trPriceListLinesBindingSource
            // 
            this.trPriceListLinesBindingSource.DataSource = typeof(Foxoft.Models.TrPriceListLine);
            // 
            // gV_PriceListLine
            // 
            this.gV_PriceListLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriceListLineId,
            this.colPriceListHeaderId,
            this.colProductCode,
            this.colPrice,
            this.colCurrencyCode,
            this.colLineDescription,
            this.colProductDesc,
            this.colLastPurchasePrice});
            this.gV_PriceListLine.CustomizationFormBounds = new System.Drawing.Rectangle(760, 390, 264, 272);
            this.gV_PriceListLine.GridControl = this.gC_PriceListLine;
            this.gV_PriceListLine.Name = "gV_PriceListLine";
            this.gV_PriceListLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gV_PriceListLine.OptionsNavigation.AutoFocusNewRow = true;
            this.gV_PriceListLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gV_PriceListLine.OptionsView.ShowGroupPanel = false;
            this.gV_PriceListLine.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gV_PriceListLine_RowCellStyle);
            this.gV_PriceListLine.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gV_PriceListLine_InitNewRow);
            this.gV_PriceListLine.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gV_PriceListLine_RowDeleted);
            this.gV_PriceListLine.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gV_PriceListLine_RowUpdated);
            this.gV_PriceListLine.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gV_PriceListLine_CustomUnboundColumnData);
            // 
            // colPriceListLineId
            // 
            this.colPriceListLineId.FieldName = "PriceListLineId";
            this.colPriceListLineId.Name = "colPriceListLineId";
            this.colPriceListLineId.OptionsColumn.AllowEdit = false;
            this.colPriceListLineId.OptionsColumn.ReadOnly = true;
            // 
            // colPriceListHeaderId
            // 
            this.colPriceListHeaderId.FieldName = "PriceListHeaderId";
            this.colPriceListHeaderId.Name = "colPriceListHeaderId";
            this.colPriceListHeaderId.OptionsColumn.AllowEdit = false;
            this.colPriceListHeaderId.OptionsColumn.ReadOnly = true;
            // 
            // colProductCode
            // 
            this.colProductCode.ColumnEdit = this.repoBtnEdit_ProductCode;
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            this.colProductCode.Width = 118;
            // 
            // repoBtnEdit_ProductCode
            // 
            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoBtnEdit_ProductCode_ButtonPressed);
            // 
            // colPrice
            // 
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 101;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.ColumnEdit = this.repoLUE_CurrencyCode;
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 3;
            this.colCurrencyCode.Width = 108;
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
            // 
            // colLineDescription
            // 
            this.colLineDescription.FieldName = "LineDescription";
            this.colLineDescription.Name = "colLineDescription";
            this.colLineDescription.Visible = true;
            this.colLineDescription.VisibleIndex = 4;
            this.colLineDescription.Width = 242;
            // 
            // colProductDesc
            // 
            this.colProductDesc.FieldName = "DcProduct.ProductDesc";
            this.colProductDesc.Name = "colProductDesc";
            this.colProductDesc.OptionsColumn.AllowEdit = false;
            this.colProductDesc.OptionsColumn.ReadOnly = true;
            this.colProductDesc.UnboundDataType = typeof(string);
            this.colProductDesc.Visible = true;
            this.colProductDesc.VisibleIndex = 1;
            this.colProductDesc.Width = 421;
            // 
            // colLastPurchasePrice
            // 
            this.colLastPurchasePrice.FieldName = "DcProduct.LastPurchasePrice";
            this.colLastPurchasePrice.Name = "colLastPurchasePrice";
            this.colLastPurchasePrice.OptionsColumn.AllowEdit = false;
            this.colLastPurchasePrice.OptionsColumn.ReadOnly = true;
            this.colLastPurchasePrice.UnboundDataType = typeof(decimal);
            this.colLastPurchasePrice.Visible = true;
            this.colLastPurchasePrice.VisibleIndex = 5;
            // 
            // repoCalcEdit_ReceivePriceList
            // 
            this.repoCalcEdit_ReceivePriceList.AutoHeight = false;
            this.repoCalcEdit_ReceivePriceList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoCalcEdit_ReceivePriceList.Name = "repoCalcEdit_ReceivePriceList";
            // 
            // repoCalcEdit_MakePriceList
            // 
            this.repoCalcEdit_MakePriceList.AutoHeight = false;
            this.repoCalcEdit_MakePriceList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoCalcEdit_MakePriceList.Name = "repoCalcEdit_MakePriceList";
            // 
            // DocumentDateDateEdit
            // 
            this.DocumentDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "DocumentDate", true));
            this.DocumentDateDateEdit.EditValue = null;
            this.DocumentDateDateEdit.Location = new System.Drawing.Point(135, 36);
            this.DocumentDateDateEdit.MenuManager = this.ribbon;
            this.DocumentDateDateEdit.Name = "DocumentDateDateEdit";
            this.DocumentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentDateDateEdit.Size = new System.Drawing.Size(337, 20);
            this.DocumentDateDateEdit.StyleController = this.dataLayoutControl1;
            this.DocumentDateDateEdit.TabIndex = 2;
            // 
            // trPriceListHeadersBindingSource
            // 
            this.trPriceListHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrPriceListHeader);
            this.trPriceListHeadersBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.trPriceListHeadersBindingSource_AddingNew);
            this.trPriceListHeadersBindingSource.CurrentItemChanged += new System.EventHandler(this.trPriceListHeadersBindingSource_CurrentItemChanged);
            // 
            // DocumentTimeTimeSpanEdit
            // 
            this.DocumentTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "DocumentTime", true));
            this.DocumentTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            this.DocumentTimeTimeSpanEdit.Location = new System.Drawing.Point(135, 60);
            this.DocumentTimeTimeSpanEdit.MenuManager = this.ribbon;
            this.DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
            this.DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentTimeTimeSpanEdit.Size = new System.Drawing.Size(337, 20);
            this.DocumentTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
            this.DocumentTimeTimeSpanEdit.TabIndex = 4;
            // 
            // DueDateDateEdit
            // 
            this.DueDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "DueDate", true));
            this.DueDateDateEdit.EditValue = null;
            this.DueDateDateEdit.Location = new System.Drawing.Point(599, 36);
            this.DueDateDateEdit.MenuManager = this.ribbon;
            this.DueDateDateEdit.Name = "DueDateDateEdit";
            this.DueDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DueDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DueDateDateEdit.Size = new System.Drawing.Size(337, 20);
            this.DueDateDateEdit.StyleController = this.dataLayoutControl1;
            this.DueDateDateEdit.TabIndex = 3;
            // 
            // DueTimeTimeSpanEdit
            // 
            this.DueTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "DueTime", true));
            this.DueTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            this.DueTimeTimeSpanEdit.Location = new System.Drawing.Point(599, 60);
            this.DueTimeTimeSpanEdit.MenuManager = this.ribbon;
            this.DueTimeTimeSpanEdit.Name = "DueTimeTimeSpanEdit";
            this.DueTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DueTimeTimeSpanEdit.Size = new System.Drawing.Size(337, 20);
            this.DueTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
            this.DueTimeTimeSpanEdit.TabIndex = 5;
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "Description", true));
            this.DescriptionTextEdit.Location = new System.Drawing.Point(599, 84);
            this.DescriptionTextEdit.MenuManager = this.ribbon;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Size = new System.Drawing.Size(337, 20);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionTextEdit.TabIndex = 8;
            // 
            // IsDisabledCheckEdit
            // 
            this.IsDisabledCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "IsDisabled", true));
            this.IsDisabledCheckEdit.Location = new System.Drawing.Point(244, 84);
            this.IsDisabledCheckEdit.MenuManager = this.ribbon;
            this.IsDisabledCheckEdit.Name = "IsDisabledCheckEdit";
            this.IsDisabledCheckEdit.Properties.Caption = "Ləğv Edilib";
            this.IsDisabledCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.IsDisabledCheckEdit.Size = new System.Drawing.Size(212, 20);
            this.IsDisabledCheckEdit.StyleController = this.dataLayoutControl1;
            this.IsDisabledCheckEdit.TabIndex = 7;
            // 
            // IsConfirmedCheckEdit
            // 
            this.IsConfirmedCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "IsConfirmed", true));
            this.IsConfirmedCheckEdit.Location = new System.Drawing.Point(12, 84);
            this.IsConfirmedCheckEdit.MenuManager = this.ribbon;
            this.IsConfirmedCheckEdit.Name = "IsConfirmedCheckEdit";
            this.IsConfirmedCheckEdit.Properties.Caption = "Təsdiqlənib";
            this.IsConfirmedCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.IsConfirmedCheckEdit.Size = new System.Drawing.Size(228, 20);
            this.IsConfirmedCheckEdit.StyleController = this.dataLayoutControl1;
            this.IsConfirmedCheckEdit.TabIndex = 6;
            // 
            // btnEdit_DocNum
            // 
            this.btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "DocumentNumber", true));
            this.btnEdit_DocNum.Location = new System.Drawing.Point(135, 12);
            this.btnEdit_DocNum.MenuManager = this.ribbon;
            this.btnEdit_DocNum.Name = "btnEdit_DocNum";
            this.btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_DocNum.Size = new System.Drawing.Size(337, 20);
            this.btnEdit_DocNum.StyleController = this.dataLayoutControl1;
            this.btnEdit_DocNum.TabIndex = 0;
            this.btnEdit_DocNum.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_DocNum_ButtonPressed);
            // 
            // btnEdit_PriceTypeCode
            // 
            this.btnEdit_PriceTypeCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPriceListHeadersBindingSource, "PriceTypeCode", true));
            this.btnEdit_PriceTypeCode.Location = new System.Drawing.Point(599, 12);
            this.btnEdit_PriceTypeCode.MenuManager = this.ribbon;
            this.btnEdit_PriceTypeCode.Name = "btnEdit_PriceTypeCode";
            this.btnEdit_PriceTypeCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.btnEdit_PriceTypeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_PriceTypeCode.Size = new System.Drawing.Size(337, 20);
            this.btnEdit_PriceTypeCode.StyleController = this.dataLayoutControl1;
            this.btnEdit_PriceTypeCode.TabIndex = 10;
            this.btnEdit_PriceTypeCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_PriceTypeCode_ButtonPressed);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(948, 465);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.ItemForDocumentDate,
            this.ItemForDocumentTime,
            this.ItemForDueDate,
            this.ItemForDueTime,
            this.ItemForDescription,
            this.ItemForIsConfirmed,
            this.ItemForIsDisabled,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(928, 445);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gC_PriceListLine;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(928, 349);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForDocumentDate
            // 
            this.ItemForDocumentDate.Control = this.DocumentDateDateEdit;
            this.ItemForDocumentDate.Location = new System.Drawing.Point(0, 24);
            this.ItemForDocumentDate.Name = "ItemForDocumentDate";
            this.ItemForDocumentDate.Size = new System.Drawing.Size(464, 24);
            this.ItemForDocumentDate.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDocumentTime
            // 
            this.ItemForDocumentTime.Control = this.DocumentTimeTimeSpanEdit;
            this.ItemForDocumentTime.Location = new System.Drawing.Point(0, 48);
            this.ItemForDocumentTime.Name = "ItemForDocumentTime";
            this.ItemForDocumentTime.Size = new System.Drawing.Size(464, 24);
            this.ItemForDocumentTime.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDueDate
            // 
            this.ItemForDueDate.Control = this.DueDateDateEdit;
            this.ItemForDueDate.Location = new System.Drawing.Point(464, 24);
            this.ItemForDueDate.Name = "ItemForDueDate";
            this.ItemForDueDate.Size = new System.Drawing.Size(464, 24);
            this.ItemForDueDate.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDueTime
            // 
            this.ItemForDueTime.Control = this.DueTimeTimeSpanEdit;
            this.ItemForDueTime.Location = new System.Drawing.Point(464, 48);
            this.ItemForDueTime.Name = "ItemForDueTime";
            this.ItemForDueTime.Size = new System.Drawing.Size(464, 24);
            this.ItemForDueTime.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(464, 72);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(464, 24);
            this.ItemForDescription.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForIsConfirmed
            // 
            this.ItemForIsConfirmed.Control = this.IsConfirmedCheckEdit;
            this.ItemForIsConfirmed.Location = new System.Drawing.Point(0, 72);
            this.ItemForIsConfirmed.Name = "ItemForIsConfirmed";
            this.ItemForIsConfirmed.Size = new System.Drawing.Size(232, 24);
            this.ItemForIsConfirmed.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForIsConfirmed.TextVisible = false;
            // 
            // ItemForIsDisabled
            // 
            this.ItemForIsDisabled.Control = this.IsDisabledCheckEdit;
            this.ItemForIsDisabled.Location = new System.Drawing.Point(232, 72);
            this.ItemForIsDisabled.Name = "ItemForIsDisabled";
            this.ItemForIsDisabled.Size = new System.Drawing.Size(216, 24);
            this.ItemForIsDisabled.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForIsDisabled.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(448, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(16, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnEdit_DocNum;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "Faktura Nömrəsi";
            this.layoutControlItem2.Size = new System.Drawing.Size(464, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(111, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnEdit_PriceTypeCode;
            this.layoutControlItem3.Location = new System.Drawing.Point(464, 0);
            this.layoutControlItem3.Name = "Qiymət Siyahı Tipi Kodu";
            this.layoutControlItem3.Size = new System.Drawing.Size(464, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(111, 13);
            // 
            // FormPriceListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 647);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FormPriceListDetail";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Qiymət Siyahısı";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gC_PriceListLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPriceListLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_PriceListLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLUE_CurrencyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_ReceivePriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCalcEdit_MakePriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPriceListHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DueDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DueDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DueTimeTimeSpanEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsDisabledCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsConfirmedCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_PriceTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDueTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsConfirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
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
        private System.Windows.Forms.BindingSource trPriceListHeadersBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gC_PriceListLine;
        private System.Windows.Forms.BindingSource trPriceListLinesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_PriceListLine;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bBI_DeletePriceList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_CurrencyCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_CashregisterCode;
        private DevExpress.XtraBars.BarButtonItem bBI_SaveAndClose;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_ReceivePriceList;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoCalcEdit_MakePriceList;
        private DevExpress.XtraBars.BarButtonItem bBI_NewPriceList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem BBI_Info;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraEditors.DateEdit DocumentDateDateEdit;
        private DevExpress.XtraEditors.TimeSpanEdit DocumentTimeTimeSpanEdit;
        private DevExpress.XtraEditors.DateEdit DueDateDateEdit;
        private DevExpress.XtraEditors.TimeSpanEdit DueTimeTimeSpanEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsDisabledCheckEdit;
        private DevExpress.XtraEditors.CheckEdit IsConfirmedCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDueDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDueTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsDisabled;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsConfirmed;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ButtonEdit DocumentNumberButtonEdit;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_DocNum;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_PriceTypeCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDesc;
        private DevExpress.XtraBars.BarButtonItem BBI_ImportExcel;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BBI_exportXLSX;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPurchasePrice;
    }
}