using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusModels.Models;

namespace ZeusServerSide.Persistance.Context
{
    /// <summary>
    /// The zeus db context.
    /// </summary>
    public class ZeusDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeusDbContext"/> class.
        /// </summary>
        public ZeusDbContext() : base()
        {
        }

        /// <summary>
        /// Gets or sets the cubbies.
        /// </summary>
        public virtual DbSet<CubbyModel> Cubbies { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public virtual DbSet<ItemModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the priorities.
        /// </summary>
        public virtual DbSet<PriorityModel> Priorities { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual DbSet<ProductModel> Products { get; set; }

        /// <summary>
        /// Gets or sets the shelves.
        /// </summary>
        public virtual DbSet<ShelfModel> Shelves { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public virtual DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public virtual DbSet<OrderModel> Orders { get; set; }

        /// <summary>
        /// Gets or sets the sectors.
        /// </summary>
        public virtual DbSet<SectorModel> Sectors { get; set; }
    }
}
