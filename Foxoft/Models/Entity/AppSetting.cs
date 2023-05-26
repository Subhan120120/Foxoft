using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class AppSetting
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Cədvəl Dizaynı")]
        public string GridViewLayout { get; set; }

        [Display(Name = "Print Edilsin")]
        public bool GetPrint { get; set; }

        [Display(Name = "Printer Adı")]
        public string PrinterName { get; set; }

        [Display(Name = "Çap sayı")]
        public int PrinterCopyNum { get; set; }

        [Display(Name = "Print Dizayn Yolu")]
        public string PrintDesignPath { get; set; }

        [Display(Name = "Yerli Valyuta Kodu")]
        public string LocalCurrencyCode { get; set; }

        [Display(Name = "Twilio Instance Id")]
        public string TwilioInstanceId { get; set; }

        [Display(Name = "Twilio Token")]
        public string TwilioToken { get; set; }

        [Display(Name = "Lisenziya")]
        public string License { get; set; }



        [ForeignKey("LocalCurrencyCode")]
        public virtual DcCurrency DcCurrency { get; set; }

    }
}
