using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Persistance.Context;

namespace ZeusServerSide.Persistance
{
    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TD">The Domain object type</typeparam>
    /// <typeparam name="TM">The persistance model type </typeparam>
    public interface IRepository<TD, TM>
        where TM : class
        where TD : class
    {
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        DbSet<TM> DbSet { get; }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TD"/>.
        /// </returns>
        TD Get(object id);

        /// <summary>
        /// The get or default.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TD"/>.
        /// </returns>
        TD GetOrDefault(object id);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entityToAdd">
        /// The entity to add.
        /// </param>
        /// <returns>
        /// The <see cref="TD"/>.
        /// </returns>
        TD Add(TD entityToAdd);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entityToUpdate">
        /// The entity to update.
        /// </param>
        /// <returns>
        /// The <see cref="TD"/>.
        /// </returns>
        TD Update(TD entityToUpdate);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entityToDelete">
        /// The entity to delete.
        /// </param>
        /// <returns>
        /// The <see cref="TD"/>.
        /// </returns>
        TD Delete(TD entityToDelete);
    }
}
