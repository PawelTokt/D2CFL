using System.Collections.Generic;
using Aurochses.Module.Business.Autofac.EntityFrameworkCore;
using Autofac;
using Autofac.Core;
using D2CFL.Data.Organization;
using D2CFL.Data.Organization.Contract;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Business.Organization
{
    public class BusinessModule : BusinessModuleBase
    {
        public BusinessModule(DbContextOptions dbContextOptions, string shemaName)
            : base(dbContextOptions, shemaName)
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrganizationUnitOfWork>().As<IOrganizationUnitOfWork>()
                .WithParameters(
                    new List<Parameter>
                    {
                        new NamedParameter(DbContextOptionsParameter, DbContextOptions),
                        new NamedParameter(SchemaNameParameter, SchemaName)
                    })
                .InstancePerLifetimeScope();
        }
    }
}
