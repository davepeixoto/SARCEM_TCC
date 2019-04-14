using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("MovimentoSapN2s")]
    public class MovimentoSapN2
    {
        [Key]
        public int MovSapN2ID { get; set; }
        [StringLength(10)]
        public string MovSapN2TMv2Chave  { get; set; }
        public int MovSapN1ID   { get; set; }
        [StringLength(1)]
        public string MovSapN2Sinal  { get; set; }
        public string MovSapN2StatusPrimario  { get; set; }
        public string MovSapN2StatusSecundario { get; set; }
        public virtual MovimentoSapN1 MovimentoSapN1 { get; set; }
        
    }
}