using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ReferenciaDePrecoConfig : EntityTypeConfiguration<ReferenciaDePreco>
    {
        public ReferenciaDePrecoConfig()
        {
            ToTable("ReferenciaDePrecos");

            HasKey(c => c.PrecoId);
            
               HasRequired(u => u.Usuario)
                .WithMany(e => e.ReferenciaDePrecos)
                 .HasForeignKey(p => p.UsuarioId);

            Property(r => r.UsuarioId)
                .HasMaxLength(128);
        }
        
    }
}