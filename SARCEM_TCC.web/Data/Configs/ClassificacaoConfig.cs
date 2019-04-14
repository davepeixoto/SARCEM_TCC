using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class ClassificacaoConfig : EntityTypeConfiguration<Classificacao>
    {
        public ClassificacaoConfig()
        {
            ToTable("Classificacoes");
        }
        //public int ClassificacaoId { get; set; }

        //public string ClassificacaoNome { get; set; }

        //public virtual List<Material> Materiais { get; set; }
        //public virtual List<Estoque> Estoques { get; set; }
        //public virtual List<Ajuste2015> Ajuste2015s { get; set; }
        //public virtual List<Giro> Giros { get; set; }
    }
}