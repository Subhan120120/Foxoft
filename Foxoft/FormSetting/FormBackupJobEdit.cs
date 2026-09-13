using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode.Service.Backup;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormBackupJobEdit : XtraForm
    {
        private readonly int _backupJobId;
        private DcBackupJob? _job;

        public FormBackupJobEdit(int backupJobId)
        {
            InitializeComponent();
            _backupJobId = backupJobId;
            DesignComponentNames();
        }

        private void DesignComponentNames()
        {
            Text = Resources.Form_BackupJobEdit_Title;

            layoutControlGroupGeneral.Text = Resources.Form_BackupJobEdit_GeneralGroup;
            layoutControlGroupDatabases.Text = Resources.Form_BackupJobEdit_DatabasesGroup;
            layoutControlGroupStrategy.Text = Resources.Form_BackupJobEdit_StrategyGroup;
            layoutControlGroupStorage.Text = Resources.Form_BackupJobEdit_StorageGroup;
            layoutControlGroupSchedule.Text = Resources.Form_BackupJobEdit_ScheduleGroup;
            layoutControlGroupRetention.Text = Resources.Form_BackupJobEdit_RetentionGroup;

            layoutControlItemJobName.Text = Resources.Entity_DcBackupJob_JobName + ":";
            chkIsEnabled.Properties.Caption = Resources.Entity_DcBackupJob_IsEnabled;

            chkAllDatabases.Properties.Caption = Resources.Form_BackupJobEdit_AllDatabases;
            layoutControlItemDatabases.Text = Resources.Entity_DcBackupJob_DatabaseNames + ":";
            btnRefreshDatabases.Text = Resources.Form_BackupManager_Refresh;

            layoutControlItemBackupType.Text = Resources.Entity_DcBackupJob_BackupType + ":";
            layoutControlItemCompression.Text = Resources.Entity_DcBackupJob_CompressionType + ":";

            layoutControlItemLocalPath.Text = Resources.Entity_DcBackupJob_LocalPath + ":";
            chkUploadToCloud.Properties.Caption = Resources.Entity_DcBackupJob_UploadToCloud;
            layoutControlItemCloudFolder.Text = Resources.Entity_DcBackupJob_CloudFolderId + ":";
            btnTestCloud.Text = Resources.Form_BackupJobEdit_TestCloud;

            layoutControlItemScheduleType.Text = Resources.Entity_DcBackupJob_ScheduleType + ":";
            layoutControlItemInterval.Text = Resources.Entity_DcBackupJob_IntervalMinutes + ":";
            layoutControlItemStartTime.Text = Resources.Entity_DcBackupJob_StartTime + ":";
            layoutControlItemEndTime.Text = Resources.Entity_DcBackupJob_EndTime + ":";
            layoutControlItemDailyTime.Text = Resources.Entity_DcBackupJob_DailyTime + ":";
            layoutControlItemDaysOfWeek.Text = Resources.Entity_DcBackupJob_SelectedDaysOfWeek + ":";

            layoutControlItemRetention.Text = Resources.Entity_DcBackupJob_RetentionDays + ":";

            btnSave.Text = Resources.Common_Save;
            btnCancel.Text = Resources.Common_Cancel;
        }

        private async void FormBackupJobEdit_Load(object sender, EventArgs e)
        {
            InitializeDropdowns();
            await LoadDatabasesAsync();

            if (_backupJobId > 0)
            {
                await LoadJobDataAsync();
            }
            else
            {
                SetDefaultValues();
            }

            UpdateControlStates();
        }

        private void InitializeDropdowns()
        {
            // Backup types
            cmbBackupType.Properties.Items.Clear();
            cmbBackupType.Properties.Items.Add(new ImageComboBoxItem(Resources.Form_BackupJobEdit_Full, (byte)BackupType.Full));
            cmbBackupType.Properties.Items.Add(new ImageComboBoxItem(Resources.Form_BackupJobEdit_Diff, (byte)BackupType.Differential));
            cmbBackupType.SelectedIndex = 0;

            // Compression types
            cmbCompression.Properties.Items.Clear();
            cmbCompression.Properties.Items.Add(new ImageComboBoxItem(".zip", (byte)BackupCompressionType.Zip));
            cmbCompression.Properties.Items.Add(new ImageComboBoxItem(".rar", (byte)BackupCompressionType.Rar));
            cmbCompression.Properties.Items.Add(new ImageComboBoxItem(Resources.Form_BackupJobEdit_NoCompression, (byte)BackupCompressionType.None));
            cmbCompression.SelectedIndex = 0;

            // Schedule types
            cmbScheduleType.Properties.Items.Clear();
            cmbScheduleType.Properties.Items.Add(new ImageComboBoxItem(Resources.Form_BackupJobEdit_ScheduleInterval, (byte)BackupScheduleType.IntervalMinutes));
            cmbScheduleType.Properties.Items.Add(new ImageComboBoxItem(Resources.Form_BackupJobEdit_ScheduleDaily, (byte)BackupScheduleType.DailyAtTime));
            cmbScheduleType.SelectedIndex = 0;

            // Days of week
            cboDaysOfWeek.Properties.Items.Clear();
            cboDaysOfWeek.Properties.Items.Add(1, Resources.Form_BackupJobEdit_DaysMonday, CheckState.Checked, true);
            cboDaysOfWeek.Properties.Items.Add(2, Resources.Form_BackupJobEdit_DaysTuesday, CheckState.Checked, true);
            cboDaysOfWeek.Properties.Items.Add(3, Resources.Form_BackupJobEdit_DaysWednesday, CheckState.Checked, true);
            cboDaysOfWeek.Properties.Items.Add(4, Resources.Form_BackupJobEdit_DaysThursday, CheckState.Checked, true);
            cboDaysOfWeek.Properties.Items.Add(5, Resources.Form_BackupJobEdit_DaysFriday, CheckState.Checked, true);
            cboDaysOfWeek.Properties.Items.Add(6, Resources.Form_BackupJobEdit_DaysSaturday, CheckState.Checked, true);
            cboDaysOfWeek.Properties.Items.Add(7, Resources.Form_BackupJobEdit_DaysSunday, CheckState.Checked, true);
        }

        private async Task LoadDatabasesAsync()
        {
            try
            {
                string conn = Properties.Settings.Default.SubConnString;
                List<string> databases = await BackupDatabaseScanner.GetOnlineDatabasesAsync(conn, false);

                cboDatabases.Properties.Items.Clear();
                foreach (string db in databases)
                {
                    cboDatabases.Properties.Items.Add(db, CheckState.Unchecked, true);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Bazaları skan edərkən xəta: {ex.Message}");
            }
        }

        private void SetDefaultValues()
        {
            txtJobName.Text = "Baza Nüsxələnməsi";
            chkIsEnabled.Checked = true;
            chkAllDatabases.Checked = true;
            cboDatabases.Enabled = false;
            cmbBackupType.SelectedIndex = 0;
            cmbCompression.SelectedIndex = 0;

            string defaultBackupDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", "Backups");
            txtLocalPath.Text = defaultBackupDir;

            chkUploadToCloud.Checked = false;
            txtCloudFolder.Text = "FoxoftBackups";
            spinRetentionDays.Value = 7;
            cmbScheduleType.SelectedIndex = 0;
            spinIntervalMinutes.Value = 60;
            timeStartTime.Time = new DateTime(2026, 1, 1, 9, 0, 0);
            timeEndTime.Time = new DateTime(2026, 1, 1, 18, 0, 0);
            timeDaily.Time = new DateTime(2026, 1, 1, 23, 0, 0);
            SetAllDaysChecked();
        }

        private async Task LoadJobDataAsync()
        {
            await using subContext db = new();
            _job = await db.DcBackupJobs.FirstOrDefaultAsync(x => x.BackupJobId == _backupJobId);
            if (_job == null)
            {
                XtraMessageBox.Show("Tapşırıq tapılmadı.", Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            txtJobName.Text = _job.JobName;
            chkIsEnabled.Checked = _job.IsEnabled;

            bool isAll = string.IsNullOrWhiteSpace(_job.DatabaseNames) || _job.DatabaseNames == "*";
            chkAllDatabases.Checked = isAll;
            if (!isAll)
            {
                SetSelectedDatabases(_job.DatabaseNames);
            }

            cmbBackupType.SelectedIndex = _job.BackupType == BackupType.Differential ? 1 : 0;
            cmbCompression.SelectedIndex = _job.CompressionType switch
            {
                BackupCompressionType.Zip => 0,
                BackupCompressionType.Rar => 1,
                _ => 2
            };

            txtLocalPath.Text = _job.LocalPath;
            chkUploadToCloud.Checked = _job.UploadToCloud;
            txtCloudFolder.Text = _job.CloudFolderId ?? "FoxoftBackups";
            spinRetentionDays.Value = _job.RetentionDays;

            cmbScheduleType.SelectedIndex = _job.ScheduleType == BackupScheduleType.DailyAtTime ? 1 : 0;
            spinIntervalMinutes.Value = Math.Max(1, _job.IntervalMinutes);
            timeStartTime.Time = DateTime.Today.Add(_job.StartTime);
            timeEndTime.Time = DateTime.Today.Add(_job.EndTime);
            timeDaily.Time = DateTime.Today.Add(_job.DailyTime);

            SetDaysOfWeekSelection(_job.SelectedDaysOfWeek);
        }

        private void SetSelectedDatabases(string dbNames)
        {
            if (string.IsNullOrWhiteSpace(dbNames) || dbNames == "*")
            {
                cboDatabases.EditValue = null;
                return;
            }

            var selected = new HashSet<string>(
                dbNames.Split(new[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()),
                StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < cboDatabases.Properties.Items.Count; i++)
            {
                var item = cboDatabases.Properties.Items[i];
                item.CheckState = selected.Contains(item.Value?.ToString() ?? string.Empty)
                    ? CheckState.Checked
                    : CheckState.Unchecked;
            }

            cboDatabases.SetEditValue(string.Join(", ", selected));
        }

        private string GetSelectedDatabases()
        {
            if (chkAllDatabases.Checked)
                return "*";

            var values = cboDatabases.Properties.Items.GetCheckedValues();
            if (values != null && values.Count > 0)
            {
                return string.Join(",", values.Select(v => v?.ToString()?.Trim()).Where(s => !string.IsNullOrEmpty(s)));
            }

            if (cboDatabases.EditValue is string text && !string.IsNullOrWhiteSpace(text))
            {
                var parts = text.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrEmpty(s));
                return string.Join(",", parts);
            }

            List<string> selected = new();
            for (int i = 0; i < cboDatabases.Properties.Items.Count; i++)
            {
                var item = cboDatabases.Properties.Items[i];
                if (item.CheckState == CheckState.Checked && item.Value != null)
                {
                    selected.Add(item.Value.ToString()!);
                }
            }

            return selected.Count > 0 ? string.Join(",", selected) : "*";
        }

        private void SetDaysOfWeekSelection(string? days)
        {
            if (string.IsNullOrWhiteSpace(days))
            {
                SetAllDaysChecked();
                return;
            }

            var set = new HashSet<string>(days.Split(new[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()));
            for (int i = 0; i < cboDaysOfWeek.Properties.Items.Count; i++)
            {
                var item = cboDaysOfWeek.Properties.Items[i];
                item.CheckState = set.Contains(item.Value?.ToString() ?? string.Empty)
                    ? CheckState.Checked
                    : CheckState.Unchecked;
            }

            cboDaysOfWeek.SetEditValue(string.Join(", ", set));
        }

        private void SetAllDaysChecked()
        {
            List<object> allDays = new();
            for (int i = 0; i < cboDaysOfWeek.Properties.Items.Count; i++)
            {
                cboDaysOfWeek.Properties.Items[i].CheckState = CheckState.Checked;
                if (cboDaysOfWeek.Properties.Items[i].Value != null)
                    allDays.Add(cboDaysOfWeek.Properties.Items[i].Value);
            }
            cboDaysOfWeek.SetEditValue(string.Join(", ", allDays));
        }

        private string GetSelectedDaysOfWeek()
        {
            var values = cboDaysOfWeek.Properties.Items.GetCheckedValues();
            if (values != null && values.Count > 0)
            {
                return string.Join(",", values.Select(v => v?.ToString()?.Trim()).Where(s => !string.IsNullOrEmpty(s)));
            }

            if (cboDaysOfWeek.EditValue is string text && !string.IsNullOrWhiteSpace(text))
            {
                var parts = text.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => !string.IsNullOrEmpty(s));
                return string.Join(",", parts);
            }

            List<string> selected = new();
            for (int i = 0; i < cboDaysOfWeek.Properties.Items.Count; i++)
            {
                var item = cboDaysOfWeek.Properties.Items[i];
                if (item.CheckState == CheckState.Checked && item.Value != null)
                {
                    selected.Add(item.Value.ToString()!);
                }
            }

            return selected.Count > 0 ? string.Join(",", selected) : "1,2,3,4,5,6,7";
        }

        private void UpdateControlStates()
        {
            cboDatabases.Enabled = !chkAllDatabases.Checked;
            txtCloudFolder.Enabled = chkUploadToCloud.Checked;
            btnTestCloud.Enabled = chkUploadToCloud.Checked;

            bool isInterval = cmbScheduleType.SelectedIndex == 0;
            spinIntervalMinutes.Enabled = isInterval;
            timeStartTime.Enabled = isInterval;
            timeEndTime.Enabled = isInterval;
            timeDaily.Enabled = !isInterval;
        }

        private void chkAllDatabases_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void chkUploadToCloud_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void cmbScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private async void btnRefreshDatabases_Click(object sender, EventArgs e)
        {
            string previousSelection = GetSelectedDatabases();
            await LoadDatabasesAsync();
            if (!chkAllDatabases.Checked)
            {
                SetSelectedDatabases(previousSelection);
            }
        }

        private void txtLocalPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using FolderBrowserDialog fbd = new();
            fbd.Description = Resources.Form_BackupJobEdit_BrowseFolder;
            if (!string.IsNullOrWhiteSpace(txtLocalPath.Text) && Directory.Exists(txtLocalPath.Text))
            {
                fbd.SelectedPath = txtLocalPath.Text;
            }

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtLocalPath.Text = fbd.SelectedPath;
            }
        }

        private async void btnTestCloud_Click(object sender, EventArgs e)
        {
            try
            {
                using GoogleDriveBackupService drive = new();
                (bool ok, string msg) = await drive.TestConnectionAsync();
                XtraMessageBox.Show(
                    msg,
                    Resources.Form_BackupJobEdit_TestCloud,
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string jobName = txtJobName.Text.Trim();
            if (string.IsNullOrWhiteSpace(jobName))
            {
                XtraMessageBox.Show("Tapşırıq adı daxil edilməlidir.", Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJobName.Focus();
                return;
            }

            string localPath = txtLocalPath.Text.Trim();
            if (string.IsNullOrWhiteSpace(localPath))
            {
                XtraMessageBox.Show("Yerli backup qovluğu seçilməlidir.", Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocalPath.Focus();
                return;
            }

            try
            {
                await using subContext db = new();
                DcBackupJob job;

                if (_backupJobId > 0)
                {
                    job = await db.DcBackupJobs.FirstOrDefaultAsync(x => x.BackupJobId == _backupJobId)
                        ?? throw new InvalidOperationException("Yenilənəcək tapşırıq tapılmadı.");
                }
                else
                {
                    job = new DcBackupJob
                    {
                        CreatedDate = DateTime.Now
                    };
                    db.DcBackupJobs.Add(job);
                }

                job.JobName = jobName;
                job.IsEnabled = chkIsEnabled.Checked;
                job.DatabaseNames = GetSelectedDatabases();

                job.BackupType = cmbBackupType.SelectedIndex == 1 ? BackupType.Differential : BackupType.Full;
                job.CompressionType = cmbCompression.SelectedIndex switch
                {
                    0 => BackupCompressionType.Zip,
                    1 => BackupCompressionType.Rar,
                    _ => BackupCompressionType.None
                };

                job.LocalPath = localPath;
                job.UploadToCloud = chkUploadToCloud.Checked;
                job.CloudFolderId = chkUploadToCloud.Checked ? txtCloudFolder.Text.Trim() : null;
                job.RetentionDays = (int)spinRetentionDays.Value;

                job.ScheduleType = cmbScheduleType.SelectedIndex == 1 ? BackupScheduleType.DailyAtTime : BackupScheduleType.IntervalMinutes;
                job.IntervalMinutes = (int)spinIntervalMinutes.Value;
                job.StartTime = timeStartTime.Time.TimeOfDay;
                job.EndTime = timeEndTime.Time.TimeOfDay;
                job.DailyTime = timeDaily.Time.TimeOfDay;
                job.SelectedDaysOfWeek = GetSelectedDaysOfWeek();

                job.ModifiedDate = DateTime.Now;
                job.NextRunTime = BackupScheduleEvaluator.CalculateNextRunTime(job, DateTime.Now);

                await db.SaveChangesAsync();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
