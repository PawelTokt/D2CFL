using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Tournament;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Business.FantasyLeague
{
    public class TournamentService : ITournamentService {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IFantasyLeagueUnitOfWork _unitOfWork;

        public TournamentService(IMapper mapper, IDataMapper dataMapper, IFantasyLeagueUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<TournamentDto>> GetList()
        {
            return await _unitOfWork.TournamentRepository.GetListAsync<TournamentDto>(_dataMapper);
        }

        public async Task<TournamentDto> Get(Guid id)
        {
            return await _unitOfWork.TournamentRepository.GetAsync<TournamentDto, TournamentEntity, Guid>(_dataMapper, id);
        }

        public async Task<TournamentDto> Add(ITournamentDto item)
        {
            var entity = await _unitOfWork.TournamentRepository.InsertAsync(_mapper.Map<TournamentEntity>(item));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<TournamentDto>(entity);
        }

        public async Task<TournamentDto> Edit(Guid id, ITournamentDto item)
        {
            var entity = await _unitOfWork.TournamentRepository.GetAsync(id);
            if(entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.TournamentRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<TournamentDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.TournamentRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}
