using D2CFL.Database.TestData.FantasyLeague;

namespace D2CFL.Database.TestData
{
    public class Service
    {
        private readonly FantasyLeagueService _fantasyLeagueService;

        public Service(FantasyLeagueService fantasyLeagueService)
        {
            _fantasyLeagueService = fantasyLeagueService;
        }

        public void Run(string environmentName)
        {
            // Fantasy League
            _fantasyLeagueService.Run(environmentName);
        }
    }
}
