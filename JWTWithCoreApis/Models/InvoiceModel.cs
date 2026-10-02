namespace JWTWithCoreApis.Models
{
    public class InvoiceModel
    {
        public int InvoiceId {  get; set; }
        public int CustomerId {  get; set; }
        public string CustomerName {  get; set; }
        public DateTime InvoiceDate { get; set; }
        public float TotalAmount {  get; set; }
        public float RemainingAmount {  get; set; }
        public float PaidAmount {  get; set; }
        public string Status { get; set; }

    }
}
