using System;

namespace D2CFL.Api.Website.Models.FantasyLeague.Organization
{
    public class OrganizationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Region { get; set; }
    }
}