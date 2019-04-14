using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Collections.Generic;

namespace SARCEM_TCC.web.Models.Domain
{
    public class UsuarioCliente:Usuario
    {
        public int? DiretoriaID { get; set; }

        public virtual Diretoria Diretorias { get; set; }



        public virtual List<Appia> Appias { get; set; }
        public virtual List<Plm> Plms { get; set; }
        
        public virtual List<HistoricoPlm> HistoricoPlms { get; set; }


    }
}