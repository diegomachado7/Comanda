using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandaEletronica.Models;
using ComandaEletronica.ViewModels;

namespace ComandaEletronica.Controllers
{
    public class UserController
    {
        public UserViewModel Validar(string Email, string Senha)
        {
            //Senha = User.HashValue(Senha);
            //Senha = Senha.Substring(0, 15);

            User u = new User().Validar(Email, Senha);
            if (u != null)
            {
                return new UserViewModel()
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Cpf = u.Cpf,
                    Cartao = u.Cartao
        };
            }
            else
                return null;
        }
    }
}