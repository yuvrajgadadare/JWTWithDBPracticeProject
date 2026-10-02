using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace JWTWithCoreApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IProductService _db; // Simulated Database

        public ProductsController(IDistributedCache cache, IProductService db)
        {
            _cache = cache;
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            string cacheKey = $"product_{id}";

            // 1. Try to get data from distributed cache
            var product = await _cache.GetRecordAsync<ProductModel>(cacheKey);

            if (product is null)
            {
                // 2. Cache Miss: Fetch from Database
                product = await _db.GetProduct(id);

                if (product is null) return NotFound();

                // 3. Save fetched data into cache for future requests
                await _cache.SetRecordAsync(cacheKey, product, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(1));
            }

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _db.DeleteProduct(id);

            // 4. Cache Invalidation: Evict item from cache when data changes
            await _cache.RemoveAsync($"product_{id}");

            return NoContent();
        }
    }
}
