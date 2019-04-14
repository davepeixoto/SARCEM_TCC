using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    [Table("PedidoDeCompras")]
    public class PedidoDeCompra
    {
        public long PedidoDeCompraId { get; set; }
        public long? EmpresaId  { get; set; }
        [StringLength(15)]
        public string Pedido { get; set; }
        public DateTime? DataCriacao  { get; set; }
        [StringLength(5)]
        public string Tipo  { get; set; }
        [StringLength(5)]
        public string OrgDeCompra  { get; set; }
        public long? FornecedorId  { get; set; }
        [StringLength(20)]
        public string Criador  { get; set; }
        public int? CondicaoDePagamentoID { get; set; }
        public int? BaseCotacaoID { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual  Fornecedor Fornecedor { get; set; }
        public virtual CondicaoDePagamento CondicaoDePagamento { get; set; }
        public virtual BaseCotacao BaseCotacao { get; set; }


        public virtual List<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }

    }
}