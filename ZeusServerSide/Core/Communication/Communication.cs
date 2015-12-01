using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Core.Communication
{
    /// <summary>
    /// The user communication.
    /// Bridge Design Pattern
    /// </summary>
    public abstract class Communication
    {
        /// <summary>
        /// Gets or sets the communication communicator.
        /// </summary>
        public ICommunicationSender CommunicationCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// The send communication.
        /// </summary>
        public abstract void Send();
    }
}
