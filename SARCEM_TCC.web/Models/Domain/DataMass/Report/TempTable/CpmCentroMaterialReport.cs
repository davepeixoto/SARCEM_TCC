using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable
{
    [Table("CpmCentroMaterialReports")]
    public class CpmCentroMaterialReport
    {
        [Key]
        public Guid CpmId { get; set; }
        public long     EmpresaID   { get; set; }
        public int      MaterialID { get; set; }
        public string   EmpresaNome         { get; set; }
        [StringLength(5)]
        public string CentroLogisticoCodSap { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        public string MaterialDescricao     { get; set; }
        [StringLength(5)]
        public string MaterialUM { get; set; }
        [StringLength(2)]
        public string MaterialClasse { get; set; }
        [StringLength(30)]
        public string ClassificacaoNome { get; set; }
        public string FamiliaNome       { get; set; }
        [StringLength(10)]
        public string   MGCodeCodigoSap { get; set; }
        public string   MGCodeDescricao { get; set; }
        public string   UserName          { get; set; }
        public decimal  Cpm3             { get; set; }
        public decimal  Cpm6             { get; set; }
        public decimal  Cpm9             { get; set; }
        public decimal  Cpm12            { get; set; }
        public decimal  Cpm15            { get; set; }
        public decimal  Cpm18            { get; set; }
        public decimal  Cpm21            { get; set; }
        public decimal  Cpm24            { get; set; }
        public DateTime DataLanc { get; set; }


    }
}