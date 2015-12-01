using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;
using ZeusModels.Models;
using ZeusServerSide.Entities;
using ZeusServerSide.Mapping;
using ZeusServerSide.Persistance.Context;

namespace ZeusServerSide.Persistance
{
    /// <summary>
    /// The item repository.
    /// </summary>
    public class ItemRepository : IRepository<IItem, ItemModel>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        public DbSet<ItemModel> DbSet { get; }

        public ItemRepository(ZeusDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Items;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IItem"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IItem Get(object id)
        {
            var result = this.Context.Items.Find((int)id);
            if (result == null)
            {
                throw new Exception("No product found with that ID");
            }

            // Mapping should be moved to another class
            return new Item()
            {
                Id = result.Id,
                CubbyId = result.CubbyId ?? -1,
                ManufactureDate = result.ManufactureDate
            };
        }

        /// <summary>
        /// The get or default.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IItem"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IItem GetOrDefault(object id)
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
        /// The <see cref="IItem"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IItem Add(IItem entityToAdd)
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
        /// The <see cref="IItem"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IItem Update(IItem entityToUpdate)
        {
            var itemModel = this.DbSet.Find(entityToUpdate.Id);
            if (itemModel == null)
            {
                throw new Exception("Mapped model not found");
            }

            itemModel.XPlacementPoint = entityToUpdate.XPlacementPoint;
            itemModel.CubbyId = entityToUpdate.CubbyId;
            itemModel.ExpiryDate = entityToUpdate.ExpiryDate;
            itemModel.ItemState = entityToUpdate.State;
            itemModel.ManufactureDate = entityToUpdate.ManufactureDate;
            itemModel.ProductId = entityToUpdate.Product.Id;
            itemModel.Sku = entityToUpdate.Sku;
            itemModel.UserId = entityToUpdate.UserId;
            itemModel.QueuedTime = entityToUpdate.QueuedTime;
            return entityToUpdate;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entityToDelete">
        /// The entity to delete.
        /// </param>
        /// <returns>
        /// The <see cref="IItem"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IItem Delete(IItem entityToDelete)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get available item by product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        public ICollection<IItem> GetAvailableItemByProduct(Product product)
        {
            var itemModels = this.DbSet.Include(x => x.Product).Where(x => x.ProductId == product.Id && x.ItemState == ItemState.Available);
            var itemDomainObjects = new List<IItem>();
            foreach (var item in itemModels)
            {
                itemDomainObjects.Add(new Item()
                {
                    Id = item.Id,
                    ExpiryDate = item.ExpiryDate,
                    ManufactureDate = item.ManufactureDate,
                    Product = Mapper.MapProductModelToDomain(item.Product),
                    Sku = item.Sku,
                    State = item.ItemState,
                    UserId = item.UserId,
                    XPlacementPoint = item.XPlacementPoint,
                    CubbyId = item.CubbyId ?? -1
                });
            }
            return itemDomainObjects;
        }
    }
}
