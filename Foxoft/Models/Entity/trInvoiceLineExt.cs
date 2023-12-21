﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    public partial class trInvoiceLineExt : BaseEntity
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("TrInvoiceLine")]
        public Guid InvoiceLineId { get; set; }

        [Display(Name = "Ödəmə")]
        [Column(TypeName = "money")]
        public decimal PriceDiscounted { get; set; }

        //public decimal PriceDiscounted
        //{
        //    get { return TrInvoiceLine.Price * (100 - TrInvoiceLine.PosDiscount) / 100; }
        //    set
        //    {
        //        if (TrInvoiceLine is not null)
        //            value = TrInvoiceLine.Price * (100 - TrInvoiceLine.PosDiscount) / 100;
        //    }
        //}


        public virtual TrInvoiceLine TrInvoiceLine { get; set; }
    }
}
