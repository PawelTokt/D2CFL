using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class PlayerData
    {
        public static IEnumerable<PlayerEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"Organization\Data", nameof(PlayerData), environmentName);

            return configuration.GetSection("Data").Get<IList<PlayerEntity>>();
        }
    }
}