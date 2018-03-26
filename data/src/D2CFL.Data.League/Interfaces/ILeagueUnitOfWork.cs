using D2CFL.Data.Interfaces;
using D2CFL.Data.League.Entities;

namespace D2CFL.Data.League.Interfaces
{
    public interface ILeagueUnitOfWork
    {
        IRepository<PlayerEntity> PlayerRepository { get; }
        IRepository<TeamEntity> TeamRepository { get; }
        IRepository<PositionEntity> PositionRepository { get; }
    }
}