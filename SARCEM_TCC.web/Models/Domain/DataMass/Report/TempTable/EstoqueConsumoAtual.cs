using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable
{
    [Table("EstoqueConsumoAtuais")]
    public class EstoqueConsumoAtual
    {
        [Key]
        public Guid Id { get; set; }
        public long EmpresaID { get; set; }
        public int CentroLogisticoID { get; set; }       
        public int? MaterialID { get; set; }
        public string EmpresaNome { get; set; }
        [StringLength(4)]
        public string CentroLogisticoCodSap { get; set; }
        public string Lote { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        public string MaterialDescricao { get; set; }
        [StringLength(2)]
        public string MaterialClasse { get; set; }
        [StringLength(5)]
        public string MaterialUM { get; set; }
        public string ClassificacaoNome { get; set; }
        public string UserName { get; set; }
        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }
        public string MGCodeDescricao { get; set; }
        public string FamiliaNome { get; set; }
        public decimal SapQtde  { get; set; }
        public decimal SapValor  { get; set; }
        public decimal FisicoQtde  { get; set; }
        public decimal FisicoValor  { get; set; }
        public decimal AdmQtde  { get; set; }
        public decimal AdmValor { get; set; }
        public decimal ConsumoQtde{ get; set; }
        public decimal ConsumoValor { get; set; }
        public decimal EntradaQtde { get; set; }
        public decimal EntradaValor { get; set; }
        public string TipoDoCentro { get; set; }
        public DateTime? DataLanc { get; set; }













        //public long ID { get; set; }
        //public int? CentroLogisticoID { get; set; }
        //public int? MaterialID { get; set; }
        //public int? EmpresaID { get; set; }
        //public int? Lote { get; set; }
        //public decimal? EstqSapQtde { get; set; }
        //public decimal? EstqSapValor { get; set; }
        //public decimal? EstqFisicoQtde { get; set; }
        //public decimal? EstqFisicoValor { get; set; }
        //public decimal? EstqAdministrativoQtde { get; set; }
        //public decimal? EstqAdministrativoValor { get; set; }
        //public decimal? ConsumoQtde { get; set; }
        //public decimal? ConsumoValor { get; set; }
        //public int Tipo_do_Centro { get; set; }
        //public int DataLanc { get; set; }




        //public virtual CentroLogistico CentroLogistico { get; set; }
        //public virtual Material Material { get; set; }
        //public virtual Empresa Empresa { get; set; }



    }
}