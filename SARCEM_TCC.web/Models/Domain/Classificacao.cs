using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SARCEM_TCC.web.Models.Domain
{
    [Table("Classificacoes")]
    public class Classificacao
    {
        public int ClassificacaoID { get; set; }

        public string ClassificacaoNome { get; set; }

        public virtual List<Material> Materiais { get; set; }
        public virtual List<Zmov> Zmovs { get; set; }
        public virtual List<Estoque> Estoques { get; set; }
        public virtual List<Ajuste2015> Ajuste2015s { get; set; }
        public virtual List<Giro> Giros { get; set; }
    }
}