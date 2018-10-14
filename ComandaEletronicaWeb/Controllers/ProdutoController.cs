using ComandaEletronica.ViewModels;
using ComandaEletronicaWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cl = ComandaEletronica.Controllers;

namespace ComandaEletronicaWeb.Controllers
{
    [ValidaAcessoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObterPorPalavraChave(string palavra)
        {
            var dados = new cl.ProdutoController().ObterPorPalavraChave(palavra);
            return dados == null ? Json("") : Json(dados);
        }

        [HttpPost]
        public ActionResult Gravar(FormCollection form)
        {
            if (form.Keys.Count > 0)
            {
                int ProdutoId = 0;
                int.TryParse(form["ProdutoId"], out ProdutoId);
                string Nome = form["Nome"].Trim();
                string Descricao = form["Descricao"].Trim();
                string Valor = form["Valor"].Trim();

                ProdutoViewModel p = new ProdutoViewModel();
                p.ProdutoId = ProdutoId;
                p.Nome = Nome;
                p.Descricao = Descricao;
                p.Valor = Valor;

                cl.ProdutoController ctlProduto = new cl.ProdutoController();
                if (ctlProduto.Gravar(p) > 0)
                    return Json("Gravador com sucesso.");
                else
                    return Json("Erro ao gravar o questionário: " + p.Nome.ToUpper());
            }
            else
            {
                return Json("O formulário submetido não contem valores válidos.");
            }
        }

        [HttpPost]
        public ActionResult Obter(int id)
        {
            var dados = new cl.ProdutoController().Obter(id);
            return Json(dados);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            cl.ProdutoController ctlProduto = new cl.ProdutoController();
            if (ctlProduto.Excluir(id) > 0)
                return Json("");
            else
                return Json("Não foi possível excluir o registro selecionado.");
        }
    }
}