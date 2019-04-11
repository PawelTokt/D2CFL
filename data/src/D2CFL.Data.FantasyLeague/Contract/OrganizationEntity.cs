using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class OrganizationEntity : Entity<Guid>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Region { get; set; }
    }
}