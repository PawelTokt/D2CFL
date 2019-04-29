using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class PlayerStatisticsData
    {
        public static IEnumerable<PlayerStatisticsEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"FantasyLeague\Data", nameof(PlayerStatisticsData), environmentName);

            return configuration.GetSection("Data").Get<IList<PlayerStatisticsEntity>>();
        }
    }
}
