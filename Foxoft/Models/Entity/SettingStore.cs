﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
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


        [ForeignKey("StoreCode")]
        public virtual DcCurrAcc DcStore { get; set; }

    }
}
