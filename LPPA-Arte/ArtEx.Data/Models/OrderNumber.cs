using System.ComponentModel.DataAnnotations.Schema;

namespace ArtEx.EF
{
    [Table("OrderNumber")]
    public partial class OrderNumber: GenericId
    {
        public int number { get; set; }
    }
}
