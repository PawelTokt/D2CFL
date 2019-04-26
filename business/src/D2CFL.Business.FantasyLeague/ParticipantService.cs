using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Participant;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Business.FantasyLeague
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IFantasyLeagueUnitOfWork _unitOfWork;

        public ParticipantService(IMapper mapper, IDataMapper dataMapper, IFantasyLeagueUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ParticipantDto>> GetList()
        {
            return await _unitOfWork.ParticipantRepository.GetListAsync<ParticipantDto>(_dataMapper);
        }

        public async Task<ParticipantDto> Get(Guid id)
        {
            return await _unitOfWork.ParticipantRepository.GetAsync<ParticipantDto, ParticipantEntity, Guid>(_dataMapper, id);
        }

        public async Task<ParticipantDto> Add(IParticipantDto item)
        {
            var entity = await _unitOfWork.ParticipantRepository.InsertAsync(_mapper.Map<ParticipantEntity>(item));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ParticipantDto>(entity);
        }

        public async Task<ParticipantDto> Edit(Guid id, IParticipantDto item)
        {
            var entity = await _unitOfWork.ParticipantRepository.GetAsync(id);
            if(entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.ParticipantRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ParticipantDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.ParticipantRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}
