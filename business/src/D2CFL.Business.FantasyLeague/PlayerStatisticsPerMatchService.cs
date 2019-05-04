using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync<PlayerStatisticsPerMatchDto, PlayerStatisticsPerMatchEntity, Guid>(_dataMapper,id);
        }

        public async Task<PlayerStatisticsPerMatchDto> Add(IPlayerStatisticsPerMatchDto item)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync(x => x.Id == item.PlayerId);
            var position = await _unitOfWork.PositionRepository.GetAsync(x => x.Id == player.Id);

            item.Points = position.KillCoefficient * item.Kills + position.AssistCoefficient * item.Assists - position.DeathCoefficient * item.Deaths;

            var playerStatisticsPerMatchEntity = await _unitOfWork.PlayerStatisticsPerMatchRepository.InsertAsync(_mapper.Map<PlayerStatisticsPerMatchEntity>(item));

            await UpdatePlayerStatisticsWhenAddingMatch(item);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerStatisticsPerMatchDto>(playerStatisticsPerMatchEntity);
        }

        private async Task UpdatePlayerStatisticsWhenAddingMatch(IPlayerStatisticsPerMatchDto item)
        {
            var playerStatisticsEntity = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);
            if(playerStatisticsEntity == null) return;

            playerStatisticsEntity.MatchesPlayed++;

            var playerStatisticsPerMatches = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetListAsync(x => x.PlayerId == item.PlayerId);

            playerStatisticsEntity.TotalKills = playerStatisticsPerMatches.Sum(x => x.Kills);
            playerStatisticsEntity.AverageKills = playerStatisticsPerMatches.Average(x => x.Kills);

            playerStatisticsEntity.TotalAssists = playerStatisticsPerMatches.Sum(x => x.Assists);
            playerStatisticsEntity.AverageAssists = playerStatisticsPerMatches.Average(x => x.Assists);

            playerStatisticsEntity.TotalDeaths = playerStatisticsPerMatches.Sum(x => x.Deaths);
            playerStatisticsEntity.AverageDeaths = playerStatisticsPerMatches.Average(x => x.Deaths);

            playerStatisticsEntity.TotalPoints = playerStatisticsPerMatches.Sum(x => x.Points);
            playerStatisticsEntity.AveragePoints = playerStatisticsPerMatches.Average(x => x.Points);

            _unitOfWork.PlayerStatisticsRepository.Update(playerStatisticsEntity);

            await _unitOfWork.CommitAsync();
        }

        public async Task<PlayerStatisticsPerMatchDto> Edit(Guid id, IPlayerStatisticsPerMatchDto item)
        {
            var entity = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync(id);
            if(entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.PlayerStatisticsPerMatchRepository.Update(entity);

            await UpdatePlayerStatistics(item);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerStatisticsPerMatchDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            var item = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync<IPlayerStatisticsPerMatchDto, PlayerStatisticsPerMatchEntity, Guid>(_dataMapper, id);

            _unitOfWork.PlayerStatisticsPerMatchRepository.Delete(id);

            await UpdatePlayerStatistics(item);

            await _unitOfWork.CommitAsync();
        }

        private async Task UpdatePlayerStatistics(IPlayerStatisticsPerMatchDto item)
        {
            var playerStatisticsEntity = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);
            if (playerStatisticsEntity == null) return;

            var playerStatisticsPerMatches = await this._unitOfWork.PlayerStatisticsPerMatchRepository.GetListAsync(x => x.PlayerId == item.PlayerId);

            playerStatisticsEntity.TotalKills = playerStatisticsPerMatches.Sum(x => x.Kills);
            playerStatisticsEntity.AverageKills = playerStatisticsPerMatches.Average(x => x.Kills);

            playerStatisticsEntity.TotalAssists = playerStatisticsPerMatches.Sum(x => x.Assists);
            playerStatisticsEntity.AverageAssists = playerStatisticsPerMatches.Average(x => x.Assists);

            playerStatisticsEntity.TotalDeaths = playerStatisticsPerMatches.Sum(x => x.Deaths);
            playerStatisticsEntity.AverageDeaths = playerStatisticsPerMatches.Average(x => x.Deaths);

            playerStatisticsEntity.TotalPoints = playerStatisticsPerMatches.Sum(x => x.Points);
            playerStatisticsEntity.AveragePoints = playerStatisticsPerMatches.Average(x => x.Points);

            _unitOfWork.PlayerStatisticsRepository.Update(playerStatisticsEntity);

            await _unitOfWork.CommitAsync();
        }
    }
}
