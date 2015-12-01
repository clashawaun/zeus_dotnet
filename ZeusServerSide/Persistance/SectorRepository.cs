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
    public class SectorRepository : IRepository<Sector, SectorModel>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        public DbSet<SectorModel> DbSet { get; }

        public SectorRepository(ZeusDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Sectors;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Sector"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Sector Get(object id)
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
        /// The <see cref="Sector"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Sector GetOrDefault(object id)
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
        /// The <see cref="Sector"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Sector Add(Sector entityToAdd)
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
        /// The <see cref="Sector"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Sector Update(Sector entityToUpdate)
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
        /// The <see cref="Sector"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Sector Delete(Sector entityToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
