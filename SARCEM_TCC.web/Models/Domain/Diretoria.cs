using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Diretorias")]
    public class Diretoria
    {
        public int DiretoriaID { get; set; }
        public string DiretoriaNome { get; set; }
        public long EmpresaID { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual List<SubDiretoria> SubDiretorias { get; set; }
        public virtual List<UsuarioCliente> UsuarioClientes { get; set; }
        public virtual List<Appia> Appias { get; set; }
        public virtual List<Plm> Plms { get; set; }
        public virtual List<HistoricoPlm> HistoricoPlms { get; set; }
    }
}