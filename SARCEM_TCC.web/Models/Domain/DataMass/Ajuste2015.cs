using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Ajuste2015s")]
    public class Ajuste2015
    {
       [Key()]
        public int ID { get; set; }
        public int      CentroLogisticoID               { get; set; }
        public int      MaterialID                      { get; set; }
        public int      ClassificacaoID                 { get; set; }
        public decimal? Ajuste2015QuantidadeConsumida   { get; set; }
        public decimal? Ajuste2015MontanteConsumido     { get; set; }
        public decimal? Ajuste2015QuantidadeEmEstoque   { get; set; }
        public decimal? Ajuste2015MontanteEmEstoque     { get; set; }
        public int?     Ajuste2015CodigoPeriodo         { get; set; }
        public int?     Ajuste2015Periodo               { get; set; }
        public string   Ajuste2015ADM                   { get; set; }

        public virtual CentroLogistico CentroLogistico  { get; set; }
        public virtual Material Material                { get; set; }
        public virtual Classificacao Classificacao      { get; set; }
    }

}