using API.Core.DbModels;
using API.Core.Specificatios;

namespace API.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        
        Task<T> GetEntityWithSpec(ISpecification<T> specification);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification );

        Task<int> CountAsync(ISpecification<T> specification);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<Product>> ListAsyncs(ProductsWithProductTypeAndBrandSpecification spec);
    }
}
