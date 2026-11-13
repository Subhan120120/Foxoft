// File: Models/HrEnums.cs
namespace Foxoft.Models
{
    public enum Gender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    public enum MaritalStatus : byte
    {
        Unknown = 0,
        Single = 1,
        Married = 2,
        Divorced = 3,
        Widowed = 4
    }

    public enum LeaveStatus : byte
    {
        Draft = 0,
        Submitted = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4
    }

    public enum LeaveType : byte
    {
        Annual = 1,
        Sick = 2,
        Unpaid = 3,
        Maternity = 4,
        Other = 99
    }

    public enum PayrollItemType : byte
    {
        Salary = 1,
        Bonus = 2,
        Overtime = 3,
        Tax = 4,
        Insurance = 5,
        Deduction = 6,
        Other = 99
    }

    /// <summary>
    /// Əməkhaqqı sətrinin mənbəyi. SalesBonus sətirləri satıcı bonus jurnalından (TrSalesBonusTxns) avtomatik formalaşır.
    /// </summary>
    public enum PayrollLineSource : byte
    {
        Manual = 0,
        Contract = 1,
        SalesBonus = 2
    }

    public enum WorkScheduleType : byte
    {
        Standard5Days = 1,
        Standard6Days = 2,
        ShiftBased = 3,
        Custom = 4
    }

    public enum AttendanceMethod : byte
    {
        Device = 1,
        Manual = 2,
        Both = 3
    }

    public enum LateCalculationMethod : byte
    {
        Actual = 1,
        AfterGrace = 2
    }

    public enum LateRoundingMethod : byte
    {
        None = 0,
        Round5 = 5,
        Round10 = 10,
        Round15 = 15
    }

    public enum OvertimePolicy : byte
    {
        Auto = 1,
        PreApproved = 2
    }

    public enum AttendanceStatus : byte
    {
        Present = 1,
        Late = 2,
        EarlyExit = 3,
        AbsentExcused = 4,
        AbsentUnexcused = 5,
        RestDay = 6,
        Holiday = 7,
        BusinessTrip = 8,
        SickLeave = 9
    }

    public enum PunchType : byte
    {
        AutoDetect = 0,
        CheckIn = 1,
        CheckOut = 2,
        BreakStart = 3,
        BreakEnd = 4
    }

    public enum PunchSourceMethod : byte
    {
        Biometric = 1,
        RfidCard = 2,
        MobileWeb = 3,
        Manual = 4
    }
}
