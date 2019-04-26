using Aurochses.Data.Autofac.EntityFrameworkCore;
using Autofac;
using D2CFL.Business.FantasyLeague;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Api.Website.App.Autofac
{
    public class FantasyLeagueModule : ModuleBase
    {
        public FantasyLeagueModule(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessModule(DbContextOptions, SchemaName));
        }
    }
}
