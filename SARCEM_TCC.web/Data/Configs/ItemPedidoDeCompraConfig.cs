using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ItemPedidoDeCompraConfig : EntityTypeConfiguration<ItemPedidoDeCompra>
    {
        public ItemPedidoDeCompraConfig()
        {
            ToTable("ItemPedidoDeCompras");

            Property(c => c.ItemPedidoDeCompraElim).HasMaxLength(10);

            Property(c => c.ItemPedidoDeCompraAvaliacao).HasMaxLength(50);

            Property(c => c.ItemPedidoDeCompraReqCompra).HasMaxLength(20);

            

            
        }

       
        
}
}