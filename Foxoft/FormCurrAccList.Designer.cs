
using DevExpress.Utils;

namespace Foxoft
{
    partial class FormCurrAccList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccList));
            gC_CurrAccList = new DevExpress.XtraGrid.GridControl();
            dcCurrAccsBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_CurrAccList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            colFatherName = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdentityNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colTaxNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colDataLanguageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreditLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsVip = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomerTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colVendorTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomerPosDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            colBonusCardNum = new DevExpress.XtraGrid.Columns.GridColumn();
            colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            colPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_CurrAccNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_CurAccEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_quit = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportCurrAcc = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_CurrAccDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_CurAccRefresh = new DevExpress.XtraBars.BarButtonItem();
            BBI_ProductMove = new DevExpress.XtraBars.BarButtonItem();
            BBI_ReportCashReg = new DevExpress.XtraBars.BarButtonItem();
            BSI_Report = new DevExpress.XtraBars.BarSubItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            BBI_test = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)gC_CurrAccList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcCurrAccsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_CurrAccList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_CurrAccList
            // 
            gC_CurrAccList.DataSource = dcCurrAccsBindingSource;
            gC_CurrAccList.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_CurrAccList.Location = new System.Drawing.Point(0, 158);
            gC_CurrAccList.MainView = gV_CurrAccList;
            gC_CurrAccList.Name = "gC_CurrAccList";
            gC_CurrAccList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEdit1 });
            gC_CurrAccList.Size = new System.Drawing.Size(858, 413);
            gC_CurrAccList.TabIndex = 0;
            gC_CurrAccList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_CurrAccList });
            gC_CurrAccList.Paint += gC_CurrAccList_Paint;
            gC_CurrAccList.Load += gC_CurrAccList_Load;
            gC_CurrAccList.ProcessGridKey += gC_CurrAccList_ProcessGridKey;
            // 
            // gV_CurrAccList
            // 
            gV_CurrAccList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCurrAccCode, colCurrAccDesc, colCurrAccTypeCode, colCompanyCode, colOfficeCode, colStoreCode, colFirstName, colLastName, colFatherName, colIdentityNum, colTaxNum, colDataLanguageCode, colCreditLimit, colIsVip, colCustomerTypeCode, colVendorTypeCode, colCustomerPosDiscountRate, colIsDisabled, colBonusCardNum, colAddress, colPhoneNum, colBirthDate, colBalance });
            gV_CurrAccList.CustomizationFormBounds = new System.Drawing.Rectangle(760, 248, 264, 272);
            gV_CurrAccList.GridControl = gC_CurrAccList;
            gV_CurrAccList.Name = "gV_CurrAccList";
            gV_CurrAccList.OptionsFind.FindDelay = 100;
            gV_CurrAccList.OptionsView.ShowGroupPanel = false;
            gV_CurrAccList.PopupMenuShowing += gV_Report_PopupMenuShowing;
            gV_CurrAccList.FocusedRowChanged += gV_CurrAccList_FocusedRowChanged;
            gV_CurrAccList.ColumnFilterChanged += gV_CurrAccList_ColumnFilterChanged;
            gV_CurrAccList.DoubleClick += gV_CurrAccList_DoubleClick;
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
            colDataLanguageCode.FieldName = "DataLanguageCode";
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
            repositoryItemTextEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegularMaskManager));
            repositoryItemTextEdit1.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            repositoryItemTextEdit1.MaskSettings.Set("mask", "(\\d?\\d?) \\d\\d\\d-\\d\\d-\\d\\d");
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
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, bBI_CurrAccNew, bBI_CurAccEdit, bBI_quit, BBI_ReportCurrAcc, bBI_ExportXlsx, bBI_CurrAccDelete, bBI_CurAccRefresh, BBI_ProductMove, BBI_ReportCashReg, BSI_Report, barButtonItem3, barButtonItem4, BBI_test });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 28;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.PageHeaderItemLinks.Add(bBI_quit);
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(858, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_CurrAccNew
            // 
            bBI_CurrAccNew.Caption = "Yeni";
            bBI_CurrAccNew.Id = 1;
            bBI_CurrAccNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurrAccNew.ImageOptions.SvgImage");
            bBI_CurrAccNew.Name = "bBI_CurrAccNew";
            bBI_CurrAccNew.ItemClick += bBI_CurrAccNew_ItemClick;
            // 
            // bBI_CurAccEdit
            // 
            bBI_CurAccEdit.Caption = "Dəyiş";
            bBI_CurAccEdit.Id = 2;
            bBI_CurAccEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurAccEdit.ImageOptions.SvgImage");
            bBI_CurAccEdit.Name = "bBI_CurAccEdit";
            bBI_CurAccEdit.ItemClick += bBI_CurrAccEdit_ItemClick;
            // 
            // bBI_quit
            // 
            bBI_quit.Caption = "Bağla";
            bBI_quit.Id = 4;
            bBI_quit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_quit.ImageOptions.SvgImage");
            bBI_quit.Name = "bBI_quit";
            bBI_quit.ItemClick += bBI_quit_ItemClick;
            // 
            // BBI_ReportCurrAcc
            // 
            BBI_ReportCurrAcc.Caption = "Müştəri ilə Haqq Hesab";
            BBI_ReportCurrAcc.Id = 5;
            BBI_ReportCurrAcc.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportCurrAcc.ImageOptions.SvgImage");
            BBI_ReportCurrAcc.Name = "BBI_ReportCurrAcc";
            BBI_ReportCurrAcc.ItemClick += bBI_Report1_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = "Excelə Göndər";
            bBI_ExportXlsx.Id = 6;
            bBI_ExportXlsx.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_CurrAccDelete
            // 
            bBI_CurrAccDelete.Caption = "Sil";
            bBI_CurrAccDelete.Id = 7;
            bBI_CurrAccDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurrAccDelete.ImageOptions.SvgImage");
            bBI_CurrAccDelete.Name = "bBI_CurrAccDelete";
            bBI_CurrAccDelete.ItemClick += bBI_CurrAccDelete_ItemClick;
            // 
            // bBI_CurAccRefresh
            // 
            bBI_CurAccRefresh.Caption = "Yenilə";
            bBI_CurAccRefresh.Id = 8;
            bBI_CurAccRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurAccRefresh.ImageOptions.SvgImage");
            bBI_CurAccRefresh.Name = "bBI_CurAccRefresh";
            bBI_CurAccRefresh.ItemClick += bBI_CurAccRefresh_ItemClick;
            // 
            // BBI_ProductMove
            // 
            BBI_ProductMove.Caption = "Malın Bütün Hərəkəti";
            BBI_ProductMove.Id = 9;
            BBI_ProductMove.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductMove.ImageOptions.SvgImage");
            BBI_ProductMove.Name = "BBI_ProductMove";
            BBI_ProductMove.ItemClick += BBI_ProductMove_ItemClick;
            // 
            // BBI_ReportCashReg
            // 
            BBI_ReportCashReg.Caption = "Pulun Bütün Hərəkəti";
            BBI_ReportCashReg.Id = 11;
            BBI_ReportCashReg.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ReportCashReg.ImageOptions.SvgImage");
            BBI_ReportCashReg.Name = "BBI_ReportCashReg";
            BBI_ReportCashReg.ItemClick += BBI_ReportCashReg_ItemClick;
            // 
            // BSI_Report
            // 
            BSI_Report.Caption = "Hesabat";
            BSI_Report.Id = 24;
            BSI_Report.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Report.ImageOptions.SvgImage");
            BSI_Report.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BBI_ReportCashReg), new DevExpress.XtraBars.LinkPersistInfo(BBI_ReportCurrAcc), new DevExpress.XtraBars.LinkPersistInfo(BBI_ProductMove) });
            BSI_Report.Name = "BSI_Report";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "Musteri ile Haqq Hesab";
            barButtonItem3.Id = 25;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "Malin Butun Hereketi";
            barButtonItem4.Id = 26;
            barButtonItem4.Name = "barButtonItem4";
            barButtonItem4.ItemClick += barButtonItem4_ItemClick;
            // 
            // BBI_test
            // 
            BBI_test.Caption = "test";
            BBI_test.Id = 27;
            BBI_test.Name = "BBI_test";
            BBI_test.ItemClick += BBI_test_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Cari Hesab";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_CurrAccNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurAccEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurrAccDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurAccRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "İdarə";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.ItemLinks.Add(BSI_Report);
            ribbonPageGroup3.ItemLinks.Add(BBI_test);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Hesabat";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new System.Drawing.Point(0, 571);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new System.Drawing.Size(858, 24);
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // FormCurrAccList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(858, 595);
            Controls.Add(gC_CurrAccList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormCurrAccList";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Cari Hesablar";
            VisibleChanged += FormCurrAccList_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)gC_CurrAccList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcCurrAccsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_CurrAccList).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_CurrAccList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CurrAccList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_CurrAccNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_quit;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportCurrAcc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private System.Windows.Forms.BindingSource dcCurrAccsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colFatherName;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityNum;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxNum;
        private DevExpress.XtraGrid.Columns.GridColumn colDataLanguageCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsVip;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVendorTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPosDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colBonusCardNum;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraBars.BarButtonItem bBI_CurrAccDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccRefresh;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductMove;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportCashReg;
        private DevExpress.XtraBars.BarSubItem BSI_Report;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem BBI_test;
    }
}