using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ZeusEntities.State;

namespace ZeusModels.Models
{
    /// <summary>
    /// The product model.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        public float Depth { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Gets or sets the priority id.
        /// </summary>
        [ForeignKey("Priority")]
        public int PriorityId { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public PriorityModel Priority { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public ProductState State { get; set; }

        // Product can have multiple orders
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public ICollection<OrderModel> Orders { get; set; } 
    }
}
