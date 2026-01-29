// File: Models/HrEnums.cs
namespace Foxoft.Models
{
    public enum OverpaymentMode : byte
    {
        AskEachTime = 0,
        AcceptExactAndReturnChange = 1,
        AcceptAllAsAdvance = 2
    }

}
