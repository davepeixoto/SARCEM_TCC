using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class EstadoConfig : EntityTypeConfiguration<Estado>
    {
        public EstadoConfig()
        {

            ToTable("Estados");

            // HasKey(c => c.EstadoId);

            Property(c => c.EstadoSiga).HasColumnType("varchar").HasMaxLength(3);
        }
        //public int EstadoId { get; set; }
        //public string EstadoNome { get; set; }
        //[StringLength(2)]
        //public string EstadoSiga { get; set; }
        //public int PaisId { get; set; }

        //public virtual Pais Pais { get; set; }

        //public virtual List<Cidade> Cidades { get; set; }
    }
}