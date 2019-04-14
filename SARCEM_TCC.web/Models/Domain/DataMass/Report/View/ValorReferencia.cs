using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("ValorReferencias")]
    public class ValorReferencia:VMaterial
    {
       
      
        public decimal  ValorDeReferencia { get; set; }
        [StringLength(30)]
        public string Origem { get; set; }


       

    }
}

















