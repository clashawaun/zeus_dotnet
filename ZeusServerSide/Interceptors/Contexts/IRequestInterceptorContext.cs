using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;

namespace ZeusServerSide.Interceptors.Contexts
{
    /// <summary>
    /// The RequestInterceptorContext interface.
    /// </summary>
    public interface IRequestInterceptorContext
    {
        /// <summary>
        /// Gets or sets the operation invoked.
        /// </summary>
        string OperationInvoked { get; set; }

        /// <summary>
        /// Gets the get current server response.
        /// </summary>
        IServerMessage GetCurrentServerResponse { get;  }
    }
}
