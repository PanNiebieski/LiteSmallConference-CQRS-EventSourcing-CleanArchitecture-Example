using AutoMapper;
using Dapper;
using LiteSmallConference.Domain.Entity;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Domain.ValueObjects.Identities;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Map;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Developers
{
    class DeveloperSubmitDoer : BeforeDoer, IDeveloperSubmitDoer
    {
        private readonly IMapper _mapper;

        public DeveloperSubmitDoer
            (ILiteSmallDBContext geekLemonContext,
            IMapper mapper)
        {
            _geekLemonContext = geekLemonContext;
            _mapper = mapper;
        }


        public async Task<DeveloperIds> Run(Developer dev)
        {
            var temp = _mapper.Map<DevloperTemp>(dev);
            temp.Status = 0;

            using var connection = new SQLiteConnection
                                        (_geekLemonContext.ConnectionString);

            var q = @"INSERT INTO Developers  (Name, UniqueId, Status) 
                VALUES (@Name, @UniqueId, @Status);
                SELECT seq From sqlite_sequence Where Name='Developers';";



            try
            {
                var result = await connection.QueryAsync<int>(q, temp);

                int createdId = result.FirstOrDefault();

                DeveloperIds ids = new DeveloperIds()
                {
                    CreatedId = new DeveloperId(createdId),
                    UniqueId = dev.UniqueId
                };

                return ids;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
