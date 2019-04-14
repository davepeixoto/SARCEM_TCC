using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class CecoConfig : EntityTypeConfiguration<Ceco>
    {
        public CecoConfig()
        {
            ToTable("Cecos");

            Property(c => c.CecoCodSap).HasMaxLength(10);

            Property(c => c.CecoSigla).HasMaxLength(10);

            Property(c => c.CecoGerencia).HasMaxLength(80);

            Property(c => c.CecoDescricao).HasMaxLength(80);

            Property(c => c.CecoProjeto).HasMaxLength(80);
        }

        //public long CecoId { get; set; }
        //[StringLength(10)]
        //public string CecoCodSap { get; set; }
        //[StringLength(10)]
        //public string CecoSigla { get; set; }
        //public string CecoGerencia { get; set; }
        //public string CecoDescricao { get; set; }
        //public long EmpresaId { get; set; }
        //public string CecoProjeto { get; set; }


        //public virtual Empresa Empresa { get; set; }
        //public virtual List<Ordem> Ordens { get; set; }
        //public virtual List<Reserva> Reservas { get; set; }

    }
}