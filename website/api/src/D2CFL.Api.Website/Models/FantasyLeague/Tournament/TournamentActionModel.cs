using System;
using D2CFL.Business.FantasyLeague.Contract.Tournament;

namespace D2CFL.Api.Website.Models.FantasyLeague.Tournament
{
    public class TournamentActionModel : ITournamentDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}