using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtEx.BL.Models
{
    public class SalesMonthModel
    {
        public string period { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }
    }

    public class StarCountModel
    {
        public int star { get; set; }
        public int quantity { get; set; }
    }

}
