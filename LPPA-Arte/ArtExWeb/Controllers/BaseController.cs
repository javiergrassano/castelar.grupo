using ArtEx.EF;
using ArtExWeb.Helpers;
using System;
using System.Web;
using System.Web.Mvc;

namespace ArtExWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        internal SessionContext ctx = new SessionContext();
        internal ArtExContext db = new ArtExContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx = null;
            }
            base.Dispose(disposing);
        }


        #region Manejo de cookies

        protected string cookie { get => getCookie(); }

        private string getCookie()
        {
            string cookieId = "";
            var cookie = ControllerContext.HttpContext.Request.Cookies["LPPA-Arte"];
            if (cookie == null)
            {
                cookieId = Guid.NewGuid().ToString();
                cookieId = "Demo";
                HttpCookie cookie1 = new HttpCookie("LPPA-Arte", cookieId);
                ControllerContext.HttpContext.Response.SetCookie(cookie1);
            }
            else
            {
                cookieId = cookie.Value;
            }
            return cookieId;
        }

        #endregion Manejo de cookies

    }
}
