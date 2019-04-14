using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class MovimentoEstoqueConfig : EntityTypeConfiguration<MovimentoEstoque>
    {
        public MovimentoEstoqueConfig()
        {
            ToTable("MovimentoEstoques");

            HasKey(c => c.MovEstqID);


            Property(c => c.MovEstqSigla).HasMaxLength(5);


        }
        //[Key]
        //public int MovEstqId { get; set; }
        //public string MovEstqChave { get; set; }
        //[StringLength(5)]
        //public string MovEstqSigla { get; set; }
    }
}