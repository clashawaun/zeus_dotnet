using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.State;

namespace ZeusEntities.DTO
{
    /// <summary>
    /// The product dto.
    /// </summary>
    public class ProductDto
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
        /// Gets or sets the state.
        /// </summary>
        public ProductState State { get; set; }
    }
}
