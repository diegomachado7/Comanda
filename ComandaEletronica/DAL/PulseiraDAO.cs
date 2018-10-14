using ComandaEletronica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandaEletronica.DAL
{
    class PulseiraDAO : Banco
    {
        private List<Pulseira> TableToList(DataTable dt)
        {
            List<Pulseira> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = (from DataRow row in dt.Rows
                         select new Pulseira()
                         {
                             PulseiraId = Convert.ToInt32(row["PulseiraId"]),
                         }).ToList();
            }
            return dados;
        }

        internal List<Pulseira> ObterPorPalavraChave(string palavra)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select pulseiraId
                                        from Pulseira 
                                        where pulseiraId like @palavra";
            ComandoSQL.Parameters.AddWithValue("@palavra", "%" + palavra + "%");
            DataTable dt = ExecutaSelect();
            return TableToList(dt);
        }

        internal int Gravar(Pulseira p)
        {
            ComandoSQL.Parameters.Clear();
            if (p.PulseiraId == 0)
                ComandoSQL.CommandText = @"insert into pulseira (pulseiraId) 
                                            values (null)";
            //INSERT INTO `comanda`.`pulseira` (`pulseiraId`) VALUES('null');
            return ExecutaComando();
        }

        internal int Excluir(int id)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from pulseira where pulseiraId = @pulseiraId";
            ComandoSQL.Parameters.AddWithValue("@pulseiraId", id);
            return ExecutaComando();
        }
    }
}