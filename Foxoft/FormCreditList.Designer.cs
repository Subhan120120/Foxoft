using DevExpress.Utils;
using DevExpress.Utils.Svg;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormCreditList
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            gC_CreditList = new DevExpress.XtraGrid.GridControl();
            creditBindingSource = new BindingSource(components);
            gV_CreditList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colTransactionType = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colServiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_AddCredit = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bSI_Balance = new DevExpress.XtraBars.BarStaticItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((ISupportInitialize)gC_CreditList).BeginInit();
            ((ISupportInitialize)creditBindingSource).BeginInit();
            ((ISupportInitialize)gV_CreditList).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_CreditList
            // 
            gC_CreditList.DataSource = creditBindingSource;
            gC_CreditList.Dock = DockStyle.Fill;
            gC_CreditList.Location = new Point(0, 158);
            gC_CreditList.MainView = gV_CreditList;
            gC_CreditList.MenuManager = ribbonControl1;
            gC_CreditList.Name = "gC_CreditList";
            gC_CreditList.Size = new Size(1100, 462);
            gC_CreditList.TabIndex = 0;
            gC_CreditList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_CreditList });
            gC_CreditList.ProcessGridKey += gC_CreditList_ProcessGridKey;
            // 
            // creditBindingSource
            // 
            creditBindingSource.DataSource = typeof(TrCredit);
            // 
            // gV_CreditList
            // 
            gV_CreditList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTransactionType, colAmount, colServiceType, colDescription, colCreatedDate, colCreatedUserName });
            gV_CreditList.GridControl = gC_CreditList;
            gV_CreditList.Name = "gV_CreditList";
            gV_CreditList.OptionsBehavior.Editable = false;
            gV_CreditList.OptionsFind.FindDelay = 100;
            gV_CreditList.OptionsView.ShowAutoFilterRow = true;
            gV_CreditList.OptionsView.ShowGroupPanel = false;
            gV_CreditList.OptionsView.ShowFooter = true;
            gV_CreditList.CustomColumnDisplayText += gV_CreditList_CustomColumnDisplayText;
            gV_CreditList.RowCellStyle += gV_CreditList_RowCellStyle;
            // 
            // colTransactionType
            // 
            colTransactionType.Caption = "Əməliyyat Növü";
            colTransactionType.FieldName = "TransactionType";
            colTransactionType.Name = "colTransactionType";
            colTransactionType.Visible = true;
            colTransactionType.VisibleIndex = 0;
            colTransactionType.Width = 120;
            // 
            // colAmount
            // 
            colAmount.Caption = "Məbləğ";
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            colAmount.Visible = true;
            colAmount.VisibleIndex = 1;
            colAmount.DisplayFormat.FormatType = FormatType.Numeric;
            colAmount.DisplayFormat.FormatString = "n2";
            colAmount.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}");
            colAmount.Width = 120;
            // 
            // colServiceType
            // 
            colServiceType.Caption = "Xidmət Növü";
            colServiceType.FieldName = "ServiceType";
            colServiceType.Name = "colServiceType";
            colServiceType.Visible = true;
            colServiceType.VisibleIndex = 2;
            colServiceType.Width = 120;
            // 
            // colDescription
            // 
            colDescription.Caption = "Açıqlama";
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 3;
            colDescription.Width = 250;
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = "Tarix";
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.Visible = true;
            colCreatedDate.VisibleIndex = 4;
            colCreatedDate.DisplayFormat.FormatType = FormatType.DateTime;
            colCreatedDate.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            colCreatedDate.Width = 140;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.Caption = "İstifadəçi";
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            colCreatedUserName.Visible = true;
            colCreatedUserName.VisibleIndex = 5;
            colCreatedUserName.Width = 100;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_AddCredit, bBI_Refresh, bBI_ExportXlsx, bSI_Balance });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_AddCredit
            // 
            bBI_AddCredit.Caption = "Kredit Əlavə Et";
            bBI_AddCredit.Id = 1;
            bBI_AddCredit.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DevExpress.XtraBars.SvgImages.Outlook Inspired.AddFile.svg", typeof(DevExpress.XtraBars.BarItem).Assembly);
            bBI_AddCredit.Name = "bBI_AddCredit";
            bBI_AddCredit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            bBI_AddCredit.ItemClick += bBI_AddCredit_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = "Yenilə";
            bBI_Refresh.Id = 2;
            bBI_Refresh.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DevExpress.XtraBars.SvgImages.Outlook Inspired.Refresh.svg", typeof(DevExpress.XtraBars.BarItem).Assembly);
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = "Excel";
            bBI_ExportXlsx.Id = 3;
            bBI_ExportXlsx.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromResources("DevExpress.XtraBars.SvgImages.Outlook Inspired.ExportToXLSX.svg", typeof(DevExpress.XtraBars.BarItem).Assembly);
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bSI_Balance
            // 
            bSI_Balance.Caption = "Balans: 0.00";
            bSI_Balance.Id = 4;
            bSI_Balance.Name = "bSI_Balance";
            bSI_Balance.ItemAppearance.Normal.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            bSI_Balance.ItemAppearance.Normal.ForeColor = Color.Green;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Kredit Əməliyyatları";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_AddCredit);
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.ItemLinks.Add(bSI_Balance);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyyat";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Export";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 620);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);
            // 
            // FormCreditList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644);
            Controls.Add(gC_CreditList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormCreditList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Kredit Əməliyyatları";
            FormClosed += FormCreditList_FormClosed;
            Load += FormCreditList_Load;
            ((ISupportInitialize)gC_CreditList).EndInit();
            ((ISupportInitialize)creditBindingSource).EndInit();
            ((ISupportInitialize)gV_CreditList).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_CreditList;
        private BindingSource creditBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CreditList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_AddCredit;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.BarStaticItem bSI_Balance;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionType;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
    }
}
