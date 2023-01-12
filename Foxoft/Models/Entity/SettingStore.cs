using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
   public partial class SettingStore
   {
      public SettingStore()
      {
         DcStores = new HashSet<DcCurrAcc>();
      }

      [Key]
      public int Id { get; set; }

      [StringLength(30)]
      [DisplayName("Mağaza Kodu")]
      [ForeignKey(nameof(DcCurrAcc))]
      public string StoreCode { get; set; }

      [DisplayName("Dizayn Fayl Qovluğu")]
      public string DesignFileFolder { get; set; }

      [DisplayName("Şəkil Qovluğu")]
      public string ImageFolder { get; set; }

      public IEnumerable<DcCurrAcc> DcStores { get; set; }

   }
}
