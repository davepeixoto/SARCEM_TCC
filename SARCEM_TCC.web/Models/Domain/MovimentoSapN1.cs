using SARCEM_TCC.web.Models.Domain.DataMass;
using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("MovimentoSapN1s")]
    public class MovimentoSapN1
    {
        [Key]
        public int MovSapN1ID  { get; set; }
        [StringLength(5)]
        public string MovSapN1CodSap  { get; set; }
        public string MovSapN1DescicaoSap  { get; set; }
        public string MovSapN1DescricaoLogistica { get; set; }


        public virtual List<MovimentoSapN2> MovimentoSapN2 { get; set; }
        public virtual List<Mb51> Mb51s { get; set; }

    }
}