using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWithCoreApis.Controllers
{
    //[Route("api/[controller]")]
     [Authorize]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        ICustomerService customerService;
        public CustomerApiController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        [Route("api/customer")]
        public List<CustomerModel> GetAll()
        {
            //string uname = User.Identity.Name;
            return customerService.GetCustomers();
        }
        [HttpGet]
        [Route("api/customer/{id}")]
        public CustomerModel GetById(int id)
        {
            return customerService.GetCustomer(id);
        }
        [HttpPost]
        [Route("api/customer")]
        public IActionResult AddCustomer(CustomerModel customer)
        {
            if (customerService.CheckEmailExistance(customer.EmailAddress))
            {
                return StatusCode(500, "Email address is already exist");
            }
            else if (customerService.CheckMobileExistance(customer.MobileNumber))
            {
                return StatusCode(500, "Mobile number is already exist");
            }
            else
            {
              CustomerModel c=  customerService.AddCustomer(customer);
                return StatusCode(200, c);
            }
        }
        [HttpPut]
        [Route("api/customer/{id}")]
        public CustomerModel UpdateProduct(int id , CustomerModel customer)
        {
            customer.CustomerId = id;
            return customerService.UpdateCustomer(customer);
        }
        [HttpDelete]
        [Route("api/customer/{id}")]
        public string DeleteCustomer(int id)
        {
            customerService.DeleteCustomer(id);
            return "Customer Deleted Successfully";
        }

    }
}
