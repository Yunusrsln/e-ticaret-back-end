using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        public readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Product>> GetProductAsync()
        {
             return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductType)
                .ToListAsync();
           
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> Create(Product model)
        {
           await _context.Products.AddAsync(model);
           await _context.SaveChangesAsync();

           return model;
        }
    }
}
