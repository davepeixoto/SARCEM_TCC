using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    [Table("Mb52s")]
    public class Mb52
    {
        public int Mb52ID { get; set; }
        public int? MaterialID { get; set; }
        public int CentroLogisticoID { get; set; }
        public int? Mb52Dep { get; set; }
        public string Mb52Lote { get; set; }
        public decimal? Mb52UtLivre { get; set; }
        public decimal? Mb52ValorUtLivre { get; set; }
        public decimal? Mb52EmTrans { get; set; }
        public decimal? Mb52ValorEmTrans { get; set; }
        public decimal? Mb52EmCQ { get; set; }
        public decimal? Mb52ValorEmCQ { get; set; }
        public decimal? Mb52Restrito { get; set; }
        public decimal? Mb52ValorRestrito { get; set; }
        public decimal? Mb52Bloqueados { get; set; }
        public decimal? Mb52ValorBloqueados { get; set; }
        public decimal? Mb52Devolucoes { get; set; }
        public decimal? Mb52ValorDevolucoes { get; set; }
        public DateTime Mb52DataLanc { get; set; }

        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Material Material { get; set; }
    }
}