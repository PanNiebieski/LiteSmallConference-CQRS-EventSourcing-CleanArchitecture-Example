using GeekLemon.Infrastructure.Write.MongoDB.Bus;
using LiteSmallConference.Application.EventSourcing.Contracts;
using LiteSmallConference.Infrastructure.EventStoreAndBus.Repositories.EventStore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeekLemonConference.Infrastructure.EventStoreAndBus
{
    public static partial class LiteSmallConferenceInstaller
    {
        public static IServiceCollection
        AddDefaultEventStore(this IServiceCollection services)
        {
            services.AddScoped<IEventStore, InMemoryEventStore>();
            return services;
        }

        public static IServiceCollection AddEventSourcing
        (this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddOptions();

            AddOption<RabbitMqConfiguration>(services, configuration);
            services.AddScoped<ISessionForEventSourcing, SessionForEventSourcing>();
            services.AddSingleton<IEventPublisher, LiteSmallEventPublisher>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddScoped<IEventRepository, CacheRepository>((services) =>
            {
                var iEventStore = services.GetRequiredService<IEventStore>();
                var iEventPublisher = services.GetRequiredService<IEventPublisher>();
                var eventRepository = new EventRepository(iEventStore, iEventPublisher);

                return new CacheRepository(eventRepository, iEventStore);
            });

            return services;
        }

        private static void AddOption<T>(IServiceCollection services, IConfiguration configuration) where T : class
        {
            services.Configure<T>(configuration.GetSection(typeof(T).Name));
        }
    }
}
