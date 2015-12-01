using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The Item interface.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        Product Product { get; set; }

        /// <summary>
        /// Gets or sets the manufacture date.
        /// </summary>
        DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        DateTime? ExpiryDate { get; set; }

        DateTime? QueuedTime { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        string Sku { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        ItemState State { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the x placement point.
        /// </summary>
        int XPlacementPoint { get; set; }

        /// <summary>
        /// Gets or sets the cubby id.
        /// </summary>
        int CubbyId { get; set; }
    }
}
