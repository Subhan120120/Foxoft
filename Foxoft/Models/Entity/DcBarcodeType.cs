using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_BarcodeType), ResourceType = typeof(Resources))]
    public partial class DcBarcodeType
    {
        public DcBarcodeType()
        {
            TrProductBarcodes = new HashSet<TrProductBarcode>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_BarcodeType_Code), ResourceType = typeof(Resources))]
        public string BarcodeTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_BarcodeType_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [StringLength(50,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string BarcodeTypeDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_BarcodeType_Default), ResourceType = typeof(Resources))]
        public bool? DefaultBarcodeType { get; set; }

        public virtual ICollection<TrProductBarcode> TrProductBarcodes { get; set; }
    }
}
