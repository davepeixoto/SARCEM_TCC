using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class MovimentoSapN2Config : EntityTypeConfiguration<MovimentoSapN2>
    {

        public MovimentoSapN2Config()
        {


            ToTable("MovimentoSapN2s");

            HasKey(c => c.MovSapN2ID);

            Property(c => c.MovSapN2TMv2Chave).HasMaxLength(10);

            //Property(c => c.MovSapN2StatusPrimario).HasMaxLength(100);

            //Property(c => c.MovSapN2StatusSecundario).HasMaxLength(100);

        }
    }
}