using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects.Identities;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers
{
    public interface IDeveloperSubmitDoer : IBeforeDoer
    {
        Task<DeveloperIds>
               Run(Developer callForSpeech);
    }
}
