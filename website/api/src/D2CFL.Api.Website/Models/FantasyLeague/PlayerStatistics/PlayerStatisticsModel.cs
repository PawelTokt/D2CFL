using System;

namespace D2CFL.Api.Website.Models.FantasyLeague.PlayerStatistics
{
    public class PlayerStatisticsModel
    {
        public Guid Id { get; set; }
        public int MatchesPlayed { get; set; }
        public int TotalKills { get; set; }
        public int TotalAssists { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalPoints { get; set; }
        public double AverageKills { get; set; }
        public double AverageAssists { get; set; }
        public double AverageDeaths { get; set; }
        public double AveragePoints { get; set; }
    }
}