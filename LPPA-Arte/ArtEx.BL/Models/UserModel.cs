using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtEx.BL.Models
{
    public class UserModel
    {
        public string id { get; set; }
        public string username { get; set; }
        public bool isAdmin { get; set; }
    }
}
