using AutoMapper;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
using System.Linq;
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
    }
}