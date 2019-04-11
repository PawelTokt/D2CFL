using Aurochses.Database.EntityFrameworkCore;
using D2CFL.Database.Context;

namespace D2CFL.Database
{
    public class Service : ServiceBase
    {
        public Service(BaseContext baseContext, FantasyLeagueContext leagueContext)
            : base(baseContext, leagueContext)
        {

        }
    }
}