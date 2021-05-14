namespace LiteSmallConference.Infrastructure.EventStorePlugin.SQLite.Config
{
    public class EventStoreSQLiteContext : IEventStoreSQLiteContext
    {
        public EventStoreSQLiteContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
    }
}
