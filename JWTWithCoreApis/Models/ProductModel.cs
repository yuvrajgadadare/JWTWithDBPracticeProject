namespace JWTWithCoreApis.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public double Rate { get; set; }

        public int Gst { get; set; }

        public int? StockQuantity { get; set; }
    }
}
