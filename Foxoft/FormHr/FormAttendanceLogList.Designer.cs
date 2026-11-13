namespace Foxoft
{
    partial class FormAttendanceLogList
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
            this.barEditDateFrom = new DevExpress.XtraBars.BarEditItem();
            this.repoDateFrom = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditDateTo = new DevExpress.XtraBars.BarEditItem();
            this.repoDateTo = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barEditStore = new DevExpress.XtraBars.BarEditItem();
            this.repoStore = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonGroupFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupOperations = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateFrom.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateTo.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbon.ExpandCollapseItem,
                this.barEditDateFrom,
                this.barEditDateTo,
                this.barEditStore,
                this.btnRefresh,
                this.btnImportExcel,
                this.btnDelete,
                this.btnClose
            });
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPage1
            });
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repoDateFrom,
                this.repoDateTo,
                this.repoStore
            });
            this.ribbon.Size = new System.Drawing.Size(1180, 158);
            // 
            // barEditDateFrom
            // 
            this.barEditDateFrom.Caption = Foxoft.Properties.Resources.Common_StartDate;
            this.barEditDateFrom.Edit = this.repoDateFrom;
            this.barEditDateFrom.EditWidth = 120;
            this.barEditDateFrom.Id = 1;
            this.barEditDateFrom.Name = "barEditDateFrom";
            // 
            // repoDateFrom
            // 
            this.repoDateFrom.AutoHeight = false;
            this.repoDateFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.repoDateFrom.Name = "repoDateFrom";
            // 
            // barEditDateTo
            // 
            this.barEditDateTo.Caption = Foxoft.Properties.Resources.Common_EndDate;
            this.barEditDateTo.Edit = this.repoDateTo;
            this.barEditDateTo.EditWidth = 120;
            this.barEditDateTo.Id = 2;
            this.barEditDateTo.Name = "barEditDateTo";
            // 
            // repoDateTo
            // 
            this.repoDateTo.AutoHeight = false;
            this.repoDateTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.repoDateTo.Name = "repoDateTo";
            // 
            // barEditStore
            // 
            this.barEditStore.Caption = Foxoft.Properties.Resources.Common_Store;
            this.barEditStore.Edit = this.repoStore;
            this.barEditStore.EditWidth = 140;
            this.barEditStore.Id = 3;
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
            // btnRefresh
            // 
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Caption = Foxoft.Properties.Resources.Form_AttendanceLogList_ImportExcel;
            this.btnImportExcel.Id = 5;
            this.btnImportExcel.Name = "btnImportExcel";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = Foxoft.Properties.Resources.Common_Delete;
            this.btnDelete.Id = 6;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnClose
            // 
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 7;
            this.btnClose.Name = "btnClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonGroupFilter,
                this.ribbonGroupOperations
            });
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.ERP_ACE_AttendanceLogs;
            // 
            // ribbonGroupFilter
            // 
            this.ribbonGroupFilter.ItemLinks.Add(this.barEditDateFrom);
            this.ribbonGroupFilter.ItemLinks.Add(this.barEditDateTo);
            this.ribbonGroupFilter.ItemLinks.Add(this.barEditStore);
            this.ribbonGroupFilter.ItemLinks.Add(this.btnRefresh);
            this.ribbonGroupFilter.Name = "ribbonGroupFilter";
            this.ribbonGroupFilter.Text = Foxoft.Properties.Resources.Common_Filter;
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.ItemLinks.Add(this.btnImportExcel);
            this.ribbonGroupOperations.ItemLinks.Add(this.btnDelete);
            this.ribbonGroupOperations.ItemLinks.Add(this.btnClose);
            this.ribbonGroupOperations.Name = "ribbonGroupOperations";
            this.ribbonGroupOperations.Text = Foxoft.Properties.Resources.Common_Operation;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1180, 522);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridView1
            });
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // FormAttendanceLogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormAttendanceLogList";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Foxoft.Properties.Resources.Form_AttendanceLogList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateFrom.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateTo.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupOperations;
        private DevExpress.XtraBars.BarEditItem barEditDateFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repoDateFrom;
        private DevExpress.XtraBars.BarEditItem barEditDateTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repoDateTo;
        private DevExpress.XtraBars.BarEditItem barEditStore;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoStore;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnImportExcel;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
