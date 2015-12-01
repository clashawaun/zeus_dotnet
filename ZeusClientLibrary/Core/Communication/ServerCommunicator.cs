using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;

namespace ZeusClientLibrary.Core.Communication
{
    /// <summary>
    /// The server communicator.
    /// </summary>
    public class ServerCommunicator : IServerCommunicator
    {
        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The send server message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="IServerMessage"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IServerMessage SendServerMessage(IServerMessage message)
        {
            using (var serverConnection = new TcpClient())
            {
                serverConnection.Connect(this.Endpoint, this.Port);
                if (!serverConnection.Connected)
                {
                    throw new Exception($"Failed to connect to Zeus server at endpoint {this.Endpoint} on port {this.Port}");
                }
                
                var stream = serverConnection.GetStream();
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, (ServerMessage)message);
                try
                {
                    return (ServerMessage)formatter.Deserialize(stream);
                }
                catch (Exception)
                {
                    throw new Exception("Invalid response from server");
                }
            }
        }
    }
}
