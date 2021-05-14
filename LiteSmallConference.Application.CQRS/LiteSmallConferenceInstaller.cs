
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LiteSmallConference.Application.CQRS
{
    public static partial class LiteSmallConferenceInstaller
    {

        public static IServiceCollection AddLiteSmallConferenceCQRS
    (this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
