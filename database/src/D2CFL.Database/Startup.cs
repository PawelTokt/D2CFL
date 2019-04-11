using D2CFL.Database.Context;
//using Aurochses.Database.EntityFrameworkCore;
using D2CFL.Data.FantasyLeague;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.Database
{
    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BaseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<FantasyLeagueContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<FantasyLeagueDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public override void Configure(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<FantasyLeagueContext>().Database.Migrate();
            }
        }
    }
}