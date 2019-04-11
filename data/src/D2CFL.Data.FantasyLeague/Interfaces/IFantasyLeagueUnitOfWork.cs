using System;
using Aurochses.Data;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Data.FantasyLeague.Interfaces
{
    public interface IFantasyLeagueUnitOfWork : IUnitOfWork
    {
        IRepository<OrganizationEntity, Guid> OrganizationRepository { get; }
        IRepository<PlayerEntity, Guid> PlayerRepository { get; }
        IRepository<PositionEntity, Guid> PositionRepository { get; }
    }
}