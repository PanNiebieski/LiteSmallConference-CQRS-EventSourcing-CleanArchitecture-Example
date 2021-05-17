using LiteSmallConference.Application.CQRS;
using LiteSmallConference.Infrastructure.BackgroundEventHandlersServer.Subscribers;
using LiteSmallConference.Infrastructure.BackgroundEventHandlersServer.Subscribers.Developers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Linq;
using System.Reflection;

namespace LiteSmallConference.Infrastructure.BackgroundEventHandlersServer
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddPersitenceDapperSQLite(Configuration);

            var seriFileLogger = new LoggerConfiguration().WriteTo.File(@"D:\Temp\").CreateLogger();
            services.AddSingleton<Serilog.ILogger>(seriFileLogger);

            services.AddSingleton<ISettings>(new Settings()
            {
                Timeout = TimeSpan.FromSeconds(5),
                Frequency = TimeSpan.FromSeconds(5),
            });

            //dont change the order
            services.AddTransient<ISubscribeBase, SubscribeSubmitDeveloper>();
            services.AddTransient<ISubscribeBase, SubscribeAcceptDeveloper>();
            services.AddTransient<ISubscribeBase, SubscribeRejectDeveloper>();


            services.AddTransient<ISubscribeBase[]>
                (p => p.GetServices<ISubscribeBase>().ToArray());

            services.AddHostedService<BackgroundEventHandlersServerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.
                    Response.WriteAsync
                    ("LiteSmallConference.Infrastructure.BackgroundEventHandlersServer Working");
                });
            });
        }
    }
}
