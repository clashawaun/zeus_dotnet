using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusServerSide.Core.Operations;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;
using ZeusServerSide.Persistance;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Commands
{
    /// <summary>
    /// The get product command.
    /// </summary>
    public class GetProductCommand : ICommand
    {
        public Task<IServerMessage> Execute(IServerMessage request)
        {
            return new GetProduct().GenerateResponse(request);
        }
    }
}
