using ComandaEletronica.DAL;
using ComandaEletronica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.Models
{
    internal class Pulseira
    {
        private int _pulseiraId;

        internal int PulseiraId { get => _pulseiraId; set => _pulseiraId = value; }


        internal List<Pulseira> ObterPorPalavraChave(string palavra)
        {
            if (palavra.Length > 0)
                return new PulseiraDAO().ObterPorPalavraChave(palavra);
            else
                return null;
        }

        internal int Gravar()
        {
            if (_pulseiraId >= 0)
                return new PulseiraDAO().Gravar(this);
            else
                return -10;
        }

        internal int Excluir(int id)
        {
            if (id > 0)
                return new PulseiraDAO().Excluir(id);
            else
                return -10;
        }
    }
}