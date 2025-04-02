
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Cari Hesab Özəllik Tipi")]
    public partial class DcCurrAccFeatureType
    {
        public DcCurrAccFeatureType()
        {
            TrCurrAccFeatures = new HashSet<TrCurrAccFeature>();
        }

        [Key]
        [Display(Name = "CH Özəllik Tipi Kodu")]
        public int CurrAccFeatureTypeId { get; set; }

        [Display(Name = "CH Özəllik Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureTypeName { get; set; }

        [Display(Name = "Sıra")]
        public int Order { get; set; }

        [Display(Name = "Filtirlənir")]
        public bool Filterable { get; set; }


        //[JsonIgnore]
        public virtual ICollection<TrCurrAccFeature> TrCurrAccFeatures { get; set; }
    }
}
