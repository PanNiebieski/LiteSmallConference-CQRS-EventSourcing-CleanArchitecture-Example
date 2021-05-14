using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers
{
    public interface IDeveloperGetByIdDoer : IBeforeDoer
    {
        Task<Developer> Run(DeveloperId id);

        Task<Developer> Run(DeveloperUniqueId id);
    }
}
