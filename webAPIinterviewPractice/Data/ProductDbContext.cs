using Microsoft.EntityFrameworkCore;
using webAPIinterviewPractice.Model.Domain;

namespace webAPIinterviewPractice.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
