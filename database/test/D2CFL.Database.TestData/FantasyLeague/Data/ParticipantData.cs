using System.Collections.Generic;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.FantasyLeague.Data
{
    public class ParticipantData
    {
        public static IEnumerable<ParticipantEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"FantasyLeague\Data", nameof(ParticipantData), environmentName);

            return configuration.GetSection("Data").Get<IList<ParticipantEntity>>();
        }
    }
}
