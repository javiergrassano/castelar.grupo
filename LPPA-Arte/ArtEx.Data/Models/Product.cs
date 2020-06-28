using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtEx.EF
{

    [Table("Product")]
    public partial class Product: GenericId
    {
        public Product()
        {
            //orderDetails = new List<OrderDetail>();
            //ratings = new List<Rating>();
        }

        [Required(ErrorMessage = "El titulo es requerido")]
        [StringLength(100, ErrorMessage = "La descripcion no debe de superar los 100 caracteres")]
        public string title { get; set; }

        [StringLength(250, ErrorMessage = "La descripcion no debe de superar los 250 caracteres")]
        public string description { get; set; }

        [ForeignKey("artist")]
        public int artistId { get; set; }

        [StringLength(30)]
        public string image { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [RequiredGreaterThanZero(ErrorMessage ="El precio tiene que ser mayor que cero")]
        public double price { get; set; }

        public int quantitySold { get; set; }

        public double avgStars { get; set; }


        public virtual Artist artist { get; set; }

        //public virtual List<OrderDetail> orderDetails { get; set; }

        //public virtual List<Rating> ratings { get; set; }
    }
}
