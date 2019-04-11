using Aurochses.Data;
using Aurochses.Data.AutoMapper;
using Autofac;
using D2CFL.Business.FantasyLeague;

namespace D2CFL.Api.Website.App.Autofac
{
    public static class Startup
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessModule());

            builder.RegisterType<DataMapper>().As<IDataMapper>().InstancePerLifetimeScope();
        }

        //public static void ConfigureContainer(ContainerBuilder builder, IConfiguration configuration)
        //{
        //    // AutoMapper
        //    builder.RegisterType<DataMapper>().As<IDataMapper>().InstancePerLifetimeScope();

        //    // Organization
        //    builder.RegisterModule(
        //        new OrganizationModule(
        //            new DbContextOptionsBuilder<OrganizationDbContext>()
        //                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        //                .Options,
        //            "organization"
        //        )
        //    );

        //    builder.RegisterType<OrganizationService>().As<IOrganizationService>().InstancePerLifetimeScope();
        //    builder.RegisterType<PositionService>().As<IPositionService>().InstancePerLifetimeScope();
        //    builder.RegisterType<PlayerService>().As<IPlayerService>().InstancePerLifetimeScope();
        //}
    }
}