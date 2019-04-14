using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class EstoqueConfig : EntityTypeConfiguration<Estoque>
    {

        public EstoqueConfig()
        {
            ToTable("Estoques");
            Property(c => c.EstoqueAdmin).HasColumnType("varchar").HasMaxLength(3);

            Property(c => c.EstoqueExpurgado).HasColumnType("varchar").HasMaxLength(3);

            Property(c => c.ClasseAvaliacaoID).HasColumnType("varchar").HasMaxLength(6);

            HasOptional(c => c.ClasseAvaliacao)
                .WithMany(e => e.Estoques)
                .HasForeignKey(f => f.ClasseAvaliacaoID);

                

        }
        //    public long EstoqueId { get; set; }
        //    public int CentroLogisticoId { get; set; }
        //    public int MaterialId { get; set; }
        //    public decimal EstoqueQtde { get; set; }
        //    public decimal? EstoqueValor { get; set; }
        //    [StringLength(1)]
        //    public string EstoqueAdmin { get; set; }
        //    public int? EstoquePeriodo { get; set; }
        //    public int? EstoqueEquivalente { get; set; }
        //    public int? ClassificacaoId { get; set; }
        //    [StringLength(1)]
        //    public string EstoqueExpurgado { get; set; }
        //    [StringLength(6)]
        //    public string ClasseAvaliacaoId { get; set; }

        //    public virtual CentroLogistico CentroLogistico { get; set; }
        //    public virtual Classificacao Classificacao { get; set; }
        //    public virtual Material Material { get; set; }
        //    public ClasseAvaliacao ClasseAvaliacao { get; set; }
    }
}