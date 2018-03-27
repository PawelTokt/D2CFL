using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using D2CFL.Data.League;
using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Business.League
{
    public class BusinessLeagueModule : Module
    {
        private readonly DbContextOptions _dbContextOptions;
        private readonly string _schemaName;

        public BusinessLeagueModule(DbContextOptions dbContextOptions, string schemaName)
        {
            _dbContextOptions = dbContextOptions;
            _schemaName = schemaName;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<LeagueUnitOfWork>().As<ILeagueUnitOfWork>()
                .WithParameters(
                    new List<Parameter>
                    {
                        new NamedParameter("dbContextOptions", _dbContextOptions),
                        new NamedParameter("schemaName", _schemaName)
                    })
                .InstancePerLifetimeScope();
        }
    }
}