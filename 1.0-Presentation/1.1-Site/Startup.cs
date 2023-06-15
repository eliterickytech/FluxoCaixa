using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rickytech.DependencyInjection.Configurations;
using Microsoft.Extensions.Logging;
using Serilog;
using Site.Middleware;

namespace Site
{
	public class Startup
	{
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InfrastructureConfiguration.AddConfiguration(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services
                  .AddApplicationConfiguration(Configuration);

            services
                .AddInfrastructureConfiguration(Configuration);

        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
				//app.UseDeveloperExceptionPage();
				app.UseExceptionHandler("/error");
			}
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddSerilog();

			//app.UseMyErrorHandler();

			app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

			
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
