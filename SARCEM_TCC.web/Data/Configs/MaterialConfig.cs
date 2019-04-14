using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class MaterialConfig : EntityTypeConfiguration<Material>
    {


        public MaterialConfig()
        {
            ToTable("Materiais");


            Property(c => c.MaterialCodSap).HasMaxLength(10);
            Property(c => c.MaterialClasse).HasMaxLength(2);
            Property(c => c.MaterialUM).HasMaxLength(5);

             HasOptional(c => c.MaterialSub)
                .WithMany()
                .HasForeignKey(c => c.MaterialSubId);






        }
       




    }

}
