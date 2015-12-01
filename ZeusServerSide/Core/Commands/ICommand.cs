using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusServerSide.Entities;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Commands
{
    /// <summary>
    /// The Command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IServerMessage> Execute(IServerMessage request);
    }
}
