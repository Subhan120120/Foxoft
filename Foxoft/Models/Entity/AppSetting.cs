﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class AppSetting
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Cədvəl Dizaynı")]
        public string? GridViewLayout { get; set; }

        [Display(Name = "Çap Edilsin")]
        public bool GetPrint { get; set; }

        [Display(Name = "Printer Adı")]
        public string? PrinterName { get; set; }

        [Display(Name = "Çap sayı")]
        public int PrinterCopyNum { get; set; }

        [Display(Name = "Print Dizayn Yolu")]
        public string? PrintDesignPath { get; set; }

        [Display(Name = "Yerli Valyuta Kodu")]
        public string? LocalCurrencyCode { get; set; }

        [Display(Name = "Whatsapp Chrome Profil Adı")]
        public string? WhatsappChromeProfileName { get; set; }

        [Display(Name = "Twilio Token")]
        public string? TwilioToken { get; set; }

        [Display(Name = "Lisenziya")]
        public string? License { get; set; }

        [Display(Name = "Son Tarix")]
        public string? DueDate { get; set; }  // lazimsiz prop, silinecek

        [DefaultValue("0")]
        [Display(Name = "Qiymət Cədvəli İstifadə Et")]
        public bool UsePriceList { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Avtomatik Yadda Saxla")]
        public bool AutoSave { get; set; }

        [Display(Name = "Faktura Redaktə Üçün Möhlət Günləri")]
        public int? InvoiceEditGraceDays { get; set; }

        [Display(Name = "Ödəniş Redaktə Üçün Möhlət Günləri")]
        public int? PaymentEditGraceDays { get; set; }

        [Display(Name = "Çap sayı")]
        [ForeignKey("DcUnitOfMeasure")]
        public int DefaultUnitOfMeasureId { get; set; }

        [Display(Name = "Tərəzi İstifadə Et")]
        public bool UseScales { get; set; }

        [Display(Name = "Barkod İstifadə Et")]
        public bool UseBarcode { get; set; }


        [ForeignKey("LocalCurrencyCode")]
        public virtual DcCurrency DcCurrency { get; set; }

        [ForeignKey("DefaultUnitOfMeasureId")]
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }


    }
}
