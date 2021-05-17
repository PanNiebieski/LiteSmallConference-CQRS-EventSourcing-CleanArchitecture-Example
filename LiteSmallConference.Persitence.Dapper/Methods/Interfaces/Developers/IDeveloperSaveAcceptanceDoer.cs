using LiteSmallConference.Domain.ValueObjects;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers
{
    public interface IDeveloperSaveAcceptanceDoer : IBeforeDoer
    {
        Task<bool> Run(DeveloperUniqueId id);

        Task<bool> Run(DeveloperId id);
    }
}
