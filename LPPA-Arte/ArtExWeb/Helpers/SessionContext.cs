using ArtEx.BL;
using ArtEx.EF;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtExWeb.Helpers
{
    public class SessionContext: BusinessContext
    {
        public SessionContext(string userId=""): base(userId)
        {
        }




    }
}