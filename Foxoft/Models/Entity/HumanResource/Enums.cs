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
}
