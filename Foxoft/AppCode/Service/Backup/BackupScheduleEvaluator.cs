using System;
using System.Collections.Generic;
using System.Linq;
using Foxoft.Models;

namespace Foxoft.AppCode.Service.Backup
{
    public static class BackupScheduleEvaluator
    {
        public static bool IsDaySelected(string? selectedDaysOfWeek, DayOfWeek dayOfWeek)
        {
            if (string.IsNullOrWhiteSpace(selectedDaysOfWeek))
                return true;

            int isoDay = dayOfWeek == DayOfWeek.Sunday ? 7 : (int)dayOfWeek;
            var days = selectedDaysOfWeek.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(s => s.Trim());

            return days.Contains(isoDay.ToString());
        }

        /// <summary>
        /// Determines whether the job is due for execution at the given reference time.
        /// </summary>
        public static bool IsJobDue(DcBackupJob job, DateTime now)
        {
            if (!job.IsEnabled)
                return false;

            if (!IsDaySelected(job.SelectedDaysOfWeek, now.DayOfWeek))
                return false;

            if (job.ScheduleType == BackupScheduleType.DailyAtTime)
            {
                if (now.TimeOfDay < job.DailyTime)
                    return false;

                // If already ran today at or after the scheduled daily time
                if (job.LastRunTime.HasValue && job.LastRunTime.Value.Date == now.Date && job.LastRunTime.Value.TimeOfDay >= job.DailyTime)
                    return false;

                return true;
            }
            else if (job.ScheduleType == BackupScheduleType.IntervalMinutes)
            {
                TimeSpan currentTime = now.TimeOfDay;

                if (currentTime < job.StartTime || currentTime > job.EndTime)
                    return false;

                int intervalMinutes = Math.Max(1, job.IntervalMinutes);

                if (!job.LastRunTime.HasValue)
                    return true;

                TimeSpan elapsed = now - job.LastRunTime.Value;
                return elapsed.TotalMinutes >= intervalMinutes;
            }

            return false;
        }

        /// <summary>
        /// Calculates the next estimated run time for display in the UI and scheduler.
        /// </summary>
        public static DateTime? CalculateNextRunTime(DcBackupJob job, DateTime now)
        {
            if (!job.IsEnabled)
                return null;

            int intervalMinutes = Math.Max(1, job.IntervalMinutes);

            for (int dayOffset = 0; dayOffset < 8; dayOffset++)
            {
                DateTime candidateDate = now.Date.AddDays(dayOffset);
                if (!IsDaySelected(job.SelectedDaysOfWeek, candidateDate.DayOfWeek))
                    continue;

                if (job.ScheduleType == BackupScheduleType.DailyAtTime)
                {
                    DateTime runCandidate = candidateDate.Add(job.DailyTime);
                    if (runCandidate > now)
                    {
                        return runCandidate;
                    }
                }
                else if (job.ScheduleType == BackupScheduleType.IntervalMinutes)
                {
                    DateTime windowStart = candidateDate.Add(job.StartTime);
                    DateTime windowEnd = candidateDate.Add(job.EndTime);

                    if (dayOffset == 0)
                    {
                        if (now < windowStart)
                            return windowStart;

                        if (now <= windowEnd)
                        {
                            DateTime nextInterval = job.LastRunTime.HasValue
                                ? job.LastRunTime.Value.AddMinutes(intervalMinutes)
                                : now;

                            if (nextInterval < now)
                                nextInterval = now;

                            if (nextInterval <= windowEnd)
                                return nextInterval;
                        }
                    }
                    else
                    {
                        return windowStart;
                    }
                }
            }

            return null;
        }
    }
}
