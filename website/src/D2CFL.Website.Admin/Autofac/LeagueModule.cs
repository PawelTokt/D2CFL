using Autofac;
using D2CFL.Data.League;
using D2CFL.Business.League;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Website.Admin.Autofac
{
    public class LeagueModule : Module
    {
        private readonly DbContextOptions _dbContextOptions;
        private readonly string _schemaName;

        public LeagueModule(DbContextOptions dbContextOptions, string schemaName)
        {
            _dbContextOptions = dbContextOptions;
            _schemaName = schemaName;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new DataLeagueModule());
            containerBuilder.RegisterModule(new BusinessLeagueModule(_dbContextOptions, _schemaName));
        }
    }
}