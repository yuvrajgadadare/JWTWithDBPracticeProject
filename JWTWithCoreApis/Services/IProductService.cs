using JWTWithCoreApis.Models;

namespace JWTWithCoreApis.Services 
{
    public interface IProductService
    {
        ProductModel AddProduct(ProductModel product);
        ProductModel UpdateProduct(ProductModel product);
        Task DeleteProduct(int Id);
      Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int Id);
    }
}
