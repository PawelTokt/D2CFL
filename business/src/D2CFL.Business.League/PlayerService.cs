using AutoMapper;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
using D2CFL.Business.League.Contract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace D2CFL.Business.League
{
    public class PlayerService : IPlayerService
    {
        private readonly ILeagueUnitOfWork _leagueUnitOfWork;

        public PlayerService(ILeagueUnitOfWork leagueUnitOfWork)
        {
            _leagueUnitOfWork = leagueUnitOfWork;
        }

        public async Task<IList<PlayerDto>> GetList()
        {
            return Mapper.Map<IList<PlayerEntity>, List<PlayerDto>>(await _leagueUnitOfWork.PlayerRepository
                .GetList().Include(x => x.Position).Include(x => x.Team).ToListAsync());
        }

        public async Task Insert(PlayerDto playerDto)
        {
            await _leagueUnitOfWork.PlayerRepository.InsertAsync(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));
            //TODO: await _leagueUnitOfWork.SaveAsync();
        }

        public async Task Update(PlayerDto playerDto)
        {
            var entity = await _leagueUnitOfWork.PlayerRepository.GetAsync(playerDto.Id);
            _leagueUnitOfWork.PlayerRepository.Update(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));
            //TODO: await _leagueUnitOfWork.SaveAsync();
        }
    }
}