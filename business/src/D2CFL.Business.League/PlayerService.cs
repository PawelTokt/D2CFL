using AutoMapper;
using D2CFL.Data.Interfaces;
using System.Threading.Tasks;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
using System.Linq;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League
{
    public class PlayerService : IPlayerService
    {
        private readonly IDataMapper _dataMapper;
        private readonly ILeagueUnitOfWork _leagueUnitOfWork;

        public PlayerService(IDataMapper dataMapper, ILeagueUnitOfWork leagueUnitOfWork)
        {
            _dataMapper = dataMapper;
            _leagueUnitOfWork = leagueUnitOfWork;
        }

        public async Task<IList<PlayerDto>> GetList()
        {
            return await _leagueUnitOfWork.PlayerRepository.GetListAsync<PlayerDto>(_dataMapper);
        }

        public async Task<PlayerDto> Get(int id)
        {
            var players = await _leagueUnitOfWork.PlayerRepository.GetListAsync<PlayerDto>(_dataMapper);

            return players.FirstOrDefault(x => x.Id == id);

            //return await _leagueUnitOfWork.PlayerRepository.GetAsync<PlayerDto>(_dataMapper);
        }

        public async Task Insert(PlayerDto playerDto)
        {
            await _leagueUnitOfWork.PlayerRepository.InsertAsync(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));

            await _leagueUnitOfWork.SaveAsync();
        }

        public void Update(PlayerDto playerDto)
        {
            _leagueUnitOfWork.PlayerRepository.Update(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));

            _leagueUnitOfWork.Save();
        }

        public void Delete(PlayerDto playerDto)
        {
            _leagueUnitOfWork.PlayerRepository.Delete(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));

            _leagueUnitOfWork.Save();
        }
    }
}