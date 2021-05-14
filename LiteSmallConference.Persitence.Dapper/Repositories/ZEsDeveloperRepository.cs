using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Repositories
{
    public class ZEsDeveloperRepository : DeveloperRepository, IZEsDeveloperRepository
    {

        public ZEsDeveloperRepository(IDeveloperGetAllDoer developerGetAllDoer,
            IDeveloperGetByIdDoer developerGetByIdDoer,
            IDeveloperSaveAcceptanceDoer developerSaveAcceptanceDoer,
            IDeveloperSaveRejectionDoer developerSaveRejection,
            IDeveloperSubmitDoer developerSubmitDoer,
            IZEsLiteSmallDBContext contetex)
            : base(developerGetAllDoer, developerGetByIdDoer, developerSaveAcceptanceDoer,
                  developerSaveRejection, developerSubmitDoer)
        {
            LiteSmallDBContext context =
                new LiteSmallDBContext(contetex.ConnectionString);

            this.ChangeContext(context);
        }
    }
}
