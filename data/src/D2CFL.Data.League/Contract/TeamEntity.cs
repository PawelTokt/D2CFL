using System.Collections.Generic;

namespace D2CFL.Data.League.Contract
{
    public class TeamEntity : Entity
    {
        public string Name { get; set; }
        public string Region { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}