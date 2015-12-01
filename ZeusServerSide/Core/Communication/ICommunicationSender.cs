using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Core.Communication
{
    /// <summary>
    /// The CommunicationSender interface.
    /// </summary>
    public interface ICommunicationSender
    {
        /// <summary>
        /// The send communication.
        /// </summary>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="endpoint">
        /// </param>
        void SendCommunication(string subject, string body, string endpoint);
    }
}
