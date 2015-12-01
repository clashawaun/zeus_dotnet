using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusEntities.DTO
{
    /// <summary>
    /// The order dto.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public ICollection<ProductDto> Products { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public ICollection<ItemDto> Items { get; set; }

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
