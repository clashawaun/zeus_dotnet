using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusServerSide.Core.Operations;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Persistance;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Commands
{
    /// <summary>
    /// The get products command.
    /// </summary>
    public class GetProductsCommand : ICommand
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
            return new GetAllProducts().GenerateResponse(request);
        }
    }
}
