using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace D2CFL.Api.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Logging
            App.Logging.Startup.ConfigureService(services, Configuration);

            // Cors
            App.Cors.Startup.ConfigureServices(services);

            // AutoMapper
            App.AutoMapper.Startup.ConfigureServices(services);

            // MVC
            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Autofac
            App.Autofac.Startup.ConfigureContainer(builder, Configuration);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Exception
            App.ExceptionHandler.Startup.Configure(app, env, Configuration);

            // Cors
            App.Cors.Startup.Configure(app);

            // StaticFiles
            app.UseStaticFiles();

            //MVC
            app.UseMvc();
        }
    }
}
