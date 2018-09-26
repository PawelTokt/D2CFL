using AutoMapper;
using D2CFL.Business.Organization.Contract.Organization;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Business.Organization.Mappings
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<OrganizationEntity, OrganizationDto>();

            CreateMap<IOrganizationDto, OrganizationEntity>();
        }
    }
}
