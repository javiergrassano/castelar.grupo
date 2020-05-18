﻿using ArtEx.BL;
using ArtEx.EF;
using ArtExWeb.Helpers;
using Microsoft.Ajax.Utilities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ArtExWeb.Controllers
{
    public class CartController : Controller
    {
        private SessionContext ctx = new SessionContext();

        /// <summary>
        /// Devuelve el carrido de compra actual, de no existir crea uno nuevo
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCart()
        {
            string cookie = "demo"; //TODO: ver la llamada de cookie segun defina e profesor

            Cart cart = ctx.GetCart(cookie);

            //TODO: Crear un objeto de retorno para los JSON con status http
            return Json(cart, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Agrega un producto al carrito de compra
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns>JSON del item recien agregado</returns>
        public JsonResult AddProduct(int productId, int quantity)
        {
            string cookie = "demo"; //TODO: ver la llamada de cookie segun defina e profesor
            var item = ctx.AddItemCart(cookie, productId, quantity);
            //TODO: Crear un objeto de retorno para los JSON con status http
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cierra el carrito de compra y genera la orden
        /// </summary>
        /// <returns></returns>
        public JsonResult CloseCart()
        {
            string cookie = "demo"; //TODO: ver la llamada de cookie segun defina e profesor
            ctx.CloseCart(cookie);
            //TODO: Crear un objeto de retorno para los JSON con status http
            return Json("ok");
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