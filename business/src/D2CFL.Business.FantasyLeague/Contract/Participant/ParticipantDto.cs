using System;

namespace D2CFL.Business.FantasyLeague.Contract.Participant
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid MatchId { get; set; }
        public int Score { get; set; }
        public string OrganizationName { get; set; }
    }
}
