﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurochses.Data;
using Aurochses.Data.Extensions;
using AutoMapper;
using D2CFL.Business.Organization.Contract.Position;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Business.Organization
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IDataMapper _dataMapper;
        private readonly IOrganizationUnitOfWork _unitOfWork;

        public PositionService(IMapper mapper, IDataMapper dataMapper, IOrganizationUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PositionDto>> GetList()
        {
            return await _unitOfWork.PositionRepository.GetListAsync<PositionDto>(_dataMapper);
        }

        public async Task<PositionDto> Get(Guid id)
        {
            return await _unitOfWork.PositionRepository.GetAsync<PositionDto, PositionEntity, Guid>(_dataMapper, id);
        }

        public async Task<PositionDto> Add(IPositionDto item)
        {
            var entity = await _unitOfWork.PositionRepository.InsertAsync(_mapper.Map<PositionEntity>(item));

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PositionDto>(entity);
        }

        public async Task<PositionDto> Edit(Guid id, IPositionDto item)
        {
            var entity = await _unitOfWork.PositionRepository.GetAsync(id);
            if (entity == null) return null;

            entity = _mapper.Map(item, entity);

            _unitOfWork.PositionRepository.Update(entity);

            return _mapper.Map<PositionDto>(entity);
        }

        public async Task Delete(Guid id)
        {
            _unitOfWork.PositionRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }
    }
}