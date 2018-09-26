using System;

namespace D2CFL.Business.Organization.Contract.Organization
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Region { get; set; }
    }
}
