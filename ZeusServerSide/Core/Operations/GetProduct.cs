using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;
using ZeusServerSide.Persistance;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Operations
{
    /// <summary>
    /// The get product.
    /// </summary>
    public class GetProduct
    {
        /// <summary>
        /// The generate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IServerMessage> GenerateResponse(IServerMessage request)
        {
            var unitOfWork = new UnitOfWork();
            var productDto = ParserFactory.GetDataParser(request.DataType).ParseData<ProductDto>(request.Body);
            if (productDto == null)
            {
                return new ServerMessage(request.Message + "Error",
                    ParserFactory.GetDataParser(request.DataType).SerializeData(new ErrorResponse()
                    {
                        Code = 101,
                        Reason = "Invalid DTO was provided"
                    }));
            }

            var product = unitOfWork.ProductRepository.GetOrDefault(productDto.Id);
            if (product == null)
            {
                return new ServerMessage(request.Message + "Error",
                    ParserFactory.GetDataParser(request.DataType).SerializeData(new ErrorResponse()
                    {
                        Code = 102,
                        Reason = "Invalid ID provided for an entity in the database"
                    }));
            }

            return new ServerMessage(request.Message + "Result",
                ParserFactory.GetDataParser(request.DataType).SerializeData(new ProductDto()
                {
                    Id = product.Id,
                    Weight = product.Weight,
                    Sku = product.Sku,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    State = product.State,
                    Width = product.Width,
                    Height = product.Height,
                    Depth = product.Depth
                }));

        }
    }
}
