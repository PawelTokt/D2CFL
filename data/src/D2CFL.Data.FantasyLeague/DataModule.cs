using System;
using Aurochses.Data;
using Aurochses.Data.EntityFrameworkCore;
using Autofac;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Data.FantasyLeague
{
    public class DataModule : Module {

        protected override void Load(ContainerBuilder builder)
        {
            // Repositoeis
            builder.RegisterType<Repository<OrganizationEntity, Guid>>().As<IRepository<OrganizationEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PositionEntity, Guid>>().As<IRepository<PositionEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PlayerEntity, Guid>>().As<IRepository<PlayerEntity, Guid>>().InstancePerLifetimeScope();

            // UnitOfWork
            builder.RegisterType<FantasyLeagueUnitOfWork>().As<IFantasyLeagueUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}