using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models
{
    public class InvoiceDto
    {
       
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime InvoiceDate { get; set; }
        public float TotalAmount { get; set; }
        public List<ProductDto> Products { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
