using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using OrionWindows.Entities.Authentication;
using OrionWindowsDesktop;
using OrionWindowsDesktop.Authenticator;
using OrionWindowsDesktop.Logging;

namespace ZeusWeb.Attributes
{
    /// <summary>
    /// The authenticated.
    /// </summary>
    public class Authenticated : ActionFilterAttribute
    {
        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.RequestContext.HttpContext.Request.Cookies["OrionUser"] == null)
            {
                filterContext.Result = new RedirectResult("http://orion.shanecraven.com/Federation/Login?returnurl=http://zeus.shanecraven.com/Auth/Orion&appid=Zeus");
                return;
            }

            var userKey = filterContext.RequestContext.HttpContext.Request.Cookies["OrionUser"].Value;
            var orion = new Orion(new DeleteMeLogger());
            orion.Communicator.ApiAuthenticator = GetAuthenticatior();
            var userProfile = Task.Run(() => orion.CreateUserController()
                .GetUserProfile(new Key() {ApiKey = userKey, Type = KeyType.UserTempKey}, "Zeus"));
            userProfile.Wait();
            var userProfileWaited = userProfile.Result;
            if (userProfileWaited.Result?.Email == null || userProfileWaited.Result.Email.Equals(string.Empty))
            {
                // filterContext.RequestContext.HttpContext.Request.Cookies["OrionUser"].Expires = DateTime.Now.AddDays(-1);
                var cookie = new HttpCookie("OrionUser") {Expires = DateTime.Now.AddDays(-1)};
                filterContext.HttpContext.Response.Cookies.Add(cookie);
                filterContext.Result = new RedirectResult("http://orion.shanecraven.com/Federation/Login?returnurl=http://zeus.shanecraven.com/Auth/Orion&appid=Zeus");
                return;
            }

            filterContext.HttpContext.Items["OrionUser"] = userProfileWaited.Result;
            filterContext.HttpContext.Items["OrionUserKey"] = userKey;

        }

        private OrgStandardAuthenticator GetAuthenticatior()
        {
            var authMech = new OrgStandardAuthenticator
            {
                SecertKey =
                           new Key()
                           {
                               ApiKey =
                                       "4ISJqHMO0XpLpMHXj77tjv1R7QKNYTptkGFKgrJdyX4=",
                               ExpiryDate = DateTime.Now,
                               Type = KeyType.ApplicationSecretKey
                           },
                PublicKey =
                           new Key()
                           {
                               ApiKey = "abc123",
                               Type = KeyType.ApplicationPublicKey,
                               ExpiryDate = DateTime.Now
                           }
            };
            return authMech;
        }
    }
}
