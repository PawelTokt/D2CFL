using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace D2CFL.Database
{
    /// <summary>
    /// Base class for Service.
    /// </summary>
    public abstract class ServiceBase
    {
        private readonly IList<DbContext> _dbContexts;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dbContexts">Database contexts.</param>
        protected ServiceBase(params DbContext[] dbContexts)
        {
            _dbContexts = new List<DbContext>(dbContexts);
        }

        /// <summary>
        /// Method for update database.
        /// </summary>
        public void Update()
        {
            foreach (var dbContext in _dbContexts)
            {
                dbContext.Database.Migrate();
            }
        }

        /// <summary>
        /// Method for update database on provided context.
        /// </summary>
        /// <param name="contextName">Database context name.</param>
        public void Update(string contextName)
        {
            _dbContexts.First(x => x.GetType().Name == contextName).Database.Migrate();
        }

        /// <summary>
        /// Method for update database on provided context to specific migration.
        /// </summary>
        /// <param name="contextName">Database context name.</param>
        /// <param name="migration">Migration.</param>
        public void Update(string contextName, string migration)
        {
            _dbContexts.First(x => x.GetType().Name == contextName).GetService<IMigrator>().Migrate(migration);
        }

        /// <summary>
        /// Reset database.
        /// </summary>
        public void Reset()
        {
            foreach (var dbContext in _dbContexts.Reverse())
            {
                dbContext.GetService<IMigrator>().Migrate("0");
            }
        }

        /// <summary>
        /// Apply data from SQL file to database.
        /// </summary>
        /// <param name="filePath">SQL file path.</param>
        public void ApplyDataFromSqlFile(string filePath = "data.sql")
        {
            _dbContexts.First().Database.ExecuteSqlCommand(File.ReadAllText(filePath));
        }
    }
}