﻿using Foxoft.Migrations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcFeatureType
    {
        public DcFeatureType()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
            TrHierarchyFeatures = new HashSet<TrHierarchyFeature>();
        }

        [Key]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }

        [Display(Name = "Özəllik Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureTypeName { get; set; }

        [Display(Name = "Sıra")]
        public int Order { get; set; }


        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
        public virtual ICollection<TrHierarchyFeature> TrHierarchyFeatures { get; set; }
    }
}
