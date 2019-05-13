using System.Linq;
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
            foreach(var item in OrganizationData.GetList(enviromentName))
            {
                if(_context.Set<OrganizationEntity>().Any(x => x.Id == item.Id))
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
            foreach(var item in PositionData.GetList(enviromentName))
            {
                if(_context.Set<PositionEntity>().Any(x => x.Id == item.Id))
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
            foreach(var item in PlayerData.GetList(enviromentName))
            {
                if(_context.Set<PlayerEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<PlayerEntity>().Update(item);
                }
                else
                {
                    _context.Set<PlayerEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // PlayersStatistics
            foreach(var item in PlayerStatisticsData.GetList(enviromentName))
            {
                if(_context.Set<PlayerStatisticsEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<PlayerStatisticsEntity>().Update(item);
                }
                else
                {
                    _context.Set<PlayerStatisticsEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // Tournament
            foreach(var item in TournamentData.GetList(enviromentName))
            {
                if(_context.Set<TournamentEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<TournamentEntity>().Update(item);
                }
                else
                {
                    _context.Set<TournamentEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // Match
            foreach(var item in MatchData.GetList(enviromentName))
            {
                if(_context.Set<MatchEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<MatchEntity>().Update(item);
                }
                else
                {
                    _context.Set<MatchEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // Participant
            foreach(var item in ParticipantData.GetList(enviromentName))
            {
                if(_context.Set<ParticipantEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<ParticipantEntity>().Update(item);
                }
                else
                {
                    _context.Set<ParticipantEntity>().Add(item);
                }
            }

            _context.SaveChanges();

            // PlayersStatisticsPerMatch
            foreach(var item in PlayerStatisticsPerMatchData.GetList(enviromentName))
            {
                if(_context.Set<PlayerStatisticsPerMatchEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<PlayerStatisticsPerMatchEntity>().Update(item);
                }
                else
                {
                    _context.Set<PlayerStatisticsPerMatchEntity>().Add(item);
                }
            }

            _context.SaveChanges();
        }
    }
}
