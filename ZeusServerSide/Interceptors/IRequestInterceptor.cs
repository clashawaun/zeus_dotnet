using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Interceptors.Contexts;

namespace ZeusServerSide.Interceptors
{
    /// <summary>
    /// The LoggingInterceptor interface.
    /// </summary>
    public interface IRequestInterceptor
    {
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
