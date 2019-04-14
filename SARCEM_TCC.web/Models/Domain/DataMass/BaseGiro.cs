using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("BaseGiros")]
    public partial class BaseGiro
    {
        public long ID { get; set; }
        public long? EmpresaID { get; set; }
        public int? CentroLogisticoID { get; set; }
        public string BaseGiroTipoCentro { get; set; }
        public int? MaterialID { get; set; }
        public decimal? BaseGiroConsQtde { get; set; }
        public decimal? BaseGiroConsValor { get; set; }
        public decimal? BaseGiroEstqQtde { get; set; }
        public decimal? BaseGiroEstqValor { get; set; }
        public int? BaseGiroEquivalente { get; set; }
        public int? BaseGiroPeriodo { get; set; }
        public int? BaseGiroClass { get; set; }
        public string BaseGiroAdm { get; set; }


        public Empresa Empresa { get; set; }
        public CentroLogistico CentroLogistico { get; set; }
        public Material Material { get; set; }
    }
}