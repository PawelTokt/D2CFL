using D2CFL.Database.TestData.Organization;

namespace D2CFL.Database.TestData
{
    public class Service
    {
        private readonly OrganizationService _organizationService;

        public Service(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        public void Run(string environmentName)
        {
            // Organization
            _organizationService.Run(environmentName);
        }
    }
}