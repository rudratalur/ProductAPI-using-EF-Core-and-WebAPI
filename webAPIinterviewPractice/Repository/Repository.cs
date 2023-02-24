using Microsoft.EntityFrameworkCore;
using webAPIinterviewPractice.Data;
using webAPIinterviewPractice.Model.Domain;

namespace webAPIinterviewPractice.Repository.IRepository
{
    public class Repository : IRepository
    {
        private readonly ProductDbContext _db;
        public Repository(ProductDbContext db)
        {
            _db = db;
        }

        public async Task<Product> AddProductAsync(Product productObj)
        {
            await _db.Products.AddAsync(productObj);
            await _db.SaveChangesAsync();
            return productObj;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(c => c.ID == id);
            if(product == null)
            {
                return null;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync(); 
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var allProducts = await _db.Products.ToListAsync();
            return allProducts;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var productByID = await _db.Products.FirstOrDefaultAsync(c=> c.ID == id);
            return productByID;
        }

        public async Task<Product> UpdateProductAsync(int id, Product productObj)
        {
            var ProductData = await _db.Products.FirstOrDefaultAsync(c=> c.ID == id);
            if(ProductData == null) return null;

            ProductData.Name = productObj.Name;
            ProductData.Price = productObj.Price;
            await _db.SaveChangesAsync();
            return ProductData;
        }
    }
}
