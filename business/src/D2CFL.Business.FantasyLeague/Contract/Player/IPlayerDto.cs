using System;

namespace D2CFL.Business.FantasyLeague.Contract.Player
{
    public interface IPlayerDto
    {
        Guid OrganizationId { get; set; }
        Guid PositionId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Nickname { get; set; }
        int Age { get; set; }
        string Country { get; set; }
    }
}