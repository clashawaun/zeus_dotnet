using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusModels.Models;
using ZeusServerSide.Entities;
using ZeusServerSide.Persistance.Context;

namespace ZeusServerSide.Persistance
{
    /// <summary>
    /// The shelf repository.
    /// </summary>
    public class ShelfRepository : IRepository<IShelf, ShelfModel>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        public DbSet<ShelfModel> DbSet { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShelfRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ShelfRepository(ZeusDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IShelf"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IShelf Get(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get or default.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IShelf"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IShelf GetOrDefault(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entityToAdd">
        /// The entity to add.
        /// </param>
        /// <returns>
        /// The <see cref="IShelf"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IShelf Add(IShelf entityToAdd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entityToUpdate">
        /// The entity to update.
        /// </param>
        /// <returns>
        /// The <see cref="IShelf"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IShelf Update(IShelf entityToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entityToDelete">
        /// The entity to delete.
        /// </param>
        /// <returns>
        /// The <see cref="IShelf"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IShelf Delete(IShelf entityToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
