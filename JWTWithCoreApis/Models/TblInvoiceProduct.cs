using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTWithCoreApis.Models;

public partial class TblInvoiceProduct
{
    [Key]
    public int InvoiceProductId { get; set; }

    public int? InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }
    [ForeignKey(nameof(InvoiceId))]
    public virtual TblInvoiceDetail? Invoice { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual TblProduct? Product { get; set; }
}
