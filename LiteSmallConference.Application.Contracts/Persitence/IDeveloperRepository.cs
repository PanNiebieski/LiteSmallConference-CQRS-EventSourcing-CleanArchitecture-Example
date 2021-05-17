using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Domain.ValueObjects.Identities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiteSmallConference.Application.Contracts.Persitence
{
    public interface IDeveloperRepository
    {
        Task<IReadOnlyList<Developer>> GetCollectionAsync(
            FilterDeveloperStatus filtrer);

        Task<Developer> GetByIdAsync(DeveloperId id);

        Task<Developer> GetByIdAsync(DeveloperUniqueId id);


        Task<DeveloperIds> SubmitAsync(Developer callForSpeech);

        Task<bool> SaveAcceptenceAsync(DeveloperUniqueId id);

        Task<bool> SaveAcceptenceAsync(DeveloperId id);

        Task<bool> SaveRejectionAsync(DeveloperUniqueId id);

        Task<bool> SaveRejectionAsync(DeveloperId id);



    }


    public interface IZEsDeveloperRepository : IDeveloperRepository
    {

    }
}
