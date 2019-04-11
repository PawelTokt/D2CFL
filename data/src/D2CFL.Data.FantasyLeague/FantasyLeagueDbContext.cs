using Aurochses.Data.EntityFrameworkCore;
using D2CFL.Data.FantasyLeague.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class FantasyLeagueDbContext : DbContextBase
    {
        public FantasyLeagueDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions, SetSchemaName())
        {
            
        }

        public static string SetSchemaName()
        {
            var className = typeof(FantasyLeagueDbContext).Name;

            var schemaname = className.Replace("Db", "").Replace("Context", "").ToLower();

            return schemaname;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new OrganizationConfiguration(SchemaName));
            builder.ApplyConfiguration(new PlayerConfiguration(SchemaName));
            builder.ApplyConfiguration(new PositionConfiguration(SchemaName));
        }
    }
}