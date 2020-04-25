using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ArtEx.EF
{
    [Table("OrderNumber")]
    public partial class OrderNumber: GenericId
    {
        public int number { get; set; }
    }
}
