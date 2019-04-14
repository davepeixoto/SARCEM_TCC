using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Collections.Generic;

namespace SARCEM_TCC.web.Models.Domain
{
    public class UsuarioLogistica: Usuario


    {
        public int UsuarioLogisticaAtividadeID { get; set; }
        public virtual UsuarioLogisticaAtividade UsuarioLogisticaAtividades { get; set; }
        
        public virtual List<Familia> Familias { get; set; }
        public virtual List<HistoricoMaterial> HistoricoMateriais { get; set; }
        public virtual List<ReferenciaDePreco> ReferenciaDePrecos { get; set; }
    }


}