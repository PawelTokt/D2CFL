using D2CFL.Data.Interfaces;
using System.Threading.Tasks;
using D2CFL.Data.League.Contract;
using System.Collections.Generic;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League
{
    public class PositionService : IPositionService
    {
        private readonly IDataMapper _dataMapper;
        private readonly ILeagueUnitOfWork _leagueUnitOfWork;

        public PositionService(IDataMapper dataMapper, ILeagueUnitOfWork leagueUnitOfWork)
        {
            _dataMapper = dataMapper;
            _leagueUnitOfWork = leagueUnitOfWork;
        }
        public async Task<IList<PositionDto>> GetList()
        {
            return await _leagueUnitOfWork.PositionRepository.GetListAsync<PositionDto>(_dataMapper);
        }

        public Task<PositionDto> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(PositionDto playerDto)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PositionDto playerDto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(PositionDto playerDto)
        {
            throw new System.NotImplementedException();
        }
    }
}