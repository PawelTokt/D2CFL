using Aurochses.Data;
using Aurochses.Data.AutoMapper;
using Autofac;
using D2CFL.Data.FantasyLeague;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Api.Website.App.Autofac
{
    public static class Startup
    {
        public static void ConfigureContainer(ContainerBuilder builder, IConfiguration configuration)
        {
            // AutoMapper
            builder.RegisterType<DataMapper>().As<IDataMapper>().InstancePerLifetimeScope();

            // FantasyLeague
            builder.RegisterModule(
                new FantasyLeagueModule(
                    new DbContextOptionsBuilder<FantasyLeagueDbContext>()
                        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                        .Options,
                    null
                )
            );
        }
    }
}