using Microsoft.EntityFrameworkCore;

namespace D2CFL.Migrations.Context
{
    /// <summary>
    /// BaseContext.
    /// </summary>
    /// <seealso cref="T:Microsoft.EntityFrameworkCore.DbContext" />
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContext" /> class.
        /// </summary>
        /// <param name="dbContextOptions">The database context options.</param>
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}