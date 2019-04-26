using D2CFL.Business.FantasyLeague.Contract.Organization;

namespace D2CFL.Api.Website.Models.FantasyLeague.Organization
{
    public class OrganizationActionModel : IOrganizationDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Region { get; set; }
    }
}
