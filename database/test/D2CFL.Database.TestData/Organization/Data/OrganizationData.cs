using System.Collections.Generic;
using D2CFL.Data.Organization.Contract;
using Microsoft.Extensions.Configuration;

namespace D2CFL.Database.TestData.Organization.Data
{
    public class OrganizationData
    {
        public static IEnumerable<OrganizationEntity> GetList(string environmentName)
        {
            var configuration = Program.BuildConfiguration(@"Organization\Data", nameof(OrganizationData), environmentName);

            return configuration.GetSection("Data").Get<IList<OrganizationEntity>>();
        }
    }
}
