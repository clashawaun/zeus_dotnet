using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer : User
    {
        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        public string ShippingAddress { get; set; }
    }
}
