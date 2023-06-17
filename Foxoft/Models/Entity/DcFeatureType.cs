﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcFeatureType
    {
        public DcFeatureType()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
        }

        [Key]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }

        [Display(Name = "Özəllik Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureTypeName { get; set; }


        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}