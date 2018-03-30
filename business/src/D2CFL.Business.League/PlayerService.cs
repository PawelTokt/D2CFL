using AutoMapper;
using D2CFL.Data.Interfaces;
using System.Threading.Tasks;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
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

        //public IList<PlayerDto> GetList()
        //{
        //    return Mapper.Map<IList<PlayerEntity>, List<PlayerDto>>(_leagueUnitOfWork.PlayerRepository.GetList()
        //            .Include(x => x.Position)
        //            .Include(x => x.Team).ToList()
        //        );
        //}
        public async Task<IList<PlayerDto>> GetList()
        {
            return await _leagueUnitOfWork.PlayerRepository.GetListAsync<PlayerDto>(_dataMapper);
        }

        public async Task<PlayerDto> Get()
        {
            //var players = Mapper.Map<IList<PlayerEntity>, List<PlayerDto>>(_leagueUnitOfWork.PlayerRepository.GetList()
            //    .Include(x => x.Position)
            //    .Include(x => x.Team).ToList()
            //);

            return await _leagueUnitOfWork.PlayerRepository.GetAsync<PlayerDto>(_dataMapper);
        }

        public void Insert(PlayerDto playerDto)
        {
            _leagueUnitOfWork.PlayerRepository.Insert(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));

            _leagueUnitOfWork.Save();
        }

        public void Update(PlayerDto playerDto)
        {
            var player = _leagueUnitOfWork.PlayerRepository.Get();

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