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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstallmentSale));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSourceTrInstallmentSale = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            repoBtnEdit_Payment = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            col_Buttons = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colMonthlyPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new RibbonControl();
            BBI_Refresh = new BarButtonItem();
            BBI_GridOptions = new BarButtonItem();
            BSI_Reports = new BarSubItem();
            BBI_QueryEdit = new BarButtonItem();
            BCI_FilterDay = new BarCheckItem();
            BBI_FilterWeek = new BarCheckItem();
            BBI_FilterMonth = new BarCheckItem();
            ribbonPage1 = new RibbonPage();
            ribbonPageGroup1 = new RibbonPageGroup();
            ribbonPageGroup2 = new RibbonPageGroup();
            ribbonPageGroup3 = new RibbonPageGroup();
            ribbonPageGroup5 = new RibbonPageGroup();
            ribbonPage2 = new RibbonPage();
            ribbonPageGroup4 = new RibbonPageGroup();
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
            editorButtonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions1.SvgImage");
            repoBtnEdit_Payment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
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
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_Refresh, BBI_GridOptions, BSI_Reports, BBI_QueryEdit, BCI_FilterDay, BBI_FilterWeek, BBI_FilterMonth });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 16;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new RibbonPage[] { ribbonPage1, ribbonPage2 });
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
            // BCI_FilterDay
            // 
            BCI_FilterDay.Caption = "Son Gün";
            BCI_FilterDay.Id = 13;
            BCI_FilterDay.ImageOptions.Image = (Image)resources.GetObject("BCI_FilterDay.ImageOptions.Image");
            BCI_FilterDay.ImageOptions.LargeImage = (Image)resources.GetObject("BCI_FilterDay.ImageOptions.LargeImage");
            BCI_FilterDay.Name = "BCI_FilterDay";
            BCI_FilterDay.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // BBI_FilterWeek
            // 
            BBI_FilterWeek.Caption = "Son Həftə";
            BBI_FilterWeek.Id = 14;
            BBI_FilterWeek.ImageOptions.Image = (Image)resources.GetObject("BBI_FilterWeek.ImageOptions.Image");
            BBI_FilterWeek.ImageOptions.LargeImage = (Image)resources.GetObject("BBI_FilterWeek.ImageOptions.LargeImage");
            BBI_FilterWeek.Name = "BBI_FilterWeek";
            BBI_FilterWeek.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // BBI_FilterMonth
            // 
            BBI_FilterMonth.Caption = "Son Ay";
            BBI_FilterMonth.Id = 15;
            BBI_FilterMonth.ImageOptions.Image = (Image)resources.GetObject("BBI_FilterMonth.ImageOptions.Image");
            BBI_FilterMonth.ImageOptions.LargeImage = (Image)resources.GetObject("BBI_FilterMonth.ImageOptions.LargeImage");
            BBI_FilterMonth.Name = "BBI_FilterMonth";
            BBI_FilterMonth.CheckedChanged += BBI_Filter_CheckedChanged;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3, ribbonPageGroup5 });
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
            ribbonPageGroup5.ItemLinks.Add(BCI_FilterDay);
            ribbonPageGroup5.ItemLinks.Add(BBI_FilterWeek);
            ribbonPageGroup5.ItemLinks.Add(BBI_FilterMonth);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Filter";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new RibbonPageGroup[] { ribbonPageGroup4 });
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private BarCheckItem BCI_FilterDay;
        private BarCheckItem BBI_FilterWeek;
        private BarCheckItem BBI_FilterMonth;
    }
}