using AutoMapper;
using D2CFL.Data.League.Contract;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamEntity, TeamDto>();

            CreateMap<TeamDto, TeamEntity>();
        }
    }
}