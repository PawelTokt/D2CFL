using D2CFL.Data.League.Entities;

namespace D2CFL.Data.League.Interfaces
{
    public interface ILeagueUnitOfWork
    {
        Repository<PlayerEntity> PlayerRepository { get; set; }
        Repository<TeamEntity> TeamRepository { get; set; }
        Repository<PositionEntity> PositionRepository { get; set; }
    }
}