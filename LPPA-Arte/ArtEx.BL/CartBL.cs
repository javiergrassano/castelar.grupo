using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                          .Include(x => x.items)
                          .Where(x=>x.cookie==cookie)
                          .FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart();
                cart.cookie = cookie;
                cart.cartDate = DateTime.Now; 
                Audit(cart);
                db.Carts.Add(cart);
                db.SaveChanges();
            }
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
                cart.items = new List<CartItem>();
            }

            // busca el producto en el carrito
            CartItem item = cart.items.Find(x => x.productId == productId);
            if (item == null)
            {
                // Al no existir crea uno nuevo
                item = new CartItem();
                Product producto = db.Products.Where(x => x.id == productId).FirstOrDefault();
                item.productId = productId;
                item.product = producto;
                item.quantity = 0;
                item.price = producto.price;
                cart.items.Add(item);
            }
            if (item.quantity + quantity > 0)
            {
                cart.itemCount += quantity;
                item.quantity += quantity;
                Audit(item);
                Audit(cart);
                db.SaveChanges();
            }
            return item;
        }

        
        public void DeleteCart(string cookie)
        {
            Cart cart = GetCart(cookie);
            if (cart != null && cart.itemCount > 0)
            {
                // Borra el carrito
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                CartItem cartItem = db.CartItems.Find(id);
                db.CartItems.Remove(cartItem);
                db.SaveChanges();
            }
            catch { }
        }

    }
}
