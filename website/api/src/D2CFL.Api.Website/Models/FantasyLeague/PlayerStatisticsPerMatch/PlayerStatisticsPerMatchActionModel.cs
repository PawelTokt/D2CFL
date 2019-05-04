using System;
using D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch;

namespace D2CFL.Api.Website.Models.FantasyLeague.PlayerStatisticsPerMatch
{
    public class PlayerStatisticsPerMatchActionModel : IPlayerStatisticsPerMatchDto
    {
        public Guid MatchId { get; set; }
        public Guid PlayerId { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public double Points { get; set; }
    }
}
