using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers
{
    public interface IDeveloperGetAllDoer : IBeforeDoer
    {
        Task<IReadOnlyList<Developer>> Run(FilterDeveloperStatus filtrer);
    }
}
