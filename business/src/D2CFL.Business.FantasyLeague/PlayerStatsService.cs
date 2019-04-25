using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.PlayerStats;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Business.FantasyLeague
{
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IFantasyLeagueUnitOfWork _unitOfWork;

        public PlayerStatsService(IMapper mapper, IDataMapper dataMapper, IFantasyLeagueUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerStatsDto>> GetList()
        {
            return await _unitOfWork.PlayerStatsRepository.GetListAsync<PlayerStatsDto>(_dataMapper);
        }

        public async Task<PlayerStatsDto> Get(Guid id)
        {
            return await _unitOfWork.PlayerStatsRepository.GetAsync<PlayerStatsDto, PlayerStatsEntity, Guid>(_dataMapper, id);
        }

        public async Task<PlayerStatsDto> Add(IPlayerStatsDto item)
        {
            var entity = _mapper.Map<PlayerStatsEntity>(item);

            await CalculatePoints(entity);

            await _unitOfWork.PlayerStatsRepository.InsertAsync(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerStatsDto>(entity);
        }

        public async Task<PlayerStatsDto> Edit(Guid id, IPlayerStatsDto item)
        {
            var entity = await _unitOfWork.PlayerStatsRepository.GetAsync(id);
            if(entity == null) return null;

            entity = _mapper.Map(item, entity);

            await CalculatePoints(entity);

            _unitOfWork.PlayerStatsRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerStatsDto>(entity);
        }

        private async Task CalculatePoints(PlayerStatsEntity entity)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync((Guid)entity.PlayerId);

            var position = await _unitOfWork.PositionRepository.GetAsync((Guid)player.PositionId);

            entity.Points = (entity.Kill * position.KillCoefficient) + (entity.Assist * position.AssistCoefficient) - (entity.Death * position.DeathCoefficient);
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.PlayerStatsRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}
