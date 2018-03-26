using AutoMapper;
using D2CFL.WebSite.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Mappings
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<PlayerDto, PlayerViewModel>();
        }
    }
}