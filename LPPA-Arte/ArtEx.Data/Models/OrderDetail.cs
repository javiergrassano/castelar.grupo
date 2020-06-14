using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public double total { get => price * (double)quantity; }

        public virtual Order order { get; set; }

        public virtual Product product { get; set; }
    }
}
