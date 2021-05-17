using AutoMapper;
using Dapper;
using LiteSmallConference.Domain.ValueObject;
using LiteSmallConference.Domain.ValueObjects;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace LiteSmallConference.Persitence.Dapper.SQLite.Methods.Developers
{
    public class DeveloperSaveRejectionDoer : BeforeDoer, IDeveloperSaveRejectionDoer
    {

        private readonly IMapper _mapper;

        public DeveloperSaveRejectionDoer
            (ILiteSmallDBContext geekLemonContext,
            IMapper mapper)
        {
            _geekLemonContext = geekLemonContext;
            _mapper = mapper;
        }



        public async Task Run(DeveloperUniqueId id)
        {
            using var connection = new SQLiteConnection
                                    (_geekLemonContext.ConnectionString);

            var q = @"UPDATE Developers
                SET Status = @Status
                WHERE UniqueId = @UniqueId;";

            try
            {
                var result = await connection.ExecuteAsync(q,
                 new
                 {
                     @UniqueId = id.Value.ToString(),
                     @Status = (int)DeveloperStatus.Rejected
                 });
            }
            catch (Exception ex)
            {

            }
        }

        public async Task Run(DeveloperId id)
        {
            using var connection = new SQLiteConnection
                                    (_geekLemonContext.ConnectionString);

            var q = @"UPDATE Developers
                SET Status = @Status
                WHERE Id = @Id;";

            try
            {
                var result = await connection.ExecuteAsync(q,
                 new
                 {
                     @Id = id.Value.ToString(),
                     @Status = (int)DeveloperStatus.Rejected
                 });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
