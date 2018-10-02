using System;
using Aurochses.Data.EntityFrameworkCore;

namespace D2CFL.Data.Organization.Contract
{
    public class PositionEntity : Entity<Guid>
    {
        public string Name { get; set; }
        public int KillCoefficient { get; set; }
        public int AssistCoefficient { get; set; }
        public int DeathCoefficient { get; set; }
    }
}