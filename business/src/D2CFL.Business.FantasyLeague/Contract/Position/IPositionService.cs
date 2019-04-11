using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.FantasyLeague.Contract.Position
{
    public interface IPositionService
    {
        Task<IList<PositionDto>> GetList();
        Task<PositionDto> Get(Guid id);
        Task<PositionDto> Add(IPositionDto item);
        Task<PositionDto> Edit(Guid id, IPositionDto item);
        Task Delete(Guid id);
    }
}