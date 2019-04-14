using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain
{
    [Table("CondicaoDePagamentos")]
    public class CondicaoDePagamento
    {
        public int CondicaoDePagamentoID { get; set; }
        [StringLength(6)]
        public string CondicaoDePagamentoCodSap { get; set; }
        public string CondicaoDePagamentoDescricao { get; set; }

        public List<Zmep> Zmeps { get; set; }
        public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }
        
    }
}