using Aurochses.Data;
using Aurochses.Data.AutoMapper;
using Autofac;
using D2CFL.Business.Organization;
using D2CFL.Business.Organization.Contract.Organization;
using D2CFL.Data.Organization;
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

            //Organization
            builder.RegisterModule(
                new OrganizationModule(
                    new DbContextOptionsBuilder<OrganizationDbContext>()
                        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                        .Options,
                    "organization"
                )
            );

            builder.RegisterType<OrganizationService>().As<IOrganizationService>().InstancePerLifetimeScope();
        }
    }
}
