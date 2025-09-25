namespace Talabat.Domain.Contracts.Presistence.DbIntializers
{
    public interface IDbIntializer
    {
        Task IntializeAsync();
        Task SeedAsync();
    }
}
