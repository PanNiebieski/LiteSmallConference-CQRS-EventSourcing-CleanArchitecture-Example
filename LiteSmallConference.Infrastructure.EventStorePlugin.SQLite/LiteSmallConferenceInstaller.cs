
using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.Infrastructure.EventStorePlugin.SQLite;
using LiteSmallConference.Infrastructure.EventStorePlugin.SQLite.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeekLemonConference.Infrastructure.EventStore.SQLite
{
    public static partial class LiteSmallConferenceInstaller
    {
        public static IServiceCollection
            AddEventStoreSqlLite
            (this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.
                GetConnectionString("EventStoreSQLiteConnectionString");

            services.AddScoped<IEventStoreSQLiteContext, EventStoreSQLiteContext>
                (
                    (services) =>
                    {
                        var c =
                        new EventStoreSQLiteContext(connection);
                        return c;
                    }
                );

            services.AddScoped<IEventStore, SqlLiteEventStore>();

            return services;
        }
    }
}
