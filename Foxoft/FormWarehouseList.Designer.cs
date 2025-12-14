using DevExpress.Utils;
using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormWarehouseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWarehouseList));
            gC_WarehouseList = new DevExpress.XtraGrid.GridControl();
            dcWarehousesBindingSource = new BindingSource(components);
            gV_WarehouseList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            col_WarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            col_WarehouseDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_WarehouseNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_CurAccEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_WarehouseDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_CurAccRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)gC_WarehouseList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcWarehousesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_WarehouseList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_WarehouseList
            // 
            gC_WarehouseList.DataSource = dcWarehousesBindingSource;
            gC_WarehouseList.Dock = DockStyle.Fill;
            gC_WarehouseList.Location = new Point(0, 158);
            gC_WarehouseList.MainView = gV_WarehouseList;
            gC_WarehouseList.Name = "gC_WarehouseList";
            gC_WarehouseList.Size = new Size(858, 413);
            gC_WarehouseList.TabIndex = 0;
            gC_WarehouseList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_WarehouseList });
            gC_WarehouseList.Paint += gC_WarehouseList_Paint;
            gC_WarehouseList.ProcessGridKey += gC_WarehouseList_ProcessGridKey;
            // 
            // gV_WarehouseList
            // 
            gV_WarehouseList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate, col_WarehouseCode, col_WarehouseDesc });
            gV_WarehouseList.CustomizationFormBounds = new Rectangle(760, 248, 264, 272);
            gV_WarehouseList.GridControl = gC_WarehouseList;
            gV_WarehouseList.Name = "gV_WarehouseList";
            gV_WarehouseList.OptionsFind.FindDelay = 100;
            gV_WarehouseList.OptionsView.ShowGroupPanel = false;
            gV_WarehouseList.FocusedRowChanged += gV_WarehouseList_FocusedRowChanged;
            gV_WarehouseList.ColumnFilterChanged += gV_WarehouseList_ColumnFilterChanged;
            gV_WarehouseList.DoubleClick += gV_WarehouseList_DoubleClick;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // col_WarehouseCode
            // 
            col_WarehouseCode.FieldName = "WarehouseCode";
            col_WarehouseCode.Name = "col_WarehouseCode";
            col_WarehouseCode.Visible = true;
            col_WarehouseCode.VisibleIndex = 0;
            // 
            // col_WarehouseDesc
            // 
            col_WarehouseDesc.FieldName = "WarehouseDesc";
            col_WarehouseDesc.Name = "col_WarehouseDesc";
            col_WarehouseDesc.Visible = true;
            col_WarehouseDesc.VisibleIndex = 1;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_WarehouseNew, bBI_CurAccEdit, bBI_ExportXlsx, bBI_WarehouseDelete, bBI_CurAccRefresh });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 9;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(858, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_WarehouseNew
            // 
            bBI_WarehouseNew.Caption = Resources.Common_New;
            bBI_WarehouseNew.Id = 1;
            bBI_WarehouseNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_WarehouseNew.ImageOptions.SvgImage");
            bBI_WarehouseNew.Name = "bBI_WarehouseNew";
            bBI_WarehouseNew.ItemClick += bBI_WarehouseNew_ItemClick;
            // 
            // bBI_CurAccEdit
            // 
            bBI_CurAccEdit.Caption = Resources.Common_Edit;
            bBI_CurAccEdit.Id = 2;
            bBI_CurAccEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurAccEdit.ImageOptions.SvgImage");
            bBI_CurAccEdit.Name = "bBI_CurAccEdit";
            bBI_CurAccEdit.ItemClick += bBI_WarehouseEdit_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 6;
            bBI_ExportXlsx.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_WarehouseDelete
            // 
            bBI_WarehouseDelete.Caption = Resources.Common_Delete;
            bBI_WarehouseDelete.Id = 7;
            bBI_WarehouseDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_WarehouseDelete.ImageOptions.SvgImage");
            bBI_WarehouseDelete.Name = "bBI_WarehouseDelete";
            bBI_WarehouseDelete.ItemClick += bBI_WarehouseDelete_ItemClick;
            // 
            // bBI_CurAccRefresh
            // 
            bBI_CurAccRefresh.Caption = Resources.Common_Refresh;
            bBI_CurAccRefresh.Id = 8;
            bBI_CurAccRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CurAccRefresh.ImageOptions.SvgImage");
            bBI_CurAccRefresh.Name = "bBI_CurAccRefresh";
            bBI_CurAccRefresh.ItemClick += bBI_WarehouseRefresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_WarehouseList_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_WarehouseNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurAccEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_WarehouseDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_CurAccRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Form_WarehouseList_RibbonGroup_Manage;
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = Resources.Form_WarehouseList_RibbonGroup_Report;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 571);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(858, 24);
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // FormWarehouseList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 595);
            Controls.Add(gC_WarehouseList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormWarehouseList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Warehouses";
            KeyDown += FormWarehouseList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_WarehouseList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcWarehousesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_WarehouseList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_WarehouseList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_WarehouseList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_WarehouseNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private System.Windows.Forms.BindingSource dcWarehousesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraBars.BarButtonItem bBI_WarehouseDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn col_WarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_WarehouseDesc;
    }
}
