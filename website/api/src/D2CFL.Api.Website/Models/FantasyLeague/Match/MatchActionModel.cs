using System;
using D2CFL.Business.FantasyLeague.Contract.Match;

namespace D2CFL.Api.Website.Models.FantasyLeague.Match
{
    public class MatchActionModel : IMatchDto
    {
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}