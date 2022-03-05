
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSale));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition6 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition7 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition8 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition7 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition8 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition9 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition9 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition10 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition10 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition11 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition12 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition13 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition14 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition15 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition11 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition12 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition13 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition14 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition16 = new DevExpress.XtraLayout.RowDefinition();
            this.lC_InvoiceLine = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Star = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Comma = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num0 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num3 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num4 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num6 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num8 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num9 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num7 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Enter = new DevExpress.XtraEditors.SimpleButton();
            this.btn_C = new DevExpress.XtraEditors.SimpleButton();
            this.btn_BackSpace = new DevExpress.XtraEditors.SimpleButton();
            this.txtEdit_Barcode = new DevExpress.XtraEditors.TextEdit();
            this.imageComboEdit_Barcode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            this.gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VatRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_SalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_ProductSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Discount = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CancelInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DeleteLine = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SalesPerson = new DevExpress.XtraEditors.SimpleButton();
            this.txtEdit_CustomerPhoneNum = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_CustomerAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_CustomerName = new DevExpress.XtraEditors.TextEdit();
            this.btn_CustomerSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CustomerEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CustomerAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtEdit_BonCardNum = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_CustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.btn_Cash = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cashless = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CustomerBonus = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.btn_PrintDesign = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ReportZ = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Num5 = new DevExpress.XtraEditors.SimpleButton();
            this.lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCG_Barcode = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_Star = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Comma = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num0 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Enter = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_C = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_BackSpace = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_ItemTextBox = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_ComboBox = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Num5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCG_Invoice = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_GridView = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCG_Function = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_ProductSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Discount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CancelInvoice = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_DeleteLine = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_SalesPerson = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Print = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_PrintDesign = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_ReportZ = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCG_Customer = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_CustomerSearch = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_BonusCardNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerTel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerAdd = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCG_Payment = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_Cash = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Cashless = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomerBonus = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.lC_InvoiceLine)).BeginInit();
            this.lC_InvoiceLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Barcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboEdit_Barcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerPhoneNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_BonCardNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Star)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Comma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Enter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_BackSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ItemTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Invoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Function)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ProductSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Discount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CancelInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DeleteLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_SalesPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_PrintDesign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ReportZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_BonusCardNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Cash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Cashless)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            this.SuspendLayout();
            // 
            // lC_InvoiceLine
            // 
            this.lC_InvoiceLine.Controls.Add(this.btn_Star);
            this.lC_InvoiceLine.Controls.Add(this.btn_Comma);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num0);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num1);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num2);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num3);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num4);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num6);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num8);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num9);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num7);
            this.lC_InvoiceLine.Controls.Add(this.btn_Enter);
            this.lC_InvoiceLine.Controls.Add(this.btn_C);
            this.lC_InvoiceLine.Controls.Add(this.btn_BackSpace);
            this.lC_InvoiceLine.Controls.Add(this.txtEdit_Barcode);
            this.lC_InvoiceLine.Controls.Add(this.imageComboEdit_Barcode);
            this.lC_InvoiceLine.Controls.Add(this.gC_InvoiceLine);
            this.lC_InvoiceLine.Controls.Add(this.btn_ProductSearch);
            this.lC_InvoiceLine.Controls.Add(this.btn_Discount);
            this.lC_InvoiceLine.Controls.Add(this.btn_CancelInvoice);
            this.lC_InvoiceLine.Controls.Add(this.btn_DeleteLine);
            this.lC_InvoiceLine.Controls.Add(this.btn_SalesPerson);
            this.lC_InvoiceLine.Controls.Add(this.txtEdit_CustomerPhoneNum);
            this.lC_InvoiceLine.Controls.Add(this.txtEdit_CustomerAddress);
            this.lC_InvoiceLine.Controls.Add(this.txtEdit_CustomerName);
            this.lC_InvoiceLine.Controls.Add(this.btn_CustomerSearch);
            this.lC_InvoiceLine.Controls.Add(this.btn_CustomerEdit);
            this.lC_InvoiceLine.Controls.Add(this.btn_CustomerAdd);
            this.lC_InvoiceLine.Controls.Add(this.txtEdit_BonCardNum);
            this.lC_InvoiceLine.Controls.Add(this.txtEdit_CustomerCode);
            this.lC_InvoiceLine.Controls.Add(this.btn_Cash);
            this.lC_InvoiceLine.Controls.Add(this.btn_Cashless);
            this.lC_InvoiceLine.Controls.Add(this.btn_CustomerBonus);
            this.lC_InvoiceLine.Controls.Add(this.btn_Print);
            this.lC_InvoiceLine.Controls.Add(this.btn_PrintDesign);
            this.lC_InvoiceLine.Controls.Add(this.btn_ReportZ);
            this.lC_InvoiceLine.Controls.Add(this.btn_Num5);
            this.lC_InvoiceLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lC_InvoiceLine.Location = new System.Drawing.Point(0, 0);
            this.lC_InvoiceLine.Name = "lC_InvoiceLine";
            this.lC_InvoiceLine.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1189, 400, 650, 400);
            this.lC_InvoiceLine.Root = this.lCG_Root;
            this.lC_InvoiceLine.Size = new System.Drawing.Size(1142, 719);
            this.lC_InvoiceLine.TabIndex = 0;
            this.lC_InvoiceLine.Text = "layoutControl1";
            // 
            // btn_Star
            // 
            this.btn_Star.AllowFocus = false;
            this.btn_Star.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Star.Appearance.Options.UseFont = true;
            this.btn_Star.Location = new System.Drawing.Point(436, 325);
            this.btn_Star.Name = "btn_Star";
            this.btn_Star.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Star.Size = new System.Drawing.Size(74, 67);
            this.btn_Star.StyleController = this.lC_InvoiceLine;
            this.btn_Star.TabIndex = 14;
            this.btn_Star.Text = "*";
            this.btn_Star.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Comma
            // 
            this.btn_Comma.AllowFocus = false;
            this.btn_Comma.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Comma.Appearance.Options.UseFont = true;
            this.btn_Comma.Location = new System.Drawing.Point(592, 325);
            this.btn_Comma.Name = "btn_Comma";
            this.btn_Comma.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Comma.Size = new System.Drawing.Size(74, 67);
            this.btn_Comma.StyleController = this.lC_InvoiceLine;
            this.btn_Comma.TabIndex = 15;
            this.btn_Comma.Text = ",";
            this.btn_Comma.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num0
            // 
            this.btn_Num0.AllowFocus = false;
            this.btn_Num0.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num0.Appearance.Options.UseFont = true;
            this.btn_Num0.Location = new System.Drawing.Point(514, 325);
            this.btn_Num0.Name = "btn_Num0";
            this.btn_Num0.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num0.Size = new System.Drawing.Size(74, 67);
            this.btn_Num0.StyleController = this.lC_InvoiceLine;
            this.btn_Num0.TabIndex = 13;
            this.btn_Num0.Text = "0";
            this.btn_Num0.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num1
            // 
            this.btn_Num1.AllowFocus = false;
            this.btn_Num1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num1.Appearance.Options.UseFont = true;
            this.btn_Num1.Location = new System.Drawing.Point(436, 255);
            this.btn_Num1.Name = "btn_Num1";
            this.btn_Num1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num1.Size = new System.Drawing.Size(74, 66);
            this.btn_Num1.StyleController = this.lC_InvoiceLine;
            this.btn_Num1.TabIndex = 6;
            this.btn_Num1.Text = "1";
            this.btn_Num1.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num2
            // 
            this.btn_Num2.AllowFocus = false;
            this.btn_Num2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num2.Appearance.Options.UseFont = true;
            this.btn_Num2.Location = new System.Drawing.Point(514, 255);
            this.btn_Num2.Name = "btn_Num2";
            this.btn_Num2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num2.Size = new System.Drawing.Size(74, 66);
            this.btn_Num2.StyleController = this.lC_InvoiceLine;
            this.btn_Num2.TabIndex = 7;
            this.btn_Num2.Text = "2";
            this.btn_Num2.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num3
            // 
            this.btn_Num3.AllowFocus = false;
            this.btn_Num3.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num3.Appearance.Options.UseFont = true;
            this.btn_Num3.Location = new System.Drawing.Point(592, 255);
            this.btn_Num3.Name = "btn_Num3";
            this.btn_Num3.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num3.Size = new System.Drawing.Size(74, 66);
            this.btn_Num3.StyleController = this.lC_InvoiceLine;
            this.btn_Num3.TabIndex = 8;
            this.btn_Num3.Text = "3";
            this.btn_Num3.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num4
            // 
            this.btn_Num4.AllowFocus = false;
            this.btn_Num4.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num4.Appearance.Options.UseFont = true;
            this.btn_Num4.Location = new System.Drawing.Point(436, 185);
            this.btn_Num4.Name = "btn_Num4";
            this.btn_Num4.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num4.Size = new System.Drawing.Size(74, 66);
            this.btn_Num4.StyleController = this.lC_InvoiceLine;
            this.btn_Num4.TabIndex = 5;
            this.btn_Num4.Text = "4";
            this.btn_Num4.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num6
            // 
            this.btn_Num6.AllowFocus = false;
            this.btn_Num6.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num6.Appearance.Options.UseFont = true;
            this.btn_Num6.Location = new System.Drawing.Point(592, 185);
            this.btn_Num6.Name = "btn_Num6";
            this.btn_Num6.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num6.Size = new System.Drawing.Size(74, 66);
            this.btn_Num6.StyleController = this.lC_InvoiceLine;
            this.btn_Num6.TabIndex = 9;
            this.btn_Num6.Text = "6";
            this.btn_Num6.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num8
            // 
            this.btn_Num8.AllowFocus = false;
            this.btn_Num8.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num8.Appearance.Options.UseFont = true;
            this.btn_Num8.Location = new System.Drawing.Point(514, 115);
            this.btn_Num8.Name = "btn_Num8";
            this.btn_Num8.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num8.Size = new System.Drawing.Size(74, 66);
            this.btn_Num8.StyleController = this.lC_InvoiceLine;
            this.btn_Num8.TabIndex = 10;
            this.btn_Num8.Text = "8";
            this.btn_Num8.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num9
            // 
            this.btn_Num9.AllowFocus = false;
            this.btn_Num9.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num9.Appearance.Options.UseFont = true;
            this.btn_Num9.Location = new System.Drawing.Point(592, 115);
            this.btn_Num9.Name = "btn_Num9";
            this.btn_Num9.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num9.Size = new System.Drawing.Size(74, 66);
            this.btn_Num9.StyleController = this.lC_InvoiceLine;
            this.btn_Num9.TabIndex = 12;
            this.btn_Num9.Text = "9";
            this.btn_Num9.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Num7
            // 
            this.btn_Num7.AllowFocus = false;
            this.btn_Num7.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num7.Appearance.Options.UseFont = true;
            this.btn_Num7.Location = new System.Drawing.Point(436, 115);
            this.btn_Num7.Name = "btn_Num7";
            this.btn_Num7.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num7.Size = new System.Drawing.Size(74, 66);
            this.btn_Num7.StyleController = this.lC_InvoiceLine;
            this.btn_Num7.TabIndex = 22;
            this.btn_Num7.Text = "7";
            this.btn_Num7.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btn_Enter.Appearance.Options.UseFont = true;
            this.btn_Enter.Location = new System.Drawing.Point(670, 255);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Enter.Size = new System.Drawing.Size(74, 137);
            this.btn_Enter.StyleController = this.lC_InvoiceLine;
            this.btn_Enter.TabIndex = 18;
            this.btn_Enter.Text = "↵";
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_C
            // 
            this.btn_C.AllowFocus = false;
            this.btn_C.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_C.Appearance.Options.UseFont = true;
            this.btn_C.Location = new System.Drawing.Point(670, 185);
            this.btn_C.Name = "btn_C";
            this.btn_C.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_C.Size = new System.Drawing.Size(74, 66);
            this.btn_C.StyleController = this.lC_InvoiceLine;
            this.btn_C.TabIndex = 17;
            this.btn_C.Text = "C";
            this.btn_C.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // btn_BackSpace
            // 
            this.btn_BackSpace.AllowFocus = false;
            this.btn_BackSpace.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BackSpace.Appearance.Options.UseFont = true;
            this.btn_BackSpace.Location = new System.Drawing.Point(670, 115);
            this.btn_BackSpace.Name = "btn_BackSpace";
            this.btn_BackSpace.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_BackSpace.Size = new System.Drawing.Size(74, 66);
            this.btn_BackSpace.StyleController = this.lC_InvoiceLine;
            this.btn_BackSpace.TabIndex = 16;
            this.btn_BackSpace.Text = "←";
            this.btn_BackSpace.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // txtEdit_Barcode
            // 
            this.txtEdit_Barcode.Location = new System.Drawing.Point(514, 61);
            this.txtEdit_Barcode.Name = "txtEdit_Barcode";
            // 
            // 
            // 
            this.txtEdit_Barcode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 17F);
            this.txtEdit_Barcode.Properties.Appearance.Options.UseFont = true;
            this.txtEdit_Barcode.Size = new System.Drawing.Size(230, 34);
            this.txtEdit_Barcode.StyleController = this.lC_InvoiceLine;
            this.txtEdit_Barcode.TabIndex = 24;
            // 
            // imageComboEdit_Barcode
            // 
            this.imageComboEdit_Barcode.Location = new System.Drawing.Point(436, 60);
            this.imageComboEdit_Barcode.Name = "imageComboEdit_Barcode";
            // 
            // 
            // 
            this.imageComboEdit_Barcode.Properties.AllowFocused = false;
            this.imageComboEdit_Barcode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.imageComboEdit_Barcode.Properties.Appearance.Options.UseFont = true;
            this.imageComboEdit_Barcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboEdit_Barcode.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.imageComboEdit_Barcode.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("imageComboEdit_Barcode.Properties.ContextImageOptions.Image")));
            this.imageComboEdit_Barcode.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("imageComboEdit_Barcode.Properties.ContextImageOptions.SvgImage")));
            this.imageComboEdit_Barcode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.imageComboEdit_Barcode.Size = new System.Drawing.Size(74, 36);
            this.imageComboEdit_Barcode.StyleController = this.lC_InvoiceLine;
            this.imageComboEdit_Barcode.TabIndex = 23;
            // 
            // gC_InvoiceLine
            // 
            this.gC_InvoiceLine.DataMember = "TrInvoiceLine";
            this.gC_InvoiceLine.Location = new System.Drawing.Point(24, 45);
            this.gC_InvoiceLine.MainView = this.gV_InvoiceLine;
            this.gC_InvoiceLine.Name = "gC_InvoiceLine";
            this.gC_InvoiceLine.Size = new System.Drawing.Size(384, 650);
            this.gC_InvoiceLine.TabIndex = 4;
            this.gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceLine});
            this.gC_InvoiceLine.DoubleClick += new System.EventHandler(this.gC_Sale_DoubleClick);
            this.gC_InvoiceLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gC_Sale_MouseUp);
            // 
            // gV_InvoiceLine
            // 
            this.gV_InvoiceLine.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gV_InvoiceLine.Appearance.FooterPanel.Options.UseFont = true;
            this.gV_InvoiceLine.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(221)))), ((int)(((byte)(245)))));
            this.gV_InvoiceLine.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gV_InvoiceLine.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gV_InvoiceLine.Appearance.Row.Options.UseFont = true;
            this.gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ProductDesc,
            this.col_Qty,
            this.col_Price,
            this.col_NetAmount,
            this.col_Barcode,
            this.col_PosDiscount,
            this.col_Amount,
            this.col_VatRate,
            this.col_SalesPersonCode});
            this.gV_InvoiceLine.GridControl = this.gC_InvoiceLine;
            this.gV_InvoiceLine.Name = "gV_InvoiceLine";
            this.gV_InvoiceLine.OptionsBehavior.Editable = false;
            this.gV_InvoiceLine.OptionsView.AutoCalcPreviewLineCount = true;
            this.gV_InvoiceLine.OptionsView.ShowFooter = true;
            this.gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
            this.gV_InvoiceLine.OptionsView.ShowIndicator = false;
            this.gV_InvoiceLine.OptionsView.ShowPreview = true;
            this.gV_InvoiceLine.PreviewIndent = 10;
            this.gV_InvoiceLine.CalcPreviewText += new DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventHandler(this.gV_InvoiceLine_CalcPreviewText);
            this.gV_InvoiceLine.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_InvoiceLine_FocusedRowChanged);
            // 
            // col_ProductDesc
            // 
            this.col_ProductDesc.Caption = "Məhsul";
            this.col_ProductDesc.FieldName = "DcProduct.ProductDescription";
            this.col_ProductDesc.Name = "col_ProductDesc";
            this.col_ProductDesc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "DcProduct.ProductDescription", "Toplam:")});
            this.col_ProductDesc.Visible = true;
            this.col_ProductDesc.VisibleIndex = 0;
            // 
            // col_Qty
            // 
            this.col_Qty.Caption = "Say";
            this.col_Qty.FieldName = "Qty";
            this.col_Qty.Name = "col_Qty";
            this.col_Qty.Visible = true;
            this.col_Qty.VisibleIndex = 1;
            this.col_Qty.Width = 39;
            // 
            // col_Price
            // 
            this.col_Price.Caption = "Qiymət";
            this.col_Price.FieldName = "Price";
            this.col_Price.Name = "col_Price";
            this.col_Price.Visible = true;
            this.col_Price.VisibleIndex = 2;
            this.col_Price.Width = 43;
            // 
            // col_NetAmount
            // 
            this.col_NetAmount.Caption = "Net Tutar";
            this.col_NetAmount.DisplayFormat.FormatString = "{0:0.##}";
            this.col_NetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_NetAmount.FieldName = "NetAmount";
            this.col_NetAmount.Name = "col_NetAmount";
            this.col_NetAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetAmount", "{0:0.##}")});
            this.col_NetAmount.Visible = true;
            this.col_NetAmount.VisibleIndex = 3;
            this.col_NetAmount.Width = 70;
            // 
            // col_Barcode
            // 
            this.col_Barcode.Caption = "Barkod";
            this.col_Barcode.FieldName = "Barcode";
            this.col_Barcode.Name = "col_Barcode";
            // 
            // col_PosDiscount
            // 
            this.col_PosDiscount.Caption = "Endirim Faizi";
            this.col_PosDiscount.FieldName = "PosDiscount";
            this.col_PosDiscount.Name = "col_PosDiscount";
            // 
            // col_Amount
            // 
            this.col_Amount.Caption = "Tutar";
            this.col_Amount.FieldName = "Amount";
            this.col_Amount.Name = "col_Amount";
            // 
            // col_VatRate
            // 
            this.col_VatRate.Caption = "ƏDV";
            this.col_VatRate.FieldName = "VatRate";
            this.col_VatRate.Name = "col_VatRate";
            // 
            // col_SalesPersonCode
            // 
            this.col_SalesPersonCode.Caption = "Satıcı";
            this.col_SalesPersonCode.FieldName = "SalesPersonCode";
            this.col_SalesPersonCode.Name = "col_SalesPersonCode";
            // 
            // btn_ProductSearch
            // 
            this.btn_ProductSearch.AllowFocus = false;
            this.btn_ProductSearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_ProductSearch.Appearance.Options.UseBackColor = true;
            this.btn_ProductSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_ProductSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ProductSearch.ImageOptions.SvgImage")));
            this.btn_ProductSearch.Location = new System.Drawing.Point(772, 254);
            this.btn_ProductSearch.Name = "btn_ProductSearch";
            this.btn_ProductSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_ProductSearch.Size = new System.Drawing.Size(83, 72);
            this.btn_ProductSearch.StyleController = this.lC_InvoiceLine;
            this.btn_ProductSearch.TabIndex = 20;
            this.btn_ProductSearch.Text = "Məhsul";
            this.btn_ProductSearch.Click += new System.EventHandler(this.btn_ProductSearch_Click);
            // 
            // btn_Discount
            // 
            this.btn_Discount.AllowFocus = false;
            this.btn_Discount.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_Discount.Appearance.Options.UseBackColor = true;
            this.btn_Discount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Discount.ImageOptions.Image")));
            this.btn_Discount.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Discount.Location = new System.Drawing.Point(859, 254);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Discount.Size = new System.Drawing.Size(83, 72);
            this.btn_Discount.StyleController = this.lC_InvoiceLine;
            this.btn_Discount.TabIndex = 25;
            this.btn_Discount.Text = "Endirim";
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // btn_CancelInvoice
            // 
            this.btn_CancelInvoice.AllowFocus = false;
            this.btn_CancelInvoice.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_CancelInvoice.Appearance.Options.UseBackColor = true;
            this.btn_CancelInvoice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CancelInvoice.ImageOptions.Image")));
            this.btn_CancelInvoice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_CancelInvoice.Location = new System.Drawing.Point(1033, 254);
            this.btn_CancelInvoice.Name = "btn_CancelInvoice";
            this.btn_CancelInvoice.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_CancelInvoice.Size = new System.Drawing.Size(85, 72);
            this.btn_CancelInvoice.StyleController = this.lC_InvoiceLine;
            this.btn_CancelInvoice.TabIndex = 29;
            this.btn_CancelInvoice.Text = "Çeki Ləğv Et";
            this.btn_CancelInvoice.Click += new System.EventHandler(this.btn_CancelInvoice_Click);
            // 
            // btn_DeleteLine
            // 
            this.btn_DeleteLine.AllowFocus = false;
            this.btn_DeleteLine.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_DeleteLine.Appearance.Options.UseBackColor = true;
            this.btn_DeleteLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeleteLine.ImageOptions.Image")));
            this.btn_DeleteLine.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_DeleteLine.Location = new System.Drawing.Point(946, 254);
            this.btn_DeleteLine.Name = "btn_DeleteLine";
            this.btn_DeleteLine.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_DeleteLine.Size = new System.Drawing.Size(83, 72);
            this.btn_DeleteLine.StyleController = this.lC_InvoiceLine;
            this.btn_DeleteLine.TabIndex = 30;
            this.btn_DeleteLine.Text = "Sətri Sil";
            this.btn_DeleteLine.Click += new System.EventHandler(this.btn_DeleteLine_Click);
            // 
            // btn_SalesPerson
            // 
            this.btn_SalesPerson.AllowFocus = false;
            this.btn_SalesPerson.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_SalesPerson.Appearance.Options.UseBackColor = true;
            this.btn_SalesPerson.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SalesPerson.ImageOptions.Image")));
            this.btn_SalesPerson.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_SalesPerson.Location = new System.Drawing.Point(772, 330);
            this.btn_SalesPerson.Name = "btn_SalesPerson";
            this.btn_SalesPerson.Size = new System.Drawing.Size(83, 73);
            this.btn_SalesPerson.StyleController = this.lC_InvoiceLine;
            this.btn_SalesPerson.TabIndex = 40;
            this.btn_SalesPerson.Text = "Satıcı";
            this.btn_SalesPerson.Click += new System.EventHandler(this.btn_SalesPerson_Click);
            // 
            // txtEdit_CustomerPhoneNum
            // 
            this.txtEdit_CustomerPhoneNum.Enabled = false;
            this.txtEdit_CustomerPhoneNum.Location = new System.Drawing.Point(846, 126);
            this.txtEdit_CustomerPhoneNum.Name = "txtEdit_CustomerPhoneNum";
            // 
            // 
            // 
            this.txtEdit_CustomerPhoneNum.Properties.AllowFocused = false;
            this.txtEdit_CustomerPhoneNum.Size = new System.Drawing.Size(219, 20);
            this.txtEdit_CustomerPhoneNum.StyleController = this.lC_InvoiceLine;
            this.txtEdit_CustomerPhoneNum.TabIndex = 37;
            // 
            // txtEdit_CustomerAddress
            // 
            this.txtEdit_CustomerAddress.Enabled = false;
            this.txtEdit_CustomerAddress.Location = new System.Drawing.Point(846, 153);
            this.txtEdit_CustomerAddress.Name = "txtEdit_CustomerAddress";
            // 
            // 
            // 
            this.txtEdit_CustomerAddress.Properties.AllowFocused = false;
            this.txtEdit_CustomerAddress.Size = new System.Drawing.Size(219, 20);
            this.txtEdit_CustomerAddress.StyleController = this.lC_InvoiceLine;
            this.txtEdit_CustomerAddress.TabIndex = 38;
            // 
            // txtEdit_CustomerName
            // 
            this.txtEdit_CustomerName.Enabled = false;
            this.txtEdit_CustomerName.Location = new System.Drawing.Point(846, 99);
            this.txtEdit_CustomerName.Name = "txtEdit_CustomerName";
            // 
            // 
            // 
            this.txtEdit_CustomerName.Properties.AllowFocused = false;
            this.txtEdit_CustomerName.Size = new System.Drawing.Size(219, 20);
            this.txtEdit_CustomerName.StyleController = this.lC_InvoiceLine;
            this.txtEdit_CustomerName.TabIndex = 35;
            // 
            // btn_CustomerSearch
            // 
            this.btn_CustomerSearch.AllowFocus = false;
            this.btn_CustomerSearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.Appearance.Options.UseBackColor = true;
            this.btn_CustomerSearch.Appearance.Options.UseBorderColor = true;
            this.btn_CustomerSearch.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearanceDisabled.Options.UseBackColor = true;
            this.btn_CustomerSearch.AppearanceDisabled.Options.UseBorderColor = true;
            this.btn_CustomerSearch.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearanceHovered.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearanceHovered.Options.UseBackColor = true;
            this.btn_CustomerSearch.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_CustomerSearch.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearancePressed.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerSearch.AppearancePressed.Options.UseBackColor = true;
            this.btn_CustomerSearch.AppearancePressed.Options.UseBorderColor = true;
            this.btn_CustomerSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerSearch.ImageOptions.Image")));
            this.btn_CustomerSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_CustomerSearch.Location = new System.Drawing.Point(1069, 45);
            this.btn_CustomerSearch.Name = "btn_CustomerSearch";
            this.btn_CustomerSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_CustomerSearch.Size = new System.Drawing.Size(49, 50);
            this.btn_CustomerSearch.StyleController = this.lC_InvoiceLine;
            this.btn_CustomerSearch.TabIndex = 32;
            this.btn_CustomerSearch.Text = "simpleButton3";
            this.btn_CustomerSearch.Click += new System.EventHandler(this.btn_CustomerSearch_Click);
            // 
            // btn_CustomerEdit
            // 
            this.btn_CustomerEdit.AllowFocus = false;
            this.btn_CustomerEdit.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.Appearance.Options.UseBackColor = true;
            this.btn_CustomerEdit.Appearance.Options.UseBorderColor = true;
            this.btn_CustomerEdit.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearanceDisabled.Options.UseBackColor = true;
            this.btn_CustomerEdit.AppearanceDisabled.Options.UseBorderColor = true;
            this.btn_CustomerEdit.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearanceHovered.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearanceHovered.Options.UseBackColor = true;
            this.btn_CustomerEdit.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_CustomerEdit.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearancePressed.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerEdit.AppearancePressed.Options.UseBackColor = true;
            this.btn_CustomerEdit.AppearancePressed.Options.UseBorderColor = true;
            this.btn_CustomerEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerEdit.ImageOptions.Image")));
            this.btn_CustomerEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_CustomerEdit.Location = new System.Drawing.Point(1069, 153);
            this.btn_CustomerEdit.Name = "btn_CustomerEdit";
            this.btn_CustomerEdit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_CustomerEdit.Size = new System.Drawing.Size(49, 52);
            this.btn_CustomerEdit.StyleController = this.lC_InvoiceLine;
            this.btn_CustomerEdit.TabIndex = 33;
            this.btn_CustomerEdit.Text = "simpleButton4";
            this.btn_CustomerEdit.Click += new System.EventHandler(this.btn_Customer_Click);
            // 
            // btn_CustomerAdd
            // 
            this.btn_CustomerAdd.AllowFocus = false;
            this.btn_CustomerAdd.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.Appearance.Options.UseBackColor = true;
            this.btn_CustomerAdd.Appearance.Options.UseBorderColor = true;
            this.btn_CustomerAdd.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearanceDisabled.Options.UseBackColor = true;
            this.btn_CustomerAdd.AppearanceDisabled.Options.UseBorderColor = true;
            this.btn_CustomerAdd.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearanceHovered.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearanceHovered.Options.UseBackColor = true;
            this.btn_CustomerAdd.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_CustomerAdd.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearancePressed.BackColor2 = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.btn_CustomerAdd.AppearancePressed.Options.UseBackColor = true;
            this.btn_CustomerAdd.AppearancePressed.Options.UseBorderColor = true;
            this.btn_CustomerAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerAdd.ImageOptions.Image")));
            this.btn_CustomerAdd.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_CustomerAdd.Location = new System.Drawing.Point(1069, 99);
            this.btn_CustomerAdd.Name = "btn_CustomerAdd";
            this.btn_CustomerAdd.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_CustomerAdd.Size = new System.Drawing.Size(49, 50);
            this.btn_CustomerAdd.StyleController = this.lC_InvoiceLine;
            this.btn_CustomerAdd.TabIndex = 31;
            this.btn_CustomerAdd.Text = "simpleButton1";
            this.btn_CustomerAdd.Click += new System.EventHandler(this.btn_Customer_Click);
            // 
            // txtEdit_BonCardNum
            // 
            this.txtEdit_BonCardNum.Enabled = false;
            this.txtEdit_BonCardNum.Location = new System.Drawing.Point(846, 180);
            this.txtEdit_BonCardNum.Name = "txtEdit_BonCardNum";
            // 
            // 
            // 
            this.txtEdit_BonCardNum.Properties.AllowFocused = false;
            this.txtEdit_BonCardNum.Size = new System.Drawing.Size(219, 20);
            this.txtEdit_BonCardNum.StyleController = this.lC_InvoiceLine;
            this.txtEdit_BonCardNum.TabIndex = 39;
            // 
            // txtEdit_CustomerCode
            // 
            this.txtEdit_CustomerCode.Enabled = false;
            this.txtEdit_CustomerCode.Location = new System.Drawing.Point(846, 72);
            this.txtEdit_CustomerCode.Name = "txtEdit_CustomerCode";
            this.txtEdit_CustomerCode.Size = new System.Drawing.Size(219, 20);
            this.txtEdit_CustomerCode.StyleController = this.lC_InvoiceLine;
            this.txtEdit_CustomerCode.TabIndex = 42;
            // 
            // btn_Cash
            // 
            this.btn_Cash.AllowFocus = false;
            this.btn_Cash.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cash.Appearance.Options.UseBackColor = true;
            this.btn_Cash.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cash.ImageOptions.Image")));
            this.btn_Cash.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Cash.Location = new System.Drawing.Point(772, 606);
            this.btn_Cash.Name = "btn_Cash";
            this.btn_Cash.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Cash.Size = new System.Drawing.Size(83, 89);
            this.btn_Cash.StyleController = this.lC_InvoiceLine;
            this.btn_Cash.TabIndex = 27;
            this.btn_Cash.Text = "Cash";
            this.btn_Cash.Click += new System.EventHandler(this.btn_Payment_Click);
            // 
            // btn_Cashless
            // 
            this.btn_Cashless.AllowFocus = false;
            this.btn_Cashless.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cashless.ImageOptions.Image")));
            this.btn_Cashless.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Cashless.Location = new System.Drawing.Point(859, 606);
            this.btn_Cashless.Name = "btn_Cashless";
            this.btn_Cashless.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Cashless.Size = new System.Drawing.Size(83, 89);
            this.btn_Cashless.StyleController = this.lC_InvoiceLine;
            this.btn_Cashless.TabIndex = 26;
            this.btn_Cashless.Text = "Visa";
            this.btn_Cashless.Click += new System.EventHandler(this.btn_Payment_Click);
            // 
            // btn_CustomerBonus
            // 
            this.btn_CustomerBonus.AllowFocus = false;
            this.btn_CustomerBonus.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CustomerBonus.ImageOptions.Image")));
            this.btn_CustomerBonus.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_CustomerBonus.Location = new System.Drawing.Point(946, 606);
            this.btn_CustomerBonus.Name = "btn_CustomerBonus";
            this.btn_CustomerBonus.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_CustomerBonus.Size = new System.Drawing.Size(83, 89);
            this.btn_CustomerBonus.StyleController = this.lC_InvoiceLine;
            this.btn_CustomerBonus.TabIndex = 28;
            this.btn_CustomerBonus.Text = "Bonus";
            this.btn_CustomerBonus.Click += new System.EventHandler(this.btn_Payment_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.ImageOptions.Image")));
            this.btn_Print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_Print.Location = new System.Drawing.Point(859, 330);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(83, 73);
            this.btn_Print.StyleController = this.lC_InvoiceLine;
            this.btn_Print.TabIndex = 43;
            this.btn_Print.Text = "Çap";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_PrintDesign
            // 
            this.btn_PrintDesign.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PrintDesign.ImageOptions.Image")));
            this.btn_PrintDesign.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_PrintDesign.Location = new System.Drawing.Point(946, 330);
            this.btn_PrintDesign.Name = "btn_PrintDesign";
            this.btn_PrintDesign.Size = new System.Drawing.Size(83, 73);
            this.btn_PrintDesign.StyleController = this.lC_InvoiceLine;
            this.btn_PrintDesign.TabIndex = 44;
            this.btn_PrintDesign.Text = "Çap Dizayn";
            this.btn_PrintDesign.Click += new System.EventHandler(this.btn_PrintDesign_Click);
            // 
            // btn_ReportZ
            // 
            this.btn_ReportZ.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ReportZ.ImageOptions.Image")));
            this.btn_ReportZ.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_ReportZ.Location = new System.Drawing.Point(1033, 330);
            this.btn_ReportZ.Name = "btn_ReportZ";
            this.btn_ReportZ.Size = new System.Drawing.Size(85, 73);
            this.btn_ReportZ.StyleController = this.lC_InvoiceLine;
            this.btn_ReportZ.TabIndex = 45;
            this.btn_ReportZ.Text = "Gün Sonu";
            this.btn_ReportZ.Click += new System.EventHandler(this.btn_ReportZ_Click);
            // 
            // btn_Num5
            // 
            this.btn_Num5.AllowFocus = false;
            this.btn_Num5.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_Num5.Appearance.Options.UseFont = true;
            this.btn_Num5.Location = new System.Drawing.Point(514, 185);
            this.btn_Num5.Name = "btn_Num5";
            this.btn_Num5.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btn_Num5.Size = new System.Drawing.Size(74, 66);
            this.btn_Num5.StyleController = this.lC_InvoiceLine;
            this.btn_Num5.TabIndex = 46;
            this.btn_Num5.Text = "5";
            this.btn_Num5.Click += new System.EventHandler(this.btn_Num_Click);
            // 
            // lCG_Root
            // 
            this.lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lCG_Root.GroupBordersVisible = false;
            this.lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCG_Barcode,
            this.lCG_Invoice,
            this.lCG_Function,
            this.lCG_Customer,
            this.lCG_Payment,
            this.layoutControlGroup2});
            this.lCG_Root.Name = "Root";
            this.lCG_Root.Size = new System.Drawing.Size(1142, 719);
            this.lCG_Root.TextVisible = false;
            // 
            // lCG_Barcode
            // 
            this.lCG_Barcode.CustomizationFormText = "Barcode";
            this.lCG_Barcode.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_Star,
            this.lCI_Comma,
            this.lCI_Num0,
            this.lCI_Num1,
            this.lCI_Num2,
            this.lCI_Num3,
            this.lCI_Num4,
            this.lCI_Num6,
            this.lCI_Num8,
            this.lCI_Num9,
            this.lCI_Num7,
            this.lCI_Enter,
            this.lCI_C,
            this.lCI_BackSpace,
            this.lCI_ItemTextBox,
            this.lCI_ComboBox,
            this.lCI_Num5});
            this.lCG_Barcode.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.lCG_Barcode.Location = new System.Drawing.Point(412, 0);
            this.lCG_Barcode.Name = "lCG_Barcode";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 25D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 25D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition3.Width = 25D;
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition4.Width = 25D;
            this.lCG_Barcode.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3,
            columnDefinition4});
            rowDefinition1.Height = 20D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 20D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition3.Height = 20D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition4.Height = 20D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition5.Height = 20D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            this.lCG_Barcode.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3,
            rowDefinition4,
            rowDefinition5});
            this.lCG_Barcode.Size = new System.Drawing.Size(336, 396);
            this.lCG_Barcode.Text = "Barcode";
            // 
            // lCI_Star
            // 
            this.lCI_Star.Control = this.btn_Star;
            this.lCI_Star.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Star.CustomizationFormText = "layoutControlItemStar";
            this.lCI_Star.Location = new System.Drawing.Point(0, 280);
            this.lCI_Star.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Star.Name = "lCI_Star";
            this.lCI_Star.OptionsTableLayoutItem.RowIndex = 4;
            this.lCI_Star.Size = new System.Drawing.Size(78, 71);
            this.lCI_Star.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Star.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Star.TextVisible = false;
            // 
            // lCI_Comma
            // 
            this.lCI_Comma.Control = this.btn_Comma;
            this.lCI_Comma.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Comma.CustomizationFormText = "layoutControlItemComma";
            this.lCI_Comma.Location = new System.Drawing.Point(156, 280);
            this.lCI_Comma.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Comma.Name = "lCI_Comma";
            this.lCI_Comma.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_Comma.OptionsTableLayoutItem.RowIndex = 4;
            this.lCI_Comma.Size = new System.Drawing.Size(78, 71);
            this.lCI_Comma.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Comma.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Comma.TextVisible = false;
            // 
            // lCI_Num0
            // 
            this.lCI_Num0.Control = this.btn_Num0;
            this.lCI_Num0.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num0.CustomizationFormText = "layoutControlItemNum0";
            this.lCI_Num0.Location = new System.Drawing.Point(78, 280);
            this.lCI_Num0.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num0.Name = "lCI_Num0";
            this.lCI_Num0.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Num0.OptionsTableLayoutItem.RowIndex = 4;
            this.lCI_Num0.Size = new System.Drawing.Size(78, 71);
            this.lCI_Num0.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num0.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num0.TextVisible = false;
            // 
            // lCI_Num1
            // 
            this.lCI_Num1.Control = this.btn_Num1;
            this.lCI_Num1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num1.CustomizationFormText = "layoutControlItemNum1";
            this.lCI_Num1.Location = new System.Drawing.Point(0, 210);
            this.lCI_Num1.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num1.Name = "lCI_Num1";
            this.lCI_Num1.OptionsTableLayoutItem.RowIndex = 3;
            this.lCI_Num1.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num1.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num1.TextVisible = false;
            // 
            // lCI_Num2
            // 
            this.lCI_Num2.Control = this.btn_Num2;
            this.lCI_Num2.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num2.CustomizationFormText = "layoutControlItemNum2";
            this.lCI_Num2.Location = new System.Drawing.Point(78, 210);
            this.lCI_Num2.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num2.Name = "lCI_Num2";
            this.lCI_Num2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Num2.OptionsTableLayoutItem.RowIndex = 3;
            this.lCI_Num2.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num2.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num2.TextVisible = false;
            // 
            // lCI_Num3
            // 
            this.lCI_Num3.Control = this.btn_Num3;
            this.lCI_Num3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num3.CustomizationFormText = "layoutControlItemNum3";
            this.lCI_Num3.Location = new System.Drawing.Point(156, 210);
            this.lCI_Num3.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num3.Name = "lCI_Num3";
            this.lCI_Num3.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_Num3.OptionsTableLayoutItem.RowIndex = 3;
            this.lCI_Num3.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num3.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num3.TextVisible = false;
            // 
            // lCI_Num4
            // 
            this.lCI_Num4.Control = this.btn_Num4;
            this.lCI_Num4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num4.CustomizationFormText = "layoutControlItemNum4";
            this.lCI_Num4.Location = new System.Drawing.Point(0, 140);
            this.lCI_Num4.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num4.Name = "lCI_Num4";
            this.lCI_Num4.OptionsTableLayoutItem.RowIndex = 2;
            this.lCI_Num4.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num4.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num4.TextVisible = false;
            // 
            // lCI_Num6
            // 
            this.lCI_Num6.Control = this.btn_Num6;
            this.lCI_Num6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num6.CustomizationFormText = "layoutControlItemNum6";
            this.lCI_Num6.Location = new System.Drawing.Point(156, 140);
            this.lCI_Num6.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num6.Name = "lCI_Num6";
            this.lCI_Num6.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_Num6.OptionsTableLayoutItem.RowIndex = 2;
            this.lCI_Num6.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num6.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num6.TextVisible = false;
            // 
            // lCI_Num8
            // 
            this.lCI_Num8.Control = this.btn_Num8;
            this.lCI_Num8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num8.CustomizationFormText = "layoutControlItemNum8";
            this.lCI_Num8.Location = new System.Drawing.Point(78, 70);
            this.lCI_Num8.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num8.Name = "lCI_Num8";
            this.lCI_Num8.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Num8.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_Num8.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num8.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num8.TextVisible = false;
            // 
            // lCI_Num9
            // 
            this.lCI_Num9.Control = this.btn_Num9;
            this.lCI_Num9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num9.CustomizationFormText = "layoutControlItemNum9";
            this.lCI_Num9.Location = new System.Drawing.Point(156, 70);
            this.lCI_Num9.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num9.Name = "lCI_Num9";
            this.lCI_Num9.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_Num9.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_Num9.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num9.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num9.TextVisible = false;
            // 
            // lCI_Num7
            // 
            this.lCI_Num7.Control = this.btn_Num7;
            this.lCI_Num7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Num7.CustomizationFormText = "layoutControlItemNum7";
            this.lCI_Num7.Location = new System.Drawing.Point(0, 70);
            this.lCI_Num7.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Num7.Name = "lCI_Num7";
            this.lCI_Num7.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_Num7.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num7.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num7.TextVisible = false;
            // 
            // lCI_Enter
            // 
            this.lCI_Enter.Control = this.btn_Enter;
            this.lCI_Enter.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Enter.CustomizationFormText = "layoutControlItemEnter";
            this.lCI_Enter.Location = new System.Drawing.Point(234, 210);
            this.lCI_Enter.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Enter.Name = "lCI_Enter";
            this.lCI_Enter.OptionsTableLayoutItem.ColumnIndex = 3;
            this.lCI_Enter.OptionsTableLayoutItem.RowIndex = 3;
            this.lCI_Enter.OptionsTableLayoutItem.RowSpan = 2;
            this.lCI_Enter.Size = new System.Drawing.Size(78, 141);
            this.lCI_Enter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Enter.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Enter.TextVisible = false;
            // 
            // lCI_C
            // 
            this.lCI_C.Control = this.btn_C;
            this.lCI_C.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_C.CustomizationFormText = "layoutControlItemC";
            this.lCI_C.Location = new System.Drawing.Point(234, 140);
            this.lCI_C.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_C.Name = "lCI_C";
            this.lCI_C.OptionsTableLayoutItem.ColumnIndex = 3;
            this.lCI_C.OptionsTableLayoutItem.RowIndex = 2;
            this.lCI_C.Size = new System.Drawing.Size(78, 70);
            this.lCI_C.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_C.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_C.TextVisible = false;
            // 
            // lCI_BackSpace
            // 
            this.lCI_BackSpace.Control = this.btn_BackSpace;
            this.lCI_BackSpace.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_BackSpace.CustomizationFormText = "layoutControlItemBackSpace";
            this.lCI_BackSpace.Location = new System.Drawing.Point(234, 70);
            this.lCI_BackSpace.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_BackSpace.Name = "lCI_BackSpace";
            this.lCI_BackSpace.OptionsTableLayoutItem.ColumnIndex = 3;
            this.lCI_BackSpace.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_BackSpace.Size = new System.Drawing.Size(78, 70);
            this.lCI_BackSpace.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_BackSpace.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_BackSpace.TextVisible = false;
            // 
            // lCI_ItemTextBox
            // 
            this.lCI_ItemTextBox.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lCI_ItemTextBox.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lCI_ItemTextBox.Control = this.txtEdit_Barcode;
            this.lCI_ItemTextBox.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_ItemTextBox.CustomizationFormText = "layoutControlItemTextBox";
            this.lCI_ItemTextBox.Location = new System.Drawing.Point(78, 0);
            this.lCI_ItemTextBox.MinSize = new System.Drawing.Size(40, 24);
            this.lCI_ItemTextBox.Name = "lCI_ItemTextBox";
            this.lCI_ItemTextBox.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_ItemTextBox.OptionsTableLayoutItem.ColumnSpan = 3;
            this.lCI_ItemTextBox.Size = new System.Drawing.Size(234, 70);
            this.lCI_ItemTextBox.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_ItemTextBox.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_ItemTextBox.TextVisible = false;
            // 
            // lCI_ComboBox
            // 
            this.lCI_ComboBox.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lCI_ComboBox.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lCI_ComboBox.Control = this.imageComboEdit_Barcode;
            this.lCI_ComboBox.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_ComboBox.CustomizationFormText = "layoutControlItemComboBox";
            this.lCI_ComboBox.Location = new System.Drawing.Point(0, 0);
            this.lCI_ComboBox.MinSize = new System.Drawing.Size(40, 24);
            this.lCI_ComboBox.Name = "lCI_ComboBox";
            this.lCI_ComboBox.Size = new System.Drawing.Size(78, 70);
            this.lCI_ComboBox.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_ComboBox.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_ComboBox.TextVisible = false;
            // 
            // lCI_Num5
            // 
            this.lCI_Num5.Control = this.btn_Num5;
            this.lCI_Num5.Location = new System.Drawing.Point(78, 140);
            this.lCI_Num5.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_Num5.Name = "lCI_Num5";
            this.lCI_Num5.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Num5.OptionsTableLayoutItem.RowIndex = 2;
            this.lCI_Num5.Size = new System.Drawing.Size(78, 70);
            this.lCI_Num5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Num5.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Num5.TextVisible = false;
            // 
            // lCG_Invoice
            // 
            this.lCG_Invoice.CustomizationFormText = "Satış";
            this.lCG_Invoice.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_GridView});
            this.lCG_Invoice.Location = new System.Drawing.Point(0, 0);
            this.lCG_Invoice.Name = "lCG_Invoice";
            this.lCG_Invoice.Size = new System.Drawing.Size(412, 699);
            this.lCG_Invoice.Text = "Satış";
            // 
            // lCI_GridView
            // 
            this.lCI_GridView.Control = this.gC_InvoiceLine;
            this.lCI_GridView.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_GridView.CustomizationFormText = "layoutControlItemGridView";
            this.lCI_GridView.Location = new System.Drawing.Point(0, 0);
            this.lCI_GridView.Name = "lCI_GridView";
            this.lCI_GridView.Size = new System.Drawing.Size(388, 654);
            this.lCI_GridView.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_GridView.TextVisible = false;
            // 
            // lCG_Function
            // 
            this.lCG_Function.CustomizationFormText = "Əməliyat";
            this.lCG_Function.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_ProductSearch,
            this.lCI_Discount,
            this.lCI_CancelInvoice,
            this.lCI_DeleteLine,
            this.lCI_SalesPerson,
            this.lCI_Print,
            this.lCI_PrintDesign,
            this.lCI_ReportZ});
            this.lCG_Function.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.lCG_Function.Location = new System.Drawing.Point(748, 209);
            this.lCG_Function.Name = "lCG_Function";
            columnDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition5.Width = 25D;
            columnDefinition6.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition6.Width = 25D;
            columnDefinition7.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition7.Width = 25D;
            columnDefinition8.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition8.Width = 25D;
            this.lCG_Function.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition5,
            columnDefinition6,
            columnDefinition7,
            columnDefinition8});
            rowDefinition6.Height = 25D;
            rowDefinition6.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition7.Height = 25D;
            rowDefinition7.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition8.Height = 25D;
            rowDefinition8.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition9.Height = 25D;
            rowDefinition9.SizeType = System.Windows.Forms.SizeType.Percent;
            this.lCG_Function.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition6,
            rowDefinition7,
            rowDefinition8,
            rowDefinition9});
            this.lCG_Function.Size = new System.Drawing.Size(374, 352);
            this.lCG_Function.Text = "Əməliyat";
            // 
            // lCI_ProductSearch
            // 
            this.lCI_ProductSearch.Control = this.btn_ProductSearch;
            this.lCI_ProductSearch.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_ProductSearch.CustomizationFormText = "layoutControlItemProductSearch";
            this.lCI_ProductSearch.Location = new System.Drawing.Point(0, 0);
            this.lCI_ProductSearch.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_ProductSearch.Name = "lCI_ProductSearch";
            this.lCI_ProductSearch.Size = new System.Drawing.Size(87, 76);
            this.lCI_ProductSearch.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_ProductSearch.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_ProductSearch.TextVisible = false;
            // 
            // lCI_Discount
            // 
            this.lCI_Discount.Control = this.btn_Discount;
            this.lCI_Discount.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Discount.CustomizationFormText = "layoutControlItemDiscount";
            this.lCI_Discount.Location = new System.Drawing.Point(87, 0);
            this.lCI_Discount.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_Discount.Name = "lCI_Discount";
            this.lCI_Discount.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Discount.Size = new System.Drawing.Size(87, 76);
            this.lCI_Discount.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Discount.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Discount.TextVisible = false;
            // 
            // lCI_CancelInvoice
            // 
            this.lCI_CancelInvoice.Control = this.btn_CancelInvoice;
            this.lCI_CancelInvoice.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CancelInvoice.CustomizationFormText = "layoutControlItemCancelInvoice";
            this.lCI_CancelInvoice.Location = new System.Drawing.Point(261, 0);
            this.lCI_CancelInvoice.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_CancelInvoice.Name = "lCI_CancelInvoice";
            this.lCI_CancelInvoice.OptionsTableLayoutItem.ColumnIndex = 3;
            this.lCI_CancelInvoice.Size = new System.Drawing.Size(89, 76);
            this.lCI_CancelInvoice.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CancelInvoice.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_CancelInvoice.TextVisible = false;
            // 
            // lCI_DeleteLine
            // 
            this.lCI_DeleteLine.Control = this.btn_DeleteLine;
            this.lCI_DeleteLine.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_DeleteLine.CustomizationFormText = "layoutControlItemDeleteLine";
            this.lCI_DeleteLine.Location = new System.Drawing.Point(174, 0);
            this.lCI_DeleteLine.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_DeleteLine.Name = "lCI_DeleteLine";
            this.lCI_DeleteLine.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_DeleteLine.Size = new System.Drawing.Size(87, 76);
            this.lCI_DeleteLine.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_DeleteLine.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_DeleteLine.TextVisible = false;
            // 
            // lCI_SalesPerson
            // 
            this.lCI_SalesPerson.Control = this.btn_SalesPerson;
            this.lCI_SalesPerson.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_SalesPerson.CustomizationFormText = "layoutControlItemSalesPerson";
            this.lCI_SalesPerson.Location = new System.Drawing.Point(0, 76);
            this.lCI_SalesPerson.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_SalesPerson.Name = "lCI_SalesPerson";
            this.lCI_SalesPerson.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_SalesPerson.Size = new System.Drawing.Size(87, 77);
            this.lCI_SalesPerson.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_SalesPerson.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_SalesPerson.TextVisible = false;
            // 
            // lCI_Print
            // 
            this.lCI_Print.Control = this.btn_Print;
            this.lCI_Print.Location = new System.Drawing.Point(87, 76);
            this.lCI_Print.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_Print.Name = "lCI_Print";
            this.lCI_Print.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Print.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_Print.Size = new System.Drawing.Size(87, 77);
            this.lCI_Print.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Print.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Print.TextVisible = false;
            // 
            // lCI_PrintDesign
            // 
            this.lCI_PrintDesign.Control = this.btn_PrintDesign;
            this.lCI_PrintDesign.Location = new System.Drawing.Point(174, 76);
            this.lCI_PrintDesign.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_PrintDesign.Name = "lCI_PrintDesign";
            this.lCI_PrintDesign.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_PrintDesign.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_PrintDesign.Size = new System.Drawing.Size(87, 77);
            this.lCI_PrintDesign.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_PrintDesign.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_PrintDesign.TextVisible = false;
            // 
            // lCI_ReportZ
            // 
            this.lCI_ReportZ.Control = this.btn_ReportZ;
            this.lCI_ReportZ.Location = new System.Drawing.Point(261, 76);
            this.lCI_ReportZ.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_ReportZ.Name = "lCI_ReportZ";
            this.lCI_ReportZ.OptionsTableLayoutItem.ColumnIndex = 3;
            this.lCI_ReportZ.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_ReportZ.Size = new System.Drawing.Size(89, 77);
            this.lCI_ReportZ.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_ReportZ.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_ReportZ.TextVisible = false;
            // 
            // lCG_Customer
            // 
            this.lCG_Customer.CustomizationFormText = "Müştəri";
            this.lCG_Customer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_CustomerSearch,
            this.lCI_BonusCardNum,
            this.lCI_CustomerAddress,
            this.lCI_CustomerTel,
            this.lCI_CustomerName,
            this.lCI_CustomerCode,
            this.lCI_CustomerAdd,
            this.lCI_CustomerEdit});
            this.lCG_Customer.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.lCG_Customer.Location = new System.Drawing.Point(748, 0);
            this.lCG_Customer.Name = "lCG_Customer";
            columnDefinition9.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition9.Width = 85D;
            columnDefinition10.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition10.Width = 15D;
            this.lCG_Customer.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition9,
            columnDefinition10});
            rowDefinition10.Height = 16.7D;
            rowDefinition10.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition11.Height = 16.7D;
            rowDefinition11.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition12.Height = 16.7D;
            rowDefinition12.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition13.Height = 16.7D;
            rowDefinition13.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition14.Height = 16.7D;
            rowDefinition14.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition15.Height = 16.7D;
            rowDefinition15.SizeType = System.Windows.Forms.SizeType.Percent;
            this.lCG_Customer.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition10,
            rowDefinition11,
            rowDefinition12,
            rowDefinition13,
            rowDefinition14,
            rowDefinition15});
            this.lCG_Customer.Size = new System.Drawing.Size(374, 209);
            this.lCG_Customer.Text = "Müştəri";
            // 
            // lCI_CustomerSearch
            // 
            this.lCI_CustomerSearch.Control = this.btn_CustomerSearch;
            this.lCI_CustomerSearch.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerSearch.CustomizationFormText = "layoutControlItemCustomerSearch";
            this.lCI_CustomerSearch.Location = new System.Drawing.Point(297, 0);
            this.lCI_CustomerSearch.MinSize = new System.Drawing.Size(26, 26);
            this.lCI_CustomerSearch.Name = "lCI_CustomerSearch";
            this.lCI_CustomerSearch.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_CustomerSearch.OptionsTableLayoutItem.RowSpan = 2;
            this.lCI_CustomerSearch.Size = new System.Drawing.Size(53, 54);
            this.lCI_CustomerSearch.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerSearch.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_CustomerSearch.TextVisible = false;
            // 
            // lCI_BonusCardNum
            // 
            this.lCI_BonusCardNum.Control = this.txtEdit_BonCardNum;
            this.lCI_BonusCardNum.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_BonusCardNum.CustomizationFormText = "Müştəri Kartı";
            this.lCI_BonusCardNum.Enabled = false;
            this.lCI_BonusCardNum.Location = new System.Drawing.Point(0, 135);
            this.lCI_BonusCardNum.MinSize = new System.Drawing.Size(119, 24);
            this.lCI_BonusCardNum.Name = "lCI_BonusCardNum";
            this.lCI_BonusCardNum.OptionsTableLayoutItem.RowIndex = 5;
            this.lCI_BonusCardNum.Size = new System.Drawing.Size(297, 29);
            this.lCI_BonusCardNum.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_BonusCardNum.Text = "Müştəri Kartı";
            this.lCI_BonusCardNum.TextSize = new System.Drawing.Size(62, 13);
            // 
            // lCI_CustomerAddress
            // 
            this.lCI_CustomerAddress.Control = this.txtEdit_CustomerAddress;
            this.lCI_CustomerAddress.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerAddress.CustomizationFormText = "Adres";
            this.lCI_CustomerAddress.Enabled = false;
            this.lCI_CustomerAddress.Location = new System.Drawing.Point(0, 108);
            this.lCI_CustomerAddress.MinSize = new System.Drawing.Size(119, 24);
            this.lCI_CustomerAddress.Name = "lCI_CustomerAddress";
            this.lCI_CustomerAddress.OptionsTableLayoutItem.RowIndex = 4;
            this.lCI_CustomerAddress.Size = new System.Drawing.Size(297, 27);
            this.lCI_CustomerAddress.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerAddress.Text = "Adres";
            this.lCI_CustomerAddress.TextSize = new System.Drawing.Size(62, 13);
            // 
            // lCI_CustomerTel
            // 
            this.lCI_CustomerTel.Control = this.txtEdit_CustomerPhoneNum;
            this.lCI_CustomerTel.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerTel.CustomizationFormText = "Telefon";
            this.lCI_CustomerTel.Enabled = false;
            this.lCI_CustomerTel.Location = new System.Drawing.Point(0, 81);
            this.lCI_CustomerTel.MinSize = new System.Drawing.Size(119, 24);
            this.lCI_CustomerTel.Name = "lCI_CustomerTel";
            this.lCI_CustomerTel.OptionsTableLayoutItem.RowIndex = 3;
            this.lCI_CustomerTel.Size = new System.Drawing.Size(297, 27);
            this.lCI_CustomerTel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerTel.Text = "Telefon";
            this.lCI_CustomerTel.TextSize = new System.Drawing.Size(62, 13);
            // 
            // lCI_CustomerName
            // 
            this.lCI_CustomerName.Control = this.txtEdit_CustomerName;
            this.lCI_CustomerName.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerName.CustomizationFormText = "Adı, Soyadı";
            this.lCI_CustomerName.Enabled = false;
            this.lCI_CustomerName.Location = new System.Drawing.Point(0, 54);
            this.lCI_CustomerName.MinSize = new System.Drawing.Size(119, 24);
            this.lCI_CustomerName.Name = "lCI_CustomerName";
            this.lCI_CustomerName.OptionsTableLayoutItem.RowIndex = 2;
            this.lCI_CustomerName.Size = new System.Drawing.Size(297, 27);
            this.lCI_CustomerName.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerName.Text = "Adı, Soyadı";
            this.lCI_CustomerName.TextSize = new System.Drawing.Size(62, 13);
            // 
            // lCI_CustomerCode
            // 
            this.lCI_CustomerCode.Control = this.txtEdit_CustomerCode;
            this.lCI_CustomerCode.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerCode.CustomizationFormText = "Müştəri Kodu";
            this.lCI_CustomerCode.Enabled = false;
            this.lCI_CustomerCode.Location = new System.Drawing.Point(0, 27);
            this.lCI_CustomerCode.MinSize = new System.Drawing.Size(119, 24);
            this.lCI_CustomerCode.Name = "lCI_CustomerCode";
            this.lCI_CustomerCode.OptionsTableLayoutItem.RowIndex = 1;
            this.lCI_CustomerCode.Size = new System.Drawing.Size(297, 27);
            this.lCI_CustomerCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerCode.Text = "Müştəri Kodu";
            this.lCI_CustomerCode.TextSize = new System.Drawing.Size(62, 13);
            // 
            // lCI_CustomerAdd
            // 
            this.lCI_CustomerAdd.Control = this.btn_CustomerAdd;
            this.lCI_CustomerAdd.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerAdd.CustomizationFormText = "layoutControlItemCustomerAdd";
            this.lCI_CustomerAdd.Location = new System.Drawing.Point(297, 54);
            this.lCI_CustomerAdd.MinSize = new System.Drawing.Size(26, 26);
            this.lCI_CustomerAdd.Name = "lCI_CustomerAdd";
            this.lCI_CustomerAdd.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_CustomerAdd.OptionsTableLayoutItem.RowIndex = 2;
            this.lCI_CustomerAdd.OptionsTableLayoutItem.RowSpan = 2;
            this.lCI_CustomerAdd.Size = new System.Drawing.Size(53, 54);
            this.lCI_CustomerAdd.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerAdd.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_CustomerAdd.TextVisible = false;
            // 
            // lCI_CustomerEdit
            // 
            this.lCI_CustomerEdit.Control = this.btn_CustomerEdit;
            this.lCI_CustomerEdit.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerEdit.CustomizationFormText = "layoutControlItemCustomerEdit";
            this.lCI_CustomerEdit.Location = new System.Drawing.Point(297, 108);
            this.lCI_CustomerEdit.MinSize = new System.Drawing.Size(26, 26);
            this.lCI_CustomerEdit.Name = "lCI_CustomerEdit";
            this.lCI_CustomerEdit.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_CustomerEdit.OptionsTableLayoutItem.RowIndex = 4;
            this.lCI_CustomerEdit.OptionsTableLayoutItem.RowSpan = 2;
            this.lCI_CustomerEdit.Size = new System.Drawing.Size(53, 56);
            this.lCI_CustomerEdit.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerEdit.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_CustomerEdit.TextVisible = false;
            // 
            // lCG_Payment
            // 
            this.lCG_Payment.CustomizationFormText = "Ödəmə";
            this.lCG_Payment.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_Cash,
            this.lCI_Cashless,
            this.lCI_CustomerBonus});
            this.lCG_Payment.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.lCG_Payment.Location = new System.Drawing.Point(748, 561);
            this.lCG_Payment.Name = "lCG_Payment";
            columnDefinition11.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition11.Width = 25D;
            columnDefinition12.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition12.Width = 25D;
            columnDefinition13.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition13.Width = 25D;
            columnDefinition14.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition14.Width = 25D;
            this.lCG_Payment.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition11,
            columnDefinition12,
            columnDefinition13,
            columnDefinition14});
            rowDefinition16.Height = 100D;
            rowDefinition16.SizeType = System.Windows.Forms.SizeType.Percent;
            this.lCG_Payment.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition16});
            this.lCG_Payment.Size = new System.Drawing.Size(374, 138);
            this.lCG_Payment.Text = "Ödəmə";
            // 
            // lCI_Cash
            // 
            this.lCI_Cash.Control = this.btn_Cash;
            this.lCI_Cash.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Cash.CustomizationFormText = "layoutControlItemCash";
            this.lCI_Cash.Location = new System.Drawing.Point(0, 0);
            this.lCI_Cash.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Cash.Name = "lCI_Cash";
            this.lCI_Cash.Size = new System.Drawing.Size(87, 93);
            this.lCI_Cash.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Cash.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Cash.TextVisible = false;
            // 
            // lCI_Cashless
            // 
            this.lCI_Cashless.Control = this.btn_Cashless;
            this.lCI_Cashless.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_Cashless.CustomizationFormText = "layoutControlItemCashless";
            this.lCI_Cashless.Location = new System.Drawing.Point(87, 0);
            this.lCI_Cashless.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_Cashless.Name = "lCI_Cashless";
            this.lCI_Cashless.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lCI_Cashless.Size = new System.Drawing.Size(87, 93);
            this.lCI_Cashless.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Cashless.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Cashless.TextVisible = false;
            // 
            // lCI_CustomerBonus
            // 
            this.lCI_CustomerBonus.Control = this.btn_CustomerBonus;
            this.lCI_CustomerBonus.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lCI_CustomerBonus.CustomizationFormText = "layoutControlItemCustomerBonus";
            this.lCI_CustomerBonus.Location = new System.Drawing.Point(174, 0);
            this.lCI_CustomerBonus.MinSize = new System.Drawing.Size(40, 26);
            this.lCI_CustomerBonus.Name = "lCI_CustomerBonus";
            this.lCI_CustomerBonus.OptionsTableLayoutItem.ColumnIndex = 2;
            this.lCI_CustomerBonus.Size = new System.Drawing.Size(87, 93);
            this.lCI_CustomerBonus.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_CustomerBonus.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_CustomerBonus.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup2.Location = new System.Drawing.Point(412, 396);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(336, 303);
            this.layoutControlGroup2.Text = "layoutControlGroup1";
            // 
            // UcSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lC_InvoiceLine);
            this.Name = "UcSale";
            this.Size = new System.Drawing.Size(1142, 719);
            this.Load += new System.EventHandler(this.UcSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lC_InvoiceLine)).EndInit();
            this.lC_InvoiceLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Barcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboEdit_Barcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerPhoneNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_BonCardNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_CustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Star)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Comma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Enter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_BackSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ItemTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Num5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Invoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Function)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ProductSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Discount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CancelInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DeleteLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_SalesPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_PrintDesign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ReportZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_BonusCardNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Cash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Cashless)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomerBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            this.ResumeLayout(false);

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
