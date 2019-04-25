using System;

namespace D2CFL.Business.FantasyLeague.Contract.Match
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string TournamentName { get; set; }
        public Guid FirstOrganizationId { get; set; }
        public string FirstOrganizationName { get; set; }
        public Guid SecondOrganizationId { get; set; }
        public string SecondOrganizationName { get; set; }
        public string Name { get; set; }
        public int FirstOrganizationScore { get; set; }
        public int SecondOrganizationScore { get; set; }
        public DateTime Date { get; set; }
    }
}
