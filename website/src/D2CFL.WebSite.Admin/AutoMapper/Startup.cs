using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.WebSite.Admin.AutoMapper
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(Startup).Assembly,
                typeof(Business.League.Mappings.PlayerProfile).Assembly,
                typeof(Business.League.Mappings.PositionProfile).Assembly,
                typeof(Business.League.Mappings.TeamProfile).Assembly,
                typeof(Mappings.PlayerProfile).Assembly,
                typeof(Mappings.PositionProfile).Assembly,
                typeof(Mappings.TeamProfile).Assembly
            );
        }
    }
}