using ArtEx.BL;
using ArtEx.EF;
using ArtExWeb.Helpers;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ArtExWeb.Controllers
{
    public class ArtistsController : Controller
    {
        private SessionContext ctx = new SessionContext();

        public ActionResult Index(string search, int page = 0, int orderBy = 0)
        {
            return View(ctx.listArtits(search, page, 15, (ArtitsOrderBy)orderBy));
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = ctx.findArtit(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        public ActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist)
        {
            if (ctx.IsValid(artist))
            {
                ctx.Update(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = ctx.findArtit(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View("Edit",artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artist artist)
        {
            if (ctx.IsValid(artist))
            {
                ctx.Update(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
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
