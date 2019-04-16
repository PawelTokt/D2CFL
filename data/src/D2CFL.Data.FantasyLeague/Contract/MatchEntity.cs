using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class MatchEntity : Entity<Guid>
    {
        public Guid TournamentId { get; set; }
        public Guid OrganizationOneId { get; set; }
        public Guid OrganizationTwoId { get; set; }
        public string Name { get; set; }
        public int OrganizationOneScore { get; set; }
        public int OrganizationTwoScore { get; set; }
        public DateTime Date { get; set; }

        public virtual TournamentEntity Tournament { get; set; }
        public virtual OrganizationEntity Organization { get; set; }
    }
}