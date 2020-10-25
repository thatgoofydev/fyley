namespace DDDCore.Infrastructure
{
    public interface IEventStoreConnectionStringProvider
    {
        string GetConnectionString();
    }
}