using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class PlayerStatisticsEntity : EntityNoneDatabaseGeneratedIdentifier<Guid>
    {
        public int MatchesPlayed { get; set; }
        public int TotalKills { get; set; }
        public int TotalAssists { get; set; }
        public int TotalDeaths { get; set; }
        public double TotalPoints { get; set; }
        public double AverageKills { get; set; }
        public double AverageAssists { get; set; }
        public double AverageDeaths { get; set; }
        public double AveragePoints { get; set; }

        public virtual PlayerEntity Player { get; set; }
    }
}
