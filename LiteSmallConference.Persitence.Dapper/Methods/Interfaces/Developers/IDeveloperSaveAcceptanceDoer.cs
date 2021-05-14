using LiteSmallConference.Domain.ValueObjects;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers
{
    public interface IDeveloperSaveAcceptanceDoer : IBeforeDoer
    {
        Task Run(DeveloperUniqueId id);

        Task Run(DeveloperId id);
    }
}
