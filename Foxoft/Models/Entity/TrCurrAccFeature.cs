using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Cari Hesab Özəlliyi")]
    public partial class TrCurrAccFeature
    {
        [Key, Column(Order = 0)]
        [ForeignKey("DcCurrAcc")]
        [Display(Name = "Məhsul Kodu")]
        public string CurrAccCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcCurrAccFeatureType")]
        [Display(Name = "CH Özəllik Tipi Kodu")]
        public int CurrAccFeatureTypeId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("DcCurrAccFeature")]
        [Display(Name = "CH Özəllik Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CurrAccFeatureCode { get; set; }


        [Display(Name = "Identity")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdentityColumn { get; set; }



        [ForeignKey("CurrAccCode")]
        public virtual DcCurrAcc DcCurrAcc { get; set; }

        [ForeignKey("CurrAccFeatureTypeId")]
        public virtual DcCurrAccFeatureType DcCurrAccFeatureType { get; set; }

        [ForeignKey("CurrAccFeatureCode")]
        public virtual DcCurrAccFeature DcCurrAccFeature { get; set; }
    }
}
