using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusEntities.DTO
{
    /// <summary>
    /// The item dto.
    /// </summary>
    public class ItemDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public ProductDto Product { get; set; }

        /// <summary>
        /// Gets or sets the manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public ItemState State { get; set; }
    }
}
