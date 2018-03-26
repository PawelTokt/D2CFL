using System;
using D2CFL.Data.Interfaces;
using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.League
{
    /// <summary>
    /// Class LeagueUnitOfWork.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.UnitOfWork"/>
    /// <seealso cref="T:D2CFL.Data.League.Contract.ILeagueUnitOfWork" />
    public class LeagueUnitOfWork : UnitOfWork, ILeagueUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueUnitOfWork"/> class.
        /// </summary>
        /// <param name="playerRepository">The player repository.</param>
        /// <param name="positionRepository">The position repository.</param>
        /// <param name="teamRepository">The team repository.</param>
        /// <param name="dbContextOptions">The database context options.</param>
        /// <param name="schemaName">Name of the schema.</param>
        public LeagueUnitOfWork(
            Func<DbContext, IRepository<PlayerEntity>> playerRepository,
            Func<DbContext, IRepository<PositionEntity>> positionRepository,
            Func<DbContext, IRepository<TeamEntity>> teamRepository,
            DbContextOptions dbContextOptions,
            string schemaName)
            : base(new LeagueDbContext(dbContextOptions, schemaName))
        {
            RegisterRepository(playerRepository(DbContext));
            RegisterRepository(positionRepository(DbContext));
            RegisterRepository(teamRepository(DbContext));
        }

        /// <summary>
        /// Gets the player repository
        /// </summary>
        /// <value>The player repository</value>
        public IRepository<PlayerEntity> PlayerRepository => GetRepository<PlayerEntity>();

        /// <summary>
        /// Gets the position repository
        /// </summary>
        /// <value>The position repository</value>
        public IRepository<PositionEntity> PositionRepository => GetRepository<PositionEntity>();

        /// <summary>
        /// Gets the team repository
        /// </summary>
        /// <value>The team repository</value>
        public IRepository<TeamEntity> TeamRepository => GetRepository<TeamEntity>();
    }
}