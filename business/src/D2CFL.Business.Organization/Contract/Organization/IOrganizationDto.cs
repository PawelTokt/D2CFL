namespace D2CFL.Business.Organization.Contract.Organization
{
    public interface IOrganizationDto
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
        string Region { get; set; }
    }
}
