using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class CondicaoDePagamentoConfig : EntityTypeConfiguration<CondicaoDePagamento>
    {
        public CondicaoDePagamentoConfig()
        {
            ToTable("CondicaoDePagamentos");

            Property(c => c.CondicaoDePagamentoCodSap).HasColumnType("varchar").HasMaxLength(6);

            Property(c => c.CondicaoDePagamentoDescricao).HasColumnType("varchar").HasMaxLength(285);
        }
        //public int CondicaoDePagamentoId { get; set; }
        //[StringLength(6)]
        //public string CondicaoDePagamentoCodSap { get; set; }
        //public string CondicaoDePagamentoDescricao { get; set; }

        //public List<Zmep> Zmeps { get; set; }
        //public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }

    }
}