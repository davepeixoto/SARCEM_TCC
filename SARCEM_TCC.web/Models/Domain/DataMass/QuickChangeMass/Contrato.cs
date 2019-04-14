using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    [Table("Contratos")]
    public class Contrato
    {
        public long ContratoID { get; set; }
        [StringLength(20)]
        public string ContratoNumero { get; set; }
        public DateTime? ContratoDataDoc { get; set; }
        public string ContratoTipo { get; set; }
        public DateTime? ContratoIniPrazo { get; set; }
        public DateTime? ContratoFimValidade { get; set; }
        public string ContratoGCm { get; set; }
        public int? BaseCotacaoID { get; set; }
        public decimal? ContratoValFixado { get; set; }
        public decimal? ContratoValGlPend { get; set; }
        public long? FornecedorID { get; set; }
        public DateTime? ContratoDataLanc { get; set; }
        public DateTime? ContratoDataAlteracao { get; set; }

        public virtual BaseCotacao BaseCotacao { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public virtual List<ItemDoContrato> ItemDoContratos { get; set; }
        public virtual List<Zmep> Zmeps { get; set; }
        public virtual List<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }
    }
}