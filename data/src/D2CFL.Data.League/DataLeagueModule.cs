using Autofac;
using D2CFL.Data.Interfaces;
using D2CFL.Data.League.Contract;

namespace D2CFL.Data.League
{
    public class DataLeagueModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Repository<PlayerEntity>>().As<IRepository<PlayerEntity>>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<Repository<PositionEntity>>().As<IRepository<PositionEntity>>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<Repository<TeamEntity>>().As<IRepository<TeamEntity>>()
                .InstancePerLifetimeScope();
        }
    }
}