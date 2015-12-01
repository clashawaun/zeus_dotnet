using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Type;

namespace ZeusEntities.Communication
{
    /// <summary>
    /// The server message.
    /// </summary>
    [Serializable]
    public class ServerMessage : IServerMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMessage"/> class.
        /// </summary>
        public ServerMessage()
        {
            this.Message = null;
            this.Body = null;
            this.User = null;

            // Assume that we are using JSON if not specified
            this.DataType = DataType.Json;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMessage"/> class.
        /// </summary>
        /// <param name="operataion">
        /// The operataion.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        public ServerMessage(string operataion, string body)
        {
            this.Message = operataion;
            this.Body = body;
            this.User = null;

            this.DataType = DataType.Json;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMessage"/> class.
        /// </summary>
        /// <param name="operataion">
        /// The operataion.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public ServerMessage(string operataion, string body, string user)
        {
            this.Message = operataion;
            this.Body = user;
            this.User = user;

            this.DataType = DataType.Json;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerMessage"/> class.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        public ServerMessage(string operation, string body, string user, DataType type)
        {
            this.Message = operation;
            this.Body = body;
            this.User = user;
            this.DataType = type;
        }
    }
}
