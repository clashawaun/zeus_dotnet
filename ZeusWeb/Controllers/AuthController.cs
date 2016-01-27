using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeusWeb.Controllers
{
    /// <summary>
    /// The auth controller.
    /// </summary>
    public class AuthController : Controller
    {
        // GET: Auth
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The orion.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Orion(string key)
        {
            if (key == null || key.Equals(string.Empty))
            {
                return this.Redirect("http://orion.shanecraven.com/Federation/Login?returnurl=http://zeus.shanecraven.com/Auth/Orion&appid=Zeus");
            }

            Response.Cookies.Add(new HttpCookie("OrionUser", key));
            return this.RedirectToAction("Index", "Home");
        }
    }
}