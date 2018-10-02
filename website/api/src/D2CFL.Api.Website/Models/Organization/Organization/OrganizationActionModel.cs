using D2CFL.Business.Organization.Contract.Organization;

namespace D2CFL.Api.Website.Models.Organization.Organization
{
    public class OrganizationActionModel : IOrganizationDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Region { get; set; }
    }
}