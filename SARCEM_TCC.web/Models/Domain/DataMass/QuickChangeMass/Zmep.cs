using System;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    public class Zmep
    {
        public long         ZmepID { get; set; }
        public string       ZmepPedido { get; set; }
        public int          ZmepPos { get; set; }
        public int          MaterialID { get; set; }
        public DateTime?    ZmepDataEntrg { get; set; }
        public decimal      ZmepQtdePedido { get; set; }
        public decimal?     ZmepQtdeEmPend { get; set; }
        public decimal?     ZmepImpPedido { get; set; }
        public decimal?     ZmepImpEmPend { get; set; }
        public int      BaseCotacaoID { get; set; }
        public long?    FornecedorID { get; set; }
        public long? ContratoID { get; set; }
        public DateTime ZmepDataDaCompra { get; set; }
        public int? CondicaoDePagamentoID { get; set; }
        public DateTime ZmepDataLanc { get; set; }
        public string ZmepCentroImputado{ get; set; }

        public virtual BaseCotacao BaseCotacao { get; set; }
        public virtual CondicaoDePagamento CondicaoDePagamento { get; set; }
        public virtual Contrato Contrato { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Material Material { get; set; }
    }
}