using ArtEx.BL.Exceptions;
using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Windows.Forms;

namespace ArtEx.BL
{
    
    public partial class BusinessContext
    {
        /// <summary>
        /// Devuelve el carrito de compra de la cookie solicitada, de no existir crea uno nuevo
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public Cart GetCart(string cookie)
        {
            Cart cart = db.Carts
                          .Include(x => x.Items)
                          .Where(x=>x.cookie==cookie)
                          .FirstOrDefault();
            return cart;
        }

        /// <summary>
        /// Agrega un producto al carrito de compra de la cookie solicitada, de existir ya el producto le suma la cantidad
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public CartItem AddItemCart(string cookie, int productId, int quantity)
        {
            // busca si existe el carrito
            Cart cart = GetCart(cookie);
            if (cart == null)
            {
                // si no existe lo crea
                cart = new Cart();
                cart.cookie = cookie;
                cart.cartDate = DateTime.Now;
                db.Carts.Add(cart);
                cart.Items = new List<CartItem>();
            }

            // busca el producto en el carrito
            CartItem item = cart.Items.Find(x => x.productId == productId);
            if (item == null)
            {
                // Al no existir crea uno nuevo
                Product producto = db.Products.Where(x => x.id == productId).FirstOrDefault();
                item.productId = productId;
                item.product = producto;
                item.quantity = 0;
                item.price = producto.price;
                cart.Items.Add(item);
                cart.itemCount++;

            }
            item.quantity += quantity;
            Audit(item);
            Audit(cart);
            db.SaveChanges();
            return item;
        }

        /// <summary>
        /// Cierra el carrito de la cookie solicitada, genera la compra y borra el carrito
        /// </summary>
        /// <param name="cookie"></param>
        public void CloseCart(string cookie)
        {
            Cart cart = GetCart(cookie);
            if (cart.Items == null || cart.Items.Count == 0)
                throw new Exception("No hay items cargados");

            //TODO: Falta poner el contador de ordenes

            Order order = new Order();
            order.orderDate = DateTime.Now;
            order.orderNumber = 0;
            foreach (var cartItem in cart.Items)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.productId = cartItem.productId;
                orderDetail.quantity = cartItem.quantity;
                orderDetail.price = cartItem.price;

                order.itemCount++;
                order.totalPrice += orderDetail.total;

                Audit(orderDetail);
                order.orderDetails.Add(orderDetail);
            }
            db.Orders.Add(order);
            db.SaveChanges();

            // Borra el carrito
            db.Carts.Remove(cart);
        }

    }
}
