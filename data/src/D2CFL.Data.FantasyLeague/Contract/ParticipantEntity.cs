using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class ParticipantEntity : Entity<Guid>
    {
        public Guid? OrganizationId { get; set; }
        public Guid MatchId { get; set; }
        public int Score { get; set; }
        public string OrganizationName { get; set; }

        public virtual OrganizationEntity Organization { get; set; }
        public virtual MatchEntity Match { get; set; }
    }
}
