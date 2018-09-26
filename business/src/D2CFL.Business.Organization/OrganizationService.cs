using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using Aurochses.Data.Extensions;
using AutoMapper;
using D2CFL.Business.Organization.Contract.Organization;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Business.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IOrganizationUnitOfWork _unitOfWork;

        public OrganizationService(IMapper mapper, IDataMapper dataMapper, IOrganizationUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<OrganizationDto>> GetList()
        {
            return await _unitOfWork.OrganizationRepository.GetListAsync<OrganizationDto>(_dataMapper);
        }

        public async Task<OrganizationDto> Get(Guid id)
        {
            return await _unitOfWork.OrganizationRepository.GetAsync<OrganizationDto, OrganizationEntity, Guid>(_dataMapper, id);
        }

        public async Task<OrganizationDto> Add(IOrganizationDto item)
        {
            var entity = await _unitOfWork.OrganizationRepository.InsertAsync(_mapper.Map<OrganizationEntity>(item));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<OrganizationDto>(entity);
        }

        public async Task Edit(Guid id, IOrganizationDto item)
        {
            var entity = await _unitOfWork.OrganizationRepository.GetAsync(id);
            if(entity == null) return;

            entity = _mapper.Map(item, entity);

            _unitOfWork.OrganizationRepository.Update(entity);

            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.OrganizationRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}
