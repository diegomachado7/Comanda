using ComandaEletronica.Models;
using ComandaEletronica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.Controllers
{
    public class ProdutoController
    {
        public List<ProdutoViewModel> ObterPorPalavraChave(string palavra)
        {
            var dados = new Produto().ObterPorPalavraChave(palavra);
            if (dados != null && dados.Count > 0)
                return (from d in dados
                        select new ProdutoViewModel()
                        {
                            ProdutoId = d.ProdutoId,
                            Nome = d.Nome,
                            Descricao = d.Descricao,
                            Valor = d.Valor
                        }).ToList();
            else
                return null;
        }

        public int Gravar(ProdutoViewModel produto)
        {
            Produto p = new Produto();
            p.ProdutoId = produto.ProdutoId;
            p.Nome = produto.Nome;
            p.Descricao = produto.Descricao;
            p.Valor = produto.Valor;
            return p.Gravar();
        }

        public ProdutoViewModel Obter(int id)
        {
            var dados = new Produto().Obter(id);
            if (dados != null)
                return new ProdutoViewModel()
                {
                    ProdutoId = dados.ProdutoId,
                    Nome = dados.Nome,
                    Descricao = dados.Descricao,
                    Valor = dados.Valor,
                };
            else
                return null;
        }

        public int Excluir(int id)
        {
            Produto p = new Produto();
            return p.Excluir(id);
        }


    }
}