using Microsoft.Extensions.Options;
using Talabat.Domain.Entities;

namespace Talabat.Infrastructure.Persistence.Data
{
    public class StoreContext :DbContext
    {
        public StoreContext()
        {
                
        }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);


        }
        public DbSet<Product> Products { get; set; }
       public DbSet<ProductBrand> Brands { get; set; }
       public DbSet<ProductCategory> Categories { get; set; }

    }
}
