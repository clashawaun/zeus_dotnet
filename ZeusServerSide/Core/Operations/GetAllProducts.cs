using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.DTO;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Persistance;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Operations
{
    /// <summary>
    /// The get all products.
    /// </summary>
    public class GetAllProducts
    {
        /// <summary>
        /// The generate response.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IServerMessage> GenerateResponse(IServerMessage request)
        {
            var unitOfWork = new UnitOfWork();
            var productList = unitOfWork.ProductRepository.GetAllProducts();
            var productDtoList = new List<ProductDto>();
            foreach (var product in productList)
            {
                productDtoList.Add(new ProductDto()
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
                });
            }
            // Console.WriteLine(ParserFactory.GetDataParser(request.DataType).SerializeData(productDtoList));
            return new ServerMessage(request.Message + "Result", ParserFactory.GetDataParser(request.DataType).SerializeData(productDtoList));
        }
    }
}
