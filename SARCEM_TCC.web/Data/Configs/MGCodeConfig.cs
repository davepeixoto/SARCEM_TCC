using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class MGCodeConfig : EntityTypeConfiguration<MGCode>
    {
        public MGCodeConfig()
        {
            ToTable("MGCodes");

            //  HasKey(c => c.MGCodeId);

            Property(c => c.MGCodeCodigoSap).HasMaxLength(10);

            Property(c => c.MGCodeDescricao).HasMaxLength(100);

        }
        //public int MGCodeId { get; set; }
        //[StringLength(10)]
        //public string MGCodeCodigoSap { get; set; }
        //public string MGCodeDescricao { get; set; }

        //public virtual List<Material> Materiais { get; set; }
    }
}