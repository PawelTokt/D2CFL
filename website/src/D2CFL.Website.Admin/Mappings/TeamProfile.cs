using AutoMapper;
using D2CFL.Website.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.Website.Admin.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDto, TeamViewModel>();

            CreateMap<TeamViewModel, TeamDto>();
        }
    }
}