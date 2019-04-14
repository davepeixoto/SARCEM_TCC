using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable
{
    [Table("GiroFechamentosMensais")]
    public class GiroFechamentoMensal
    {   [Key]
        public Guid GiroID { get; set; }
        public long EmpresaID { get; set; }
        public int CentroLogisticoID { get; set; }
        public int MaterialID { get; set; }
        public int ClassificacaoID { get; set; }
        public int FamiliaID { get; set; }
        public int MGCodeID { get; set; }
        public string UserId { get; set; }
        public int GiroEquivalente { get; set; }
        public string EmpresaNome { get; set; }
        [StringLength(4)]
        public string CentroLogisticoCodSap { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        public string MaterialDescricao { get; set; }
        [StringLength(5)]
        public string MaterialUM { get; set; }
        [StringLength(2)]
        public string MaterialClasse { get; set; }
        [StringLength(30)]
        public string ClassificacaoNome { get; set; }
        public string FamiliaNome { get; set; }
        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }
        public string MGCodeDescricao { get; set; }
        public string UserName { get; set; }
        public decimal GiroConsQtde { get; set; }
        public decimal GiroConsValor { get; set; }
        public decimal GiroEstqQtde { get; set; }
        public decimal GiroEstqValor { get; set; }
        public long GiroPeriodo { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        [StringLength(20)]
        public string TipoDoCentro { get; set; }
        [StringLength(1)]
        public string Adm { get; set; }
        
    }
}