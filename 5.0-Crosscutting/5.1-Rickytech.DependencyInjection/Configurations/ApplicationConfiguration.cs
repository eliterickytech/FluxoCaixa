using Rickytech.Application;

using Rickytech.Domain.Interfaces;
using Rickytech.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rickytech.Domain.Interfaces.Services;
using Rickytech.Application.RickytechApp;
using Rickytech.Application.RickytechApp.Interfaces;

namespace Rickytech.DependencyInjection.Configurations
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFlowRepository, FlowRepository>();

            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IFlowServices, FlowServices>();

            return services;
        }

    }
}
