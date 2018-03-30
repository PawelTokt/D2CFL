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
        /// Gets query of type T for repository.
        /// </summary>
        /// <returns><cref>IQueryable{TEntity}</cref>.</returns>
        protected IQueryable<TEntity> Query()
        {
            IQueryable<TEntity> query = DbSet;

            return query;
        }

        /// <summary>
        /// Gets query of type T for repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        protected IQueryable<TModel> Query<TModel>(IDataMapper dataMapper)
        {
            return dataMapper.Map<TModel>(Query());
        }

        /// <summary>
        /// Gets entity of type T from repository.
        /// </summary>
        /// <returns><cref>TEntity</cref>.</returns>
        public TEntity Get()
        {
            return DbSet.FirstOrDefault();
        }

        /// <summary>
        /// Gets model of type T from repository.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>TModel</cref></returns>
        public TModel Get<TModel>(IDataMapper dataMapper)
        {
            return Query<TModel>(dataMapper).FirstOrDefault();
        }

        /// <summary>
        /// Asynchronously gets entity of type T from repository.
        /// </summary>
        /// <returns><cref>TEntity</cref>.</returns>
        public async Task<TEntity> GetAsync()
        {
            return await DbSet.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Asynchronously gets model of type T from repository.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>Task{TModel}</cref>.</returns>
        public async Task<TModel> GetAsync<TModel>(IDataMapper dataMapper)
        {
            return await Query<TModel>(dataMapper).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets entities of type T from repository.
        /// </summary>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        public IList<TEntity> GetList()
        {
            return Query().ToList();
        }

        /// <summary>
        /// Gets models of type T from repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>IList{TModel}</cref>.</returns>
        public IList<TModel> GetList<TModel>(IDataMapper dataMapper)
        {
            return Query<TModel>(dataMapper).ToList();
        }

        /// <summary>
        /// Asynchronously gets entities of type T from repository.
        /// </summary>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        public async Task<IList<TEntity>> GetListAsync()
        {
            return await Query().ToListAsync();
        }

        /// <summary>
        /// Asynchronously gets models of type T from repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        public async Task<IList<TModel>> GetListAsync<TModel>(IDataMapper dataMapper)
        {
            return await Query<TModel>(dataMapper).ToListAsync();
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