using D2CFL.Data.League;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Migrations.Context
{
    public class LeagueContext : LeagueDbContext
    {
        public LeagueContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions, Configuration.LeagueSchema)
        {

        }
    }
}