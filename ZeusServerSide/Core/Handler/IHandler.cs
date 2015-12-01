using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Handler
{
    // Chain of responsibility
    /// <summary>
    /// The Handler interface.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Gets or sets the successor.
        /// </summary>
        IHandler Successor { get; set; }

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        IConfig Config { get; set; }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task HandleRequest(IServerMessage request, IServerMessage response);
    }
}
