using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class MatchEntity : Entity<Guid>
    {
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public int FirstOrganizationScore { get; set; }
        public int SecondOrganizationScore { get; set; }
        public DateTime Date { get; set; }

        public virtual TournamentEntity Tournament { get; set; }
    }
}
