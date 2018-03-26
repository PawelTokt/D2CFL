using D2CFL.Data.Interfaces;

namespace D2CFL.Data.League.Contract
{
    public interface ILeagueUnitOfWork
    {
        IRepository<PlayerEntity> PlayerRepository { get; }
        IRepository<TeamEntity> TeamRepository { get; }
        IRepository<PositionEntity> PositionRepository { get; }
    }
}