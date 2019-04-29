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
            Func<DbContext, IRepository<MatchEntity, Guid>> matchRepository,
            Func<DbContext, IRepository<OrganizationEntity, Guid>> organizationRepository,
            Func<DbContext, IRepository<ParticipantEntity, Guid>> participantRepository,
            Func<DbContext, IRepository<PlayerEntity, Guid>> playerRepository,
            Func<DbContext, IRepository<PlayerStatisticsEntity, Guid>> playerStatisticsRepository,
            Func<DbContext, IRepository<PositionEntity, Guid>> positionRepository,
            Func<DbContext, IRepository<TournamentEntity, Guid>> tournamentRepository,
            DbContextOptions dbContextOptions,
            string schemaName
        ) : base(new FantasyLeagueDbContext(dbContextOptions, schemaName))
        {
            RegisterRepository(matchRepository(DbContext));
            RegisterRepository(organizationRepository(DbContext));
            RegisterRepository(participantRepository(DbContext));
            RegisterRepository(playerRepository(DbContext));
            RegisterRepository(playerStatisticsRepository(DbContext));
            RegisterRepository(positionRepository(DbContext));
            RegisterRepository(tournamentRepository(DbContext));
        }

        public IRepository<MatchEntity, Guid> MatchRepository => GetRepository<MatchEntity, Guid>();

        public IRepository<OrganizationEntity, Guid> OrganizationRepository => GetRepository<OrganizationEntity, Guid>();

        public IRepository<ParticipantEntity, Guid> ParticipantRepository => GetRepository<ParticipantEntity, Guid>();

        public IRepository<PlayerEntity, Guid> PlayerRepository => GetRepository<PlayerEntity, Guid>();

        public IRepository<PlayerStatisticsEntity, Guid> PlayerStatisticsRepository => GetRepository<PlayerStatisticsEntity, Guid>();

        public IRepository<PositionEntity, Guid> PositionRepository => GetRepository<PositionEntity, Guid>();

        public IRepository<TournamentEntity, Guid> TournamentRepository => GetRepository<TournamentEntity, Guid>();
    }
}
