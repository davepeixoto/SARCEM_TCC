using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class Me2mConfig : EntityTypeConfiguration<Me2m>
    {
        public Me2mConfig()
        {
            ToTable("Me2ms");

            HasKey(k => k.Me2mID);
            

            HasRequired(c => c.CentroLogisticosRec)
                .WithMany(m => m.Me2mRecebedor)
                .HasForeignKey(f => f.Me2mCentroRecebedor);

            HasOptional(c => c.CentroLogisticosOrig)
               .WithMany(m => m.Me2mOrigem)
                .HasForeignKey(f => f.Me2mCentroOrigem);

        }

        
    }
}