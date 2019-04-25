using System;

namespace D2CFL.Business.FantasyLeague.Contract.Match
{
    public interface IMatchDto
    {
        Guid TournamentId { get; set; }
        Guid FirstOrganizationId { get; set; }
        Guid SecondOrganizationId { get; set; }
        string Name { get; set; }
        int FirstOrganizationScore { get; set; }
        int SecondOrganizationScore { get; set; }
        DateTime Date { get; set; }
    }
}
