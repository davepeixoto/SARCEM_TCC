using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class HistoricoDeCompraConfig : EntityTypeConfiguration<HistoricoDeCompra>
    {

        public HistoricoDeCompraConfig()
        {
            ToTable("HistoricoDeCompras");
            HasKey(c => c.HistCompID);

            Property(c => c.HistCompResponsavel).HasMaxLength(80);

            Property(c => c.HistCompODC).HasMaxLength(20);

            Property(c => c.HistCompGrC).HasMaxLength(80);
        }

        //[Key]
        //public long HistCompID { get; set; }
        //public int MaterialId { get; set; }
        //public DateTime? HistCompDataPedido { get; set; }
        //public string HistCompResponsável { get; set; }
        //public string HistCompODC { get; set; }
        //public int? HistCompItem { get; set; }
        //public decimal? HistCompQuant { get; set; }
        //public decimal? HistCompPreco_semImpostos { get; set; }
        //public decimal? HistCompICMS { get; set; }
        //public decimal? HistCompIPI { get; set; }
        //public decimal? HistCompPreco_comICMS_semIPI { get; set; }
        
        //public long? FornecedorID { get; set; }
        //public decimal? HistCompPreco_emDolar { get; set; }
        //public decimal? HistCompPreco_emRS_semICMS_comIPI { get; set; }
        //public decimal? HistCompDolar_doDia { get; set; }
        //public decimal? HistCompValor_IPI { get; set; }
        //public decimal? HistCompValor_ICMS { get; set; }
        //public decimal? HistCompP_x_Q_emRS { get; set; }
        //public decimal? HistCompP_x_Q_emUS { get; set; }
        //public decimal? HistCompYBR { get; set; }
        //public string HistCompGrC { get; set; }
        //public DateTime? HistCompDataLanc { get; set; }

        //public virtual Fornecedor Fornecedor { get; set; }
        //public virtual Material Material { get; set; }
    }
}