using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Cari Hesab Özəlliyi")]
    public partial class DcCurrAccFeature
    {
        public DcCurrAccFeature()
        {
            TrCurrAccFeatures = new HashSet<TrCurrAccFeature>();
        }

        [Key, Column(Order = 0)]
        [Display(Name = "Özəllik Kodu")]
        public string CurrAccFeatureCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcFeatureTypeCurrAcc")]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int CurrAccFeatureTypeId { get; set; }

        [Display(Name = "Özəllik Açıqlaması")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string? FeatureDesc { get; set; }


        [ForeignKey("CurrAccFeatureTypeId")]
        public virtual DcCurrAccFeatureType DcCurrAccFeatureType { get; set; }

        public virtual ICollection<TrCurrAccFeature> TrCurrAccFeatures { get; set; }
    }
}
