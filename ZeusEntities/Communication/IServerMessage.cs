using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Type;

namespace ZeusEntities.Communication
{
    /// <summary>
    /// The ServerMessage interface.
    /// </summary>
    public interface IServerMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        string Body { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        DataType DataType { get; set; }
    }
}
