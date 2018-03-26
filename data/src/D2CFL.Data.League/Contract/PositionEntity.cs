using System.Collections.Generic;

namespace D2CFL.Data.League.Contract
{
    public class PositionEntity : Entity
    {
        public string Name { get; set; }
        public double KillCoefficient { get; set; }
        public double DeathCoefficient { get; set; }
        public double AssistCoefficient { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}