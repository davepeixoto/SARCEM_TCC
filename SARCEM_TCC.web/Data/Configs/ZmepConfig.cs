using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ZmepConfig : EntityTypeConfiguration<Zmep>
    {
        public ZmepConfig()
        {
            ToTable("Zmeps");
            HasKey(c => c.ZmepID);

        Property(c => c.ZmepID                  ).HasColumnType("bigint"); //long        
        Property(c => c.ZmepPedido              ).HasColumnType("varchar").HasMaxLength(20); //string      
        Property(c => c.ZmepPos                 ).HasColumnType("int"); //int         
        Property(c => c.MaterialID              ).HasColumnType("int"); //int         
        Property(c => c.ZmepDataEntrg           ).HasColumnType("datetime").IsOptional(); //DateTime?   
        Property(c => c.ZmepQtdePedido          ).HasColumnType("money"); //decimal     
        Property(c => c.ZmepQtdeEmPend          ).HasColumnType("money").IsOptional(); //decimal?    
        Property(c => c.ZmepImpPedido           ).HasColumnType("money").IsOptional(); //decimal?    
        Property(c => c.ZmepImpEmPend           ).HasColumnType("money").IsOptional(); //decimal?    
        Property(c => c.BaseCotacaoID           ).HasColumnType("int"); //int         
        Property(c => c.FornecedorID            ).HasColumnType("bigint").IsOptional(); //long?       
        Property(c => c.ContratoID              ).HasColumnType("bigint").IsOptional(); //long?       
        Property(c => c.ZmepDataDaCompra        ).HasColumnType("datetime"); //DateTime    
        Property(c => c.CondicaoDePagamentoID   ).HasColumnType("int").IsOptional(); //int?        
        Property(c => c.ZmepDataLanc            ).HasColumnType("datetime"); //DateTime    
        Property(c => c.ZmepCentroImputado      ).HasColumnType("varchar").HasMaxLength(3); //string      

            HasOptional(p => p.Contrato).WithMany(f => f.Zmeps).HasForeignKey(k => k.ContratoID);
            HasOptional(p => p.Fornecedor).WithMany(f => f.Zmeps).HasForeignKey(k => k.FornecedorID);
            HasRequired(p => p.BaseCotacao).WithMany(f => f.Zmeps).HasForeignKey(k => k.BaseCotacaoID);
            HasRequired(p => p.CondicaoDePagamento).WithMany(f => f.Zmeps).HasForeignKey(k => k.CondicaoDePagamentoID);
            HasRequired(p => p.Material).WithMany(f => f.Zmeps).HasForeignKey(k => k.MaterialID);

        }

/*
        public virtual Contrato Contrato 
        public virtual Fornecedor Fornecedor
        
        public virtual BaseCotacao BaseCotacao 
        public virtual CondicaoDePagamento CondicaoDePagamento 
        public virtual Material Material 
*/
    }
}