using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JWTWithCoreApis.Services 
{
    public class InvoiceService : IInvoiceService
    {
        CoreapidbContext db;
        public InvoiceService(CoreapidbContext db)
        {
            this.db = db;
        }

        public TblInvoiceDetail AddNewInvoice(InvoiceDto d)
        {
            List<TblInvoiceProduct> products=new List<TblInvoiceProduct>(); 
            foreach(var s in d.Products)
            {
                products.Add(new TblInvoiceProduct() { ProductId = s.ProductId, Quantity = s.Quantity });
            }
            TblInvoiceDetail p = new TblInvoiceDetail()
            {
                CustomerId = d.CustomerId,
                InvoiceDate = d.InvoiceDate,
                TotalAmount = d.TotalAmount,
                TblInvoiceProducts = products
            };
            db.TblInvoiceDetails.Add(p);
            db.SaveChanges();
            TblInvoiceDetail dd = new TblInvoiceDetail()
            {
                InvoiceId = p.InvoiceId,
                InvoiceDate = p.InvoiceDate,
                TotalAmount = p.TotalAmount,
                CustomerId = p.CustomerId
            };
            return dd;
        }

        public InvoiceModel GetInvoice(int invoice_id)
        {
            InvoiceModel m = GetInvoiceModel(invoice_id);
             
            return m;
        }

        public List<InvoiceModel> GetInvoices()
        {
             List<InvoiceModel> lst=new List<InvoiceModel>();
            foreach(TblInvoiceDetail d in db.TblInvoiceDetails.ToList())
            {
                InvoiceModel m = GetInvoiceModel(d.InvoiceId);
                lst.Add(m);
            }
            return lst;
        }



        [NonAction]
        public InvoiceModel GetInvoiceModel(int id)
        {
            InvoiceModel m = null;
            TblInvoiceDetail d = db.TblInvoiceDetails.Find(id);
            if (d != null)
            {
                TblCustomer c = db.TblCustomers.Find(d.CustomerId);
                List<TblInvoicePayment> payments = GetInvoiceWisePayments(d.InvoiceId);
                float total_amount = 0, paid_amount = 0, remaining_amount = 0;
                total_amount = (float)d.TotalAmount;
                if (payments != null)
                {
                    paid_amount = (float)payments.Sum(e => e.PaymentAmount);
                }
                remaining_amount = total_amount - paid_amount;
                string status = "";
                if (paid_amount == 0)
                {
                    status = "Un Paid";
                }
                else if (paid_amount > 0 && paid_amount < total_amount)
                {
                    status = "Partial Paid";
                }
                else
                {
                    status = "Paid";
                }

                m = new InvoiceModel()
                {
                    InvoiceId = d.InvoiceId,
                    CustomerId = (int)d.CustomerId,
                    CustomerName = c.CustomerName,
                    InvoiceDate = (DateTime)d.InvoiceDate,
                    PaidAmount = paid_amount,
                    RemainingAmount = remaining_amount,
                    Status = status,
                    TotalAmount = total_amount
                };
            }
            return m;
        }

      

        public List<TblInvoicePayment> GetInvoiceWisePayments(int invoice_id)
        {
            List<TblInvoicePayment> payments = db.TblInvoicePayments.Where(e => e.InvoiceId.Equals(invoice_id)).ToList();
            return payments;
        }

        public List<TblInvoiceProduct> GetInvoiceWiseProducts(int invoice_id)
        {
            List < TblInvoiceProduct> lst=db.TblInvoiceProducts.Where(e=>e.InvoiceId.Equals(invoice_id)).ToList();
            return lst;
        }

        public TblInvoiceDetail GetInvoiceIdWiseData(int invoice_id)
        {
            TblInvoiceDetail d = db.TblInvoiceDetails.Find(invoice_id);
            TblCustomer c = db.TblCustomers.Find(d.CustomerId);
            List<TblInvoiceProduct> products = db.TblInvoiceProducts.Where(e => e.InvoiceId.Equals(d.InvoiceId)).ToList();
            List<TblInvoiceProduct> lst=new List<TblInvoiceProduct>();
            foreach(TblInvoiceProduct p in products)
            {
                TblProduct pr = db.TblProducts.Find(p.ProductId);
                p.Product = pr;
                lst.Add(p);
            }
            List<TblInvoicePayment> payments = db.TblInvoicePayments.Where(e => e.InvoiceId.Equals(d.InvoiceId)).ToList();
            d.TblInvoicePayments= payments;
            d.Customer = c;
            d.TblInvoiceProducts = lst;
            return d;
        }

        public InvoicePaymentModel AddInvoicePayment(InvoicePaymentModel p)
        {
            TblInvoicePayment pm = new TblInvoicePayment()
            {
                InvoiceId = p.InvoiceId,
                Description = p.Description,
                PaymentAmount = p.PaymentAmount,
                PaymentDate = p.PaymentDate,
                PaymentMode = p.PaymentMode
            };
            db.TblInvoicePayments.Add(pm);
            db.SaveChanges();
            InvoicePaymentModel payment = new InvoicePaymentModel()
            {
                PaymentMode = p.PaymentMode,
                InvoiceId = p.InvoiceId,
                PaymentDate = p.PaymentDate,
                PaymentAmount = p.PaymentAmount,
                Description = p.Description,
                PaymentId = p.PaymentId
            };
            return payment;
        }

        public List<InvoicePaymentModel> GetInvoiceWiseAllPayments(int InvoiceId)
        {
            List<InvoicePaymentModel> payments=new List<InvoicePaymentModel>();
            foreach(var p in db.TblInvoicePayments.Where(e => e.InvoiceId.Equals(InvoiceId)).ToList())
            {
                InvoicePaymentModel payment = new InvoicePaymentModel()
                {
                    PaymentMode = p.PaymentMode,
                    InvoiceId = p.InvoiceId,
                    PaymentDate = p.PaymentDate,
                    PaymentAmount = p.PaymentAmount,
                    Description = p.Description,
                    PaymentId = p.PaymentId
                };
                payments.Add(payment);
            }
            return payments;
        }

        public TblInvoiceDetail GetInvoiceWiseAllDetails(int invoice_id)
        {
            TblInvoiceDetail st = new TblInvoiceDetail();
            TblInvoiceDetail d = db.TblInvoiceDetails.Find(invoice_id);
            st.InvoiceId = d.InvoiceId;
            st.InvoiceDate = d.InvoiceDate;
            st.TotalAmount = d.TotalAmount;
            st.CustomerId = d.CustomerId;
                 

             TblCustomer c = db.TblCustomers.Find(d.CustomerId);
            st.Customer = new TblCustomer()
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                EmailAddress = c.EmailAddress,
                MobileNumber = c.MobileNumber,
                City = c.City
            };
            List<TblInvoiceProduct> products = new List<TblInvoiceProduct>();
            foreach (var p in db.TblInvoiceProducts.Where(e => e.InvoiceId.Equals(invoice_id)).ToList())
            {
                TblProduct prod=db.TblProducts.Find(p.ProductId);
                prod.TblInvoiceProducts = null;
                TblInvoiceProduct pr = new TblInvoiceProduct()
                {
                    ProductId = p.ProductId,
                     InvoiceId = p.InvoiceId,
                      InvoiceProductId=p.InvoiceProductId,
                       Quantity = p.Quantity,
                        Product=prod,
                };
                products.Add(pr);
            }
            st.TblInvoiceProducts = products;
          List<TblInvoicePayment> payments = new List<TblInvoicePayment>();
            foreach(var b in db.TblInvoicePayments.Where(e => e.InvoiceId.Equals(invoice_id)).ToList())
            {
                payments.Add(new TblInvoicePayment()
                {
                    PaymentId = b.PaymentId,
                    Description = b.Description,
                    PaymentAmount = b.PaymentAmount,
                    PaymentDate = b.PaymentDate,
                    PaymentMode = b.PaymentMode,
                    InvoiceId = b.InvoiceId
                });
                
            }
            st.TblInvoicePayments = payments;
            return st;
        }
    }
}
