using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.FantasyLeague.Contract.Tournament
{
    public interface ITournamentService
    {
        Task<IList<TournamentDto>> GetList();

        Task<TournamentDto> Get(Guid id);

        Task<TournamentDto> Add(ITournamentDto item);

        Task<TournamentDto> Edit(Guid id, ITournamentDto item);

        Task Delete(Guid id);
    }
}
