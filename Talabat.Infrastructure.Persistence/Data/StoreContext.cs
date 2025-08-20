using Microsoft.Extensions.Options;
using Talabat.Domain.Entities;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        
       public DbSet<Product> Products { get; set; }
       public DbSet<ProductBrand> Brands { get; set; }
       public DbSet<ProductCategory> Categories { get; set; }

    }
}
