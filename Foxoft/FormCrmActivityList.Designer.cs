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
            colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colNextPlanDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            colAssignedCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colAssignedCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colResult = new DevExpress.XtraGrid.Columns.GridColumn();
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
            gV_CrmActivityList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate, colActivityCode, colActivityDate, colStartTime, colEndTime, colNextPlanDate, colSubject, colCurrAccCode, colCurrAccDesc, colOfficeCode, colStoreCode, colActivityTypeDesc, colStatus, colPriority, colIsCompleted, colAssignedCurrAccCode, colAssignedCurrAccDesc, colDescription, colResult });
            gV_CrmActivityList.GridControl = gC_CrmActivityList;
            gV_CrmActivityList.Name = "gV_CrmActivityList";
            gV_CrmActivityList.OptionsBehavior.Editable = false;
            gV_CrmActivityList.OptionsFind.FindDelay = 100;
            gV_CrmActivityList.OptionsView.ColumnAutoWidth = false;
            gV_CrmActivityList.OptionsView.ShowAutoFilterRow = true;
            gV_CrmActivityList.OptionsView.ShowGroupPanel = false;
            gV_CrmActivityList.RowCellClick += gV_CrmActivityList_RowCellClick;
            gV_CrmActivityList.CustomColumnDisplayText += gV_CrmActivityList_CustomColumnDisplayText;
            gV_CrmActivityList.CustomUnboundColumnData += gV_CrmActivityList_CustomUnboundColumnData;
            gV_CrmActivityList.PopupMenuShowing += gV_CrmActivityList_PopupMenuShowing;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.Caption = Resources.Entity_Base_CreatedUserName;
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            colCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.Caption = Resources.Entity_Base_LastUpdatedUserName;
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.Caption = Resources.Entity_Base_LastUpdatedDate;
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colActivityCode
            // 
            colActivityCode.Caption = Resources.Entity_TrCrmActivity_ActivityCode;
            colActivityCode.FieldName = "ActivityCode";
            colActivityCode.Name = "colActivityCode";
            colActivityCode.Visible = true;
            colActivityCode.VisibleIndex = 0;
            colActivityCode.Width = 110;
            // 
            // colActivityDate
            // 
            colActivityDate.Caption = Resources.Entity_TrCrmActivity_ActivityDate;
            colActivityDate.FieldName = "ActivityDate";
            colActivityDate.Name = "colActivityDate";
            colActivityDate.Visible = true;
            colActivityDate.VisibleIndex = 1;
            colActivityDate.Width = 100;
            // 
            // colStartTime
            // 
            colStartTime.Caption = Resources.Entity_TrCrmActivity_StartTime;
            colStartTime.FieldName = "StartTime";
            colStartTime.Name = "colStartTime";
            colStartTime.Visible = true;
            colStartTime.VisibleIndex = 2;
            colStartTime.Width = 100;
            // 
            // colEndTime
            // 
            colEndTime.Caption = Resources.Entity_TrCrmActivity_EndTime;
            colEndTime.FieldName = "EndTime";
            colEndTime.Name = "colEndTime";
            colEndTime.Visible = true;
            colEndTime.VisibleIndex = 3;
            colEndTime.Width = 100;
            // 
            // colNextPlanDate
            // 
            colNextPlanDate.Caption = Resources.Entity_TrCrmActivity_NextPlanDate;
            colNextPlanDate.FieldName = "NextPlanDate";
            colNextPlanDate.Name = "colNextPlanDate";
            colNextPlanDate.Visible = true;
            colNextPlanDate.VisibleIndex = 4;
            colNextPlanDate.Width = 120;
            // 
            // colSubject
            // 
            colSubject.Caption = Resources.Entity_TrCrmActivity_Subject;
            colSubject.FieldName = "Subject";
            colSubject.Name = "colSubject";
            colSubject.Visible = true;
            colSubject.VisibleIndex = 5;
            colSubject.Width = 180;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = Resources.Entity_CurrAcc_Code;
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 6;
            colCurrAccCode.Width = 120;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.Caption = Resources.Entity_CurrAcc_Desc;
            colCurrAccDesc.FieldName = "DcCurrAcc.CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 7;
            colCurrAccDesc.Width = 160;
            // 
            // colOfficeCode
            // 
            colOfficeCode.Caption = Resources.Entity_CurrAcc_Office;
            colOfficeCode.FieldName = "OfficeCode";
            colOfficeCode.Name = "colOfficeCode";
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = Resources.Entity_CurrAcc_StoreCode;
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            // 
            // colActivityTypeDesc
            // 
            colActivityTypeDesc.Caption = Resources.Entity_TrCrmActivity_ActivityTypeId;
            colActivityTypeDesc.FieldName = "DcCrmActivityType.ActivityTypeDesc";
            colActivityTypeDesc.Name = "colActivityTypeDesc";
            colActivityTypeDesc.Visible = true;
            colActivityTypeDesc.VisibleIndex = 8;
            colActivityTypeDesc.Width = 130;
            // 
            // colStatus
            // 
            colStatus.Caption = Resources.Entity_TrCrmActivity_Status;
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 9;
            colStatus.Width = 100;
            // 
            // colPriority
            // 
            colPriority.Caption = Resources.Entity_TrCrmActivity_Priority;
            colPriority.FieldName = "Priority";
            colPriority.Name = "colPriority";
            colPriority.Visible = true;
            colPriority.VisibleIndex = 10;
            colPriority.Width = 90;
            // 
            // colIsCompleted
            // 
            colIsCompleted.Caption = Resources.Entity_TrCrmActivity_IsCompleted;
            colIsCompleted.FieldName = "IsCompleted";
            colIsCompleted.Name = "colIsCompleted";
            colIsCompleted.Visible = true;
            colIsCompleted.VisibleIndex = 11;
            colIsCompleted.Width = 90;
            // 
            // colAssignedCurrAccCode
            // 
            colAssignedCurrAccCode.Caption = Resources.Entity_TrCrmActivity_AssignedCurrAccCode;
            colAssignedCurrAccCode.FieldName = "AssignedCurrAccCode";
            colAssignedCurrAccCode.Name = "colAssignedCurrAccCode";
            colAssignedCurrAccCode.Visible = true;
            colAssignedCurrAccCode.VisibleIndex = 12;
            colAssignedCurrAccCode.Width = 120;
            // 
            // colAssignedCurrAccDesc
            // 
            colAssignedCurrAccDesc.Caption = Resources.Entity_TrCrmActivity_AssignedCurrAccDesc;
            colAssignedCurrAccDesc.FieldName = "AssignedCurrAccDesc";
            colAssignedCurrAccDesc.Name = "colAssignedCurrAccDesc";
            colAssignedCurrAccDesc.UnboundDataType = typeof(string);
            colAssignedCurrAccDesc.Visible = true;
            colAssignedCurrAccDesc.VisibleIndex = 13;
            colAssignedCurrAccDesc.Width = 160;
            // 
            // colDescription
            // 
            colDescription.Caption = Resources.Entity_TrCrmActivity_Description;
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 14;
            colDescription.Width = 220;
            // 
            // colResult
            // 
            colResult.Caption = Resources.Entity_TrCrmActivity_Result;
            colResult.FieldName = "Result";
            colResult.Name = "colResult";
            colResult.Visible = true;
            colResult.VisibleIndex = 15;
            colResult.Width = 220;
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
            bBI_CrmActivityNew.Caption = Resources.Common_New;
            bBI_CrmActivityNew.Id = 1;
            bBI_CrmActivityNew.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityNew.ImageOptions.SvgImage");
            bBI_CrmActivityNew.Name = "bBI_CrmActivityNew";
            bBI_CrmActivityNew.ItemClick += bBI_CrmActivityNew_ItemClick;
            // 
            // bBI_CrmActivityEdit
            // 
            bBI_CrmActivityEdit.Caption = Resources.Common_Edit;
            bBI_CrmActivityEdit.Id = 2;
            bBI_CrmActivityEdit.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityEdit.ImageOptions.SvgImage");
            bBI_CrmActivityEdit.Name = "bBI_CrmActivityEdit";
            bBI_CrmActivityEdit.ItemClick += bBI_CrmActivityEdit_ItemClick;
            // 
            // bBI_ExportXlsx
            // 
            bBI_ExportXlsx.Caption = Resources.Common_ExportToExcel;
            bBI_ExportXlsx.Id = 3;
            bBI_ExportXlsx.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage");
            bBI_ExportXlsx.Name = "bBI_ExportXlsx";
            bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            // 
            // bBI_CrmActivityDelete
            // 
            bBI_CrmActivityDelete.Caption = Resources.Common_Delete;
            bBI_CrmActivityDelete.Id = 4;
            bBI_CrmActivityDelete.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityDelete.ImageOptions.SvgImage");
            bBI_CrmActivityDelete.Name = "bBI_CrmActivityDelete";
            bBI_CrmActivityDelete.ItemClick += bBI_CrmActivityDelete_ItemClick;
            // 
            // bBI_CrmActivityRefresh
            // 
            bBI_CrmActivityRefresh.Caption = Resources.Common_Refresh;
            bBI_CrmActivityRefresh.Id = 5;
            bBI_CrmActivityRefresh.ImageOptions.SvgImage = (SvgImage)resources.GetObject("bBI_CrmActivityRefresh.ImageOptions.SvgImage");
            bBI_CrmActivityRefresh.Name = "bBI_CrmActivityRefresh";
            bBI_CrmActivityRefresh.ItemClick += bBI_CrmActivityRefresh_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_CrmActivityList_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_CrmActivityRefresh);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Common_Operations;
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = Resources.Common_Export;
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 620);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);
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
            Text = Resources.Form_CrmActivityList_Caption;
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
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colNextPlanDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityTypeDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignedCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
    }
}
