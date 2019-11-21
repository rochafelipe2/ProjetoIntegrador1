using MercadOn.Models.Login;
using MercadOn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MercadOn.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            model.Email = "";
            model.Senha = "";
            return View(model);
        }
        
        [HttpPost]
        // POST: Login
        public ActionResult Login(LoginModel model)
        {

            var service = new UsuarioService(new ContextMercadOn());

            var user = service.ConsultarPorFiltro(x => x.email == model.Email && x.senha == model.Senha).FirstOrDefault();

            if(user != null && user.idUsuario > 0)
            {
                ViewBag.Status = true;
                //Usuário existeste.
            }
            else
            {
                ViewBag.Status = false;
                //Usuário não existente.
            }

            return View();
        }
    }
}