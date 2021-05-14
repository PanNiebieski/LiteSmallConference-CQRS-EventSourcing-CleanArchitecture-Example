namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Developers
{
    internal class SqliteConnection
    {
        private string connectionString;

        public SqliteConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}