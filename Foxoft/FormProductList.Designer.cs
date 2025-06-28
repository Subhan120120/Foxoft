
using DevExpress.Utils;

namespace Foxoft
{
    partial class FormProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductList));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions13 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            SerializableAppearanceObject serializableAppearanceObject49 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject50 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject51 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject52 = new SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions14 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            SerializableAppearanceObject serializableAppearanceObject53 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject54 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject55 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject56 = new SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions15 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            SerializableAppearanceObject serializableAppearanceObject57 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject58 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject59 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject60 = new SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions16 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            SerializableAppearanceObject serializableAppearanceObject61 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject62 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject63 = new SerializableAppearanceObject();
            SerializableAppearanceObject serializableAppearanceObject64 = new SerializableAppearanceObject();
            gC_ProductList = new MyGridControl();
            gV_ProductList = new MyGridView(this);
            dcProductsBindingSource = new BindingSource(components);
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_ProductNew = new DevExpress.XtraBars.BarButtonItem();
            btn_ProductEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            bBI_ProductDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_ProductRefresh = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            BBI_query = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            txtEdit_filtercolumns = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            BBI_Save = new DevExpress.XtraBars.BarButtonItem();
            BBI_Show = new DevExpress.XtraBars.BarButtonItem();
            BSI_Reports = new DevExpress.XtraBars.BarSubItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            popupMenuReports = new DevExpress.XtraBars.PopupMenu(components);
            popupMenu1 = new DevExpress.XtraBars.PopupMenu(components);
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            svgImageCollection1 = new SvgImageCollection(components);
            repositoryItemRibbonSearchEdit1 = new DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit();
            repositoryItemRibbonSearchEdit2 = new DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit();
            ((System.ComponentModel.ISupportInitialize)gC_ProductList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcProductsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuReports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit2).BeginInit();
            SuspendLayout();
            // 
            // gC_ProductList
            // 
            gC_ProductList.DataSource = dcProductsBindingSource;
            gC_ProductList.Dock = DockStyle.Fill;
            gC_ProductList.Location = new Point(0, 158);
            gC_ProductList.MainView = gV_ProductList;
            gC_ProductList.Name = "gC_ProductList";
            gC_ProductList.Size = new Size(1105, 481);
            gC_ProductList.TabIndex = 0;
            gC_ProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_ProductList });
            // 
            // gV_ProductList
            // 
            gV_ProductList.GridControl = gC_ProductList;
            gV_ProductList.Name = "gV_ProductList";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_ProductNew, btn_ProductEdit, bBI_ExportExcel, bBI_ProductDelete, bBI_ProductRefresh, barButtonItem2, BBI_query, barButtonItem4, txtEdit_filtercolumns, BBI_Save, BBI_Show, BSI_Reports });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 40;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage3 });
            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEdit1 });
            ribbonControl1.Size = new Size(1105, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // BBI_ProductNew
            // 
            BBI_ProductNew.Caption = "Yeni";
            BBI_ProductNew.Id = 1;
            BBI_ProductNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ProductNew.ImageOptions.SvgImage");
            BBI_ProductNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.N);
            BBI_ProductNew.Name = "BBI_ProductNew";
            // 
            // btn_ProductEdit
            // 
            btn_ProductEdit.Caption = "Dəyiş";
            btn_ProductEdit.Id = 2;
            btn_ProductEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_ProductEdit.ImageOptions.SvgImage");
            btn_ProductEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F2);
            btn_ProductEdit.Name = "btn_ProductEdit";
            // 
            // bBI_ExportExcel
            // 
            bBI_ExportExcel.Caption = "Excele At";
            bBI_ExportExcel.Id = 5;
            bBI_ExportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportExcel.ImageOptions.SvgImage");
            bBI_ExportExcel.Name = "bBI_ExportExcel";
            // 
            // bBI_ProductDelete
            // 
            bBI_ProductDelete.Caption = "Sil";
            bBI_ProductDelete.Id = 8;
            bBI_ProductDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ProductDelete.ImageOptions.SvgImage");
            bBI_ProductDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.Delete);
            bBI_ProductDelete.Name = "bBI_ProductDelete";
            // 
            // bBI_ProductRefresh
            // 
            bBI_ProductRefresh.Caption = "Yenilə";
            bBI_ProductRefresh.Id = 9;
            bBI_ProductRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ProductRefresh.ImageOptions.SvgImage");
            bBI_ProductRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F5);
            bBI_ProductRefresh.Name = "bBI_ProductRefresh";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Barkod Dizayn";
            barButtonItem2.Id = 22;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.Name = "barButtonItem2";
            // 
            // BBI_query
            // 
            BBI_query.Caption = "Sorğu";
            BBI_query.Id = 23;
            BBI_query.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_query.ImageOptions.SvgImage");
            BBI_query.Name = "BBI_query";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "test";
            barButtonItem4.Id = 28;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // txtEdit_filtercolumns
            // 
            txtEdit_filtercolumns.Caption = "filter columns";
            txtEdit_filtercolumns.Edit = repositoryItemTextEdit1;
            txtEdit_filtercolumns.Id = 34;
            txtEdit_filtercolumns.Name = "txtEdit_filtercolumns";
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // BBI_Save
            // 
            BBI_Save.Caption = "Save";
            BBI_Save.Id = 35;
            BBI_Save.Name = "BBI_Save";
            // 
            // BBI_Show
            // 
            BBI_Show.Caption = "Show";
            BBI_Show.Id = 36;
            BBI_Show.Name = "BBI_Show";
            // 
            // BSI_Reports
            // 
            BSI_Reports.Caption = "Hesabat";
            BSI_Reports.Id = 39;
            BSI_Reports.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Reports.ImageOptions.SvgImage");
            BSI_Reports.Name = "BSI_Reports";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Məhsul";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_ProductNew);
            ribbonPageGroup1.ItemLinks.Add(btn_ProductEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_ProductDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_ProductRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "İdarə";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportExcel);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Nəzarət";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(BSI_Reports);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Hesabat";
            // 
            // ribbonPage3
            // 
            ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5, ribbonPageGroup6 });
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = "Ayarlar";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(BBI_query);
            ribbonPageGroup5.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Data";
            // 
            // ribbonPageGroup6
            // 
            ribbonPageGroup6.ItemLinks.Add(txtEdit_filtercolumns);
            ribbonPageGroup6.ItemLinks.Add(BBI_Show);
            ribbonPageGroup6.ItemLinks.Add(BBI_Save);
            ribbonPageGroup6.Name = "ribbonPageGroup6";
            ribbonPageGroup6.Text = "Filter Columns";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 639);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1105, 24);
            // 
            // popupMenuReports
            // 
            popupMenuReports.Name = "popupMenuReports";
            popupMenuReports.Ribbon = ribbonControl1;
            popupMenuReports.BeforePopup += popupMenuReports_BeforePopup;
            // 
            // popupMenu1
            // 
            popupMenu1.Name = "popupMenu1";
            popupMenu1.Ribbon = ribbonControl1;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("report", "image://svgimages/business objects/bo_report.svg");
            svgImageCollection1.Add("add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("barcode", "image://svgimages/content/barcode.svg");
            svgImageCollection1.Add("actions_delete", "image://svgimages/icon builder/actions_delete.svg");
            // 
            // repositoryItemRibbonSearchEdit1
            // 
            repositoryItemRibbonSearchEdit1.AllowFocused = false;
            repositoryItemRibbonSearchEdit1.AutoHeight = false;
            repositoryItemRibbonSearchEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            editorButtonImageOptions13.AllowGlyphSkinning = DefaultBoolean.True;
            repositoryItemRibbonSearchEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, editorButtonImageOptions13, new KeyShortcut(Keys.None), serializableAppearanceObject49, serializableAppearanceObject50, serializableAppearanceObject51, serializableAppearanceObject52, "", null, null, ToolTipAnchor.Default), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, true, false, false, editorButtonImageOptions14, new KeyShortcut(Keys.None), serializableAppearanceObject53, serializableAppearanceObject54, serializableAppearanceObject55, serializableAppearanceObject56, "", null, null, ToolTipAnchor.Default) });
            repositoryItemRibbonSearchEdit1.Name = "repositoryItemRibbonSearchEdit1";
            repositoryItemRibbonSearchEdit1.NullText = "Search";
            // 
            // repositoryItemRibbonSearchEdit2
            // 
            repositoryItemRibbonSearchEdit2.AllowFocused = false;
            repositoryItemRibbonSearchEdit2.AutoHeight = false;
            repositoryItemRibbonSearchEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            editorButtonImageOptions15.AllowGlyphSkinning = DefaultBoolean.True;
            repositoryItemRibbonSearchEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, editorButtonImageOptions15, new KeyShortcut(Keys.None), serializableAppearanceObject57, serializableAppearanceObject58, serializableAppearanceObject59, serializableAppearanceObject60, "", null, null, ToolTipAnchor.Default), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, true, false, false, editorButtonImageOptions16, new KeyShortcut(Keys.None), serializableAppearanceObject61, serializableAppearanceObject62, serializableAppearanceObject63, serializableAppearanceObject64, "", null, null, ToolTipAnchor.Default) });
            repositoryItemRibbonSearchEdit2.Name = "repositoryItemRibbonSearchEdit2";
            repositoryItemRibbonSearchEdit2.NullText = "Search";
            // 
            // FormProductList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 663);
            Controls.Add(gC_ProductList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormProductList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterParent;
            StatusBar = ribbonStatusBar1;
            Text = "Məhsul Siyahısı";
            KeyDown += FormProductList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_ProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcProductsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_ProductList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuReports).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MyGridControl gC_ProductList;
        private MyGridView gV_ProductList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem BBI_ProductNew;
        private DevExpress.XtraBars.BarButtonItem btn_ProductEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportExcel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.BindingSource dcProductsBindingSource;
        private DevExpress.XtraBars.BarButtonItem bBI_ProductDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_ProductRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.BarButtonItem BBI_query;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem BBI_ReportProduct;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem BBI_Save;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarEditItem txtEdit_filtercolumns;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem BBI_Show;
        private SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit repositoryItemRibbonSearchEdit1;
        private DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit repositoryItemRibbonSearchEdit2;
        private DevExpress.XtraBars.PopupMenu popupMenuReports;
        private DevExpress.XtraBars.BarSubItem BSI_Reports;
    }
}