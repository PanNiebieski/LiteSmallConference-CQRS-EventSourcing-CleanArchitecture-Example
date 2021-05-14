namespace LiteSmallConference.Persitence.Dapper.SQLite.Config
{
    public class LiteSmallDBContext : ILiteSmallDBContext, IZEsLiteSmallDBContext
    {
        public LiteSmallDBContext(string connectionString)
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
