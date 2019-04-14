using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class Mm60Config : EntityTypeConfiguration<Mm60>
    {
        public Mm60Config()
        {
            ToTable("Mm60s");
        }
        //public long Mm60Id { get; set; }
        //public int MaterialId { get; set; }
        //public decimal? Mm60Valor { get; set; }
        //public int? CentroLogisticoId { get; set; }
        //public System.DateTime? Mm60DataUltModif { get; set; }
        //public int Mm60Periodo { get; set; }
        //public int Mm60Equivalente { get; set; }

        //public virtual CentroLogistico CentroLogistico { get; set; }
        //public virtual Material Material { get; set; }
    }
}