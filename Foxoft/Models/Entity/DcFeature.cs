﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Özəllik")]
    public partial class DcFeature
    {
        public DcFeature()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
        }

        [Key, Column(Order = 0)]
        [Display(Name = "Özəllik Kodu")]
        public string FeatureCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcFeatureType")]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }

        [Display(Name = "Özəllik Açıqlaması")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string? FeatureDesc { get; set; }


        [ForeignKey("FeatureTypeId")]
        public virtual DcFeatureType DcFeatureType { get; set; }

        [JsonIgnore]
        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}
