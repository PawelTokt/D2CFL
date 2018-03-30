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
        /// <returns><cref>TEntity</cref>.</returns>
        TEntity Get();

        /// <summary>
        /// Gets model of type T from repository.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>TModel</cref></returns>
        TModel Get<TModel>(IDataMapper dataMapper);

        /// <summary>
        /// Asynchronously gets entity from repository by Id.
        /// </summary>
        /// <returns><cref>Task{TEntity}</cref>.</returns>
        Task<TEntity> GetAsync();

        /// <summary>
        /// Asynchronously gets model of type T from repository.
        /// If no entity is found, then null is returned.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>Task{TModel}</cref>.</returns>
        Task<TModel> GetAsync<TModel>(IDataMapper dataMapper);

        /// <summary>
        /// Gets entities of type T from repository.
        /// </summary>
        /// <returns><cref>IList{TEntity}</cref>.</returns>
        IList<TEntity> GetList();

        /// <summary>
        /// Gets models of type T from repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>IList{TModel}</cref>.</returns>
        IList<TModel> GetList<TModel>(IDataMapper dataMapper);

        /// <summary>
        /// Asynchronously gets entities of type T from repository.
        /// </summary>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        Task<IList<TEntity>> GetListAsync();

        /// <summary>
        /// Asynchronously gets models of type T from repository.
        /// </summary>
        /// <typeparam name="TModel">The type of the T model.</typeparam>
        /// <param name="dataMapper">The data mapper.</param>
        /// <returns><cref>Task{IList{TModel}}</cref>.</returns>
        Task<IList<TModel>> GetListAsync<TModel>(IDataMapper dataMapper);

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