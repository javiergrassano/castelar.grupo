using ArtEx.BL;
using ArtEx.BL.Models;
using ArtExWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ArtExWeb.Controllers
{
    [Authorize(Roles="Admin")]
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.products = ctx.ListProducts(orderBy: ProductOrderBy.quantitySold);

            ViewBag.sales = ctx.DashboardSales();
            ViewBag.stars = ctx.DashboardStars();

            return View();

        }

        public ActionResult Users()
        {
            var users = ApplicationDbContext.Create().Users.Select(x=>new UserModel() { id = x.Id, username=x.UserName,isAdmin=x.Roles.Count>0 }).ToList();
            return View(users);
        }

        public ActionResult ChangeRole(string id)
        {
            var db = ApplicationDbContext.Create();

            var r = db.Roles.ToList()[0];
            var u = db.Users.Find(id);

            if (u.Roles.Count > 0)
            {
                u.Roles.Clear();
            }
            else
            {
                u.Roles.Add(new IdentityUserRole() { RoleId = r.Id, UserId = u.Id });
            }
            db.SaveChanges();

            return RedirectToAction("Users", "Dashboard");
        }

        public ActionResult Logs()
        {
            var errors = ctx.ListErrors();
            return View(errors);
        }

    }
}