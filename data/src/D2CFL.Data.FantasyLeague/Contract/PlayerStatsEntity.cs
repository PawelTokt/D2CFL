using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class PlayerStatsEntity : Entity<Guid>
    {
        public Guid MatchId { get; set; }
        public Guid? PlayerId { get; set; }
        public int Kill { get; set; }
        public int Assist { get; set; }
        public int Death { get; set; }
        public int Points { get; set; }

        public virtual MatchEntity Match { get; set; }
        public virtual PlayerEntity Player { get; set; }
    }
}
