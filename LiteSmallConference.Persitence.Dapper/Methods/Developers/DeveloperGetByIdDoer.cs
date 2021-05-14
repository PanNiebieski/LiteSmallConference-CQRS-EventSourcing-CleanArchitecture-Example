using AutoMapper;
using Dapper;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Map;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Developers
{
    public class DeveloperGetByIdDoer : BeforeDoer, IDeveloperGetByIdDoer
    {


        private readonly IMapper _mapper;

        public DeveloperGetByIdDoer
            (ILiteSmallDBContext geekLemonContext,
            IMapper mapper)
        {
            _geekLemonContext = geekLemonContext;
            _mapper = mapper;
        }


        public async Task<Developer> Run(DeveloperId id)
        {
            using var connection = new SQLiteConnection
                           (_geekLemonContext.ConnectionString);

            var q = @$"SELECT Id,UniqueId,Name,Status FROM Developers
                    WHERE Id = @Id";

            try
            {
                var r = await connection.
                QueryFirstOrDefaultAsync<DevloperTemp>
                (q, new
                {
                    @Id = id.Value,
                });

                var rmaped = _mapper.Map<Developer>(r);

                return rmaped;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Developer> Run(DeveloperUniqueId id)
        {
            using var connection = new SQLiteConnection
                           (_geekLemonContext.ConnectionString);

            var q = @$"SELECT Id,UniqueId,Name,Status FROM Developers
                    WHERE UniqueId = @UniqueId";

            try
            {
                var r = await connection.
                QueryFirstOrDefaultAsync<DevloperTemp>
                (q, new
                {
                    @UniqueId = id.Value,
                });



                var rmaped = _mapper.Map<Developer>(r);

                return rmaped;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
