using System;

namespace D2CFL.Api.Website.Models.FantasyLeague.PlayerStatisticsPerMatch
{
    public class PlayerStatisticsPerMatchModel
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public Guid PlayerId { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public double Points { get; set; }
        public string PlayerNickname { get; set; }
    }
}
