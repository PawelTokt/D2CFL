using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class TournamentEntity : Entity<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}