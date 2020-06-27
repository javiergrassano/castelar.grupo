using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtEx.EF;
using ArtExWeb.Helpers;
using Microsoft.AspNet.Identity;

namespace ArtExWeb.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        // GET: Orders/Create
        public ActionResult Create()
        {
            string id = User?.Identity?.GetUserId() ?? "";
            ctx = new SessionContext(id);

            Order order = ctx.CloseCart(cookie);
            return View(order);
        }

        public ActionResult List()
        {
            string id = User?.Identity?.GetUserId() ?? "";
            ctx = new SessionContext(id);
            var orders = ctx.GetOrders();
            return View(orders.ToList());
        }

    }
}
