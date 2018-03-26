﻿using AutoMapper;
using D2CFL.Data.League.Entities;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League.Mappings
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<PlayerEntity, PlayerDto>();
        }
    }
}