using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Core.Communication
{
    /// <summary>
    /// The sms sender.
    /// </summary>
    public class SmsSender : ICommunicationSender
    {
        /// <summary>
        /// The send communication.
        /// </summary>
        /// <param name="identifer">
        /// The identifer.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="endpoint"></param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SendCommunication(string subject, string body, string endpoint)
        {
            // Send SMS message using my text anywhere account
            var twoFactorSms = new net.textapp.www.Service();
            // REDACTED CODE TO SEND SINCE IT CONTAINED CREDENTIALS
        }
    }
}
