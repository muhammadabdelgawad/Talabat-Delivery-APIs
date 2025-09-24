namespace Talabat.Domain.Contracts.Presistence
{
    public interface IDbIntializer
    {
        Task IntializeAsync();
        Task SeedAsync();
    }
}
