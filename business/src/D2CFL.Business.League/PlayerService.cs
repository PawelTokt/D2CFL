using AutoMapper;
using System.Linq;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League
{
    public class PlayerService : IPlayerService
    {
        private readonly ILeagueUnitOfWork _leagueUnitOfWork;

        public PlayerService(ILeagueUnitOfWork leagueUnitOfWork)
        {
            _leagueUnitOfWork = leagueUnitOfWork;
        }

        public IList<PlayerDto> GetList()
        {
            return Mapper.Map<IList<PlayerEntity>, List<PlayerDto>>(_leagueUnitOfWork.PlayerRepository.GetList()
                    .Include(x => x.Position)
                    .Include(x => x.Team).ToList()
                );
        }

        public PlayerDto Get(int id)
        {
            var players = Mapper.Map<IList<PlayerEntity>, List<PlayerDto>>(_leagueUnitOfWork.PlayerRepository.GetList()
                .Include(x => x.Position)
                .Include(x => x.Team).ToList()
            );

            return players.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(PlayerDto playerDto)
        {
            _leagueUnitOfWork.PlayerRepository.Insert(Mapper.Map<PlayerDto, PlayerEntity>(playerDto));

            _leagueUnitOfWork.Save();
        }

        public void Update(PlayerDto playerDto)
        {
            var player =  _leagueUnitOfWork.PlayerRepository.Get(playerDto.Id);

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