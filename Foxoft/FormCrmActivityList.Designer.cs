using DevExpress.Utils;
using DevExpress.Utils.Svg;
using Foxoft.Models;
using Foxoft.Properties;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormCrmActivityList
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormCrmActivityList));
            gC_CrmActivityList = new DevExpress.XtraGrid.GridControl();
            crmActivitiesBindingSource = new BindingSource(components);
            gV_CrmActivityList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            colAssignedCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_CrmActivityNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_CrmActivityEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            bBI_CrmActivityDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_CrmActivityRefresh = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            colNextPlanDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((ISupportInitialize)gC_CrmActivityList).BeginInit();
            ((ISupportInitialize)crmActivitiesBindingSource).BeginInit();
            ((ISupportInitialize)gV_CrmActivityList).BeginInit();
            ((ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // gC_CrmActivityList
            // 
            gC_CrmActivityList.DataSource = crmActivitiesBindingSource;
            gC_CrmActivityList.Dock = DockStyle.Fill;
            gC_CrmActivityList.Location = new Point(0, 158);
            gC_CrmActivityList.MainView = gV_CrmActivityList;
            gC_CrmActivityList.MenuManager = ribbonControl1;
            gC_CrmActivityList.Name = "gC_CrmActivityList";
            gC_CrmActivityList.Size = new Size(1100, 462);
            gC_CrmActivityList.TabIndex = 0;
            gC_CrmActivityList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_CrmActivityList });
            gC_CrmActivityList.Paint += gC_CrmActivityList_Paint;
            gC_CrmActivityList.ProcessGridKey += gC_CrmActivityList_ProcessGridKey;
            // 
            // crmActivitiesBindingSource
            // 
            crmActivitiesBindingSource.DataSource = typeof(TrCrmActivity);
            // 
            // gV_CrmActivityList
            // 
            gV_CrmActivityList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate, colActivityCode, colActivityDate, colSubject, colCurrAccCode, colActivityTypeDesc, colStatus, colPriority, colIsCompleted, colAssignedCurrAccCode, colNextPlanDate });
            gV_CrmActivityList.GridControl = gC_CrmActivityList;
            gV_CrmActivityList.Name = "gV_CrmActivityList";
            gV_CrmActivityList.OptionsBehavior.Editable = false;
            gV_CrmActivityList.OptionsFind.FindDelay = 100;
            gV_CrmActivityList.OptionsView.ShowAutoFilterRow = true;
            gV_CrmActivityList.OptionsView.ShowGroupPanel = false;
            gV_CrmActivityList.RowCellClick += gV_CrmActivityList_RowCellClick;
            gV_CrmActivityList.CustomColumnDisplayText += gV_CrmActivityList_CustomColumnDisplayText;
            gV_CrmActivityList.PopupMenuShowing += gV_CrmActivityList_PopupMenuShowing;
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
            // colActivityCode
            // 
            colActivityCode.Caption = "Aktivlik Kodu";
            colActivityCode.FieldName = "ActivityCode";
            colActivityCode.Name = "colActivityCode";
            colActivityCode.Visible = true;
            colActivityCode.VisibleIndex = 0;
            // 
            // colActivityDate
            // 
            colActivityDate.Caption = "Tarix";
            colActivityDate.FieldName = "ActivityDate";
            colActivityDate.Name = "colActivityDate";
            colActivityDate.Visible = true;
            colActivityDate.VisibleIndex = 1;
            // 
            // colSubject
            // 
            colSubject.Caption = "Mövzu";
            colSubject.FieldName = "Subject";
            colSubject.Name = "colSubject";
            colSubject.Visible = true;
            colSubject.VisibleIndex = 2;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = "Cari Kod";
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 3;
            // 
            // colActivityTypeDesc
            // 
            colActivityTypeDesc.Caption = "Aktivlik Növü";
            colActivityTypeDesc.FieldName = "DcCrmActivityType.ActivityTypeDesc";
            colActivityTypeDesc.Name = "colActivityTypeDesc";
            colActivityTypeDesc.Visible = true;
            colActivityTypeDesc.VisibleIndex = 4;
            // 
            // colStatus
            // 
            colStatus.Caption = "Status";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 5;
            // 
            // colPriority
            // 
            colPriority.Caption = "Prioritet";
            colPriority.FieldName = "Priority";
            colPriority.Name = "colPriority";
            colPriority.Visible = true;
            colPriority.VisibleIndex = 6;
            // 
            // colIsCompleted
            // 
            colIsCompleted.Caption = "Tamamlanıb";
            colIsCompleted.FieldName = "IsCompleted";
            colIsCompleted.Name = "colIsCompleted";
            colIsCompleted.Visible = true;
            colIsCompleted.VisibleIndex = 7;
            // 
            // colAssignedCurrAccCode
            // 
            colAssignedCurrAccCode.Caption = "Təyin edilən";
            colAssignedCurrAccCode.FieldName = "AssignedCurrAccCode";
            colAssignedCurrAccCode.Name = "colAssignedCurrAccCode";
            colAssignedCurrAccCode.Visible = true;
            colAssignedCurrAccCode.VisibleIndex = 8;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_CrmActivityNew, bBI_CrmActivityEdit, bBI_ExportXlsx, bBI_CrmActivityDelete, bBI_CrmActivityRefresh });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 6;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_CrmActivityNew
            // 
            bBI_CrmActivityNew.Caption = "Yeni";
            bBI_CrmActivityNew.Id = 1;
            bBI_CrmActivityNew.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityNew.ImageOptions.SvgImage");
            bBI_CrmActivityNew.Name = "bBI_CrmActivityNew";
            bBI_CrmActivityNew.ItemClick += bBI_CrmActivityNew_ItemClick;
            // 
            // bBI_CrmActivityEdit
            // 
            bBI_CrmActivityEdit.Caption = "Dəyiş";
            bBI_CrmActivityEdit.Id = 2;
            bBI_CrmActivityEdit.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityEdit.ImageOptions.SvgImage");
            bBI_CrmActivityEdit.Name = "bBI_CrmActivityEdit";
            bBI_CrmActivityEdit.ItemClick += bBI_CrmActivityEdit_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = "Excel";
            bBI_ExportXlsx.Id = 3;
            bBI_ExportXlsx.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_CrmActivityDelete
            // 
            bBI_CrmActivityDelete.Caption = "Sil";
            bBI_CrmActivityDelete.Id = 4;
            bBI_CrmActivityDelete.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityDelete.ImageOptions.SvgImage");
            bBI_CrmActivityDelete.Name = "bBI_CrmActivityDelete";
            bBI_CrmActivityDelete.ItemClick += bBI_CrmActivityDelete_ItemClick;
            // 
            // bBI_CrmActivityRefresh
            // 
            bBI_CrmActivityRefresh.Caption = "Yenilə";
            bBI_CrmActivityRefresh.Id = 5;
            bBI_CrmActivityRefresh.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityRefresh.ImageOptions.SvgImage");
            bBI_CrmActivityRefresh.Name = "bBI_CrmActivityRefresh";
            bBI_CrmActivityRefresh.ItemClick += bBI_CrmActivityRefresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "CRM Aktivlikləri";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyyat";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Export";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 620);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);
            // 
            // colNextPlanDate
            // 
            colNextPlanDate.FieldName = "NextPlanDate";
            colNextPlanDate.Name = "colNextPlanDate";
            colNextPlanDate.Visible = true;
            colNextPlanDate.VisibleIndex = 9;
            // 
            // FormCrmActivityList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644);
            Controls.Add(gC_CrmActivityList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormCrmActivityList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "CRM Aktivlikləri";
            FormClosed += FormCrmActivityList_FormClosed;
            Load += FormCrmActivityList_Load;
            ((ISupportInitialize)gC_CrmActivityList).EndInit();
            ((ISupportInitialize)crmActivitiesBindingSource).EndInit();
            ((ISupportInitialize)gV_CrmActivityList).EndInit();
            ((ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_CrmActivityList;
        private BindingSource crmActivitiesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CrmActivityList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_CrmActivityNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CrmActivityEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.BarButtonItem bBI_CrmActivityDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_CrmActivityRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityCode;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityTypeDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNextPlanDate;
    }
}
