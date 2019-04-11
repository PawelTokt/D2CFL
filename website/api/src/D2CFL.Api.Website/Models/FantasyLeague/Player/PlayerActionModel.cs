using System;
using D2CFL.Business.FantasyLeague.Contract.Player;

namespace D2CFL.Api.Website.Models.FantasyLeague.Player
{
    public class PlayerActionModel : IPlayerDto
    {
        public Guid? OrganizationId { get; set; }
        public Guid? PositionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}