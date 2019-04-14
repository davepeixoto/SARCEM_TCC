using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Reservas")]
    public class Reserva
    {
        public int ReservaID { get; set; }
        public string ReservaPedido { get; set; }
        public System.DateTime? ReservaDataCriacao { get; set; }
        public long? CecoID { get; set; }
        public int ReservaPos { get; set; }
        public int MaterialID { get; set; }
        public decimal? ReservaQtdeOrdenada { get; set; }
        public decimal? ReservaQtdeDespachada { get; set; }
        public decimal? ReservaQtdePendente { get; set; }
        public int CentroLogisticoID { get; set; }
        public long? OrdemID { get; set; }
        public string ReservaCodEmpreiteira { get; set; }
        public string ReservaClasseCusto { get; set; }
        public string ReservaLogin { get; set; }
        public string ReservaObs { get; set; }
        public string ReservaLote { get; set; }
        public System.DateTime ReservaDataLanc { get; set; }

        public virtual Ceco Ceco { get; set; }
        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Material Material { get; set; }
        public virtual Ordem Ordem { get; set; }
    }
}