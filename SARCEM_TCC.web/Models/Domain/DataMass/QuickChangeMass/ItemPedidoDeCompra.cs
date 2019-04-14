using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    [Table("ItemPedidoDeCompras")]
    public class ItemPedidoDeCompra
    {

        public long ItemPedidoDeCompraId { get; set; }
        public long PedidoDeCompraId { get; set; }
        public DateTime ItemPedidoDeCompraDataRemessa  { get; set; }
        [StringLength(5)]
        public string ItemPedidoDeCompraElim  { get; set; }
        public int ItemPedidoDeCompraItem  { get; set; }
        public int? MaterialID { get; set; }
        public int? CentroLogisticoID { get; set; }
        [StringLength(50)]
        public string ItemPedidoDeCompraAvaliacao  { get; set; }
        public decimal? ItemPedidoDeCompraQtdePedida  { get; set; }
        public decimal? ItemPedidoDeCompraValorLiquido  { get; set; }
        public decimal? ItemPedidoDeCompraValorBruto  { get; set; }
        [StringLength(15)]
        public string ItemPedidoDeCompraReqCompra  { get; set; }
        public int ItemPedidoDeCompraItemReqCompra  { get; set; }
        public long? ContratoID { get; set; }
        public int? ItemPedidoDeCompraItemContrato  { get; set; }
        public decimal? ItemPedidoDeCompraValorReferencia { get; set; }

        public virtual Material Material { get; set; }
        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Contrato Contrato { get; set; }
        public virtual PedidoDeCompra PedidoDeCompra { get; set; }
        
}
}