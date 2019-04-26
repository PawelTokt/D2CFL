using System;
using D2CFL.Business.FantasyLeague.Contract.PlayerStats;

namespace D2CFL.Api.Website.Models.FantasyLeague.PlayerStats
{
    public class PlayerStatsActionModel : IPlayerStatsDto
    {
        public Guid MatchId { get; set; }
        public Guid PlayerId { get; set; }
        public int Kill { get; set; }
        public int Assist { get; set; }
        public int Death { get; set; }
    }
}
