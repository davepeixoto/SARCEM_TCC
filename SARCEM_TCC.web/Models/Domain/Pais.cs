using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Paises")]
    public class Pais
    {
        public int PaisID{ get; set; }
        public string PaisNome { get; set; }
        [StringLength(3)]
        public string PaisSigla{ get; set; }

        public virtual List<Estado> Estados { get; set; }

    }
}