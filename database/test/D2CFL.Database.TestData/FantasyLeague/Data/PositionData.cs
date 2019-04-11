using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class PositionData
    {
        public static IEnumerable<PositionEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"Organization\Data", nameof(PositionData), environmentName);

            return configuration.GetSection("Data").Get<IList<PositionEntity>>();
        }
    }
}