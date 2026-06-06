using Foxoft.Models.Entity.Report;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormFormReport
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
            gC_FormReportList = new DevExpress.XtraGrid.GridControl();
            trFormReportsBindingSource = new BindingSource(components);
            gV_FormReportList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFormCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_FormCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_ReportId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colShortcut = new DevExpress.XtraGrid.Columns.GridColumn();
            colCopyToClipboard = new DevExpress.XtraGrid.Columns.GridColumn();
            repoCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_New = new DevExpress.XtraBars.BarButtonItem();
            bBI_Save = new DevExpress.XtraBars.BarButtonItem();
            bBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_Close = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gC_FormReportList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trFormReportsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_FormReportList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_FormCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_ReportId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_FormReportList
            // 
            gC_FormReportList.DataSource = trFormReportsBindingSource;
            gC_FormReportList.Dock = DockStyle.Fill;
            gC_FormReportList.Location = new Point(0, 158);
            gC_FormReportList.MainView = gV_FormReportList;
            gC_FormReportList.MenuManager = ribbonControl1;
            gC_FormReportList.Name = "gC_FormReportList";
            gC_FormReportList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoLUE_FormCode, repoLUE_ReportId, repoCheckEdit });
            gC_FormReportList.Size = new Size(900, 418);
            gC_FormReportList.TabIndex = 0;
            gC_FormReportList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_FormReportList });
            gC_FormReportList.Paint += gC_FormReportList_Paint;
            gC_FormReportList.ProcessGridKey += gC_FormReportList_ProcessGridKey;
            // 
            // trFormReportsBindingSource
            // 
            trFormReportsBindingSource.DataSource = typeof(TrFormReport);
            // 
            // gV_FormReportList
            // 
            gV_FormReportList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFormCode, colReportId, colShortcut, colCopyToClipboard });
            gV_FormReportList.GridControl = gC_FormReportList;
            gV_FormReportList.Name = "gV_FormReportList";
            gV_FormReportList.OptionsFind.FindDelay = 100;
            gV_FormReportList.OptionsNavigation.AutoFocusNewRow = true;
            gV_FormReportList.OptionsView.ColumnAutoWidth = false;
            gV_FormReportList.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gV_FormReportList.OptionsView.ShowAutoFilterRow = true;
            gV_FormReportList.OptionsView.ShowGroupPanel = false;
            gV_FormReportList.FocusedRowChanged += gV_FormReportList_FocusedRowChanged;
            gV_FormReportList.ColumnFilterChanged += gV_FormReportList_ColumnFilterChanged;
            gV_FormReportList.InitNewRow += gV_FormReportList_InitNewRow;
            gV_FormReportList.ShowingEditor += gV_FormReportList_ShowingEditor;
            // 
            // colFormCode
            // 
            colFormCode.Caption = Resources.Entity_FormReport_FormCode;
            colFormCode.ColumnEdit = repoLUE_FormCode;
            colFormCode.FieldName = "FormCode";
            colFormCode.Name = "colFormCode";
            colFormCode.Visible = true;
            colFormCode.VisibleIndex = 0;
            colFormCode.Width = 220;
            // 
            // repoLUE_FormCode
            // 
            repoLUE_FormCode.AutoHeight = false;
            repoLUE_FormCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_FormCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormCode", Resources.Entity_Form_Code), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormDesc", Resources.Entity_Form_Desc) });
            repoLUE_FormCode.DisplayMember = "FormDesc";
            repoLUE_FormCode.Name = "repoLUE_FormCode";
            repoLUE_FormCode.NullText = "";
            repoLUE_FormCode.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            repoLUE_FormCode.ValueMember = "FormCode";
            // 
            // colReportId
            // 
            colReportId.Caption = Resources.Entity_FormReport_ReportId;
            colReportId.ColumnEdit = repoLUE_ReportId;
            colReportId.FieldName = "ReportId";
            colReportId.Name = "colReportId";
            colReportId.Visible = true;
            colReportId.VisibleIndex = 1;
            colReportId.Width = 280;
            // 
            // repoLUE_ReportId
            // 
            repoLUE_ReportId.AutoHeight = false;
            repoLUE_ReportId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_ReportId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportId", Resources.Entity_Report_Id), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportName", Resources.Entity_Report_Name) });
            repoLUE_ReportId.DisplayMember = "ReportName";
            repoLUE_ReportId.Name = "repoLUE_ReportId";
            repoLUE_ReportId.NullText = "";
            repoLUE_ReportId.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            repoLUE_ReportId.ValueMember = "ReportId";
            // 
            // colShortcut
            // 
            colShortcut.Caption = Resources.Entity_FormReport_Shortcut;
            colShortcut.FieldName = "Shortcut";
            colShortcut.Name = "colShortcut";
            colShortcut.Visible = true;
            colShortcut.VisibleIndex = 2;
            colShortcut.Width = 140;
            // 
            // colCopyToClipboard
            // 
            colCopyToClipboard.Caption = Resources.Entity_FormReport_CopyToClipboard;
            colCopyToClipboard.ColumnEdit = repoCheckEdit;
            colCopyToClipboard.FieldName = "CopyToClipboard";
            colCopyToClipboard.Name = "colCopyToClipboard";
            colCopyToClipboard.Visible = true;
            colCopyToClipboard.VisibleIndex = 3;
            colCopyToClipboard.Width = 150;
            // 
            // repoCheckEdit
            // 
            repoCheckEdit.AutoHeight = false;
            repoCheckEdit.Name = "repoCheckEdit";
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_New, bBI_Save, bBI_Delete, bBI_Refresh, bBI_ExportXlsx, bBI_Close });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(900, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_New
            // 
            bBI_New.Caption = Resources.Common_New;
            bBI_New.Id = 1;
            bBI_New.Name = "bBI_New";
            bBI_New.ItemClick += bBI_New_ItemClick;
            // 
            // bBI_Save
            // 
            bBI_Save.Caption = Resources.Common_Save;
            bBI_Save.Id = 2;
            bBI_Save.Name = "bBI_Save";
            bBI_Save.ItemClick += bBI_Save_ItemClick;
            // 
            // bBI_Delete
            // 
            bBI_Delete.Caption = Resources.Common_Delete;
            bBI_Delete.Id = 3;
            bBI_Delete.Name = "bBI_Delete";
            bBI_Delete.ItemClick += bBI_Delete_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = Resources.Common_Refresh;
            bBI_Refresh.Id = 4;
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 5;
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_Close
            // 
            bBI_Close.Caption = Resources.Common_Close;
            bBI_Close.Id = 6;
            bBI_Close.Name = "bBI_Close";
            bBI_Close.ItemClick += bBI_Close_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Entity_FormReport;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_New);
            ribbonPageGroup1.ItemLinks.Add(bBI_Save);
            ribbonPageGroup1.ItemLinks.Add(bBI_Delete);
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.ItemLinks.Add(bBI_Close);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Common_Manage;
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = Resources.Common_Report;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 576);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(900, 24);
            // 
            // FormTrFormReport
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(gC_FormReportList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormTrFormReport";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Entity_FormReport;
            KeyDown += FormTrFormReport_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_FormReportList).EndInit();
            ((System.ComponentModel.ISupportInitialize)trFormReportsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_FormReportList).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_FormCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_ReportId).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoCheckEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_FormReportList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_FormReportList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bBI_New;
        private DevExpress.XtraBars.BarButtonItem bBI_Save;
        private DevExpress.XtraBars.BarButtonItem bBI_Delete;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.BarButtonItem bBI_Close;
        private BindingSource trFormReportsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFormCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReportId;
        private DevExpress.XtraGrid.Columns.GridColumn colShortcut;
        private DevExpress.XtraGrid.Columns.GridColumn colCopyToClipboard;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_FormCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_ReportId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckEdit;
    }
}
