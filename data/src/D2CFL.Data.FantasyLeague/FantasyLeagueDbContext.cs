//using Aurochses.Data.EntityFrameworkCore;

using D2CFL.Data.FantasyLeague.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class FantasyLeagueDbContext : DbContextBase<FantasyLeagueDbContext>
    {
        public FantasyLeagueDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MatchConfiguration(SchemaName));
            builder.ApplyConfiguration(new OrganizationConfiguration(SchemaName));
            builder.ApplyConfiguration(new ParticipantConfiguration(SchemaName));
            builder.ApplyConfiguration(new PlayerConfiguration(SchemaName));
            //builder.ApplyConfiguration(new PlayerStatsConfiguration(SchemaName));
            builder.ApplyConfiguration(new PositionConfiguration(SchemaName));
            builder.ApplyConfiguration(new TournamentConfiguration(SchemaName));
        }
    }
}
