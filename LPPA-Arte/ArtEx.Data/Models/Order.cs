using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ArtEx.EF
{

    [Table("Order")]
    public partial class Order: GenericId
    {
        public Order()
        {
            items = new List<OrderDetail>();
        }

        public string userId { get; set; }

        public DateTime orderDate { get; set; }

        [NotMapped]
        public string period { get => orderDate.ToString("yyyy-MM"); }

        public double totalPrice { get; set; }

        public int orderNumber { get; set; }

        public int itemCount { get; set; }

        public virtual List<OrderDetail> items { get; set; }

    }

}
