using ComandaEletronica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = ComandaEletronica.Controllers;

namespace ComandaEletronicaWeb.Controllers
{
    public class PulseiraController : Controller
    {
        // GET: Pulseira
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObterPorPalavraChave(string palavra)
        {
            var dados = new cl.PulseiraController().ObterPorPalavraChave(palavra);
            return dados == null ? Json("") : Json(dados);
        }

        [HttpPost]
        public ActionResult Gravar(FormCollection form)
        {
            //int ProdutoId = 0;
            //int.TryParse(form["ProdutoId"], out ProdutoId);
            //string Nome = form["Nome"].Trim();
            //string Descricao = form["Descricao"].Trim();
            //string Valor = form["Valor"].Trim();

            PulseiraViewModel p = new PulseiraViewModel();
            //p.ProdutoId = ProdutoId;
            //p.Nome = Nome;
            //p.Descricao = Descricao;
            //p.Valor = Valor;

            cl.PulseiraController ctlPulseira = new cl.PulseiraController();
            if (ctlPulseira.Gravar(p) > 0)
                return Json("Gravador com sucesso.");
            else
                return Json("Erro ao gravar a pulseira");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            cl.PulseiraController ctlPulseira = new cl.PulseiraController();
            if (ctlPulseira.Excluir(id) > 0)
                return Json("");
            else
                return Json("Não foi possível excluir o registro selecionado.");
        }
    }
}