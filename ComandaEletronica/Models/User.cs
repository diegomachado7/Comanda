using ComandaEletronica.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.Models
{
    class User
    {
        private int _id;
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        private string _cartao;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Cartao { get => _cartao; set => _cartao = value; }

        public static string HashValue(string value)
        {
            System.Text.UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
                hashBytes = hash.ComputeHash(encoding.GetBytes(value));

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }

        internal User Validar(string Email, string Senha)
        {
            if (Email.Length > 0 && Senha.Length > 0)
                return new UserDAO().Validar(Email, Senha);
            else
                return null;
        }
    }
}