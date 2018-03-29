using System.Linq;
using D2CFL.Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data
{
    /// <summary>
    /// Repository for data layer
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    /// <seealso cref="T:D2CFL.Data.Interfaces.IRepository{TEntity}" />
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity :  Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>The database context.</value>
        protected DbContext DbContext { get; }

        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <value>The database set.</value>
        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

        /// <summary>
        /// Gets entity of type T from repository.
        /// </summary>
        /// <param name="id">The Entity Id</param>
        /// <returns><cref>TEntity</cref>.</returns>
        public TEntity Get(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Asynchronously gets entity of type T from repository.
        /// </summary>
        /// <param name="id">The Entity Id</param>
        /// <returns><cref>TEntity</cref>.</returns>
        public async Task<TEntity> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets entities of type T from repository.
        /// </summary>
        /// <returns><cref>IQueryable{TEntity}</cref>.</returns>
        public IQueryable<TEntity> GetList()
        {
            return DbSet;
        }

        /// <summary>
        /// Asynchronously gets entities of type T from repository.
        /// </summary>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        public async Task<IList<TEntity>> GetListAsync()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Inserts entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity.</returns>
        public TEntity Insert(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        /// <summary>
        /// Asynchronously inserts entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><cref>TEntity</cref>.</returns>
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityEntry = await DbSet.AddAsync(entity);

            return entityEntry.Entity;
        }

        /// <summary>
        /// Updates entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity.</returns>
        public TEntity Update(TEntity entity)
        {
            DbSet.Attach(entity);

            DbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbContext.Entry(entity).State = EntityState.Deleted;

            DbSet.Remove(entity);
        }
    }
}