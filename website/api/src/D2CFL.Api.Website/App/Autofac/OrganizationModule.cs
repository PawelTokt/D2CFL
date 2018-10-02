using Aurochses.Module.Autofac.EntityFrameworkCore;
using Autofac;
using D2CFL.Business.Organization;
using D2CFL.Data.Organization;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Api.Website.App.Autofac
{
    public class OrganizationModule : ModuleBase
    {
        public OrganizationModule(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new BusinessModule(DbContextOptions, SchemaName));
        }
    }
}