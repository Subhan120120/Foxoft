// File: Models/HrEnums.cs
namespace Foxoft.Models
{
    public enum OverpaymentMode : byte
    {
        AskEachTime = 0,
        AcceptExactAndReturnChange = 1,
        AcceptAllAsAdvance = 2
    }

    public enum LoyaltyTxnType : byte
    {
        Earn = 1,     // bonus qazanıldı (+)
        Reverse = 2,  // qazanılanı silmək (-)
        Redeem = 3,   // bonus xərcləndi (-)
        Refund = 4,   // xərclənəni qaytarmaq (+)
        Adjust = 5,   // manual düzəliş (+/-)
        Expire = 6    // müddəti bitdi (-)
    }

    public enum PaymentType : byte
    {
        Cash = 1,        // Nağd
        Cashless = 2,    // Nağdsız
        Bonus = 3,       // Bonus
        Commission = 4   // Komissiya
    }

}
