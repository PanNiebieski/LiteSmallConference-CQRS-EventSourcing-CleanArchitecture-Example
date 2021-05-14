using AutoMapper;
using Dapper;
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Map;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Developers
{
    class DeveloperGetAllDoer : BeforeDoer, IDeveloperGetAllDoer
    {
        private readonly IMapper _mapper;

        public DeveloperGetAllDoer
            (ILiteSmallDBContext geekLemonContext,
            IMapper mapper)
        {
            _geekLemonContext = geekLemonContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Developer>> Run(FilterDeveloperStatus filtrer)
        {
            using var connection = new SQLiteConnection
                             (_geekLemonContext.ConnectionString);

            IEnumerable<DevloperTemp> r;

            var q = @$"SELECT
                Id,UniqueId,Name,Status FROM Developers";

            if (filtrer == FilterDeveloperStatus.All)
            {
                r = await connection.QueryAsync<DevloperTemp>(q);
            }
            else
            {
                r = await connection.QueryAsync<DevloperTemp>
                    (q + " WHERE Status = @st;"
                    , new { st = (int)filtrer });
            }

            var rmaped = _mapper.Map<IEnumerable<Developer>>(r);

            return rmaped.ToList().AsReadOnly();

        }
    }
}
