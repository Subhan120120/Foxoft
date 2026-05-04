$items = @(
    @("Common_Error", "Error", "Xəta"),
    @("Common_Info", "Information", "Məlumat"),
    @("Common_Attention", "Attention", "Diqqət"),
    @("Common_SavedSuccessfully", "Saved successfully.", "Uğurla yadda saxlanıldı."),
    @("Common_ErrorOccurred", "An error occurred.", "Xəta baş verdi."),
    @("Campaign_ExcelImportError", "Error occurred during Excel import.", "Excel import zamanı xəta baş verdi."),
    @("Campaign_ConfirmDelete", "Delete selected campaign?", "Seçilmiş kampaniya silinsin?"),
    @("Invoice_PaymentZeroReturn", "Payment is equal to 0! Do you want to return to the invoice?", "Ödəmə 0-a bərabərdir! Fakturaya qayıtmaq istəyirsiz?"),
    @("Invoice_NoValueFoundForCodes", "No value found for the following codes.", "Aşağıdakı kodlar üzrə dəyər tapılmadı."),
    @("Common_OpenConfirmation", "Do you want to open it?", "Açmaq istəyirsiz?"),
    @("Report_OnlyRepxAllowed", "You can only select .repx files.", "Yalnız .repx fayl seçə bilərsiniz."),
    @("BonusCard_Cancelled", "Bonus Card Cancelled!", "Bonus Kart Ləğv olundu!"),
    @("BonusCard_NotFound", "Bonus Card not found!", "Bonus Kartı tapılmadı!"),
    @("Campaign_NoProductInInvoice", "No product in invoice.", "Fakturada məhsul yoxdur."),
    @("Campaign_NoCampaignApplied", "No campaign applied.", "Heç bir kampaniya tətbiq edilməyib."),
    @("Campaign_DiscountRemoved", "Campaign discount removed.", "Kampaniya endirimi silindi."),
    @("Campaign_NoAmountToPay", "No amount left to pay.", "Ödəniləcək məbləğ qalmayıb."),
    @("Campaign_InvalidPassword", "Invalid password! Campaign not applied.", "Şifrə yanlışdır! Kampaniya tətbiq edilmədi."),
    @("Campaign_NotApplied", "Campaign not applied.", "Kampaniya tətbiq edilmədi."),
    @("Report_NotFound", "Report_Embedded_PaymentReport not found.", "Report_Embedded_PaymentReport tapılmadı."),
    @("Payment_ApiSettingsIncomplete", "API settings are incomplete. Please configure in AppSettings.", "API ayarları tam deyil. Lütfən AppSetting-dən tənzimləyin."),
    @("Product_CannotCloneSameProduct", "Cannot clone from the same product.", "Eyni məhsuldan klonlamaq olmaz."),
    @("Product_FeaturesClonedSuccessfully", "Features cloned successfully.", "Özəlliklər uğurla klonlandı."),
    @("Auth_StoreNotActive", "Store is not active.", "Mağaza Aktiv Deyil"),
    @("Auth_UserAlreadyLoggedIn", "User is already logged in.", "İstifadəçi artıq sistemə daxil olub."),
    @("Auth_InvalidUserOrPassword", "Invalid user or password", "İstifadəçi və ya şifrə yanlışdır"),
    @("Report_NoPermission", "You do not have permission!", "Yetkiniz yoxdur!")
)

foreach ($item in $items) {
    .\AddResource.ps1 -Key $item[0] -EnValue $item[1] -AzValue $item[2]
}
