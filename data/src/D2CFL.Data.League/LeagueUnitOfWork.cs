using D2CFL.Data.Interfaces;
using D2CFL.Data.League.Entities;
using D2CFL.Data.League.Interfaces;

namespace D2CFL.Data.League
{
    public class LeagueUnitOfWork : UnitOfWork, ILeagueUnitOfWork
    {
        public LeagueUnitOfWork(LeagueDbContext leagueDbContext)
            : base(leagueDbContext)
        {
            PlayerRepository = new Repository<PlayerEntity>(leagueDbContext);
            TeamRepository = new Repository<TeamEntity>(leagueDbContext);
            PositionRepository = new Repository<PositionEntity>(leagueDbContext);
        }

        public IRepository<PlayerEntity> PlayerRepository { get; set; }
        public IRepository<TeamEntity> TeamRepository { get; set; }
        public IRepository<PositionEntity> PositionRepository { get; set; }
    }
}