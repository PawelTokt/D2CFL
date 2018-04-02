using AutoMapper;
using D2CFL.WebSite.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Mappings
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