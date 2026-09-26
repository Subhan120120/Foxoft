using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Foxoft
{
    partial class UcReturn
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UcReturn));

            lC_Root = new LayoutControl();
            lCG_Root = new LayoutControlGroup();

            // Header Group & Controls
            lCG_InvoiceHeader = new LayoutControlGroup();
            btnEdit_InvoiceHeader = new ButtonEdit();
            lCI_InvoiceHeader = new LayoutControlItem();
            txt_CurrAccDesc = new TextEdit();
            lCI_CurrAccDesc = new LayoutControlItem();
            txt_DocDate = new TextEdit();
            lCI_DocDate = new LayoutControlItem();
            txt_TotalAmount = new TextEdit();
            lCI_TotalAmount = new LayoutControlItem();
            txt_BarcodeSearch = new ButtonEdit();
            lCI_BarcodeSearch = new LayoutControlItem();
            btn_ReturnAll = new SimpleButton();
            lCI_ReturnAll = new LayoutControlItem();
            btn_Clear = new SimpleButton();
            lCI_Clear = new LayoutControlItem();

            // Original Lines Group & Grid
            lCG_InvoiceLine = new LayoutControlGroup();
            gC_InvoiceLine = new MyGridControl();
            gV_InvoiceLine = new MyGridView();
            col_ProductCode = new GridColumn();
            col_Barcode = new GridColumn();
            col_ProductDesc = new GridColumn();
            col_Qty = new GridColumn();
            col_ReturnQty = new GridColumn();
            col_RemainingQty = new GridColumn();
            col_Price = new GridColumn();
            col_PosDiscount = new GridColumn();
            col_NetAmount = new GridColumn();
            col_ActionAdd = new GridColumn();
            repoBtn_AddReturn = new RepositoryItemButtonEdit();
            lCI_InvoiceLine = new LayoutControlItem();

            // Splitter
            splitterMain = new SplitterItem();

            // Right Group
            lCG_RightPanel = new LayoutControlGroup();

            // Return Cart Group & Grid
            lCG_ReturnCart = new LayoutControlGroup();
            gC_ReturnInvoiceLine = new MyGridControl();
            gV_ReturnInvoiceLine = new MyGridView();
            col_RProductCode = new GridColumn();
            col_RProductDesc = new GridColumn();
            col_RQty = new GridColumn();
            repoSpin_ReturnQty = new RepositoryItemSpinEdit();
            col_RPrice = new GridColumn();
            col_RPosDiscount = new GridColumn();
            col_RNetAmount = new GridColumn();
            col_RRemove = new GridColumn();
            repoBtn_RemoveReturn = new RepositoryItemButtonEdit();
            lCI_ReturnInvoiceLine = new LayoutControlItem();

            // Right Splitter
            splitterRight = new SplitterItem();

            // Payments Group & Grid
            lCG_Payment = new LayoutControlGroup();
            gC_PaymentLine = new MyGridControl();
            gV_PaymentLine = new MyGridView();
            col_PaymentTypeDesc = new GridColumn();
            col_PaymentMethodDesc = new GridColumn();
            col_CashRegisterDesc = new GridColumn();
            col_Payment = new GridColumn();
            lCI_Payment = new LayoutControlItem();

            // Actions Group & Buttons
            lCG_Actions = new LayoutControlGroup();
            btn_Ok = new SimpleButton();
            lCI_Ok = new LayoutControlItem();
            btn_Cancel = new SimpleButton();
            lCI_Cancel = new LayoutControlItem();

            ((ISupportInitialize)lC_Root).BeginInit();
            lC_Root.SuspendLayout();
            ((ISupportInitialize)lCG_Root).BeginInit();
            ((ISupportInitialize)lCG_InvoiceHeader).BeginInit();
            ((ISupportInitialize)btnEdit_InvoiceHeader.Properties).BeginInit();
            ((ISupportInitialize)lCI_InvoiceHeader).BeginInit();
            ((ISupportInitialize)txt_CurrAccDesc.Properties).BeginInit();
            ((ISupportInitialize)lCI_CurrAccDesc).BeginInit();
            ((ISupportInitialize)txt_DocDate.Properties).BeginInit();
            ((ISupportInitialize)lCI_DocDate).BeginInit();
            ((ISupportInitialize)txt_TotalAmount.Properties).BeginInit();
            ((ISupportInitialize)lCI_TotalAmount).BeginInit();
            ((ISupportInitialize)txt_BarcodeSearch.Properties).BeginInit();
            ((ISupportInitialize)lCI_BarcodeSearch).BeginInit();
            ((ISupportInitialize)lCI_ReturnAll).BeginInit();
            ((ISupportInitialize)lCI_Clear).BeginInit();
            ((ISupportInitialize)lCG_InvoiceLine).BeginInit();
            ((ISupportInitialize)gC_InvoiceLine).BeginInit();
            ((ISupportInitialize)gV_InvoiceLine).BeginInit();
            ((ISupportInitialize)repoBtn_AddReturn).BeginInit();
            ((ISupportInitialize)lCI_InvoiceLine).BeginInit();
            ((ISupportInitialize)splitterMain).BeginInit();
            ((ISupportInitialize)lCG_RightPanel).BeginInit();
            ((ISupportInitialize)lCG_ReturnCart).BeginInit();
            ((ISupportInitialize)gC_ReturnInvoiceLine).BeginInit();
            ((ISupportInitialize)gV_ReturnInvoiceLine).BeginInit();
            ((ISupportInitialize)repoSpin_ReturnQty).BeginInit();
            ((ISupportInitialize)repoBtn_RemoveReturn).BeginInit();
            ((ISupportInitialize)lCI_ReturnInvoiceLine).BeginInit();
            ((ISupportInitialize)splitterRight).BeginInit();
            ((ISupportInitialize)lCG_Payment).BeginInit();
            ((ISupportInitialize)gC_PaymentLine).BeginInit();
            ((ISupportInitialize)gV_PaymentLine).BeginInit();
            ((ISupportInitialize)lCI_Payment).BeginInit();
            ((ISupportInitialize)lCG_Actions).BeginInit();
            ((ISupportInitialize)lCI_Ok).BeginInit();
            ((ISupportInitialize)lCI_Cancel).BeginInit();
            SuspendLayout();

            // 
            // lC_Root
            // 
            lC_Root.Controls.Add(btnEdit_InvoiceHeader);
            lC_Root.Controls.Add(txt_CurrAccDesc);
            lC_Root.Controls.Add(txt_DocDate);
            lC_Root.Controls.Add(txt_TotalAmount);
            lC_Root.Controls.Add(txt_BarcodeSearch);
            lC_Root.Controls.Add(btn_ReturnAll);
            lC_Root.Controls.Add(btn_Clear);
            lC_Root.Controls.Add(gC_InvoiceLine);
            lC_Root.Controls.Add(gC_ReturnInvoiceLine);
            lC_Root.Controls.Add(gC_PaymentLine);
            lC_Root.Controls.Add(btn_Ok);
            lC_Root.Controls.Add(btn_Cancel);
            lC_Root.Dock = DockStyle.Fill;
            lC_Root.Location = new Point(0, 0);
            lC_Root.Name = "lC_Root";
            lC_Root.Root = lCG_Root;
            lC_Root.Size = new Size(1200, 780);
            lC_Root.TabIndex = 0;

            // 
            // lCG_Root
            // 
            lCG_Root.EnableIndentsWithoutBorders = DefaultBoolean.True;
            lCG_Root.GroupBordersVisible = false;
            lCG_Root.Items.AddRange(new BaseLayoutItem[] {
                lCG_InvoiceHeader,
                lCG_InvoiceLine,
                splitterMain,
                lCG_RightPanel
            });
            lCG_Root.Name = "lCG_Root";
            lCG_Root.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            lCG_Root.Size = new Size(1200, 780);
            lCG_Root.TextVisible = false;

            // 
            // lCG_InvoiceHeader
            // 
            lCG_InvoiceHeader.AppearanceGroup.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lCG_InvoiceHeader.AppearanceGroup.Options.UseFont = true;
            lCG_InvoiceHeader.CaptionImageOptions.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            lCG_InvoiceHeader.Items.AddRange(new BaseLayoutItem[] {
                lCI_InvoiceHeader,
                lCI_CurrAccDesc,
                lCI_DocDate,
                lCI_TotalAmount,
                lCI_BarcodeSearch,
                lCI_ReturnAll,
                lCI_Clear
            });
            lCG_InvoiceHeader.Location = new Point(0, 0);
            lCG_InvoiceHeader.Name = "lCG_InvoiceHeader";
            lCG_InvoiceHeader.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            lCG_InvoiceHeader.Size = new Size(1188, 110);
            lCG_InvoiceHeader.Text = Resources.Form_Return_Group_InvoiceHeader;

            // 
            // btnEdit_InvoiceHeader
            // 
            btnEdit_InvoiceHeader.Location = new Point(90, 36);
            btnEdit_InvoiceHeader.Name = "btnEdit_InvoiceHeader";
            btnEdit_InvoiceHeader.Properties.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit_InvoiceHeader.Properties.Appearance.Options.UseFont = true;
            btnEdit_InvoiceHeader.Properties.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Search),
                new EditorButton(ButtonPredefines.Clear)
            });
            btnEdit_InvoiceHeader.Size = new Size(240, 26);
            btnEdit_InvoiceHeader.StyleController = lC_Root;
            btnEdit_InvoiceHeader.TabIndex = 1;
            btnEdit_InvoiceHeader.ButtonClick += btnEdit_InvoiceHeader_ButtonClick;
            btnEdit_InvoiceHeader.KeyDown += btnEdit_InvoiceHeader_KeyDown;

            // 
            // lCI_InvoiceHeader
            // 
            lCI_InvoiceHeader.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            lCI_InvoiceHeader.AppearanceItemCaption.Options.UseFont = true;
            lCI_InvoiceHeader.Control = btnEdit_InvoiceHeader;
            lCI_InvoiceHeader.Location = new Point(0, 0);
            lCI_InvoiceHeader.Name = "lCI_InvoiceHeader";
            lCI_InvoiceHeader.Size = new Size(326, 32);
            lCI_InvoiceHeader.Text = Resources.Form_Return_Label_InvoiceHeader;
            lCI_InvoiceHeader.TextSize = new Size(78, 15);

            // 
            // txt_CurrAccDesc
            // 
            txt_CurrAccDesc.Location = new Point(420, 36);
            txt_CurrAccDesc.Name = "txt_CurrAccDesc";
            txt_CurrAccDesc.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txt_CurrAccDesc.Properties.Appearance.Options.UseFont = true;
            txt_CurrAccDesc.Properties.ReadOnly = true;
            txt_CurrAccDesc.Size = new Size(280, 26);
            txt_CurrAccDesc.StyleController = lC_Root;
            txt_CurrAccDesc.TabIndex = 2;

            // 
            // lCI_CurrAccDesc
            // 
            lCI_CurrAccDesc.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            lCI_CurrAccDesc.AppearanceItemCaption.Options.UseFont = true;
            lCI_CurrAccDesc.Control = txt_CurrAccDesc;
            lCI_CurrAccDesc.Location = new Point(326, 0);
            lCI_CurrAccDesc.Name = "lCI_CurrAccDesc";
            lCI_CurrAccDesc.Size = new Size(370, 32);
            lCI_CurrAccDesc.Text = Resources.Form_Return_Label_CurrAcc;
            lCI_CurrAccDesc.TextSize = new Size(82, 15);

            // 
            // txt_DocDate
            // 
            txt_DocDate.Location = new Point(782, 36);
            txt_DocDate.Name = "txt_DocDate";
            txt_DocDate.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txt_DocDate.Properties.Appearance.Options.UseFont = true;
            txt_DocDate.Properties.ReadOnly = true;
            txt_DocDate.Size = new Size(130, 26);
            txt_DocDate.StyleController = lC_Root;
            txt_DocDate.TabIndex = 3;

            // 
            // lCI_DocDate
            // 
            lCI_DocDate.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            lCI_DocDate.AppearanceItemCaption.Options.UseFont = true;
            lCI_DocDate.Control = txt_DocDate;
            lCI_DocDate.Location = new Point(696, 0);
            lCI_DocDate.Name = "lCI_DocDate";
            lCI_DocDate.Size = new Size(212, 32);
            lCI_DocDate.Text = Resources.Form_Return_Label_DocDate;
            lCI_DocDate.TextSize = new Size(74, 15);

            // 
            // txt_TotalAmount
            // 
            txt_TotalAmount.Location = new Point(998, 36);
            txt_TotalAmount.Name = "txt_TotalAmount";
            txt_TotalAmount.Properties.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txt_TotalAmount.Properties.Appearance.ForeColor = Color.DarkSlateBlue;
            txt_TotalAmount.Properties.Appearance.Options.UseFont = true;
            txt_TotalAmount.Properties.Appearance.Options.UseForeColor = true;
            txt_TotalAmount.Properties.Appearance.Options.UseTextOptions = true;
            txt_TotalAmount.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            txt_TotalAmount.Properties.ReadOnly = true;
            txt_TotalAmount.Size = new Size(176, 26);
            txt_TotalAmount.StyleController = lC_Root;
            txt_TotalAmount.TabIndex = 4;

            // 
            // lCI_TotalAmount
            // 
            lCI_TotalAmount.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            lCI_TotalAmount.AppearanceItemCaption.Options.UseFont = true;
            lCI_TotalAmount.Control = txt_TotalAmount;
            lCI_TotalAmount.Location = new Point(908, 0);
            lCI_TotalAmount.Name = "lCI_TotalAmount";
            lCI_TotalAmount.Size = new Size(266, 32);
            lCI_TotalAmount.Text = Resources.Form_Return_Label_TotalAmount;
            lCI_TotalAmount.TextSize = new Size(82, 15);

            // 
            // txt_BarcodeSearch
            // 
            txt_BarcodeSearch.Location = new Point(90, 68);
            txt_BarcodeSearch.Name = "txt_BarcodeSearch";
            txt_BarcodeSearch.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txt_BarcodeSearch.Properties.Appearance.Options.UseFont = true;
            txt_BarcodeSearch.Properties.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Search)
            });
            txt_BarcodeSearch.Size = new Size(610, 26);
            txt_BarcodeSearch.StyleController = lC_Root;
            txt_BarcodeSearch.TabIndex = 5;
            txt_BarcodeSearch.ButtonClick += txt_BarcodeSearch_ButtonClick;
            txt_BarcodeSearch.KeyDown += txt_BarcodeSearch_KeyDown;

            // 
            // lCI_BarcodeSearch
            // 
            lCI_BarcodeSearch.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            lCI_BarcodeSearch.AppearanceItemCaption.Options.UseFont = true;
            lCI_BarcodeSearch.Control = txt_BarcodeSearch;
            lCI_BarcodeSearch.Location = new Point(0, 32);
            lCI_BarcodeSearch.Name = "lCI_BarcodeSearch";
            lCI_BarcodeSearch.Size = new Size(696, 36);
            lCI_BarcodeSearch.Text = Resources.Form_Return_Label_SearchBarcode;
            lCI_BarcodeSearch.TextSize = new Size(78, 15);

            // 
            // btn_ReturnAll
            // 
            btn_ReturnAll.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_ReturnAll.Appearance.Options.UseFont = true;
            btn_ReturnAll.Location = new Point(712, 68);
            btn_ReturnAll.Name = "btn_ReturnAll";
            btn_ReturnAll.Size = new Size(240, 28);
            btn_ReturnAll.StyleController = lC_Root;
            btn_ReturnAll.TabIndex = 6;
            btn_ReturnAll.Text = Resources.Form_Return_Button_ReturnAll;
            btn_ReturnAll.Click += btn_ReturnAll_Click;

            // 
            // lCI_ReturnAll
            // 
            lCI_ReturnAll.Control = btn_ReturnAll;
            lCI_ReturnAll.Location = new Point(696, 32);
            lCI_ReturnAll.Name = "lCI_ReturnAll";
            lCI_ReturnAll.Size = new Size(246, 36);
            lCI_ReturnAll.TextVisible = false;

            // 
            // btn_Clear
            // 
            btn_Clear.Appearance.Font = new Font("Segoe UI", 9F);
            btn_Clear.Appearance.Options.UseFont = true;
            btn_Clear.Location = new Point(958, 68);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(216, 28);
            btn_Clear.StyleController = lC_Root;
            btn_Clear.TabIndex = 7;
            btn_Clear.Text = Resources.Form_Return_Button_Clear;
            btn_Clear.Click += btn_Clear_Click;

            // 
            // lCI_Clear
            // 
            lCI_Clear.Control = btn_Clear;
            lCI_Clear.Location = new Point(942, 32);
            lCI_Clear.Name = "lCI_Clear";
            lCI_Clear.Size = new Size(232, 36);
            lCI_Clear.TextVisible = false;

            // 
            // lCG_InvoiceLine
            // 
            lCG_InvoiceLine.AppearanceGroup.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lCG_InvoiceLine.AppearanceGroup.Options.UseFont = true;
            lCG_InvoiceLine.Items.AddRange(new BaseLayoutItem[] { lCI_InvoiceLine });
            lCG_InvoiceLine.Location = new Point(0, 110);
            lCG_InvoiceLine.Name = "lCG_InvoiceLine";
            lCG_InvoiceLine.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            lCG_InvoiceLine.Size = new Size(640, 658);
            lCG_InvoiceLine.Text = Resources.Form_Return_Group_InvoiceLine;

            // 
            // gC_InvoiceLine
            // 
            gC_InvoiceLine.Location = new Point(14, 142);
            gC_InvoiceLine.MainView = gV_InvoiceLine;
            gC_InvoiceLine.Name = "gC_InvoiceLine";
            gC_InvoiceLine.RepositoryItems.AddRange(new RepositoryItem[] { repoBtn_AddReturn });
            gC_InvoiceLine.Size = new Size(622, 622);
            gC_InvoiceLine.TabIndex = 8;
            gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceLine });

            // 
            // gV_InvoiceLine
            // 
            gV_InvoiceLine.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gV_InvoiceLine.Appearance.HeaderPanel.Options.UseFont = true;
            gV_InvoiceLine.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            gV_InvoiceLine.Appearance.Row.Options.UseFont = true;
            gV_InvoiceLine.Appearance.FooterPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gV_InvoiceLine.Appearance.FooterPanel.Options.UseFont = true;
            gV_InvoiceLine.Columns.AddRange(new GridColumn[] {
                col_ProductCode,
                col_Barcode,
                col_ProductDesc,
                col_Qty,
                col_ReturnQty,
                col_RemainingQty,
                col_Price,
                col_PosDiscount,
                col_NetAmount,
                col_ActionAdd
            });
            gV_InvoiceLine.GridControl = gC_InvoiceLine;
            gV_InvoiceLine.Name = "gV_InvoiceLine";
            gV_InvoiceLine.OptionsBehavior.Editable = true;
            gV_InvoiceLine.OptionsView.ShowFooter = true;
            gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
            gV_InvoiceLine.OptionsView.ShowIndicator = false;
            gV_InvoiceLine.RowStyle += gV_InvoiceLine_RowStyle;
            gV_InvoiceLine.DoubleClick += gV_InvoiceLine_DoubleClick;
            gV_InvoiceLine.KeyDown += gV_InvoiceLine_KeyDown;

            // 
            // col_ProductCode
            // 
            col_ProductCode.Caption = Resources.Entity_InvoiceLine_ProductCode;
            col_ProductCode.FieldName = "ProductCode";
            col_ProductCode.Name = "col_ProductCode";
            col_ProductCode.OptionsColumn.AllowEdit = false;
            col_ProductCode.Visible = true;
            col_ProductCode.VisibleIndex = 0;
            col_ProductCode.Width = 75;

            // 
            // col_Barcode
            // 
            col_Barcode.Caption = Resources.Entity_InvoiceLine_Barcode;
            col_Barcode.FieldName = "Barcode";
            col_Barcode.Name = "col_Barcode";
            col_Barcode.OptionsColumn.AllowEdit = false;
            col_Barcode.Visible = true;
            col_Barcode.VisibleIndex = 1;
            col_Barcode.Width = 85;

            // 
            // col_ProductDesc
            // 
            col_ProductDesc.Caption = Resources.Entity_Product_Desc;
            col_ProductDesc.FieldName = "ProductDesc";
            col_ProductDesc.Name = "col_ProductDesc";
            col_ProductDesc.OptionsColumn.AllowEdit = false;
            col_ProductDesc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductCode", "{0}")
            });
            col_ProductDesc.Visible = true;
            col_ProductDesc.VisibleIndex = 2;
            col_ProductDesc.Width = 140;

            // 
            // col_Qty
            // 
            col_Qty.AppearanceCell.Options.UseTextOptions = true;
            col_Qty.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_Qty.Caption = Resources.Entity_InvoiceLine_Qty;
            col_Qty.DisplayFormat.FormatString = "{0:0.##}";
            col_Qty.DisplayFormat.FormatType = FormatType.Numeric;
            col_Qty.FieldName = "Qty";
            col_Qty.Name = "col_Qty";
            col_Qty.OptionsColumn.AllowEdit = false;
            col_Qty.Visible = true;
            col_Qty.VisibleIndex = 3;
            col_Qty.Width = 55;

            // 
            // col_ReturnQty
            // 
            col_ReturnQty.AppearanceCell.Options.UseTextOptions = true;
            col_ReturnQty.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_ReturnQty.Caption = Resources.Entity_InvoiceLine_ReturnQty;
            col_ReturnQty.DisplayFormat.FormatString = "{0:0.##}";
            col_ReturnQty.DisplayFormat.FormatType = FormatType.Numeric;
            col_ReturnQty.FieldName = "ReturnQty";
            col_ReturnQty.Name = "col_ReturnQty";
            col_ReturnQty.OptionsColumn.AllowEdit = false;
            col_ReturnQty.Visible = true;
            col_ReturnQty.VisibleIndex = 4;
            col_ReturnQty.Width = 55;

            // 
            // col_RemainingQty
            // 
            col_RemainingQty.AppearanceCell.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            col_RemainingQty.AppearanceCell.ForeColor = Color.DarkGreen;
            col_RemainingQty.AppearanceCell.Options.UseFont = true;
            col_RemainingQty.AppearanceCell.Options.UseForeColor = true;
            col_RemainingQty.AppearanceCell.Options.UseTextOptions = true;
            col_RemainingQty.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_RemainingQty.Caption = Resources.Entity_InvoiceLine_RemainingQty;
            col_RemainingQty.DisplayFormat.FormatString = "{0:0.##}";
            col_RemainingQty.DisplayFormat.FormatType = FormatType.Numeric;
            col_RemainingQty.FieldName = "RemainingQty";
            col_RemainingQty.Name = "col_RemainingQty";
            col_RemainingQty.OptionsColumn.AllowEdit = false;
            col_RemainingQty.Visible = true;
            col_RemainingQty.VisibleIndex = 5;
            col_RemainingQty.Width = 60;

            // 
            // col_Price
            // 
            col_Price.AppearanceCell.Options.UseTextOptions = true;
            col_Price.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_Price.Caption = Resources.Entity_InvoiceLine_Price;
            col_Price.DisplayFormat.FormatString = "{0:N2}";
            col_Price.DisplayFormat.FormatType = FormatType.Numeric;
            col_Price.FieldName = "Price";
            col_Price.Name = "col_Price";
            col_Price.OptionsColumn.AllowEdit = false;
            col_Price.Visible = true;
            col_Price.VisibleIndex = 6;
            col_Price.Width = 65;

            // 
            // col_PosDiscount
            // 
            col_PosDiscount.AppearanceCell.Options.UseTextOptions = true;
            col_PosDiscount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_PosDiscount.Caption = Resources.Entity_InvoiceLine_PosDiscount;
            col_PosDiscount.DisplayFormat.FormatString = "{0:0.##}";
            col_PosDiscount.DisplayFormat.FormatType = FormatType.Numeric;
            col_PosDiscount.FieldName = "PosDiscount";
            col_PosDiscount.Name = "col_PosDiscount";
            col_PosDiscount.OptionsColumn.AllowEdit = false;
            col_PosDiscount.Visible = true;
            col_PosDiscount.VisibleIndex = 7;
            col_PosDiscount.Width = 50;

            // 
            // col_NetAmount
            // 
            col_NetAmount.AppearanceCell.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            col_NetAmount.AppearanceCell.Options.UseFont = true;
            col_NetAmount.AppearanceCell.Options.UseTextOptions = true;
            col_NetAmount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_NetAmount.Caption = Resources.Entity_InvoiceLine_NetAmount;
            col_NetAmount.DisplayFormat.FormatString = "{0:N2}";
            col_NetAmount.DisplayFormat.FormatType = FormatType.Numeric;
            col_NetAmount.FieldName = "NetAmount";
            col_NetAmount.Name = "col_NetAmount";
            col_NetAmount.OptionsColumn.AllowEdit = false;
            col_NetAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmount", "{0:N2}")
            });
            col_NetAmount.Visible = true;
            col_NetAmount.VisibleIndex = 8;
            col_NetAmount.Width = 75;

            // 
            // col_ActionAdd
            // 
            col_ActionAdd.Caption = Resources.Form_Return_Col_Add;
            col_ActionAdd.ColumnEdit = repoBtn_AddReturn;
            col_ActionAdd.MaxWidth = 45;
            col_ActionAdd.MinWidth = 45;
            col_ActionAdd.Name = "col_ActionAdd";
            col_ActionAdd.OptionsColumn.AllowSort = DefaultBoolean.False;
            col_ActionAdd.Visible = true;
            col_ActionAdd.VisibleIndex = 9;
            col_ActionAdd.Width = 45;

            // 
            // repoBtn_AddReturn
            // 
            repoBtn_AddReturn.AutoHeight = false;
            repoBtn_AddReturn.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Plus)
            });
            repoBtn_AddReturn.Name = "repoBtn_AddReturn";
            repoBtn_AddReturn.TextEditStyle = TextEditStyles.HideTextEditor;
            repoBtn_AddReturn.ButtonClick += repoBtn_AddReturn_ButtonClick;

            // 
            // lCI_InvoiceLine
            // 
            lCI_InvoiceLine.Control = gC_InvoiceLine;
            lCI_InvoiceLine.Location = new Point(0, 0);
            lCI_InvoiceLine.Name = "lCI_InvoiceLine";
            lCI_InvoiceLine.Size = new Size(626, 626);
            lCI_InvoiceLine.TextVisible = false;

            // 
            // splitterMain
            // 
            splitterMain.AllowHotTrack = true;
            splitterMain.Location = new Point(640, 110);
            splitterMain.Name = "splitterMain";
            splitterMain.Size = new Size(10, 658);

            // 
            // lCG_RightPanel
            // 
            lCG_RightPanel.GroupBordersVisible = false;
            lCG_RightPanel.Items.AddRange(new BaseLayoutItem[] {
                lCG_ReturnCart,
                splitterRight,
                lCG_Payment,
                lCG_Actions
            });
            lCG_RightPanel.Location = new Point(650, 110);
            lCG_RightPanel.Name = "lCG_RightPanel";
            lCG_RightPanel.Size = new Size(538, 658);
            lCG_RightPanel.TextVisible = false;

            // 
            // lCG_ReturnCart
            // 
            lCG_ReturnCart.AppearanceGroup.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lCG_ReturnCart.AppearanceGroup.Options.UseFont = true;
            lCG_ReturnCart.Items.AddRange(new BaseLayoutItem[] { lCI_ReturnInvoiceLine });
            lCG_ReturnCart.Location = new Point(0, 0);
            lCG_ReturnCart.Name = "lCG_ReturnCart";
            lCG_ReturnCart.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            lCG_ReturnCart.Size = new Size(538, 380);
            lCG_ReturnCart.Text = Resources.Form_Return_Group_ReturnCart;

            // 
            // gC_ReturnInvoiceLine
            // 
            gC_ReturnInvoiceLine.Location = new Point(664, 142);
            gC_ReturnInvoiceLine.MainView = gV_ReturnInvoiceLine;
            gC_ReturnInvoiceLine.Name = "gC_ReturnInvoiceLine";
            gC_ReturnInvoiceLine.RepositoryItems.AddRange(new RepositoryItem[] {
                repoSpin_ReturnQty,
                repoBtn_RemoveReturn
            });
            gC_ReturnInvoiceLine.Size = new Size(520, 344);
            gC_ReturnInvoiceLine.TabIndex = 9;
            gC_ReturnInvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_ReturnInvoiceLine });

            // 
            // gV_ReturnInvoiceLine
            // 
            gV_ReturnInvoiceLine.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gV_ReturnInvoiceLine.Appearance.HeaderPanel.Options.UseFont = true;
            gV_ReturnInvoiceLine.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            gV_ReturnInvoiceLine.Appearance.Row.Options.UseFont = true;
            gV_ReturnInvoiceLine.Appearance.FooterPanel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gV_ReturnInvoiceLine.Appearance.FooterPanel.Options.UseFont = true;
            gV_ReturnInvoiceLine.Columns.AddRange(new GridColumn[] {
                col_RProductCode,
                col_RProductDesc,
                col_RQty,
                col_RPrice,
                col_RPosDiscount,
                col_RNetAmount,
                col_RRemove
            });
            gV_ReturnInvoiceLine.GridControl = gC_ReturnInvoiceLine;
            gV_ReturnInvoiceLine.Name = "gV_ReturnInvoiceLine";
            gV_ReturnInvoiceLine.OptionsBehavior.Editable = true;
            gV_ReturnInvoiceLine.OptionsView.ShowFooter = true;
            gV_ReturnInvoiceLine.OptionsView.ShowGroupPanel = false;
            gV_ReturnInvoiceLine.OptionsView.ShowIndicator = false;
            gV_ReturnInvoiceLine.KeyDown += gV_ReturnInvoiceLine_KeyDown;

            // 
            // col_RProductCode
            // 
            col_RProductCode.Caption = Resources.Entity_InvoiceLine_ProductCode;
            col_RProductCode.FieldName = "ProductCode";
            col_RProductCode.Name = "col_RProductCode";
            col_RProductCode.OptionsColumn.AllowEdit = false;
            col_RProductCode.Visible = true;
            col_RProductCode.VisibleIndex = 0;
            col_RProductCode.Width = 75;

            // 
            // col_RProductDesc
            // 
            col_RProductDesc.Caption = Resources.Entity_Product_Desc;
            col_RProductDesc.FieldName = "ProductDesc";
            col_RProductDesc.Name = "col_RProductDesc";
            col_RProductDesc.OptionsColumn.AllowEdit = false;
            col_RProductDesc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProductCode", "{0}")
            });
            col_RProductDesc.Visible = true;
            col_RProductDesc.VisibleIndex = 1;
            col_RProductDesc.Width = 140;

            // 
            // col_RQty
            // 
            col_RQty.AppearanceCell.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            col_RQty.AppearanceCell.Options.UseFont = true;
            col_RQty.AppearanceCell.Options.UseTextOptions = true;
            col_RQty.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_RQty.Caption = Resources.Form_Return_Col_ReturnQty;
            col_RQty.ColumnEdit = repoSpin_ReturnQty;
            col_RQty.DisplayFormat.FormatString = "{0:0.##}";
            col_RQty.DisplayFormat.FormatType = FormatType.Numeric;
            col_RQty.FieldName = "ReturnQty";
            col_RQty.Name = "col_RQty";
            col_RQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReturnQty", "{0:0.##}")
            });
            col_RQty.Visible = true;
            col_RQty.VisibleIndex = 2;
            col_RQty.Width = 70;

            // 
            // repoSpin_ReturnQty
            // 
            repoSpin_ReturnQty.AutoHeight = false;
            repoSpin_ReturnQty.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Combo)
            });
            repoSpin_ReturnQty.IsFloatValue = false;
            repoSpin_ReturnQty.Mask.EditMask = "N0";
            repoSpin_ReturnQty.MaxValue = new decimal(new int[] { 999999, 0, 0, 0 });
            repoSpin_ReturnQty.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            repoSpin_ReturnQty.Name = "repoSpin_ReturnQty";
            repoSpin_ReturnQty.EditValueChanged += repoSpin_ReturnQty_EditValueChanged;

            // 
            // col_RPrice
            // 
            col_RPrice.AppearanceCell.Options.UseTextOptions = true;
            col_RPrice.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_RPrice.Caption = Resources.Entity_InvoiceLine_Price;
            col_RPrice.DisplayFormat.FormatString = "{0:N2}";
            col_RPrice.DisplayFormat.FormatType = FormatType.Numeric;
            col_RPrice.FieldName = "Price";
            col_RPrice.Name = "col_RPrice";
            col_RPrice.OptionsColumn.AllowEdit = false;
            col_RPrice.Visible = true;
            col_RPrice.VisibleIndex = 3;
            col_RPrice.Width = 65;

            // 
            // col_RPosDiscount
            // 
            col_RPosDiscount.AppearanceCell.Options.UseTextOptions = true;
            col_RPosDiscount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_RPosDiscount.Caption = Resources.Entity_InvoiceLine_PosDiscount;
            col_RPosDiscount.DisplayFormat.FormatString = "{0:0.##}";
            col_RPosDiscount.DisplayFormat.FormatType = FormatType.Numeric;
            col_RPosDiscount.FieldName = "PosDiscount";
            col_RPosDiscount.Name = "col_RPosDiscount";
            col_RPosDiscount.OptionsColumn.AllowEdit = false;
            col_RPosDiscount.Visible = true;
            col_RPosDiscount.VisibleIndex = 4;
            col_RPosDiscount.Width = 50;

            // 
            // col_RNetAmount
            // 
            col_RNetAmount.AppearanceCell.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            col_RNetAmount.AppearanceCell.ForeColor = Color.DarkRed;
            col_RNetAmount.AppearanceCell.Options.UseFont = true;
            col_RNetAmount.AppearanceCell.Options.UseForeColor = true;
            col_RNetAmount.AppearanceCell.Options.UseTextOptions = true;
            col_RNetAmount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_RNetAmount.Caption = Resources.Entity_InvoiceLine_NetAmount;
            col_RNetAmount.DisplayFormat.FormatString = "{0:N2}";
            col_RNetAmount.DisplayFormat.FormatType = FormatType.Numeric;
            col_RNetAmount.FieldName = "NetAmount";
            col_RNetAmount.Name = "col_RNetAmount";
            col_RNetAmount.OptionsColumn.AllowEdit = false;
            col_RNetAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmount", "{0:N2} AZN")
            });
            col_RNetAmount.Visible = true;
            col_RNetAmount.VisibleIndex = 5;
            col_RNetAmount.Width = 85;

            // 
            // col_RRemove
            // 
            col_RRemove.Caption = Resources.Form_Return_Col_Remove;
            col_RRemove.ColumnEdit = repoBtn_RemoveReturn;
            col_RRemove.MaxWidth = 45;
            col_RRemove.MinWidth = 45;
            col_RRemove.Name = "col_RRemove";
            col_RRemove.OptionsColumn.AllowSort = DefaultBoolean.False;
            col_RRemove.Visible = true;
            col_RRemove.VisibleIndex = 6;
            col_RRemove.Width = 45;

            // 
            // repoBtn_RemoveReturn
            // 
            repoBtn_RemoveReturn.AutoHeight = false;
            repoBtn_RemoveReturn.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Delete)
            });
            repoBtn_RemoveReturn.Name = "repoBtn_RemoveReturn";
            repoBtn_RemoveReturn.TextEditStyle = TextEditStyles.HideTextEditor;
            repoBtn_RemoveReturn.ButtonClick += repoBtn_RemoveReturn_ButtonClick;

            // 
            // lCI_ReturnInvoiceLine
            // 
            lCI_ReturnInvoiceLine.Control = gC_ReturnInvoiceLine;
            lCI_ReturnInvoiceLine.Location = new Point(0, 0);
            lCI_ReturnInvoiceLine.Name = "lCI_ReturnInvoiceLine";
            lCI_ReturnInvoiceLine.Size = new Size(524, 348);
            lCI_ReturnInvoiceLine.TextVisible = false;

            // 
            // splitterRight
            // 
            splitterRight.AllowHotTrack = true;
            splitterRight.Location = new Point(0, 380);
            splitterRight.Name = "splitterRight";
            splitterRight.Size = new Size(538, 10);

            // 
            // lCG_Payment
            // 
            lCG_Payment.AppearanceGroup.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lCG_Payment.AppearanceGroup.Options.UseFont = true;
            lCG_Payment.Items.AddRange(new BaseLayoutItem[] { lCI_Payment });
            lCG_Payment.Location = new Point(0, 390);
            lCG_Payment.Name = "lCG_Payment";
            lCG_Payment.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            lCG_Payment.Size = new Size(538, 188);
            lCG_Payment.Text = Resources.Form_Return_Group_Payment;

            // 
            // gC_PaymentLine
            // 
            gC_PaymentLine.Location = new Point(664, 522);
            gC_PaymentLine.MainView = gV_PaymentLine;
            gC_PaymentLine.Name = "gC_PaymentLine";
            gC_PaymentLine.Size = new Size(520, 152);
            gC_PaymentLine.TabIndex = 10;
            gC_PaymentLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_PaymentLine });

            // 
            // gV_PaymentLine
            // 
            gV_PaymentLine.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gV_PaymentLine.Appearance.HeaderPanel.Options.UseFont = true;
            gV_PaymentLine.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            gV_PaymentLine.Appearance.Row.Options.UseFont = true;
            gV_PaymentLine.Appearance.FooterPanel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            gV_PaymentLine.Appearance.FooterPanel.Options.UseFont = true;
            gV_PaymentLine.Columns.AddRange(new GridColumn[] {
                col_PaymentTypeDesc,
                col_PaymentMethodDesc,
                col_CashRegisterDesc,
                col_Payment
            });
            gV_PaymentLine.GridControl = gC_PaymentLine;
            gV_PaymentLine.Name = "gV_PaymentLine";
            gV_PaymentLine.OptionsBehavior.Editable = false;
            gV_PaymentLine.OptionsView.ShowFooter = true;
            gV_PaymentLine.OptionsView.ShowGroupPanel = false;
            gV_PaymentLine.OptionsView.ShowIndicator = false;
            gV_PaymentLine.CustomColumnDisplayText += gV_PaymentLine_CustomColumnDisplayText;

            // 
            // col_PaymentTypeDesc
            // 
            col_PaymentTypeDesc.Caption = Resources.Form_Return_Col_Payment_Type;
            col_PaymentTypeDesc.FieldName = "DcPaymentType.PaymentTypeDesc";
            col_PaymentTypeDesc.Name = "col_PaymentTypeDesc";
            col_PaymentTypeDesc.Visible = true;
            col_PaymentTypeDesc.VisibleIndex = 0;
            col_PaymentTypeDesc.Width = 100;

            // 
            // col_PaymentMethodDesc
            // 
            col_PaymentMethodDesc.Caption = Resources.Entity_PaymentLine_PaymentMethodId;
            col_PaymentMethodDesc.FieldName = "DcPaymentMethod.PaymentMethodDesc";
            col_PaymentMethodDesc.Name = "col_PaymentMethodDesc";
            col_PaymentMethodDesc.Visible = true;
            col_PaymentMethodDesc.VisibleIndex = 1;
            col_PaymentMethodDesc.Width = 120;

            // 
            // col_CashRegisterDesc
            // 
            col_CashRegisterDesc.Caption = Resources.Entity_PaymentLine_CashRegisterCode;
            col_CashRegisterDesc.FieldName = "DcCashRegister.CurrAccDesc";
            col_CashRegisterDesc.Name = "col_CashRegisterDesc";
            col_CashRegisterDesc.Visible = true;
            col_CashRegisterDesc.VisibleIndex = 2;
            col_CashRegisterDesc.Width = 130;

            // 
            // col_Payment
            // 
            col_Payment.AppearanceCell.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            col_Payment.AppearanceCell.Options.UseFont = true;
            col_Payment.AppearanceCell.Options.UseTextOptions = true;
            col_Payment.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            col_Payment.Caption = Resources.Entity_InvoiceLine_Amount;
            col_Payment.DisplayFormat.FormatString = "{0:N2}";
            col_Payment.DisplayFormat.FormatType = FormatType.Numeric;
            col_Payment.FieldName = "Payment";
            col_Payment.Name = "col_Payment";
            col_Payment.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Payment", "{0:N2}")
            });
            col_Payment.Visible = true;
            col_Payment.VisibleIndex = 3;
            col_Payment.Width = 100;

            // 
            // lCI_Payment
            // 
            lCI_Payment.Control = gC_PaymentLine;
            lCI_Payment.Location = new Point(0, 0);
            lCI_Payment.Name = "lCI_Payment";
            lCI_Payment.Size = new Size(524, 156);
            lCI_Payment.TextVisible = false;

            // 
            // lCG_Actions
            // 
            lCG_Actions.GroupBordersVisible = false;
            lCG_Actions.Items.AddRange(new BaseLayoutItem[] {
                lCI_Ok,
                lCI_Cancel
            });
            lCG_Actions.Location = new Point(0, 578);
            lCG_Actions.Name = "lCG_Actions";
            lCG_Actions.Size = new Size(538, 80);
            lCG_Actions.TextVisible = false;

            // 
            // btn_Ok
            // 
            btn_Ok.Appearance.BackColor = Color.FromArgb(46, 139, 87);
            btn_Ok.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Ok.Appearance.ForeColor = Color.White;
            btn_Ok.Appearance.Options.UseBackColor = true;
            btn_Ok.Appearance.Options.UseFont = true;
            btn_Ok.Appearance.Options.UseForeColor = true;
            btn_Ok.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            btn_Ok.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Ok.ImageOptions.SvgImage");
            btn_Ok.ImageOptions.SvgImageSize = new Size(24, 24);
            btn_Ok.Location = new Point(656, 688);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(330, 68);
            btn_Ok.StyleController = lC_Root;
            btn_Ok.TabIndex = 11;
            btn_Ok.Text = Resources.Form_Return_Button_Confirm;
            btn_Ok.Click += btn_Ok_Click;

            // 
            // lCI_Ok
            // 
            lCI_Ok.Control = btn_Ok;
            lCI_Ok.Location = new Point(0, 0);
            lCI_Ok.MinSize = new Size(120, 60);
            lCI_Ok.Name = "lCI_Ok";
            lCI_Ok.Size = new Size(334, 80);
            lCI_Ok.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Ok.TextVisible = false;

            // 
            // btn_Cancel
            // 
            btn_Cancel.Appearance.Font = new Font("Segoe UI", 10F);
            btn_Cancel.Appearance.Options.UseFont = true;
            btn_Cancel.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            btn_Cancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Cancel.ImageOptions.SvgImage");
            btn_Cancel.ImageOptions.SvgImageSize = new Size(22, 22);
            btn_Cancel.Location = new Point(990, 688);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(196, 68);
            btn_Cancel.StyleController = lC_Root;
            btn_Cancel.TabIndex = 12;
            btn_Cancel.Text = Resources.Form_Return_Button_Cancel;
            btn_Cancel.Click += btn_Cancel_Click;

            // 
            // lCI_Cancel
            // 
            lCI_Cancel.Control = btn_Cancel;
            lCI_Cancel.Location = new Point(334, 0);
            lCI_Cancel.MinSize = new Size(100, 60);
            lCI_Cancel.Name = "lCI_Cancel";
            lCI_Cancel.Size = new Size(204, 80);
            lCI_Cancel.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Cancel.TextVisible = false;

            // 
            // UcReturn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lC_Root);
            Name = "UcReturn";
            Size = new Size(1200, 780);
            Load += UcReturn_Load;

            ((ISupportInitialize)lC_Root).EndInit();
            lC_Root.ResumeLayout(false);
            ((ISupportInitialize)lCG_Root).EndInit();
            ((ISupportInitialize)lCG_InvoiceHeader).EndInit();
            ((ISupportInitialize)btnEdit_InvoiceHeader.Properties).EndInit();
            ((ISupportInitialize)lCI_InvoiceHeader).EndInit();
            ((ISupportInitialize)txt_CurrAccDesc.Properties).EndInit();
            ((ISupportInitialize)lCI_CurrAccDesc).EndInit();
            ((ISupportInitialize)txt_DocDate.Properties).EndInit();
            ((ISupportInitialize)lCI_DocDate).EndInit();
            ((ISupportInitialize)txt_TotalAmount.Properties).EndInit();
            ((ISupportInitialize)lCI_TotalAmount).EndInit();
            ((ISupportInitialize)txt_BarcodeSearch.Properties).EndInit();
            ((ISupportInitialize)lCI_BarcodeSearch).EndInit();
            ((ISupportInitialize)lCI_ReturnAll).EndInit();
            ((ISupportInitialize)lCI_Clear).EndInit();
            ((ISupportInitialize)lCG_InvoiceLine).EndInit();
            ((ISupportInitialize)gC_InvoiceLine).EndInit();
            ((ISupportInitialize)gV_InvoiceLine).EndInit();
            ((ISupportInitialize)repoBtn_AddReturn).EndInit();
            ((ISupportInitialize)lCI_InvoiceLine).EndInit();
            ((ISupportInitialize)splitterMain).EndInit();
            ((ISupportInitialize)lCG_RightPanel).EndInit();
            ((ISupportInitialize)lCG_ReturnCart).EndInit();
            ((ISupportInitialize)gC_ReturnInvoiceLine).EndInit();
            ((ISupportInitialize)gV_ReturnInvoiceLine).EndInit();
            ((ISupportInitialize)repoSpin_ReturnQty).EndInit();
            ((ISupportInitialize)repoBtn_RemoveReturn).EndInit();
            ((ISupportInitialize)lCI_ReturnInvoiceLine).EndInit();
            ((ISupportInitialize)splitterRight).EndInit();
            ((ISupportInitialize)lCG_Payment).EndInit();
            ((ISupportInitialize)gC_PaymentLine).EndInit();
            ((ISupportInitialize)gV_PaymentLine).EndInit();
            ((ISupportInitialize)lCI_Payment).EndInit();
            ((ISupportInitialize)lCG_Actions).EndInit();
            ((ISupportInitialize)lCI_Ok).EndInit();
            ((ISupportInitialize)lCI_Cancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LayoutControl lC_Root;
        private LayoutControlGroup lCG_Root;

        private LayoutControlGroup lCG_InvoiceHeader;
        private ButtonEdit btnEdit_InvoiceHeader;
        private LayoutControlItem lCI_InvoiceHeader;
        private TextEdit txt_CurrAccDesc;
        private LayoutControlItem lCI_CurrAccDesc;
        private TextEdit txt_DocDate;
        private LayoutControlItem lCI_DocDate;
        private TextEdit txt_TotalAmount;
        private LayoutControlItem lCI_TotalAmount;
        private ButtonEdit txt_BarcodeSearch;
        private LayoutControlItem lCI_BarcodeSearch;
        private SimpleButton btn_ReturnAll;
        private LayoutControlItem lCI_ReturnAll;
        private SimpleButton btn_Clear;
        private LayoutControlItem lCI_Clear;

        private LayoutControlGroup lCG_InvoiceLine;
        private MyGridControl gC_InvoiceLine;
        private MyGridView gV_InvoiceLine;
        private GridColumn col_ProductCode;
        private GridColumn col_Barcode;
        private GridColumn col_ProductDesc;
        private GridColumn col_Qty;
        private GridColumn col_ReturnQty;
        private GridColumn col_RemainingQty;
        private GridColumn col_Price;
        private GridColumn col_PosDiscount;
        private GridColumn col_NetAmount;
        private GridColumn col_ActionAdd;
        private RepositoryItemButtonEdit repoBtn_AddReturn;
        private LayoutControlItem lCI_InvoiceLine;

        private SplitterItem splitterMain;

        private LayoutControlGroup lCG_RightPanel;

        private LayoutControlGroup lCG_ReturnCart;
        private MyGridControl gC_ReturnInvoiceLine;
        private MyGridView gV_ReturnInvoiceLine;
        private GridColumn col_RProductCode;
        private GridColumn col_RProductDesc;
        private GridColumn col_RQty;
        private RepositoryItemSpinEdit repoSpin_ReturnQty;
        private GridColumn col_RPrice;
        private GridColumn col_RPosDiscount;
        private GridColumn col_RNetAmount;
        private GridColumn col_RRemove;
        private RepositoryItemButtonEdit repoBtn_RemoveReturn;
        private LayoutControlItem lCI_ReturnInvoiceLine;

        private SplitterItem splitterRight;

        private LayoutControlGroup lCG_Payment;
        private MyGridControl gC_PaymentLine;
        private MyGridView gV_PaymentLine;
        private GridColumn col_PaymentTypeDesc;
        private GridColumn col_PaymentMethodDesc;
        private GridColumn col_CashRegisterDesc;
        private GridColumn col_Payment;
        private LayoutControlItem lCI_Payment;

        private LayoutControlGroup lCG_Actions;
        private SimpleButton btn_Ok;
        private LayoutControlItem lCI_Ok;
        private SimpleButton btn_Cancel;
        private LayoutControlItem lCI_Cancel;
    }
}
