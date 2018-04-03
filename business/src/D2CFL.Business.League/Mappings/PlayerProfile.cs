using AutoMapper;
using D2CFL.Data.League.Contract;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerEntity, PlayerDto>()
                .ForMember(x => x.Team, opt => opt.MapFrom(src => src.TeamEntity.Name))
                .ForMember(x => x.Position, opt => opt.MapFrom(x => x.PositionEntity.Name));

            CreateMap<PlayerDto, PlayerEntity>();
            //.ForMember(x => x.Position, opt => opt.Ignore())
            //.ForMember(x => x.Team, opt => opt.Ignore());
        }
    }
}