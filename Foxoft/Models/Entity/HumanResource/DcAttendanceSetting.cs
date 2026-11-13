using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Table("DcAttendanceSettings")]
    public class DcAttendanceSetting
    {
        [Key]
        public int Id { get; set; } = 1;

        public bool AttendanceEnabled { get; set; } = true;

        public Guid? DefaultWorkScheduleId { get; set; }

        [ForeignKey(nameof(DefaultWorkScheduleId))]
        public virtual DcWorkSchedule? DefaultWorkSchedule { get; set; }

        public AttendanceMethod AttendanceMethod { get; set; } = AttendanceMethod.Both;

        public bool RequireApproval { get; set; } = false;

        public bool AllowManualEntry { get; set; } = true;

        public bool AllowAttendanceCorrection { get; set; } = true;

        public bool AutoCalculateAttendance { get; set; } = true;

        public bool AutoCloseDay { get; set; } = false;

        /// <summary>
        /// Anti-Double Punch (Debounce): Eyni cihazda X dəqiqə ərzində təkrar oxunan loglar nəzərə alınmır.
        /// </summary>
        public int DebounceMinutes { get; set; } = 2;

        /// <summary>
        /// Güzəşt müddəti (dəqiqə ilə)
        /// </summary>
        public int GracePeriodMinutes { get; set; } = 5;

        /// <summary>
        /// Gecikmə hesablama metodu: Actual (bütün gecikmə) və ya AfterGrace (toleransdan artıq olan hissə)
        /// </summary>
        public LateCalculationMethod LateCalculationMethod { get; set; } = LateCalculationMethod.Actual;

        /// <summary>
        /// Gecikmə yuvarlaqlaşdırması: None, 5, 10, 15 dəqiqə
        /// </summary>
        public LateRoundingMethod LateRoundingMethod { get; set; } = LateRoundingMethod.None;

        public bool AllowLateCorrection { get; set; } = true;

        public bool LateApprovalRequired { get; set; } = false;

        /// <summary>
        /// Erkən çıxış üçün güzəşt müddəti (dəqiqə ilə)
        /// </summary>
        public int EarlyExitGracePeriodMinutes { get; set; } = 5;

        /// <summary>
        /// Artıq iş (Overtime) siyasəti: Auto (avtomatik) və ya PreApproved (əvvəlcədən rəhbər tərəfindən təsdiqli)
        /// </summary>
        public OvertimePolicy OvertimePolicy { get; set; } = OvertimePolicy.Auto;

        /// <summary>
        /// Minimum artıq iş dəqiqəsi (bundan az olanlar artıq iş sayılmır)
        /// </summary>
        public int MinOvertimeMinutes { get; set; } = 15;

        /// <summary>
        /// Artıq işin yuvarlaqlaşdırılması (0, 15, 30 dəq)
        /// </summary>
        public int OvertimeRoundingMinutes { get; set; } = 0;

        /// <summary>
        /// Bildiriş parametrləri
        /// </summary>
        public bool NotifyHrOnLate { get; set; } = false;

        public bool NotifyManagerOnAbsence { get; set; } = false;

        public bool NotifyOnMissingCheckOut { get; set; } = false;
    }
}
