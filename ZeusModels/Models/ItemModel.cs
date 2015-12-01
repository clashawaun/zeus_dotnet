using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusModels.Models
{
    /// <summary>
    /// The item model.
    /// </summary>
    public class ItemModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public ProductModel Product { get; set; }

        /// <summary>
        /// Gets or sets the cubby id.
        /// </summary>
        [ForeignKey("Cubby")]
        public int? CubbyId { get; set; }

        /// <summary>
        /// Gets or sets the cubby.
        /// </summary>
        public CubbyModel Cubby { get; set; }

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
        /// Gets or sets the item state.
        /// </summary>
        public ItemState ItemState { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the x placement point.
        /// </summary>
        public int XPlacementPoint { get; set; }
    }
}
