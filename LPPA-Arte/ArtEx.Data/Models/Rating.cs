using System.ComponentModel.DataAnnotations.Schema;

namespace ArtEx.EF
{

    [Table("Rating")]
    public partial class Rating: GenericId
    {
        public string userId { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }

        public int stars { get; set; }


        public virtual Product product { get; set; }

    }
}
