using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeusModels.Models;
using ZeusServerSide.Entities;
using ZeusServerSide.Persistance.Context;

namespace ZeusServerSide.Persistance
{
    public class ProductRepository : IRepository<Product, ProductModel>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ZeusDbContext Context { get; }

        /// <summary>
        /// Gets the db set.
        /// </summary>
        public DbSet<ProductModel> DbSet { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ProductRepository(ZeusDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Products;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Product Get(object id)
        {
            var result = this.DbSet.Find((int)id);
            if (result == null)
            {
                throw new Exception("No product found with that ID");
            }

            // Mapping should be moved to another class
            return new Product()
            {
                Id = result.Id,
                Depth = result.Depth,
                Description = result.Description,
                Height = result.Height,
                Name = result.Name,
                Price = result.Price,
                Priority = PriorityFactory.GetPriority(result.PriorityId),
                Sku = result.Sku,
                State = result.State,
                Weight = result.Weight,
                Width = result.Width
            };
        }

        /// <summary>
        /// The get multiple products.
        /// </summary>
        /// <param name="productIds">
        /// The product ids.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ICollection<Product>> GetMultipleProducts(ICollection<int> productIds)
        {
            var domainProducts = new ConcurrentBag<Product>();
            var missingProduct = false;
            var timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Timer has started");
            foreach (var productId in productIds)
            {
                var productModel = this.DbSet.Find(productId);
                if (productModel == null)
                {
                    missingProduct = true;
                    break;
                }

                domainProducts.Add(new Product()
                {
                    Id = productModel.Id,
                    Depth = productModel.Depth,
                    Description = productModel.Description,
                    Height = productModel.Height,
                    Name = productModel.Name,
                    Price = productModel.Price,
                    Priority = PriorityFactory.GetPriority(productModel.PriorityId),
                    Sku = productModel.Sku,
                    State = productModel.State,
                    Weight = productModel.Weight,
                    Width = productModel.Width
                });
            }

            timer.Stop();
            Console.WriteLine(timer.Elapsed);

            if (missingProduct)
            {
                return null;
            }
            return domainProducts.ToList();
        }
            

        /// <summary>
        /// The get or default.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Product GetOrDefault(object id)
        {
            var result = this.DbSet.Find((int)id);
            if (result == null)
            {
                return null;
            }

            // Mapping should be moved to another class
            return new Product()
            {
                Id = result.Id,
                Depth = result.Depth,
                Description = result.Description,
                Height = result.Height,
                Name = result.Name,
                Price = result.Price,
                Priority = PriorityFactory.GetPriority(result.PriorityId),
                Sku = result.Sku,
                State = result.State,
                Weight = result.Weight,
                Width = result.Width
            };
        }

        /// <summary>
        /// The get all products.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        public ICollection<Product> GetAllProducts()
        {
            var productModels = this.DbSet.ToList();
            var productList = new List<Product>();
            foreach (var product in productModels)
            {
                productList.Add(new Product()
                {
                    Id = product.Id,
                    Depth = product.Depth,
                    Description = product.Description,
                    Height = product.Height,
                    Name = product.Name,
                    Price = product.Price,
                    Sku = product.Sku,
                    State = product.State,
                    Weight = product.Weight,
                    Width = product.Width,
                    Priority = PriorityFactory.GetPriority(product.PriorityId)
                });
            }
            return productList;
        } 

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entityToAdd">
        /// The entity to add.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Product Add(Product entityToAdd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entityToUpdate">
        /// The entity to update.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Product Update(Product entityToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entityToDelete">
        /// The entity to delete.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Product Delete(Product entityToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
