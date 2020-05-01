using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArtEx.BL
{
    public partial class BusinessContext
    {
        private ArtExContext db;

        public BusinessContext()
        {
            db = new ArtExContext();
        }

        private void Audit(GenericId model)
        {
            if(model.id==0)
            {
                model.createdBy = "usuario";
                model.createdOn = DateTime.Now;
            }
            model.changedBy = "usuario";
            model.changedOn = DateTime.Now;
        }

    }
}
