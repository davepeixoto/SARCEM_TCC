using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Mm60s")]
    public class Mm60
    {
        public long Mm60ID { get; set; }
        public int MaterialID { get; set; }
        public decimal? Mm60Valor { get; set; }
        public int? CentroLogisticoID { get; set; }
        public System.DateTime? Mm60DataUltModif { get; set; }
        public int Mm60Periodo { get; set; }
        public int Mm60Equivalente { get; set; }

        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Material Material { get; set; }
    }
}