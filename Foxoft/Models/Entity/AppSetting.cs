using Foxoft.Properties;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class AppSetting
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_GridViewLayout), ResourceType = typeof(Resources))]
        public string? GridViewLayout { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_AutoPrint), ResourceType = typeof(Resources))]
        public bool AutoPrint { get; set; }


        [Display(Name = nameof(Resources.Entity_AppSetting_PrinterName), ResourceType = typeof(Resources))]
        public string? PrinterName { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_PrintCount), ResourceType = typeof(Resources))]
        public int PrintCount { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_PrintDesignPath), ResourceType = typeof(Resources))]
        public string? PrintDesignPath { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_LocalCurrencyCode), ResourceType = typeof(Resources))]
        public string? LocalCurrencyCode { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_WhatsappChromeProfileName), ResourceType = typeof(Resources))]
        public string? WhatsappChromeProfileName { get; set; }

        [Display(Name = "Twilio Token")]
        public string? TwilioToken { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_License), ResourceType = typeof(Resources))]
        public string? License { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_DueDate), ResourceType = typeof(Resources))]
        public string? DueDate { get; set; }  // lazimsiz prop, silinecek

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_AppSetting_UsePriceList), ResourceType = typeof(Resources))]
        public bool UsePriceList { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_AppSetting_AutoSave), ResourceType = typeof(Resources))]
        public bool AutoSave { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_InvoiceEditGraceDays), ResourceType = typeof(Resources))]
        public int? InvoiceEditGraceDays { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_PaymentEditGraceDays), ResourceType = typeof(Resources))]
        public int? PaymentEditGraceDays { get; set; }

        [ForeignKey("DcUnitOfMeasure")]
        [Display(Name = nameof(Resources.Entity_AppSetting_DefaultUnitOfMeasureId), ResourceType = typeof(Resources))]
        public int DefaultUnitOfMeasureId { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_UseScales), ResourceType = typeof(Resources))]
        public bool UseScales { get; set; }

        [Display(Name = nameof(Resources.Entity_AppSetting_UseBarcode), ResourceType = typeof(Resources))]
        public bool UseBarcode { get; set; }


        [ForeignKey("LocalCurrencyCode")]
        public virtual DcCurrency DcCurrency { get; set; }

        [ForeignKey("DefaultUnitOfMeasureId")]
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }


    }
}
