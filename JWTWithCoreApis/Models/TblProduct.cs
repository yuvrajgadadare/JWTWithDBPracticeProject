using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models;

public partial class TblProduct
{
    [Key]
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double Rate { get; set; }

    public int Gst { get; set; }

    public int? StockQuantity { get; set; }

    public virtual ICollection<TblInvoiceProduct> TblInvoiceProducts { get; set; } = new List<TblInvoiceProduct>();
}
