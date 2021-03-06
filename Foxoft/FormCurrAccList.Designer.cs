
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccList));
         this.gC_CurrAccList = new DevExpress.XtraGrid.GridControl();
         this.gV_CurrAccList = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.col_CurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_CurrAccTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_OfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_IdentityNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_PhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_BonusCardNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.col_CurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_CurrAccNew = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CurAccEdit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_refresh = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Report1 = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         ((System.ComponentModel.ISupportInitialize)(this.gC_CurrAccList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_CurrAccList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_CurrAccList
         // 
         this.gC_CurrAccList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_CurrAccList.Location = new System.Drawing.Point(0, 158);
         this.gC_CurrAccList.MainView = this.gV_CurrAccList;
         this.gC_CurrAccList.Name = "gC_CurrAccList";
         this.gC_CurrAccList.Size = new System.Drawing.Size(858, 413);
         this.gC_CurrAccList.TabIndex = 0;
         this.gC_CurrAccList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_CurrAccList});
         this.gC_CurrAccList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_CurrAccList_Paint);
         this.gC_CurrAccList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_CurrAccList_ProcessGridKey);
         // 
         // gV_CurrAccList
         // 
         this.gV_CurrAccList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_CurrAccCode,
            this.col_CurrAccTypeCode,
            this.col_OfficeCode,
            this.col_FirstName,
            this.col_LastName,
            this.col_IdentityNum,
            this.col_PhoneNum,
            this.col_Address,
            this.col_BonusCardNum,
            this.col_CurrAccDesc,
            this.colBalance});
         this.gV_CurrAccList.CustomizationFormBounds = new System.Drawing.Rectangle(867, 248, 264, 272);
         this.gV_CurrAccList.GridControl = this.gC_CurrAccList;
         this.gV_CurrAccList.Name = "gV_CurrAccList";
         this.gV_CurrAccList.OptionsView.ShowGroupPanel = false;
         this.gV_CurrAccList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_CurrAccList_FocusedRowChanged);
         this.gV_CurrAccList.ColumnFilterChanged += new System.EventHandler(this.gV_CurrAccList_ColumnFilterChanged);
         this.gV_CurrAccList.DoubleClick += new System.EventHandler(this.gV_CurrAccList_DoubleClick);
         // 
         // col_CurrAccCode
         // 
         this.col_CurrAccCode.Caption = "Cari Hesab";
         this.col_CurrAccCode.FieldName = "CurrAccCode";
         this.col_CurrAccCode.Name = "col_CurrAccCode";
         this.col_CurrAccCode.Visible = true;
         this.col_CurrAccCode.VisibleIndex = 0;
         // 
         // col_CurrAccTypeCode
         // 
         this.col_CurrAccTypeCode.Caption = "Tədarikçi Tipi";
         this.col_CurrAccTypeCode.FieldName = "CurrAccTypeCode";
         this.col_CurrAccTypeCode.Name = "col_CurrAccTypeCode";
         // 
         // col_OfficeCode
         // 
         this.col_OfficeCode.Caption = "Ofis Kodu";
         this.col_OfficeCode.FieldName = "OfficeCode";
         this.col_OfficeCode.Name = "col_OfficeCode";
         // 
         // col_FirstName
         // 
         this.col_FirstName.Caption = "Adı";
         this.col_FirstName.FieldName = "FirstName";
         this.col_FirstName.Name = "col_FirstName";
         // 
         // col_LastName
         // 
         this.col_LastName.Caption = "Soyadı";
         this.col_LastName.FieldName = "LastName";
         this.col_LastName.Name = "col_LastName";
         // 
         // col_IdentityNum
         // 
         this.col_IdentityNum.Caption = "Ş.V. Nömrəsi";
         this.col_IdentityNum.FieldName = "IdentityNum";
         this.col_IdentityNum.Name = "col_IdentityNum";
         // 
         // col_PhoneNum
         // 
         this.col_PhoneNum.Caption = "Telefon";
         this.col_PhoneNum.DisplayFormat.FormatString = "{0:(##) ### ## ##}";
         this.col_PhoneNum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.col_PhoneNum.FieldName = "PhoneNum";
         this.col_PhoneNum.Name = "col_PhoneNum";
         this.col_PhoneNum.Visible = true;
         this.col_PhoneNum.VisibleIndex = 2;
         // 
         // col_Address
         // 
         this.col_Address.Caption = "Adres";
         this.col_Address.FieldName = "Address";
         this.col_Address.Name = "col_Address";
         this.col_Address.Visible = true;
         this.col_Address.VisibleIndex = 3;
         // 
         // col_BonusCardNum
         // 
         this.col_BonusCardNum.Caption = "Bonus Kartı";
         this.col_BonusCardNum.FieldName = "BonusCardNum";
         this.col_BonusCardNum.Name = "col_BonusCardNum";
         // 
         // col_CurrAccDesc
         // 
         this.col_CurrAccDesc.Caption = "Cari Hesab Açıqlaması";
         this.col_CurrAccDesc.FieldName = "CurrAccDesc";
         this.col_CurrAccDesc.Name = "col_CurrAccDesc";
         this.col_CurrAccDesc.Visible = true;
         this.col_CurrAccDesc.VisibleIndex = 1;
         // 
         // colBalance
         // 
         this.colBalance.DisplayFormat.FormatString = "{0:n2}";
         this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colBalance.FieldName = "Balance";
         this.colBalance.Name = "colBalance";
         this.colBalance.Visible = true;
         this.colBalance.VisibleIndex = 4;
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_CurrAccNew,
            this.bBI_CurAccEdit,
            this.bBI_refresh,
            this.bBI_quit,
            this.bBI_Report1,
            this.bBI_ExportXlsx});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 7;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_quit);
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(858, 158);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
         // 
         // bBI_CurrAccNew
         // 
         this.bBI_CurrAccNew.Caption = "Yeni Istifadəçi";
         this.bBI_CurrAccNew.Id = 1;
         this.bBI_CurrAccNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CurrAccNew.ImageOptions.SvgImage")));
         this.bBI_CurrAccNew.Name = "bBI_CurrAccNew";
         this.bBI_CurrAccNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CurrAccNew_ItemClick);
         // 
         // bBI_CurAccEdit
         // 
         this.bBI_CurAccEdit.Caption = "Istifadəçini Dəyiş";
         this.bBI_CurAccEdit.Id = 2;
         this.bBI_CurAccEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CurAccEdit.ImageOptions.SvgImage")));
         this.bBI_CurAccEdit.Name = "bBI_CurAccEdit";
         this.bBI_CurAccEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CurrAccEdit_ItemClick);
         // 
         // bBI_refresh
         // 
         this.bBI_refresh.Caption = "Yenilə";
         this.bBI_refresh.Id = 3;
         this.bBI_refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_refresh.ImageOptions.SvgImage")));
         this.bBI_refresh.Name = "bBI_refresh";
         this.bBI_refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_refresh_ItemClick);
         // 
         // bBI_quit
         // 
         this.bBI_quit.Caption = "Bağla";
         this.bBI_quit.Id = 4;
         this.bBI_quit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_quit.ImageOptions.SvgImage")));
         this.bBI_quit.Name = "bBI_quit";
         this.bBI_quit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_quit_ItemClick);
         // 
         // bBI_Report1
         // 
         this.bBI_Report1.Caption = "Müştəri ilə Haqq Hesab";
         this.bBI_Report1.Id = 5;
         this.bBI_Report1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Report1.ImageOptions.SvgImage")));
         this.bBI_Report1.Name = "bBI_Report1";
         this.bBI_Report1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Report1_ItemClick);
         // 
         // bBI_ExportXlsx
         // 
         this.bBI_ExportXlsx.Caption = "Excelə Göndər";
         this.bBI_ExportXlsx.Id = 6;
         this.bBI_ExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
         this.bBI_ExportXlsx.Name = "bBI_ExportXlsx";
         this.bBI_ExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportXlsx_ItemClick);
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Cari Hesab";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurrAccNew);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurAccEdit);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_refresh);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "İdarə Et";
         // 
         // ribbonPageGroup3
         // 
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_Report1);
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_ExportXlsx);
         this.ribbonPageGroup3.Name = "ribbonPageGroup3";
         this.ribbonPageGroup3.Text = "Hesabat";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 571);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(858, 24);
         // 
         // ribbonPage2
         // 
         this.ribbonPage2.Name = "ribbonPage2";
         this.ribbonPage2.Text = "ribbonPage2";
         // 
         // FormCurrAccList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(858, 595);
         this.Controls.Add(this.gC_CurrAccList);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "FormCurrAccList";
         this.Ribbon = this.ribbonControl1;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "Cari Hesablar";
         ((System.ComponentModel.ISupportInitialize)(this.gC_CurrAccList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_CurrAccList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_CurrAccList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CurrAccList;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_OfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn col_LastName;
        private DevExpress.XtraGrid.Columns.GridColumn col_IdentityNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_PhoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraGrid.Columns.GridColumn col_BonusCardNum;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_CurrAccNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_quit;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccDesc;
      private DevExpress.XtraGrid.Columns.GridColumn colBalance;
      private DevExpress.XtraBars.BarButtonItem bBI_Report1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
      private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
   }
}