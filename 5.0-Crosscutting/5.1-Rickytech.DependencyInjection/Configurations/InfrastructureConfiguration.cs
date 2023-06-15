using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rickytech.DependencyInjection.Configurations;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Microsoft.Extensions.Logging;
using System;

namespace Rickytech.DependencyInjection.Configurations
{
    public static class InfrastructureConfiguration
    {

        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetSection("ConnectionStrings:ConnectionRedis").Value;
            });

            return services;
        }

        public static void AddConfiguration(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration.GetSection("ElasticConfiguration:Uri").Value))
                {
                    AutoRegisterTemplate = true,
                })
            .CreateLogger();

        }
    }
}
