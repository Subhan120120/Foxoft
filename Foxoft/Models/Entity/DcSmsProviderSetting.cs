using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public class DcSmsProviderSetting
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Provider Type")]
        [StringLength(50)]
        public string ProviderType { get; set; } = "GenericHttp";

        [Display(Name = "Server URL")]
        [StringLength(500)]
        public string? ServerUrl { get; set; }

        [Display(Name = "API Key / Token")]
        [StringLength(250)]
        public string? ApiKey { get; set; }

        [Display(Name = "Sender Title")]
        [StringLength(50)]
        public string? SenderTitle { get; set; }

        [Display(Name = "Username")]
        [StringLength(100)]
        public string? Username { get; set; }

        [Display(Name = "Password")]
        [StringLength(100)]
        public string? Password { get; set; }

        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
