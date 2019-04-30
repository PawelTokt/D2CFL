using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Participant;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<ParticipantEntity, ParticipantDto>()
                .ForMember(x => x.OrganizationName, opts => opts.MapFrom(src => src.Organization.Name));

            CreateMap<IParticipantDto, ParticipantEntity>()
                .ForMember(x => x.OrganizationName, opts => opts.Ignore());
        }
    }
}
