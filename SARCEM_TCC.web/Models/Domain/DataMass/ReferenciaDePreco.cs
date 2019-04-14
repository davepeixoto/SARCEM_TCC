using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("ReferenciaDePrecos")]
    public class ReferenciaDePreco
    {
        [Key]
        public int      PrecoId         { get; set; }
        public int      MaterialID      { get; set; }    
        public decimal  PrecoValor      { get; set; }
        public DateTime PrecoDataLanc  { get; set; }
        public string UsuarioId { get; set; }

        public virtual Material Material { get; set; }
        public UsuarioLogistica Usuario { get; set; }
    }
}