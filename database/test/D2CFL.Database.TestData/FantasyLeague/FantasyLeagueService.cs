﻿using System.Linq;
using D2CFL.Data.FantasyLeague.Contract;
using D2CFL.Database.Context;
using D2CFL.Database.TestData.FantasyLeague.Data;

namespace D2CFL.Database.TestData.FantasyLeague
{
    public class FantasyLeagueService
    {
        private readonly FantasyLeagueContext _context;

        public FantasyLeagueService(FantasyLeagueContext context)
        {
            _context = context;
        }

        public void Run(string enviromentName)
        {
            // Organization
            foreach (var item in OrganizationData.GetList(enviromentName))
            {
                if (_context.Set<OrganizationEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<OrganizationEntity>().Update(item);
                }
                else
                {
                    _context.Set<OrganizationEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // Position
            foreach (var item in PositionData.GetList(enviromentName))
            {
                if (_context.Set<PositionEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<PositionEntity>().Update(item);
                }
                else
                {
                    _context.Set<PositionEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // Player
            foreach (var item in PlayerData.GetList(enviromentName))
            {
                if (_context.Set<PlayerEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<PlayerEntity>().Update(item);
                }
                else
                {
                    _context.Set<PlayerEntity>().Add(item);
                }
            }

            _context.SaveChanges();
        }
    }
}