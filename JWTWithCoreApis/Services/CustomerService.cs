using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;

namespace JWTWithCoreApis.Services 
{
    public class CustomerService : ICustomerService
    {
        CoreapidbContext db;
        public CustomerService(CoreapidbContext db)
        {
            this.db = db;
        }
        public CustomerModel AddCustomer(CustomerModel customer)
        {
             TblCustomer c=new TblCustomer()
             {
                  CustomerName = customer.CustomerName,
                   City = customer.City,
                     EmailAddress=customer.EmailAddress,
                      MobileNumber = customer.MobileNumber,
                       
             };
            db.TblCustomers.Add(c);
            db.SaveChanges();
            CustomerModel cm = new CustomerModel()
            {
                CustomerName = c.CustomerName,
                MobileNumber = c.MobileNumber,
                City = c.City,
                EmailAddress = c.EmailAddress,
                CustomerId = c.CustomerId
            };
            return cm;
        }
        public bool CheckMobileExistance(string MobileNumber)
        {
            TblCustomer c = db.TblCustomers.FirstOrDefault(e => e.MobileNumber.ToLower().Equals(MobileNumber.ToLower()));
            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEmailExistance(string EmailAddress)
        {
            TblCustomer c = db.TblCustomers.FirstOrDefault(e => e.EmailAddress.ToLower().Equals(EmailAddress.ToLower()));
            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteCustomer(int Id)
        {
            TblCustomer customer = db.TblCustomers.Find(Id);
            db.TblCustomers.Remove(customer);
            db.SaveChanges();
        }
        public CustomerModel GetCustomer(int Id)
        {
            TblCustomer c = db.TblCustomers.Find(Id);
            CustomerModel cm = new CustomerModel()
            {
                CustomerName = c.CustomerName,
                MobileNumber = c.MobileNumber,
                City = c.City,
                EmailAddress = c.EmailAddress,
                CustomerId = c.CustomerId
            };
            return cm;
        }

        public List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> lst = new List<CustomerModel>();
            foreach(var c in db.TblCustomers.ToList())
            {
                CustomerModel cm = new CustomerModel()
                {
                    CustomerName = c.CustomerName,
                    MobileNumber = c.MobileNumber,
                    City = c.City,
                    EmailAddress = c.EmailAddress,
                    CustomerId = c.CustomerId
                };
                lst.Add(cm);
            }
            return lst;
        }
        public CustomerModel UpdateCustomer(CustomerModel customer)
        {
            TblCustomer c = new TblCustomer()
            {
                CustomerName = customer.CustomerName,
                City = customer.City,
                EmailAddress = customer.EmailAddress,
                MobileNumber = customer.MobileNumber,
            };
            db.TblCustomers.Update(c);
            db.SaveChanges();
            CustomerModel cm = new CustomerModel()
            {
                CustomerName = c.CustomerName,
                MobileNumber = c.MobileNumber,
                City = c.City,
                EmailAddress = c.EmailAddress,
                CustomerId = c.CustomerId
            };
            return cm;
        }
    }
}
