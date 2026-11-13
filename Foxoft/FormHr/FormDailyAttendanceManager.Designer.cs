namespace Foxoft
{
    partial class FormDailyAttendanceManager
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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditDate = new DevExpress.XtraBars.BarEditItem();
            this.repoDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditStore = new DevExpress.XtraBars.BarEditItem();
            this.repoStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barEditStatus = new DevExpress.XtraBars.BarEditItem();
            this.repoStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnToday = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrev = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewTimeline = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewDay = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewWorkWeek = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewMonth = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewAgenda = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkExcused = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkUnexcused = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkRestDay = new DevExpress.XtraBars.BarButtonItem();
            this.btnApproveOvertime = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecalculate = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonGroupFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupViews = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbon.ExpandCollapseItem,
                this.barEditDate,
                this.barEditStore,
                this.barEditStatus,
                this.btnRefresh,
                this.btnToday,
                this.btnPrev,
                this.btnNext,
                this.btnViewTimeline,
                this.btnViewDay,
                this.btnViewWorkWeek,
                this.btnViewMonth,
                this.btnViewAgenda,
                this.btnMarkExcused,
                this.btnMarkUnexcused,
                this.btnMarkRestDay,
                this.btnApproveOvertime,
                this.btnRecalculate,
                this.btnEdit,
                this.btnSave,
                this.btnDelete,
                this.btnClose
            });
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 22;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPage1
            });
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repoDate,
                this.repoStore,
                this.repoStatus
            });
            this.ribbon.Size = new System.Drawing.Size(1280, 158);
            // 
            // barEditDate
            // 
            this.barEditDate.Caption = Foxoft.Properties.Resources.Common_Date;
            this.barEditDate.Edit = this.repoDate;
            this.barEditDate.EditWidth = 120;
            this.barEditDate.Id = 1;
            this.barEditDate.Name = "barEditDate";
            // 
            // repoDate
            // 
            this.repoDate.AutoHeight = false;
            this.repoDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.repoDate.Name = "repoDate";
            // 
            // barEditStore
            // 
            this.barEditStore.Caption = Foxoft.Properties.Resources.Common_Store;
            this.barEditStore.Edit = this.repoStore;
            this.barEditStore.EditWidth = 140;
            this.barEditStore.Id = 2;
            this.barEditStore.Name = "barEditStore";
            // 
            // repoStore
            // 
            this.repoStore.AutoHeight = false;
            this.repoStore.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.repoStore.NullText = Foxoft.Properties.Resources.Common_All;
            this.repoStore.Name = "repoStore";
            // 
            // barEditStatus
            // 
            this.barEditStatus.Caption = Foxoft.Properties.Resources.Entity_Attendance_Status;
            this.barEditStatus.Edit = this.repoStatus;
            this.barEditStatus.EditWidth = 130;
            this.barEditStatus.Id = 3;
            this.barEditStatus.Name = "barEditStatus";
            // 
            // repoStatus
            // 
            this.repoStatus.AutoHeight = false;
            this.repoStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.repoStatus.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repoStatus.Name = "repoStatus";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnToday
            // 
            this.btnToday.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_Today;
            this.btnToday.Id = 5;
            this.btnToday.Name = "btnToday";
            // 
            // btnPrev
            // 
            this.btnPrev.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_Previous;
            this.btnPrev.Id = 6;
            this.btnPrev.Name = "btnPrev";
            // 
            // btnNext
            // 
            this.btnNext.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_Next;
            this.btnNext.Id = 7;
            this.btnNext.Name = "btnNext";
            // 
            // btnViewTimeline
            // 
            this.btnViewTimeline.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ViewTimeline;
            this.btnViewTimeline.Id = 8;
            this.btnViewTimeline.Name = "btnViewTimeline";
            // 
            // btnViewDay
            // 
            this.btnViewDay.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ViewDay;
            this.btnViewDay.Id = 9;
            this.btnViewDay.Name = "btnViewDay";
            // 
            // btnViewWorkWeek
            // 
            this.btnViewWorkWeek.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ViewWorkWeek;
            this.btnViewWorkWeek.Id = 10;
            this.btnViewWorkWeek.Name = "btnViewWorkWeek";
            // 
            // btnViewMonth
            // 
            this.btnViewMonth.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ViewMonth;
            this.btnViewMonth.Id = 11;
            this.btnViewMonth.Name = "btnViewMonth";
            // 
            // btnViewAgenda
            // 
            this.btnViewAgenda.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ViewAgenda;
            this.btnViewAgenda.Id = 12;
            this.btnViewAgenda.Name = "btnViewAgenda";
            // 
            // btnMarkExcused
            // 
            this.btnMarkExcused.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_MarkExcused;
            this.btnMarkExcused.Id = 13;
            this.btnMarkExcused.Name = "btnMarkExcused";
            // 
            // btnMarkUnexcused
            // 
            this.btnMarkUnexcused.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_MarkUnexcused;
            this.btnMarkUnexcused.Id = 14;
            this.btnMarkUnexcused.Name = "btnMarkUnexcused";
            // 
            // btnMarkRestDay
            // 
            this.btnMarkRestDay.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_MarkRestDay;
            this.btnMarkRestDay.Id = 15;
            this.btnMarkRestDay.Name = "btnMarkRestDay";
            // 
            // btnApproveOvertime
            // 
            this.btnApproveOvertime.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ApproveOvertime;
            this.btnApproveOvertime.Id = 16;
            this.btnApproveOvertime.Name = "btnApproveOvertime";
            // 
            // btnRecalculate
            // 
            this.btnRecalculate.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_Recalculate;
            this.btnRecalculate.Id = 17;
            this.btnRecalculate.Name = "btnRecalculate";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = Foxoft.Properties.Resources.Common_Edit;
            this.btnEdit.Id = 18;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnSave
            // 
            this.btnSave.Caption = Foxoft.Properties.Resources.Common_Save;
            this.btnSave.Id = 19;
            this.btnSave.Name = "btnSave";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = Foxoft.Properties.Resources.Common_Delete;
            this.btnDelete.Id = 20;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnClose
            // 
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 21;
            this.btnClose.Name = "btnClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonGroupFilter,
                this.ribbonGroupNavigation,
                this.ribbonGroupViews,
                this.ribbonGroupActions
            });
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.ERP_ACE_DailyAttendance;
            // 
            // ribbonGroupFilter
            // 
            this.ribbonGroupFilter.ItemLinks.Add(this.barEditDate);
            this.ribbonGroupFilter.ItemLinks.Add(this.barEditStore);
            this.ribbonGroupFilter.ItemLinks.Add(this.barEditStatus);
            this.ribbonGroupFilter.ItemLinks.Add(this.btnRefresh);
            this.ribbonGroupFilter.Name = "ribbonGroupFilter";
            this.ribbonGroupFilter.Text = Foxoft.Properties.Resources.Common_Filter;
            // 
            // ribbonGroupNavigation
            // 
            this.ribbonGroupNavigation.ItemLinks.Add(this.btnToday);
            this.ribbonGroupNavigation.ItemLinks.Add(this.btnPrev);
            this.ribbonGroupNavigation.ItemLinks.Add(this.btnNext);
            this.ribbonGroupNavigation.Name = "ribbonGroupNavigation";
            this.ribbonGroupNavigation.Text = Foxoft.Properties.Resources.Form_DailyAttendance_NavigationGroup;
            // 
            // ribbonGroupViews
            // 
            this.ribbonGroupViews.ItemLinks.Add(this.btnViewTimeline);
            this.ribbonGroupViews.ItemLinks.Add(this.btnViewDay);
            this.ribbonGroupViews.ItemLinks.Add(this.btnViewWorkWeek);
            this.ribbonGroupViews.ItemLinks.Add(this.btnViewMonth);
            this.ribbonGroupViews.ItemLinks.Add(this.btnViewAgenda);
            this.ribbonGroupViews.Name = "ribbonGroupViews";
            this.ribbonGroupViews.Text = Foxoft.Properties.Resources.Form_DailyAttendance_ViewsGroup;
            // 
            // ribbonGroupActions
            // 
            this.ribbonGroupActions.ItemLinks.Add(this.btnMarkExcused);
            this.ribbonGroupActions.ItemLinks.Add(this.btnMarkUnexcused);
            this.ribbonGroupActions.ItemLinks.Add(this.btnMarkRestDay);
            this.ribbonGroupActions.ItemLinks.Add(this.btnApproveOvertime);
            this.ribbonGroupActions.ItemLinks.Add(this.btnRecalculate);
            this.ribbonGroupActions.ItemLinks.Add(this.btnEdit);
            this.ribbonGroupActions.ItemLinks.Add(this.btnSave);
            this.ribbonGroupActions.ItemLinks.Add(this.btnDelete);
            this.ribbonGroupActions.ItemLinks.Add(this.btnClose);
            this.ribbonGroupActions.Name = "ribbonGroupActions";
            this.ribbonGroupActions.Text = Foxoft.Properties.Resources.Common_Operation;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 158);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dateNavigator1);
            this.splitContainerControl1.Panel1.MinSize = 200;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1280, 562);
            this.splitContainerControl1.SplitterPosition = 230;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.ShowTodayButton = true;
            this.dateNavigator1.Size = new System.Drawing.Size(230, 562);
            this.dateNavigator1.TabIndex = 0;
            // 
            // schedulerDataStorage1
            // 
            // Appointments Mappings
            this.schedulerDataStorage1.Appointments.Mappings.AppointmentId = "Id";
            this.schedulerDataStorage1.Appointments.Mappings.ResourceId = "CurrAccCode";
            this.schedulerDataStorage1.Appointments.Mappings.Start = "StartTime";
            this.schedulerDataStorage1.Appointments.Mappings.End = "EndTime";
            this.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerDataStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerDataStorage1.Appointments.Mappings.Status = "StatusId";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "LabelId";
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("AttendanceId", "Id"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("AttendanceStatus", "AttendanceStatus"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("WorkedMinutes", "WorkedMinutes"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("LateMinutes", "LateMinutes"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("EarlyExitMinutes", "EarlyExitMinutes"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("OvertimeMinutes", "OvertimeMinutes"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ApprovedOvertimeMinutes", "ApprovedOvertimeMinutes"));
            this.schedulerDataStorage1.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IsManualOverride", "IsManualOverride"));
            // Resources Mappings
            this.schedulerDataStorage1.Resources.Mappings.Id = "CurrAccCode";
            this.schedulerDataStorage1.Resources.Mappings.Caption = "Caption";
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.MenuManager = this.ribbon;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.Size = new System.Drawing.Size(1040, 562);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Views.TimelineView.AppointmentDisplayOptions.AppointmentAutoHeight = true;
            this.schedulerControl1.Views.TimelineView.ResourcesPerPage = 12;
            this.schedulerControl1.Views.TimelineView.Scales.Add(new DevExpress.XtraScheduler.TimeScaleDay());
            this.schedulerControl1.Views.TimelineView.Scales.Add(new DevExpress.XtraScheduler.TimeScaleHour());
            // 
            // FormDailyAttendanceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormDailyAttendanceManager";
            this.Ribbon = this.ribbon;
            this.Text = Foxoft.Properties.Resources.Form_DailyAttendance_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupNavigation;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupViews;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupActions;
        private DevExpress.XtraBars.BarEditItem barEditDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repoDate;
        private DevExpress.XtraBars.BarEditItem barEditStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoStore;
        private DevExpress.XtraBars.BarEditItem barEditStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoStatus;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnToday;
        private DevExpress.XtraBars.BarButtonItem btnPrev;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnViewTimeline;
        private DevExpress.XtraBars.BarButtonItem btnViewDay;
        private DevExpress.XtraBars.BarButtonItem btnViewWorkWeek;
        private DevExpress.XtraBars.BarButtonItem btnViewMonth;
        private DevExpress.XtraBars.BarButtonItem btnViewAgenda;
        private DevExpress.XtraBars.BarButtonItem btnMarkExcused;
        private DevExpress.XtraBars.BarButtonItem btnMarkUnexcused;
        private DevExpress.XtraBars.BarButtonItem btnMarkRestDay;
        private DevExpress.XtraBars.BarButtonItem btnApproveOvertime;
        private DevExpress.XtraBars.BarButtonItem btnRecalculate;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
    }
}
