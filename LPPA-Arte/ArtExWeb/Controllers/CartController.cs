using ArtEx.BL;
using ArtEx.EF;
using ArtExWeb.Helpers;
using ArtExWeb.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;

namespace ArtExWeb.Controllers
{
    public class CartController : BaseController
    {
        public ActionResult Index()
        {
            Cart cart = ctx.GetCart(cookie);
            return View(cart);
        }

        public ActionResult Delete()
        {
            ctx.DeleteCart(cookie);
            Cart cart = new Cart();
            return View("Index",cart);
        }

        public ActionResult DeleteItem(int id)
        {
            ctx.DeleteItem(id);
            Cart cart = ctx.GetCart(cookie);
            return Redirect("/cart");
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Pay()
        {
            Cart cart = ctx.GetCart(cookie);
            return View(cart);
        }

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
        /// Devuelve el cantidad total del carrito
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCartTotal()
        {
            Cart cart = ctx.GetCart(cookie);
            //TODO: Crear un objeto de retorno para los JSON con status http
            return Json(cart.itemCount, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Agrega un producto al carrito de compra
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns>JSON del item recien agregado</returns>
        [HttpPost]
        public JsonResult AddProduct(int productId, int quantity)
        {
            var item = ctx.AddItemCart(cookie, productId, quantity);
            Cart cart = ctx.GetCart(cookie);

            //TODO: Crear un objeto de retorno para los JSON con status http
            CartItemResponse result = new CartItemResponse();
            result.productId = item.productId;
            result.quantity = item.quantity;
            result.total = item.total;
            result.cartItemCount = cart.itemCount;
            result.cartTotal = cart.total;
            return Json(result);
        }

        /// <summary>
        /// Cierra el carrito de compra y genera la orden
        /// </summary>
        /// <returns></returns>
        public JsonResult CloseCart()
        {
            ctx.CloseCart(cookie);
            //TODO: Crear un objeto de retorno para los JSON con status http
            return Json("ok");
        }

    }
}
