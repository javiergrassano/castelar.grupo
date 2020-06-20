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
        private string currentUserId;

        public BusinessContext()
        {
            db = new ArtExContext();
        }

        public BusinessContext(string userId): this()
        {
            currentUserId = userId;
        }

        private void Audit(GenericId model)
        {
            if(model.id==0)
            {
                model.createdBy = currentUserId;
                model.createdOn = DateTime.Now;
            }
            model.changedBy = currentUserId;
            model.changedOn = DateTime.Now;
        }

    }
}
