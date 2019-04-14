using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Zmovs")]
    public class Zmov
    {
        public long ZmovID { get; set; }
        public System.DateTime? ZmovFecDocum { get; set; }
        public string ZmovDocMat { get; set; }
        public int? ZmovPos1 { get; set; }
        public int? CentroLogisticoID { get; set; }
        public int? ZmovAlm { get; set; }
        public string ZmovLote { get; set; }
        public int? MaterialID { get; set; }
        public string ZmovCodigoAntiguo { get; set; }
        public string ZmovGr { get; set; }
        public decimal? ZmovCantidad { get; set; }
        public string ZmovE1 { get; set; }
        public string ZmovCMO { get; set; }
        public string ZmovE2 { get; set; }
        public string ZmovProv { get; set; }
        public string ZmovPedido { get; set; }
        public int? ZmovPos2 { get; set; }
        public long? OrdemID { get; set; }
        public string ZmovTexto { get; set; }
        public decimal? ZmovImpEnt { get; set; }
        public decimal? ZmovImpSal { get; set; }
        public string ZmovNombreDelU { get; set; }
        public decimal? ZmovQtde { get; set; }
        public decimal? ZmovValor { get; set; }
        public int? ZmovPeriodo { get; set; }
        public int? ZmovEquivalente { get; set; }
        public int? ClassificacaoID { get; set; }
        public string ZmovExpurgado { get; set; }
        public System.DateTime? ZmovDataLanc { get; set; }

        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Classificacao Classificacao { get; set; }
        public virtual Material Material { get; set; }
        public virtual Ordem Ordem { get; set; }
    }
}