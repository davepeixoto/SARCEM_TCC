using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("MovimentoEstoques")]
    public class MovimentoEstoque
    {
        [Key]
        public int MovEstqID { get; set; }
        public string MovEstqChave { get; set; }
        [StringLength(5)]
        public string MovEstqSigla { get; set; }
    }
}