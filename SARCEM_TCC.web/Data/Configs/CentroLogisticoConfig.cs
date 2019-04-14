using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class CentroLogisticoConfig : EntityTypeConfiguration<CentroLogistico>
    {
        public CentroLogisticoConfig()
        {
            ToTable("CentrosLogisticos");

            Property(c => c.CentroLogisticoCodSap)
                .HasMaxLength(8);

          
            HasMany(f => f.Me2mRecebedor)
                .WithRequired(p => p.CentroLogisticosRec)
                .HasForeignKey(m=> m.Me2mCentroRecebedor);

            HasMany(f => f.Me2mOrigem)
                .WithOptional(p => p.CentroLogisticosOrig)
                .HasForeignKey(m=> m.Me2mCentroOrigem);

           // Property(c => c.CEP).HasMaxLength(15);

        }
    

    }
}