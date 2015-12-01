using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Interceptors;
using ZeusServerSide.Interceptors.Contexts;

namespace ZeusServerSide.Dispatchers
{
    /// <summary>
    /// The dispatcher.
    /// </summary>
    internal class Dispatcher : IDispatcher
    {
        /// <summary>
        /// The _registered interceptors.
        /// </summary>
        private readonly ISet<IRequestInterceptor> _registeredInterceptors;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dispatcher"/> class.
        /// </summary>
        public Dispatcher()
        {
            this._registeredInterceptors = new HashSet<IRequestInterceptor>();
        }

        /// <summary>
        /// The attach.
        /// </summary>
        /// <param name="interceptor">
        /// The interceptor.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Attach(IRequestInterceptor interceptor)
        {
            this._registeredInterceptors.Add(interceptor);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="interceptor">
        /// The interceptor.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Remove(IRequestInterceptor interceptor)
        {
            if (this._registeredInterceptors.Contains(interceptor))
            {
                this._registeredInterceptors.Remove(interceptor);
            }
        }

        /// <summary>
        /// The on request recieved.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void OnRequestRecieved(IRequestInterceptorContext context)
        {
            foreach (var interceptor in this._registeredInterceptors)
            {
                interceptor.OnRequestRecieved(context);
            }
        }

        /// <summary>
        /// The on request complete.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void OnRequestComplete(IRequestInterceptorContext context)
        {
            foreach (var interceptor in this._registeredInterceptors)
            {
                interceptor.OnRequestComplete(context);
            }
        }
    }
}
