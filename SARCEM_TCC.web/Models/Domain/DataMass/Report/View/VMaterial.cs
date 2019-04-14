using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VMaterial")]
    public class VMaterial
    {
        [Key]
        public int MaterialID  { get; set; }
        public long   EmpresaID     { get; set; }
        public string EmpresaNome   { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        public string MaterialDescricao  { get; set; }
        [StringLength(5)]
        public string MaterialClasse  { get; set; }
        [StringLength(5)]
        public string MaterialUM  { get; set; }
        public int ClassificacaoID { get; set; }
        public string ClassificacaoNome  { get; set; }
        public int FamiliaID { get; set; }
        public string FamiliaNome  { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int MGCodeID { get; set; }
        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }
        
        public string MGCodeDescricao  { get; set; }
       
        public DateTime? MaterialDataInclusao  { get; set; }

        public int? MaterialSubId { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }


    }
}