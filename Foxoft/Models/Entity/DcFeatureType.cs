﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Özəllik Tipi")]
    public partial class DcFeatureType
    {
        public DcFeatureType()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
            TrHierarchyFeatureTypes = new HashSet<TrHierarchyFeatureType>();
        }

        [Key]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }

        [Display(Name = "Özəllik Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureTypeName { get; set; }

        [Display(Name = "Sıra")]
        public int Order { get; set; }

        [Display(Name = "Filtirlənir")]
        public bool Filterable { get; set; }


        //[JsonIgnore]
        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
        //[JsonIgnore]
        public virtual ICollection<TrHierarchyFeatureType> TrHierarchyFeatureTypes { get; set; }
    }
}
