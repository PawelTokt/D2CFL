using System;
using D2CFL.Data.Interfaces;
using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.League
{
    public class LeagueUnitOfWork : UnitOfWork, ILeagueUnitOfWork
    {
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

        public IRepository<PlayerEntity> PlayerRepository => GetRepository<PlayerEntity>();
        public IRepository<PositionEntity> PositionRepository => GetRepository<PositionEntity>();
        public IRepository<TeamEntity> TeamRepository => GetRepository<TeamEntity>();
    }
}