using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("SubDiretorias")]
    public class SubDiretoria
    {
        public int SubDiretoriaID { get; set; }
        public string SubDiretoriaNome { get; set; }
        
        [StringLength(4)]
        public string SubDiretoriaSigla { get; set; }
        public int DiretoriaID { get; set; }
        public virtual Diretoria Diretoria { get; set; }
        public virtual List<Ordem> Ordens { get; set; }
        public virtual List<Appia> Appias { get; set; }
        public virtual List<Plm>Plms { get; set; }
        public virtual List<HistoricoPlm> HistoricoPlms { get; set; }
    }
}