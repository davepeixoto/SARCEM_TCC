using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VF0b1")]
    public class VF0b1
    {
        [Key]
        public int MaterialID { get; set; }

        [StringLength(50)]
        public string Lote { get; set; }

        [StringLength(10)]
        public string MaterialCodSap { get; set; }

        [StringLength(150)]
        public string MaterialDescricao { get; set; }

        [StringLength(5)]
        public string MaterialClasse { get; set; }

        [StringLength(5)]
        public string MaterialUM { get; set; }

        [StringLength(30)]
        public string ClassificacaoNome { get; set; }

        [StringLength(80)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }


        [StringLength(150)]
        public string MGCodeDescricao { get; set; }

        [StringLength(150)]
        public string FamiliaNome { get; set; }

        public decimal EstqQtde { get; set; }
        public decimal EstqValor { get; set; }
        public decimal ConsumoQtde { get; set; }
        public decimal ConsumoValor { get; set; }
        public decimal ValorDeReferencia { get; set; }
        public DateTime DataLanc { get; set; }
        
    }
}

