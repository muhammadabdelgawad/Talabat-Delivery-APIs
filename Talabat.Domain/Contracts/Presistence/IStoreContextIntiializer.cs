namespace Talabat.Domain.Contracts.Presistence
{
    public interface IStoreContextIntiializer
    {
        Task IntiializeAsync();
        Task SeedAsync();
    }
}
