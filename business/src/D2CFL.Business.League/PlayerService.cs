using AutoMapper;
using D2CFL.Data.League.Entities;
using System.Collections.Generic;
using D2CFL.Data.League.Interfaces;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League
{
    public class PlayerService : IPlayerSerivice
    {
        private readonly ILeagueUnitOfWork _leagueUnitOfWork;

        public PlayerService(ILeagueUnitOfWork leagueUnitOfWork)
        {
            _leagueUnitOfWork = leagueUnitOfWork;
        }

        public IList<PlayerDto> GetList()
        {
            return Mapper.Map<IList<PlayerEntity>, List<PlayerDto>>(_leagueUnitOfWork.PlayerRepository.GetList());
        }
    }
}