namespace JWTWithCoreApis.Models
{
    public class InvoicePaymentModel
    {
        public int PaymentId { get; set; }

        public int? InvoiceId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public double? PaymentAmount { get; set; }

        public string? PaymentMode { get; set; }

        public string? Description { get; set; }
    }
}
