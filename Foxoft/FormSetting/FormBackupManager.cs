using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.AppCode.Service.Backup;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormBackupManager : RibbonForm
    {
        public FormBackupManager()
        {
            InitializeComponent();
            DesignComponentNames();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_BackupManager_Title;
            ribbonPage1.Text = Resources.Form_BackupManager_Title;

            bBI_NewJob.Caption = Resources.Form_BackupManager_NewJob;
            bBI_EditJob.Caption = Resources.Form_BackupManager_EditJob;
            bBI_DeleteJob.Caption = Resources.Form_BackupManager_DeleteJob;
            bBI_RunNow.Caption = Resources.Form_BackupManager_RunNow;
            bBI_Refresh.Caption = Resources.Form_BackupManager_Refresh;

            ribbonPageGroupJobs.Text = Resources.Form_BackupJobEdit_Title;
            ribbonPageGroupService.Text = Resources.Form_BackupManager_ServiceStatus;

            bBI_StartService.Caption = Resources.Form_BackupManager_StartService;
            bBI_StopService.Caption = Resources.Form_BackupManager_StopService;
            bBI_InstallService.Caption = Resources.Form_BackupManager_InstallService;
            bBI_UninstallService.Caption = Resources.Form_BackupManager_UninstallService;

            colJobName.Caption = Resources.Entity_DcBackupJob_JobName;
            colIsEnabled.Caption = Resources.Entity_DcBackupJob_IsEnabled;
            colDatabaseNames.Caption = Resources.Entity_DcBackupJob_DatabaseNames;
            colBackupType.Caption = Resources.Entity_DcBackupJob_BackupType;
            colCompressionType.Caption = Resources.Entity_DcBackupJob_CompressionType;
            colLocalPath.Caption = Resources.Entity_DcBackupJob_LocalPath;
            colUploadToCloud.Caption = Resources.Entity_DcBackupJob_UploadToCloud;
            colRetentionDays.Caption = Resources.Entity_DcBackupJob_RetentionDays;
            colLastRunTime.Caption = Resources.Entity_DcBackupJob_LastRunTime;
            colNextRunTime.Caption = Resources.Entity_DcBackupJob_NextRunTime;
            colLastStatus.Caption = Resources.Entity_DcBackupJob_LastStatus;

            colLogStartTime.Caption = Resources.Entity_TrBackupLog_StartTime;
            colLogJobName.Caption = Resources.Entity_TrBackupLog_JobName;
            colLogDatabaseName.Caption = Resources.Entity_TrBackupLog_DatabaseName;
            colLogBackupType.Caption = Resources.Entity_TrBackupLog_BackupType;
            colLogFileName.Caption = Resources.Entity_TrBackupLog_BackupFileName;
            colLogFileSize.Caption = Resources.Entity_TrBackupLog_FileSizeMb;
            colLogCompressedSize.Caption = Resources.Entity_TrBackupLog_CompressedSizeMb;
            colLogDuration.Caption = Resources.Entity_TrBackupLog_DurationSeconds;
            colLogCloud.Caption = Resources.Entity_TrBackupLog_IsUploadedToCloud;
            colLogSuccess.Caption = Resources.Entity_TrBackupLog_IsSuccess;
            colLogError.Caption = Resources.Entity_TrBackupLog_ErrorMessage;

            splitContainerControl1.Panel1.Text = Resources.Form_BackupJobEdit_Title;
            splitContainerControl1.Panel2.Text = Resources.Form_BackupManager_LogsTitle;
        }

        private async void FormBackupManager_Load(object sender, EventArgs e)
        {
            UpdateServiceStatusDisplay();
            timerStatus.Start();
            await RefreshDataAsync();
        }

        private async Task RefreshDataAsync()
        {
            await LoadJobsAsync();
            await LoadLogsAsync();
        }

        private async Task LoadJobsAsync()
        {
            try
            {
                await using subContext db = new();
                List<DcBackupJob> jobs = await db.DcBackupJobs
                    .AsNoTracking()
                    .OrderBy(x => x.BackupJobId)
                    .ToListAsync();

                gc_Jobs.DataSource = jobs;
                gv_Jobs.BestFitColumns();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Jobs yüklənərkən xəta: {ex.Message}");
            }
        }

        private async Task LoadLogsAsync()
        {
            try
            {
                await using subContext db = new();
                List<TrBackupLog> logs = await db.TrBackupLogs
                    .AsNoTracking()
                    .OrderByDescending(x => x.StartTime)
                    .Take(150)
                    .ToListAsync();

                gc_Logs.DataSource = logs;
                gv_Logs.BestFitColumns();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Jurnal yüklənərkən xəta: {ex.Message}");
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateServiceStatusDisplay();
        }

        private void UpdateServiceStatusDisplay()
        {
            BackupWorkerStatus status = BackupWorkerManager.GetStatus();
            string text = status switch
            {
                BackupWorkerStatus.RunningAsService => Resources.Form_BackupManager_StatusRunningService,
                BackupWorkerStatus.RunningAsProcess => Resources.Form_BackupManager_StatusRunningProcess,
                BackupWorkerStatus.Stopped => Resources.Form_BackupManager_StatusStopped,
                BackupWorkerStatus.NotInstalled => Resources.Form_BackupManager_StatusNotInstalled,
                _ => status.ToString()
            };

            bSI_ServiceStatus.Caption = $"{Resources.Form_BackupManager_ServiceStatus}: {text}";
        }

        private DcBackupJob? GetFocusedJob()
        {
            return gv_Jobs.GetFocusedRow() as DcBackupJob;
        }

        private async void bBI_NewJob_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormBackupJobEdit form = new(0);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await RefreshDataAsync();
            }
        }

        private async void bBI_EditJob_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcBackupJob? selected = GetFocusedJob();
            if (selected == null)
                return;

            using FormBackupJobEdit form = new(selected.BackupJobId);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await RefreshDataAsync();
            }
        }

        private async void bBI_DeleteJob_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcBackupJob? selected = GetFocusedJob();
            if (selected == null)
                return;

            DialogResult dr = XtraMessageBox.Show(
                Resources.Form_BackupManager_ConfirmDelete,
                Resources.Form_BackupManager_DeleteJob,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            try
            {
                await using subContext db = new();
                DcBackupJob? job = await db.DcBackupJobs.FirstOrDefaultAsync(x => x.BackupJobId == selected.BackupJobId);
                if (job != null)
                {
                    db.DcBackupJobs.Remove(job);
                    await db.SaveChangesAsync();
                }

                await RefreshDataAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bBI_RunNow_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcBackupJob? selected = GetFocusedJob();
            if (selected == null)
                return;

            int jobId = selected.BackupJobId;
            string conn = Properties.Settings.Default.SubConnString;

            XtraMessageBox.Show(
                Resources.Form_BackupManager_RunStarted,
                Resources.Form_BackupManager_RunNow,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _ = Task.Run(async () =>
            {
                try
                {
                    await using subContext db = new();
                    var setting = await db.AppSettings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 1);
                    string? rarPath = setting?.RarExePath;

                    await BackupExecutionEngine.ExecuteJobAsync(jobId, conn, rarPath);

                    if (!IsDisposed && IsHandleCreated)
                    {
                        Invoke(async () => await RefreshDataAsync());
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"RunNow xətası: {ex.Message}");
                }
            });
        }

        private async void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            await RefreshDataAsync();
        }

        private void bBI_StartService_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool started = BackupWorkerManager.Start();
            UpdateServiceStatusDisplay();
        }

        private void bBI_StopService_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool stopped = BackupWorkerManager.Stop();
            UpdateServiceStatusDisplay();
        }

        private void bBI_InstallService_ItemClick(object sender, ItemClickEventArgs e)
        {
            (bool ok, string output) = BackupWorkerManager.InstallService();
            XtraMessageBox.Show(
                output,
                Resources.Form_BackupManager_InstallService,
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            UpdateServiceStatusDisplay();
        }

        private void bBI_UninstallService_ItemClick(object sender, ItemClickEventArgs e)
        {
            (bool ok, string output) = BackupWorkerManager.UninstallService();
            XtraMessageBox.Show(
                output,
                Resources.Form_BackupManager_UninstallService,
                MessageBoxButtons.OK,
                ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            UpdateServiceStatusDisplay();
        }

        private void gv_Jobs_DoubleClick(object sender, EventArgs e)
        {
            bBI_EditJob_ItemClick(sender, null!);
        }
    }
}
