using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComandaEletronicaWeb.Filters
{
    public class ValidaAcessoFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie ck = filterContext.HttpContext.Request.Cookies["token"];
            if (ck == null || ck.Values["email"] == "" || ck.Values["senha"] == "")
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}