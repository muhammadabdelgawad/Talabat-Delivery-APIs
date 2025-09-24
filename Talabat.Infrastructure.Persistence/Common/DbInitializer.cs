using Talabat.Domain.Contracts.Presistence.DbIntializers;

namespace Talabat.Infrastructure.Persistence.Common
{
    public abstract class DbInitializer(DbContext _dbContext) : IDbIntializer
    {
        public virtual async Task IntializeAsync()
        {
            var pendingMigratuiions = _dbContext.Database.GetPendingMigrations();
            if (pendingMigratuiions.Any())
                await _dbContext.Database.MigrateAsync();

        }

        public abstract Task SeedAsync();
    }
}
