using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OrionWindows.Entities.Authentication;
using ZeusEntities.Communication;
using ZeusEntities.Type;
using ZeusServerSide.Core.Handler;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Dispatchers;
using ZeusServerSide.Interceptors;
using ZeusServerSide.Interceptors.Contexts;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Processing
{
    /// <summary>
    /// The server.
    /// </summary>
    public class Server : IServer
    {
        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        public IConfig Config { get; set; }

        private IServerMessage CurrentRequest { get; set; }

        private IServerMessage CurrentResponse { get; set; }

        private IDispatcher Dispatcher { get; }

        public Server()
        {
            Config = new Config()
            {
                SystemPublicKey =
                    new Key()
                    {
                        ApiKey = "zeus_pub_key",
                        Type = KeyType.ApplicationPublicKey,
                        ExpiryDate = DateTime.Now
                    },
                SystemSecretKey =
                    new Key()
                    {
                        ApiKey = "4ISJqHMO0XpLpMHXj77tjv1R7QKNYTptkGFKgrJdyX4=",
                        Type = KeyType.ApplicationSecretKey,
                        ExpiryDate = DateTime.Now
                    }
            };
            Dispatcher = new Dispatcher();
        }

        public void RegisterRequestInterceptor(IRequestInterceptor interceptor)
        {
            this.Dispatcher.Attach(interceptor);
        }

        public void UnRegisterRequestInterceptor(IRequestInterceptor interceptor)
        {
            this.Dispatcher.Remove(interceptor);
        }
        /// <summary>
        /// The start server instance.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void StartServerInstance()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The start server instance.
        /// </summary>
        /// <param name="port">
        /// The port.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public async void StartServerInstance(object port)
        {
            var listener = new TcpListener((int)port);
            listener.Start();
            Console.WriteLine($"A server instance is now listening {Dns.GetHostEntry("localhost").AddressList[0]} port {(int)port}");
            await ProcessIncommingRequests(listener);
        }

        /// <summary>
        /// The process incomming requests.
        /// </summary>
        /// <param name="listener">
        /// The listener.
        /// </param>
        private async Task ProcessIncommingRequests(TcpListener listener)
        {
            while (true)
            {
                var socket = listener.AcceptTcpClient();
                //Console.WriteLine("Initial Recieve, about to start deserialize");
                var stream = socket.GetStream();
                var binaryFormatter = new BinaryFormatter();
                CurrentRequest = (ServerMessage) binaryFormatter.Deserialize(stream);
                //Console.WriteLine("Request recieved, begin processing");
                //Console.WriteLine(CurrentRequest.Body);
                Dispatcher.OnRequestRecieved(new RequestInterceptorContext(GetCurrentServerResponse)
                {
                    OperationInvoked = CurrentRequest.Message
                });
                CurrentResponse = new ServerMessage();

                // Setup chain of responsibility
                var orionAuthenticate = new OrionAuthenticationHandler()
                {
                    Config = this.Config,
                    Successor = new WorkHandler()
                    {
                        Config = this.Config,
                        Successor = null
                    }
                };
                // Start the chain that will generate the response
                await orionAuthenticate.HandleRequest(CurrentRequest, CurrentResponse);
                //Console.WriteLine(CurrentResponse.Body);
                // Send the response back to the client
                Dispatcher.OnRequestComplete(new RequestInterceptorContext(GetCurrentServerResponse)
                {
                    OperationInvoked = CurrentRequest.Message
                });
                binaryFormatter.Serialize(stream, CurrentResponse);
                CurrentResponse = null;
                CurrentRequest = null;
                socket.Close();
            }
        }

        private IServerMessage GetCurrentServerResponse()
        {
            return CurrentResponse;
        }
    }
}
