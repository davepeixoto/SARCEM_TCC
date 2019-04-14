using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{


    public class PaisConfig : EntityTypeConfiguration<Pais>
    {
        public PaisConfig()

        {
            ToTable("Paises");

            // HasKey(c => c.PaisId);

            Property(c => c.PaisNome)
                .HasMaxLength(50);

            Property(c => c.PaisSigla)
            .HasMaxLength(5);

        }
    }
}