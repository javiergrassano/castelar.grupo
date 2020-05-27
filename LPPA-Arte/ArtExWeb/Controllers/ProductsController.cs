using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtEx.BL;
using ArtEx.EF;
using ArtExWeb.Helpers;

namespace ArtExWeb.Controllers
{
    public class ProductsController : Controller
    {
        private SessionContext ctx = new SessionContext();

        public ActionResult Index(string search, int page = 0, int orderBy = 0)
        {
            return View(ctx.ListProducts(search, page, 15, (ProductOrderBy)orderBy));
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ctx.findProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ctx.IsValid(product))
            {
                ctx.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            return View("Edit", product);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = ctx.findProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            return View("Edit", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ctx.IsValid(product))
            {
                ctx.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx = null;
            }
            base.Dispose(disposing);
        }

    }
}
