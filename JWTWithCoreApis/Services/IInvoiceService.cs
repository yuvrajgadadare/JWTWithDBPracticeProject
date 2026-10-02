using JWTWithCoreApis.Models;

namespace JWTWithCoreApis.Services 
{
    public interface IInvoiceService
    {
        TblInvoiceDetail AddNewInvoice(InvoiceDto d);
        List<InvoiceModel> GetInvoices();
        InvoiceModel GetInvoice(int invoice_id);
        InvoicePaymentModel AddInvoicePayment(InvoicePaymentModel p);
        List<TblInvoicePayment> GetInvoiceWisePayments(int invoice_id);
       TblInvoiceDetail GetInvoiceWiseAllDetails(int invoice_id);
        List<TblInvoiceProduct> GetInvoiceWiseProducts(int invoice_id);
        TblInvoiceDetail GetInvoiceIdWiseData(int invoice_id);
        List<InvoicePaymentModel> GetInvoiceWiseAllPayments(int InvoiceId);
    }
}
