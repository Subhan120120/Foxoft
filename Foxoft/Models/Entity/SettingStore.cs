using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Mağaza Parametr")]
    public partial class SettingStore
    {
        public SettingStore()
        {
            //DcStores = new HashSet<DcCurrAcc>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Display(Name = "Mağaza Kodu")]
        [ForeignKey("DcStore")]
        public string StoreCode { get; set; }

        [Display(Name = "Dizayn Fayl Qovluğu")]
        public string? DesignFileFolder { get; set; }

        [Display(Name = "Şəkil Qovluğu")]
        public string? ImageFolder { get; set; }

        [Display(Name = "Printer Adı")]
        public string? PrinterName { get; set; }

        [Display(Name = "Satıcı Sətiri Kopyala")]
        public bool SalesmanContinuity { get; set; }

        [Display(Name = "Tərəzi")]
        public bool UseScales { get; set; }

        [Display(Name = "Default Ölçü Vahidi")]
        [ForeignKey("DcUnitOfMeasure")]
        public int DefaultUnitOfMeasureId { get; set; }

        [ForeignKey("StoreCode")]
        public virtual DcCurrAcc DcStore { get; set; }

        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }

    }
}
