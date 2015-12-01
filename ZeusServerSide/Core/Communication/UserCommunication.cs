using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Core.Communication
{
    /// <summary>
    /// The user communication.
    /// </summary>
    public class UserCommunication : Communication
    {
        /// <summary>
        /// The send function
        /// </summary>
        public override void Send()
        {
            CommunicationCommunicator.SendCommunication(this.Subject, this.Body, this.Endpoint);
        }
    }
}
