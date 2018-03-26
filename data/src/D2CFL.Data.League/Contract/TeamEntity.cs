using System.Collections.Generic;

namespace D2CFL.Data.League.Contract
{
    public class TeamEntity : Entity
    {
        public TeamEntity()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Players = new List<PlayerEntity>();
        }

        public string Name { get; set; }
        public string Region { get; set; }

        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}