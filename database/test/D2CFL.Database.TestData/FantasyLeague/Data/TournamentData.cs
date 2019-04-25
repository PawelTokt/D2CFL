using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class TournamentData
    {
        public static IEnumerable<TournamentEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"FantasyLeague\Data", nameof(TournamentData), environmentName);

            return configuration.GetSection("Data").Get<IList<TournamentEntity>>();
        }
    }
}
