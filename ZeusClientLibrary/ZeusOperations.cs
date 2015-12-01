using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OrionWindows.Entities.Authentication;
using ZeusClientLibrary.Core.Communication;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusEntities.Type;

namespace ZeusClientLibrary
{
    /// <summary>
    /// The operations.
    /// </summary>
    public class ZeusOperations
    {
        /// <summary>
        /// Gets or sets the communicator.
        /// </summary>
        public IServerCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the user key.
        /// </summary>
        public string UserKey { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeusOperations"/> class.
        /// </summary>
        public ZeusOperations()
        {
            if (Communicator == null)
            {
                Communicator = new ServerCommunicator() { Endpoint = "server.zeus.shanecraven.com", Port = 9000 };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeusOperations"/> class.
        /// </summary>
        /// <param name="communicator">
        /// The communicator.
        /// </param>
        public ZeusOperations(IServerCommunicator communicator)
        {
            this.Communicator = communicator;
        }

        /// <summary>
        /// The place order.
        /// </summary>
        /// <param name="newOrder">
        /// The new order.
        /// </param>
        /// <returns>
        /// The <see cref="OrderDto"/>.
        /// </returns>
        public bool PlaceOrder(OrderDto newOrder)
        {
            try
            {
                var result = this.Communicator.SendServerMessage(this.GenerateMessage("PlaceOrder", newOrder));
                return JsonConvert.DeserializeObject<OrderResultDto>(result.Body).Success;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public ProductDto GetProduct(int id)
        {
            var result = this.Communicator.SendServerMessage(this.GenerateMessage("GetProduct", new ProductDto() { Id = id }));
            return JsonConvert.DeserializeObject<ProductDto>(result.Body);
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            var result = this.Communicator.SendServerMessage(this.GenerateMessage("GetAllProducts", new ProductDto()));
            return JsonConvert.DeserializeObject<ICollection<ProductDto>>(result.Body);
        } 

        /// <summary>
        /// The convert key string to object.
        /// </summary>
        /// <returns>
        /// The <see cref="Key"/>.
        /// </returns>
        private Key ConvertKeyStringToObject()
        {
            return new Key() { ApiKey = this.UserKey, Type = KeyType.UserTempKey };
        }

        /// <summary>
        /// The generate message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <returns>
        /// The <see cref="IServerMessage"/>.
        /// </returns>
        private IServerMessage GenerateMessage(string message, object body)
        {
            return new ServerMessage()
            {
                Message = message,
                Body = JsonConvert.SerializeObject(body),
                User = JsonConvert.SerializeObject(ConvertKeyStringToObject()),
                DataType = DataType.Json
            };
        }
    }
}
