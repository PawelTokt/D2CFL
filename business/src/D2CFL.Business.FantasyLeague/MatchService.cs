using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Match;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Business.FantasyLeague
{
    public class MatchService : IMatchService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IFantasyLeagueUnitOfWork _unitOfWork;

        public MatchService(IMapper mapper, IDataMapper dataMapper, IFantasyLeagueUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<MatchDto>> GetList()
        {
            return await _unitOfWork.MatchRepository.GetListAsync<MatchDto>(_dataMapper);
        }

        public async Task<MatchDto> Get(Guid id)
        {
            return await _unitOfWork.MatchRepository.GetAsync<MatchDto, MatchEntity, Guid>(_dataMapper, id);
        }

        public async Task<MatchDto> Add(IMatchDto item)
        {
            var entity = await _unitOfWork.MatchRepository.InsertAsync(_mapper.Map<MatchEntity>(item));

            await _unitOfWork.CommitAsync();

            var aa = _mapper.Map<MatchDto>(entity);

            return aa;
        }

        public async Task<MatchDto> Edit(Guid id, IMatchDto item)
        {
            var entity = await _unitOfWork.MatchRepository.GetAsync(id);
            if (entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.MatchRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<MatchDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.MatchRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}