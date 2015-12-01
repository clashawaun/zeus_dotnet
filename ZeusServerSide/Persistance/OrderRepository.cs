using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZeusModels.Models;
using ZeusServerSide.Entities;
using ZeusServerSide.Mapping;
using ZeusServerSide.Persistance.Context;

namespace ZeusServerSide.Persistance
{
    /// <summary>
    /// The order repository.
    /// </summary>
    public class OrderRepository : IRepository<Order, OrderModel>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        public DbSet<OrderModel> DbSet { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public OrderRepository(ZeusDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Orders;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Order"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Order Get(object id)
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
        /// The <see cref="Order"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Order GetOrDefault(object id)
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
        /// The <see cref="Order"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Order Add(Order entityToAdd)
        {
            var itemModels = new List<ItemModel>();
            // Get the related Item Models
            foreach (var itemModel in entityToAdd.Items.Select(item => this.Context.Items.Find(item.Id)))
            {
                if (itemModel == null)
                {
                    throw new Exception("One or more items in the order is null");
                }

                itemModels.Add(itemModel);
            }

            var order = new OrderModel()
            {
                Items = itemModels,
                ShippingAddress = entityToAdd.ShippingAddress,
                Status = entityToAdd.Status
            };
            this.DbSet.Add(order);
            return entityToAdd;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entityToUpdate">
        /// The entity to update.
        /// </param>
        /// <returns>
        /// The <see cref="Order"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Order Update(Order entityToUpdate)
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
        /// The <see cref="Order"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Order Delete(Order entityToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
