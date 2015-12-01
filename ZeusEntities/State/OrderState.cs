using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusEntities.State
{
    /// <summary>
    /// The order status.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// The recieved.
        /// </summary>
        Recieved,

        /// <summary>
        /// The processing.
        /// </summary>
        Processing,

        /// <summary>
        /// The shipped.
        /// </summary>
        Shipped
    }
}
