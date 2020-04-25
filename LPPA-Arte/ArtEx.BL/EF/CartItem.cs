using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtEx.EF
{

    [Table("CartItem")]
    public partial class CartItem: GenericId
    {

        [ForeignKey("cart")]
        public int cartId { get; set; }

        public int productId { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public virtual Cart cart { get; set; }
    }
}
