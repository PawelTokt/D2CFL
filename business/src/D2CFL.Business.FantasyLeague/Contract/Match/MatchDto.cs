using System;

namespace D2CFL.Business.FantasyLeague.Contract.Match
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}