using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The item.
    /// </summary>
    public class Item : IItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the queued time.
        /// </summary>
        public DateTime? QueuedTime { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public ItemState State { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the x placement point.
        /// </summary>
        public int XPlacementPoint { get; set; }

        /// <summary>
        /// Gets or sets the cubby id.
        /// </summary>
        public int CubbyId { get; set; }
    }
}
