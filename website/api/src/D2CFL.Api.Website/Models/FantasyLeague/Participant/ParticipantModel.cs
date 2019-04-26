using System;

namespace D2CFL.Api.Website.Models.FantasyLeague.Participant
{
    public class ParticipantModel
    {
        public Guid Id { get; set; }
        public Guid? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public Guid MatchId { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
    }
}
