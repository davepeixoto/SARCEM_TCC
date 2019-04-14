using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Mb51s")]
    public class Mb51
    {
        public long Mb51Id { get; set; }
      
        public int MaterialID { get; set; }

      
        public int? CentroLogisticoID { get; set; }
        public int? Mb51Dep { get; set; }

     
        public int? MovSapN1ID { get; set; }
        public string Mb51DocMat { get; set; }
        public int? Mb51Itm { get; set; }
        public string Mb51TextoCabDocumento { get; set; }
        public string Mb51Reserva { get; set; }
        public string Mb51Pedido { get; set; }
        public string Mb51Referencia { get; set; }
        public string Mb51Texto { get; set; }
        public string Mb51Tipo { get; set; }
        public DateTime? Mb51DataDocumento { get; set; }
        public DateTime? Mb51DataLancamento { get; set; }
        
        public long? OrdemID { get; set; }
        public string Mb51PtoDescarga { get; set; }
        public decimal? Mb51QtdUMReg { get; set; }
        public string Mb51Lote { get; set; }
        public decimal? Mb51MontanteMI { get; set; }
        public int? Mb51Periodo { get; set; }
        public int? Mb51Equivalente { get; set; }
        public string Mb51Expurgado { get; set; }
        public DateTime? Mb51DataLanc { get; set; }

        public virtual CentroLogistico CentroLogistico { get; set; }
        public virtual Material Material { get; set; }
        public virtual Ordem Ordem { get; set; }
    }
}