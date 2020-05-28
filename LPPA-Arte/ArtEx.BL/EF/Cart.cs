using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ArtEx.EF
{
    [Table("Cart")]
    public partial class Cart: GenericId
    {
        public Cart()
        {
            items = new List<CartItem>();
        }

        [Required]
        [StringLength(40)]
        public string cookie { get; set; }

        public DateTime cartDate { get; set; }

        public int itemCount { get; set; }

        public virtual List<CartItem> items { get; set; }
    }
}
