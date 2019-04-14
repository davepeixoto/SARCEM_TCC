using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ContratoConfig : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfig()
        {
            ToTable("Contratos");

            Property(c => c.ContratoNumero).HasColumnType("varchar").HasMaxLength(20);

            Property(c => c.ContratoTipo).HasColumnType("varchar").HasMaxLength(10);

            Property(c => c.ContratoGCm).HasColumnType("varchar").HasMaxLength(10);

          

        }
        //public long ContratoId { get; set; }
        //[StringLength(20)]
        //public string ContratoNumero { get; set; }
        //public DateTime? ContratoDataDoc { get; set; }
        //public string ContratoTipo { get; set; }
        //public DateTime? ContratoIniPrazo { get; set; }
        //public DateTime? ContratoFimValidade { get; set; }
        //public string ContratoGCm { get; set; }
        //public int? BaseCotacaoId { get; set; }
        //public decimal? ContratoValFixado { get; set; }
        //public decimal? ContratoValGlPend { get; set; }
        //public long? FornecedorID { get; set; }
        //public DateTime ContratoDataLanc { get; set; }
        //public DateTime? ContratoDataAlteracao { get; set; }

        //public virtual BaseCotacao BaseCotacao { get; set; }
        //public virtual Fornecedor Fornecedor { get; set; }

        //public virtual List<ItemDoContrato> ItemDoContratos { get; set; }
        //public virtual List<Zmep> Zmeps { get; set; }
        //public virtual List<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }
    }
}