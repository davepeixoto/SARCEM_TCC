using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            ToTable("Fornecedores");
            Property(c => c.FornecedorNome).HasColumnType("varchar").HasMaxLength(150);
        }

        //public long FornecedorID { get; set; }
        //public string FornecedorNome { get; set; }

        //public virtual List<Contrato> Contratos { get; set; }
        //public virtual List<HistoricoDeCompra> HistoricoDeCompras { get; set; }
        //public virtual List<Zmep> Zemps { get; set; }
        //public virtual List<Me2m> Me2ms { get; set; }
        //public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }
    }

}