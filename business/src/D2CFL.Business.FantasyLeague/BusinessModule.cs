using Aurochses.Data;
using Aurochses.Data.AutoMapper;
using Autofac;
using D2CFL.Business.FantasyLeague.Contract.Organization;
using D2CFL.Business.FantasyLeague.Contract.Player;
using D2CFL.Business.FantasyLeague.Contract.Position;
using D2CFL.Data.FantasyLeague;

namespace D2CFL.Business.FantasyLeague
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());

            // AutoMapper
            builder.RegisterType<DataMapper>().As<IDataMapper>().InstancePerLifetimeScope();

            // Services
            builder.RegisterType<OrganizationService>().As<IOrganizationService>().InstancePerLifetimeScope();
            builder.RegisterType<PlayerService>().As<IPlayerService>().InstancePerLifetimeScope();
            builder.RegisterType<PositionService>().As<IPositionService>().InstancePerLifetimeScope();
        }
    }
}