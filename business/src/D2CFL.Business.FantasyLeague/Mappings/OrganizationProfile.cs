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

            CreateMap<OrganizationEntity, ParticipantEntity>()
                .ForMember(x => x.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(x => x.MatchId, opts => opts.Ignore())
                .ForMember(x => x.OrganizationId, opts => opts.Ignore())
                .ForMember(x => x.Id, opts => opts.Ignore());
        }
    }
}
