using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The error response.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public int Code { get; set; }
    }
}
