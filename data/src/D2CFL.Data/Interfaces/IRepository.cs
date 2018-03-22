using System.Threading.Tasks;
using System.Collections.Generic;

namespace D2CFL.Data.Interfaces
{
    /// <summary>
    /// Interface of repository for data layer.
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Gets entity from repository by Id.
        /// </summary>
        /// <param name="id">The Entity Id</param>
        /// <returns><cref>TEntity</cref>.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Asynchronously gets entity from repository by Id.
        /// </summary>
        /// <param name="id">The Entity Id</param>
        /// <returns><cref>Task{TEntity}</cref>.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Gets entities from repository.
        /// </summary>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        IList<TEntity> GetList();

        /// <summary>
        /// Asynchronously gets entities from repository.
        /// </summary>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        Task<IList<TEntity>> GetListAsync();

        /// <summary>
        /// Inserts entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity.</returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Asynchronously inserts entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><cref>TEntity</cref>.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Updates entity in the repository.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity.</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);
    }
}