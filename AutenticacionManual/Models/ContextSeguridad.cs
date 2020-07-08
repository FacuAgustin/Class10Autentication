using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionManual.Models
{
    public class ContextSeguridad:IdentityDbContext<IdentityUser>
    {
        public ContextSeguridad():base(@"Data Source=DESKTOP-FMD0NPE\SQLEXPRESS;Initial Catalog=SeguridadMvcClas10;Integrated Security=true")
        {

        }
    }
}