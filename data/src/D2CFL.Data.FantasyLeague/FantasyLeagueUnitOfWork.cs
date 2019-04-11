using System;
using Aurochses.Data;
using Aurochses.Data.EntityFrameworkCore;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class FantasyLeagueUnitOfWork : UnitOfWork, IFantasyLeagueUnitOfWork
    {
        public FantasyLeagueUnitOfWork(
            Func<DbContext, IRepository<OrganizationEntity, Guid>> organizationRepository,
            Func<DbContext, IRepository<PositionEntity, Guid>> positionRepository,
            Func<DbContext, IRepository<PlayerEntity, Guid>> playerRepository,
            DbContextOptions dbContextOptions
            ) : base(new FantasyLeagueDbContext(dbContextOptions)) {
            RegisterRepository(organizationRepository(DbContext));
            RegisterRepository(positionRepository(DbContext));
            RegisterRepository(playerRepository(DbContext));
        }

        public IRepository<OrganizationEntity, Guid> OrganizationRepository => GetRepository<OrganizationEntity, Guid>();

        public IRepository<PositionEntity, Guid> PositionRepository => GetRepository<PositionEntity, Guid>();

        public IRepository<PlayerEntity, Guid> PlayerRepository => GetRepository<PlayerEntity, Guid>();
    }
}