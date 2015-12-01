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
    /// The cubby repository.
    /// </summary>
    public class CubbyRepository : IRepository<ICubby, CubbyModel>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        public DbSet<CubbyModel> DbSet { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CubbyRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CubbyRepository(ZeusDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Cubbies;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ICubby"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ICubby Get(object id)
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
        /// The <see cref="ICubby"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ICubby GetOrDefault(object id)
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
        /// The <see cref="ICubby"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ICubby Add(ICubby entityToAdd)
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
        /// The <see cref="ICubby"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ICubby Update(ICubby entityToUpdate)
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
        /// The <see cref="ICubby"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ICubby Delete(ICubby entityToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
