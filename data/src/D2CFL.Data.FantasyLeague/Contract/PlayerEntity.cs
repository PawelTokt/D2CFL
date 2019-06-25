using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague.Contract
{
    public class PlayerEntity : Entity<Guid>
    {
        public Guid? OrganizationId { get; set; }
        public Guid? PositionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public virtual OrganizationEntity Organization { get; set; }
        public virtual PositionEntity Position { get; set; }
        public virtual PlayerStatisticsEntity PlayerStatistics { get; set; }
    }
}