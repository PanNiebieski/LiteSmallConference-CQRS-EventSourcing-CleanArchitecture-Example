using LiteSmallConference.Persitence.Dapper.SQLite.Config;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods
{
    public class BeforeDoer
    {
        protected ILiteSmallDBContext _geekLemonContext;

        public void ChangeDBContext(ILiteSmallDBContext context)
        {
            _geekLemonContext = context;
        }
    }
}
