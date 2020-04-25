using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ArtEx.EF
{
    

    [Table("Artist")]
    public partial class Artist: GenericId
    {
        public Artist()
        {
            products = new List<Product>();
        }

        [Required]
        [StringLength(30)]
        public string firstName { get; set; }

        [Required]
        [StringLength(30)]
        public string lastName { get; set; }

        [StringLength(30)]
        public string lifeSpan { get; set; }

        [StringLength(30)]
        public string country { get; set; }

        [StringLength(2000)]
        public string description { get; set; }

        public int totalProducts { get; set; }

        public virtual List<Product> products { get; set; }
    }
}
