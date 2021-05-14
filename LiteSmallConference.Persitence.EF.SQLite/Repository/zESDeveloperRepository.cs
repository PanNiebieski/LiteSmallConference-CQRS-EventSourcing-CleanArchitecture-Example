using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Domain.ValueObjects.Identities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.EF.SQLite.Repository
{
    public class zESDeveloperRepository : IZEsDeveloperRepository
    {
        protected readonly zESLiteSmallConferenceContext _dbContext;

        public zESDeveloperRepository(zESLiteSmallConferenceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Developer> GetByIdAsync(DeveloperId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Developer> GetByIdAsync(DeveloperUniqueId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Developer>> GetCollectionAsync(FilterDeveloperStatus filtrer)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAcceptenceAsync(DeveloperUniqueId id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAcceptenceAsync(DeveloperId id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveRejectionAsync(DeveloperUniqueId id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveRejectionAsync(DeveloperId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<DeveloperIds> SubmitAsync(Developer callForSpeech)
        {
            throw new System.NotImplementedException();
        }
    }
}
