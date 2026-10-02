using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTWithCoreApis.Migrations
{
    /// <inheritdoc />
    public partial class me4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: true),
                    Gst = table.Column<double>(type: "float", nullable: true),
                    StockQuantity = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "TblCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Tblemployees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tblemployees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "TblProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Gst = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProducts", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "TblstudentDetails",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblstudentDetails", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Tblusers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tblusers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TblInvoiceDetails",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInvoiceDetails", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_TblInvoiceDetails_TblCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TblCustomers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "TblInvoicePayments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentAmount = table.Column<double>(type: "float", nullable: true),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInvoicePayments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_TblInvoicePayments_TblInvoiceDetails_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "TblInvoiceDetails",
                        principalColumn: "InvoiceId");
                });

            migrationBuilder.CreateTable(
                name: "TblInvoiceProducts",
                columns: table => new
                {
                    InvoiceProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInvoiceProducts", x => x.InvoiceProductId);
                    table.ForeignKey(
                        name: "FK_TblInvoiceProducts_TblInvoiceDetails_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "TblInvoiceDetails",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_TblInvoiceProducts_TblProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TblProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoiceDetails_CustomerId",
                table: "TblInvoiceDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoicePayments_InvoiceId",
                table: "TblInvoicePayments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoiceProducts_InvoiceId",
                table: "TblInvoiceProducts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInvoiceProducts_ProductId",
                table: "TblInvoiceProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tblemployees");

            migrationBuilder.DropTable(
                name: "TblInvoicePayments");

            migrationBuilder.DropTable(
                name: "TblInvoiceProducts");

            migrationBuilder.DropTable(
                name: "TblstudentDetails");

            migrationBuilder.DropTable(
                name: "Tblusers");

            migrationBuilder.DropTable(
                name: "TblInvoiceDetails");

            migrationBuilder.DropTable(
                name: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblCustomers");
        }
    }
}
