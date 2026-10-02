using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models
{
    public class CustomerModel
    {

        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public string? City { get; set; }
    }
}
