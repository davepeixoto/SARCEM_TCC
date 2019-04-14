using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class PedidoDeCompraConfig : EntityTypeConfiguration<PedidoDeCompra>
    {
        public PedidoDeCompraConfig()
        {
            ToTable("PedidoDeCompras");

            Property(c => c.Pedido).HasMaxLength(20);

            Property(c => c.Tipo).HasMaxLength(10);

            Property(c => c.OrgDeCompra).HasMaxLength(10);

            Property(c => c.Criador).HasMaxLength(30);

            


        }
        //public long PedidoDeCompraId { get; set; }
        //public long EmpresaId  { get; set; }
        //[StringLength(15)]
        //public string Pedido { get; set; }
        //public DateTime DataCriacao  { get; set; }
        //[StringLength(5)]
        //public string Tipo  { get; set; }
        //[StringLength(5)]
        //public string OrgDeCompra  { get; set; }
        //public long FornecedorId  { get; set; }
        //[StringLength(20)]
        //public string Criador  { get; set; }
        //public int CondicaoDePagamentoId { get; set; }
        //public int BaseCotacaoId { get; set; }

        //public virtual Empresa Empresa { get; set; }
        //public virtual  Fornecedor Fornecedor { get; set; }
        //public virtual CondicaoDePagamento CondicaoDePagamento { get; set; }
        //public virtual BaseCotacao BaseCotacao { get; set; }


        //public virtual List<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }

    }
}