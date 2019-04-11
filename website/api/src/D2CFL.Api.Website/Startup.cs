using System.Collections.Generic;
using Autofac;
using D2CFL.Api.Website.Settings;
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
            App.Logging.Startup.ConfigureServices(services, Configuration);

            // Cors
            App.Cors.Startup.ConfigureServices(services);

            // AutoMapper
            App.AutoMapper.Startup.ConfigureServices(services);

            // Swagger
            App.Swagger.Startup.ConfigureServices(services, Configuration);

            // Applications
            services.Configure<List<Application>>(Configuration.GetSection("Applications"));

            // MVC
            services.AddMvc(
                //config =>
                //{
                //    config.Filters.Add(
                //        // Authorize All
                //        new AuthorizeFilter(
                //            new AuthorizationPolicyBuilder()
                //                .RequireAuthenticatedUser()
                //                .Build()
                //        )
                //    );
                //}
            );
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Autofac
            //App.Autofac.Startup.ConfigureContainer(builder, Configuration);
            App.Autofac.Startup.ConfigureContainer(builder, Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Exception
            App.ExceptionHandler.Startup.Configure(app, env, Configuration);

            // Cors
            App.Cors.Startup.Configure(app);

            // Swagger
            App.Swagger.Startup.Configure(app, Configuration);

            // StaticFiles
            app.UseStaticFiles();

            //MVC
            app.UseMvc();
        }
    }
}