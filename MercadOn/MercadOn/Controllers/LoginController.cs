using MercadOn.Models.Login;
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
            model.Email = "Email";
            model.Senha = "Senha";
            return View(model);
        }
        
        [HttpPost]
        // POST: Login
        public ActionResult Login(LoginModel model)
        {
            return View();
        }
    }
}