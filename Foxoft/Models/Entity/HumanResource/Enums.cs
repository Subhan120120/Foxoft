// File: Models/HumanResource/Enums.cs
using System;

namespace Foxoft.Models.Entity.HumanResource
{
    public enum HrGender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    public enum HrMaritalStatus : byte
    {
        Unknown = 0,
        Single = 1,
        Married = 2,
        Divorced = 3,
        Widowed = 4
    }

    public enum HrLeaveStatus : byte
    {
        Draft = 0,
        Submitted = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4
    }

    public enum HrPayrollItemType : byte
    {
        Salary = 1,
        Bonus = 2,
        Allowance = 3,
        Overtime = 4,
        Tax = 5,
        Insurance = 6,
        Deduction = 7
    }
}
