using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class Mb52Config : EntityTypeConfiguration<Mb52>
    {
        public Mb52Config()
        {
            ToTable("Mb52s");

            Property(c => c.Mb52Lote).HasMaxLength(50);

           
        }
        //public int Mb52Id { get; set; }
        //public int? MaterialId { get; set; }
        //public int CentroLogisticoId { get; set; }
        //public int? Mb52Dep { get; set; }
        //public string Mb52Lote { get; set; }
        //public decimal? Mb52UtLivre { get; set; }
        //public decimal? Mb52ValorUtLivre { get; set; }
        //public decimal? Mb52EmTrans { get; set; }
        //public decimal? Mb52ValorEmTrans { get; set; }
        //public decimal? Mb52EmCQ { get; set; }
        //public decimal? Mb52ValorEmCQ { get; set; }
        //public decimal? Mb52Restrito { get; set; }
        //public decimal? Mb52ValorRestrito { get; set; }
        //public decimal? Mb52Bloqueados { get; set; }
        //public decimal? Mb52ValorBloqueados { get; set; }
        //public decimal? Mb52Devolucoes { get; set; }
        //public decimal? Mb52ValorDevolucoes { get; set; }
        //public DateTime Mb52DataLanc { get; set; }

        //public virtual CentroLogistico CentroLogistico { get; set; }
        //public virtual Material Material { get; set; }
    }
}