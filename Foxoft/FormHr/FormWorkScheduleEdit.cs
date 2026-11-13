using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public class WorkScheduleDayVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DayOfWeek DayOfWeek { get; set; }
        public string DayName => DayOfWeek.ToString();
        public bool IsWorkDay { get; set; } = true;
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(18, 0, 0);
        public TimeSpan? BreakStartTime { get; set; } = new TimeSpan(13, 0, 0);
        public TimeSpan? BreakEndTime { get; set; } = new TimeSpan(14, 0, 0);
        public int BreakDurationMinutes { get; set; } = 60;
        public int PlannedWorkMinutes { get; set; } = 480;
    }

    public partial class FormWorkScheduleEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcWorkSchedule entity;
        private BindingList<WorkScheduleDayVM> daysList = new();

        public FormWorkScheduleEdit(Guid? scheduleId)
        {
            InitializeComponent();
            id = scheduleId;

            Text = id == null ? Properties.Resources.Form_WorkSchedule_Caption_New : Properties.Resources.Form_WorkSchedule_Caption_Edit;

            InitDropdowns();
            LoadEntity();

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => Close();
        }

        private void InitDropdowns()
        {
            cmbScheduleType.Properties.Items.Clear();
            foreach (WorkScheduleType t in Enum.GetValues(typeof(WorkScheduleType)))
                cmbScheduleType.Properties.Items.Add(t);
        }

        private void LoadEntity()
        {
            if (id == null)
            {
                entity = new DcWorkSchedule
                {
                    Id = Guid.NewGuid(),
                    ScheduleCode = "WS-" + DateTime.Now.ToString("yyMMddHHmm"),
                    ScheduleName = "Yeni İş Qrafiki",
                    ScheduleType = WorkScheduleType.Standard5Days,
                    WeeklyHours = 40.00m,
                    IsActive = true
                };

                var days = new List<WorkScheduleDayVM>();
                var allDays = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
                foreach (var d in allDays)
                {
                    bool isWork = d != DayOfWeek.Saturday && d != DayOfWeek.Sunday;
                    days.Add(new WorkScheduleDayVM
                    {
                        DayOfWeek = d,
                        IsWorkDay = isWork,
                        StartTime = isWork ? new TimeSpan(9, 0, 0) : TimeSpan.Zero,
                        EndTime = isWork ? new TimeSpan(18, 0, 0) : TimeSpan.Zero,
                        BreakDurationMinutes = isWork ? 60 : 0,
                        PlannedWorkMinutes = isWork ? 480 : 0
                    });
                }
                daysList = new BindingList<WorkScheduleDayVM>(days);
            }
            else
            {
                entity = db.DcWorkSchedules.Include(x => x.Days).First(x => x.Id == id.Value);

                var days = entity.Days.OrderBy(d => ((int)d.DayOfWeek + 6) % 7).Select(d => new WorkScheduleDayVM
                {
                    Id = d.Id,
                    DayOfWeek = d.DayOfWeek,
                    IsWorkDay = d.IsWorkDay,
                    StartTime = d.StartTime,
                    EndTime = d.EndTime,
                    BreakStartTime = d.BreakStartTime,
                    BreakEndTime = d.BreakEndTime,
                    BreakDurationMinutes = d.BreakDurationMinutes,
                    PlannedWorkMinutes = d.PlannedWorkMinutes
                }).ToList();

                daysList = new BindingList<WorkScheduleDayVM>(days);
            }

            txtScheduleCode.Text = entity.ScheduleCode;
            txtScheduleName.Text = entity.ScheduleName;
            cmbScheduleType.SelectedItem = entity.ScheduleType;
            spWeeklyHours.Value = entity.WeeklyHours;
            chkIsActive.Checked = entity.IsActive;
            txtDescription.Text = entity.Description;

            gridControlDays.DataSource = daysList;

            if (gridViewDays.Columns["Id"] != null) gridViewDays.Columns["Id"].Visible = false;
            if (gridViewDays.Columns["DayOfWeek"] != null) gridViewDays.Columns["DayOfWeek"].Visible = false;
            if (gridViewDays.Columns["DayName"] != null)
            {
                gridViewDays.Columns["DayName"].Caption = "Gün";
                gridViewDays.Columns["DayName"].OptionsColumn.AllowEdit = false;
            }
            if (gridViewDays.Columns["IsWorkDay"] != null) gridViewDays.Columns["IsWorkDay"].Caption = "İş Günüdür";
            if (gridViewDays.Columns["StartTime"] != null) gridViewDays.Columns["StartTime"].Caption = "Giriş Saatı";
            if (gridViewDays.Columns["EndTime"] != null) gridViewDays.Columns["EndTime"].Caption = "Çıxış Saatı";
            if (gridViewDays.Columns["BreakDurationMinutes"] != null) gridViewDays.Columns["BreakDurationMinutes"].Caption = "Fasilə (dəq)";
            if (gridViewDays.Columns["PlannedWorkMinutes"] != null) gridViewDays.Columns["PlannedWorkMinutes"].Caption = "Planlaşdırılan İş (dəq)";

            gridViewDays.BestFitColumns();
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(txtScheduleCode.Text) || string.IsNullOrWhiteSpace(txtScheduleName.Text))
            {
                XtraMessageBox.Show(this, "Qrafik kodu və adı mütləq doldurulmalıdır.", Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.ScheduleCode = txtScheduleCode.Text.Trim();
            entity.ScheduleName = txtScheduleName.Text.Trim();
            entity.ScheduleType = cmbScheduleType.SelectedItem is WorkScheduleType st ? st : WorkScheduleType.Standard5Days;
            entity.WeeklyHours = spWeeklyHours.Value;
            entity.IsActive = chkIsActive.Checked;
            entity.Description = txtDescription.Text;

            // Günləri yenilə
            foreach (var vm in daysList)
            {
                var existingDay = entity.Days.FirstOrDefault(d => d.DayOfWeek == vm.DayOfWeek);
                if (existingDay == null)
                {
                    existingDay = new DcWorkScheduleDay
                    {
                        Id = Guid.NewGuid(),
                        WorkScheduleId = entity.Id,
                        DayOfWeek = vm.DayOfWeek
                    };
                    entity.Days.Add(existingDay);
                }

                existingDay.IsWorkDay = vm.IsWorkDay;
                existingDay.StartTime = vm.StartTime;
                existingDay.EndTime = vm.EndTime;
                existingDay.BreakStartTime = vm.BreakStartTime;
                existingDay.BreakEndTime = vm.BreakEndTime;
                existingDay.BreakDurationMinutes = vm.BreakDurationMinutes;

                if (vm.IsWorkDay)
                {
                    int totalMinutes = (int)(vm.EndTime - vm.StartTime).TotalMinutes;
                    existingDay.PlannedWorkMinutes = Math.Max(0, totalMinutes - vm.BreakDurationMinutes);
                }
                else
                {
                    existingDay.PlannedWorkMinutes = 0;
                }
            }

            if (id == null)
                db.DcWorkSchedules.Add(entity);

            db.SaveChanges();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
