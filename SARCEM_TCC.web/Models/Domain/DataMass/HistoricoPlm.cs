using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("HistoricoPlms")]
    public class HistoricoPlm
    {


        [Key]
        public long PlmID { get; set; }
        public int? MaterialID { get; set; }
        public int? CentroLogisticoID { get; set; }
        public int? DiretoriaID { get; set; }
        public int? SUbDiretoriaID { get; set; }
        public string PlmProjeto { get; set; }
        public string PlmInfoAdicional { get; set; }
        public string PlmResponsavel { get; set; }

        public string UsuarioClienteId { get; set; }
        public decimal? PlmQuantidade { get; set; }
        public int? PlmPeriodo { get; set; }
        public int? PlmEquivalente { get; set; }
        public System.DateTime? PlmDataLanc { get; set; }

        public virtual SubDiretoria SubDiretoria { get; set; }
        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Diretoria Diretoria { get; set; }
        public virtual Material Material { get; set; }
        public virtual UsuarioCliente UsuarioClientes { get; set; }

    }
}