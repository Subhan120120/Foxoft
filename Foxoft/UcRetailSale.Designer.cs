
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
using Foxoft.Models;

namespace Foxoft
{
    partial class UcRetailSale
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UcRetailSale));
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();
            ColumnDefinition columnDefinition3 = new ColumnDefinition();
            ColumnDefinition columnDefinition4 = new ColumnDefinition();
            RowDefinition rowDefinition1 = new RowDefinition();
            RowDefinition rowDefinition2 = new RowDefinition();
            RowDefinition rowDefinition3 = new RowDefinition();
            RowDefinition rowDefinition4 = new RowDefinition();
            ColumnDefinition columnDefinition5 = new ColumnDefinition();
            ColumnDefinition columnDefinition6 = new ColumnDefinition();
            ColumnDefinition columnDefinition7 = new ColumnDefinition();
            ColumnDefinition columnDefinition8 = new ColumnDefinition();
            RowDefinition rowDefinition5 = new RowDefinition();
            lC_InvoiceLine = new LayoutControl();
            lbl_InvoicePaidTotalSum = new LabelControl();
            lbl_InvoicePaidTotalSumTxt = new LabelControl();
            lbl_InvoicePaidCashlessSum = new LabelControl();
            lbl_InvoicePaidCashlessSumTxt = new LabelControl();
            labelControl2 = new LabelControl();
            lbl_InvoicePaidCashSumTxt = new LabelControl();
            txt_PrintCount = new TextEdit();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            CurrAccCodeTextEdit = new TextEdit();
            dcCurrAccBindingSource = new BindingSource(components);
            CurrAccDescTextEdit = new TextEdit();
            BonusCardNumTextEdit = new TextEdit();
            AddressTextEdit = new TextEdit();
            PhoneNumTextEdit = new TextEdit();
            btn_CustomerSearch = new SimpleButton();
            btn_CustomerAdd = new SimpleButton();
            btn_CustomerEdit = new SimpleButton();
            Root = new LayoutControlGroup();
            layoutControlGroup1 = new LayoutControlGroup();
            ItemForCurrAccCode = new LayoutControlItem();
            ItemForCurrAccDesc = new LayoutControlItem();
            ItemForBonusCardNum = new LayoutControlItem();
            ItemForAddress = new LayoutControlItem();
            ItemForPhoneNum = new LayoutControlItem();
            layoutControlItem3 = new LayoutControlItem();
            layoutControlItem4 = new LayoutControlItem();
            layoutControlItem5 = new LayoutControlItem();
            ucNumberPad1 = new UCNumberPad();
            txtEdit_Barcode = new TextEdit();
            imageComboEdit_Barcode = new ImageComboBoxEdit();
            gC_InvoiceLine = new GridControl();
            trInvoiceLinesBindingSource = new BindingSource(components);
            gV_InvoiceLine = new GridView();
            colInvoiceHeaderId = new GridColumn();
            colInvoiceLineId = new GridColumn();
            colProductCode = new GridColumn();
            col_ProductDesc = new GridColumn();
            col_Qty = new GridColumn();
            col_Price = new GridColumn();
            col_NetAmount = new GridColumn();
            col_Barcode = new GridColumn();
            col_PosDiscount = new GridColumn();
            col_Amount = new GridColumn();
            colProductCost = new GridColumn();
            col_VatRate = new GridColumn();
            col_SalesPersonCode = new GridColumn();
            colCreatedDate = new GridColumn();
            colCreatedUserName = new GridColumn();
            colExchangeRate = new GridColumn();
            colCurrencyCode = new GridColumn();
            colQtyOut = new GridColumn();
            btn_ProductSearch = new SimpleButton();
            btn_Discount = new SimpleButton();
            btn_CancelInvoice = new SimpleButton();
            btn_DeleteLine = new SimpleButton();
            btn_SalesPerson = new SimpleButton();
            btn_Cash = new SimpleButton();
            btn_Cashless = new SimpleButton();
            btn_CustomerBonus = new SimpleButton();
            btn_Print = new SimpleButton();
            btn_PrintPreview = new SimpleButton();
            btn_ReportZ = new SimpleButton();
            btn_NewInvoice = new SimpleButton();
            btn_IncomplatedInvoices = new SimpleButton();
            lCG_Root = new LayoutControlGroup();
            lCG_Barcode = new LayoutControlGroup();
            lCI_ComboBox = new LayoutControlItem();
            LCI_Barcode = new LayoutControlItem();
            layoutControlItem1 = new LayoutControlItem();
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
            LCI_NewInvoice = new LayoutControlItem();
            layoutControlItem8 = new LayoutControlItem();
            lCG_Payment = new LayoutControlGroup();
            lCI_Cash = new LayoutControlItem();
            lCI_Cashless = new LayoutControlItem();
            lCI_CustomerBonus = new LayoutControlItem();
            LCG_Total = new LayoutControlGroup();
            layoutControlItem6 = new LayoutControlItem();
            layoutControlGroup3 = new LayoutControlGroup();
            layoutControlItem7 = new LayoutControlItem();
            lbl_InvoicePaidCashSum = new LayoutControlItem();
            layoutControlItem10 = new LayoutControlItem();
            layoutControlItem12 = new LayoutControlItem();
            layoutControlItem13 = new LayoutControlItem();
            layoutControlItem11 = new LayoutControlItem();
            emptySpaceItem1 = new EmptySpaceItem();
            emptySpaceItem2 = new EmptySpaceItem();
            layoutControlGroup2 = new LayoutControlGroup();
            layoutControlItem2 = new LayoutControlItem();
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            trInvoiceHeadersBindingSource = new BindingSource(components);
            ((ISupportInitialize)lC_InvoiceLine).BeginInit();
            lC_InvoiceLine.SuspendLayout();
            ((ISupportInitialize)txt_PrintCount.Properties).BeginInit();
            ((ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((ISupportInitialize)CurrAccCodeTextEdit.Properties).BeginInit();
            ((ISupportInitialize)dcCurrAccBindingSource).BeginInit();
            ((ISupportInitialize)CurrAccDescTextEdit.Properties).BeginInit();
            ((ISupportInitialize)BonusCardNumTextEdit.Properties).BeginInit();
            ((ISupportInitialize)AddressTextEdit.Properties).BeginInit();
            ((ISupportInitialize)PhoneNumTextEdit.Properties).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)layoutControlGroup1).BeginInit();
            ((ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((ISupportInitialize)ItemForCurrAccDesc).BeginInit();
            ((ISupportInitialize)ItemForBonusCardNum).BeginInit();
            ((ISupportInitialize)ItemForAddress).BeginInit();
            ((ISupportInitialize)ItemForPhoneNum).BeginInit();
            ((ISupportInitialize)layoutControlItem3).BeginInit();
            ((ISupportInitialize)layoutControlItem4).BeginInit();
            ((ISupportInitialize)layoutControlItem5).BeginInit();
            ((ISupportInitialize)txtEdit_Barcode.Properties).BeginInit();
            ((ISupportInitialize)imageComboEdit_Barcode.Properties).BeginInit();
            ((ISupportInitialize)gC_InvoiceLine).BeginInit();
            ((ISupportInitialize)trInvoiceLinesBindingSource).BeginInit();
            ((ISupportInitialize)gV_InvoiceLine).BeginInit();
            ((ISupportInitialize)lCG_Root).BeginInit();
            ((ISupportInitialize)lCG_Barcode).BeginInit();
            ((ISupportInitialize)lCI_ComboBox).BeginInit();
            ((ISupportInitialize)LCI_Barcode).BeginInit();
            ((ISupportInitialize)layoutControlItem1).BeginInit();
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
            ((ISupportInitialize)LCI_NewInvoice).BeginInit();
            ((ISupportInitialize)layoutControlItem8).BeginInit();
            ((ISupportInitialize)lCG_Payment).BeginInit();
            ((ISupportInitialize)lCI_Cash).BeginInit();
            ((ISupportInitialize)lCI_Cashless).BeginInit();
            ((ISupportInitialize)lCI_CustomerBonus).BeginInit();
            ((ISupportInitialize)LCG_Total).BeginInit();
            ((ISupportInitialize)layoutControlItem6).BeginInit();
            ((ISupportInitialize)layoutControlGroup3).BeginInit();
            ((ISupportInitialize)layoutControlItem7).BeginInit();
            ((ISupportInitialize)lbl_InvoicePaidCashSum).BeginInit();
            ((ISupportInitialize)layoutControlItem10).BeginInit();
            ((ISupportInitialize)layoutControlItem12).BeginInit();
            ((ISupportInitialize)layoutControlItem13).BeginInit();
            ((ISupportInitialize)layoutControlItem11).BeginInit();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            ((ISupportInitialize)emptySpaceItem2).BeginInit();
            ((ISupportInitialize)layoutControlGroup2).BeginInit();
            ((ISupportInitialize)layoutControlItem2).BeginInit();
            ((ISupportInitialize)trInvoiceHeadersBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lC_InvoiceLine
            // 
            lC_InvoiceLine.Controls.Add(lbl_InvoicePaidTotalSum);
            lC_InvoiceLine.Controls.Add(lbl_InvoicePaidTotalSumTxt);
            lC_InvoiceLine.Controls.Add(lbl_InvoicePaidCashlessSum);
            lC_InvoiceLine.Controls.Add(lbl_InvoicePaidCashlessSumTxt);
            lC_InvoiceLine.Controls.Add(labelControl2);
            lC_InvoiceLine.Controls.Add(lbl_InvoicePaidCashSumTxt);
            lC_InvoiceLine.Controls.Add(txt_PrintCount);
            lC_InvoiceLine.Controls.Add(dataLayoutControl1);
            lC_InvoiceLine.Controls.Add(ucNumberPad1);
            lC_InvoiceLine.Controls.Add(txtEdit_Barcode);
            lC_InvoiceLine.Controls.Add(imageComboEdit_Barcode);
            lC_InvoiceLine.Controls.Add(gC_InvoiceLine);
            lC_InvoiceLine.Controls.Add(btn_ProductSearch);
            lC_InvoiceLine.Controls.Add(btn_Discount);
            lC_InvoiceLine.Controls.Add(btn_CancelInvoice);
            lC_InvoiceLine.Controls.Add(btn_DeleteLine);
            lC_InvoiceLine.Controls.Add(btn_SalesPerson);
            lC_InvoiceLine.Controls.Add(btn_Cash);
            lC_InvoiceLine.Controls.Add(btn_Cashless);
            lC_InvoiceLine.Controls.Add(btn_CustomerBonus);
            lC_InvoiceLine.Controls.Add(btn_Print);
            lC_InvoiceLine.Controls.Add(btn_PrintPreview);
            lC_InvoiceLine.Controls.Add(btn_ReportZ);
            lC_InvoiceLine.Controls.Add(btn_NewInvoice);
            lC_InvoiceLine.Controls.Add(btn_IncomplatedInvoices);
            lC_InvoiceLine.Dock = DockStyle.Fill;
            lC_InvoiceLine.Location = new Point(0, 0);
            lC_InvoiceLine.Name = "lC_InvoiceLine";
            lC_InvoiceLine.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1189, 400, 650, 400);
            lC_InvoiceLine.Root = lCG_Root;
            lC_InvoiceLine.Size = new Size(1075, 650);
            lC_InvoiceLine.TabIndex = 0;
            lC_InvoiceLine.Text = "layoutControl1";
            // 
            // lbl_InvoicePaidTotalSum
            // 
            lbl_InvoicePaidTotalSum.Appearance.Font = new Font("Tahoma", 12F);
            lbl_InvoicePaidTotalSum.Appearance.Options.UseFont = true;
            lbl_InvoicePaidTotalSum.Location = new Point(621, 595);
            lbl_InvoicePaidTotalSum.Name = "lbl_InvoicePaidTotalSum";
            lbl_InvoicePaidTotalSum.Size = new Size(68, 19);
            lbl_InvoicePaidTotalSum.StyleController = lC_InvoiceLine;
            lbl_InvoicePaidTotalSum.TabIndex = 1;
            lbl_InvoicePaidTotalSum.Text = "0.00 AZN";
            // 
            // lbl_InvoicePaidTotalSumTxt
            // 
            lbl_InvoicePaidTotalSumTxt.Appearance.Font = new Font("Tahoma", 12F);
            lbl_InvoicePaidTotalSumTxt.Appearance.Options.UseFont = true;
            lbl_InvoicePaidTotalSumTxt.Location = new Point(552, 595);
            lbl_InvoicePaidTotalSumTxt.Name = "lbl_InvoicePaidTotalSumTxt";
            lbl_InvoicePaidTotalSumTxt.Size = new Size(65, 19);
            lbl_InvoicePaidTotalSumTxt.StyleController = lC_InvoiceLine;
            lbl_InvoicePaidTotalSumTxt.TabIndex = 1;
            lbl_InvoicePaidTotalSumTxt.Text = "Ödənilib:";
            // 
            // lbl_InvoicePaidCashlessSum
            // 
            lbl_InvoicePaidCashlessSum.Appearance.Font = new Font("Tahoma", 12F);
            lbl_InvoicePaidCashlessSum.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashlessSum.Location = new Point(621, 572);
            lbl_InvoicePaidCashlessSum.Name = "lbl_InvoicePaidCashlessSum";
            lbl_InvoicePaidCashlessSum.Size = new Size(68, 19);
            lbl_InvoicePaidCashlessSum.StyleController = lC_InvoiceLine;
            lbl_InvoicePaidCashlessSum.TabIndex = 1;
            lbl_InvoicePaidCashlessSum.Text = "0.00 AZN";
            // 
            // lbl_InvoicePaidCashlessSumTxt
            // 
            lbl_InvoicePaidCashlessSumTxt.Appearance.Font = new Font("Tahoma", 12F);
            lbl_InvoicePaidCashlessSumTxt.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashlessSumTxt.Location = new Point(556, 572);
            lbl_InvoicePaidCashlessSumTxt.Name = "lbl_InvoicePaidCashlessSumTxt";
            lbl_InvoicePaidCashlessSumTxt.Size = new Size(61, 19);
            lbl_InvoicePaidCashlessSumTxt.StyleController = lC_InvoiceLine;
            lbl_InvoicePaidCashlessSumTxt.TabIndex = 1;
            lbl_InvoicePaidCashlessSumTxt.Text = "Nağdsız:";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new Font("Tahoma", 12F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new Point(621, 549);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(68, 19);
            labelControl2.StyleController = lC_InvoiceLine;
            labelControl2.TabIndex = 1;
            labelControl2.Text = "0.00 AZN";
            // 
            // lbl_InvoicePaidCashSumTxt
            // 
            lbl_InvoicePaidCashSumTxt.Appearance.Font = new Font("Tahoma", 12F);
            lbl_InvoicePaidCashSumTxt.Appearance.Options.UseFont = true;
            lbl_InvoicePaidCashSumTxt.Location = new Point(574, 549);
            lbl_InvoicePaidCashSumTxt.Name = "lbl_InvoicePaidCashSumTxt";
            lbl_InvoicePaidCashSumTxt.Size = new Size(43, 19);
            lbl_InvoicePaidCashSumTxt.StyleController = lC_InvoiceLine;
            lbl_InvoicePaidCashSumTxt.TabIndex = 1;
            lbl_InvoicePaidCashSumTxt.Text = "Nağd:";
            // 
            // txt_PrintCount
            // 
            txt_PrintCount.Location = new Point(480, 414);
            txt_PrintCount.Name = "txt_PrintCount";
            txt_PrintCount.Size = new Size(221, 20);
            txt_PrintCount.StyleController = lC_InvoiceLine;
            txt_PrintCount.TabIndex = 7;
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(CurrAccCodeTextEdit);
            dataLayoutControl1.Controls.Add(CurrAccDescTextEdit);
            dataLayoutControl1.Controls.Add(BonusCardNumTextEdit);
            dataLayoutControl1.Controls.Add(AddressTextEdit);
            dataLayoutControl1.Controls.Add(PhoneNumTextEdit);
            dataLayoutControl1.Controls.Add(btn_CustomerSearch);
            dataLayoutControl1.Controls.Add(btn_CustomerAdd);
            dataLayoutControl1.Controls.Add(btn_CustomerEdit);
            dataLayoutControl1.DataSource = dcCurrAccBindingSource;
            dataLayoutControl1.Location = new Point(729, 45);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(322, 146);
            dataLayoutControl1.TabIndex = 5;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // CurrAccCodeTextEdit
            // 
            CurrAccCodeTextEdit.DataBindings.Add(new Binding("EditValue", dcCurrAccBindingSource, "CurrAccCode", true));
            CurrAccCodeTextEdit.Location = new Point(103, 12);
            CurrAccCodeTextEdit.Name = "CurrAccCodeTextEdit";
            CurrAccCodeTextEdit.Properties.AllowNullInput = DefaultBoolean.False;
            CurrAccCodeTextEdit.Size = new Size(163, 20);
            CurrAccCodeTextEdit.StyleController = dataLayoutControl1;
            CurrAccCodeTextEdit.TabIndex = 4;
            // 
            // dcCurrAccBindingSource
            // 
            dcCurrAccBindingSource.DataSource = typeof(DcCurrAcc);
            dcCurrAccBindingSource.AddingNew += dcCurrAccBindingSource_AddingNew;
            // 
            // CurrAccDescTextEdit
            // 
            CurrAccDescTextEdit.DataBindings.Add(new Binding("EditValue", dcCurrAccBindingSource, "CurrAccDesc", true));
            CurrAccDescTextEdit.Location = new Point(103, 36);
            CurrAccDescTextEdit.Name = "CurrAccDescTextEdit";
            CurrAccDescTextEdit.Size = new Size(163, 20);
            CurrAccDescTextEdit.StyleController = dataLayoutControl1;
            CurrAccDescTextEdit.TabIndex = 5;
            // 
            // BonusCardNumTextEdit
            // 
            BonusCardNumTextEdit.DataBindings.Add(new Binding("EditValue", dcCurrAccBindingSource, "BonusCardNum", true));
            BonusCardNumTextEdit.Location = new Point(103, 60);
            BonusCardNumTextEdit.Name = "BonusCardNumTextEdit";
            BonusCardNumTextEdit.Size = new Size(163, 20);
            BonusCardNumTextEdit.StyleController = dataLayoutControl1;
            BonusCardNumTextEdit.TabIndex = 6;
            // 
            // AddressTextEdit
            // 
            AddressTextEdit.DataBindings.Add(new Binding("EditValue", dcCurrAccBindingSource, "Address", true));
            AddressTextEdit.Location = new Point(103, 84);
            AddressTextEdit.Name = "AddressTextEdit";
            AddressTextEdit.Size = new Size(163, 20);
            AddressTextEdit.StyleController = dataLayoutControl1;
            AddressTextEdit.TabIndex = 7;
            // 
            // PhoneNumTextEdit
            // 
            PhoneNumTextEdit.DataBindings.Add(new Binding("EditValue", dcCurrAccBindingSource, "PhoneNum", true));
            PhoneNumTextEdit.Location = new Point(103, 108);
            PhoneNumTextEdit.Name = "PhoneNumTextEdit";
            PhoneNumTextEdit.Properties.Mask.EditMask = "(999) 000-0000";
            PhoneNumTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            PhoneNumTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PhoneNumTextEdit.Size = new Size(163, 20);
            PhoneNumTextEdit.StyleController = dataLayoutControl1;
            PhoneNumTextEdit.TabIndex = 8;
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
            btn_CustomerSearch.ButtonStyle = BorderStyles.UltraFlat;
            btn_CustomerSearch.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerSearch.ImageOptions.Image");
            btn_CustomerSearch.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerSearch.Location = new Point(270, 12);
            btn_CustomerSearch.Name = "btn_CustomerSearch";
            btn_CustomerSearch.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerSearch.Size = new Size(40, 38);
            btn_CustomerSearch.StyleController = dataLayoutControl1;
            btn_CustomerSearch.TabIndex = 32;
            btn_CustomerSearch.Text = "simpleButton3";
            btn_CustomerSearch.Click += btn_CustomerSearch_Click;
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
            btn_CustomerAdd.ButtonStyle = BorderStyles.UltraFlat;
            btn_CustomerAdd.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerAdd.ImageOptions.Image");
            btn_CustomerAdd.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerAdd.Location = new Point(270, 54);
            btn_CustomerAdd.Name = "btn_CustomerAdd";
            btn_CustomerAdd.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerAdd.Size = new Size(40, 38);
            btn_CustomerAdd.StyleController = dataLayoutControl1;
            btn_CustomerAdd.TabIndex = 31;
            btn_CustomerAdd.Text = "simpleButton1";
            btn_CustomerAdd.Click += btn_CustomerAdd_Click;
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
            btn_CustomerEdit.ButtonStyle = BorderStyles.UltraFlat;
            btn_CustomerEdit.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerEdit.ImageOptions.Image");
            btn_CustomerEdit.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerEdit.Location = new Point(270, 96);
            btn_CustomerEdit.Name = "btn_CustomerEdit";
            btn_CustomerEdit.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerEdit.Size = new Size(40, 38);
            btn_CustomerEdit.StyleController = dataLayoutControl1;
            btn_CustomerEdit.TabIndex = 33;
            btn_CustomerEdit.Text = "simpleButton4";
            btn_CustomerEdit.Click += Btn_CustomerEdit_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(322, 146);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new BaseLayoutItem[] { ItemForCurrAccCode, ItemForCurrAccDesc, ItemForBonusCardNum, ItemForAddress, ItemForPhoneNum, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(302, 126);
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = CurrAccCodeTextEdit;
            ItemForCurrAccCode.Location = new Point(0, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(258, 24);
            ItemForCurrAccCode.TextSize = new Size(79, 13);
            // 
            // ItemForCurrAccDesc
            // 
            ItemForCurrAccDesc.Control = CurrAccDescTextEdit;
            ItemForCurrAccDesc.Location = new Point(0, 24);
            ItemForCurrAccDesc.Name = "ItemForCurrAccDesc";
            ItemForCurrAccDesc.Size = new Size(258, 24);
            ItemForCurrAccDesc.TextSize = new Size(79, 13);
            // 
            // ItemForBonusCardNum
            // 
            ItemForBonusCardNum.Control = BonusCardNumTextEdit;
            ItemForBonusCardNum.Location = new Point(0, 48);
            ItemForBonusCardNum.Name = "ItemForBonusCardNum";
            ItemForBonusCardNum.Size = new Size(258, 24);
            ItemForBonusCardNum.TextSize = new Size(79, 13);
            // 
            // ItemForAddress
            // 
            ItemForAddress.Control = AddressTextEdit;
            ItemForAddress.Location = new Point(0, 72);
            ItemForAddress.Name = "ItemForAddress";
            ItemForAddress.Size = new Size(258, 24);
            ItemForAddress.TextSize = new Size(79, 13);
            // 
            // ItemForPhoneNum
            // 
            ItemForPhoneNum.Control = PhoneNumTextEdit;
            ItemForPhoneNum.Location = new Point(0, 96);
            ItemForPhoneNum.Name = "ItemForPhoneNum";
            ItemForPhoneNum.Size = new Size(258, 30);
            ItemForPhoneNum.TextSize = new Size(79, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btn_CustomerSearch;
            layoutControlItem3.Location = new Point(258, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(44, 42);
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btn_CustomerAdd;
            layoutControlItem4.Location = new Point(258, 42);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(44, 42);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = btn_CustomerEdit;
            layoutControlItem5.Location = new Point(258, 84);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(44, 42);
            layoutControlItem5.TextSize = new Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // ucNumberPad1
            // 
            ucNumberPad1.Location = new Point(426, 87);
            ucNumberPad1.Name = "ucNumberPad1";
            ucNumberPad1.Size = new Size(275, 278);
            ucNumberPad1.TabIndex = 4;
            // 
            // txtEdit_Barcode
            // 
            txtEdit_Barcode.Location = new Point(482, 47);
            txtEdit_Barcode.Name = "txtEdit_Barcode";
            txtEdit_Barcode.Properties.Appearance.Font = new Font("Tahoma", 17F);
            txtEdit_Barcode.Properties.Appearance.Options.UseFont = true;
            txtEdit_Barcode.Size = new Size(219, 34);
            txtEdit_Barcode.StyleController = lC_InvoiceLine;
            txtEdit_Barcode.TabIndex = 3;
            txtEdit_Barcode.KeyDown += TxtEdit_Barcode_KeyDown;
            // 
            // imageComboEdit_Barcode
            // 
            imageComboEdit_Barcode.Location = new Point(426, 46);
            imageComboEdit_Barcode.Name = "imageComboEdit_Barcode";
            imageComboEdit_Barcode.Properties.AllowFocused = false;
            imageComboEdit_Barcode.Properties.Appearance.Font = new Font("Tahoma", 15F);
            imageComboEdit_Barcode.Properties.Appearance.Options.UseFont = true;
            imageComboEdit_Barcode.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            imageComboEdit_Barcode.Properties.ContextImageOptions.Alignment = ContextImageAlignment.Far;
            imageComboEdit_Barcode.Properties.ContextImageOptions.Image = (Image)resources.GetObject("imageComboEdit_Barcode.Properties.ContextImageOptions.Image");
            imageComboEdit_Barcode.Properties.ContextImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("imageComboEdit_Barcode.Properties.ContextImageOptions.SvgImage");
            imageComboEdit_Barcode.Properties.DisplayFormat.FormatType = FormatType.Custom;
            imageComboEdit_Barcode.Size = new Size(52, 36);
            imageComboEdit_Barcode.StyleController = lC_InvoiceLine;
            imageComboEdit_Barcode.TabIndex = 2;
            // 
            // gC_InvoiceLine
            // 
            gC_InvoiceLine.DataSource = trInvoiceLinesBindingSource;
            gC_InvoiceLine.Location = new Point(24, 45);
            gC_InvoiceLine.MainView = gV_InvoiceLine;
            gC_InvoiceLine.Name = "gC_InvoiceLine";
            gC_InvoiceLine.Size = new Size(374, 581);
            gC_InvoiceLine.TabIndex = 0;
            gC_InvoiceLine.ViewCollection.AddRange(new BaseView[] { gV_InvoiceLine });
            gC_InvoiceLine.DoubleClick += gC_Sale_DoubleClick;
            gC_InvoiceLine.MouseUp += gC_Sale_MouseUp;
            // 
            // trInvoiceLinesBindingSource
            // 
            trInvoiceLinesBindingSource.DataSource = typeof(TrInvoiceLine);
            // 
            // gV_InvoiceLine
            // 
            gV_InvoiceLine.Appearance.FooterPanel.Font = new Font("Tahoma", 12F);
            gV_InvoiceLine.Appearance.FooterPanel.Options.UseFont = true;
            gV_InvoiceLine.Appearance.HideSelectionRow.BackColor = Color.FromArgb(206, 221, 245);
            gV_InvoiceLine.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gV_InvoiceLine.Appearance.Row.Font = new Font("Tahoma", 12F);
            gV_InvoiceLine.Appearance.Row.Options.UseFont = true;
            gV_InvoiceLine.Columns.AddRange(new GridColumn[] { colInvoiceHeaderId, colInvoiceLineId, colProductCode, col_ProductDesc, col_Qty, col_Price, col_NetAmount, col_Barcode, col_PosDiscount, col_Amount, colProductCost, col_VatRate, col_SalesPersonCode, colCreatedDate, colCreatedUserName, colExchangeRate, colCurrencyCode, colQtyOut });
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
            gV_InvoiceLine.InitNewRow += gV_InvoiceLine_InitNewRow;
            gV_InvoiceLine.FocusedRowChanged += gV_InvoiceLine_FocusedRowChanged;
            gV_InvoiceLine.CellValueChanged += GV_InvoiceLine_CellValueChanged;
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colInvoiceLineId
            // 
            colInvoiceLineId.FieldName = "InvoiceLineId";
            colInvoiceLineId.Name = "colInvoiceLineId";
            // 
            // colProductCode
            // 
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            // 
            // col_ProductDesc
            // 
            col_ProductDesc.Caption = "Məhsul";
            col_ProductDesc.FieldName = "DcProduct.ProductDesc";
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
            // colProductCost
            // 
            colProductCost.FieldName = "ProductCost";
            colProductCost.Name = "colProductCost";
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
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            // 
            // colQtyOut
            // 
            colQtyOut.FieldName = "QtyOut";
            colQtyOut.Name = "colQtyOut";
            // 
            // btn_ProductSearch
            // 
            btn_ProductSearch.AllowFocus = false;
            btn_ProductSearch.Appearance.BackColor = Color.Transparent;
            btn_ProductSearch.Appearance.Options.UseBackColor = true;
            btn_ProductSearch.ImageOptions.Location = ImageLocation.TopCenter;
            btn_ProductSearch.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_ProductSearch.ImageOptions.SvgImage");
            btn_ProductSearch.Location = new Point(729, 240);
            btn_ProductSearch.Name = "btn_ProductSearch";
            btn_ProductSearch.ShowFocusRectangle = DefaultBoolean.False;
            btn_ProductSearch.Size = new Size(77, 63);
            btn_ProductSearch.StyleController = lC_InvoiceLine;
            btn_ProductSearch.TabIndex = 1;
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
            btn_Discount.Location = new Point(810, 240);
            btn_Discount.Name = "btn_Discount";
            btn_Discount.ShowFocusRectangle = DefaultBoolean.False;
            btn_Discount.Size = new Size(77, 63);
            btn_Discount.StyleController = lC_InvoiceLine;
            btn_Discount.TabIndex = 1;
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
            btn_CancelInvoice.Location = new Point(972, 240);
            btn_CancelInvoice.Name = "btn_CancelInvoice";
            btn_CancelInvoice.ShowFocusRectangle = DefaultBoolean.False;
            btn_CancelInvoice.Size = new Size(79, 63);
            btn_CancelInvoice.StyleController = lC_InvoiceLine;
            btn_CancelInvoice.TabIndex = 1;
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
            btn_DeleteLine.Location = new Point(891, 240);
            btn_DeleteLine.Name = "btn_DeleteLine";
            btn_DeleteLine.ShowFocusRectangle = DefaultBoolean.False;
            btn_DeleteLine.Size = new Size(77, 63);
            btn_DeleteLine.StyleController = lC_InvoiceLine;
            btn_DeleteLine.TabIndex = 1;
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
            btn_SalesPerson.Location = new Point(729, 307);
            btn_SalesPerson.Name = "btn_SalesPerson";
            btn_SalesPerson.Size = new Size(77, 63);
            btn_SalesPerson.StyleController = lC_InvoiceLine;
            btn_SalesPerson.TabIndex = 1;
            btn_SalesPerson.Text = "Satıcı";
            btn_SalesPerson.Click += btn_SalesPerson_Click;
            // 
            // btn_Cash
            // 
            btn_Cash.AllowFocus = false;
            btn_Cash.Appearance.BackColor = Color.Transparent;
            btn_Cash.Appearance.Options.UseBackColor = true;
            btn_Cash.ImageOptions.Image = (Image)resources.GetObject("btn_Cash.ImageOptions.Image");
            btn_Cash.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_Cash.Location = new Point(729, 554);
            btn_Cash.Name = "btn_Cash";
            btn_Cash.ShowFocusRectangle = DefaultBoolean.False;
            btn_Cash.Size = new Size(77, 72);
            btn_Cash.StyleController = lC_InvoiceLine;
            btn_Cash.TabIndex = 1;
            btn_Cash.Text = "Cash";
            btn_Cash.Click += btn_Payment_Click;
            // 
            // btn_Cashless
            // 
            btn_Cashless.AllowFocus = false;
            btn_Cashless.ImageOptions.Image = (Image)resources.GetObject("btn_Cashless.ImageOptions.Image");
            btn_Cashless.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_Cashless.Location = new Point(810, 554);
            btn_Cashless.Name = "btn_Cashless";
            btn_Cashless.ShowFocusRectangle = DefaultBoolean.False;
            btn_Cashless.Size = new Size(77, 72);
            btn_Cashless.StyleController = lC_InvoiceLine;
            btn_Cashless.TabIndex = 1;
            btn_Cashless.Text = "Nağdsız";
            btn_Cashless.Click += btn_Payment_Click;
            // 
            // btn_CustomerBonus
            // 
            btn_CustomerBonus.AllowFocus = false;
            btn_CustomerBonus.ImageOptions.Image = (Image)resources.GetObject("btn_CustomerBonus.ImageOptions.Image");
            btn_CustomerBonus.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_CustomerBonus.Location = new Point(891, 554);
            btn_CustomerBonus.Name = "btn_CustomerBonus";
            btn_CustomerBonus.ShowFocusRectangle = DefaultBoolean.False;
            btn_CustomerBonus.Size = new Size(77, 72);
            btn_CustomerBonus.StyleController = lC_InvoiceLine;
            btn_CustomerBonus.TabIndex = 1;
            btn_CustomerBonus.Text = "Bonus";
            btn_CustomerBonus.Click += btn_Payment_Click;
            // 
            // btn_Print
            // 
            btn_Print.AllowFocus = false;
            btn_Print.ImageOptions.Image = (Image)resources.GetObject("btn_Print.ImageOptions.Image");
            btn_Print.ImageOptions.Location = ImageLocation.TopCenter;
            btn_Print.Location = new Point(810, 307);
            btn_Print.Name = "btn_Print";
            btn_Print.Size = new Size(77, 63);
            btn_Print.StyleController = lC_InvoiceLine;
            btn_Print.TabIndex = 1;
            btn_Print.Text = "Çap";
            btn_Print.Click += btn_Print_Click;
            // 
            // btn_PrintPreview
            // 
            btn_PrintPreview.AllowFocus = false;
            btn_PrintPreview.ImageOptions.Image = (Image)resources.GetObject("btn_PrintPreview.ImageOptions.Image");
            btn_PrintPreview.ImageOptions.Location = ImageLocation.TopCenter;
            btn_PrintPreview.Location = new Point(891, 307);
            btn_PrintPreview.Name = "btn_PrintPreview";
            btn_PrintPreview.Size = new Size(77, 63);
            btn_PrintPreview.StyleController = lC_InvoiceLine;
            btn_PrintPreview.TabIndex = 1;
            btn_PrintPreview.Text = "Çap Görünüş";
            btn_PrintPreview.Click += btn_PrintPrevieww_Click;
            // 
            // btn_ReportZ
            // 
            btn_ReportZ.AllowFocus = false;
            btn_ReportZ.ImageOptions.Image = (Image)resources.GetObject("btn_ReportZ.ImageOptions.Image");
            btn_ReportZ.ImageOptions.Location = ImageLocation.TopCenter;
            btn_ReportZ.Location = new Point(972, 307);
            btn_ReportZ.Name = "btn_ReportZ";
            btn_ReportZ.Size = new Size(79, 63);
            btn_ReportZ.StyleController = lC_InvoiceLine;
            btn_ReportZ.TabIndex = 1;
            btn_ReportZ.Text = "Gün Sonu";
            btn_ReportZ.Click += btn_ReportZ_Click;
            // 
            // btn_NewInvoice
            // 
            btn_NewInvoice.AllowFocus = false;
            btn_NewInvoice.ImageOptions.Image = (Image)resources.GetObject("btn_NewInvoice.ImageOptions.Image");
            btn_NewInvoice.ImageOptions.Location = ImageLocation.TopCenter;
            btn_NewInvoice.Location = new Point(729, 374);
            btn_NewInvoice.Name = "btn_NewInvoice";
            btn_NewInvoice.Size = new Size(77, 63);
            btn_NewInvoice.StyleController = lC_InvoiceLine;
            btn_NewInvoice.TabIndex = 1;
            btn_NewInvoice.Text = "Yeni";
            btn_NewInvoice.Click += Btn_NewInvoice_Click;
            // 
            // btn_IncomplatedInvoices
            // 
            btn_IncomplatedInvoices.ImageOptions.Image = (Image)resources.GetObject("btn_IncomplatedInvoices.ImageOptions.Image");
            btn_IncomplatedInvoices.ImageOptions.Location = ImageLocation.MiddleCenter;
            btn_IncomplatedInvoices.Location = new Point(810, 374);
            btn_IncomplatedInvoices.Name = "btn_IncomplatedInvoices";
            btn_IncomplatedInvoices.Size = new Size(77, 63);
            btn_IncomplatedInvoices.StyleController = lC_InvoiceLine;
            btn_IncomplatedInvoices.TabIndex = 6;
            btn_IncomplatedInvoices.Text = "simpleButton3";
            btn_IncomplatedInvoices.Click += btn_IncomplatedInvoices_Click;
            // 
            // lCG_Root
            // 
            lCG_Root.EnableIndentsWithoutBorders = DefaultBoolean.True;
            lCG_Root.GroupBordersVisible = false;
            lCG_Root.Items.AddRange(new BaseLayoutItem[] { lCG_Barcode, lCG_Invoice, lCG_Function, lCG_Payment, LCG_Total, layoutControlGroup2 });
            lCG_Root.Name = "Root";
            lCG_Root.Size = new Size(1075, 650);
            lCG_Root.TextVisible = false;
            // 
            // lCG_Barcode
            // 
            lCG_Barcode.CustomizationFormText = "Barcode";
            lCG_Barcode.Items.AddRange(new BaseLayoutItem[] { lCI_ComboBox, LCI_Barcode, layoutControlItem1 });
            lCG_Barcode.Location = new Point(402, 0);
            lCG_Barcode.Name = "lCG_Barcode";
            lCG_Barcode.Size = new Size(303, 369);
            lCG_Barcode.Text = "Barcode";
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
            lCI_ComboBox.Size = new Size(56, 42);
            lCI_ComboBox.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ComboBox.TextSize = new Size(0, 0);
            lCI_ComboBox.TextVisible = false;
            // 
            // LCI_Barcode
            // 
            LCI_Barcode.ContentHorzAlignment = HorzAlignment.Center;
            LCI_Barcode.ContentVertAlignment = VertAlignment.Center;
            LCI_Barcode.Control = txtEdit_Barcode;
            LCI_Barcode.ControlAlignment = ContentAlignment.TopLeft;
            LCI_Barcode.CustomizationFormText = "layoutControlItemTextBox";
            LCI_Barcode.Location = new Point(56, 0);
            LCI_Barcode.MinSize = new Size(40, 24);
            LCI_Barcode.Name = "LCI_Barcode";
            LCI_Barcode.OptionsTableLayoutItem.ColumnIndex = 1;
            LCI_Barcode.OptionsTableLayoutItem.ColumnSpan = 3;
            LCI_Barcode.Size = new Size(223, 42);
            LCI_Barcode.SizeConstraintsType = SizeConstraintsType.Custom;
            LCI_Barcode.TextSize = new Size(0, 0);
            LCI_Barcode.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = ucNumberPad1;
            layoutControlItem1.Location = new Point(0, 42);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(279, 282);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // lCG_Invoice
            // 
            lCG_Invoice.CustomizationFormText = "Satış";
            lCG_Invoice.Items.AddRange(new BaseLayoutItem[] { lCI_GridView });
            lCG_Invoice.Location = new Point(0, 0);
            lCG_Invoice.Name = "lCG_Invoice";
            lCG_Invoice.Size = new Size(402, 630);
            lCG_Invoice.Text = "Satış";
            // 
            // lCI_GridView
            // 
            lCI_GridView.Control = gC_InvoiceLine;
            lCI_GridView.ControlAlignment = ContentAlignment.TopLeft;
            lCI_GridView.CustomizationFormText = "layoutControlItemGridView";
            lCI_GridView.Location = new Point(0, 0);
            lCI_GridView.Name = "lCI_GridView";
            lCI_GridView.Size = new Size(378, 585);
            lCI_GridView.TextSize = new Size(0, 0);
            lCI_GridView.TextVisible = false;
            // 
            // lCG_Function
            // 
            lCG_Function.CustomizationFormText = "Əməliyat";
            lCG_Function.Items.AddRange(new BaseLayoutItem[] { lCI_ProductSearch, lCI_Discount, lCI_CancelInvoice, lCI_DeleteLine, lCI_SalesPerson, lCI_Print, lCI_PrintDesign, lCI_ReportZ, LCI_NewInvoice, layoutControlItem8 });
            lCG_Function.LayoutMode = LayoutMode.Table;
            lCG_Function.Location = new Point(705, 195);
            lCG_Function.Name = "lCG_Function";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 25D;
            columnDefinition2.SizeType = SizeType.Percent;
            columnDefinition2.Width = 25D;
            columnDefinition3.SizeType = SizeType.Percent;
            columnDefinition3.Width = 25D;
            columnDefinition4.SizeType = SizeType.Percent;
            columnDefinition4.Width = 25D;
            lCG_Function.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new ColumnDefinition[] { columnDefinition1, columnDefinition2, columnDefinition3, columnDefinition4 });
            rowDefinition1.Height = 25D;
            rowDefinition1.SizeType = SizeType.Percent;
            rowDefinition2.Height = 25D;
            rowDefinition2.SizeType = SizeType.Percent;
            rowDefinition3.Height = 25D;
            rowDefinition3.SizeType = SizeType.Percent;
            rowDefinition4.Height = 25D;
            rowDefinition4.SizeType = SizeType.Percent;
            lCG_Function.OptionsTableLayoutGroup.RowDefinitions.AddRange(new RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            lCG_Function.Size = new Size(350, 314);
            lCG_Function.Text = "Əməliyat";
            // 
            // lCI_ProductSearch
            // 
            lCI_ProductSearch.Control = btn_ProductSearch;
            lCI_ProductSearch.ControlAlignment = ContentAlignment.TopLeft;
            lCI_ProductSearch.CustomizationFormText = "layoutControlItemProductSearch";
            lCI_ProductSearch.Location = new Point(0, 0);
            lCI_ProductSearch.Name = "lCI_ProductSearch";
            lCI_ProductSearch.Size = new Size(81, 67);
            lCI_ProductSearch.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ProductSearch.TextSize = new Size(0, 0);
            lCI_ProductSearch.TextVisible = false;
            // 
            // lCI_Discount
            // 
            lCI_Discount.Control = btn_Discount;
            lCI_Discount.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Discount.CustomizationFormText = "layoutControlItemDiscount";
            lCI_Discount.Location = new Point(81, 0);
            lCI_Discount.Name = "lCI_Discount";
            lCI_Discount.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Discount.Size = new Size(81, 67);
            lCI_Discount.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Discount.TextSize = new Size(0, 0);
            lCI_Discount.TextVisible = false;
            // 
            // lCI_CancelInvoice
            // 
            lCI_CancelInvoice.Control = btn_CancelInvoice;
            lCI_CancelInvoice.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CancelInvoice.CustomizationFormText = "layoutControlItemCancelInvoice";
            lCI_CancelInvoice.Location = new Point(243, 0);
            lCI_CancelInvoice.Name = "lCI_CancelInvoice";
            lCI_CancelInvoice.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_CancelInvoice.Size = new Size(83, 67);
            lCI_CancelInvoice.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CancelInvoice.TextSize = new Size(0, 0);
            lCI_CancelInvoice.TextVisible = false;
            // 
            // lCI_DeleteLine
            // 
            lCI_DeleteLine.Control = btn_DeleteLine;
            lCI_DeleteLine.ControlAlignment = ContentAlignment.TopLeft;
            lCI_DeleteLine.CustomizationFormText = "layoutControlItemDeleteLine";
            lCI_DeleteLine.Location = new Point(162, 0);
            lCI_DeleteLine.Name = "lCI_DeleteLine";
            lCI_DeleteLine.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_DeleteLine.Size = new Size(81, 67);
            lCI_DeleteLine.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_DeleteLine.TextSize = new Size(0, 0);
            lCI_DeleteLine.TextVisible = false;
            // 
            // lCI_SalesPerson
            // 
            lCI_SalesPerson.Control = btn_SalesPerson;
            lCI_SalesPerson.ControlAlignment = ContentAlignment.TopLeft;
            lCI_SalesPerson.CustomizationFormText = "layoutControlItemSalesPerson";
            lCI_SalesPerson.Location = new Point(0, 67);
            lCI_SalesPerson.Name = "lCI_SalesPerson";
            lCI_SalesPerson.OptionsTableLayoutItem.RowIndex = 1;
            lCI_SalesPerson.Size = new Size(81, 67);
            lCI_SalesPerson.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_SalesPerson.TextSize = new Size(0, 0);
            lCI_SalesPerson.TextVisible = false;
            // 
            // lCI_Print
            // 
            lCI_Print.Control = btn_Print;
            lCI_Print.Location = new Point(81, 67);
            lCI_Print.Name = "lCI_Print";
            lCI_Print.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Print.OptionsTableLayoutItem.RowIndex = 1;
            lCI_Print.Size = new Size(81, 67);
            lCI_Print.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Print.TextSize = new Size(0, 0);
            lCI_Print.TextVisible = false;
            // 
            // lCI_PrintDesign
            // 
            lCI_PrintDesign.Control = btn_PrintPreview;
            lCI_PrintDesign.Location = new Point(162, 67);
            lCI_PrintDesign.Name = "lCI_PrintDesign";
            lCI_PrintDesign.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_PrintDesign.OptionsTableLayoutItem.RowIndex = 1;
            lCI_PrintDesign.Size = new Size(81, 67);
            lCI_PrintDesign.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_PrintDesign.TextSize = new Size(0, 0);
            lCI_PrintDesign.TextVisible = false;
            // 
            // lCI_ReportZ
            // 
            lCI_ReportZ.Control = btn_ReportZ;
            lCI_ReportZ.Location = new Point(243, 67);
            lCI_ReportZ.Name = "lCI_ReportZ";
            lCI_ReportZ.OptionsTableLayoutItem.ColumnIndex = 3;
            lCI_ReportZ.OptionsTableLayoutItem.RowIndex = 1;
            lCI_ReportZ.Size = new Size(83, 67);
            lCI_ReportZ.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_ReportZ.TextSize = new Size(0, 0);
            lCI_ReportZ.TextVisible = false;
            // 
            // LCI_NewInvoice
            // 
            LCI_NewInvoice.Control = btn_NewInvoice;
            LCI_NewInvoice.Location = new Point(0, 134);
            LCI_NewInvoice.Name = "layoutControlItem7";
            LCI_NewInvoice.OptionsTableLayoutItem.RowIndex = 2;
            LCI_NewInvoice.Size = new Size(81, 67);
            LCI_NewInvoice.SizeConstraintsType = SizeConstraintsType.Custom;
            LCI_NewInvoice.TextSize = new Size(0, 0);
            LCI_NewInvoice.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = btn_IncomplatedInvoices;
            layoutControlItem8.Location = new Point(81, 134);
            layoutControlItem8.MinSize = new Size(60, 40);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem8.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem8.Size = new Size(81, 67);
            layoutControlItem8.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem8.TextSize = new Size(0, 0);
            layoutControlItem8.TextVisible = false;
            // 
            // lCG_Payment
            // 
            lCG_Payment.CustomizationFormText = "Ödəmə";
            lCG_Payment.Items.AddRange(new BaseLayoutItem[] { lCI_Cash, lCI_Cashless, lCI_CustomerBonus });
            lCG_Payment.LayoutMode = LayoutMode.Table;
            lCG_Payment.Location = new Point(705, 509);
            lCG_Payment.Name = "lCG_Payment";
            columnDefinition5.SizeType = SizeType.Percent;
            columnDefinition5.Width = 25D;
            columnDefinition6.SizeType = SizeType.Percent;
            columnDefinition6.Width = 25D;
            columnDefinition7.SizeType = SizeType.Percent;
            columnDefinition7.Width = 25D;
            columnDefinition8.SizeType = SizeType.Percent;
            columnDefinition8.Width = 25D;
            lCG_Payment.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new ColumnDefinition[] { columnDefinition5, columnDefinition6, columnDefinition7, columnDefinition8 });
            rowDefinition5.Height = 100D;
            rowDefinition5.SizeType = SizeType.Percent;
            lCG_Payment.OptionsTableLayoutGroup.RowDefinitions.AddRange(new RowDefinition[] { rowDefinition5 });
            lCG_Payment.Size = new Size(350, 121);
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
            lCI_Cash.Size = new Size(81, 76);
            lCI_Cash.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Cash.TextSize = new Size(0, 0);
            lCI_Cash.TextVisible = false;
            // 
            // lCI_Cashless
            // 
            lCI_Cashless.Control = btn_Cashless;
            lCI_Cashless.ControlAlignment = ContentAlignment.TopLeft;
            lCI_Cashless.CustomizationFormText = "layoutControlItemCashless";
            lCI_Cashless.Location = new Point(81, 0);
            lCI_Cashless.MinSize = new Size(40, 26);
            lCI_Cashless.Name = "lCI_Cashless";
            lCI_Cashless.OptionsTableLayoutItem.ColumnIndex = 1;
            lCI_Cashless.Size = new Size(81, 76);
            lCI_Cashless.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_Cashless.TextSize = new Size(0, 0);
            lCI_Cashless.TextVisible = false;
            // 
            // lCI_CustomerBonus
            // 
            lCI_CustomerBonus.Control = btn_CustomerBonus;
            lCI_CustomerBonus.ControlAlignment = ContentAlignment.TopLeft;
            lCI_CustomerBonus.CustomizationFormText = "layoutControlItemCustomerBonus";
            lCI_CustomerBonus.Location = new Point(162, 0);
            lCI_CustomerBonus.MinSize = new Size(40, 26);
            lCI_CustomerBonus.Name = "lCI_CustomerBonus";
            lCI_CustomerBonus.OptionsTableLayoutItem.ColumnIndex = 2;
            lCI_CustomerBonus.Size = new Size(81, 76);
            lCI_CustomerBonus.SizeConstraintsType = SizeConstraintsType.Custom;
            lCI_CustomerBonus.TextSize = new Size(0, 0);
            lCI_CustomerBonus.TextVisible = false;
            // 
            // LCG_Total
            // 
            LCG_Total.CustomizationFormText = "layoutControlGroup1";
            LCG_Total.Items.AddRange(new BaseLayoutItem[] { layoutControlItem6, layoutControlGroup3, emptySpaceItem2 });
            LCG_Total.Location = new Point(402, 369);
            LCG_Total.Name = "LCG_Total";
            LCG_Total.Size = new Size(303, 261);
            LCG_Total.Text = "Toplam";
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = txt_PrintCount;
            layoutControlItem6.Location = new Point(0, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new Size(279, 24);
            layoutControlItem6.Text = "Çap Sayı";
            layoutControlItem6.TextSize = new Size(42, 13);
            // 
            // layoutControlGroup3
            // 
            layoutControlGroup3.GroupStyle = GroupStyle.Light;
            layoutControlGroup3.Items.AddRange(new BaseLayoutItem[] { layoutControlItem7, lbl_InvoicePaidCashSum, layoutControlItem10, layoutControlItem12, layoutControlItem13, layoutControlItem11, emptySpaceItem1 });
            layoutControlGroup3.Location = new Point(0, 123);
            layoutControlGroup3.Name = "layoutControlGroup3";
            layoutControlGroup3.Size = new Size(279, 93);
            layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.ContentHorzAlignment = HorzAlignment.Far;
            layoutControlItem7.Control = lbl_InvoicePaidCashSumTxt;
            layoutControlItem7.Location = new Point(114, 0);
            layoutControlItem7.Name = "item0";
            layoutControlItem7.Size = new Size(69, 23);
            layoutControlItem7.TextSize = new Size(0, 0);
            layoutControlItem7.TextVisible = false;
            // 
            // lbl_InvoicePaidCashSum
            // 
            lbl_InvoicePaidCashSum.ContentHorzAlignment = HorzAlignment.Far;
            lbl_InvoicePaidCashSum.Control = labelControl2;
            lbl_InvoicePaidCashSum.Location = new Point(183, 0);
            lbl_InvoicePaidCashSum.Name = "lbl_InvoicePaidCashSum";
            lbl_InvoicePaidCashSum.Size = new Size(72, 23);
            lbl_InvoicePaidCashSum.TextSize = new Size(0, 0);
            lbl_InvoicePaidCashSum.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.ContentHorzAlignment = HorzAlignment.Far;
            layoutControlItem10.Control = lbl_InvoicePaidCashlessSumTxt;
            layoutControlItem10.Location = new Point(114, 23);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.Size = new Size(69, 23);
            layoutControlItem10.TextSize = new Size(0, 0);
            layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            layoutControlItem12.ContentHorzAlignment = HorzAlignment.Far;
            layoutControlItem12.Control = lbl_InvoicePaidTotalSumTxt;
            layoutControlItem12.Location = new Point(114, 46);
            layoutControlItem12.Name = "layoutControlItem12";
            layoutControlItem12.Size = new Size(69, 23);
            layoutControlItem12.TextSize = new Size(0, 0);
            layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            layoutControlItem13.ContentHorzAlignment = HorzAlignment.Far;
            layoutControlItem13.Control = lbl_InvoicePaidTotalSum;
            layoutControlItem13.Location = new Point(183, 46);
            layoutControlItem13.Name = "layoutControlItem13";
            layoutControlItem13.Size = new Size(72, 23);
            layoutControlItem13.TextSize = new Size(0, 0);
            layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            layoutControlItem11.ContentHorzAlignment = HorzAlignment.Far;
            layoutControlItem11.Control = lbl_InvoicePaidCashlessSum;
            layoutControlItem11.Location = new Point(183, 23);
            layoutControlItem11.Name = "layoutControlItem11";
            layoutControlItem11.Size = new Size(72, 23);
            layoutControlItem11.TextSize = new Size(0, 0);
            layoutControlItem11.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(0, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(114, 69);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new Point(0, 24);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(279, 99);
            emptySpaceItem2.TextSize = new Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.Items.AddRange(new BaseLayoutItem[] { layoutControlItem2 });
            layoutControlGroup2.Location = new Point(705, 0);
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new Size(350, 195);
            layoutControlGroup2.Text = "Müştəri";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = dataLayoutControl1;
            layoutControlItem2.Location = new Point(0, 0);
            layoutControlItem2.MaxSize = new Size(0, 150);
            layoutControlItem2.MinSize = new Size(213, 150);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(326, 150);
            layoutControlItem2.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // trInvoiceHeadersBindingSource
            // 
            trInvoiceHeadersBindingSource.DataSource = typeof(TrInvoiceHeader);
            trInvoiceHeadersBindingSource.AddingNew += trInvoiceHeadersBindingSource_AddingNew;
            // 
            // UcRetailSale
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lC_InvoiceLine);
            Name = "UcRetailSale";
            Size = new Size(1075, 650);
            Load += UcRetailSale_Load;
            ((ISupportInitialize)lC_InvoiceLine).EndInit();
            lC_InvoiceLine.ResumeLayout(false);
            ((ISupportInitialize)txt_PrintCount.Properties).EndInit();
            ((ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((ISupportInitialize)CurrAccCodeTextEdit.Properties).EndInit();
            ((ISupportInitialize)dcCurrAccBindingSource).EndInit();
            ((ISupportInitialize)CurrAccDescTextEdit.Properties).EndInit();
            ((ISupportInitialize)BonusCardNumTextEdit.Properties).EndInit();
            ((ISupportInitialize)AddressTextEdit.Properties).EndInit();
            ((ISupportInitialize)PhoneNumTextEdit.Properties).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)layoutControlGroup1).EndInit();
            ((ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((ISupportInitialize)ItemForCurrAccDesc).EndInit();
            ((ISupportInitialize)ItemForBonusCardNum).EndInit();
            ((ISupportInitialize)ItemForAddress).EndInit();
            ((ISupportInitialize)ItemForPhoneNum).EndInit();
            ((ISupportInitialize)layoutControlItem3).EndInit();
            ((ISupportInitialize)layoutControlItem4).EndInit();
            ((ISupportInitialize)layoutControlItem5).EndInit();
            ((ISupportInitialize)txtEdit_Barcode.Properties).EndInit();
            ((ISupportInitialize)imageComboEdit_Barcode.Properties).EndInit();
            ((ISupportInitialize)gC_InvoiceLine).EndInit();
            ((ISupportInitialize)trInvoiceLinesBindingSource).EndInit();
            ((ISupportInitialize)gV_InvoiceLine).EndInit();
            ((ISupportInitialize)lCG_Root).EndInit();
            ((ISupportInitialize)lCG_Barcode).EndInit();
            ((ISupportInitialize)lCI_ComboBox).EndInit();
            ((ISupportInitialize)LCI_Barcode).EndInit();
            ((ISupportInitialize)layoutControlItem1).EndInit();
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
            ((ISupportInitialize)LCI_NewInvoice).EndInit();
            ((ISupportInitialize)layoutControlItem8).EndInit();
            ((ISupportInitialize)lCG_Payment).EndInit();
            ((ISupportInitialize)lCI_Cash).EndInit();
            ((ISupportInitialize)lCI_Cashless).EndInit();
            ((ISupportInitialize)lCI_CustomerBonus).EndInit();
            ((ISupportInitialize)LCG_Total).EndInit();
            ((ISupportInitialize)layoutControlItem6).EndInit();
            ((ISupportInitialize)layoutControlGroup3).EndInit();
            ((ISupportInitialize)layoutControlItem7).EndInit();
            ((ISupportInitialize)lbl_InvoicePaidCashSum).EndInit();
            ((ISupportInitialize)layoutControlItem10).EndInit();
            ((ISupportInitialize)layoutControlItem12).EndInit();
            ((ISupportInitialize)layoutControlItem13).EndInit();
            ((ISupportInitialize)layoutControlItem11).EndInit();
            ((ISupportInitialize)emptySpaceItem1).EndInit();
            ((ISupportInitialize)emptySpaceItem2).EndInit();
            ((ISupportInitialize)layoutControlGroup2).EndInit();
            ((ISupportInitialize)layoutControlItem2).EndInit();
            ((ISupportInitialize)trInvoiceHeadersBindingSource).EndInit();
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
        private SimpleButton btn_CustomerSearch;
        private SimpleButton btn_CustomerEdit;
        private SimpleButton btn_CustomerAdd;
        private SimpleButton btn_Cash;
        private SimpleButton btn_Cashless;
        private SimpleButton btn_CustomerBonus;
        private LayoutControlGroup lCG_Barcode;
        private LayoutControlItem LCI_Barcode;
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
        private LayoutControlGroup LCG_Total;
        private SimpleButton btn_Print;
        private LayoutControlItem lCI_Print;
        private SimpleButton btn_PrintDesign;
        private LayoutControlItem lCI_PrintDesign;
        private SimpleButton btn_ReportZ;
        private LayoutControlItem lCI_ReportZ;
        private GridColumn col_SalesPersonCode;
        private SimpleButton btn_Num5;
        private GridColumn col_ProductDesc;
        private UCNumberPad ucNumberPad1;
        private LayoutControlItem layoutControlItem1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private BindingSource dcCurrAccBindingSource;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItem2;
        private TextEdit CurrAccCodeTextEdit;
        private TextEdit CurrAccDescTextEdit;
        private TextEdit BonusCardNumTextEdit;
        private TextEdit AddressTextEdit;
        private TextEdit PhoneNumTextEdit;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem ItemForCurrAccCode;
        private LayoutControlItem ItemForCurrAccDesc;
        private LayoutControlItem ItemForBonusCardNum;
        private LayoutControlItem ItemForAddress;
        private LayoutControlItem ItemForPhoneNum;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlGroup layoutControlGroup2;
        private SimpleButton btn_PrintPreview;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private TextEdit textEdit1;
        private LayoutControlItem layoutControlItem6;
        private EmptySpaceItem emptySpaceItem1;
        private TextEdit txt_PrintCount;
        private BindingSource trInvoiceHeadersBindingSource;
        private BindingSource trInvoiceLinesBindingSource;
        private GridColumn colInvoiceHeaderId;
        private GridColumn colInvoiceLineId;
        private GridColumn colCreatedDate;
        private GridColumn colCreatedUserName;
        private GridColumn colExchangeRate;
        private GridColumn colCurrencyCode;
        private GridColumn colProductCode;
        private GridColumn colProductCost;
        private GridColumn colQtyOut;
        private SimpleButton simpleButton1;
        private LayoutControlItem LCI_NewInvoice;
        private SimpleButton NewInvoice;
        private SimpleButton btn_NewInvoice;
        private SimpleButton btn_IncomplatedInvoices;
        private LayoutControlItem layoutControlItem8;
        private LabelControl lbl_InvoicePaidTotalSum;
        private LabelControl lbl_InvoicePaidTotalSumTxt;
        private LabelControl lbl_InvoicePaidCashlessSum;
        private LabelControl lbl_InvoicePaidCashlessSumTxt;
        private LabelControl labelControl2;
        private LabelControl lbl_InvoicePaidCashSumTxt;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem lbl_InvoicePaidCashSum;
        private LayoutControlItem layoutControlItem10;
        private LayoutControlItem layoutControlItem11;
        private LayoutControlItem layoutControlItem12;
        private LayoutControlItem layoutControlItem13;
        private LayoutControlGroup layoutControlGroup3;
        private EmptySpaceItem emptySpaceItem2;
    }
}
