using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public ICollection<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public ICollection<IItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        public string ShippingAddress { get; set; }
    }
}
