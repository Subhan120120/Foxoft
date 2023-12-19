
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPriceListDetail));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_DeletePriceList = new DevExpress.XtraBars.BarButtonItem();
            bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            bBI_NewPriceList = new DevExpress.XtraBars.BarButtonItem();
            BBI_Info = new DevExpress.XtraBars.BarButtonItem();
            BBI_ImportExcel = new DevExpress.XtraBars.BarButtonItem();
            BBI_exportXLSX = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            gC_PriceListLine = new DevExpress.XtraGrid.GridControl();
            trPriceListLinesBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_PriceListLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPriceListLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriceListHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_CurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCalcEdit_ReceivePriceList = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repoCalcEdit_MakePriceList = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            DocumentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            trPriceListHeadersBindingSource = new System.Windows.Forms.BindingSource(components);
            DocumentTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            DueDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            DueTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            IsDisabledCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            IsConfirmedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            btnEdit_PriceTypeCode = new DevExpress.XtraEditors.ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDueDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDueTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsConfirmed = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_PriceListLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPriceListLinesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_PriceListLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_ReceivePriceList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_MakePriceList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPriceListHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocumentTimeTimeSpanEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DueDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DueDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DueTimeTimeSpanEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DescriptionTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsDisabledCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsConfirmedCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_PriceTypeCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDueDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDueTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsConfirmed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, bBI_DeletePriceList, bBI_SaveAndClose, bBI_NewPriceList, BBI_Info, BBI_ImportExcel, BBI_exportXLSX, ribbon.SearchEditItem });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 12;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbon.Size = new System.Drawing.Size(948, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // bBI_DeletePriceList
            // 
            bBI_DeletePriceList.Caption = "Qiymət Siyahısını Sil";
            bBI_DeletePriceList.Id = 1;
            bBI_DeletePriceList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_DeletePriceList.ImageOptions.SvgImage");
            bBI_DeletePriceList.Name = "bBI_DeletePriceList";
            bBI_DeletePriceList.ItemClick += bBI_DeletePriceList_ItemClick;
            // 
            // bBI_SaveAndClose
            // 
            bBI_SaveAndClose.Caption = "Yadda Saxla Bağla";
            bBI_SaveAndClose.Id = 2;
            bBI_SaveAndClose.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_SaveAndClose.ImageOptions.SvgImage");
            bBI_SaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            bBI_SaveAndClose.Name = "bBI_SaveAndClose";
            bBI_SaveAndClose.ItemDoubleClick += bBI_SaveAndClose_ItemClick;
            // 
            // bBI_NewPriceList
            // 
            bBI_NewPriceList.Caption = "Yeni Qiymət Siyahısı";
            bBI_NewPriceList.Id = 5;
            bBI_NewPriceList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_NewPriceList.ImageOptions.SvgImage");
            bBI_NewPriceList.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N);
            bBI_NewPriceList.Name = "bBI_NewPriceList";
            bBI_NewPriceList.ItemClick += bBI_NewPriceList_ItemClick;
            // 
            // BBI_Info
            // 
            BBI_Info.Caption = "İnfo";
            BBI_Info.Id = 10;
            BBI_Info.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Info.ImageOptions.SvgImage");
            BBI_Info.Name = "BBI_Info";
            // 
            // BBI_ImportExcel
            // 
            BBI_ImportExcel.Caption = "Excel'dən Al";
            BBI_ImportExcel.Id = 11;
            BBI_ImportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ImportExcel.ImageOptions.SvgImage");
            BBI_ImportExcel.Name = "BBI_ImportExcel";
            BBI_ImportExcel.ItemClick += BBI_ImportExcel_ItemClick;
            // 
            // BBI_exportXLSX
            // 
            BBI_exportXLSX.Caption = "Excel'ə Göndər";
            BBI_exportXLSX.Id = 22;
            BBI_exportXLSX.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_exportXLSX.ImageOptions.SvgImage");
            BBI_exportXLSX.Name = "BBI_exportXLSX";
            BBI_exportXLSX.ItemClick += BBI_exportXLSX_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Ödəmə";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_SaveAndClose);
            ribbonPageGroup1.ItemLinks.Add(bBI_NewPriceList);
            ribbonPageGroup1.ItemLinks.Add(bBI_DeletePriceList);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Ödəmə";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            ribbonPageGroup3.ItemLinks.Add(BBI_Info);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Məlumat";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_ImportExcel);
            ribbonPageGroup2.ItemLinks.Add(BBI_exportXLSX);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Excel";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 623);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new System.Drawing.Size(948, 24);
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(gC_PriceListLine);
            dataLayoutControl1.Controls.Add(DocumentDateDateEdit);
            dataLayoutControl1.Controls.Add(DocumentTimeTimeSpanEdit);
            dataLayoutControl1.Controls.Add(DueDateDateEdit);
            dataLayoutControl1.Controls.Add(DueTimeTimeSpanEdit);
            dataLayoutControl1.Controls.Add(DescriptionTextEdit);
            dataLayoutControl1.Controls.Add(IsDisabledCheckEdit);
            dataLayoutControl1.Controls.Add(IsConfirmedCheckEdit);
            dataLayoutControl1.Controls.Add(btnEdit_DocNum);
            dataLayoutControl1.Controls.Add(btnEdit_PriceTypeCode);
            dataLayoutControl1.DataSource = trPriceListHeadersBindingSource;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.Location = new System.Drawing.Point(0, 158);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(947, 331, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(948, 465);
            dataLayoutControl1.TabIndex = 2;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gC_PriceListLine
            // 
            gC_PriceListLine.DataSource = trPriceListLinesBindingSource;
            gC_PriceListLine.Location = new System.Drawing.Point(12, 108);
            gC_PriceListLine.MainView = gV_PriceListLine;
            gC_PriceListLine.MenuManager = ribbon;
            gC_PriceListLine.Name = "gC_PriceListLine";
            gC_PriceListLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoLUE_CurrencyCode, repoCalcEdit_ReceivePriceList, repoCalcEdit_MakePriceList, repoBtnEdit_ProductCode });
            gC_PriceListLine.Size = new System.Drawing.Size(924, 345);
            gC_PriceListLine.TabIndex = 9;
            gC_PriceListLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PriceListLine });
            gC_PriceListLine.KeyDown += gC_PriceListLine_KeyDown;
            // 
            // trPriceListLinesBindingSource
            // 
            trPriceListLinesBindingSource.DataSource = typeof(TrPriceListLine);
            // 
            // gV_PriceListLine
            // 
            gV_PriceListLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colPriceListLineId, colPriceListHeaderId, colProductCode, colPrice, colCurrencyCode, colLineDescription, colProductDesc, colLastPurchasePrice });
            gV_PriceListLine.CustomizationFormBounds = new System.Drawing.Rectangle(760, 390, 264, 272);
            gV_PriceListLine.GridControl = gC_PriceListLine;
            gV_PriceListLine.Name = "gV_PriceListLine";
            gV_PriceListLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_PriceListLine.OptionsNavigation.AutoFocusNewRow = true;
            gV_PriceListLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gV_PriceListLine.OptionsView.ShowGroupPanel = false;
            gV_PriceListLine.RowCellStyle += gV_PriceListLine_RowCellStyle;
            gV_PriceListLine.InitNewRow += gV_PriceListLine_InitNewRow;
            gV_PriceListLine.RowDeleted += gV_PriceListLine_RowDeleted;
            gV_PriceListLine.RowUpdated += gV_PriceListLine_RowUpdated;
            gV_PriceListLine.CustomUnboundColumnData += gV_PriceListLine_CustomUnboundColumnData;
            // 
            // colPriceListLineId
            // 
            colPriceListLineId.FieldName = "PriceListLineId";
            colPriceListLineId.Name = "colPriceListLineId";
            colPriceListLineId.OptionsColumn.AllowEdit = false;
            colPriceListLineId.OptionsColumn.ReadOnly = true;
            // 
            // colPriceListHeaderId
            // 
            colPriceListHeaderId.FieldName = "PriceListHeaderId";
            colPriceListHeaderId.Name = "colPriceListHeaderId";
            colPriceListHeaderId.OptionsColumn.AllowEdit = false;
            colPriceListHeaderId.OptionsColumn.ReadOnly = true;
            // 
            // colProductCode
            // 
            colProductCode.ColumnEdit = repoBtnEdit_ProductCode;
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 0;
            colProductCode.Width = 118;
            // 
            // repoBtnEdit_ProductCode
            // 
            repoBtnEdit_ProductCode.AutoHeight = false;
            repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            repoBtnEdit_ProductCode.ButtonPressed += repoBtnEdit_ProductCode_ButtonPressed;
            // 
            // colPrice
            // 
            colPrice.FieldName = "Price";
            colPrice.Name = "colPrice";
            colPrice.Visible = true;
            colPrice.VisibleIndex = 2;
            colPrice.Width = 101;
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.ColumnEdit = repoLUE_CurrencyCode;
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 3;
            colCurrencyCode.Width = 108;
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
            // 
            // colLineDescription
            // 
            colLineDescription.FieldName = "LineDescription";
            colLineDescription.Name = "colLineDescription";
            colLineDescription.Visible = true;
            colLineDescription.VisibleIndex = 4;
            colLineDescription.Width = 242;
            // 
            // colProductDesc
            // 
            colProductDesc.FieldName = "DcProduct.ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.OptionsColumn.AllowEdit = false;
            colProductDesc.OptionsColumn.ReadOnly = true;
            colProductDesc.UnboundDataType = typeof(string);
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 1;
            colProductDesc.Width = 421;
            // 
            // colLastPurchasePrice
            // 
            colLastPurchasePrice.FieldName = "DcProduct.LastPurchasePrice";
            colLastPurchasePrice.Name = "colLastPurchasePrice";
            colLastPurchasePrice.OptionsColumn.AllowEdit = false;
            colLastPurchasePrice.OptionsColumn.ReadOnly = true;
            colLastPurchasePrice.UnboundDataType = typeof(decimal);
            colLastPurchasePrice.Visible = true;
            colLastPurchasePrice.VisibleIndex = 5;
            // 
            // repoCalcEdit_ReceivePriceList
            // 
            repoCalcEdit_ReceivePriceList.AutoHeight = false;
            repoCalcEdit_ReceivePriceList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_ReceivePriceList.Name = "repoCalcEdit_ReceivePriceList";
            // 
            // repoCalcEdit_MakePriceList
            // 
            repoCalcEdit_MakePriceList.AutoHeight = false;
            repoCalcEdit_MakePriceList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoCalcEdit_MakePriceList.Name = "repoCalcEdit_MakePriceList";
            // 
            // DocumentDateDateEdit
            // 
            DocumentDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "DocumentDate", true));
            DocumentDateDateEdit.EditValue = null;
            DocumentDateDateEdit.Location = new System.Drawing.Point(135, 36);
            DocumentDateDateEdit.MenuManager = ribbon;
            DocumentDateDateEdit.Name = "DocumentDateDateEdit";
            DocumentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentDateDateEdit.Size = new System.Drawing.Size(337, 20);
            DocumentDateDateEdit.StyleController = dataLayoutControl1;
            DocumentDateDateEdit.TabIndex = 2;
            // 
            // trPriceListHeadersBindingSource
            // 
            trPriceListHeadersBindingSource.DataSource = typeof(TrPriceListHeader);
            trPriceListHeadersBindingSource.AddingNew += trPriceListHeadersBindingSource_AddingNew;
            trPriceListHeadersBindingSource.CurrentItemChanged += trPriceListHeadersBindingSource_CurrentItemChanged;
            // 
            // DocumentTimeTimeSpanEdit
            // 
            DocumentTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "DocumentTime", true));
            DocumentTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            DocumentTimeTimeSpanEdit.Location = new System.Drawing.Point(135, 60);
            DocumentTimeTimeSpanEdit.MenuManager = ribbon;
            DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
            DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DocumentTimeTimeSpanEdit.Size = new System.Drawing.Size(337, 20);
            DocumentTimeTimeSpanEdit.StyleController = dataLayoutControl1;
            DocumentTimeTimeSpanEdit.TabIndex = 4;
            // 
            // DueDateDateEdit
            // 
            DueDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "DueDate", true));
            DueDateDateEdit.EditValue = null;
            DueDateDateEdit.Location = new System.Drawing.Point(599, 36);
            DueDateDateEdit.MenuManager = ribbon;
            DueDateDateEdit.Name = "DueDateDateEdit";
            DueDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DueDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DueDateDateEdit.Size = new System.Drawing.Size(337, 20);
            DueDateDateEdit.StyleController = dataLayoutControl1;
            DueDateDateEdit.TabIndex = 3;
            // 
            // DueTimeTimeSpanEdit
            // 
            DueTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "DueTime", true));
            DueTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            DueTimeTimeSpanEdit.Location = new System.Drawing.Point(599, 60);
            DueTimeTimeSpanEdit.MenuManager = ribbon;
            DueTimeTimeSpanEdit.Name = "DueTimeTimeSpanEdit";
            DueTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DueTimeTimeSpanEdit.Size = new System.Drawing.Size(337, 20);
            DueTimeTimeSpanEdit.StyleController = dataLayoutControl1;
            DueTimeTimeSpanEdit.TabIndex = 5;
            // 
            // DescriptionTextEdit
            // 
            DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "Description", true));
            DescriptionTextEdit.Location = new System.Drawing.Point(599, 84);
            DescriptionTextEdit.MenuManager = ribbon;
            DescriptionTextEdit.Name = "DescriptionTextEdit";
            DescriptionTextEdit.Size = new System.Drawing.Size(337, 20);
            DescriptionTextEdit.StyleController = dataLayoutControl1;
            DescriptionTextEdit.TabIndex = 8;
            // 
            // IsDisabledCheckEdit
            // 
            IsDisabledCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "IsDisabled", true));
            IsDisabledCheckEdit.Location = new System.Drawing.Point(138, 84);
            IsDisabledCheckEdit.MenuManager = ribbon;
            IsDisabledCheckEdit.Name = "IsDisabledCheckEdit";
            IsDisabledCheckEdit.Properties.Caption = "Ləğv Edilib";
            IsDisabledCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            IsDisabledCheckEdit.Size = new System.Drawing.Size(122, 20);
            IsDisabledCheckEdit.StyleController = dataLayoutControl1;
            IsDisabledCheckEdit.TabIndex = 7;
            // 
            // IsConfirmedCheckEdit
            // 
            IsConfirmedCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "IsConfirmed", true));
            IsConfirmedCheckEdit.Location = new System.Drawing.Point(12, 84);
            IsConfirmedCheckEdit.MenuManager = ribbon;
            IsConfirmedCheckEdit.Name = "IsConfirmedCheckEdit";
            IsConfirmedCheckEdit.Properties.Caption = "Təsdiqlənib";
            IsConfirmedCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            IsConfirmedCheckEdit.Size = new System.Drawing.Size(122, 20);
            IsConfirmedCheckEdit.StyleController = dataLayoutControl1;
            IsConfirmedCheckEdit.TabIndex = 6;
            // 
            // btnEdit_DocNum
            // 
            btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "DocumentNumber", true));
            btnEdit_DocNum.Location = new System.Drawing.Point(135, 12);
            btnEdit_DocNum.MenuManager = ribbon;
            btnEdit_DocNum.Name = "btnEdit_DocNum";
            btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_DocNum.Size = new System.Drawing.Size(337, 20);
            btnEdit_DocNum.StyleController = dataLayoutControl1;
            btnEdit_DocNum.TabIndex = 0;
            btnEdit_DocNum.ButtonPressed += btnEdit_DocNum_ButtonPressed;
            // 
            // btnEdit_PriceTypeCode
            // 
            btnEdit_PriceTypeCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", trPriceListHeadersBindingSource, "PriceTypeCode", true));
            btnEdit_PriceTypeCode.Location = new System.Drawing.Point(599, 12);
            btnEdit_PriceTypeCode.MenuManager = ribbon;
            btnEdit_PriceTypeCode.Name = "btnEdit_PriceTypeCode";
            btnEdit_PriceTypeCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            btnEdit_PriceTypeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_PriceTypeCode.Size = new System.Drawing.Size(337, 20);
            btnEdit_PriceTypeCode.StyleController = dataLayoutControl1;
            btnEdit_PriceTypeCode.TabIndex = 10;
            btnEdit_PriceTypeCode.ButtonPressed += btnEdit_PriceTypeCode_ButtonPressed;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(948, 465);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, ItemForDocumentDate, ItemForDocumentTime, ItemForDueDate, ItemForDueTime, ItemForDescription, ItemForIsConfirmed, ItemForIsDisabled, emptySpaceItem1, layoutControlItem2, layoutControlItem3 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(928, 445);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gC_PriceListLine;
            layoutControlItem1.Location = new System.Drawing.Point(0, 96);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(928, 349);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // ItemForDocumentDate
            // 
            ItemForDocumentDate.Control = DocumentDateDateEdit;
            ItemForDocumentDate.Location = new System.Drawing.Point(0, 24);
            ItemForDocumentDate.Name = "ItemForDocumentDate";
            ItemForDocumentDate.Size = new System.Drawing.Size(464, 24);
            ItemForDocumentDate.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDocumentTime
            // 
            ItemForDocumentTime.Control = DocumentTimeTimeSpanEdit;
            ItemForDocumentTime.Location = new System.Drawing.Point(0, 48);
            ItemForDocumentTime.Name = "ItemForDocumentTime";
            ItemForDocumentTime.Size = new System.Drawing.Size(464, 24);
            ItemForDocumentTime.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDueDate
            // 
            ItemForDueDate.Control = DueDateDateEdit;
            ItemForDueDate.Location = new System.Drawing.Point(464, 24);
            ItemForDueDate.Name = "ItemForDueDate";
            ItemForDueDate.Size = new System.Drawing.Size(464, 24);
            ItemForDueDate.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDueTime
            // 
            ItemForDueTime.Control = DueTimeTimeSpanEdit;
            ItemForDueTime.Location = new System.Drawing.Point(464, 48);
            ItemForDueTime.Name = "ItemForDueTime";
            ItemForDueTime.Size = new System.Drawing.Size(464, 24);
            ItemForDueTime.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForDescription
            // 
            ItemForDescription.Control = DescriptionTextEdit;
            ItemForDescription.Location = new System.Drawing.Point(464, 72);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new System.Drawing.Size(464, 24);
            ItemForDescription.TextSize = new System.Drawing.Size(111, 13);
            // 
            // ItemForIsConfirmed
            // 
            ItemForIsConfirmed.Control = IsConfirmedCheckEdit;
            ItemForIsConfirmed.Location = new System.Drawing.Point(0, 72);
            ItemForIsConfirmed.Name = "ItemForIsConfirmed";
            ItemForIsConfirmed.Size = new System.Drawing.Size(126, 24);
            ItemForIsConfirmed.TextSize = new System.Drawing.Size(0, 0);
            ItemForIsConfirmed.TextVisible = false;
            // 
            // ItemForIsDisabled
            // 
            ItemForIsDisabled.Control = IsDisabledCheckEdit;
            ItemForIsDisabled.Location = new System.Drawing.Point(126, 72);
            ItemForIsDisabled.Name = "ItemForIsDisabled";
            ItemForIsDisabled.Size = new System.Drawing.Size(126, 24);
            ItemForIsDisabled.TextSize = new System.Drawing.Size(0, 0);
            ItemForIsDisabled.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(252, 72);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(212, 24);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnEdit_DocNum;
            layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            layoutControlItem2.Name = "Faktura Nömrəsi";
            layoutControlItem2.Size = new System.Drawing.Size(464, 24);
            layoutControlItem2.TextSize = new System.Drawing.Size(111, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnEdit_PriceTypeCode;
            layoutControlItem3.Location = new System.Drawing.Point(464, 0);
            layoutControlItem3.Name = "Qiymət Siyahı Tipi Kodu";
            layoutControlItem3.Size = new System.Drawing.Size(464, 24);
            layoutControlItem3.TextSize = new System.Drawing.Size(111, 13);
            // 
            // FormPriceListDetail
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(948, 647);
            Controls.Add(dataLayoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormPriceListDetail";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "Qiymət Siyahısı";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_PriceListLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPriceListLinesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_PriceListLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_CurrencyCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_ReceivePriceList).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCalcEdit_MakePriceList).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPriceListHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocumentTimeTimeSpanEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DueDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DueDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DueTimeTimeSpanEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DescriptionTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsDisabledCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsConfirmedCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_PriceTypeCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDueDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDueTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsConfirmed).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
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