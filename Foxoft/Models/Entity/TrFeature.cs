using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class TrFeature
    {
        public TrFeature()
        {
            //TrRoleClaims = new HashSet<TrRoleClaim>();
        }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Özəllik Id")]
        [ForeignKey("DcFeature")]
        public int FeatureId { get; set; }
                
        [DisplayName("Məhsul")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }


        public virtual DcFeature DcFeature { get; set; }

        public virtual DcProduct DcProduct { get; set; }
    }
}
