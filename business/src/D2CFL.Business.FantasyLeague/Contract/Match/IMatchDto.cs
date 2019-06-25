using System;

namespace D2CFL.Business.FantasyLeague.Contract.Match
{
    public interface IMatchDto
    {
        Guid TournamentId { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
    }
}