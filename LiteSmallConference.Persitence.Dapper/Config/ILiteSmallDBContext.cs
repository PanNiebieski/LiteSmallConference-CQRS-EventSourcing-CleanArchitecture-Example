namespace LiteSmallConference.Persitence.Dapper.SQLite.Config
{
    public interface ILiteSmallDBContext
    {
        string ConnectionString { get; }
    }

    public interface IZEsLiteSmallDBContext
    {
        string ConnectionString { get; }
    }
}
