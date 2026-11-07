namespace Foxoft.Models
{
    /// <summary>
    /// Satıcı bonusunun hesablanma prinsipi.
    /// </summary>
    public enum BonusCalcMethod : byte
    {
        /// <summary>Satış məbləğindən faiz (10.000 × 2%). Faktura səviyyəsində hesablanır.</summary>
        SalesAmountPercent = 1,

        /// <summary>Ümumi mənfəətdən faiz (2.000 × 5%). Maya dəyəri TrInvoiceLine.ProductCost-dan götürülür.</summary>
        GrossProfitPercent = 2,

        /// <summary>Satılan məhsul sayına görə (100 ədəd × 1 AZN).</summary>
        PerUnitSold = 3,

        /// <summary>Satış planının yerinə yetirilməsinə görə (dövr üzrə).</summary>
        SalesTargetAchievement = 4,

        /// <summary>Müştəridən yığılan pula görə (8.000 × 2%).</summary>
        CollectionPercent = 5,

        /// <summary>Sabit bonus (dövr üzrə, məs. 300 AZN).</summary>
        FixedAmount = 6,

        /// <summary>Satış intervalına görə dəyişən faiz (1%, 2%, 3%...). Dövr üzrə hesablanır.</summary>
        TieredSalesPercent = 7
    }

    /// <summary>
    /// İnterval bonusunun hesablanma forması.
    /// </summary>
    public enum BonusTierMode : byte
    {
        /// <summary>Hər interval öz faizinə görə hesablanır.</summary>
        Progressive = 1,

        /// <summary>Çatılmış son intervalın faizi bütün məbləğə tətbiq edilir.</summary>
        Retroactive = 2
    }

    /// <summary>
    /// "Bonus nə zaman hesablanmalıdır?" parametri.
    /// </summary>
    public enum BonusTriggerType : byte
    {
        /// <summary>Faktura təsdiqlənəndə (Invoice based).</summary>
        OnInvoiceConfirm = 1,

        /// <summary>Müştəri ödəniş etdikdə (Collection based): bonus ödənilmiş hissəyə mütənasib açılır.</summary>
        OnCustomerPayment = 2,

        /// <summary>Manual qaydada (dövr üzrə hesablama formasından).</summary>
        Manual = 3
    }

    /// <summary>
    /// Dövr əsaslı metodlar (interval, hədəf, sabit) üçün aqreqasiya dövrü.
    /// </summary>
    public enum BonusPeriodType : byte
    {
        Monthly = 1,
        Quarterly = 2,
        Yearly = 3
    }

    /// <summary>
    /// Bonus jurnalı əməliyyat növü. Jurnal yalnız əlavə olunan (append-only) qeydlərdən ibarətdir.
    /// </summary>
    public enum BonusTxnType : byte
    {
        /// <summary>Qazanılan bonus (+).</summary>
        Earn = 1,

        /// <summary>Ləğv / qaytarma nəticəsində mənfi bonus (-).</summary>
        Reverse = 2,

        /// <summary>Manual düzəliş (+/-). Avtomatik yenidən hesablamada nəzərə alınmır.</summary>
        Adjust = 3
    }
}
