using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class TournamentEntity : Entity<Guid>
    {
        public string Name { get; set; }
    }
}