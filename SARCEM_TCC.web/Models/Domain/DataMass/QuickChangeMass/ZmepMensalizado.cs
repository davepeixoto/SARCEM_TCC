using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    [Table("ZmepMensalizados")]
    public class ZmepMensalizado
    {
        [Key]
        public int Id { get; set; }
        public int MaterialID { get; set; }
        public decimal Atraso { get; set; }
        public decimal Month1 { get; set; }
        public decimal Month2 { get; set; }
        public decimal Month3 { get; set; }
        public decimal Month4 { get; set; }
        public decimal Month5 { get; set; }
        public decimal Month6 { get; set; }
        public decimal Month7 { get; set; }
        public decimal Month8 { get; set; }
        public decimal Month9 { get; set; }
        public decimal Month10 { get; set; }
        public decimal Month11 { get; set; }
        public decimal Month12 { get; set; }
        public decimal Month13 { get; set; }
        public decimal Month14 { get; set; }
        public decimal Month15 { get; set; }
        public decimal Month16 { get; set; }
        public decimal Month17 { get; set; }
        public decimal Month18 { get; set; }
        public decimal Month19 { get; set; }
        public decimal Month20 { get; set; }
        public decimal Month21 { get; set; }
        public decimal Month22 { get; set; }
        public decimal Month23 { get; set; }
        public decimal Month24 { get; set; }
        public DateTime DataLanc { get; set; }
        
    }
}
