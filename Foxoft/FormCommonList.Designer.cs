using DevExpress.XtraEditors;

namespace Foxoft
{
    partial class FormCommonList<T>
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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_query = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportExcel = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            BBI_New = new DevExpress.XtraBars.BarButtonItem();
            BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            bBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSource1 = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_query, bBI_ExportExcel });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 3;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbonControl1.Size = new Size(800, 158);
            // 
            // BBI_query
            // 
            BBI_query.Caption = "Sorğu";
            BBI_query.Id = 23;
            BBI_query.Name = "BBI_query";
            // 
            // bBI_ExportExcel
            // 
            bBI_ExportExcel.Caption = "Excele At";
            bBI_ExportExcel.Id = 5;
            bBI_ExportExcel.Name = "bBI_ExportExcel";
            bBI_ExportExcel.ItemClick += bBI_ExportExcel_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Əməliyatlar";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_New);
            ribbonPageGroup1.ItemLinks.Add(BBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(bBI_Delete);
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Alətlər";
            // 
            // BBI_New
            // 
            BBI_New.Caption = "Yeni";
            BBI_New.Id = 1;
            BBI_New.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.N);
            BBI_New.Name = "BBI_New";
            BBI_New.ItemClick += BBI_New_ItemClick;
            // 
            // BBI_Edit
            // 
            BBI_Edit.Caption = "Dəyiş";
            BBI_Edit.Id = 2;
            BBI_Edit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F2);
            BBI_Edit.Name = "BBI_Edit";
            BBI_Edit.ItemClick += BBI_Edit_ItemClick;
            // 
            // bBI_Delete
            // 
            bBI_Delete.Caption = "Sil";
            bBI_Delete.Id = 8;
            bBI_Delete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Delete);
            bBI_Delete.Name = "bBI_Delete";
            bBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = "Yenilə";
            bBI_Refresh.Id = 9;
            bBI_Refresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F5);
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_query);
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportExcel);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Data";
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("sendxlsx", "image://svgimages/send/sendxlsx.svg");
            svgImageCollection1.Add("add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("delete", "image://svgimages/scheduling/delete.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("queryedit", "image://svgimages/dashboards/editdatasource.svg");
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSource1;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 158);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbonControl1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(800, 292);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            gridControl1.ProcessGridKey += gridControl1_ProcessGridKey;
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.ColumnFilterChanged += gridView1_ColumnFilterChanged;
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
            gridView1.RowLoaded += gridView1_RowLoaded;
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // FormCommonList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridControl1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormCommonList";
            Ribbon = ribbonControl1;
            Text = "FormCommonList";
            Activated += FormCommonList_Activated;
            Load += FormCommonList_Load;
            KeyDown += FormCommonList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BBI_query;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportExcel;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
        private DevExpress.XtraBars.BarButtonItem bBI_Delete;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}