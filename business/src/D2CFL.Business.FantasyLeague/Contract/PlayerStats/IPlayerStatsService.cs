using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.FantasyLeague.Contract.PlayerStats
{
    public interface IPlayerStatsService
    {
        Task<IList<PlayerStatsDto>> GetList();

        Task<PlayerStatsDto> Get(Guid id);

        Task<PlayerStatsDto> Add(IPlayerStatsDto item);

        Task<PlayerStatsDto> Edit(Guid id, IPlayerStatsDto item);

        Task Delete(Guid id);
    }
}
