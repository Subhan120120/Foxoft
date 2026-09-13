namespace Foxoft
{
    partial class FormBackupManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBackupManager));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_NewJob = new DevExpress.XtraBars.BarButtonItem();
            bBI_EditJob = new DevExpress.XtraBars.BarButtonItem();
            bBI_DeleteJob = new DevExpress.XtraBars.BarButtonItem();
            bBI_RunNow = new DevExpress.XtraBars.BarButtonItem();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bSI_ServiceStatus = new DevExpress.XtraBars.BarStaticItem();
            bBI_StartService = new DevExpress.XtraBars.BarButtonItem();
            bBI_StopService = new DevExpress.XtraBars.BarButtonItem();
            bBI_InstallService = new DevExpress.XtraBars.BarButtonItem();
            bBI_UninstallService = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupJobs = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupService = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            gc_Jobs = new DevExpress.XtraGrid.GridControl();
            gv_Jobs = new DevExpress.XtraGrid.Views.Grid.GridView();
            colJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            colDatabaseNames = new DevExpress.XtraGrid.Columns.GridColumn();
            colBackupType = new DevExpress.XtraGrid.Columns.GridColumn();
            colCompressionType = new DevExpress.XtraGrid.Columns.GridColumn();
            colLocalPath = new DevExpress.XtraGrid.Columns.GridColumn();
            colUploadToCloud = new DevExpress.XtraGrid.Columns.GridColumn();
            colRetentionDays = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastRunTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colNextRunTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            gc_Logs = new DevExpress.XtraGrid.GridControl();
            gv_Logs = new DevExpress.XtraGrid.Views.Grid.GridView();
            colLogStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogDatabaseName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogBackupType = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogFileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogCompressedSize = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogCloud = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogSuccess = new DevExpress.XtraGrid.Columns.GridColumn();
            colLogError = new DevExpress.XtraGrid.Columns.GridColumn();
            timerStatus = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gc_Jobs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gv_Jobs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gc_Logs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gv_Logs).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_NewJob, bBI_EditJob, bBI_DeleteJob, bBI_RunNow, bBI_Refresh, bSI_ServiceStatus, bBI_StartService, bBI_StopService, bBI_InstallService, bBI_UninstallService });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 12;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // bBI_NewJob
            // 
            bBI_NewJob.Caption = "Yeni Tapşırıq";
            bBI_NewJob.Id = 1;
            bBI_NewJob.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_NewJob.ImageOptions.SvgImage");
            bBI_NewJob.Name = "bBI_NewJob";
            bBI_NewJob.ItemClick += bBI_NewJob_ItemClick;
            // 
            // bBI_EditJob
            // 
            bBI_EditJob.Caption = "Düzəliş et";
            bBI_EditJob.Id = 2;
            bBI_EditJob.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_EditJob.ImageOptions.SvgImage");
            bBI_EditJob.Name = "bBI_EditJob";
            bBI_EditJob.ItemClick += bBI_EditJob_ItemClick;
            // 
            // bBI_DeleteJob
            // 
            bBI_DeleteJob.Caption = "Sil";
            bBI_DeleteJob.Id = 3;
            bBI_DeleteJob.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_DeleteJob.ImageOptions.SvgImage");
            bBI_DeleteJob.Name = "bBI_DeleteJob";
            bBI_DeleteJob.ItemClick += bBI_DeleteJob_ItemClick;
            // 
            // bBI_RunNow
            // 
            bBI_RunNow.Caption = "İndi İcra Et";
            bBI_RunNow.Id = 4;
            bBI_RunNow.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_RunNow.ImageOptions.SvgImage");
            bBI_RunNow.Name = "bBI_RunNow";
            bBI_RunNow.ItemClick += bBI_RunNow_ItemClick;
            // 
            // bBI_Refresh
            // 
            bBI_Refresh.Caption = "Yenilə";
            bBI_Refresh.Id = 5;
            bBI_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Refresh.ImageOptions.SvgImage");
            bBI_Refresh.Name = "bBI_Refresh";
            bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            // 
            // bSI_ServiceStatus
            // 
            bSI_ServiceStatus.Caption = "Status: Yoxlanılır...";
            bSI_ServiceStatus.Id = 6;
            bSI_ServiceStatus.Name = "bSI_ServiceStatus";
            // 
            // bBI_StartService
            // 
            bBI_StartService.Caption = "Başlat";
            bBI_StartService.Id = 7;
            bBI_StartService.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_StartService.ImageOptions.SvgImage");
            bBI_StartService.Name = "bBI_StartService";
            bBI_StartService.ItemClick += bBI_StartService_ItemClick;
            // 
            // bBI_StopService
            // 
            bBI_StopService.Caption = "Dayandır";
            bBI_StopService.Id = 8;
            bBI_StopService.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_StopService.ImageOptions.SvgImage");
            bBI_StopService.Name = "bBI_StopService";
            bBI_StopService.ItemClick += bBI_StopService_ItemClick;
            // 
            // bBI_InstallService
            // 
            bBI_InstallService.Caption = "Servisi Quraşdır";
            bBI_InstallService.Id = 9;
            bBI_InstallService.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_InstallService.ImageOptions.SvgImage");
            bBI_InstallService.Name = "bBI_InstallService";
            bBI_InstallService.ItemClick += bBI_InstallService_ItemClick;
            // 
            // bBI_UninstallService
            // 
            bBI_UninstallService.Caption = "Servisi Sil";
            bBI_UninstallService.Id = 10;
            bBI_UninstallService.Name = "bBI_UninstallService";
            bBI_UninstallService.ItemClick += bBI_UninstallService_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupJobs, ribbonPageGroupService });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Backup İdarəetməsi";
            // 
            // ribbonPageGroupJobs
            // 
            ribbonPageGroupJobs.ItemLinks.Add(bBI_NewJob);
            ribbonPageGroupJobs.ItemLinks.Add(bBI_EditJob);
            ribbonPageGroupJobs.ItemLinks.Add(bBI_DeleteJob);
            ribbonPageGroupJobs.ItemLinks.Add(bBI_RunNow);
            ribbonPageGroupJobs.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroupJobs.Name = "ribbonPageGroupJobs";
            ribbonPageGroupJobs.Text = "Tapşırıqlar";
            // 
            // ribbonPageGroupService
            // 
            ribbonPageGroupService.ItemLinks.Add(bBI_StartService);
            ribbonPageGroupService.ItemLinks.Add(bBI_StopService);
            ribbonPageGroupService.ItemLinks.Add(bBI_InstallService);
            ribbonPageGroupService.ItemLinks.Add(bBI_UninstallService);
            ribbonPageGroupService.Name = "ribbonPageGroupService";
            ribbonPageGroupService.Text = "Fon Servisi";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.ItemLinks.Add(bSI_ServiceStatus);
            ribbonStatusBar1.Location = new Point(0, 676);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("add", "image://svgimages/icon builder/actions_add.svg");
            svgImageCollection1.Add("edit", "image://svgimages/icon builder/actions_edit.svg");
            svgImageCollection1.Add("delete", "image://svgimages/icon builder/actions_delete.svg");
            svgImageCollection1.Add("refresh", "image://svgimages/icon builder/actions_refresh.svg");
            svgImageCollection1.Add("uninstall", "image://svgimages/scheduling/delete.svg");
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.Horizontal = false;
            splitContainerControl1.Location = new Point(0, 158);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(gc_Jobs);
            splitContainerControl1.Panel1.Text = "Tapşırıqlar";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(gc_Logs);
            splitContainerControl1.Panel2.Text = "Jurnal";
            splitContainerControl1.Size = new Size(1100, 518);
            splitContainerControl1.SplitterPosition = 260;
            splitContainerControl1.TabIndex = 2;
            // 
            // gc_Jobs
            // 
            gc_Jobs.Dock = DockStyle.Fill;
            gc_Jobs.Location = new Point(0, 0);
            gc_Jobs.MainView = gv_Jobs;
            gc_Jobs.MenuManager = ribbonControl1;
            gc_Jobs.Name = "gc_Jobs";
            gc_Jobs.Size = new Size(1100, 260);
            gc_Jobs.TabIndex = 0;
            gc_Jobs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gv_Jobs });
            // 
            // gv_Jobs
            // 
            gv_Jobs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colJobName, colIsEnabled, colDatabaseNames, colBackupType, colCompressionType, colLocalPath, colUploadToCloud, colRetentionDays, colLastRunTime, colNextRunTime, colLastStatus });
            gv_Jobs.GridControl = gc_Jobs;
            gv_Jobs.Name = "gv_Jobs";
            gv_Jobs.OptionsBehavior.Editable = false;
            gv_Jobs.OptionsView.ShowGroupPanel = false;
            gv_Jobs.DoubleClick += gv_Jobs_DoubleClick;
            // 
            // colJobName
            // 
            colJobName.Caption = "Tapşırığın Adı";
            colJobName.FieldName = "JobName";
            colJobName.Name = "colJobName";
            colJobName.Visible = true;
            colJobName.VisibleIndex = 0;
            colJobName.Width = 150;
            // 
            // colIsEnabled
            // 
            colIsEnabled.Caption = "Aktivdir";
            colIsEnabled.FieldName = "IsEnabled";
            colIsEnabled.Name = "colIsEnabled";
            colIsEnabled.Visible = true;
            colIsEnabled.VisibleIndex = 1;
            colIsEnabled.Width = 60;
            // 
            // colDatabaseNames
            // 
            colDatabaseNames.Caption = "Bazalar";
            colDatabaseNames.FieldName = "DatabaseNames";
            colDatabaseNames.Name = "colDatabaseNames";
            colDatabaseNames.Visible = true;
            colDatabaseNames.VisibleIndex = 2;
            colDatabaseNames.Width = 140;
            // 
            // colBackupType
            // 
            colBackupType.Caption = "Növ";
            colBackupType.FieldName = "BackupType";
            colBackupType.Name = "colBackupType";
            colBackupType.Visible = true;
            colBackupType.VisibleIndex = 3;
            colBackupType.Width = 80;
            // 
            // colCompressionType
            // 
            colCompressionType.Caption = "Arxivləmə";
            colCompressionType.FieldName = "CompressionType";
            colCompressionType.Name = "colCompressionType";
            colCompressionType.Visible = true;
            colCompressionType.VisibleIndex = 4;
            colCompressionType.Width = 80;
            // 
            // colLocalPath
            // 
            colLocalPath.Caption = "Yerli Qovluq";
            colLocalPath.FieldName = "LocalPath";
            colLocalPath.Name = "colLocalPath";
            colLocalPath.Visible = true;
            colLocalPath.VisibleIndex = 5;
            colLocalPath.Width = 160;
            // 
            // colUploadToCloud
            // 
            colUploadToCloud.Caption = "Bulud";
            colUploadToCloud.FieldName = "UploadToCloud";
            colUploadToCloud.Name = "colUploadToCloud";
            colUploadToCloud.Visible = true;
            colUploadToCloud.VisibleIndex = 6;
            colUploadToCloud.Width = 60;
            // 
            // colRetentionDays
            // 
            colRetentionDays.Caption = "Saxlama (Gün)";
            colRetentionDays.FieldName = "RetentionDays";
            colRetentionDays.Name = "colRetentionDays";
            colRetentionDays.Visible = true;
            colRetentionDays.VisibleIndex = 7;
            colRetentionDays.Width = 90;
            // 
            // colLastRunTime
            // 
            colLastRunTime.Caption = "Son İcra";
            colLastRunTime.DisplayFormat.FormatString = "g";
            colLastRunTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colLastRunTime.FieldName = "LastRunTime";
            colLastRunTime.Name = "colLastRunTime";
            colLastRunTime.Visible = true;
            colLastRunTime.VisibleIndex = 8;
            colLastRunTime.Width = 120;
            // 
            // colNextRunTime
            // 
            colNextRunTime.Caption = "Növbəti İcra";
            colNextRunTime.DisplayFormat.FormatString = "g";
            colNextRunTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colNextRunTime.FieldName = "NextRunTime";
            colNextRunTime.Name = "colNextRunTime";
            colNextRunTime.Visible = true;
            colNextRunTime.VisibleIndex = 9;
            colNextRunTime.Width = 120;
            // 
            // colLastStatus
            // 
            colLastStatus.Caption = "Status";
            colLastStatus.FieldName = "LastStatus";
            colLastStatus.Name = "colLastStatus";
            colLastStatus.Visible = true;
            colLastStatus.VisibleIndex = 10;
            colLastStatus.Width = 90;
            // 
            // gc_Logs
            // 
            gc_Logs.Dock = DockStyle.Fill;
            gc_Logs.Location = new Point(0, 0);
            gc_Logs.MainView = gv_Logs;
            gc_Logs.MenuManager = ribbonControl1;
            gc_Logs.Name = "gc_Logs";
            gc_Logs.Size = new Size(1100, 248);
            gc_Logs.TabIndex = 0;
            gc_Logs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gv_Logs });
            // 
            // gv_Logs
            // 
            gv_Logs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colLogStartTime, colLogJobName, colLogDatabaseName, colLogBackupType, colLogFileName, colLogFileSize, colLogCompressedSize, colLogDuration, colLogCloud, colLogSuccess, colLogError });
            gv_Logs.GridControl = gc_Logs;
            gv_Logs.Name = "gv_Logs";
            gv_Logs.OptionsBehavior.Editable = false;
            gv_Logs.OptionsView.ShowGroupPanel = false;
            // 
            // colLogStartTime
            // 
            colLogStartTime.Caption = "Tarix";
            colLogStartTime.DisplayFormat.FormatString = "g";
            colLogStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colLogStartTime.FieldName = "StartTime";
            colLogStartTime.Name = "colLogStartTime";
            colLogStartTime.Visible = true;
            colLogStartTime.VisibleIndex = 0;
            colLogStartTime.Width = 110;
            // 
            // colLogJobName
            // 
            colLogJobName.Caption = "Tapşırıq";
            colLogJobName.FieldName = "JobName";
            colLogJobName.Name = "colLogJobName";
            colLogJobName.Visible = true;
            colLogJobName.VisibleIndex = 1;
            colLogJobName.Width = 120;
            // 
            // colLogDatabaseName
            // 
            colLogDatabaseName.Caption = "Baza";
            colLogDatabaseName.FieldName = "DatabaseName";
            colLogDatabaseName.Name = "colLogDatabaseName";
            colLogDatabaseName.Visible = true;
            colLogDatabaseName.VisibleIndex = 2;
            colLogDatabaseName.Width = 100;
            // 
            // colLogBackupType
            // 
            colLogBackupType.Caption = "Növ";
            colLogBackupType.FieldName = "BackupType";
            colLogBackupType.Name = "colLogBackupType";
            colLogBackupType.Visible = true;
            colLogBackupType.VisibleIndex = 3;
            colLogBackupType.Width = 80;
            // 
            // colLogFileName
            // 
            colLogFileName.Caption = "Fayl Adı";
            colLogFileName.FieldName = "BackupFileName";
            colLogFileName.Name = "colLogFileName";
            colLogFileName.Visible = true;
            colLogFileName.VisibleIndex = 4;
            colLogFileName.Width = 150;
            // 
            // colLogFileSize
            // 
            colLogFileSize.Caption = "İlkin Ölçü (MB)";
            colLogFileSize.DisplayFormat.FormatString = "{0:N2} MB";
            colLogFileSize.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colLogFileSize.FieldName = "FileSizeMb";
            colLogFileSize.Name = "colLogFileSize";
            colLogFileSize.Visible = true;
            colLogFileSize.VisibleIndex = 5;
            colLogFileSize.Width = 100;
            // 
            // colLogCompressedSize
            // 
            colLogCompressedSize.Caption = "Sıxılmış (MB)";
            colLogCompressedSize.DisplayFormat.FormatString = "{0:N2} MB";
            colLogCompressedSize.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colLogCompressedSize.FieldName = "CompressedSizeMb";
            colLogCompressedSize.Name = "colLogCompressedSize";
            colLogCompressedSize.Visible = true;
            colLogCompressedSize.VisibleIndex = 6;
            colLogCompressedSize.Width = 100;
            // 
            // colLogDuration
            // 
            colLogDuration.Caption = "Müddət (san)";
            colLogDuration.DisplayFormat.FormatString = "F1";
            colLogDuration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colLogDuration.FieldName = "DurationSeconds";
            colLogDuration.Name = "colLogDuration";
            colLogDuration.Visible = true;
            colLogDuration.VisibleIndex = 7;
            colLogDuration.Width = 80;
            // 
            // colLogCloud
            // 
            colLogCloud.Caption = "Bulud";
            colLogCloud.FieldName = "IsUploadedToCloud";
            colLogCloud.Name = "colLogCloud";
            colLogCloud.Visible = true;
            colLogCloud.VisibleIndex = 8;
            colLogCloud.Width = 60;
            // 
            // colLogSuccess
            // 
            colLogSuccess.Caption = "Nəticə";
            colLogSuccess.FieldName = "IsSuccess";
            colLogSuccess.Name = "colLogSuccess";
            colLogSuccess.Visible = true;
            colLogSuccess.VisibleIndex = 9;
            colLogSuccess.Width = 60;
            // 
            // colLogError
            // 
            colLogError.Caption = "Xəta";
            colLogError.FieldName = "ErrorMessage";
            colLogError.Name = "colLogError";
            colLogError.Visible = true;
            colLogError.VisibleIndex = 10;
            colLogError.Width = 150;
            // 
            // timerStatus
            // 
            timerStatus.Interval = 3000;
            timerStatus.Tick += timerStatus_Tick;
            // 
            // FormBackupManager
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(splitContainerControl1);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormBackupManager";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "Backup İdarəetməsi";
            Load += FormBackupManager_Load;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gc_Jobs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gv_Jobs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gc_Logs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gv_Logs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupJobs;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupService;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem bBI_NewJob;
        private DevExpress.XtraBars.BarButtonItem bBI_EditJob;
        private DevExpress.XtraBars.BarButtonItem bBI_DeleteJob;
        private DevExpress.XtraBars.BarButtonItem bBI_RunNow;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarStaticItem bSI_ServiceStatus;
        private DevExpress.XtraBars.BarButtonItem bBI_StartService;
        private DevExpress.XtraBars.BarButtonItem bBI_StopService;
        private DevExpress.XtraBars.BarButtonItem bBI_InstallService;
        private DevExpress.XtraBars.BarButtonItem bBI_UninstallService;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gc_Jobs;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Jobs;
        private DevExpress.XtraGrid.Columns.GridColumn colJobName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colDatabaseNames;
        private DevExpress.XtraGrid.Columns.GridColumn colBackupType;
        private DevExpress.XtraGrid.Columns.GridColumn colCompressionType;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalPath;
        private DevExpress.XtraGrid.Columns.GridColumn colUploadToCloud;
        private DevExpress.XtraGrid.Columns.GridColumn colRetentionDays;
        private DevExpress.XtraGrid.Columns.GridColumn colLastRunTime;
        private DevExpress.XtraGrid.Columns.GridColumn colNextRunTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLastStatus;
        private DevExpress.XtraGrid.GridControl gc_Logs;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Logs;
        private DevExpress.XtraGrid.Columns.GridColumn colLogStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLogJobName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDatabaseName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogBackupType;
        private DevExpress.XtraGrid.Columns.GridColumn colLogFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogFileSize;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCompressedSize;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCloud;
        private DevExpress.XtraGrid.Columns.GridColumn colLogSuccess;
        private DevExpress.XtraGrid.Columns.GridColumn colLogError;
        private System.Windows.Forms.Timer timerStatus;
    }
}
