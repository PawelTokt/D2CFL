using System;
using D2CFL.Business.FantasyLeague.Contract.Participant;

namespace D2CFL.Api.Website.Models.FantasyLeague.Participant
{
    public class ParticipantActionModel : IParticipantDto
    {
        public Guid OrganizationId { get; set; }
        public Guid MatchId { get; set; }
        public int Score { get; set; }
    }
}
