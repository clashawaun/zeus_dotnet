using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrionWindows.Utils;
using ZeusEntities.Communication;
using ZeusServerSide.Core.Commands;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;
using IConfig = ZeusServerSide.Utils.IConfig;

namespace ZeusServerSide.Core.Handler
{
    /// <summary>
    /// The work handler.
    /// </summary>
    public class WorkHandler : IHandler
    {
        /// <summary>
        /// The _commands.
        /// </summary>
        private Dictionary<string, ICommand> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkHandler"/> class.
        /// </summary>
        /// <param name="commands">
        /// The commands.
        /// </param>
        public WorkHandler()
        {
            this._commands = GenerateCommandMap();
        }

        /// <summary>
        /// Gets or sets the successor.
        /// </summary>
        public IHandler Successor { get; set; }

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        public IConfig Config { get; set; }

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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public async Task HandleRequest(IServerMessage request, IServerMessage response)
        {
            // Check if authentication passed
            if (request.User == null)
            {
                // Do nothing if this happens, the auth segement will have dealt
                // with this state
            }
            else if (!this._commands.ContainsKey(request.Message))
            {
                response.Message = $"{request.Message}Error";
                response.Body = ParserFactory.GetDataParser(request.DataType).SerializeData(new ErrorResponse()
                {
                    Reason = $"The operation {request.Message} is not available on the server",
                    Code = 100
                });
            }
            else
            {
                var commandResponse = await this._commands[request.Message].Execute(request);
                response.DataType = request.DataType;
                response.Body = commandResponse.Body;
                response.Message = commandResponse.Message;
                response.User = null;
            }

            // Check if there is a successor for this segment of the chain
            if (Successor != null)
            {
                await Successor.HandleRequest(request, response);
            }
        }

        /// <summary>
        /// The generate command map.
        /// </summary>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        private static Dictionary<string, ICommand> GenerateCommandMap()
        {
            return new Dictionary<string, ICommand>
            {
                { "PlaceOrder", new OrderCommand() },
                { "GetAllProducts", new GetProductsCommand() },
                { "GetProduct", new GetProductCommand() }
            };
        }


    }
}
