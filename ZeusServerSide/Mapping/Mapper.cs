using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusModels.Models;
using ZeusServerSide.Entities;

namespace ZeusServerSide.Mapping
{
    /// <summary>
    /// The mapper.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// The map product model to domain.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        public static Product MapProductModelToDomain(ProductModel model)
        {
            return new Product()
            {
                Id = model.Id,
                Depth = model.Depth,
                Description = model.Description,
                Height = model.Height,
                Name = model.Name,
                Price = model.Price,
                Sku = model.Sku,
                State = model.State,
                Weight = model.Weight,
                Width = model.Width,
                Priority = PriorityFactory.GetPriority(model.PriorityId)
            };
        }

        /// <summary>
        /// The map product domain to model.
        /// </summary>
        /// <param name="domain">
        /// The domain.
        /// </param>
        /// <returns>
        /// The <see cref="ProductModel"/>.
        /// </returns>
        public static ProductModel MapProductDomainToModel(Product domain)
        {
            return new ProductModel();
        }

        /// <summary>
        /// The map existing item to model.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="itemModel">
        /// The item model.
        /// </param>
        public static void MapExistingItemToModel(IItem item, ItemModel itemModel)
        {
            itemModel.XPlacementPoint = item.XPlacementPoint;
            itemModel.CubbyId = item.CubbyId;
            itemModel.ExpiryDate = item.ExpiryDate;
            itemModel.ItemState = item.State;
            itemModel.ManufactureDate = item.ManufactureDate;
            itemModel.ProductId = item.Product.Id;
            itemModel.Sku = item.Sku;
            itemModel.UserId = item.UserId;
        }
    }
}
