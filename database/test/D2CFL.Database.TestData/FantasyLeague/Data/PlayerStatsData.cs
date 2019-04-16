using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class PlayerStatsData
    {
        public static IEnumerable<PlayerStatsEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"FantasyLeague\Data", nameof(PlayerStatsData), environmentName);

            return configuration.GetSection("Data").Get<IList<PlayerStatsEntity>>();
        }
    }
}