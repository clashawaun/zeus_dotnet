using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusEntities.State;
using ZeusServerSide.Core.Communication;
using ZeusServerSide.Core.Error;
using ZeusServerSide.Core.Operations;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;
using ZeusServerSide.Persistance;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Commands
{
    /// <summary>
    /// The order command.
    /// </summary>
    public class OrderCommand : ICommand
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
        public Task<IServerMessage> Execute(IServerMessage request)
        {
            return new ProcessOrder().GenerateResponse(request);
        }
    }
}
