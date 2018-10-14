using ComandaEletronica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.DAL
{
    class ProdutoDAO : Banco
    {
        private List<Produto> TableToList(DataTable dt)
        {
            List<Produto> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = (from DataRow row in dt.Rows
                         select new Produto()
                         {
                             ProdutoId = Convert.ToInt32(row["ProdutoId"]),
                             Nome = row["Nome"].ToString(),
                             Descricao = row["Descricao"].ToString(),
                             Valor = row["Valor"].ToString()

                         }).ToList();
            }
            return dados;
        }

        internal List<Produto> ObterPorPalavraChave(string palavra)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select produtoID, nome, descricao, valor
                                        from Produto 
                                        where Nome like @palavra
                                        order by Nome";
            ComandoSQL.Parameters.AddWithValue("@palavra", "%" + palavra + "%");
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }

        internal int Gravar(Produto p)
        {
            ComandoSQL.Parameters.Clear();
            if (p.ProdutoId == 0)
                ComandoSQL.CommandText = @"insert into Produto (nome, descricao, valor) 
                                            values (@nome, @descricao, @valor)";
            else
            {
                ComandoSQL.CommandText = @"update Produto set nome = @nome, descricao = @descricao, valor = @valor
                                            where produtoId = @produtoId";
                ComandoSQL.Parameters.AddWithValue("@produtoId", p.ProdutoId);
            }
            ComandoSQL.Parameters.AddWithValue("@nome", p.Nome);
            ComandoSQL.Parameters.AddWithValue("@descricao", p.Descricao);
            ComandoSQL.Parameters.AddWithValue("@valor", p.Valor);
            return ExecutaComando();
        }

        internal Produto Obter(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select produtoId, nome, descricao, valor 
                                        from Produto 
                                        where produtoId = @produtoId";
            ComandoSQL.Parameters.AddWithValue("@produtoId", id);
            DataTable dt = ExecutaSelect();
            var dados = TableToList(dt);
            return dados == null ? null : dados.FirstOrDefault();
        }

        internal int Excluir(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from Produto where produtoId = @produtoId";
            ComandoSQL.Parameters.AddWithValue("@produtoId", id);
            return ExecutaComando();
        }
    }
}