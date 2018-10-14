using ComandaEletronica.Models;
using ComandaEletronica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.Controllers
{
    public class PulseiraController
    {
        public List<PulseiraViewModel> ObterPorPalavraChave(string palavra)
        {
            var dados = new Pulseira().ObterPorPalavraChave(palavra);
            if (dados != null && dados.Count > 0)
                return (from d in dados
                        select new PulseiraViewModel()
                        {
                            PulseiraId = d.PulseiraId,
                        }).ToList();
            else
                return null;
        }

        public int Gravar(PulseiraViewModel pulseira)
        {
            Pulseira p = new Pulseira();
            p.PulseiraId = pulseira.PulseiraId;
            return p.Gravar();
        }

        public int Excluir(int id)
        {
            Pulseira p = new Pulseira();
            return p.Excluir(id);
        }
    }
}