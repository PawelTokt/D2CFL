using System.Collections.Generic;

namespace D2CFL.Data.League.Contract
{
    /// <summary>
    /// Class PositionEntity.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.Entity" />
    public class PositionEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionEntity"/> class.
        /// </summary>
        public PositionEntity()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Players = new List<PlayerEntity>();
        }

        /// <summary>
        /// Gets or sets the position name.
        /// </summary>
        /// <value>The position name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the kill cofficient.
        /// </summary>
        /// <value>The kill cofficient.</value>
        public double KillCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the death cofficient.
        /// </summary>
        /// <value>The death cofficient.</value>
        public double DeathCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the assist cofficient.
        /// </summary>
        /// <value>The assist cofficient.</value>
        public double AssistCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the players per position.
        /// </summary>
        /// <value>The players per position.</value>
        public virtual ICollection<PlayerEntity> Players { get; set; }
    }
}