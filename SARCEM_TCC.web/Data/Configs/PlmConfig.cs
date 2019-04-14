using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class PlmConfig : EntityTypeConfiguration<Plm>
    {
        public PlmConfig()
        {
            ToTable("Plms");
            Property(p => p.UsuarioClienteId)
                  .HasMaxLength(128);
                


        }
        
    }
}