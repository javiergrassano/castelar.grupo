using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ArtEx.EF
{

    [Table("Product")]
    public partial class Product: GenericId
    {
        public Product()
        {
            orderDetails = new List<OrderDetail>();
            ratings = new List<Rating>();
        }

        [Required]
        [StringLength(100)]
        public string title { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        [ForeignKey("artist")]
        public int artistId { get; set; }

        [Required]
        [StringLength(30)]
        public string image { get; set; }

        public double price { get; set; }

        public int quantitySold { get; set; }

        public double avgStars { get; set; }


        public virtual Artist artist { get; set; }

        public virtual List<OrderDetail> orderDetails { get; set; }

        public virtual List<Rating> ratings { get; set; }
    }
}
