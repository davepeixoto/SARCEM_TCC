using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class MovimentoSapN1Config : EntityTypeConfiguration<MovimentoSapN1>
    {

        public MovimentoSapN1Config()
        {
            ToTable("MovimentoSapN1s");

            HasKey(c => c.MovSapN1ID);

            Property(c => c.MovSapN1CodSap).HasMaxLength(5);

            //Property(c => c.MovSapN1DescicaoSap).HasMaxLength(100);

            //Property(c => c.MovSapN1DescricaoLogistica).HasMaxLength(100);

        }

    }

}
