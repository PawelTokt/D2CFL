using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.Organization.Contract
{
    public class OrganizationEntity : Entity<Guid>
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Region { get; set; }
    }
}
