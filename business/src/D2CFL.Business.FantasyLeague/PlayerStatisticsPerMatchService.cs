using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Business.FantasyLeague
{
    public class PlayerStatisticsPerMatchService : IPlayerStatisticsPerMatchService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IFantasyLeagueUnitOfWork _unitOfWork;

        public PlayerStatisticsPerMatchService(IMapper mapper, IDataMapper dataMapper, IFantasyLeagueUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerStatisticsPerMatchDto>> GetList()
        {
            return await _unitOfWork.PlayerStatisticsPerMatchRepository.GetListAsync<PlayerStatisticsPerMatchDto>(_dataMapper);
        }

        public async Task<PlayerStatisticsPerMatchDto> Get(Guid id)
        {
            return await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync<PlayerStatisticsPerMatchDto, PlayerStatisticsPerMatchEntity, Guid>(_dataMapper, id);
        }

        public async Task<PlayerStatisticsPerMatchDto> Add(IPlayerStatisticsPerMatchDto item)
        {
            var playerStatisticsPerMatchEntity = await _unitOfWork.PlayerStatisticsPerMatchRepository.InsertAsync(_mapper.Map<PlayerStatisticsPerMatchEntity>(item));

            await UpdatePlayerStatisticsWhenAddingMatch(item);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerStatisticsPerMatchDto>(playerStatisticsPerMatchEntity);
        }

        private async Task UpdatePlayerStatisticsWhenAddingMatch(IPlayerStatisticsPerMatchDto item)
        {
            var entity = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);
            if(entity == null) return;

            entity.MatchesPlayed++;

            entity.TotalKills += item.Kills;
            entity.TotalAssists += item.Assists;
            entity.TotalDeaths += item.Death;
            entity.TotalPoints += item.Points;

            entity.AverageKills = (double)Math.Round((decimal)(entity.TotalKills / entity.MatchesPlayed), 2);
            entity.AverageAssists = (double)Math.Round((decimal)(entity.TotalKills / entity.MatchesPlayed), 2);
            entity.AverageDeaths = (double)Math.Round((decimal)(entity.TotalKills / entity.MatchesPlayed), 2);
            entity.AveragePoints = (double)Math.Round((decimal)(entity.TotalKills / entity.MatchesPlayed), 2);

            _unitOfWork.PlayerStatisticsRepository.Update(entity);

            await _unitOfWork.CommitAsync();
        }

        public async Task<PlayerStatisticsPerMatchDto> Edit(Guid id, IPlayerStatisticsPerMatchDto item)
        {
            var entity = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync(id);
            if(entity == null) return null;

            entity = _mapper.Map(item, entity);

            await UpdatePlayerStatisticsWhenEditingMatch(item, entity);

            _unitOfWork.PlayerStatisticsPerMatchRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerStatisticsPerMatchDto>(entity);
        }

        private async Task UpdatePlayerStatisticsWhenEditingMatch(IPlayerStatisticsPerMatchDto item, PlayerStatisticsPerMatchEntity entity)
        {
            var playerStatisticsEntity = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);
            if(entity == null) return;

            playerStatisticsEntity.TotalKills = playerStatisticsEntity.TotalKills - entity.Kills + item.Kills;
            playerStatisticsEntity.TotalAssists = playerStatisticsEntity.TotalAssists - entity.Kills + item.Assists;
            playerStatisticsEntity.TotalDeaths = playerStatisticsEntity.TotalDeaths - entity.Kills + item.Death;
            playerStatisticsEntity.TotalPoints = playerStatisticsEntity.TotalPoints - entity.Kills + item.Points;

            playerStatisticsEntity.AverageKills = (double)Math.Round((decimal)(playerStatisticsEntity.TotalKills / playerStatisticsEntity.MatchesPlayed), 2);
            playerStatisticsEntity.AverageAssists = (double)Math.Round((decimal)(playerStatisticsEntity.TotalKills / playerStatisticsEntity.MatchesPlayed), 2);
            playerStatisticsEntity.AverageDeaths = (double)Math.Round((decimal)(playerStatisticsEntity.TotalKills / playerStatisticsEntity.MatchesPlayed), 2);
            playerStatisticsEntity.AveragePoints = (double)Math.Round((decimal)(playerStatisticsEntity.TotalKills / playerStatisticsEntity.MatchesPlayed), 2);

            _unitOfWork.PlayerStatisticsRepository.Update(playerStatisticsEntity);

            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.PlayerStatisticsPerMatchRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}
