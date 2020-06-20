using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtEx.EF
{

    [Table("User")]
    public partial class User: GenericId
    {
        public User()
        {
            //orders = new List<Order>();
            ratings = new List<Rating>();
        }

        [Required]
        [StringLength(30)]
        public string firstName { get; set; }

        [Required]
        [StringLength(30)]
        public string lastName { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(30)]
        public string city { get; set; }

        [StringLength(30)]
        public string country { get; set; }

        public DateTime signupDate { get; set; }

        public int orderCount { get; set; }

        //public virtual List<Order> orders { get; set; }

        public virtual List<Rating> ratings { get; set; }
    }
}
