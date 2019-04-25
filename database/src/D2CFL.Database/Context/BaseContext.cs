using Microsoft.EntityFrameworkCore;

namespace D2CFL.Database.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }
    }
}
