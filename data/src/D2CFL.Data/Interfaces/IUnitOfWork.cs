using System;
using System.Threading.Tasks;

namespace D2CFL.Data.Interfaces
{
    /// <summary>
    /// Interface of UnitOfWork for data layer.
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all changes.
        /// </summary>
        void Save();

        /// <summary>
        /// Asynchronously saves all changes.
        /// </summary>
        Task SaveAsync();
    }
}