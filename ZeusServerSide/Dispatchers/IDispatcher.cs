using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Entities;
using ZeusServerSide.Interceptors;
using ZeusServerSide.Interceptors.Contexts;

namespace ZeusServerSide.Dispatchers
{
    /// <summary>
    /// The Dispatcher interface.
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="interceptor">
        /// The interceptor.
        /// </param>
        void Attach(IRequestInterceptor interceptor);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="interceptor">
        /// The interceptor.
        /// </param>
        void Remove(IRequestInterceptor interceptor);

        /// <summary>
        /// The on request recieved.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        void OnRequestRecieved(IRequestInterceptorContext context);

        /// <summary>
        /// The on request complete.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        void OnRequestComplete(IRequestInterceptorContext context);
    }
}
