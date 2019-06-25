using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.Api.Website.App.AutoMapper
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(Startup).Assembly,
                typeof(Business.FantasyLeague.BusinessModule).Assembly
            );
        }
    }
}