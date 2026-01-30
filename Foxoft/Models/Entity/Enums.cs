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
        Redeem = 2,   // bonus xərcləndi (-)
        Reverse = 3,  // geri çevirmə (qazanılanı silmək və ya xərclənəni qaytarmaq)
        Adjust = 4,   // manual düzəliş (+/-)
        Expire = 5    // müddəti bitdi (-)
    }

    public enum PaymentType : byte
    {
        Cash = 1,        // Nağd
        Cashless = 2,    // Nağdsız
        Bonus = 3,       // Bonus
        Commission = 4   // Komissiya
    }

}
