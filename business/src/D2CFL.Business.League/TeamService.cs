using AutoMapper;
using D2CFL.Data.Interfaces;
using System.Threading.Tasks;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
using D2CFL.Business.League.Contract;


namespace D2CFL.Business.League
{
    public class TeamService : ITeamService
    {
        private readonly IDataMapper _dataMapper;
        private readonly ILeagueUnitOfWork _leagueUnitOfWork;

        public TeamService(IDataMapper dataMapper, ILeagueUnitOfWork leagueUnitOfWork)
        {
            _dataMapper = dataMapper;
            _leagueUnitOfWork = leagueUnitOfWork;
        }

        public async Task<IList<TeamDto>> GetList()
        {
            return await _leagueUnitOfWork.TeamRepository.GetListAsync<TeamDto>(_dataMapper);
        }

        public async Task<TeamDto> Get()
        {
            return await _leagueUnitOfWork.TeamRepository.GetAsync<TeamDto>(_dataMapper);
        }

        public async Task Insert(TeamDto teamDto)
        {
            await _leagueUnitOfWork.TeamRepository.InsertAsync(Mapper.Map<TeamDto, TeamEntity>(teamDto));

            await _leagueUnitOfWork.SaveAsync();
        }

        public void Update(TeamDto playerDto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TeamDto playerDto)
        {
            throw new System.NotImplementedException();
        }
    }
}