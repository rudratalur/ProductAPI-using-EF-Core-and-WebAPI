using webAPIinterviewPractice.Model.Domain;

namespace webAPIinterviewPractice.Repository.IRepository
{
    public interface IRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product>GetByIdAsync(int id);
        public Task<Product> AddProductAsync(Product productObj);
        public Task<Product> UpdateProductAsync(int id, Product productObj);
        public Task<Product> DeleteProductAsync(int id);
    }
}
