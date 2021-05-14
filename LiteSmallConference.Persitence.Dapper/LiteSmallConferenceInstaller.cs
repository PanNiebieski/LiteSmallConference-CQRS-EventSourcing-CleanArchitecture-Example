
using LiteSmallConference.Application.Contracts.Persitence;
using LiteSmallConference.Persitence.Dapper.SQLite.Config;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Developers;
using LiteSmallConference.Persitence.Dapper.SQLite.Methods.Interfaces.Developers;
using LiteSmallConference.Persitence.Dapper.SQLite.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LiteSmallConference.Application.CQRS
{
    public static partial class LiteSmallConferenceInstaller
    {

        public static IServiceCollection AddPersitenceDapperSQLite
        (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var connection = configuration.
                GetConnectionString("LiteSmallConferenceConnectionString");
            var zEsConnection = configuration.
                GetConnectionString("ZEsLiteSmallConferenceConnectionString");

            services.AddTransient<ILiteSmallDBContext, LiteSmallDBContext>
                (
                    (services) =>
                    {
                        var c =
                        new LiteSmallDBContext(connection);
                        return c;
                    }
                );

            services.AddTransient<IZEsLiteSmallDBContext, LiteSmallDBContext>
            (
                (services) =>
                {
                    var c =
                    new LiteSmallDBContext(zEsConnection);
                    return c;
                }
            );

            services.AddTransient<IDeveloperGetAllDoer, DeveloperGetAllDoer>();
            services.AddTransient<IDeveloperGetByIdDoer, DeveloperGetByIdDoer>();
            services.AddTransient<IDeveloperSaveAcceptanceDoer, DeveloperSaveAcceptanceDoer>();
            services.AddTransient<IDeveloperSaveRejectionDoer, DeveloperSaveRejectionDoer>();
            services.AddTransient<IDeveloperSubmitDoer, DeveloperSubmitDoer>();

            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IZEsDeveloperRepository, ZEsDeveloperRepository>();

            return services;
        }

    }
}
