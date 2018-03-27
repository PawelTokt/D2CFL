using D2CFL.Data.Interfaces;

namespace D2CFL.Data.League.Contract
{
    /// <summary>
    /// Interface ILeagueUnitOfWork.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.Interfaces.IUnitOfWork" />
    public interface ILeagueUnitOfWork
    {
        /// <summary>
        /// Gets the player repository.
        /// </summary>
        /// <value>The player repository.</value>
        IRepository<PlayerEntity> PlayerRepository { get; }

        /// <summary>
        /// Gets the position repository.
        /// </summary>
        /// <value>The position repository.</value>
        IRepository<PositionEntity> PositionRepository { get; }

        /// <summary>
        /// Gets the team repository.
        /// </summary>
        /// <value>The team repository.</value>
        IRepository<TeamEntity> TeamRepository { get; }
    }
}