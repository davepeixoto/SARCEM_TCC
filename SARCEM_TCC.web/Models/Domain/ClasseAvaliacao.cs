using SARCEM_TCC.web.Models.Domain.DataMass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("ClasseAvaliacoes")]
    public class ClasseAvaliacao
    {
        [Key]
        [StringLength(6)]
        public string ClasseAvaliacaoID { get; set; }
        public string ClasseAvaliacaoDescricao { get; set; }
        public string  ClasseAvaliacaoContaRazao { get; set; }
        public string ClasseAvaliacaoTipo { get; set; }


        public virtual List<Estoque> Estoques { get; set; }

    }
}