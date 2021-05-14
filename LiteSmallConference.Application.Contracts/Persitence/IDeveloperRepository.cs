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

        Task SaveAcceptenceAsync(DeveloperUniqueId id);

        Task SaveAcceptenceAsync(DeveloperId id);

        Task SaveRejectionAsync(DeveloperUniqueId id);

        Task SaveRejectionAsync(DeveloperId id);



    }


    public interface IZEsDeveloperRepository : IDeveloperRepository
    {

    }
}
