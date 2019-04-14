using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("MGCodes")]
    public class MGCode
    {
        public int MGCodeID { get; set; }
        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }
        public string MGCodeDescricao { get; set; }
       
        public virtual List<Material> Materiais { get; set; }
    }
}