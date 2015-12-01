using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeusServerApplication.Interceptor;
using ZeusServerSide.Core.Processing;

namespace ZeusServerApplication
{
    /// <summary>
    /// The program.
    /// </summary>
    public class ZeusServer
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[] { "5" };
            }
            if (args.Length == 1)
            {
                var threads = new Thread[Convert.ToInt32(args[0])];
                for (var i = 0; i < threads.Length; i++)
                {
                    var portNumber = 9000 + i;
                    var serverInstance = new Server();
                    serverInstance.RegisterRequestInterceptor(new RequestLoggingInterceptor());
                    threads[i] = new Thread(new ParameterizedThreadStart(serverInstance.StartServerInstance));
                    Console.WriteLine($"Starting Server Instance {i}");
                    threads[i].Start(portNumber);
                    Console.WriteLine($"Server Instance {i} has been started");
                }
                Console.WriteLine("All Server instances are runnning. Press any key to terminate all instances");
                Console.ReadKey();
            }
            else
            {

            }
        }
    }
}
