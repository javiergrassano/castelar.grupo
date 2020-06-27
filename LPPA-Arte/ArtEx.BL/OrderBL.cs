using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ArtEx.BL
{

    public partial class BusinessContext
    {
        /// <summary>
        /// Cierra el carrito de la cookie solicitada, genera la compra y borra el carrito
        /// </summary>
        /// <param name="cookie"></param>
        public Order CloseCart(string cookie)
        {
            Cart cart = GetCart(cookie);
            if (cart.items == null || cart.items.Count == 0)
                throw new Exception("No hay items cargados");

            //TODO: Falta poner el contador de ordenes

            Order order = new Order();
            order.orderDate = DateTime.Now;
            order.orderNumber = GetLastOrderNumber();
            order.userId = currentUserId;
            foreach (var cartItem in cart.items)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.product = cartItem.product;
                orderDetail.quantity = cartItem.quantity;
                orderDetail.price = cartItem.price;

                order.itemCount++;
                order.totalPrice += orderDetail.total;

                Audit(orderDetail);
                order.items.Add(orderDetail);
            }

            Audit(order);
            db.Orders.Add(order);
            db.SaveChanges();

            // Borra el carrito
            db.Carts.Remove(cart);
            db.SaveChanges();

            return order;
        }

        public Order Update(Order order)
        {
            order.orderNumber = GetLastOrderNumber();
            order.userId = currentUserId;
            foreach (var item in order.items)
            {
                Audit(item);
            }
            Audit(order);
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        /// <summary>
        /// Devuelve el proximo nuemro de orden
        /// </summary>
        /// <returns></returns>
        private int GetLastOrderNumber()
        {
            int number = 0;

            OrderNumber orderNumber = db.OrderNumbers.FirstOrDefault();
            if (orderNumber == null)
            {
                orderNumber = new OrderNumber();
                db.OrderNumbers.Add(orderNumber);
            }
            number = ++orderNumber.number;
            Audit(orderNumber);
            db.SaveChanges();
            return number;

        }

        public List<Order> GetOrders()
        {
            List<Order> orders = db.Orders
                                        .Include(x => x.items)
                                        .Where(x => x.userId == currentUserId)
                                        .ToList();
            return orders;


        }
    }
}
