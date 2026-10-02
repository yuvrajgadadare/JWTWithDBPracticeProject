using JWTWithCoreApis.Models;

namespace JWTWithCoreApis.Services 
{
    public interface ICustomerService
    {
        CustomerModel AddCustomer(CustomerModel customer);
        CustomerModel UpdateCustomer(CustomerModel customer);
        void DeleteCustomer(int Id);
        List<CustomerModel> GetCustomers();
        CustomerModel GetCustomer(int Id);
        bool CheckEmailExistance(string EmailAddress);
        bool CheckMobileExistance(string MobileNumber);
    }
}
