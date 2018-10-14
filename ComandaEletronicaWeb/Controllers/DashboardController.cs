using ComandaEletronicaWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComandaEletronicaWeb.Controllers
{
    [ValidaAcessoFilter]
    public class DashboardController : Controller
    {
        // GET: Dashbord
        public ActionResult Index()
        {
            return View();
        }
    }
}