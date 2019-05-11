using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch
{
    public interface IPlayerStatisticsPerMatchService
    {
        Task<IList<PlayerStatisticsPerMatchDto>> GetList();

        Task<PlayerStatisticsPerMatchDto> Get(Guid id);

        Task<PlayerStatisticsPerMatchDto> Add(IPlayerStatisticsPerMatchDto item);

        Task<PlayerStatisticsPerMatchDto> Edit(Guid id, IPlayerStatisticsPerMatchDto item);
    }
}
