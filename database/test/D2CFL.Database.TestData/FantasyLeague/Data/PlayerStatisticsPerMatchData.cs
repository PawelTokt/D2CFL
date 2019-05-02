using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class PlayerStatisticsPerMatchData
    {
        public static IEnumerable<PlayerStatisticsPerMatchEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"FantasyLeague\Data", nameof(PlayerStatisticsPerMatchData), environmentName);

            return configuration.GetSection("Data").Get<IList<PlayerStatisticsPerMatchEntity>>();
        }
    }
}
