using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class Mb51Config : EntityTypeConfiguration<Mb51>
    {
        public Mb51Config()
        {
            ToTable("Mb51s");


            Property(c => c.Mb51Expurgado).HasMaxLength(2);
        }

        //public long Mb51Id { get; set; }
      
        //public int MaterialId { get; set; }

      
        //public int? CentroLogisticoId { get; set; }
        //public int? Mb51Dep { get; set; }

     
        //public int? MovSapN1Id { get; set; }
        //public string Mb51DocMat { get; set; }
        //public int? Mb51Itm { get; set; }
        //public string Mb51TextoCabDocumento { get; set; }
        //public string Mb51Reserva { get; set; }
        //public string Mb51Pedido { get; set; }
        //public string Mb51Referencia { get; set; }
        //public string Mb51Texto { get; set; }
        //public string Mb51Tipo { get; set; }
        //public DateTime? Mb51DataDocumento { get; set; }
        //public DateTime? Mb51DataLancamento { get; set; }
        
        //public long? OrdemId { get; set; }
        //public string Mb51PtoDescarga { get; set; }
        //public decimal? Mb51QtdUMReg { get; set; }
        //public string Mb51Lote { get; set; }
        //public decimal? Mb51MontanteMI { get; set; }
        //public int? Mb51Periodo { get; set; }
        //public int? Mb51Equivalente { get; set; }
        //public string Mb51Expurgado { get; set; }
        //public DateTime? Mb51DataLanc { get; set; }

        //public virtual CentroLogistico CentroLogistico { get; set; }
        //public virtual Material Material { get; set; }
        //public virtual Ordem Ordem { get; set; }
    }
}