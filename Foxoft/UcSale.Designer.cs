
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using System.Windows.Forms;
using System;
using DevExpress.Data;

namespace Foxoft
{
    partial class UcSale
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
        /// the contents of method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UcSale));
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();
            ColumnDefinition columnDefinition3 = new ColumnDefinition();
            ColumnDefinition columnDefinition4 = new ColumnDefinition();
            RowDefinition rowDefinition1 = new RowDefinition();
            RowDefinition rowDefinition2 = new RowDefinition();
            RowDefinition rowDefinition3 = new RowDefinition();
            RowDefinition rowDefinition4 = new RowDefinition();
            RowDefinition rowDefinition5 = new RowDefinition();
            ColumnDefinition columnDefinition5 = new ColumnDefinition();
            ColumnDefinition columnDefinition6 = new ColumnDefinition();
            ColumnDefinition columnDefinition7 = new ColumnDefinition();
            ColumnDefinition columnDefinition8 = new ColumnDefinition();
            RowDefinition rowDefinition6 = new RowDefinition();
            RowDefinition rowDefinition7 = new RowDefinition();
            RowDefinition rowDefinition8 = new RowDefinition();
            RowDefinition rowDefinition9 = new RowDefinition();
            ColumnDefinition columnDefinition9 = new ColumnDefinition();
            ColumnDefinition columnDefinition10 = new ColumnDefinition();
            RowDefinition rowDefinition10 = new RowDefinition();
            RowDefinition rowDefinition11 = new RowDefinition();
            RowDefinition rowDefinition12 = new RowDefinition();
            RowDefinition rowDefinition13 = new RowDefinition();
            RowDefinition rowDefinition14 = new RowDefinition();
            RowDefinition rowDefinition15 = new RowDefinition();
            ColumnDefinition columnDefinition11 = new ColumnDefinition();
            ColumnDefinition columnDefinition12 = new ColumnDefinition();
            ColumnDefinition columnDefinition13 = new ColumnDefinition();
            ColumnDefinition columnDefinition14 = new ColumnDefinition();
            RowDefinition rowDefinition16 = new RowDefinition();
            lC_InvoiceLine = new LayoutControl();
            btn_Star = new SimpleButton();
            btn_Comma = new SimpleButton();
            btn_Num0 = new SimpleButton();
            btn_Num1 = new SimpleButton();
            btn_Num2 = new SimpleButton();
            btn_Num3 = new SimpleButton();
            btn_Num4 = new SimpleButton();
            btn_Num6 = new SimpleButton();
            btn_Num8 = new SimpleButton();
            btn_Num9 = new SimpleButton();
            btn_Num7 = new SimpleButton();
            btn_Enter = new SimpleButton();
            btn_C = new SimpleButton();
            btn_BackSpace = new SimpleButton();
            txtEdit_Barcode = new TextEdit();
            imageComboEdit_Barcode = new ImageComboBoxEdit();
            gC_InvoiceLine = new GridControl();
            gV_InvoiceLine = new GridView();
            col_ProductDesc = new GridColumn();
            col_Qty = new GridColumn();
            col_Price = new GridColumn();
            col_NetAmount = new GridColumn();
            col_Barcode = new GridColumn();
            col_PosDiscount = new GridColumn();
            col_Amount = new GridColumn();
            col_VatRate = new GridColumn();
            col_SalesPersonCode = new GridColumn();
            btn_ProductSearch = new SimpleButton();
            btn_Discount = new SimpleButton();
            btn_CancelInvoice = new SimpleButton();
            btn_DeleteLine = new SimpleButton();
            btn_SalesPerson = new SimpleButton();
            txtEdit_CustomerPhoneNum = new TextEdit();
            txtEdit_CustomerAddress = new TextEdit();
            txtEdit_CustomerName = new TextEdit();
            btn_CustomerSearch = new SimpleButton();
            btn_CustomerEdit = new SimpleButton();
            btn_CustomerAdd = new SimpleButton();
            txtEdit_BonCardNum = new TextEdit();
            txtEdit_CustomerCode = new TextEdit();
            btn_Cash = new SimpleButton();
            btn_Cashless = new SimpleButton();
            btn_CustomerBonus = new SimpleButton();
            btn_Print = new SimpleButton();
            btn_PrintDesign = new SimpleButton();
            btn_ReportZ = new SimpleButton();
            btn_Num5 = new SimpleButton();
            lCG_Root = new LayoutControlGroup();
            lCG_Barcode = new LayoutControlGroup();
            lCI_Star = new LayoutControlItem();
            lCI_Comma = new LayoutControlItem();
            lCI_Num0 = new LayoutControlItem();
            lCI_Num1 = new LayoutControlItem();
            lCI_Num2 = new LayoutControlItem();
            lCI_Num3 = new LayoutControlItem();
            lCI_Num4 = new LayoutControlItem();
            lCI_Num6 = new LayoutControlItem();
            lCI_Num8 = new LayoutControlItem();
            lCI_Num9 = new LayoutControlItem();
            lCI_Num7 = new LayoutControlItem();
            lCI_Enter = new LayoutControlItem();
            lCI_C = new LayoutControlItem();
            lCI_BackSpace = new LayoutControlItem();
            lCI_ItemTextBox = new LayoutControlItem();
            lCI_ComboBox = new LayoutControlItem();
            lCI_Num5 = new LayoutControlItem();
            lCG_Invoice = new LayoutControlGroup();
            lCI_GridView = new LayoutControlItem();
            lCG_Function = new LayoutControlGroup();
            lCI_ProductSearch = new LayoutControlItem();
            lCI_Discount = new LayoutControlItem();
            lCI_CancelInvoice = new LayoutControlItem();
            lCI_DeleteLine = new LayoutControlItem();
            lCI_SalesPerson = new LayoutControlItem();
            lCI_Print = new LayoutControlItem();
            lCI_PrintDesign = new LayoutControlItem();
            lCI_ReportZ = new LayoutControlItem();
            lCG_Customer = new LayoutControlGroup();
            lCI_CustomerSearch = new LayoutControlItem();
            lCI_BonusCardNum = new LayoutControlItem();
            lCI_CustomerAddress = new LayoutControlItem();
            lCI_CustomerTel = new LayoutControlItem();
            lCI_CustomerName = new LayoutControlItem();
            lCI_CustomerCode = new LayoutControlItem();
            lCI_CustomerAdd = new LayoutControlItem();
            lCI_CustomerEdit = new LayoutControlItem();
            lCG_Payment = new LayoutControlGroup();
            lCI_Cash = new LayoutControlItem();
            lCI_Cashless = new LayoutControlItem();
            lCI_CustomerBonus = new LayoutControlItem();
            layoutControlGroup2 = new LayoutControlGroup();
            ((ISupportInitialize)lC_InvoiceLine).BeginInit();
            lC_InvoiceLine.SuspendLayout();
            ((ISupportInitialize)txtEdit_Barcode.Properties).BeginInit();
            ((ISupportInitialize)imageComboEdit_Barcode.Properties).BeginInit();
            ((ISupportInitialize)gC_InvoiceLine).BeginInit();
            ((ISupportInitialize)gV_InvoiceLine).BeginInit();
            ((ISupportInitialize)txtEdit_CustomerPhoneNum.Properties).BeginInit();
            ((ISupportInitialize)txtEdit_CustomerAddress.Properties).BeginInit();
            ((ISupportInitialize)txtEdit_CustomerName.Properties).BeginInit();
            ((ISupportInitialize)txtEdit_BonCardNum.Properties).BeginInit();
            ((ISupportInitialize)txtEdit_CustomerCode.Properties).BeginInit();
            ((ISupportInitialize)lCG_Root).BeginInit();
            ((ISupportInitialize)lCG_Barcode).BeginInit();
            ((ISupportInitialize)lCI_Star).BeginInit();
            ((ISupportInitialize)lCI_Comma).BeginInit();
            ((ISupportInitialize)lCI_Num0).BeginInit();
            ((ISupportInitialize)lCI_Num1).BeginInit();
            ((ISupportInitialize)lCI_Num2).BeginInit();
            ((ISupportInitialize)lCI_Num3).BeginInit();
            ((ISupportInitialize)lCI_Num4).BeginInit();
            ((ISupportInitialize)lCI_Num6).BeginInit();
            ((ISupportInitialize)lCI_Num8).BeginInit();
            ((ISupportInitialize)lCI_Num9).BeginInit();
            ((ISupportInitialize)lCI_Num7).BeginInit();
            ((ISupportInitialize)lCI_Enter).BeginInit();
            ((ISupportInitialize)lCI_C).BeginInit();
            ((ISupportInitialize)lCI_BackSpace).BeginInit();
            ((ISupportInitialize)lCI_ItemTextBox).BeginInit();
            ((ISupportInitialize)lCI_ComboBox).BeginInit();
            ((ISupportInitialize)lCI_Num5).BeginInit();
            ((ISupportInitialize)lCG_Invoice).BeginInit();
            ((ISupportInitialize)lCI_GridView).BeginInit();
            ((ISupportInitialize)lCG_Function).BeginInit();
            ((ISupportInitialize)lCI_ProductSearch).BeginInit();
            ((ISupportInitialize)lCI_Discount).BeginInit();
            ((ISupportInitialize)lCI_CancelInvoice).BeginInit();
            ((ISupportInitialize)lCI_DeleteLine).BeginInit();
            ((ISupportInitialize)lCI_SalesPerson).BeginInit();
            ((ISupportInitialize)lCI_Print).BeginInit();
            ((ISupportInitialize)lCI_PrintDesign).BeginInit();
            ((ISupportInitialize)lCI_ReportZ).BeginInit();
            ((ISupportInitialize)lCG_Customer).BeginInit();
            ((ISupportInitialize)lCI_CustomerSearch).BeginInit();
            ((ISupportInitialize)lCI_BonusCardNum).BeginInit();
            ((ISupportInitialize)lCI_CustomerAddress).BeginInit();
            ((ISupportInitialize)lCI_CustomerTel).BeginInit();
            ((ISupportInitialize)lCI_CustomerName).BeginInit();
            ((ISupportInitialize)lCI_CustomerCode).BeginInit();
            ((ISupportInitialize)lCI_CustomerAdd).BeginInit();
            ((ISupportInitialize)lCI_CustomerEdit).BeginInit();
            ((ISupportInitialize)lCG_Payment).BeginInit();
            ((ISupportInitialize)lCI_Cash).BeginInit();
            ((ISupportInitialize)lCI_Cashless).BeginInit();
            ((ISupportInitialize)lCI_CustomerBonus).BeginInit();
            ((ISupportInitialize)layoutControlGroup2).BeginInit();
            SuspendLayout();
            // 
            // lC_InvoiceLine
            // 
            lC_InvoiceLine.Controls.Add(btn_Star);
            lC_InvoiceLine.Controls.Add(btn_Comma);
            lC_InvoiceLine.Controls.Add(btn_Num0);
            lC_InvoiceLine.Controls.Add(btn_Num1);
            lC_InvoiceLine.Controls.Add(btn_Num2);
            lC_InvoiceLine.Controls.Add(btn_Num3);
            lC_InvoiceLine.Controls.Add(btn_Num4);
            lC_InvoiceLine.Controls.Add(btn_Num6);
            lC_InvoiceLine.Controls.Add(btn_Num8);
            lC_InvoiceLine.Controls.Add(btn_Num9);
            lC_InvoiceLine.Controls.Add(btn_Num7);
            lC_InvoiceLine.Controls.Add(btn_Enter);
            lC_InvoiceLine.Controls.Add(btn_C);
            lC_InvoiceLine.Controls.Add(btn_BackSpace);
            lC_InvoiceLine.Controls.Add(txtEdit_Barcode);
            lC_InvoiceLine.Controls.Add(imageComboEdit_Barcode);
            lC_InvoiceLine.Controls.Add(gC_InvoiceLine);
            lC_InvoiceLine.Controls.Add(btn_ProductSearch);
            lC_InvoiceLine.Controls.Add(btn_Discount);
            lC_InvoiceLine.Controls.Add(btn_CancelInvoice);
            lC_InvoiceLine.Controls.Add(btn_DeleteLine);
            lC_InvoiceLine.Controls.Add(btn_SalesPerson);
            lC_InvoiceLine.Controls.Add(txtEdit_CustomerPhoneNum);
            lC_InvoiceLine.Controls.Add(txtEdit_CustomerAddress);
            lC_InvoiceLine.Controls.Add(txtEdit_CustomerName);
            lC_InvoiceLine.Controls.Add(btn_CustomerSearch);
            lC_InvoiceLine.Controls.Add(btn_CustomerEdit);
            lC_InvoiceLine.Controls.Add(btn_CustomerAdd);
            lC_InvoiceLine.Controls.Add(txtEdit_BonCardNum);
            lC_InvoiceLine.Controls.Add(txtEdit_CustomerCode);
            lC_InvoiceLine.Controls.Add(btn_Cash);
            lC_InvoiceLine.Controls.Add(btn_Cashless);
            lC_InvoiceLine.Controls.Add(btn_CustomerBonus);
            lC_InvoiceLine.Controls.Add(btn_Print);
            lC_InvoiceLine.Controls.Add(btn_PrintDesign);
            lC_InvoiceLine.Controls.Add(btn_ReportZ);
            lC_InvoiceLine.Controls.Add(btn_Num5);
            lC_InvoiceLine.Dock = DockStyle.Fill;
            lC_InvoiceLine.Location = new Point(0, 0);
            lC_InvoiceLine.Name = "lC_InvoiceLine";
            lC_InvoiceLine.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1189, 400, 650, 400);
            lC_InvoiceLine.Root = lCG_Root;
            lC_InvoiceLine.Size = new Size(1142, 719);
            lC_InvoiceLine.TabIndex = 0;
            lC_InvoiceLine.Text = "layoutControl1";
            // 
            // btn_Star
            // 
            btn_Star.AllowFocus = false;
            btn_Star.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Star.Appearance.Options.UseFont = true;
            btn_Star.Location = new Point(436, 325);
            btn_Star.Name = "btn_Star";
            btn_Star.ShowFocusRectangle = DefaultBoolean.False;
            btn_Star.Size = new Size(74, 67);
            btn_Star.StyleController = lC_InvoiceLine;
            btn_Star.TabIndex = 14;
            btn_Star.Text = "*";
            btn_Star.Click += btn_Num_Click;
            // 
            // btn_Comma
            // 
            btn_Comma.AllowFocus = false;
            btn_Comma.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Comma.Appearance.Options.UseFont = true;
            btn_Comma.Location = new Point(592, 325);
            btn_Comma.Name = "btn_Comma";
            btn_Comma.ShowFocusRectangle = DefaultBoolean.False;
            btn_Comma.Size = new Size(74, 67);
            btn_Comma.StyleController = lC_InvoiceLine;
            btn_Comma.TabIndex = 15;
            btn_Comma.Text = ",";
            btn_Comma.Click += btn_Num_Click;
            // 
            // btn_Num0
            // 
            btn_Num0.AllowFocus = false;
            btn_Num0.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num0.Appearance.Options.UseFont = true;
            btn_Num0.Location = new Point(514, 325);
            btn_Num0.Name = "btn_Num0";
            btn_Num0.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num0.Size = new Size(74, 67);
            btn_Num0.StyleController = lC_InvoiceLine;
            btn_Num0.TabIndex = 13;
            btn_Num0.Text = "0";
            btn_Num0.Click += btn_Num_Click;
            // 
            // btn_Num1
            // 
            btn_Num1.AllowFocus = false;
            btn_Num1.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num1.Appearance.Options.UseFont = true;
            btn_Num1.Location = new Point(436, 255);
            btn_Num1.Name = "btn_Num1";
            btn_Num1.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num1.Size = new Size(74, 66);
            btn_Num1.StyleController = lC_InvoiceLine;
            btn_Num1.TabIndex = 6;
            btn_Num1.Text = "1";
            btn_Num1.Click += btn_Num_Click;
            // 
            // btn_Num2
            // 
            btn_Num2.AllowFocus = false;
            btn_Num2.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num2.Appearance.Options.UseFont = true;
            btn_Num2.Location = new Point(514, 255);
            btn_Num2.Name = "btn_Num2";
            btn_Num2.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num2.Size = new Size(74, 66);
            btn_Num2.StyleController = lC_InvoiceLine;
            btn_Num2.TabIndex = 7;
            btn_Num2.Text = "2";
            btn_Num2.Click += btn_Num_Click;
            // 
            // btn_Num3
            // 
            btn_Num3.AllowFocus = false;
            btn_Num3.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num3.Appearance.Options.UseFont = true;
            btn_Num3.Location = new Point(592, 255);
            btn_Num3.Name = "btn_Num3";
            btn_Num3.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num3.Size = new Size(74, 66);
            btn_Num3.StyleController = lC_InvoiceLine;
            btn_Num3.TabIndex = 8;
            btn_Num3.Text = "3";
            btn_Num3.Click += btn_Num_Click;
            // 
            // btn_Num4
            // 
            btn_Num4.AllowFocus = false;
            btn_Num4.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num4.Appearance.Options.UseFont = true;
            btn_Num4.Location = new Point(436, 185);
            btn_Num4.Name = "btn_Num4";
            btn_Num4.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num4.Size = new Size(74, 66);
            btn_Num4.StyleController = lC_InvoiceLine;
            btn_Num4.TabIndex = 5;
            btn_Num4.Text = "4";
            btn_Num4.Click += btn_Num_Click;
            // 
            // btn_Num6
            // 
            btn_Num6.AllowFocus = false;
            btn_Num6.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num6.Appearance.Options.UseFont = true;
            btn_Num6.Location = new Point(592, 185);
            btn_Num6.Name = "btn_Num6";
            btn_Num6.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num6.Size = new Size(74, 66);
            btn_Num6.StyleController = lC_InvoiceLine;
            btn_Num6.TabIndex = 9;
            btn_Num6.Text = "6";
            btn_Num6.Click += btn_Num_Click;
            // 
            // btn_Num8
            // 
            btn_Num8.AllowFocus = false;
            btn_Num8.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num8.Appearance.Options.UseFont = true;
            btn_Num8.Location = new Point(514, 115);
            btn_Num8.Name = "btn_Num8";
            btn_Num8.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num8.Size = new Size(74, 66);
            btn_Num8.StyleController = lC_InvoiceLine;
            btn_Num8.TabIndex = 10;
            btn_Num8.Text = "8";
            btn_Num8.Click += btn_Num_Click;
            // 
            // btn_Num9
            // 
            btn_Num9.AllowFocus = false;
            btn_Num9.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num9.Appearance.Options.UseFont = true;
            btn_Num9.Location = new Point(592, 115);
            btn_Num9.Name = "btn_Num9";
            btn_Num9.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num9.Size = new Size(74, 66);
            btn_Num9.StyleController = lC_InvoiceLine;
            btn_Num9.TabIndex = 12;
            btn_Num9.Text = "9";
            btn_Num9.Click += btn_Num_Click;
            // 
            // btn_Num7
            // 
            btn_Num7.AllowFocus = false;
            btn_Num7.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num7.Appearance.Options.UseFont = true;
            btn_Num7.Location = new Point(436, 115);
            btn_Num7.Name = "btn_Num7";
            btn_Num7.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num7.Size = new Size(74, 66);
            btn_Num7.StyleController = lC_InvoiceLine;
            btn_Num7.TabIndex = 22;
            btn_Num7.Text = "7";
            btn_Num7.Click += btn_Num_Click;
            // 
            // btn_Enter
            // 
            btn_Enter.Appearance.Font = new Font("Tahoma", 20F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Enter.Appearance.Options.UseFont = true;
            btn_Enter.Location = new Point(670, 255);
            btn_Enter.Name = "btn_Enter";
            btn_Enter.ShowFocusRectangle = DefaultBoolean.False;
            btn_Enter.Size = new Size(74, 137);
            btn_Enter.StyleController = lC_InvoiceLine;
            btn_Enter.TabIndex = 18;
            btn_Enter.Text = "↵";
            btn_Enter.Click += btn_Enter_Click;
            // 
            // btn_C
            // 
            btn_C.AllowFocus = false;
            btn_C.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_C.Appearance.Options.UseFont = true;
            btn_C.Location = new Point(670, 185);
            btn_C.Name = "btn_C";
            btn_C.ShowFocusRectangle = DefaultBoolean.False;
            btn_C.Size = new Size(74, 66);
            btn_C.StyleController = lC_InvoiceLine;
            btn_C.TabIndex = 17;
            btn_C.Text = "C";
            btn_C.Click += btn_Num_Click;
            // 
            // btn_BackSpace
            // 
            btn_BackSpace.AllowFocus = false;
            btn_BackSpace.Appearance.Font = new Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_BackSpace.Appearance.Options.UseFont = true;
            btn_BackSpace.Location = new Point(670, 115);
            btn_BackSpace.Name = "btn_BackSpace";
            btn_BackSpace.ShowFocusRectangle = DefaultBoolean.False;
            btn_BackSpace.Size = new Size(74, 66);
            btn_BackSpace.StyleController = lC_InvoiceLine;
            btn_BackSpace.TabIndex = 16;
            btn_BackSpace.Text = "←";
            btn_BackSpace.Click += btn_Num_Click;
            // 
            // txtEdit_Barcode
            // 
            txtEdit_Barcode.Location = new Point(514, 61);
            txtEdit_Barcode.Name = "txtEdit_Barcode";
            txtEdit_Barcode.Properties.Appearance.Font = new Font("Tahoma", 17F, FontStyle.Regular, GraphicsUnit.Point);
            txtEdit_Barcode.Properties.Appearance.Options.UseFont = true;
            txtEdit_Barcode.Size = new Size(230, 34);
            txtEdit_Barcode.StyleController = lC_InvoiceLine;
            txtEdit_Barcode.TabIndex = 24;
            // 
            // imageComboEdit_Barcode
            // 
            imageComboEdit_Barcode.Location = new Point(436, 60);
            imageComboEdit_Barcode.Name = "imageComboEdit_Barcode";
            imageComboEdit_Barcode.Properties.AllowFocused = false;
            imageComboEdit_Barcode.Properties.Appearance.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Point);
            imageComboEdit_Barcode.Properties.Appearance.Options.UseFont = true;
            imageComboEdit_Barcode.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            imageComboEdit_Barcode.Properties.ContextImageOptions.Alignment = ContextImageAlignment.Far;
            imageComboEdit_Barcode.Properties.ContextImageOptions.Image = (Image)resources.GetObject("imageComboEdit_Barcode.Properties.ContextImageOptions.Image");
            imageComboEdit_Barcode.Properties.ContextImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("imageComboEdit_Barcode.Properties.ContextImageOptions.SvgImage");
            imageComboEdit_Barcode.Properties.DisplayFormat.FormatType = FormatType.Custom;
            imageComboEdit_Barcode.Size = new Size(74, 36);
            imageComboEdit_Barcode.StyleController = lC_InvoiceLine;
            imageComboEdit_Barcode.TabIndex = 23;
            // 
            // gC_InvoiceLine
            // 
            gC_InvoiceLine.DataMember = "TrInvoiceLine";
            gC_InvoiceLine.Location = new Point(24, 45);
            gC_InvoiceLine.MainView = gV_InvoiceLine;
            gC_InvoiceLine.Name = "gC_InvoiceLine";
            gC_InvoiceLine.Size = new Size(384, 650);
            gC_InvoiceLine.TabIndex = 4;
            gC_InvoiceLine.ViewCollection.AddRange(new BaseView[] { gV_InvoiceLine });
            gC_InvoiceLine.DoubleClick += gC_Sale_DoubleClick;
            gC_InvoiceLine.MouseUp += gC_Sale_MouseUp;
            // 
            // gV_InvoiceLine
            // 
            gV_InvoiceLine.Appearance.FooterPanel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gV_InvoiceLine.Appearance.FooterPanel.Options.UseFont = true;
            gV_InvoiceLine.Appearance.HideSelectionRow.BackColor = Color.FromArgb(206, 221, 245);
            gV_InvoiceLine.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gV_InvoiceLine.Appearance.Row.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gV_InvoiceLine.Appearance.Row.Options.UseFont = true;
            gV_InvoiceLine.Columns.AddRange(new GridColumn[] { col_ProductDesc, col_Qty, col_Price, col_NetAmount, col_Barcode, col_PosDiscount, col_Amount, col_VatRate, col_SalesPersonCode });
            gV_InvoiceLine.GridControl = gC_InvoiceLine;
            gV_InvoiceLine.Name = "gV_InvoiceLine";
            gV_InvoiceLine.OptionsBehavior.Editable = false;
            gV_InvoiceLine.OptionsView.AutoCalcPreviewLineCount = true;
            gV_InvoiceLine.OptionsView.ShowFooter = true;
            gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
            gV_InvoiceLine.OptionsView.ShowIndicator = false;
            gV_InvoiceLine.OptionsView.ShowPreview = true;
            gV_InvoiceLine.PreviewIndent = 10;
            gV_InvoiceLine.CalcPreviewText += gV_InvoiceLine_CalcPreviewText;
            gV_InvoiceLine.FocusedRowChanged += gV_InvoiceLine_FocusedRowChanged;
            // 
            // col_ProductDesc
            // 
            col_ProductDesc.Caption = "Məhsul";
            col_ProductDesc.FieldName = "ProductDesc";
            col_ProductDesc.Name = "col_ProductDesc";
            col_ProductDesc.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Custom, "ProductDes", "Toplam:") });
            col_ProductDesc.Visible = true;
            col_ProductDesc.VisibleIndex = 0;
            // 
            // col_Qty
            // 
            col_Qty.Caption = "Say";
            col_Qty.FieldName = "Qty";
            col_Qty.Name = "col_Qty";
            col_Qty.Visible = true;
            col_Qty.VisibleIndex = 1;
            col_Qty.Width = 39;
            // 
            // col_Price
            // 
            col_Price.Caption = "Qiymət";
            col_Price.FieldName = "Price";
            col_Price.Name = "col_Price";
            col_Price.Visible = true;
            col_Price.VisibleIndex = 2;
            col_Price.Width = 43;
            // 
            // col_NetAmount
            // 
            col_NetAmount.Caption = "Net Tutar";
            col_NetAmount.DisplayFormat.FormatString = "{0:0.##}";
            col_NetAmount.DisplayFormat.FormatType = FormatType.Numeric;
            col_NetAmount.FieldName = "NetAmount";
            col_NetAmount.Name = "col_NetAmount";
            col_NetAmount.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, "NetAmount", "{0:0.##}") });
            col_NetAmount.Visible = true;
            col_NetAmount.VisibleIndex = 3;
            col_NetAmount.Width = 70;
            // 
            // col_Barcode
            // 
            col_Barcode.Caption = "Barkod";
            col_Barcode.FieldName = "Barcode";
            col_Barcode.Name = "col_Barcode";
            // 
            // col_PosDiscount
            // 
            col_PosDiscount.Caption = "Endirim Faizi";
            col_PosDiscount.FieldName = "PosDiscount";
            col_PosDiscount.Name = "col_PosDiscount";
            // 
            // col_Amount
            // 
            col_Amount.Caption = "Tutar";
            col_Amount.FieldName = "Amount";
            col_Amount.Name = "col_Amount";
            // 
            // col_VatRate
            // 
            col_VatRate.Caption = "ƏDV";
            col_VatRate.FieldName = "VatRate";
            col_VatRate.Name = "col_VatRate";
            // 
            // col_SalesPersonCode
            // 
            col_SalesPersonCode.Caption = "Satıcı";
            col_SalesPersonCode.FieldName = "SalesPersonCode";
            col_SalesPersonCode.Name = "col_SalesPersonCode";
            // 
            // btn_ProductSearch
            // 
            btn_ProductSearch.AllowFocus = false;
            btn_ProductSearch.Appearance.BackColor = Color.Transparent;
            btn_ProductSearch.Appearance.Options.UseBackColor = true;
            btn_ProductSearch.ImageOptions.Location = ImageLocation.TopCenter;
            btn_ProductSearch.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_ProductSearch.ImageOptions.SvgImage");
            btn_ProductSearch.Location = new Point(772, 254);
            btn_ProductSearch.Name = "btn_ProductSearch";
            btn_ProductSearch.ShowFocusRectangle = DefaultBoolean.False;
            btn_ProductSearch.Size = new Size(83, 72);
            btn_ProductSearch.StyleController = lC_InvoiceLine;
            btn_ProductSearch.TabIndex = 20;
            btn_ProductSearch.Text = "Məhsul";
            btn_ProductSearch.Click += btn_ProductSearch_Click;
            // 
            // btn_Discount
            // 
            btn_Discount.AllowFocus = false;
            btn_Discount.Appearance.BackColor = Color.Transparent;
            btn_Discount.Appearance.Options.UseBackColor = true;
            btn_Discount.ImageOptions.Image = (Image)resources.GetObject("btn_Discount.ImageOptions.Image");
            btn_Discount.ImageOptions.Location = ImageLocation.TopCenter;
            btn_Discount.Location = new Point(859, 254);
            btn_Discount.Name = "btn_Discount";
            btn_Discount.ShowFocusRectangle = DefaultBoolean.False;
            btn_Discount.Size = new Size(83, 72);
            btn_Discount.StyleController = lC_InvoiceLine;
            btn_Discount.TabIndex = 25;
            btn_Discount.Text = "Endirim";
            btn_Discount.Click += btn_Discount_Click;
            // 
            // btn_CancelInvoice
            // 
            btn_CancelInvoice.AllowFocus = false;
            btn_CancelInvoice.Appearance.BackColor = Color.Transparent;
            btn_CancelInvoice.Appearance.Options.UseBackColor = true;
            btn_CancelInvoice.ImageOptions.Image = (Image)resources.GetObject("btn_CancelInvoice.ImageOptions.Image");
            btn_CancelInvoice.ImageOptions.Location = ImageLocation.TopCenter;
            btn_CancelInvoice.Location = new Point(1033, 254);
            btn_CancelInvoice.Name = "btn_CancelInvoice";
            btn_CancelInvoice.ShowFocusRectangle = DefaultBoolean.False;
            btn_CancelInvoice.Size = new Size(85, 72);
            btn_CancelInvoice.StyleController = lC_InvoiceLine;
            btn_CancelInvoice.TabIndex = 29;
            btn_CancelInvoice.Text = "Çeki Ləğv Et";
            btn_CancelInvoice.Click += btn_CancelInvoice_Click;
            // 
            // btn_DeleteLine
            // 
            btn_DeleteLine.AllowFocus = false;
            btn_DeleteLine.Appearance.BackColor = Color.Transparent;
            btn_DeleteLine.Appearance.Options.UseBackColor = true;
            btn_DeleteLine.ImageOptions.Image = (Image)resources.GetObject("btn_DeleteLine.ImageOptions.Image");
            btn_DeleteLine.ImageOptions.Location = ImageLocation.TopCenter;
            btn_DeleteLine.Location = new Point(946, 254);
            btn_DeleteLine.Name = "btn_DeleteLine";
            btn_DeleteLine.ShowFocusRectangle = DefaultBoolean.False;
            btn_DeleteLine.Size = new Size(83, 72);
            btn_DeleteLine.StyleController = lC_InvoiceLine;
            btn_DeleteLine.TabIndex = 30;
            btn_DeleteLine.Text = "Sətri Sil";
            btn_DeleteLine.Click += btn_DeleteLine_Click;
            // 
            // btn_SalesPerson
            // 
            btn_SalesPerson.AllowFocus = false;
            btn_SalesPerson.Appearance.BackColor = Color.Transparent;
            btn_SalesPerson.Appearance.Options.UseBackColor = true;
            btn_SalesPerson.ImageOptions.Image = (Image)resources.GetObject("btn_SalesPerson.ImageOptions.Image");
            btn_SalesPerson.ImageOptions.Location = ImageLocation.TopCenter;
            btn_SalesPerson.Location = new Point(772, 330);
            btn_SalesPerson.Name = "btn_SalesPerson";
            btn_SalesPerson.Size = new Size(83, 73);
            btn_SalesPerson.StyleController = lC_InvoiceLine;
            btn_SalesPerson.TabIndex = 40;
            btn_SalesPerson.Text = "Satıcı";
            btn_SalesPerson.Click += btn_SalesPerson_Click;
            // 
            // txtEdit_CustomerPhoneNum
            // 
            txtEdit_CustomerPhoneNum.Enabled = false;
            txtEdit_CustomerPhoneNum.Location = new Point(846, 126);
            txtEdit_CustomerPhoneNum.Name = "txtEdit_CustomerPhoneNum";
            txtEdit_CustomerPhoneNum.Properties.AllowFocused = false;
            txtEdit_CustomerPhoneNum.Size = new Size(219, 20);
            txtEdit_CustomerPhoneNum.StyleController = lC_InvoiceLine;
            txtEdit_CustomerPhoneNum.TabIndex = 37;
            // 
            // txtEdit_CustomerAddress
            // 
            txtEdit_CustomerAddress.Enabled = false;
            txtEdit_CustomerAddress.Location = new Point(846, 153);
            txtEdit_CustomerAddress.Name = "txtEdit_CustomerAddress";
            txtEdit_CustomerAddress.Properties.AllowFocused = false;
            txtEdit_CustomerAddress.Size = new Size(219, 20);
            txtEdit_CustomerAddress.StyleController = lC_InvoiceLine;
            txtEdit_CustomerAddress.TabIndex = 38;
            // 
            // txtEdit_CustomerName
            // 
            txtEdit_CustomerName.Enabled = false;
            txtEdit_CustomerName.Location = new Point(846, 99);
            txtEdit_CustomerName.Name = "txtEdit_CustomerName";
            txtEdit_CustomerName.Properties.AllowFocused = false;
            txtEdit_CustomerName.Size = new Size(219, 20);
            txtEdit_CustomerName.StyleController = lC_InvoiceLine;
            txtEdit_CustomerName.TabIndex = 35;
            // 
            // btn_CustomerSearch
            // 
            btn_CustomerSearch.AllowFocus = false;
            btn_CustomerSearch.Appearance.BackColor = Color.Transparent;
            btn_CustomerSearch.Appearance.BackColor2 = Color.Transparent;
            btn_CustomerSearch.Appearance.BorderColor = Color.Transparent;
            btn_CustomerSearch.Appearance.Options.UseBackColor = true;
            btn_CustomerSearch.Appearance.Options.UseBorderColor = true;
            btn_CustomerSearch.AppearanceDisabled.BackColor = Color.Transparent;
            btn_CustomerSearch.AppearanceDisabled.BackColor2 = Color.Transparent;
            btn_CustomerSearch.AppearanceDisabled.BorderColor = Color.Transparent;
            btn_CustomerSearch.AppearanceDisabled.Options.UseBackColor = true;
            btn_CustomerSearch.AppearanceDisabled.Options.UseBorderColor = true;
            btn_CustomerSearch.AppearanceHovered.BackColor = Color.Transparent;
            btn_CustomerSearch.AppearanceHovered.BackColor2 = Color.Transparent;
            btn_CustomerSearch.AppearanceHovered.BorderColor = Color.Transparent;
            btn_CustomerSearch.AppearanceHovered.Options.UseBackColor = true;
            btn_CustomerSearch.AppearanceHovered.Options.UseBorderColor = true;
            btn_CustomerSearch.AppearancePressed.BackColor = Color.Transparent;
            btn_CustomerSearch.AppearancePressed.BackColor2 = Color.Transparent;
            btn_CustomerSearch.AppearancePressed.BorderColor = Color.Transparent;
            btn_CustomerSearch.AppearancePressed.Options.UseBackColor = true;
            btn_CustomerSearch.AppearancePressed.Options.UseBorderColor = true;
            btn_CustomerSearch.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerSearch.ImageOptions.Image");
            btn_CustomerSearch.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerSearch.Location = new Point(1069, 45);
            btn_CustomerSearch.Name = "btn_CustomerSearch";
            btn_CustomerSearch.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerSearch.Size = new Size(49, 50);
            btn_CustomerSearch.StyleController = lC_InvoiceLine;
            btn_CustomerSearch.TabIndex = 32;
            btn_CustomerSearch.Text = "simpleButton3";
            btn_CustomerSearch.Click += btn_CustomerSearch_Click;
            // 
            // btn_CustomerEdit
            // 
            btn_CustomerEdit.AllowFocus = false;
            btn_CustomerEdit.Appearance.BackColor = Color.Transparent;
            btn_CustomerEdit.Appearance.BackColor2 = Color.Transparent;
            btn_CustomerEdit.Appearance.BorderColor = Color.Transparent;
            btn_CustomerEdit.Appearance.Options.UseBackColor = true;
            btn_CustomerEdit.Appearance.Options.UseBorderColor = true;
            btn_CustomerEdit.AppearanceDisabled.BackColor = Color.Transparent;
            btn_CustomerEdit.AppearanceDisabled.BackColor2 = Color.Transparent;
            btn_CustomerEdit.AppearanceDisabled.BorderColor = Color.Transparent;
            btn_CustomerEdit.AppearanceDisabled.Options.UseBackColor = true;
            btn_CustomerEdit.AppearanceDisabled.Options.UseBorderColor = true;
            btn_CustomerEdit.AppearanceHovered.BackColor = Color.Transparent;
            btn_CustomerEdit.AppearanceHovered.BackColor2 = Color.Transparent;
            btn_CustomerEdit.AppearanceHovered.BorderColor = Color.Transparent;
            btn_CustomerEdit.AppearanceHovered.Options.UseBackColor = true;
            btn_CustomerEdit.AppearanceHovered.Options.UseBorderColor = true;
            btn_CustomerEdit.AppearancePressed.BackColor = Color.Transparent;
            btn_CustomerEdit.AppearancePressed.BackColor2 = Color.Transparent;
            btn_CustomerEdit.AppearancePressed.BorderColor = Color.Transparent;
            btn_CustomerEdit.AppearancePressed.Options.UseBackColor = true;
            btn_CustomerEdit.AppearancePressed.Options.UseBorderColor = true;
            btn_CustomerEdit.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerEdit.ImageOptions.Image");
            btn_CustomerEdit.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerEdit.Location = new Point(1069, 153);
            btn_CustomerEdit.Name = "btn_CustomerEdit";
            btn_CustomerEdit.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerEdit.Size = new Size(49, 52);
            btn_CustomerEdit.StyleController = lC_InvoiceLine;
            btn_CustomerEdit.TabIndex = 33;
            btn_CustomerEdit.Text = "simpleButton4";
            btn_CustomerEdit.Click += btn_Customer_Click;
            // 
            // btn_CustomerAdd
            // 
            btn_CustomerAdd.AllowFocus = false;
            btn_CustomerAdd.Appearance.BackColor = Color.Transparent;
            btn_CustomerAdd.Appearance.BackColor2 = Color.Transparent;
            btn_CustomerAdd.Appearance.BorderColor = Color.Transparent;
            btn_CustomerAdd.Appearance.Options.UseBackColor = true;
            btn_CustomerAdd.Appearance.Options.UseBorderColor = true;
            btn_CustomerAdd.AppearanceDisabled.BackColor = Color.Transparent;
            btn_CustomerAdd.AppearanceDisabled.BackColor2 = Color.Transparent;
            btn_CustomerAdd.AppearanceDisabled.BorderColor = Color.Transparent;
            btn_CustomerAdd.AppearanceDisabled.Options.UseBackColor = true;
            btn_CustomerAdd.AppearanceDisabled.Options.UseBorderColor = true;
            btn_CustomerAdd.AppearanceHovered.BackColor = Color.Transparent;
            btn_CustomerAdd.AppearanceHovered.BackColor2 = Color.Transparent;
            btn_CustomerAdd.AppearanceHovered.BorderColor = Color.Transparent;
            btn_CustomerAdd.AppearanceHovered.Options.UseBackColor = true;
            btn_CustomerAdd.AppearanceHovered.Options.UseBorderColor = true;
            btn_CustomerAdd.AppearancePressed.BackColor = Color.Transparent;
            btn_CustomerAdd.AppearancePressed.BackColor2 = Color.Transparent;
            btn_CustomerAdd.AppearancePressed.BorderColor = Color.Transparent;
            btn_CustomerAdd.AppearancePressed.Options.UseBackColor = true;
            btn_CustomerAdd.AppearancePressed.Options.UseBorderColor = true;
            btn_CustomerAdd.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerAdd.ImageOptions.Image");
            btn_CustomerAdd.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerAdd.Location = new Point(1069, 99);
            btn_CustomerAdd.Name = "btn_CustomerAdd";
            btn_CustomerAdd.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerAdd.Size = new Size(49, 50);
            btn_CustomerAdd.StyleController = lC_InvoiceLine;
            btn_CustomerAdd.TabIndex = 31;
            btn_CustomerAdd.Text = "simpleButton1";
            btn_CustomerAdd.Click += btn_Customer_Click;
            // 
            // txtEdit_BonCardNum
            // 
            txtEdit_BonCardNum.Enabled = false;
            txtEdit_BonCardNum.Location = new Point(846, 180);
            txtEdit_BonCardNum.Name = "txtEdit_BonCardNum";
            txtEdit_BonCardNum.Properties.AllowFocused = false;
            txtEdit_BonCardNum.Size = new Size(219, 20);
            txtEdit_BonCardNum.StyleController = lC_InvoiceLine;
            txtEdit_BonCardNum.TabIndex = 39;
            // 
            // txtEdit_CustomerCode
            // 
            txtEdit_CustomerCode.Enabled = false;
            txtEdit_CustomerCode.Location = new Point(846, 72);
            txtEdit_CustomerCode.Name = "txtEdit_CustomerCode";
            txtEdit_CustomerCode.Size = new Size(219, 20);
            txtEdit_CustomerCode.StyleController = lC_InvoiceLine;
            txtEdit_CustomerCode.TabIndex = 42;
            // 
            // btn_Cash
            // 
            btn_Cash.AllowFocus = false;
            btn_Cash.Appearance.BackColor = Color.Transparent;
            btn_Cash.Appearance.Options.UseBackColor = true;
            btn_Cash.ImageOptions.Image = (Image)resources.GetObject("btn_Cash.ImageOptions.Image");
            btn_Cash.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_Cash.Location = new Point(772, 606);
            btn_Cash.Name = "btn_Cash";
            btn_Cash.ShowFocusRectangle = DefaultBoolean.False;
            btn_Cash.Size = new Size(83, 89);
            btn_Cash.StyleController = lC_InvoiceLine;
            btn_Cash.TabIndex = 27;
            btn_Cash.Text = "Cash";
            btn_Cash.Click += btn_Payment_Click;
            // 
            // btn_Cashless
            // 
            btn_Cashless.AllowFocus = false;
            btn_Cashless.ImageOptions.Image = (Image)resources.GetObject("btn_Cashless.ImageOptions.Image");
            btn_Cashless.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_Cashless.Location = new Point(859, 606);
            btn_Cashless.Name = "btn_Cashless";
            btn_Cashless.ShowFocusRectangle = DefaultBoolean.False;
            btn_Cashless.Size = new Size(83, 89);
            btn_Cashless.StyleController = lC_InvoiceLine;
            btn_Cashless.TabIndex = 26;
            btn_Cashless.Text = "Nağdsız";
            btn_Cashless.Click += btn_Payment_Click;
            // 
            // btn_CustomerBonus
            // 
            btn_CustomerBonus.AllowFocus = false;
            btn_CustomerBonus.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerBonus.ImageOptions.Image");
            btn_CustomerBonus.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerBonus.Location = new Point(946, 606);
            btn_CustomerBonus.Name = "btn_CustomerBonus";
            btn_CustomerBonus.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerBonus.Size = new Size(83, 89);
            btn_CustomerBonus.StyleController = lC_InvoiceLine;
            btn_CustomerBonus.TabIndex = 28;
            btn_CustomerBonus.Text = "Bonus";
            btn_CustomerBonus.Click += btn_Payment_Click;
            // 
            // btn_Print
            // 
            btn_Print.ImageOptions.Image = (Image)resources.GetObject("btn_Print.ImageOptions.Image");
            btn_Print.ImageOptions.Location = ImageLocation.TopCenter;
            btn_Print.Location = new Point(859, 330);
            btn_Print.Name = "btn_Print";
            btn_Print.Size = new Size(83, 73);
            btn_Print.StyleController = lC_InvoiceLine;
            btn_Print.TabIndex = 43;
            btn_Print.Text = "Çap";
            btn_Print.Click += btn_Print_Click;
            // 
            // btn_PrintDesign
            // 
            btn_PrintDesign.ImageOptions.Image = (Image)resources.GetObject("btn_PrintDesign.ImageOptions.Image");
            btn_PrintDesign.ImageOptions.Location = ImageLocation.TopCenter;
            btn_PrintDesign.Location = new Point(946, 330);
            btn_PrintDesign.Name = "btn_PrintDesign";
            btn_PrintDesign.Size = new Size(83, 73);
            btn_PrintDesign.StyleController = lC_InvoiceLine;
            btn_PrintDesign.TabIndex = 44;
            btn_PrintDesign.Text = "Çap Dizayn";
            btn_PrintDesign.Click += btn_PrintDesign_Click;
            // 
            // btn_ReportZ
            // 
            btn_ReportZ.ImageOptions.Image = (Image)resources.GetObject("btn_ReportZ.ImageOptions.Image");
            btn_ReportZ.ImageOptions.Location = ImageLocation.TopCenter;
            btn_ReportZ.Location = new Point(1033, 330);
            btn_ReportZ.Name = "btn_ReportZ";
            btn_ReportZ.Size = new Size(85, 73);
            btn_ReportZ.StyleController = lC_InvoiceLine;
            btn_ReportZ.TabIndex = 45;
            btn_ReportZ.Text = "Gün Sonu";
            btn_ReportZ.Click += btn_ReportZ_Click;
            // 
            // btn_Num5
            // 
            btn_Num5.AllowFocus = false;
            btn_Num5.Appearance.Font = new Font("Tahoma", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Num5.Appearance.Options.UseFont = true;
            btn_Num5.Location = new Point(514, 185);
            btn_Num5.Name = "btn_Num5";
            btn_Num5.ShowFocusRectangle = DefaultBoolean.False;
            btn_Num5.Size = new Size(74, 66);
            btn_Num5.StyleController = lC_InvoiceLine;
            btn_Num5.TabIndex = 46;
            btn_Num5.Text = "5";
            btn_Num5.Click += btn_Num_Click;
            // 
            // lCG_Root
            // 
            lCG_Root.EnableIndentsWithoutBorders = DefaultBoolean.True;
            lCG_Root.GroupBordersVisible = false;
            lCG_Root.Items.AddRange(new BaseLayoutItem[] { lCG_Barcode, lCG_Invoice, lCG_Function, lCG_Customer, lCG_Payment, layoutControlGroup2 });
            lCG_Root.Name = "Root";
            lCG_Root.Size = new Size(1142, 719);
            lCG_Root.TextVisible = false;
            // 
            // lCG_Barcode
            // 
            lCG_Barcode.CustomizationFormText = "Barcode";
            lCG_Barcode.Items.AddRange(new BaseLayoutItem[] { lCI_Star, lCI_Comma, lCI_Num0, lCI_Num1, lCI_Num2, lCI_Num3, lCI_Num4, lCI_Num6, lCI_Num8, lCI_Num9, lCI_Num7, lCI_Enter, lCI_C, lCI_BackSpace, lCI_ItemTextBox, lCI_ComboBox, lCI_Num5 });
            lCG_Barcode.LayoutMode = LayoutMode.Table;
            lCG_Barcode.Location = new Point(412, 0);
            lCG_Barcode.Name = "lCG_Barcode";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 25D;
            columnDefinition2.SizeType = SizeType.Percent;
            columnDefinition2.Width = 25D;
            columnDefinition3.SizeType = SizeType.Percent;
            columnDefinition3.Width = 25D;
            columnDefinition4.SizeType = SizeType.Percent;
            columnDefinition4.Width = 25D;
            lCG_Barcode.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new ColumnDefinition[] { columnDefinition1, columnDefinition2, columnDefinition3, columnDefinition4 });
            rowDefinition1.Height = 20D;
            rowDefinition1.SizeType = SizeType.Percent;
            rowDefinition2.Height = 20D;
            rowDefinition2.SizeType = SizeType.Percent;
            rowDefinition3.Height = 20D;
            rowDefinition3.SizeType = SizeType.Percent;
            rowDefinition4.Height = 20D;
            rowDefinition4.SizeType = SizeType.Percent;
            rowDefinition5.Height = 20D;
            rowDefinition5.SizeType = SizeType.Percent;
            lCG_Barcode.OptionsTableLayoutGroup.RowDefinitions.AddRange(new RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5 });
            lCG_Barcode.Size = new Size(336, 396);
            lCG_Barcode.Text = "Barcode";
            // 
            // lCI_Star
            // 
            lCI_Star.Control = btn_Star;
            lCI_Star.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Star.CustomizationFormText = "layoutControlItemStar";
            lCI_Star.Location = new Point(0, 280);
            lCI_Star.MinSize = new Size(40, 26);
            lCI_Star.Name = "lCI_Star";
            lCI_Star.OptionsTableLayoutItem.RowIndex = 4;
            lCI_Star.Size = new Size(78, 71);
            lCI_Star.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Star.TextSize = new Size(0, 0);
            lCI_Star.TextVisible = false;
            // 
            // lCI_Comma
            // 
            lCI_Comma.Control = btn_Comma;
            lCI_Comma.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Comma.CustomizationFormText = "layoutControlItemComma";
            lCI_Comma.Location = new Point(156, 280);
            lCI_Comma.MinSize = new Size(40, 26);
            lCI_Comma.Name = "lCI_Comma";
            lCI_Comma.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_Comma.OptionsTableLayoutItem.RowIndex = 4;
            lCI_Comma.Size = new Size(78, 71);
            lCI_Comma.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Comma.TextSize = new Size(0, 0);
            lCI_Comma.TextVisible = false;
            // 
            // lCI_Num0
            // 
            lCI_Num0.Control = btn_Num0;
            lCI_Num0.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num0.CustomizationFormText = "layoutControlItemNum0";
            lCI_Num0.Location = new Point(78, 280);
            lCI_Num0.MinSize = new Size(40, 26);
            lCI_Num0.Name = "lCI_Num0";
            lCI_Num0.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Num0.OptionsTableLayoutItem.RowIndex = 4;
            lCI_Num0.Size = new Size(78, 71);
            lCI_Num0.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num0.TextSize = new Size(0, 0);
            lCI_Num0.TextVisible = false;
            // 
            // lCI_Num1
            // 
            lCI_Num1.Control = btn_Num1;
            lCI_Num1.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num1.CustomizationFormText = "layoutControlItemNum1";
            lCI_Num1.Location = new Point(0, 210);
            lCI_Num1.MinSize = new Size(40, 26);
            lCI_Num1.Name = "lCI_Num1";
            lCI_Num1.OptionsTableLayoutItem.RowIndex = 3;
            lCI_Num1.Size = new Size(78, 70);
            lCI_Num1.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num1.TextSize = new Size(0, 0);
            lCI_Num1.TextVisible = false;
            // 
            // lCI_Num2
            // 
            lCI_Num2.Control = btn_Num2;
            lCI_Num2.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num2.CustomizationFormText = "layoutControlItemNum2";
            lCI_Num2.Location = new Point(78, 210);
            lCI_Num2.MinSize = new Size(40, 26);
            lCI_Num2.Name = "lCI_Num2";
            lCI_Num2.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Num2.OptionsTableLayoutItem.RowIndex = 3;
            lCI_Num2.Size = new Size(78, 70);
            lCI_Num2.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num2.TextSize = new Size(0, 0);
            lCI_Num2.TextVisible = false;
            // 
            // lCI_Num3
            // 
            lCI_Num3.Control = btn_Num3;
            lCI_Num3.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num3.CustomizationFormText = "layoutControlItemNum3";
            lCI_Num3.Location = new Point(156, 210);
            lCI_Num3.MinSize = new Size(40, 26);
            lCI_Num3.Name = "lCI_Num3";
            lCI_Num3.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_Num3.OptionsTableLayoutItem.RowIndex = 3;
            lCI_Num3.Size = new Size(78, 70);
            lCI_Num3.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num3.TextSize = new Size(0, 0);
            lCI_Num3.TextVisible = false;
            // 
            // lCI_Num4
            // 
            lCI_Num4.Control = btn_Num4;
            lCI_Num4.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num4.CustomizationFormText = "layoutControlItemNum4";
            lCI_Num4.Location = new Point(0, 140);
            lCI_Num4.MinSize = new Size(40, 26);
            lCI_Num4.Name = "lCI_Num4";
            lCI_Num4.OptionsTableLayoutItem.RowIndex = 2;
            lCI_Num4.Size = new Size(78, 70);
            lCI_Num4.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num4.TextSize = new Size(0, 0);
            lCI_Num4.TextVisible = false;
            // 
            // lCI_Num6
            // 
            lCI_Num6.Control = btn_Num6;
            lCI_Num6.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num6.CustomizationFormText = "layoutControlItemNum6";
            lCI_Num6.Location = new Point(156, 140);
            lCI_Num6.MinSize = new Size(40, 26);
            lCI_Num6.Name = "lCI_Num6";
            lCI_Num6.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_Num6.OptionsTableLayoutItem.RowIndex = 2;
            lCI_Num6.Size = new Size(78, 70);
            lCI_Num6.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num6.TextSize = new Size(0, 0);
            lCI_Num6.TextVisible = false;
            // 
            // lCI_Num8
            // 
            lCI_Num8.Control = btn_Num8;
            lCI_Num8.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num8.CustomizationFormText = "layoutControlItemNum8";
            lCI_Num8.Location = new Point(78, 70);
            lCI_Num8.MinSize = new Size(40, 26);
            lCI_Num8.Name = "lCI_Num8";
            lCI_Num8.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Num8.OptionsTableLayoutItem.RowIndex = 1;
            lCI_Num8.Size = new Size(78, 70);
            lCI_Num8.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num8.TextSize = new Size(0, 0);
            lCI_Num8.TextVisible = false;
            // 
            // lCI_Num9
            // 
            lCI_Num9.Control = btn_Num9;
            lCI_Num9.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num9.CustomizationFormText = "layoutControlItemNum9";
            lCI_Num9.Location = new Point(156, 70);
            lCI_Num9.MinSize = new Size(40, 26);
            lCI_Num9.Name = "lCI_Num9";
            lCI_Num9.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_Num9.OptionsTableLayoutItem.RowIndex = 1;
            lCI_Num9.Size = new Size(78, 70);
            lCI_Num9.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num9.TextSize = new Size(0, 0);
            lCI_Num9.TextVisible = false;
            // 
            // lCI_Num7
            // 
            lCI_Num7.Control = btn_Num7;
            lCI_Num7.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Num7.CustomizationFormText = "layoutControlItemNum7";
            lCI_Num7.Location = new Point(0, 70);
            lCI_Num7.MinSize = new Size(40, 26);
            lCI_Num7.Name = "lCI_Num7";
            lCI_Num7.OptionsTableLayoutItem.RowIndex = 1;
            lCI_Num7.Size = new Size(78, 70);
            lCI_Num7.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num7.TextSize = new Size(0, 0);
            lCI_Num7.TextVisible = false;
            // 
            // lCI_Enter
            // 
            lCI_Enter.Control = btn_Enter;
            lCI_Enter.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Enter.CustomizationFormText = "layoutControlItemEnter";
            lCI_Enter.Location = new Point(234, 210);
            lCI_Enter.MinSize = new Size(40, 26);
            lCI_Enter.Name = "lCI_Enter";
            lCI_Enter.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_Enter.OptionsTableLayoutItem.RowIndex = 3;
            lCI_Enter.OptionsTableLayoutItem.RowSpan = 2;
            lCI_Enter.Size = new Size(78, 141);
            lCI_Enter.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Enter.TextSize = new Size(0, 0);
            lCI_Enter.TextVisible = false;
            // 
            // lCI_C
            // 
            lCI_C.Control = btn_C;
            lCI_C.ControlAlignment = ContentAlignment.TopLeft;
            lCI_C.CustomizationFormText = "layoutControlItemC";
            lCI_C.Location = new Point(234, 140);
            lCI_C.MinSize = new Size(40, 26);
            lCI_C.Name = "lCI_C";
            lCI_C.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_C.OptionsTableLayoutItem.RowIndex = 2;
            lCI_C.Size = new Size(78, 70);
            lCI_C.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_C.TextSize = new Size(0, 0);
            lCI_C.TextVisible = false;
            // 
            // lCI_BackSpace
            // 
            lCI_BackSpace.Control = btn_BackSpace;
            lCI_BackSpace.ControlAlignment = ContentAlignment.TopLeft;
            lCI_BackSpace.CustomizationFormText = "layoutControlItemBackSpace";
            lCI_BackSpace.Location = new Point(234, 70);
            lCI_BackSpace.MinSize = new Size(40, 26);
            lCI_BackSpace.Name = "lCI_BackSpace";
            lCI_BackSpace.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_BackSpace.OptionsTableLayoutItem.RowIndex = 1;
            lCI_BackSpace.Size = new Size(78, 70);
            lCI_BackSpace.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_BackSpace.TextSize = new Size(0, 0);
            lCI_BackSpace.TextVisible = false;
            // 
            // lCI_ItemTextBox
            // 
            lCI_ItemTextBox.ContentHorzAlignment = HorzAlignment.Center;
            lCI_ItemTextBox.ContentVertAlignment = VertAlignment.Center;
            lCI_ItemTextBox.Control = txtEdit_Barcode;
            lCI_ItemTextBox.ControlAlignment = ContentAlignment.TopLeft;
            lCI_ItemTextBox.CustomizationFormText = "layoutControlItemTextBox";
            lCI_ItemTextBox.Location = new Point(78, 0);
            lCI_ItemTextBox.MinSize = new Size(40, 24);
            lCI_ItemTextBox.Name = "lCI_ItemTextBox";
            lCI_ItemTextBox.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_ItemTextBox.OptionsTableLayoutItem.ColumnSpan = 3;
            lCI_ItemTextBox.Size = new Size(234, 70);
            lCI_ItemTextBox.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ItemTextBox.TextSize = new Size(0, 0);
            lCI_ItemTextBox.TextVisible = false;
            // 
            // lCI_ComboBox
            // 
            lCI_ComboBox.ContentHorzAlignment = HorzAlignment.Center;
            lCI_ComboBox.ContentVertAlignment = VertAlignment.Center;
            lCI_ComboBox.Control = imageComboEdit_Barcode;
            lCI_ComboBox.ControlAlignment = ContentAlignment.TopLeft;
            lCI_ComboBox.CustomizationFormText = "layoutControlItemComboBox";
            lCI_ComboBox.Location = new Point(0, 0);
            lCI_ComboBox.MinSize = new Size(40, 24);
            lCI_ComboBox.Name = "lCI_ComboBox";
            lCI_ComboBox.Size = new Size(78, 70);
            lCI_ComboBox.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ComboBox.TextSize = new Size(0, 0);
            lCI_ComboBox.TextVisible = false;
            // 
            // lCI_Num5
            // 
            lCI_Num5.Control = btn_Num5;
            lCI_Num5.Location = new Point(78, 140);
            lCI_Num5.MinSize = new Size(78, 26);
            lCI_Num5.Name = "lCI_Num5";
            lCI_Num5.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Num5.OptionsTableLayoutItem.RowIndex = 2;
            lCI_Num5.Size = new Size(78, 70);
            lCI_Num5.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Num5.TextSize = new Size(0, 0);
            lCI_Num5.TextVisible = false;
            // 
            // lCG_Invoice
            // 
            lCG_Invoice.CustomizationFormText = "Satış";
            lCG_Invoice.Items.AddRange(new BaseLayoutItem[] { lCI_GridView });
            lCG_Invoice.Location = new Point(0, 0);
            lCG_Invoice.Name = "lCG_Invoice";
            lCG_Invoice.Size = new Size(412, 699);
            lCG_Invoice.Text = "Satış";
            // 
            // lCI_GridView
            // 
            lCI_GridView.Control = gC_InvoiceLine;
            lCI_GridView.ControlAlignment = ContentAlignment.TopLeft;
            lCI_GridView.CustomizationFormText = "layoutControlItemGridView";
            lCI_GridView.Location = new Point(0, 0);
            lCI_GridView.Name = "lCI_GridView";
            lCI_GridView.Size = new Size(388, 654);
            lCI_GridView.TextSize = new Size(0, 0);
            lCI_GridView.TextVisible = false;
            // 
            // lCG_Function
            // 
            lCG_Function.CustomizationFormText = "Əməliyat";
            lCG_Function.Items.AddRange(new BaseLayoutItem[] { lCI_ProductSearch, lCI_Discount, lCI_CancelInvoice, lCI_DeleteLine, lCI_SalesPerson, lCI_Print, lCI_PrintDesign, lCI_ReportZ });
            lCG_Function.LayoutMode = LayoutMode.Table;
            lCG_Function.Location = new Point(748, 209);
            lCG_Function.Name = "lCG_Function";
            columnDefinition5.SizeType = SizeType.Percent;
            columnDefinition5.Width = 25D;
            columnDefinition6.SizeType = SizeType.Percent;
            columnDefinition6.Width = 25D;
            columnDefinition7.SizeType = SizeType.Percent;
            columnDefinition7.Width = 25D;
            columnDefinition8.SizeType = SizeType.Percent;
            columnDefinition8.Width = 25D;
            lCG_Function.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new ColumnDefinition[] { columnDefinition5, columnDefinition6, columnDefinition7, columnDefinition8 });
            rowDefinition6.Height = 25D;
            rowDefinition6.SizeType = SizeType.Percent;
            rowDefinition7.Height = 25D;
            rowDefinition7.SizeType = SizeType.Percent;
            rowDefinition8.Height = 25D;
            rowDefinition8.SizeType = SizeType.Percent;
            rowDefinition9.Height = 25D;
            rowDefinition9.SizeType = SizeType.Percent;
            lCG_Function.OptionsTableLayoutGroup.RowDefinitions.AddRange(new RowDefinition[] { rowDefinition6, rowDefinition7, rowDefinition8, rowDefinition9 });
            lCG_Function.Size = new Size(374, 352);
            lCG_Function.Text = "Əməliyat";
            // 
            // lCI_ProductSearch
            // 
            lCI_ProductSearch.Control = btn_ProductSearch;
            lCI_ProductSearch.ControlAlignment = ContentAlignment.TopLeft;
            lCI_ProductSearch.CustomizationFormText = "layoutControlItemProductSearch";
            lCI_ProductSearch.Location = new Point(0, 0);
            lCI_ProductSearch.MinSize = new Size(78, 26);
            lCI_ProductSearch.Name = "lCI_ProductSearch";
            lCI_ProductSearch.Size = new Size(87, 76);
            lCI_ProductSearch.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ProductSearch.TextSize = new Size(0, 0);
            lCI_ProductSearch.TextVisible = false;
            // 
            // lCI_Discount
            // 
            lCI_Discount.Control = btn_Discount;
            lCI_Discount.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Discount.CustomizationFormText = "layoutControlItemDiscount";
            lCI_Discount.Location = new Point(87, 0);
            lCI_Discount.MinSize = new Size(78, 26);
            lCI_Discount.Name = "lCI_Discount";
            lCI_Discount.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Discount.Size = new Size(87, 76);
            lCI_Discount.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Discount.TextSize = new Size(0, 0);
            lCI_Discount.TextVisible = false;
            // 
            // lCI_CancelInvoice
            // 
            lCI_CancelInvoice.Control = btn_CancelInvoice;
            lCI_CancelInvoice.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CancelInvoice.CustomizationFormText = "layoutControlItemCancelInvoice";
            lCI_CancelInvoice.Location = new Point(261, 0);
            lCI_CancelInvoice.MinSize = new Size(78, 26);
            lCI_CancelInvoice.Name = "lCI_CancelInvoice";
            lCI_CancelInvoice.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_CancelInvoice.Size = new Size(89, 76);
            lCI_CancelInvoice.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CancelInvoice.TextSize = new Size(0, 0);
            lCI_CancelInvoice.TextVisible = false;
            // 
            // lCI_DeleteLine
            // 
            lCI_DeleteLine.Control = btn_DeleteLine;
            lCI_DeleteLine.ControlAlignment = ContentAlignment.TopLeft;
            lCI_DeleteLine.CustomizationFormText = "layoutControlItemDeleteLine";
            lCI_DeleteLine.Location = new Point(174, 0);
            lCI_DeleteLine.MinSize = new Size(78, 26);
            lCI_DeleteLine.Name = "lCI_DeleteLine";
            lCI_DeleteLine.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_DeleteLine.Size = new Size(87, 76);
            lCI_DeleteLine.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_DeleteLine.TextSize = new Size(0, 0);
            lCI_DeleteLine.TextVisible = false;
            // 
            // lCI_SalesPerson
            // 
            lCI_SalesPerson.Control = btn_SalesPerson;
            lCI_SalesPerson.ControlAlignment = ContentAlignment.TopLeft;
            lCI_SalesPerson.CustomizationFormText = "layoutControlItemSalesPerson";
            lCI_SalesPerson.Location = new Point(0, 76);
            lCI_SalesPerson.MinSize = new Size(78, 26);
            lCI_SalesPerson.Name = "lCI_SalesPerson";
            lCI_SalesPerson.OptionsTableLayoutItem.RowIndex = 1;
            lCI_SalesPerson.Size = new Size(87, 77);
            lCI_SalesPerson.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_SalesPerson.TextSize = new Size(0, 0);
            lCI_SalesPerson.TextVisible = false;
            // 
            // lCI_Print
            // 
            lCI_Print.Control = btn_Print;
            lCI_Print.Location = new Point(87, 76);
            lCI_Print.MinSize = new Size(78, 26);
            lCI_Print.Name = "lCI_Print";
            lCI_Print.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Print.OptionsTableLayoutItem.RowIndex = 1;
            lCI_Print.Size = new Size(87, 77);
            lCI_Print.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Print.TextSize = new Size(0, 0);
            lCI_Print.TextVisible = false;
            // 
            // lCI_PrintDesign
            // 
            lCI_PrintDesign.Control = btn_PrintDesign;
            lCI_PrintDesign.Location = new Point(174, 76);
            lCI_PrintDesign.MinSize = new Size(78, 26);
            lCI_PrintDesign.Name = "lCI_PrintDesign";
            lCI_PrintDesign.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_PrintDesign.OptionsTableLayoutItem.RowIndex = 1;
            lCI_PrintDesign.Size = new Size(87, 77);
            lCI_PrintDesign.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_PrintDesign.TextSize = new Size(0, 0);
            lCI_PrintDesign.TextVisible = false;
            // 
            // lCI_ReportZ
            // 
            lCI_ReportZ.Control = btn_ReportZ;
            lCI_ReportZ.Location = new Point(261, 76);
            lCI_ReportZ.MinSize = new Size(78, 26);
            lCI_ReportZ.Name = "lCI_ReportZ";
            lCI_ReportZ.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_ReportZ.OptionsTableLayoutItem.RowIndex = 1;
            lCI_ReportZ.Size = new Size(89, 77);
            lCI_ReportZ.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ReportZ.TextSize = new Size(0, 0);
            lCI_ReportZ.TextVisible = false;
            // 
            // lCG_Customer
            // 
            lCG_Customer.CustomizationFormText = "Müştəri";
            lCG_Customer.Items.AddRange(new BaseLayoutItem[] { lCI_CustomerSearch, lCI_BonusCardNum, lCI_CustomerAddress, lCI_CustomerTel, lCI_CustomerName, lCI_CustomerCode, lCI_CustomerAdd, lCI_CustomerEdit });
            lCG_Customer.LayoutMode = LayoutMode.Table;
            lCG_Customer.Location = new Point(748, 0);
            lCG_Customer.Name = "lCG_Customer";
            columnDefinition9.SizeType = SizeType.Percent;
            columnDefinition9.Width = 85D;
            columnDefinition10.SizeType = SizeType.Percent;
            columnDefinition10.Width = 15D;
            lCG_Customer.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new ColumnDefinition[] { columnDefinition9, columnDefinition10 });
            rowDefinition10.Height = 16.7D;
            rowDefinition10.SizeType = SizeType.Percent;
            rowDefinition11.Height = 16.7D;
            rowDefinition11.SizeType = SizeType.Percent;
            rowDefinition12.Height = 16.7D;
            rowDefinition12.SizeType = SizeType.Percent;
            rowDefinition13.Height = 16.7D;
            rowDefinition13.SizeType = SizeType.Percent;
            rowDefinition14.Height = 16.7D;
            rowDefinition14.SizeType = SizeType.Percent;
            rowDefinition15.Height = 16.7D;
            rowDefinition15.SizeType = SizeType.Percent;
            lCG_Customer.OptionsTableLayoutGroup.RowDefinitions.AddRange(new RowDefinition[] { rowDefinition10, rowDefinition11, rowDefinition12, rowDefinition13, rowDefinition14, rowDefinition15 });
            lCG_Customer.Size = new Size(374, 209);
            lCG_Customer.Text = "Müştəri";
            // 
            // lCI_CustomerSearch
            // 
            lCI_CustomerSearch.Control = btn_CustomerSearch;
            lCI_CustomerSearch.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerSearch.CustomizationFormText = "layoutControlItemCustomerSearch";
            lCI_CustomerSearch.Location = new Point(297, 0);
            lCI_CustomerSearch.MinSize = new Size(26, 26);
            lCI_CustomerSearch.Name = "lCI_CustomerSearch";
            lCI_CustomerSearch.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_CustomerSearch.OptionsTableLayoutItem.RowSpan = 2;
            lCI_CustomerSearch.Size = new Size(53, 54);
            lCI_CustomerSearch.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerSearch.TextSize = new Size(0, 0);
            lCI_CustomerSearch.TextVisible = false;
            // 
            // lCI_BonusCardNum
            // 
            lCI_BonusCardNum.Control = txtEdit_BonCardNum;
            lCI_BonusCardNum.ControlAlignment = ContentAlignment.TopLeft;
            lCI_BonusCardNum.CustomizationFormText = "Müştəri Kartı";
            lCI_BonusCardNum.Enabled = false;
            lCI_BonusCardNum.Location = new Point(0, 135);
            lCI_BonusCardNum.MinSize = new Size(119, 24);
            lCI_BonusCardNum.Name = "lCI_BonusCardNum";
            lCI_BonusCardNum.OptionsTableLayoutItem.RowIndex = 5;
            lCI_BonusCardNum.Size = new Size(297, 29);
            lCI_BonusCardNum.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_BonusCardNum.Text = "Müştəri Kartı";
            lCI_BonusCardNum.TextSize = new Size(62, 13);
            // 
            // lCI_CustomerAddress
            // 
            lCI_CustomerAddress.Control = txtEdit_CustomerAddress;
            lCI_CustomerAddress.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerAddress.CustomizationFormText = "Adres";
            lCI_CustomerAddress.Enabled = false;
            lCI_CustomerAddress.Location = new Point(0, 108);
            lCI_CustomerAddress.MinSize = new Size(119, 24);
            lCI_CustomerAddress.Name = "lCI_CustomerAddress";
            lCI_CustomerAddress.OptionsTableLayoutItem.RowIndex = 4;
            lCI_CustomerAddress.Size = new Size(297, 27);
            lCI_CustomerAddress.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerAddress.Text = "Adres";
            lCI_CustomerAddress.TextSize = new Size(62, 13);
            // 
            // lCI_CustomerTel
            // 
            lCI_CustomerTel.Control = txtEdit_CustomerPhoneNum;
            lCI_CustomerTel.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerTel.CustomizationFormText = "Telefon";
            lCI_CustomerTel.Enabled = false;
            lCI_CustomerTel.Location = new Point(0, 81);
            lCI_CustomerTel.MinSize = new Size(119, 24);
            lCI_CustomerTel.Name = "lCI_CustomerTel";
            lCI_CustomerTel.OptionsTableLayoutItem.RowIndex = 3;
            lCI_CustomerTel.Size = new Size(297, 27);
            lCI_CustomerTel.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerTel.Text = "Telefon";
            lCI_CustomerTel.TextSize = new Size(62, 13);
            // 
            // lCI_CustomerName
            // 
            lCI_CustomerName.Control = txtEdit_CustomerName;
            lCI_CustomerName.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerName.CustomizationFormText = "Adı, Soyadı";
            lCI_CustomerName.Enabled = false;
            lCI_CustomerName.Location = new Point(0, 54);
            lCI_CustomerName.MinSize = new Size(119, 24);
            lCI_CustomerName.Name = "lCI_CustomerName";
            lCI_CustomerName.OptionsTableLayoutItem.RowIndex = 2;
            lCI_CustomerName.Size = new Size(297, 27);
            lCI_CustomerName.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerName.Text = "Adı, Soyadı";
            lCI_CustomerName.TextSize = new Size(62, 13);
            // 
            // lCI_CustomerCode
            // 
            lCI_CustomerCode.Control = txtEdit_CustomerCode;
            lCI_CustomerCode.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerCode.CustomizationFormText = "Müştəri Kodu";
            lCI_CustomerCode.Enabled = false;
            lCI_CustomerCode.Location = new Point(0, 27);
            lCI_CustomerCode.MinSize = new Size(119, 24);
            lCI_CustomerCode.Name = "lCI_CustomerCode";
            lCI_CustomerCode.OptionsTableLayoutItem.RowIndex = 1;
            lCI_CustomerCode.Size = new Size(297, 27);
            lCI_CustomerCode.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerCode.Text = "Müştəri Kodu";
            lCI_CustomerCode.TextSize = new Size(62, 13);
            // 
            // lCI_CustomerAdd
            // 
            lCI_CustomerAdd.Control = btn_CustomerAdd;
            lCI_CustomerAdd.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerAdd.CustomizationFormText = "layoutControlItemCustomerAdd";
            lCI_CustomerAdd.Location = new Point(297, 54);
            lCI_CustomerAdd.MinSize = new Size(26, 26);
            lCI_CustomerAdd.Name = "lCI_CustomerAdd";
            lCI_CustomerAdd.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_CustomerAdd.OptionsTableLayoutItem.RowIndex = 2;
            lCI_CustomerAdd.OptionsTableLayoutItem.RowSpan = 2;
            lCI_CustomerAdd.Size = new Size(53, 54);
            lCI_CustomerAdd.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerAdd.TextSize = new Size(0, 0);
            lCI_CustomerAdd.TextVisible = false;
            // 
            // lCI_CustomerEdit
            // 
            lCI_CustomerEdit.Control = btn_CustomerEdit;
            lCI_CustomerEdit.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerEdit.CustomizationFormText = "layoutControlItemCustomerEdit";
            lCI_CustomerEdit.Location = new Point(297, 108);
            lCI_CustomerEdit.MinSize = new Size(26, 26);
            lCI_CustomerEdit.Name = "lCI_CustomerEdit";
            lCI_CustomerEdit.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_CustomerEdit.OptionsTableLayoutItem.RowIndex = 4;
            lCI_CustomerEdit.OptionsTableLayoutItem.RowSpan = 2;
            lCI_CustomerEdit.Size = new Size(53, 56);
            lCI_CustomerEdit.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerEdit.TextSize = new Size(0, 0);
            lCI_CustomerEdit.TextVisible = false;
            // 
            // lCG_Payment
            // 
            lCG_Payment.CustomizationFormText = "Ödəmə";
            lCG_Payment.Items.AddRange(new BaseLayoutItem[] { lCI_Cash, lCI_Cashless, lCI_CustomerBonus });
            lCG_Payment.LayoutMode = LayoutMode.Table;
            lCG_Payment.Location = new Point(748, 561);
            lCG_Payment.Name = "lCG_Payment";
            columnDefinition11.SizeType = SizeType.Percent;
            columnDefinition11.Width = 25D;
            columnDefinition12.SizeType = SizeType.Percent;
            columnDefinition12.Width = 25D;
            columnDefinition13.SizeType = SizeType.Percent;
            columnDefinition13.Width = 25D;
            columnDefinition14.SizeType = SizeType.Percent;
            columnDefinition14.Width = 25D;
            lCG_Payment.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new ColumnDefinition[] { columnDefinition11, columnDefinition12, columnDefinition13, columnDefinition14 });
            rowDefinition16.Height = 100D;
            rowDefinition16.SizeType = SizeType.Percent;
            lCG_Payment.OptionsTableLayoutGroup.RowDefinitions.AddRange(new RowDefinition[] { rowDefinition16 });
            lCG_Payment.Size = new Size(374, 138);
            lCG_Payment.Text = "Ödəmə";
            // 
            // lCI_Cash
            // 
            lCI_Cash.Control = btn_Cash;
            lCI_Cash.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Cash.CustomizationFormText = "layoutControlItemCash";
            lCI_Cash.Location = new Point(0, 0);
            lCI_Cash.MinSize = new Size(40, 26);
            lCI_Cash.Name = "lCI_Cash";
            lCI_Cash.Size = new Size(87, 93);
            lCI_Cash.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Cash.TextSize = new Size(0, 0);
            lCI_Cash.TextVisible = false;
            // 
            // lCI_Cashless
            // 
            lCI_Cashless.Control = btn_Cashless;
            lCI_Cashless.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Cashless.CustomizationFormText = "layoutControlItemCashless";
            lCI_Cashless.Location = new Point(87, 0);
            lCI_Cashless.MinSize = new Size(40, 26);
            lCI_Cashless.Name = "lCI_Cashless";
            lCI_Cashless.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Cashless.Size = new Size(87, 93);
            lCI_Cashless.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Cashless.TextSize = new Size(0, 0);
            lCI_Cashless.TextVisible = false;
            // 
            // lCI_CustomerBonus
            // 
            lCI_CustomerBonus.Control = btn_CustomerBonus;
            lCI_CustomerBonus.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerBonus.CustomizationFormText = "layoutControlItemCustomerBonus";
            lCI_CustomerBonus.Location = new Point(174, 0);
            lCI_CustomerBonus.MinSize = new Size(40, 26);
            lCI_CustomerBonus.Name = "lCI_CustomerBonus";
            lCI_CustomerBonus.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_CustomerBonus.Size = new Size(87, 93);
            lCI_CustomerBonus.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerBonus.TextSize = new Size(0, 0);
            lCI_CustomerBonus.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.CustomizationFormText = "layoutControlGroup1";
            layoutControlGroup2.Location = new Point(412, 396);
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new Size(336, 303);
            layoutControlGroup2.Text = "layoutControlGroup1";
            // 
            // UcSale
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lC_InvoiceLine);
            Name = "UcSale";
            Size = new Size(1142, 719);
            Load += UcSale_Load;
            ((ISupportInitialize)lC_InvoiceLine).EndInit();
            lC_InvoiceLine.ResumeLayout(false);
            ((ISupportInitialize)txtEdit_Barcode.Properties).EndInit();
            ((ISupportInitialize)imageComboEdit_Barcode.Properties).EndInit();
            ((ISupportInitialize)gC_InvoiceLine).EndInit();
            ((ISupportInitialize)gV_InvoiceLine).EndInit();
            ((ISupportInitialize)txtEdit_CustomerPhoneNum.Properties).EndInit();
            ((ISupportInitialize)txtEdit_CustomerAddress.Properties).EndInit();
            ((ISupportInitialize)txtEdit_CustomerName.Properties).EndInit();
            ((ISupportInitialize)txtEdit_BonCardNum.Properties).EndInit();
            ((ISupportInitialize)txtEdit_CustomerCode.Properties).EndInit();
            ((ISupportInitialize)lCG_Root).EndInit();
            ((ISupportInitialize)lCG_Barcode).EndInit();
            ((ISupportInitialize)lCI_Star).EndInit();
            ((ISupportInitialize)lCI_Comma).EndInit();
            ((ISupportInitialize)lCI_Num0).EndInit();
            ((ISupportInitialize)lCI_Num1).EndInit();
            ((ISupportInitialize)lCI_Num2).EndInit();
            ((ISupportInitialize)lCI_Num3).EndInit();
            ((ISupportInitialize)lCI_Num4).EndInit();
            ((ISupportInitialize)lCI_Num6).EndInit();
            ((ISupportInitialize)lCI_Num8).EndInit();
            ((ISupportInitialize)lCI_Num9).EndInit();
            ((ISupportInitialize)lCI_Num7).EndInit();
            ((ISupportInitialize)lCI_Enter).EndInit();
            ((ISupportInitialize)lCI_C).EndInit();
            ((ISupportInitialize)lCI_BackSpace).EndInit();
            ((ISupportInitialize)lCI_ItemTextBox).EndInit();
            ((ISupportInitialize)lCI_ComboBox).EndInit();
            ((ISupportInitialize)lCI_Num5).EndInit();
            ((ISupportInitialize)lCG_Invoice).EndInit();
            ((ISupportInitialize)lCI_GridView).EndInit();
            ((ISupportInitialize)lCG_Function).EndInit();
            ((ISupportInitialize)lCI_ProductSearch).EndInit();
            ((ISupportInitialize)lCI_Discount).EndInit();
            ((ISupportInitialize)lCI_CancelInvoice).EndInit();
            ((ISupportInitialize)lCI_DeleteLine).EndInit();
            ((ISupportInitialize)lCI_SalesPerson).EndInit();
            ((ISupportInitialize)lCI_Print).EndInit();
            ((ISupportInitialize)lCI_PrintDesign).EndInit();
            ((ISupportInitialize)lCI_ReportZ).EndInit();
            ((ISupportInitialize)lCG_Customer).EndInit();
            ((ISupportInitialize)lCI_CustomerSearch).EndInit();
            ((ISupportInitialize)lCI_BonusCardNum).EndInit();
            ((ISupportInitialize)lCI_CustomerAddress).EndInit();
            ((ISupportInitialize)lCI_CustomerTel).EndInit();
            ((ISupportInitialize)lCI_CustomerName).EndInit();
            ((ISupportInitialize)lCI_CustomerCode).EndInit();
            ((ISupportInitialize)lCI_CustomerAdd).EndInit();
            ((ISupportInitialize)lCI_CustomerEdit).EndInit();
            ((ISupportInitialize)lCG_Payment).EndInit();
            ((ISupportInitialize)lCI_Cash).EndInit();
            ((ISupportInitialize)lCI_Cashless).EndInit();
            ((ISupportInitialize)lCI_CustomerBonus).EndInit();
            ((ISupportInitialize)layoutControlGroup2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LayoutControl lC_InvoiceLine;
        private LayoutControlGroup lCG_Root;
        private SimpleButton btn_Star;
        private SimpleButton btn_Comma;
        private SimpleButton btn_Num0;
        private SimpleButton btn_Num1;
        private SimpleButton btn_Num2;
        private SimpleButton btn_Num3;
        private SimpleButton btn_Num4;
        private SimpleButton btn_Num6;
        private SimpleButton btn_Num8;
        private SimpleButton btn_Num9;
        private SimpleButton btn_Num7;
        public SimpleButton btn_Enter;
        private SimpleButton btn_C;
        private SimpleButton btn_BackSpace;
        private TextEdit txtEdit_Barcode;
        private ImageComboBoxEdit imageComboEdit_Barcode;
        private GridControl gC_InvoiceLine;
        private GridView gV_InvoiceLine;
        private GridColumn col_Qty;
        private GridColumn col_Price;
        private GridColumn col_NetAmount;
        private GridColumn col_Barcode;
        private GridColumn col_PosDiscount;
        private GridColumn col_Amount;
        private GridColumn col_VatRate;
        private SimpleButton btn_ProductSearch;
        private SimpleButton btn_Discount;
        private SimpleButton btn_CancelInvoice;
        private SimpleButton btn_DeleteLine;
        private SimpleButton btn_SalesPerson;
        private TextEdit txtEdit_CustomerPhoneNum;
        private TextEdit txtEdit_CustomerAddress;
        private TextEdit txtEdit_CustomerName;
        private SimpleButton btn_CustomerSearch;
        private SimpleButton btn_CustomerEdit;
        private SimpleButton btn_CustomerAdd;
        private TextEdit txtEdit_BonCardNum;
        private TextEdit txtEdit_CustomerCode;
        private SimpleButton btn_Cash;
        private SimpleButton btn_Cashless;
        private SimpleButton btn_CustomerBonus;
        private LayoutControlGroup lCG_Barcode;
        private LayoutControlItem lCI_Star;
        private LayoutControlItem lCI_Comma;
        private LayoutControlItem lCI_Num0;
        private LayoutControlItem lCI_Num1;
        private LayoutControlItem lCI_Num2;
        private LayoutControlItem lCI_Num3;
        private LayoutControlItem lCI_Num4;
        private LayoutControlItem lCI_Num6;
        private LayoutControlItem lCI_Num8;
        private LayoutControlItem lCI_Num9;
        private LayoutControlItem lCI_Num7;
        private LayoutControlItem lCI_Enter;
        private LayoutControlItem lCI_C;
        private LayoutControlItem lCI_BackSpace;
        private LayoutControlItem lCI_ItemTextBox;
        private LayoutControlItem lCI_ComboBox;
        private LayoutControlGroup lCG_Invoice;
        private LayoutControlItem lCI_GridView;
        private LayoutControlGroup lCG_Function;
        private LayoutControlItem lCI_ProductSearch;
        private LayoutControlItem lCI_Discount;
        private LayoutControlItem lCI_CancelInvoice;
        private LayoutControlItem lCI_DeleteLine;
        private LayoutControlItem lCI_SalesPerson;
        private LayoutControlGroup lCG_Customer;
        private LayoutControlItem lCI_CustomerTel;
        private LayoutControlItem lCI_CustomerAddress;
        private LayoutControlItem lCI_CustomerName;
        private LayoutControlItem lCI_CustomerSearch;
        private LayoutControlItem lCI_CustomerEdit;
        private LayoutControlItem lCI_CustomerAdd;
        private LayoutControlItem lCI_BonusCardNum;
        private LayoutControlItem lCI_CustomerCode;
        private LayoutControlGroup lCG_Payment;
        private LayoutControlItem lCI_Cash;
        private LayoutControlItem lCI_Cashless;
        private LayoutControlItem lCI_CustomerBonus;
        private LayoutControlGroup layoutControlGroup2;
        private SimpleButton btn_Print;
        private LayoutControlItem lCI_Print;
        private SimpleButton btn_PrintDesign;
        private LayoutControlItem lCI_PrintDesign;
        private SimpleButton btn_ReportZ;
        private LayoutControlItem lCI_ReportZ;
        private GridColumn col_SalesPersonCode;
        private SimpleButton btn_Num5;
        private LayoutControlItem lCI_Num5;
        private GridColumn col_ProductDesc;
    }
}
