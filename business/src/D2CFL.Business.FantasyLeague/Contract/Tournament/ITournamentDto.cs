using System;

namespace D2CFL.Business.FantasyLeague.Contract.Tournament
{
    public interface ITournamentDto
    {
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
