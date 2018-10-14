using ComandaEletronica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.DAL
{
    internal class UserDAO : Banco
    {
        private List<User> TableToList(DataTable dt)
        {
            List<User> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = (from DataRow row in dt.Rows
                         select new User()
                         {
                             Id = Convert.ToInt32(row["userId"]),
                             Email = row["Email"].ToString(),
                             Senha = row["Senha"].ToString(),
                             Nome = row["Nome"].ToString()
                         }).ToList();
            }
            return dados;
        }

        internal User Validar(string email, string senha)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select userId, nome, email, senha from comanda.user where email = @email and senha = @senha";
            ComandoSQL.Parameters.AddWithValue("@email", email);
            ComandoSQL.Parameters.AddWithValue("@senha", senha);
            DataTable dt = ExecutaSelect();

            var dados = TableToList(dt);
            if (dados != null)
                return dados.FirstOrDefault();
            else
                return null;
        }
    }
}