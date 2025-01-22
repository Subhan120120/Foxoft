using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Keyless]
    public class TrInstallmentViewModel
    {
        [Display(Name = "Kredit ID")]
        public int InstallmentId { get; set; }

        [Display(Name = "Faktura Başlıq ID")]
        public Guid InvoiceHeaderId { get; set; }

        [Display(Name = "Cari Hesab")]
        public string? CurrAccCode { get; set; }

        [Display(Name = "Sənəd Tarixi")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Ödəniş Planı Kodu")]
        public string PaymentPlanCode { get; set; }

        [Display(Name = "Məbləğ")]
        public decimal Amount { get; set; }

        [Display(Name = "Məbləğ (YPV)")]
        public decimal AmountLoc { get; set; }

        [Display(Name = "Komissiya")]
        public decimal Commission { get; set; }

        [Display(Name = "Valyuta Kodu")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Məzənnə")]
        public float ExchangeRate { get; set; }

        [Display(Name = "Ödənişlərin Cəmi")]
        public decimal TotalPaid { get; set; }

        [Display(Name = "Qalan Balans")]
        public decimal RemainingBalance { get; set; }

        [Display(Name = "Aylıq Ödəniş")]
        public decimal MonthlyPayment { get; set; }

        [Display(Name = "Ödənilməli")]
        public decimal DueAmount { get; set; }

        [Display(Name = "Gecikən Günlər")]
        public int OverdueDays { get; set; }

        [Display(Name = "Gecikmə Tarixi")]
        public DateTime? OverdueDate { get; set; } // İlk gecikmə tarixi olaraq "OverdueDate" istifadə edildi
    }

}
