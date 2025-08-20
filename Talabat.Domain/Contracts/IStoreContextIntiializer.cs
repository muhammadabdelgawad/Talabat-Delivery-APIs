namespace Talabat.Domain.Contracts
{
    public interface IStoreContextIntiializer
    {
        Task IntiializeAsync();
        Task SeedAsync();
    }
}
