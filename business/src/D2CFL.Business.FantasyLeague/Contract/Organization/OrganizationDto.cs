using System;

namespace D2CFL.Business.FantasyLeague.Contract.Organization
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Region { get; set; }
    }
}
