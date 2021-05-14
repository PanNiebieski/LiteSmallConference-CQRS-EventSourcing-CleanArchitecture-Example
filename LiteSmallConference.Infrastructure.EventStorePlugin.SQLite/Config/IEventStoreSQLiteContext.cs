namespace LiteSmallConference.Infrastructure.EventStorePlugin.SQLite.Config
{
    public interface IEventStoreSQLiteContext
    {
        string ConnectionString { get; }
    }
}
