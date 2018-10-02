using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using Aurochses.Data.Extensions;
using AutoMapper;
using D2CFL.Business.Organization.Contract.Player;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Business.Organization
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IOrganizationUnitOfWork _unitOfWork;

        public PlayerService(IMapper mapper, IDataMapper dataMapper, IOrganizationUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerDto>> GetList()
        {
            return await _unitOfWork.PlayerRepository.GetListAsync<PlayerDto>(_dataMapper);
        }

        public async Task<PlayerDto> Get(Guid id)
        {
            return await _unitOfWork.PlayerRepository.GetAsync<PlayerDto, PlayerEntity, Guid>(_dataMapper, id);
        }

        public async Task<PlayerDto> Add(IPlayerDto item)
        {
            var entity = await _unitOfWork.PlayerRepository.InsertAsync(_mapper.Map<PlayerEntity>(item));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerDto>(entity);
        }

        public async Task<PlayerDto> Edit(Guid id, IPlayerDto item)
        {
            var entity = await _unitOfWork.PlayerRepository.GetAsync(id);
            if (entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.PlayerRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PlayerDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.PlayerRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}