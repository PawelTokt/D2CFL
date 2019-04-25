using System;
using Aurochses.Data;
using Aurochses.Data.EntityFrameworkCore;
using Autofac;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Data.FantasyLeague
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repositoeis
            builder.RegisterType<Repository<MatchEntity, Guid>>().As<IRepository<MatchEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<OrganizationEntity, Guid>>().As<IRepository<OrganizationEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PlayerEntity, Guid>>().As<IRepository<PlayerEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PlayerStatsEntity, Guid>>().As<IRepository<PlayerStatsEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PositionEntity, Guid>>().As<IRepository<PositionEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<TournamentEntity, Guid>>().As<IRepository<TournamentEntity, Guid>>().InstancePerLifetimeScope();
        }
    }
}
