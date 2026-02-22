using DevExpress.Utils;
using DevExpress.Utils.Svg;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormDocumentLockList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocumentLockList));
            gC_DocumentLockList = new DevExpress.XtraGrid.GridControl();
            documentLocksBindingSource = new BindingSource(components);
            gV_DocumentLockList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colLockId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentType = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentId = new DevExpress.XtraGrid.Columns.GridColumn();
            colLockedByUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            colLockedByUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLockedAtUtc = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastHeartbeatAtUtc = new DevExpress.XtraGrid.Columns.GridColumn();
            colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAppInstanceId = new DevExpress.XtraGrid.Columns.GridColumn();
            colReason = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            LockedByUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_DocumentLockRefresh = new DevExpress.XtraBars.BarButtonItem();
            BBI_ForceUnlock = new DevExpress.XtraBars.BarButtonItem();
            BBI_UnlockRequest = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gC_DocumentLockList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentLocksBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_DocumentLockList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_DocumentLockList
            // 
            gC_DocumentLockList.DataSource = documentLocksBindingSource;
            gC_DocumentLockList.Dock = DockStyle.Fill;
            gC_DocumentLockList.Location = new Point(0, 158);
            gC_DocumentLockList.MainView = gV_DocumentLockList;
            gC_DocumentLockList.Name = "gC_DocumentLockList";
            gC_DocumentLockList.Size = new Size(980, 430);
            gC_DocumentLockList.TabIndex = 0;
            gC_DocumentLockList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_DocumentLockList });
            gC_DocumentLockList.Paint += gC_DocumentLockList_Paint;
            gC_DocumentLockList.ProcessGridKey += gC_DocumentLockList_ProcessGridKey;
            // 
            // documentLocksBindingSource
            // 
            documentLocksBindingSource.DataSource = typeof(DocumentLockVM);
            // 
            // gV_DocumentLockList
            // 
            gV_DocumentLockList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colLockId, colDocumentType, colDocumentId, colLockedByUserId, colLockedByUserName, colLockedAtUtc, colLastHeartbeatAtUtc, colMachineName, colAppInstanceId, colReason, colDocumentNumber, LockedByUserName });
            gV_DocumentLockList.GridControl = gC_DocumentLockList;
            gV_DocumentLockList.Name = "gV_DocumentLockList";
            gV_DocumentLockList.OptionsBehavior.Editable = false;
            gV_DocumentLockList.OptionsSelection.EnableAppearanceFocusedCell = false;
            gV_DocumentLockList.OptionsView.ColumnAutoWidth = false;
            gV_DocumentLockList.OptionsView.ShowAutoFilterRow = true;
            gV_DocumentLockList.OptionsView.ShowGroupPanel = false;
            // 
            // colLockId
            // 
            colLockId.FieldName = "LockId";
            colLockId.Name = "colLockId";
            colLockId.Visible = true;
            colLockId.VisibleIndex = 0;
            colLockId.Width = 220;
            // 
            // colDocumentType
            // 
            colDocumentType.FieldName = "DocumentType";
            colDocumentType.Name = "colDocumentType";
            colDocumentType.Visible = true;
            colDocumentType.VisibleIndex = 5;
            colDocumentType.Width = 120;
            // 
            // colDocumentId
            // 
            colDocumentId.FieldName = "DocumentId";
            colDocumentId.Name = "colDocumentId";
            colDocumentId.Visible = true;
            colDocumentId.VisibleIndex = 1;
            colDocumentId.Width = 220;
            // 
            // colLockedByUserId
            // 
            colLockedByUserId.FieldName = "LockedByUserId";
            colLockedByUserId.Name = "colLockedByUserId";
            colLockedByUserId.Visible = true;
            colLockedByUserId.VisibleIndex = 4;
            colLockedByUserId.Width = 220;
            // 
            // colLockedByUserName
            // 
            colLockedByUserName.FieldName = "LockedByUserName";
            colLockedByUserName.Name = "colLockedByUserName";
            colLockedByUserName.Visible = true;
            colLockedByUserName.VisibleIndex = 6;
            colLockedByUserName.Width = 160;
            // 
            // colLockedAtUtc
            // 
            colLockedAtUtc.FieldName = "LockedAtUtc";
            colLockedAtUtc.Name = "colLockedAtUtc";
            colLockedAtUtc.Visible = true;
            colLockedAtUtc.VisibleIndex = 7;
            colLockedAtUtc.Width = 150;
            // 
            // colLastHeartbeatAtUtc
            // 
            colLastHeartbeatAtUtc.FieldName = "LastHeartbeatAtUtc";
            colLastHeartbeatAtUtc.Name = "colLastHeartbeatAtUtc";
            colLastHeartbeatAtUtc.Visible = true;
            colLastHeartbeatAtUtc.VisibleIndex = 8;
            colLastHeartbeatAtUtc.Width = 150;
            // 
            // colMachineName
            // 
            colMachineName.FieldName = "MachineName";
            colMachineName.Name = "colMachineName";
            colMachineName.Visible = true;
            colMachineName.VisibleIndex = 9;
            colMachineName.Width = 140;
            // 
            // colAppInstanceId
            // 
            colAppInstanceId.FieldName = "AppInstanceId";
            colAppInstanceId.Name = "colAppInstanceId";
            colAppInstanceId.Visible = true;
            colAppInstanceId.VisibleIndex = 10;
            colAppInstanceId.Width = 220;
            // 
            // colReason
            // 
            colReason.FieldName = "Reason";
            colReason.Name = "colReason";
            colReason.Visible = true;
            colReason.VisibleIndex = 11;
            colReason.Width = 250;
            // 
            // colDocumentNumber
            // 
            colDocumentNumber.FieldName = "DocumentNumber";
            colDocumentNumber.Name = "colDocumentNumber";
            colDocumentNumber.Visible = true;
            colDocumentNumber.VisibleIndex = 2;
            // 
            // LockedByUserName
            // 
            LockedByUserName.FieldName = "LockedByUserName";
            LockedByUserName.Name = "LockedByUserName";
            LockedByUserName.Visible = true;
            LockedByUserName.VisibleIndex = 3;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_ExportXlsx, bBI_DocumentLockRefresh, BBI_ForceUnlock, BBI_UnlockRequest });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 11;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(980, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 6;
            bBI_ExportXlsx.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_DocumentLockRefresh
            // 
            bBI_DocumentLockRefresh.Caption = Resources.Common_Refresh;
            bBI_DocumentLockRefresh.Id = 8;
            bBI_DocumentLockRefresh.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_DocumentLockRefresh.ImageOptions.SvgImage");
            bBI_DocumentLockRefresh.Name = "bBI_DocumentLockRefresh";
            bBI_DocumentLockRefresh.ItemClick += bBI_DocumentLockRefresh_ItemClick;
            // 
            // BBI_ForceUnlock
            // 
            BBI_ForceUnlock.Caption = "Force Unlock";
            BBI_ForceUnlock.Id = 9;
            BBI_ForceUnlock.ImageOptions.SvgImage = (SvgImage)resources.GetObject("BBI_ForceUnlock.ImageOptions.SvgImage");
            BBI_ForceUnlock.Name = "BBI_ForceUnlock";
            BBI_ForceUnlock.ItemClick += BBI_ForceUnlock_ItemClick;
            // 
            // BBI_UnlockRequest
            // 
            BBI_UnlockRequest.Caption = "Unlock Request";
            BBI_UnlockRequest.Id = 10;
            BBI_UnlockRequest.ImageOptions.SvgImage = (SvgImage)resources.GetObject("BBI_UnlockRequest.ImageOptions.SvgImage");
            BBI_UnlockRequest.Name = "BBI_UnlockRequest";
            BBI_UnlockRequest.ItemClick += BBI_UnlockRequest_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Main";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_DocumentLockRefresh);
            ribbonPageGroup1.ItemLinks.Add(BBI_UnlockRequest);
            ribbonPageGroup1.ItemLinks.Add(BBI_ForceUnlock);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Manage";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Report";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 588);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(980, 24);
            // 
            // FormDocumentLockList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 612);
            Controls.Add(gC_DocumentLockList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormDocumentLockList";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "Document Locks";
            Load += FormDocumentLockList_Load;
            ((System.ComponentModel.ISupportInitialize)gC_DocumentLockList).EndInit();
            ((System.ComponentModel.ISupportInitialize)documentLocksBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_DocumentLockList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_DocumentLockList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_DocumentLockList;
        private System.Windows.Forms.BindingSource documentLocksBindingSource;

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_DocumentLockRefresh;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;

        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;

        private DevExpress.XtraGrid.Columns.GridColumn colLockId;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentType;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentId;
        private DevExpress.XtraGrid.Columns.GridColumn colLockedByUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colLockedByUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLockedAtUtc;
        private DevExpress.XtraGrid.Columns.GridColumn colLastHeartbeatAtUtc;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colAppInstanceId;
        private DevExpress.XtraGrid.Columns.GridColumn colReason;
        private DevExpress.XtraBars.BarButtonItem BBI_ForceUnlock;
        private DevExpress.XtraBars.BarButtonItem BBI_UnlockRequest;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn LockedByUserName;
    }
}