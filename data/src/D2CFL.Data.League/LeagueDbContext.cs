using Microsoft.EntityFrameworkCore;
using D2CFL.Data.League.EntitiesConfigurations;

namespace D2CFL.Data.League
{
    /// <summary>
    /// Class LeagueDbContext.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.DbContextBase"/>
    public class LeagueDbContext : DbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">The database context options.</param>
        /// <param name="schemaName">Name of the schema.</param>
        public LeagueDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {

        }

        /// <summary>
        /// Applying the configuration of dbContext entities.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerEntityConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new TeamEntityConfiguration(SchemaName));
            modelBuilder.ApplyConfiguration(new PositionEntityConfiguration(SchemaName));
        }
    }
}