using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;

namespace ZeusClientLibrary.Core.Communication
{
    /// <summary>
    /// The ServerCommunicator interface.
    /// </summary>
    public interface IServerCommunicator
    {
        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// The send server message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="IServerMessage"/>.
        /// </returns>
        IServerMessage SendServerMessage(IServerMessage message);
    }
}
