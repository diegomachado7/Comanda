using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = ComandaEletronica.Controllers;

namespace ComandaEletronicaWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            HttpCookie ck = Request.Cookies["token"];
            if (ck != null && int.Parse(ck.Values["userId"]) > 0)
                return RedirectToAction("Index", "Dashboard");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Validar(string Email, string Senha)
        {
            if (Email != "" && Senha != "")
            {
                cl.UserController ctlUser = new cl.UserController();
                var usuario = ctlUser.Validar(Email, Senha);
                if (usuario != null)
                {
                    HttpCookie ck = new HttpCookie("token");
                    ck.Values.Add("userId", usuario.Id.ToString());
                    var nomes = usuario.Nome.Split(' ');
                    ck.Values.Add("Nome", "Oi, " + nomes[0]);
                    ck.Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(ck);

                    return Json("");
                }
                else
                    return Json("O usuário e/ou a senha informados não conferem.");
            }
            else
                return Json("Por favor, informe um usuário e uma senha para acesso.");
        }

        public ActionResult Sair()
        {
            HttpCookie cookie = Request.Cookies["token"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}