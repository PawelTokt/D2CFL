using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class PlayerStatisticsPerMatchEntity : Entity<Guid>
    {
        public Guid MatchId { get; set; }
        public Guid? PlayerId { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Death { get; set; }
        public double Points { get; set; }
        public string PlayerNickname { get; set; }

        public virtual MatchEntity Match { get; set; }
        public virtual PlayerEntity Player { get; set; }
    }
}
