using System;
using D2CFL.Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data
{
    /// <summary>
    /// UnitOfWork for data layer.
    /// </summary>
    /// <seealso cref="T:D2CFL.Data.Interfaces.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IList<object> _repositories;
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new List<object>();
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        protected DbContext DbContext => _dbContext;

        /// <summary>
        /// Saves all changes on the DB.
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves all changes on the DB.
        /// </summary>
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Dispose object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// are disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer: only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">
        /// Indicates, whether method has been
        /// called directly by user code from Dispose() or from Finalizer.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                // unmanaged resources would be cleaned up here.
                return;
            }

            if (_isDisposed)
            {
                // no need to dispose twice.
                return;
            }

            // free managed resources 
            _isDisposed = true;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Registers repository instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <param name="repository">The repository.</param>
        protected void RegisterRepository<TEntity>(IRepository<TEntity> repository)
            where TEntity : IEntity
        {
            _repositories.Add(repository);
        }

        /// <summary>
        /// Gets the repository for specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the T entity.</typeparam>
        /// <returns>(IRepository{TEntity})_repositories.</returns>
        protected virtual IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : IEntity
        {
            return (IRepository<TEntity>)_repositories;
        }
    }
}