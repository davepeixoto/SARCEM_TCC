using SARCEM_TCC.web.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VEstoqueHistoricos")]
    public class VEstoqueHistorico
    {
        [Key]
        public Guid         Id                      { get; set; }
        public long         EmpresaID               { get; set; }
        public int          MaterialID              { get; set; }
        public string       EmpresaNome             { get; set; }
        [StringLength(5)]
        public string       CentroLogisticoCodSap   { get; set; }
        [StringLength(10)]
        public string       MaterialCodSap          { get; set; }
        public string       MaterialDescricao       { get; set; }
        [StringLength(5)]
        public string       MaterialUM              { get; set; }
        [StringLength(2)]
        public string       MaterialClasse          { get; set; }
        [StringLength(30)]
        public string       ClassificacaoNome       { get; set; }
        public string       FamiliaNome             { get; set; }
        [StringLength(10)]
        public string       MGCodeCodigoSap         { get; set; }
        public string       MGCodeDescricao         { get; set; }
        public string       UserName                { get; set; }
        public TipoDaInfo   TipoDaInfo              { get; set; }
        public decimal      M1                      { get; set; }
        public decimal      M2                      { get; set; }
        public decimal      M3                      { get; set; }
        public decimal      M4                      { get; set; }
        public decimal      M5                      { get; set; }
        public decimal      M6                      { get; set; }
        public decimal      M7                      { get; set; }
        public decimal      M8                      { get; set; }
        public decimal      M9                      { get; set; }
        public decimal      M10                     { get; set; }
        public decimal      M11                     { get; set; }
        public decimal      M12                     { get; set; }
        public DateTime     DataLanc                { get; set; }
        public bool         AdmVersion              { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }

    }
}