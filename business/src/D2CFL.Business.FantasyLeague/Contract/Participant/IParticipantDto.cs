using System;

namespace D2CFL.Business.FantasyLeague.Contract.Participant
{
    public interface IParticipantDto
    {
        Guid OrganizationId { get; set; }
        Guid MatchId { get; set; }
        int Score { get; set; }
    }
}