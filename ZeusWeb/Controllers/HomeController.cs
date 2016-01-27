using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrionWindows.Entities.User;
using ZeusWeb.Attributes;

namespace ZeusWeb.Controllers
{
    /// <summary>
    /// The home controller.
    /// </summary>
  //   [Authenticated]
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            //ViewBag.Name = ((UserProfile)HttpContext.Items["OrionUser"]).Firstname + " " +
                           //((UserProfile)HttpContext.Items["OrionUser"]).Surname;
            ViewBag.Name = "There";
            return View();
        }

        /// <summary>
        /// The sample zeus logout.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult SampleZeusLogout()
        {
            var cookie = new HttpCookie("OrionUser") { Expires = DateTime.Now.AddDays(-1) };
            Response.Cookies.Add(cookie);
            return this.Redirect("http://orion.shanecraven.com/Federation/Logout?returnurl=http://zeus.shanecraven.com&appid=Zeus");
        }
    }
}