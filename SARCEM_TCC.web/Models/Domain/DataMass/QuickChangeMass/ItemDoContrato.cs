using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass
{
    [Table("ItemDoContratos")]
    public class ItemDoContrato
    {
        public long ItemDoContratoID { get; set; }
        public long ContratoID { get; set; }
        public int ItemDoContratoItm { get; set; }
        public int? MaterialID { get; set; }
        public string ItemDoContratoElim { get; set; }
        public int? CentroLogisticoID { get; set; }
        public decimal? ItemDoContratoQtdeDisp { get; set; }
        public decimal? ItemDoContratoQtdeContrato { get; set; }
        public decimal? ItemDoContratoValRef { get; set; }
        public DateTime? ItemDoContratoDataLanc { get; set; }
        public DateTime? ItemDoContratoDataAlteracao { get; set; }

        public virtual Contrato Contrato { get; set; }
        public virtual Material Material { get; set; }
        public virtual CentroLogistico CentroLogistico { get; set; }
    }
}