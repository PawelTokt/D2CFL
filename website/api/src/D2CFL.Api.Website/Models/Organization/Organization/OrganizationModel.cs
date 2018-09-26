using System;

namespace D2CFL.Api.Website.Models.Organization.Organization
{
    public class OrganizationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Region { get; set; }
    }
}
