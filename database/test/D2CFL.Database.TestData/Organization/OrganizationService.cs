using System.Linq;
using D2CFL.Data.Organization.Contract;
using D2CFL.Database.Context;
using D2CFL.Database.TestData.Organization.Data;

namespace D2CFL.Database.TestData.Organization
{
    public class OrganizationService
    {
        private readonly OrganizationContext _context;

        public OrganizationService(OrganizationContext context)
        {
            _context = context;
        }

        public void Run(string enviromentName)
        {
            //Organization
            foreach (var item in OrganizationData.GetList(enviromentName))
            {
                if (_context.Set<OrganizationEntity>().Any(x => x.Id == item.Id))
                {
                    _context.Set<OrganizationEntity>().Update(item);
                }
                else
                {
                    _context.Set<OrganizationEntity>().Add(item);
                }
            }

            _context.SaveChanges();
        }
    }
}
