using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTWithCoreApis.Models;

public partial class TblInvoicePayment
{
    [Key]
    public int PaymentId { get; set; }

    public int? InvoiceId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public double? PaymentAmount { get; set; }

    public string? PaymentMode { get; set; }

    public string? Description { get; set; }
    [ForeignKey(nameof(InvoiceId))]
    public virtual TblInvoiceDetail? Invoice { get; set; }
}
