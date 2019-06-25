using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using D2CFL.Business.FantasyLeague.Contract.PlayerStatistics;

namespace D2CFL.Business.FantasyLeague.Contract.Player
{
    public interface IPlayerService
    {
        Task<IList<PlayerDto>> GetList();

        Task<PlayerDto> Get(Guid id);

        Task<PlayerStatisticsDto> GetStatistics(Guid id);

        Task<PlayerDto> Add(IPlayerDto item);

        Task<PlayerDto> Edit(Guid id, IPlayerDto item);

        Task Delete(Guid id);
    }
}