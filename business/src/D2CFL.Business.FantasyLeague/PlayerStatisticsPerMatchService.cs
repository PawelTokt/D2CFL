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
            return await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync<PlayerStatisticsPerMatchDto, PlayerStatisticsPerMatchEntity, Guid>(_dataMapper, id);
        }

        public async Task<PlayerStatisticsPerMatchDto> Add(IPlayerStatisticsPerMatchDto item)
        {
            await CountPlayerPoints(item);

            var entity = await _unitOfWork.PlayerStatisticsPerMatchRepository.InsertAsync(_mapper.Map<PlayerStatisticsPerMatchEntity>(item));

            await _unitOfWork.CommitAsync();

            var playerStatistics = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);

            playerStatistics.MatchesPlayed++;

            await UpdatePlayerStatistics(playerStatistics);

            return _mapper.Map<PlayerStatisticsPerMatchDto>(entity);
        }

        public async Task<PlayerStatisticsPerMatchDto> Edit(Guid id, IPlayerStatisticsPerMatchDto item)
        {
            await CountPlayerPoints(item);

            var entity = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync(id);

            entity = _mapper.Map(item, entity);

            _unitOfWork.PlayerStatisticsPerMatchRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            var playerStatistics = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);

            await UpdatePlayerStatistics(playerStatistics);

            return _mapper.Map<PlayerStatisticsPerMatchDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            var item = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetAsync<IPlayerStatisticsPerMatchDto, PlayerStatisticsPerMatchEntity, Guid>(_dataMapper, id);

            _unitOfWork.PlayerStatisticsPerMatchRepository.Delete(id);

            await _unitOfWork.CommitAsync();

            var playerStatistics = await _unitOfWork.PlayerStatisticsRepository.GetAsync(item.PlayerId);

            playerStatistics.MatchesPlayed--;

            await UpdatePlayerStatistics(playerStatistics);
        }

        private async Task CountPlayerPoints(IPlayerStatisticsPerMatchDto item)
        {
            var player = await _unitOfWork.PlayerRepository.GetAsync(x => x.Id == item.PlayerId);
            var position = await _unitOfWork.PositionRepository.GetAsync(x => x.Id == player.Id);

            item.Points = position.KillCoefficient * item.Kills + position.AssistCoefficient * item.Assists - position.DeathCoefficient * item.Deaths;
        }

        private async Task UpdatePlayerStatistics(PlayerStatisticsEntity playerStatistics)
        {
            var playerStatisticsPerMatches = await _unitOfWork.PlayerStatisticsPerMatchRepository.GetListAsync(x => x.PlayerId == playerStatistics.Id);

            playerStatistics.TotalKills = playerStatisticsPerMatches.Sum(x => x.Kills);
            playerStatistics.AverageKills = playerStatisticsPerMatches.Average(x => x.Kills);

            playerStatistics.TotalAssists = playerStatisticsPerMatches.Sum(x => x.Assists);
            playerStatistics.AverageAssists = playerStatisticsPerMatches.Average(x => x.Assists);

            playerStatistics.TotalDeaths = playerStatisticsPerMatches.Sum(x => x.Deaths);
            playerStatistics.AverageDeaths = playerStatisticsPerMatches.Average(x => x.Deaths);

            playerStatistics.TotalPoints = playerStatisticsPerMatches.Sum(x => x.Points);
            playerStatistics.AveragePoints = playerStatisticsPerMatches.Average(x => x.Points);

            _unitOfWork.PlayerStatisticsRepository.Update(playerStatistics);

            await _unitOfWork.CommitAsync();
        }
    }
}
