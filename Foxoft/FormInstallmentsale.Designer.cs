using DevExpress.Dialogs.Core.View;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;

namespace Foxoft
{
    partial class FormInstallmentSale
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstallmentSale));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSourceTrInstallmentSale = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            repoBtnEdit_Payment = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            col_Buttons = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colMonthlyPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_Refresh = new BarButtonItem();
            BBI_GridOptions = new BarButtonItem();
            BSI_Reports = new BarSubItem();
            BBI_QueryEdit = new BarButtonItem();
            barButtonGroup1 = new BarButtonGroup();
            barCheckItem1 = new BarCheckItem();
            barCheckItem2 = new BarCheckItem();
            barCheckItem3 = new BarCheckItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentSale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSourceTrInstallmentSale;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 158);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoBtnEdit_Payment });
            gridControl1.Size = new Size(954, 368);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.RowHeight = 18;
            gridView1.PopupMenuShowing += gridView1_PopupMenuShowing;
            gridView1.ShowingEditor += gV_Report_ShowingEditor;
            // 
            // repoBtnEdit_Payment
            // 
            repoBtnEdit_Payment.AutoHeight = false;
            editorButtonImageOptions3.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions3.SvgImage");
            repoBtnEdit_Payment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            repoBtnEdit_Payment.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            repoBtnEdit_Payment.Name = "repoBtnEdit_Payment";
            repoBtnEdit_Payment.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repoBtnEdit_Payment.ButtonPressed += RepoBtnEdit_Payment_ButtonPressed;
            // 
            // col_Buttons
            // 
            col_Buttons.ColumnEdit = repoBtnEdit_Payment;
            col_Buttons.Name = "col_Buttons";
            col_Buttons.Visible = true;
            col_Buttons.VisibleIndex = 0;
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colMonthlyPayment
            // 
            colMonthlyPayment.Name = "colMonthlyPayment";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_Refresh, BBI_GridOptions, BSI_Reports, BBI_QueryEdit, barButtonGroup1, barCheckItem1, barCheckItem2, barCheckItem3 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 9;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbonControl1.Size = new Size(954, 158);
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = "Yenilə";
            BBI_Refresh.Id = 1;
            BBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Refresh.ImageOptions.SvgImage");
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BBI_GridOptions
            // 
            BBI_GridOptions.Caption = "Dizayn Düzəltmə";
            BBI_GridOptions.Id = 2;
            BBI_GridOptions.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GridOptions.ImageOptions.SvgImage");
            BBI_GridOptions.Name = "BBI_GridOptions";
            BBI_GridOptions.ItemClick += BBI_GridOptions_ItemClick;
            // 
            // BSI_Reports
            // 
            BSI_Reports.Caption = "Hesabatlar";
            BSI_Reports.Id = 3;
            BSI_Reports.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Reports.ImageOptions.SvgImage");
            BSI_Reports.Name = "BSI_Reports";
            // 
            // BBI_QueryEdit
            // 
            BBI_QueryEdit.Caption = "Sorğunu Dəyiş";
            BBI_QueryEdit.Id = 4;
            BBI_QueryEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_QueryEdit.ImageOptions.SvgImage");
            BBI_QueryEdit.Name = "BBI_QueryEdit";
            BBI_QueryEdit.ItemClick += BBI_QueryEdit_ItemClick;
            // 
            // barButtonGroup1
            // 
            barButtonGroup1.Caption = "barButtonGroup1";
            barButtonGroup1.Id = 5;
            barButtonGroup1.ItemLinks.Add(barCheckItem1);
            barButtonGroup1.ItemLinks.Add(barCheckItem2);
            barButtonGroup1.ItemLinks.Add(barCheckItem3);
            barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barCheckItem1
            // 
            barCheckItem1.Caption = "barCheckItem1";
            barCheckItem1.GroupIndex = 10;
            barCheckItem1.Id = 6;
            barCheckItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barCheckItem1.ImageOptions.SvgImage");
            barCheckItem1.Name = "barCheckItem1";
            barCheckItem1.RibbonStyle = RibbonItemStyles.Large;     // <-- Large tile
            barCheckItem1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barCheckItem1.ImageOptions.SvgImageSize = new Size(32, 32);
            barCheckItem1.LargeWidth = 60;
            // 
            // barCheckItem2
            // 
            barCheckItem2.Caption = "barCheckItem2";
            barCheckItem2.GroupIndex = 10;
            barCheckItem2.Id = 7;
            barCheckItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barCheckItem2.ImageOptions.SvgImage");
            barCheckItem2.Name = "barCheckItem2";
            barCheckItem2.RibbonStyle = RibbonItemStyles.Large;     // <-- Large tile
            barCheckItem2.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barCheckItem2.ImageOptions.SvgImageSize = new Size(32, 32);
            barCheckItem2.LargeWidth = 60;
            // 
            // barCheckItem3
            // 
            barCheckItem3.Caption = "barCheckItem3";
            barCheckItem3.GroupIndex = 10;
            barCheckItem3.Id = 8;
            barCheckItem3.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barCheckItem3.ImageOptions.SvgImage");
            barCheckItem3.Name = "barCheckItem3";
            barCheckItem3.RibbonStyle = RibbonItemStyles.Large;     // <-- Large tile
            barCheckItem3.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            barCheckItem3.ImageOptions.SvgImageSize = new Size(32, 32);
            barCheckItem3.LargeWidth = 60;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3, ribbonPageGroup5 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Kredit";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyyat";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_GridOptions);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Dizayn";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(BSI_Reports);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Print";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(barButtonGroup1);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Filter";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup4 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(BBI_QueryEdit);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Query";
            // 
            // FormInstallmentSale
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 526);
            Controls.Add(gridControl1);
            Controls.Add(ribbonControl1);
            Name = "FormInstallmentSale";
            Ribbon = ribbonControl1;
            Text = "FormInstallmentSale";
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceTrInstallmentSale).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_Payment).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BindingSource bindingSourceTrInstallmentSale;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_Payment;
        private DevExpress.XtraGrid.Columns.GridColumn col_Buttons;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthlyPayment;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem BBI_GridOptions;
        private BarSubItem BSI_Reports;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private BarButtonItem BBI_QueryEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private BarCheckItem barCheckItem1;
        private BarCheckItem barCheckItem2;
        private BarCheckItem barCheckItem3;
    }
}