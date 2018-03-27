﻿namespace D2CFL.Data.League.Contract
{
    /// <summary>
    /// Class PlayerEntity.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.Entity" />
    public class PlayerEntity : Entity
    {
        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        /// <value>The position name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player nickname.
        /// </summary>
        /// <value>The position name.</value>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the player surename.
        /// </summary>
        /// <value>The position name.</value>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the position identifier.
        /// </summary>
        /// <value>The position identifier.</value>
        public int? PositionEntityId { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public PositionEntity Position { get; set; }

        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        public int? TeamEntityId { get; set; }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>The team.</value>
        public TeamEntity Team { get; set; }
    }
}