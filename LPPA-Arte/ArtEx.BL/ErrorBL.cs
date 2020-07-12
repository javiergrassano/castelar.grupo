using ArtEx.BL.Exceptions;
using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace ArtEx.BL
{

    public partial class BusinessContext
    {

        public void CreateError(Error model)
        {
            try
            {
                Audit(model);
                db.Errors.Add(model);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }


    }

}
