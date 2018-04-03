using AutoMapper;
using System.Linq;
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

        public async Task<PositionDto> Get(int id)
        {
            var positions = await _leagueUnitOfWork.PositionRepository.GetListAsync<PositionDto>(_dataMapper);

            return positions.FirstOrDefault(x => x.Id == id);
        }

        public async Task Insert(PositionDto positionDto)
        {
            await _leagueUnitOfWork.PositionRepository.InsertAsync(Mapper.Map<PositionDto, PositionEntity>(positionDto));

            await _leagueUnitOfWork.SaveAsync();
        }

        public void Update(PositionDto positionDto)
        {
            _leagueUnitOfWork.PositionRepository.Update(Mapper.Map<PositionDto, PositionEntity>(positionDto));

            _leagueUnitOfWork.Save();
        }

        public void Delete(PositionDto positionDto)
        {
            _leagueUnitOfWork.PositionRepository.Delete(Mapper.Map<PositionDto, PositionEntity>(positionDto));

            _leagueUnitOfWork.Save();
        }
    }
}