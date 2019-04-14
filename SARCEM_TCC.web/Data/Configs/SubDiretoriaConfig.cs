using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class SubDiretoriaConfig : EntityTypeConfiguration<SubDiretoria>
    {
        public SubDiretoriaConfig()
        {
            ToTable("SubDiretorias");

            //  HasKey(c => c.SubDiretoriaId);


            //HasKey(c => c.DiretoriaId)
            //    .HasRequired(d => d.Diretoria)
            //    .WithRequiredDependent();

            //Property(c => c.SubDiretoriaNome)
            //    .HasMaxLength(50);

            Property(c => c.SubDiretoriaSigla)
                .HasMaxLength(6);


            


        }
    }
}