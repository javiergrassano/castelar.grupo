using ArtEx.BL;
using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtExWeb.Helpers
{
    public static class LogHelper
    {
        public  static void Logs(Exception exception)
        {

                string userId = null;
                try
                {
                    userId = HttpContext.Current.User.Identity.Name;
                }
                catch
                {
                }
                BusinessContext businessContext = new BusinessContext();
                var error = new Error()
                {
                    //UserId = userId,
                    exception = exception.GetType().FullName,
                    message = exception.Message,
                    everything = exception.ToString(),
                    ipAddress = HttpContext.Current.Request.UserHostAddress,
                    userAgent = HttpContext.Current.Request.UserAgent,
                    pathAndQuery = HttpContext.Current.Request.Url == null ? "" : HttpContext.Current.Request.Url.PathAndQuery,
                    httpReferer = HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.PathAndQuery,

                };
                businessContext.CreateError(error);
                throw exception; 
        }
        
    }
}