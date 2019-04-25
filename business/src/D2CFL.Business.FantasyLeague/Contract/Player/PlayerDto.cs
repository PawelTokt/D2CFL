using System;

namespace D2CFL.Business.FantasyLeague.Contract.Player
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public Guid PositionId { get; set; }
        public string PositionName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int MatchesPlayed { get; set; }
    }
}