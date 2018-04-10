using Autofac;
using D2CFL.Data;
using D2CFL.Data.League;
using D2CFL.Business.League;
using D2CFL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using D2CFL.Business.League.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Website.Admin.Autofac
{
    public static class Startup
    {
        public static void ConfigureContainer(ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            // AutoMapper
            containerBuilder.RegisterType<DataMapper>().As<IDataMapper>().InstancePerLifetimeScope();

            //League
            containerBuilder.RegisterModule(
                new LeagueModule(
                    new DbContextOptionsBuilder<LeagueDbContext>()
                        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                        .Options,
                    "league"
                )
            );

            containerBuilder.RegisterType<PlayerService>().As<IPlayerService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<TeamService>().As<ITeamService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<PositionService>().As<IPositionService>().InstancePerLifetimeScope();
        }
    }
}