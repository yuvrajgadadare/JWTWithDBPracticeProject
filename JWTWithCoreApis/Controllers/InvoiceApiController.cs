using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWithCoreApis.Controllers
{
//    [Route("api/[controller]")]
     [Authorize]
    [ApiController]
    public class InvoiceApiController : ControllerBase
    {
        IProductService productService;
        ICustomerService customerService;
        IInvoiceService invoiceService;
        public InvoiceApiController(IProductService productService, ICustomerService customerService, IInvoiceService invoiceService)
        {
            this.productService = productService;
            this.customerService = customerService;
            this.invoiceService = invoiceService;
        }
        
        [HttpGet]
        [Route("api/invoice")]
        public List<InvoiceModel> GetInvoices()
        {
            List<InvoiceModel> lst = invoiceService.GetInvoices();
            return lst;
        }

        [HttpGet]
        [Route("api/invoice/{id}")]
        public  InvoiceModel GetInvoice(int id)
        {
            InvoiceModel  st = invoiceService.GetInvoice(id);
            return  st;
        }
        [HttpPost]
        [Route("api/invoice")]
        public TblInvoiceDetail AddInvoice(InvoiceDto d)
        {
            TblInvoiceDetail st = invoiceService.AddNewInvoice(d);
            return st;
        }
        [HttpPost]
        [Route("api/payinvoice")]
        public InvoicePaymentModel PayNow(InvoicePaymentModel  d)
        {
            InvoicePaymentModel st = invoiceService.AddInvoicePayment(d);
            return st;
        }
        [HttpGet]
        [Route("api/invoicewisepayments/{id}")]
        public List<InvoicePaymentModel> GetInvoiceWisePayments(int id)
        {
            List<InvoicePaymentModel> lst = invoiceService.GetInvoiceWiseAllPayments(id);
            return lst;
        }

        [HttpGet]
        [Route("api/invoicewisealldetails/{id}")]
        public  TblInvoiceDetail  GetInvoiceWiseAllDetails(int id)
        {
            TblInvoiceDetail st = invoiceService.GetInvoiceWiseAllDetails(id);
            return  st;
        }
    }
}
