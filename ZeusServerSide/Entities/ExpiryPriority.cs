using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    public class ExpiryPriority : IPriority
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int CalculatePriority(IItem item, Product product)
        {
            var priorityScore = 0;
            var today = DateTime.Now;
            var expiry = item.ExpiryDate;
            var manufacture = item.ManufactureDate;
            if (expiry == null)
            {
                priorityScore += (today - manufacture).Days;
            }
            else
            {
                priorityScore += (today - expiry.Value).Days;
            }

            return priorityScore;
        }
    }
}
