using API.Core.DbModels;

namespace API.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductAsync();
        Task<List<ProductType>> GetProductTypesAsync();
        Task<List<ProductBrand>> GetProductBrandsAsync();
        Task<Product> Create(Product model);

    }
}
