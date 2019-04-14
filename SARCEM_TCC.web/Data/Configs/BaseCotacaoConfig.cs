using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class BaseCotacaoConfig : EntityTypeConfiguration<BaseCotacao>
    {
        public BaseCotacaoConfig()
        {
            ToTable("BaseCotacoes");


        Property(c => c.BaseCotacaoID           ).HasColumnType("int");//int     
        Property(c => c.BaseCotacaoNome         ).HasColumnType("varchar").HasMaxLength(100);//string  
        Property(c => c.BaseCotacaoSigla        ).HasColumnType("varchar").HasMaxLength(100);//string  
        Property(c => c.BaseCotacaoValor        ).HasColumnType("money");//decimal 
        Property(c => c.BaseCotacaoDataDaCotacao).HasColumnType("datetime").IsOptional();//DateTime

            HasMany(f => f.Zmeps).WithRequired(p => p.BaseCotacao).HasForeignKey(k => k.BaseCotacaoID);
            HasMany(f => f.PedidoDeCompras).WithRequired(p => p.BaseCotacao).HasForeignKey(k => k.BaseCotacaoID);



        /*
        public virtual List<PedidoDeCompra> PedidoDeCompras 
        public virtual List<Zmep> Zmeps  */

    }
}
}