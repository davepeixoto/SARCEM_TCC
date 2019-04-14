using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class HistoricoPlmConfig : EntityTypeConfiguration<HistoricoPlm>
    {
        public HistoricoPlmConfig()
        {
            ToTable("HistoricoPlms");
            HasKey(c => c.PlmID);

            Property(p => p.UsuarioClienteId)
      .HasMaxLength(128);

        }


        //[Key]
        //public long PlmId { get; set; }
        //public int? MaterialId { get; set; }
        //public int? CentroLogisticoId { get; set; }
        //public int? DiretoriaId { get; set; }
        //public int? SubDiretoriaId { get; set; }
        //public string PlmProjeto { get; set; }
        //public string PlmInfoAdicional { get; set; }
        //public string PlmResponsavel { get; set; }

        //public string ClienteId { get; set; }
        //public decimal? PlmQuantidade { get; set; }
        //public int? PlmPeriodo { get; set; }
        //public int? PlmEquivalente { get; set; }
        //public System.DateTime? PlmDataLanc { get; set; }

        //public virtual SubDiretoria SubDiretoria { get; set; }
        //public virtual CentroLogistico CentroLogistico { get; set; }
        //public virtual Diretoria Diretoria { get; set; }
        //public virtual Material Material { get; set; }
        //public virtual Cliente Clientes { get; set; }

    }
}