using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.FantasyLeague.Contract.Participant
{
    public interface IParticipantService
    {
        Task<IList<ParticipantDto>> GetList();

        Task<ParticipantDto> Get(Guid id);

        Task<ParticipantDto> Add(IParticipantDto item);

        Task<ParticipantDto> Edit(Guid id, IParticipantDto item);

        Task Delete(Guid id);
    }
}
