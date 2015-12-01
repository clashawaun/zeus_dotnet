using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;

/// <summary>
/// The get current response.
/// </summary>
public delegate IServerMessage GetCurrentResponse();
namespace ZeusServerSide.Interceptors.Contexts
{

    /// <summary>
    /// The request interceptor context.
    /// </summary>
    public class RequestInterceptorContext : IRequestInterceptorContext
    {
        private readonly GetCurrentResponse _responseAccessorPointer;

        public RequestInterceptorContext(GetCurrentResponse accessResponseMethod)
        {
            _responseAccessorPointer = accessResponseMethod;
        }

        /// <summary>
        /// Gets or sets the operation invoked.
        /// </summary>
        public string OperationInvoked { get; set; }

        /// <summary>
        /// Gets or sets the get current server response.
        /// </summary>
        public IServerMessage GetCurrentServerResponse => _responseAccessorPointer.Invoke();
    }
}
