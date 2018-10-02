using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.Organization.Contract.Organization
{
    public interface IOrganizationService
    {
        Task<IList<OrganizationDto>> GetList();
        Task<OrganizationDto> Get(Guid id);
        Task<OrganizationDto> Add(IOrganizationDto item);
        Task<OrganizationDto> Edit(Guid id, IOrganizationDto item);
        Task Delete(Guid id);
    }
}