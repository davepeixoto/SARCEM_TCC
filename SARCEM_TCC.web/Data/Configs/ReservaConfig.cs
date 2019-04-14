using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ReservaConfig : EntityTypeConfiguration<Reserva>
    {
        public ReservaConfig()
        {
            ToTable("Reservas");
         
        }
        
    }
}