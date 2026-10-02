using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTWithCoreApis.Models;

public partial class TblInvoiceDetail
{
    [Key]
    public int InvoiceId { get; set; }

    public DateTime InvoiceDate { get; set; }


    public int? CustomerId { get; set; }

    public double? TotalAmount { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual TblCustomer? Customer { get; set; }

    public virtual ICollection<TblInvoicePayment> TblInvoicePayments { get; set; } = new List<TblInvoicePayment>();

    public virtual ICollection<TblInvoiceProduct> TblInvoiceProducts { get; set; } = new List<TblInvoiceProduct>();
}
