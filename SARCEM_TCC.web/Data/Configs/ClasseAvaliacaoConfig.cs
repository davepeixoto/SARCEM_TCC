using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class ClasseAvaliacaoConfig : EntityTypeConfiguration<ClasseAvaliacao>
    {

        public ClasseAvaliacaoConfig()
        {
            ToTable("ClasseAvaliacoes");
            HasKey(c => c.ClasseAvaliacaoID);

            Property(d => d.ClasseAvaliacaoID).HasColumnType("varchar").HasMaxLength(6);
            Property(c => c.ClasseAvaliacaoContaRazao).HasColumnType("varchar").HasMaxLength(20);
            Property(c => c.ClasseAvaliacaoTipo).HasColumnType("varchar").HasMaxLength(20);


        }
        //[Key]
        //[StringLength(6)]
        //public string ClasseAvaliacaoId { get; set; }
        //public string ClasseAvaliacaoDescricao { get; set; }
        //public string  ClasseAvaliacaoContaRazao { get; set; }
        //public string ClasseAvaliacaoTipo { get; set; }


        //public virtual List<Estoque> Estoques { get; set; }

    }
}