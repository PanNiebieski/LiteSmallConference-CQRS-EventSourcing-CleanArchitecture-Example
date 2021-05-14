using LiteSmallConference.Persitence.Dapper.SQLite.Config;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces
{
    public interface IBeforeDoer
    {
        void ChangeDBContext(ILiteSmallDBContext context);
    }
}
