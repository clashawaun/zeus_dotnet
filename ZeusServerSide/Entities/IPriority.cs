using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The Priority interface.
    /// </summary>
    public interface IPriority
    {
        /// <summary>
        /// The calculate priority.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int CalculatePriority(IItem item, Product product);
    }
}
