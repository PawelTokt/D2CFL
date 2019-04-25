using System;

namespace D2CFL.Business.FantasyLeague.Contract.PlayerStats
{
    public class PlayerStatsDto
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public string MathcName { get; set; }
        public Guid PlayerId { get; set; }
        public string PlayerNickName { get; set; }
        public int Kill { get; set; }
        public int Assist { get; set; }
        public int Death { get; set; }
        public int Points { get; set; }
    }
}