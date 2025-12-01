using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormStoreList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStoreList));
            gC_StoreList = new GridControl();
            dcCurrAccsBindingSource = new BindingSource(components);
            gV_StoreList = new GridView();
            colCurrAccCode = new GridColumn();
            colCurrAccDesc = new GridColumn();
            colCurrAccTypeCode = new GridColumn();
            colCompanyCode = new GridColumn();
            colOfficeCode = new GridColumn();
            colStoreCode = new GridColumn();
            colFirstName = new GridColumn();
            colLastName = new GridColumn();
            colFatherName = new GridColumn();
            colIdentityNum = new GridColumn();
            colTaxNum = new GridColumn();
            colDataLanguageCode = new GridColumn();
            colCreditLimit = new GridColumn();
            colIsVip = new GridColumn();
            colCustomerTypeCode = new GridColumn();
            colVendorTypeCode = new GridColumn();
            colCustomerPosDiscountRate = new GridColumn();
            colIsDisabled = new GridColumn();
            colBonusCardNum = new GridColumn();
            colAddress = new GridColumn();
            colPhoneNum = new GridColumn();
            repositoryItemTextEdit1 = new RepositoryItemTextEdit();
            colBirthDate = new GridColumn();
            colBalance = new GridColumn();
            ribbonControl1 = new RibbonControl();
            bBI_CurrAccNew = new BarButtonItem();
            bBI_CurAccEdit = new BarButtonItem();
            bBI_ExportXlsx = new BarButtonItem();
            bBI_CurrAccDelete = new BarButtonItem();
            bBI_CurAccRefresh = new BarButtonItem();
            BBI_query = new BarButtonItem();
            BSI_Reports = new BarSubItem();
            ribbonPage1 = new RibbonPage();
            ribbonPageGroup1 = new RibbonPageGroup();
            ribbonPageGroup3 = new RibbonPageGroup();
            ribbonPage3 = new RibbonPage();
            ribbonPageGroup2 = new RibbonPageGroup();
            ribbonStatusBar1 = new RibbonStatusBar();
            popupMenuReports = new PopupMenu(components);
            ribbonPage2 = new RibbonPage();
            ((System.ComponentModel.ISupportInitialize)gC_StoreList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcCurrAccsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_StoreList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuReports).BeginInit();
            SuspendLayout();
            // 
            // gC_StoreList
            // 
            gC_StoreList.DataSource = dcCurrAccsBindingSource;
            gC_StoreList.Dock = DockStyle.Fill;
            gC_StoreList.Location = new Point(0, 158);
            gC_StoreList.MainView = gV_StoreList;
            gC_StoreList.Name = "gC_StoreList";
            gC_StoreList.RepositoryItems.AddRange(new RepositoryItem[] { repositoryItemTextEdit1 });
            gC_StoreList.Size = new Size(858, 413);
            gC_StoreList.TabIndex = 0;
            gC_StoreList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_StoreList });
            gC_StoreList.Load += gC_CurrAccList_Load;
            gC_StoreList.ProcessGridKey += gC_CurrAccList_ProcessGridKey;
            // 
            // dcCurrAccsBindingSource
            // 
            dcCurrAccsBindingSource.DataSource = typeof(DcCurrAcc);
            // 
            // gV_StoreList
            // 
            gV_StoreList.Columns.AddRange(new GridColumn[] { colCurrAccCode, colCurrAccDesc, colCurrAccTypeCode, colCompanyCode, colOfficeCode, colStoreCode, colFirstName, colLastName, colFatherName, colIdentityNum, colTaxNum, colDataLanguageCode, colCreditLimit, colIsVip, colCustomerTypeCode, colVendorTypeCode, colCustomerPosDiscountRate, colIsDisabled, colBonusCardNum, colAddress, colPhoneNum, colBirthDate, colBalance });
            gV_StoreList.CustomizationFormBounds = new Rectangle(760, 248, 264, 272);
            gV_StoreList.GridControl = gC_StoreList;
            gV_StoreList.Name = "gV_StoreList";
            gV_StoreList.OptionsBehavior.Editable = false;
            gV_StoreList.OptionsFind.FindDelay = 100;
            gV_StoreList.OptionsView.ShowGroupPanel = false;
            gV_StoreList.PopupMenuShowing += gV_CurrAccList_PopupMenuShowing;
            gV_StoreList.FocusedRowChanged += gV_StoreList_FocusedRowChanged;
            gV_StoreList.ColumnFilterChanged += gV_CurrAccList_ColumnFilterChanged;
            gV_StoreList.DoubleClick += gV_CurrAccList_DoubleClick;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 0;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 1;
            // 
            // colCurrAccTypeCode
            // 
            colCurrAccTypeCode.FieldName = "CurrAccTypeCode";
            colCurrAccTypeCode.Name = "colCurrAccTypeCode";
            // 
            // colCompanyCode
            // 
            colCompanyCode.FieldName = "CompanyCode";
            colCompanyCode.Name = "colCompanyCode";
            // 
            // colOfficeCode
            // 
            colOfficeCode.FieldName = "OfficeCode";
            colOfficeCode.Name = "colOfficeCode";
            // 
            // colStoreCode
            // 
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            // 
            // colFirstName
            // 
            colFirstName.FieldName = "FirstName";
            colFirstName.Name = "colFirstName";
            // 
            // colLastName
            // 
            colLastName.FieldName = "LastName";
            colLastName.Name = "colLastName";
            // 
            // colFatherName
            // 
            colFatherName.FieldName = "FatherName";
            colFatherName.Name = "colFatherName";
            // 
            // colIdentityNum
            // 
            colIdentityNum.FieldName = "IdentityNum";
            colIdentityNum.Name = "colIdentityNum";
            // 
            // colTaxNum
            // 
            colTaxNum.FieldName = "TaxNum";
            colTaxNum.Name = "colTaxNum";
            // 
            // colDataLanguageCode
            // 
            colDataLanguageCode.FieldName = "LanguageCode";
            colDataLanguageCode.Name = "colDataLanguageCode";
            // 
            // colCreditLimit
            // 
            colCreditLimit.FieldName = "CreditLimit";
            colCreditLimit.Name = "colCreditLimit";
            // 
            // colIsVip
            // 
            colIsVip.FieldName = "IsVip";
            colIsVip.Name = "colIsVip";
            colIsVip.Visible = true;
            colIsVip.VisibleIndex = 2;
            // 
            // colCustomerTypeCode
            // 
            colCustomerTypeCode.FieldName = "CustomerTypeCode";
            colCustomerTypeCode.Name = "colCustomerTypeCode";
            // 
            // colVendorTypeCode
            // 
            colVendorTypeCode.FieldName = "VendorTypeCode";
            colVendorTypeCode.Name = "colVendorTypeCode";
            // 
            // colCustomerPosDiscountRate
            // 
            colCustomerPosDiscountRate.FieldName = "CustomerPosDiscountRate";
            colCustomerPosDiscountRate.Name = "colCustomerPosDiscountRate";
            // 
            // colIsDisabled
            // 
            colIsDisabled.FieldName = "IsDisabled";
            colIsDisabled.Name = "colIsDisabled";
            // 
            // colBonusCardNum
            // 
            colBonusCardNum.FieldName = "BonusCardNum";
            colBonusCardNum.Name = "colBonusCardNum";
            // 
            // colAddress
            // 
            colAddress.FieldName = "Address";
            colAddress.Name = "colAddress";
            // 
            // colPhoneNum
            // 
            colPhoneNum.ColumnEdit = repositoryItemTextEdit1;
            colPhoneNum.FieldName = "PhoneNum";
            colPhoneNum.Name = "colPhoneNum";
            colPhoneNum.Visible = true;
            colPhoneNum.VisibleIndex = 3;
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            repositoryItemTextEdit1.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            repositoryItemTextEdit1.MaskSettings.Set("mask", "f");
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            repositoryItemTextEdit1.UseMaskAsDisplayFormat = true;
            // 
            // colBirthDate
            // 
            colBirthDate.FieldName = "BirthDate";
            colBirthDate.Name = "colBirthDate";
            // 
            // colBalance
            // 
            colBalance.DisplayFormat.FormatString = "{0:n2}";
            colBalance.DisplayFormat.FormatType = FormatType.Numeric;
            colBalance.FieldName = "Balance";
            colBalance.Name = "colBalance";
            colBalance.Visible = true;
            colBalance.VisibleIndex = 4;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_CurrAccNew, bBI_CurAccEdit, bBI_ExportXlsx, bBI_CurrAccDelete, bBI_CurAccRefresh, BBI_query, BSI_Reports });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 31;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new RibbonPage[] { ribbonPage1, ribbonPage3 });
            ribbonControl1.Size = new Size(858, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_CurrAccNew
            // 
            bBI_CurrAccNew.Caption = Resources.Common_New;
            bBI_CurrAccNew.Id = 1;
            bBI_CurrAccNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurrAccNew.ImageOptions.SvgImage");
            bBI_CurrAccNew.ItemShortcut = new BarShortcut(Keys.Control | Keys.N);
            bBI_CurrAccNew.Name = "bBI_CurrAccNew";
            bBI_CurrAccNew.ItemClick += bBI_CurrAccNew_ItemClick;
            // 
            // bBI_CurAccEdit
            // 
            bBI_CurAccEdit.Caption = Resources.Common_Edit;
            bBI_CurAccEdit.Id = 2;
            bBI_CurAccEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurAccEdit.ImageOptions.SvgImage");
            bBI_CurAccEdit.ItemShortcut = new BarShortcut(Keys.F2);
            bBI_CurAccEdit.Name = "bBI_CurAccEdit";
            bBI_CurAccEdit.ItemClick += bBI_CurrAccEdit_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 6;
            bBI_ExportXlsx.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_CurrAccDelete
            // 
            bBI_CurrAccDelete.Caption = Resources.Common_Delete;
            bBI_CurrAccDelete.Id = 7;
            bBI_CurrAccDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurrAccDelete.ImageOptions.SvgImage");
            bBI_CurrAccDelete.ItemShortcut = new BarShortcut(Keys.Delete);
            bBI_CurrAccDelete.Name = "bBI_CurrAccDelete";
            bBI_CurrAccDelete.ItemClick += bBI_CurrAccDelete_ItemClick;
            // 
            // bBI_CurAccRefresh
            // 
            bBI_CurAccRefresh.Caption = Resources.Common_Refresh;
            bBI_CurAccRefresh.Id = 8;
            bBI_CurAccRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurAccRefresh.ImageOptions.SvgImage");
            bBI_CurAccRefresh.ItemShortcut = new BarShortcut(Keys.F5);
            bBI_CurAccRefresh.Name = "bBI_CurAccRefresh";
            bBI_CurAccRefresh.ItemClick += bBI_CurAccRefresh_ItemClick;
            // 
            // BBI_query
            // 
            BBI_query.Caption = Resources.Common_Query;
            BBI_query.Id = 28;
            BBI_query.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_query.ImageOptions.SvgImage");
            BBI_query.Name = "BBI_query";
            BBI_query.ItemClick += BBI_query_ItemClick;
            // 
            // BSI_Reports
            // 
            BSI_Reports.Caption = Resources.ERP_ACE_Reports;
            BSI_Reports.Id = 30;
            BSI_Reports.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Reports.ImageOptions.SvgImage");
            BSI_Reports.Name = "BSI_Reports";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.ERP_ACE_StoreList;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_CurrAccNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurAccEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurrAccDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurAccRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Common_Operations;
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.ItemLinks.Add(BSI_Reports);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = Resources.Common_Report;
            // 
            // ribbonPage3
            // 
            ribbonPage3.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup2 });
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = Resources.Common_Settings;
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_query);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = Resources.Common_Data;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 571);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(858, 24);
            // 
            // popupMenuReports
            // 
            popupMenuReports.Name = "popupMenuReports";
            popupMenuReports.Ribbon = ribbonControl1;
            popupMenuReports.BeforePopup += popupMenuReports_BeforePopup;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // FormStoreList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 595);
            Controls.Add(gC_StoreList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormStoreList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = Resources.ERP_ACE_StoreList;
            Activated += FormStoreList_Activated;
            KeyDown += FormStoreList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_StoreList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcCurrAccsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_StoreList).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GridControl gC_StoreList;
        private GridView gV_StoreList;
        private RibbonControl ribbonControl1;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroup1;
        private RibbonStatusBar ribbonStatusBar1;
        private RibbonPage ribbonPage2;
        private BarButtonItem bBI_CurrAccNew;
        private BarButtonItem bBI_CurAccEdit;
        private RibbonPageGroup ribbonPageGroup3;
        private BarButtonItem bBI_ExportXlsx;
        private BindingSource dcCurrAccsBindingSource;
        private GridColumn colCurrAccCode;
        private GridColumn colCurrAccDesc;
        private GridColumn colCurrAccTypeCode;
        private GridColumn colCompanyCode;
        private GridColumn colOfficeCode;
        private GridColumn colStoreCode;
        private GridColumn colFirstName;
        private GridColumn colLastName;
        private GridColumn colFatherName;
        private GridColumn colIdentityNum;
        private GridColumn colTaxNum;
        private GridColumn colDataLanguageCode;
        private GridColumn colCreditLimit;
        private GridColumn colIsVip;
        private GridColumn colCustomerTypeCode;
        private GridColumn colVendorTypeCode;
        private GridColumn colCustomerPosDiscountRate;
        private GridColumn colIsDisabled;
        private GridColumn colBonusCardNum;
        private GridColumn colAddress;
        private GridColumn colPhoneNum;
        private GridColumn colBirthDate;
        private GridColumn colBalance;
        private BarButtonItem bBI_CurrAccDelete;
        private BarButtonItem bBI_CurAccRefresh;
        private RibbonPage ribbonPage3;
        private RibbonPageGroup ribbonPageGroup2;
        private BarButtonItem BBI_query;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private PopupMenu popupMenuReports;
        private BarSubItem BSI_Reports;
    }
}
