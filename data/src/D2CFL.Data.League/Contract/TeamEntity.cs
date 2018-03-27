using System.Collections.Generic;

namespace D2CFL.Data.League.Contract
{
    /// <summary>
    /// Class TeamEntity.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.Entity" />
    public class TeamEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamEntity"/> class.
        /// </summary>
        public TeamEntity()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Players = new List<PlayerEntity>();
        }

        /// <summary>
        /// Gets or sets the team name.
        /// </summary>
        /// <value>The team name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the team region.
        /// </summary>
        /// <value>The team region.</value>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the players of teams.
        /// </summary>
        /// <value>The players of teams.</value>
        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}