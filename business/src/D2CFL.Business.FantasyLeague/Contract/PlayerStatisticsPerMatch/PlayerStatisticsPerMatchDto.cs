using System;

namespace D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch
{
    public class PlayerStatisticsPerMatchDto
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public Guid PlayerId { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Death { get; set; }
        public double Points { get; set; }
        public string PlayerNickname { get; set; }
    }
}
