using System.Collections.Generic;
using Autofac;
using AutoMapper;
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
           
            // Applications
            services.Configure<List<Application>>(Configuration.GetSection("Applications"));

            // MVC
            services.AddMvc();
        }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
       
            // StaticFiles
            app.UseStaticFiles();

            //MVC
            app.UseMvc();
        }
    }
}
