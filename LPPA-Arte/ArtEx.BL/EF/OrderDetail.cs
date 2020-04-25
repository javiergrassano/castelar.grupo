using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ArtEx.EF
{

    [Table("OrderDetail")]
    public partial class OrderDetail: GenericId
    {
        [ForeignKey("order")]
        public int orderId { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public virtual Order order { get; set; }

        public virtual Product product { get; set; }
    }
}
