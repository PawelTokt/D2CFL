using AutoMapper;
using System.Linq;
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

        public async Task<TeamDto> Get(int id)
        {
            var teams = await _leagueUnitOfWork.TeamRepository.GetListAsync<TeamDto>(_dataMapper);

            return teams.FirstOrDefault(x => x.Id == id);
        }

        public async Task Insert(TeamDto teamDto)
        {
            await _leagueUnitOfWork.TeamRepository.InsertAsync(Mapper.Map<TeamDto, TeamEntity>(teamDto));

            await _leagueUnitOfWork.SaveAsync();
        }

        public void Update(TeamDto teamDto)
        {
            _leagueUnitOfWork.TeamRepository.Update(Mapper.Map<TeamDto, TeamEntity>(teamDto));

            _leagueUnitOfWork.Save();
        }

        public void Delete(TeamDto teamDto)
        {
            _leagueUnitOfWork.TeamRepository.Delete(Mapper.Map<TeamDto, TeamEntity>(teamDto));

            _leagueUnitOfWork.Save();
        }
    }
}