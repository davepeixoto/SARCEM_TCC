using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Estoques")]
    public class Estoque
    {
        public long EstoqueID { get; set; }
        public int CentroLogisticoID { get; set; }
        public int MaterialID { get; set; }
        public decimal EstoqueQtde { get; set; }
        public decimal? EstoqueValor { get; set; }
        [StringLength(1)]
        public string EstoqueAdmin { get; set; }
        public int? EstoquePeriodo { get; set; }
        public int? EstoqueEquivalente { get; set; }
        public int? ClassificacaoID { get; set; }
        [StringLength(1)]
        public string EstoqueExpurgado { get; set; }
        [StringLength(6)]
        public string ClasseAvaliacaoID { get; set; }

        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Classificacao Classificacao { get; set; }
        public virtual Material Material { get; set; }
        public ClasseAvaliacao ClasseAvaliacao { get; set; }
    }
}