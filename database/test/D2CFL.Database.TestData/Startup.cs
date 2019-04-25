using D2CFL.Database.TestData.FantasyLeague;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.Database.TestData
{
    public class Startup : Database.Startup
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient<FantasyLeagueService>();

            services.AddTransient<Service>();
        }
    }
}
