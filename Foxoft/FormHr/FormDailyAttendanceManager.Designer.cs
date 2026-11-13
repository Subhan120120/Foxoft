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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditDate = new DevExpress.XtraBars.BarEditItem();
            this.repoDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditStore = new DevExpress.XtraBars.BarEditItem();
            this.repoStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barEditStatus = new DevExpress.XtraBars.BarEditItem();
            this.repoStatus = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkExcused = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkUnexcused = new DevExpress.XtraBars.BarButtonItem();
            this.btnMarkRestDay = new DevExpress.XtraBars.BarButtonItem();
            this.btnApproveOvertime = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecalculate = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonGroupFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
                this.btnMarkExcused,
                this.btnMarkUnexcused,
                this.btnMarkRestDay,
                this.btnApproveOvertime,
                this.btnRecalculate,
                this.btnSave,
                this.btnClose
            });
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
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
            // btnMarkExcused
            // 
            this.btnMarkExcused.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_MarkExcused;
            this.btnMarkExcused.Id = 5;
            this.btnMarkExcused.Name = "btnMarkExcused";
            // 
            // btnMarkUnexcused
            // 
            this.btnMarkUnexcused.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_MarkUnexcused;
            this.btnMarkUnexcused.Id = 6;
            this.btnMarkUnexcused.Name = "btnMarkUnexcused";
            // 
            // btnMarkRestDay
            // 
            this.btnMarkRestDay.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_MarkRestDay;
            this.btnMarkRestDay.Id = 12;
            this.btnMarkRestDay.Name = "btnMarkRestDay";
            // 
            // btnApproveOvertime
            // 
            this.btnApproveOvertime.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_ApproveOvertime;
            this.btnApproveOvertime.Id = 7;
            this.btnApproveOvertime.Name = "btnApproveOvertime";
            // 
            // btnRecalculate
            // 
            this.btnRecalculate.Caption = Foxoft.Properties.Resources.Form_DailyAttendance_Recalculate;
            this.btnRecalculate.Id = 8;
            this.btnRecalculate.Name = "btnRecalculate";
            // 
            // btnSave
            // 
            this.btnSave.Caption = Foxoft.Properties.Resources.Common_Save;
            this.btnSave.Id = 9;
            this.btnSave.Name = "btnSave";
            // 
            // btnClose
            // 
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 10;
            this.btnClose.Name = "btnClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonGroupFilter,
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
            // ribbonGroupActions
            // 
            this.ribbonGroupActions.ItemLinks.Add(this.btnMarkExcused);
            this.ribbonGroupActions.ItemLinks.Add(this.btnMarkUnexcused);
            this.ribbonGroupActions.ItemLinks.Add(this.btnMarkRestDay);
            this.ribbonGroupActions.ItemLinks.Add(this.btnApproveOvertime);
            this.ribbonGroupActions.ItemLinks.Add(this.btnRecalculate);
            this.ribbonGroupActions.ItemLinks.Add(this.btnSave);
            this.ribbonGroupActions.ItemLinks.Add(this.btnClose);
            this.ribbonGroupActions.Name = "ribbonGroupActions";
            this.ribbonGroupActions.Text = Foxoft.Properties.Resources.Common_Operation;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1280, 562);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridView1
            });
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FormDailyAttendanceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormDailyAttendanceManager";
            this.Ribbon = this.ribbon;
            this.Text = Foxoft.Properties.Resources.Form_DailyAttendance_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupActions;
        private DevExpress.XtraBars.BarEditItem barEditDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repoDate;
        private DevExpress.XtraBars.BarEditItem barEditStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoStore;
        private DevExpress.XtraBars.BarEditItem barEditStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoStatus;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnMarkExcused;
        private DevExpress.XtraBars.BarButtonItem btnMarkUnexcused;
        private DevExpress.XtraBars.BarButtonItem btnMarkRestDay;
        private DevExpress.XtraBars.BarButtonItem btnApproveOvertime;
        private DevExpress.XtraBars.BarButtonItem btnRecalculate;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
