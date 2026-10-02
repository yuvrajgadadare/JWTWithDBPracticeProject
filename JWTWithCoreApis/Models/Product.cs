using System;
using System.Collections.Generic;

namespace JWTWithCoreApis.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? Rate { get; set; }

    public double? Gst { get; set; }

    public double? StockQuantity { get; set; }
}
