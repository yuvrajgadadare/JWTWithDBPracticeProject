using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models;

public partial class TblCustomer
{
    [Key]
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string? City { get; set; }

    public virtual ICollection<TblInvoiceDetail> TblInvoiceDetails { get; set; } = new List<TblInvoiceDetail>();
}
