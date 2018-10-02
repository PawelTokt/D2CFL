using AutoMapper;
using D2CFL.Business.Organization.Contract.Player;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Business.Organization.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerEntity, PlayerDto>()
                .ForMember(x => x.OrganizationName, opts => opts.MapFrom(src => src.Organization.Name))
                .ForMember(x => x.PositionName, opts => opts.MapFrom(src => src.Position.Name));
            CreateMap<IPlayerDto, PlayerEntity>();
        }
    }
}