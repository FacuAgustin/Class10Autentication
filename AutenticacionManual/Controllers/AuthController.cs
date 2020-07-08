using AutenticacionManual.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AutenticacionManual.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [Authorize]
        public ActionResult Secreto()
        {
            return Content($"El Codigo de lanzamiento es  {Guid.NewGuid().ToString()}");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string pass,string returnUrl)
        {
            ContextSeguridad ctxt = new ContextSeguridad();

            UserStore<IdentityUser> user = new UserStore<IdentityUser>(ctxt);

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(user);

            IdentityUser identityUser = userManager.Find(username, pass);
            if (identityUser != null)
            {

            IAuthenticationManager authenticationManager=this.HttpContext.GetOwinContext().Authentication;
            ClaimsIdentity claimsIdentity = new ClaimsIdentity("CookieAuthentication");
            authenticationManager.SignIn(claimsIdentity);
                return Redirect(returnUrl);
            }
            
            ViewBag.Mensaje = "Credenciales Incorrectas";
            return View();
        }
        public ActionResult CrearUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearUsuario(string username,string pass)
        {
            ContextSeguridad ctxt = new ContextSeguridad();
            UserStore<IdentityUser> user = new UserStore<IdentityUser>(ctxt);
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(user);
            IdentityResult result = userManager.Create(new IdentityUser()
            {
                UserName = username
            },pass) ;
            if (result.Succeeded)
            {
                return Content("Usuario Creado");
            }
            return Content("Error al Crear el usuario");
        }

    }
}