using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace JWTWithCoreApis.Models;

public partial class CoreapidbContext : DbContext
{

    public CoreapidbContext(DbContextOptions<CoreapidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; }

    public virtual DbSet<TblInvoicePayment> TblInvoicePayments { get; set; }

    public virtual DbSet<TblInvoiceProduct> TblInvoiceProducts { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<Tblemployee> Tblemployees { get; set; }

    public virtual DbSet<TblstudentDetail> TblstudentDetails { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }
     
}
