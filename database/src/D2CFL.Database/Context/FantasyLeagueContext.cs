using D2CFL.Data.FantasyLeague;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Database.Context
{
    public class FantasyLeagueContext : FantasyLeagueDbContext
    {
        public FantasyLeagueContext(DbContextOptions<FantasyLeagueDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}