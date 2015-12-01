using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Interceptors;
using ZeusServerSide.Interceptors.Contexts;

namespace ZeusServerApplication.Interceptor
{
    /// <summary>
    /// The request logging interceptor.
    /// </summary>
    public class RequestLoggingInterceptor : IRequestInterceptor
    {
        public void OnRequestRecieved(IRequestInterceptorContext context)
        {
            Console.WriteLine("On Request Recieved called - Interceptor");
            Console.WriteLine($"{context.OperationInvoked} has been invoked\n");
        }

        public void OnRequestComplete(IRequestInterceptorContext context)
        {
            Console.WriteLine("On Request Complete called - Interceptor");
            Console.WriteLine($"{context.OperationInvoked} has been invoked and response {context.GetCurrentServerResponse.Body} was generated\n");
        }
    }
}
