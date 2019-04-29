using System;
using Aurochses.Data;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Data.FantasyLeague.Interfaces
{
    public interface IFantasyLeagueUnitOfWork : IUnitOfWork
    {
        IRepository<MatchEntity, Guid> MatchRepository { get; }
        IRepository<OrganizationEntity, Guid> OrganizationRepository { get; }
        IRepository<ParticipantEntity, Guid> ParticipantRepository { get; }
        IRepository<PlayerEntity, Guid> PlayerRepository { get; }
        IRepository<PlayerStatisticsEntity, Guid> PlayerStatisticsRepository { get; }
        IRepository<PositionEntity, Guid> PositionRepository { get; }
        IRepository<TournamentEntity, Guid> TournamentRepository { get; }
    }
}
