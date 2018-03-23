using D2CFL.Data.League.Entities;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.League
{
    public class LeagueDbContext : DbContextBase
    {
        public LeagueDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {

        }

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}