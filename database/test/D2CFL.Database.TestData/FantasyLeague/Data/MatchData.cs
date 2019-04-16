using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class MatchData
    {
        public static IEnumerable<MatchEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"FantasyLeague\Data", nameof(MatchData), environmentName);

            return configuration.GetSection("Data").Get<IList<MatchEntity>>();
        }
    }
}