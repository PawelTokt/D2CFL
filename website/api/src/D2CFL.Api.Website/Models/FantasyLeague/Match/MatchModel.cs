using System;

namespace D2CFL.Api.Website.Models.FantasyLeague.Match
{
    public class MatchModel
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
