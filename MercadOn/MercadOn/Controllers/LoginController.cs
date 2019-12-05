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

        public ActionResult Logout()
        {
            Session["cliente"] = null;
            Session["clienteid"] = null;
            Session["mercado"] = null;
            Session["mercadoid"] = null;

            return RedirectToAction("Login", "Login");

        }
        
        [HttpPost]
        // POST: Login
        public ActionResult Login(LoginModel model)
        {
            var context = new ContextMercadOn();
            var service = new UsuarioService(context);
            var clienteService = new ConsumidorService(context);
            var mercadoService = new MercadoService(context);
            var user = service.ConsultarPorFiltro(x => x.email == model.Email && x.senha == model.Senha).FirstOrDefault();
            
            if(user != null && user.idUsuario > 0)
            {
                ViewBag.Status = true;
                //Usuário existeste.

                var cliente = clienteService.ConsultarPorFiltro(x => x.idUsuario == user.idUsuario, x => x.UsuarioEntity).FirstOrDefault();
                if (cliente != null)
                {
                    Session["cliente"] = cliente;
                    Session["clienteid"] = cliente.idCliente;
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    var empresa = mercadoService.ConsultarPorFiltro(x => x.idUsuario == user.idUsuario, x => x.UsuarioEntity).FirstOrDefault();

                    if(empresa != null)
                    {
                        Session["mercado"] = empresa;
                        Session["mercadoid"] = empresa.idMercado;
                        return RedirectToAction("Index", "Empresa");
                    }
                }

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