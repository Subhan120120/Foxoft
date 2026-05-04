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
    @("Campaign_DiscountDeleted", "Campaign discount removed.", "Kampaniya endirimi silindi."),
    @("Campaign_LogTitle", "Campaign Log", "Kampaniya Loqu"),
    @("Campaign_EnterPromoCode", "Enter Promo Code:", "Promo Kod Daxil Edin:"),
    @("Campaign_PromoCodeTitle", "Promo Code", "Promo Kod"),
    @("Payment_NoRemainingAmount", "No remaining amount to pay.", "Ödəniləcək məbləğ qalmayıb."),
    @("Payment_Title", "Payment", "Ödəniş"),
    @("Campaign_PasswordIncorrect", "Campaign password incorrect!", "Kampaniya şifrəsi yanlışdır!"),
    @("Campaign_CashOnlyAppliedDeleteWarning", "IsCashOnly campaign applied. Delete not allowed.", "IsCashOnly kampaniya tətbiq edilib. Silinməyə icazə verilmir."),
    @("Campaign_EnterPassword", "Enter campaign password:", "Kampaniya şifrəsini daxil edin:"),
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
    @("Report_NoPermission", "You do not have permission!", "Yetkiniz yoxdur!"),
    @("Product_CloneConfirmation", "Do you want to clone features of product code {0}?", "{0} kodlu məhsulun özəllikləri klonlansın?"),
    @("Salesperson_EnterCode", "Enter Salesman Code:", "Satıcı Kodu Daxil Edin:"),
    @("Salesperson_Title", "Salesperson", "Satıcı"),
    @("BonusCard_EnterNum", "Enter Bonus Card:", "Bonus Kart Daxil Edin:"),
    @("BonusCard_Title", "Bonus Card", "Bonus Kart"),
    @("Network_CannotConnect", "Cannot connect to {0}.", "{0} ilə əlaqə qurula bilmir."),
    @("ExcelExport_Filter", "Excel File|*.xlsx", "Excel Faylı|*.xlsx"),
    @("ExcelExport_SaveTitle", "Save Excel File", "Excel Faylı Yadda Saxla"),
    @("Preview_VAT", "VAT: ", "ƏDV: "),
    @("Preview_Barcode", "Barcode: ", "Barkod: "),
    @("Preview_PosDiscount", "Pos Discount: ", "Pos Endirimi: "),
    @("Preview_Salesperson", "Salesperson: ", "Satıcı: "),
    @("Common_Manage", "Manage", "İdarə Et"),
    @("Campaign_CannotDeleteInUse", "This campaign has already been used in invoices. Disable it instead of deleting.", "Bu kampaniya artıq fakturalarda istifadə olunub. Silmək əvəzinə deaktiv edin."),
    @("Campaign_ListTitle", "Campaigns", "Kampaniyalar"),
    @("Credit_Balance", "Balance: {0}", "Balans: {0}"),
    @("Credit_EnterApiKey", "Enter API Key to add credit:", "Kredit əlavə etmək üçün API Key daxil edin:"),
    @("Credit_AddTitle", "Add Credit", "Kredit Əlavə Et"),
    @("Credit_ApiKeyAlreadyUsed", "This API Key has already been used!", "Bu API Key artıq istifadə olunub!"),
    @("Credit_NoInternet", "No internet connection!", "İnternet bağlantısı yoxdur!"),
    @("Credit_ExcelLoadError", "Excel file could not be loaded!", "Excel faylı yüklənə bilmədi!"),
    @("Credit_ApiKeyInactive", "Entered API Key is not active!", "Daxil edilən API Key aktiv deyil!"),
    @("Credit_InvalidCreditValue", "Credit value for API Key is incorrect!", "API Key-ə aid kredit dəyəri düzgün deyil!"),
    @("Credit_PurchaseWithApiKey", "Credit purchase with API Key", "API Key ilə kredit alışı"),
    @("Credit_AddedSuccessfully", "{0} credit added successfully!", "{0} kredit uğurla əlavə edildi!"),
    @("Credit_AddError", "Error occurred while adding credit:", "Kredit əlavə edilərkən xəta baş verdi:"),
    @("Credit_ExportTitle", "Credit Transactions", "Kredit Əməliyyatları"),
    @("Credit_Purchase", "Purchase", "Satın alma"),
    @("Credit_Usage", "Usage", "Xərc")
)

$resBase = "C:\Users\Subhan\source\repos\Foxoft\Foxoft\Properties\Resources.resx"
$resAz = "C:\Users\Subhan\source\repos\Foxoft\Foxoft\Properties\Resources.az.resx"
$designer = "C:\Users\Subhan\source\repos\Foxoft\Foxoft\Properties\Resources.Designer.cs"

[xml]$xmlBase = Get-Content $resBase -Encoding UTF8
[xml]$xmlAz = Get-Content $resAz -Encoding UTF8

foreach ($item in $items) {
    $key = $item[0]
    $enVal = $item[1]
    $azVal = $item[2]

    # Base
    $node = $xmlBase.root.data | Where-Object { $_.name -eq $key }
    if ($node) { $node.value = $enVal } else {
        $newNode = $xmlBase.CreateElement("data"); $newNode.SetAttribute("name", $key); $newNode.SetAttribute("xml:space", "preserve")
        $valNode = $xmlBase.CreateElement("value"); $valNode.InnerText = $enVal; $newNode.AppendChild($valNode); $xmlBase.root.AppendChild($newNode)
    }

    # Az
    $node = $xmlAz.root.data | Where-Object { $_.name -eq $key }
    if ($node) { $node.value = $azVal } else {
        $newNode = $xmlAz.CreateElement("data"); $newNode.SetAttribute("name", $key); $newNode.SetAttribute("xml:space", "preserve")
        $valNode = $xmlAz.CreateElement("value"); $valNode.InnerText = $azVal; $newNode.AppendChild($valNode); $xmlAz.root.AppendChild($newNode)
    }
}
$xmlBase.Save($resBase)
$xmlAz.Save($resAz)

$designerContent = Get-Content $designer -Raw
foreach ($item in $items) {
    $key = $item[0]
    $enVal = $item[1]
    if ($designerContent -notmatch "public static string $key ") {
        $prop = @"
        
        /// <summary>
        ///   Looks up a localized string similar to $($enVal -replace '"', '""').
        /// </summary>
        public static string $key {
            get {
                return ResourceManager.GetString("$key", resourceCulture);
            }
        }
"@
        $pos = $designerContent.LastIndexOf("}")
        $pos2 = $designerContent.LastIndexOf("}", $pos - 1)
        $designerContent = $designerContent.Substring(0, $pos2) + $prop + "`r`n    }`r`n}`r`n"
    }
}
[System.IO.File]::WriteAllText($designer, $designerContent, [System.Text.Encoding]::UTF8)
