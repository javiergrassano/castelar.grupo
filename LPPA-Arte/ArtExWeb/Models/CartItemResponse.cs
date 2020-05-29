using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtExWeb.Models
{
    public class CartItemResponse
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }
        public int cartItemCount { get; set; }
        public double cartTotal { get; set; }
    }
}