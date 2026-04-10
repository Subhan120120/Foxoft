using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    //public enum CampaignTypeCode
    //{
    //    Standard = 1,
    //    PromoCode = 2,
    //    CategoryDiscount = 3,
    //    PaymentMethodCampaign = 4
    //}

    public enum DiscountTypeCode
    {
        Percent = 1,
        Amount = 2
    }

    [Index(nameof(CampaignCode), IsUnique = true)]
    [Index(nameof(IsActive), nameof(StartDate), nameof(EndDate))]
    public partial class DcCampaign : BaseEntity
    {
        [Key]
        public Guid CampaignId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Kampaniya kodu")]
        public string CampaignCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Kampaniya adı")]
        public string CampaignDesc { get; set; }

        //[Required]
        //[StringLength(20)]
        //[DefaultValue(CampaignTypeCode.Standard)]
        //[Display(Name = "Kampaniya tipi")]
        //public CampaignTypeCode CampaignTypeCode { get; set; } = CampaignTypeCode.Standard;

        [StringLength(50)]
        [Display(Name = "Promo code")]
        public string? PromoCode { get; set; }

        [Required]
        [Display(Name = "Endirim tipi")]
        [DefaultValue(DiscountTypeCode.Percent)]
        public DiscountTypeCode DiscountTypeCode { get; set; } = DiscountTypeCode.Percent;

        [DefaultValueSql("0")]
        [Display(Name = "Endirim dəyəri")]
        public decimal DiscountValue { get; set; }

        [DefaultValueSql("0")]
        [Display(Name = "Prioritet")]
        public int Priority { get; set; }

        [DefaultValueSql("1")]
        [Display(Name = "Aktiv")]
        public bool IsActive { get; set; } = true;

        [DefaultValueSql("0")]
        [Display(Name = "Birləşə bilir")]
        public bool IsCombinable { get; set; }

        [Display(Name = "Başlama tarixi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitmə tarixi")]
        public DateTime EndDate { get; set; }

        [DefaultValueSql("0")]
        [Display(Name = "Min. faktura məbləği")]
        public decimal MinInvoiceAmount { get; set; }

        [DefaultValueSql("0")]
        [Display(Name = "Maks. endirim")]
        public decimal MaxDiscountAmount { get; set; }

        [Required]
        [Display(Name = "Process Kodu")]
        [DefaultValue("RS")]
        public string ProcessCode { get; set; } = "RS"; 

        [StringLength(250)]
        [Display(Name = "Qeyd")]
        public string? Note { get; set; }

        [StringLength(50)]
        [Display(Name = "Kampaniya şifrəsi")]
        public string? CampaignPassword { get; set; }

        public virtual ICollection<TrCampaignProduct> TrCampaignProducts { get; set; } = new List<TrCampaignProduct>();
        public virtual ICollection<TrCampaignCategory> TrCampaignCategories { get; set; } = new List<TrCampaignCategory>();
        public virtual ICollection<TrCampaignCustomer> TrCampaignCustomers { get; set; } = new List<TrCampaignCustomer>();
        public virtual ICollection<TrCampaignStore> TrCampaignStores { get; set; } = new List<TrCampaignStore>();
        public virtual ICollection<TrCampaignWarehouse> TrCampaignWarehouses { get; set; } = new List<TrCampaignWarehouse>();
        public virtual ICollection<TrCampaignPaymentMethod> TrCampaignPaymentMethods { get; set; } = new List<TrCampaignPaymentMethod>();
        public virtual ICollection<TrInvoiceCampaignLog> TrInvoiceCampaignLogs { get; set; } = new List<TrInvoiceCampaignLog>();
    }
}