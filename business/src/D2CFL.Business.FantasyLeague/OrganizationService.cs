using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Organization;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Data.FantasyLeague.Interfaces;

namespace D2CFL.Business.FantasyLeague
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IFantasyLeagueUnitOfWork _unitOfWork;

        public OrganizationService(IMapper mapper, IDataMapper dataMapper, IFantasyLeagueUnitOfWork unitOfWork)
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

        public async Task<OrganizationDto> Edit(Guid id, IOrganizationDto item)
        {
            var entity = await _unitOfWork.OrganizationRepository.GetAsync(id);
            if(entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.OrganizationRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<OrganizationDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            await SetParticipantNameOfDeletedOrganization(id);

            _unitOfWork.OrganizationRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }

        private async Task SetParticipantNameOfDeletedOrganization(Guid id)
        {
            var organization = await _unitOfWork.OrganizationRepository.GetAsync(id);
            if(organization == null) return;

            var participant = await _unitOfWork.ParticipantRepository.GetAsync(x => x.OrganizationId == id);
            if(participant == null) return;

            participant = _mapper.Map(organization, participant);

            _unitOfWork.ParticipantRepository.Update(participant);
        }
    }
}
