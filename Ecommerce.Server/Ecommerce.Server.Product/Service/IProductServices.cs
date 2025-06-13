using AutoMapper;
using Ecommerce.Server.Product.DataBaseConn;
using Ecommerce.Server.Product.Model;
using Ecommerce.Server.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Ecommerce.Server.Product.Service
{
    public interface IProductServices
    {
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse> GetProductByIdAsync(Guid id);
        Task<ProductResponse> CreateProductAsync(ProductCreate productDto);
        Task<ProductResponse> UpdateProductAsync(Guid id, ProductCreate productDto);
        Task<bool> DeleteProductAsync(Guid id);
        Task<List<ProductResponse>> GetProductsByCategoryNameAsync(string categoryName);
        Task<List<ProductResponse>> GetProductsByCategoryIdAsync(int id);
    }

    public class ProductService : IProductServices
    {
        private readonly ProductDBContext _context;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

        public ProductService(ProductDBContext context, IMemoryCache cache, IMapper mapper)
        {
            _context = context;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            const string cacheKey = "AllProducts";

            if (!_cache.TryGetValue(cacheKey, out List<ProductResponse> products))
            {
                var entities = await _context.Products.ToListAsync();
                products = _mapper.Map<List<ProductResponse>>(entities);
                _cache.Set(cacheKey, products, _cacheDuration);
            }

            return products;
        }

        public async Task<ProductResponse> GetProductByIdAsync(Guid id)
        {
            string cacheKey = $"Product_{id}";

            if (!_cache.TryGetValue(cacheKey, out ProductResponse productDto))
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return null;

                productDto = _mapper.Map<ProductResponse>(product);
                _cache.Set(cacheKey, productDto, _cacheDuration);
            }

            return productDto;
        }

        public async Task<ProductResponse> CreateProductAsync(ProductCreate dto)
        {
            var product = _mapper.Map<ProductDetail>(dto);
            product.Id = Guid.NewGuid();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            _cache.Remove("AllProducts");

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> UpdateProductAsync(Guid id, ProductCreate dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            _mapper.Map(dto, product);

            await _context.SaveChangesAsync();

            _cache.Remove("AllProducts");
            _cache.Remove($"Product_{id}");

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            _cache.Remove("AllProducts");
            _cache.Remove($"Product_{id}");

            return true;
        }

        public async Task<List<ProductResponse>> GetProductsByCategoryIdAsync(int id)
        {
            var products = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();
            return _mapper.Map<List<ProductResponse>>(products);
        }

        public async Task<List<ProductResponse>> GetProductsByCategoryNameAsync(string categoryName)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
            if (category == null) return new List<ProductResponse>();

            return await GetProductsByCategoryIdAsync(category.Id);
        }
    }
}
