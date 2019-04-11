using Autofac;
using D2CFL.Business.FantasyLeague;

namespace D2CFL.Api.Website.App.Autofac
{
    public static class Startup
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessModule());
        }


        // OLD SOLUTION
        //public static void ConfigureContainer(ContainerBuilder builder, IConfiguration configuration)
        //{
        //    builder.RegisterModule(
        //        new OrganizationModule(
        //            new DbContextOptionsBuilder<OrganizationDbContext>()
        //                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        //                .Options,
        //            "organization"
        //        )
        //    );
        //}
    }
}