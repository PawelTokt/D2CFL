using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.FantasyLeague.Contract.Match
{
    public interface IMatchService
    {
        Task<IList<MatchDto>> GetList();

        Task<MatchDto> Get(Guid id);

        Task<MatchDto> Add(IMatchDto item);

        Task<MatchDto> Edit(Guid id, IMatchDto item);

        Task Delete(Guid id);
    }
}
