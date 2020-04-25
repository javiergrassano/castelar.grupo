using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ArtEx.EF
{

    [Table("Order")]
    public partial class Order: GenericId
    {
        public Order()
        {
            orderDetails = new List<OrderDetail>();
        }

        [ForeignKey("user")]
        public int userId { get; set; }

        public DateTime orderDate { get; set; }

        public double totalPrice { get; set; }

        public int orderNumber { get; set; }

        public int itemCount { get; set; }

        public virtual User user { get; set; }

        public virtual List<OrderDetail> orderDetails { get; set; }
    }
}
