using System;
using Aurochses.Data;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Module.Data.Autofac;
using Autofac;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Data.Organization
{
    public class DataModule : DataModuleBase
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<OrganizationEntity, Guid>>().As<IRepository<OrganizationEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PositionEntity, Guid>>().As<IRepository<PositionEntity, Guid>>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<PlayerEntity, Guid>>().As<IRepository<PlayerEntity, Guid>>().InstancePerLifetimeScope();
        }
    }
}