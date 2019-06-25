namespace D2CFL.Business.FantasyLeague.Contract.Organization
{
    public interface IOrganizationDto
    {
        string Name { get; set; }
        string ShortName { get; set; }
        string Region { get; set; }
    }
}