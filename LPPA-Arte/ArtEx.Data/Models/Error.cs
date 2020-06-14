using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtEx.EF
{

    [Table("Error")]
    public partial class Error: GenericId
    {
        public int? userId { get; set; }

        public DateTime? errorDate { get; set; }

        [StringLength(40)]
        public string ipAddress { get; set; }

        public string userAgent { get; set; }

        public string exception { get; set; }

        public string message { get; set; }

        public string everything { get; set; }

        [StringLength(500)]
        public string httpReferer { get; set; }

        [StringLength(500)]
        public string pathAndQuery { get; set; }
    }
}
