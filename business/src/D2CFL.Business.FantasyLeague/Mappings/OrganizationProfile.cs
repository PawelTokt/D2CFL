using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Organization;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
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