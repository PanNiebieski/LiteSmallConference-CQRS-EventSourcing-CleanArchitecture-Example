using LiteSmallConference.Domain.ValueObjects;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers
{
    public interface IDeveloperSaveRejectionDoer : IBeforeDoer
    {
        Task Run(DeveloperUniqueId id);

        Task Run(DeveloperId id);
    }
}
