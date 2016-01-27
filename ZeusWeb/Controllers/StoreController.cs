using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZeusClientLibrary;
using ZeusEntities.DTO;
using ZeusWeb.Attributes;
using ZeusWeb.Models;

namespace ZeusWeb.Controllers
{
    [Authenticated]
    public class StoreController : Controller
    {
        // GET: Product
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            var zeusOp = new ZeusOperations { UserKey = HttpContext.Items["OrionUserKey"].ToString() };
            var productsToDisplay = zeusOp.GetAllProducts();
            ViewBag.Products = productsToDisplay;
            return View();
        }

        /// <summary>
        /// The product.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Product(string id)
        {
            var zeusOp = new ZeusOperations { UserKey = HttpContext.Items["OrionUserKey"].ToString() };
            var product = zeusOp.GetProduct(Convert.ToInt32(id));
            ViewBag.Product = product;
            ViewBag.Id = id;
            return this.View(product);
        }

        /// <summary>
        /// The order.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Order(string id)
        {
            ViewBag.Oid = id;
            return View(new OrderViewModel());
        }

        /// <summary>
        /// The order.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Order(OrderViewModel model, string id)
        {
            var zeusOp = new ZeusOperations { UserKey = HttpContext.Items["OrionUserKey"].ToString() };
            var result = zeusOp.PlaceOrder(new OrderDto()
            {
                Products = new List<ProductDto>() {new ProductDto() {Id = Convert.ToInt32(id)}},
                ShippingAddress = $"{model.AddressLineOne},{model.AddressLineTwo},{model.City},{model.Country}"
            });

            ViewBag.Status = result ? "Order submitted successfully" : "Order failed";
            return View("OrderStatus");
        }
    }
}