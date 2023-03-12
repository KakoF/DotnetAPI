using Domain.Abstractions;
using Domain.DTO.IsSimianDTO.Validators;
using Domain.DTO.IsSimianDTO;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation;
using Infra.Repositories;
using Service.Implementations;
using Service.Services;
using Domain.Interfaces.Notifications;
using Domain.Notifications;
using Domain.Interfaces.Clients;
using IntegratorHttpClient.Implementations;
using Infra.DataConnector;
using Infra.Interfaces;
using Domain.Interfaces.Cache;
using Infra.Caching;
using IntegratorMessageQueue.Interfaces.RabbitMq;
using IntegratorMessageQueue.RabbitMq;

namespace SimianApplication.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            
            builder.Services.AddSingleton<IRabbitMqIntegrator>(sp =>
            {
                var rabbitLooger = sp.GetRequiredService<ILogger<RabbitMqIntegrator>>();
                var connection = builder.Configuration["ConnectionStrings:rabbit:connection"];
                return new RabbitMqIntegrator(rabbitLooger, connection);
            });

            builder.Services.AddScoped<IDbConnector>(db => new PostgreeConnector(builder.Configuration["ConnectionStrings:postgree"]));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration["ConnectionStrings:redis:connection"];
                options.InstanceName = builder.Configuration["ConnectionStrings:redis:key"];
            });
            services.AddMemoryCache();


            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
            services.AddScoped<ISimianRepository, SimianRepository>();
            services.AddScoped<ISimianCalcRepository, SimianCalcRepository>();
            services.AddScoped<ISimianCalcService, SimanCalcService>();
            services.AddScoped<IStatsService, StatsService>();
            services.AddScoped<ISimianService, SimianService>();
            services.AddScoped<IAdviceService, AdviceService>();
            services.AddScoped<IChuckNorrisService, ChuckNorrisService>();
            services.AddScoped<ISimianPatternsExecute, SimianPatternsExecute>();

            services.AddScoped<SimianPatternAbstract, DiagonalSimianPattern>();
            services.AddScoped<SimianPatternAbstract, HorizontalSimianPattern>();
            services.AddScoped<SimianPatternAbstract, VerticalSimianPattern>();
            
            services.AddScoped<ICacheMethods, CacheMethods>();
            services.AddScoped<IMemoryStorageCache, MemoryStorageCache>();
            services.AddScoped<IRedisStorageCache, RedisStorageCache>();



            services.AddTransient<IValidator<IsSimianRequestDTO>, IsSimianValidator>();

            services.AddHttpClient<IAdviceClient, AdviceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["Clients:Advice:basePath"]);
            });

            services.AddHttpClient<IChuckNorrisClient, ChuckNorrisClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["Clients:ChuckNorris:basePath"]);
            });

            return services;
        }
    }
}
