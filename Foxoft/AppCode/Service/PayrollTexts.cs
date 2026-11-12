using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft.AppCode.Service
{
    /// <summary>Əməkhaqqı modulu üçün lokallaşdırılmış mətnlər.</summary>
    public static class PayrollTexts
    {
        public static string GetPayrollItemTypeName(PayrollItemType itemType) => itemType switch
        {
            PayrollItemType.Salary => Resources.Enum_PayrollItemType_Salary,
            PayrollItemType.Bonus => Resources.Enum_PayrollItemType_Bonus,
            PayrollItemType.Overtime => Resources.Enum_PayrollItemType_Overtime,
            PayrollItemType.Tax => Resources.Enum_PayrollItemType_Tax,
            PayrollItemType.Insurance => Resources.Enum_PayrollItemType_Insurance,
            PayrollItemType.Deduction => Resources.Enum_PayrollItemType_Deduction,
            PayrollItemType.Other => Resources.Enum_PayrollItemType_Other,
            _ => itemType.ToString()
        };
    }
}
