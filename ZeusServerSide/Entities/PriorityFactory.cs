using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The priority factory.
    /// </summary>
    public class PriorityFactory
    {
        /// <summary>
        /// The get priority.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IPriority"/>.
        /// </returns>
        public static IPriority GetPriority(int id)
        {
            switch (id)
            {
                case 1:
                { 
                    return new ExpiryPriority();
                }

                default:
                {
                    return null;
                }
            }
        }
    }
}
