using ComandaEletronica.DAL;
using ComandaEletronica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.Models
{
    internal class Produto
    {
        private int _produtoId;
        private string _nome;
        private string _descricao;
        private string _valor;

        internal int ProdutoId { get => _produtoId; set => _produtoId = value; }
        internal string Nome { get => _nome; set => _nome = value; }
        internal string Descricao { get => _descricao; set => _descricao = value; }
        internal string Valor { get => _valor; set => _valor = value; }

        internal List<Produto> ObterPorPalavraChave(string palavra)
        {
            if (palavra.Length > 0)
                return new ProdutoDAO().ObterPorPalavraChave(palavra);
            else
                return null;
        }

        internal int Gravar()
        {
            if (_produtoId >= 0 && _nome.Length > 0)
                return new ProdutoDAO().Gravar(this);
            else
                return -10;
        }

        internal Produto Obter(int id)
        {
            if (id > 0)
                return new ProdutoDAO().Obter(id);
            else
                return null;
        }

        internal int Excluir(int id)
        {
            if (id > 0)
                return new ProdutoDAO().Excluir(id);
            else
                return -10;
        }
    }
}