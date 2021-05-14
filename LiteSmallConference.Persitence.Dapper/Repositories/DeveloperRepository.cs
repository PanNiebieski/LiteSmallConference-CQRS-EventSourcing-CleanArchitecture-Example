using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Domain.ValueObjects.Identities;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private IDeveloperGetAllDoer _developerGetAllDoer;
        private IDeveloperGetByIdDoer _developerGetByIdDoer;
        private IDeveloperSaveAcceptanceDoer _developerSaveAcceptanceDoer;
        private IDeveloperSaveRejectionDoer _developerSaveRejection;
        private IDeveloperSubmitDoer _developerSubmitDoer;

        public DeveloperRepository(IDeveloperGetAllDoer developerGetAllDoer,
            IDeveloperGetByIdDoer developerGetByIdDoer,
            IDeveloperSaveAcceptanceDoer developerSaveAcceptanceDoer,
            IDeveloperSaveRejectionDoer developerSaveRejection,
            IDeveloperSubmitDoer developerSubmitDoer)
        {
            _developerGetAllDoer = developerGetAllDoer;
            _developerGetByIdDoer = developerGetByIdDoer;
            _developerSaveAcceptanceDoer = developerSaveAcceptanceDoer;
            _developerSaveRejection = developerSaveRejection;
            _developerSubmitDoer = developerSubmitDoer;
        }


        public void ChangeContext(ILiteSmallDBContext geekLemonDB)
        {
            _developerGetAllDoer.ChangeDBContext(geekLemonDB);
            _developerGetByIdDoer.ChangeDBContext(geekLemonDB);
            _developerSaveAcceptanceDoer.ChangeDBContext(geekLemonDB);
            _developerSaveRejection.ChangeDBContext(geekLemonDB);
            _developerSubmitDoer.ChangeDBContext(geekLemonDB);
        }

        public Task<Developer> GetByIdAsync(DeveloperId id)
        {
            return _developerGetByIdDoer.Run(id);
        }

        public Task<Developer> GetByIdAsync(DeveloperUniqueId id)
        {
            return _developerGetByIdDoer.Run(id);
        }

        public Task<IReadOnlyList<Developer>> GetCollectionAsync(FilterDeveloperStatus filtrer)
        {
            return _developerGetAllDoer.Run(filtrer);
        }

        public Task SaveAcceptenceAsync(DeveloperUniqueId id)
        {
            return _developerSaveAcceptanceDoer.Run(id);
        }

        public Task SaveAcceptenceAsync(DeveloperId id)
        {
            return _developerSaveAcceptanceDoer.Run(id);
        }

        public Task SaveRejectionAsync(DeveloperUniqueId id)
        {
            return _developerSaveRejection.Run(id);
        }

        public Task SaveRejectionAsync(DeveloperId id)
        {
            return _developerSaveRejection.Run(id);
        }

        public Task<DeveloperIds> SubmitAsync(Developer d)
        {
            return _developerSubmitDoer.Run(d);
        }
    }
}
