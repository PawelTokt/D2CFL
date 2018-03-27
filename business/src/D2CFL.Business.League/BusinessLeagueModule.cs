using Autofac;
using D2CFL.Data.League;
using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Business.League
{
    public class BusinessLeagueModule : Module
    {
        private readonly DbContextOptions _dbContextOptions;
        private readonly string _schemaName;


        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<LeagueUnitOfWork>().As<ILeagueUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}