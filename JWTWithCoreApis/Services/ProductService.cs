using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;

namespace JWTWithCoreApis.Services
{
    public class ProductService : IProductService
    {
        CoreapidbContext db;
        public ProductService(CoreapidbContext db)
        {
            this.db = db;
        }

        public ProductModel AddProduct(ProductModel product)
        {
            TblProduct pr=new TblProduct()
            {
                 ProductName=product.ProductName,
                  Gst= product.Gst,
                   Rate=product.Gst,
                    StockQuantity=product.StockQuantity
            };
            db.TblProducts.Add(pr);
            db.SaveChanges();

            ProductModel pm = new ProductModel()
            {
                ProductName = pr.ProductName,
                Gst = pr.Gst,
                ProductId = pr.ProductId,
                StockQuantity = (int)pr.StockQuantity,
                Rate = pr.Rate,
            };
            return pm;
        }

        public async Task DeleteProduct(int Id)
        {
            TblProduct p = db.TblProducts.Find(Id);
             db.TblProducts.Remove(p);
            db.SaveChanges();

        }

        public async Task<ProductModel> GetProduct(int Id)
        {
            TblProduct p=db.TblProducts.Find(Id);
            ProductModel pm = new ProductModel()
            {
                ProductName = p.ProductName,
                Gst = p.Gst,
                ProductId = p.ProductId,
                StockQuantity = (int)p.StockQuantity,
                Rate = p.Rate

            };
            return pm;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            List<ProductModel> lst = new List<ProductModel>();
            foreach(var p in db.TblProducts.ToList())
            {
                ProductModel pm = new ProductModel()
                {
                    ProductName = p.ProductName,
                    Gst = p.Gst,
                    ProductId = p.ProductId,
                    StockQuantity = (int)p.StockQuantity,
                    Rate = p.Rate

                };
                lst.Add(pm);
            }
            
            return lst;
        }

        public ProductModel UpdateProduct(ProductModel product)
        {
            TblProduct pr = new TblProduct()
            {
                 ProductId=product.ProductId,
                ProductName = product.ProductName,
                Gst = product.Gst,
                Rate = product.Gst,
                StockQuantity = product.StockQuantity
            };
            db.TblProducts.Update(pr);
            db.SaveChanges();
            ProductModel pm = new ProductModel()
            {
                ProductName = pr.ProductName,
                Gst = pr.Gst,
                ProductId = pr.ProductId,
                StockQuantity = (int)pr.StockQuantity,
                Rate = pr.Rate,
            };
            return pm;
        }
    }
}
