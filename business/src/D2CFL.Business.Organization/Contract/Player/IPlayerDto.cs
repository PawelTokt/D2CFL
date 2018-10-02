namespace D2CFL.Business.Organization.Contract.Player
{
    public interface IPlayerDto
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Nickname { get; set; }
        int Age { get; set; }
        string Country { get; set; }
    }
}