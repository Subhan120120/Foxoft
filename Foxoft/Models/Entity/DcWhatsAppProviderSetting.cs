using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public class DcWhatsAppProviderSetting
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Server URL")]
        [StringLength(500)]
        public string? ServerUrl { get; set; }

        [Display(Name = "Instance Name")]
        [StringLength(100)]
        public string? InstanceName { get; set; }

        [Display(Name = "API Key")]
        [StringLength(200)]
        public string? ApiKey { get; set; }
    }
}
