using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class ZmovConfig : EntityTypeConfiguration<Zmov>
    {
        public ZmovConfig()
        {
            ToTable("Zmovs");

            Property(c=>c.ZmovID               ).HasColumnType("bigint"); //long         
            Property(c=>c.ZmovFecDocum         ).HasColumnType("datetime").IsOptional(); //DateTime?    
            Property(c=>c.ZmovDocMat           ).HasColumnType("varchar").HasMaxLength(20); //string       
            Property(c=>c.ZmovPos1             ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.CentroLogisticoID    ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.ZmovAlm              ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.ZmovLote             ).HasColumnType("varchar").HasMaxLength(20); //string       
            Property(c=>c.MaterialID           ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.ZmovCodigoAntiguo    ).HasColumnType("varchar").HasMaxLength(20); //string       
            Property(c=>c.ZmovGr               ).HasColumnType("varchar").HasMaxLength(5); //string       
            Property(c=>c.ZmovCantidad         ).HasColumnType("money").IsOptional(); //decimal?     
            Property(c=>c.ZmovE1               ).HasColumnType("varchar").HasMaxLength(5); //string       
            Property(c=>c.ZmovCMO              ).HasColumnType("varchar").HasMaxLength(5); //string       
            Property(c=>c.ZmovE2               ).HasColumnType("varchar").HasMaxLength(5); //string       
            Property(c=>c.ZmovProv             ).HasColumnType("varchar").HasMaxLength(20); //string       
            Property(c=>c.ZmovPedido           ).HasColumnType("varchar").HasMaxLength(20); //string       
            Property(c=>c.ZmovPos2             ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.OrdemID              ).HasColumnType("bigint").IsOptional(); //long?        
            Property(c=>c.ZmovTexto            ).HasColumnType("varchar").HasMaxLength(100); //string       
            Property(c=>c.ZmovImpEnt           ).HasColumnType("money").IsOptional(); //decimal?     
            Property(c=>c.ZmovImpSal           ).HasColumnType("money").IsOptional(); //decimal?     
            Property(c=>c.ZmovNombreDelU       ).HasColumnType("varchar").HasMaxLength(20); //string       
            Property(c=>c.ZmovQtde             ).HasColumnType("money").IsOptional(); //decimal?     
            Property(c=>c.ZmovValor            ).HasColumnType("money").IsOptional(); //decimal?     
            Property(c=>c.ZmovPeriodo          ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.ZmovEquivalente      ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.ClassificacaoID      ).HasColumnType("int").IsOptional(); //int?         
            Property(c=>c.ZmovExpurgado        ).HasColumnType("varchar"); //string       
            Property(c=>c.ZmovDataLanc         ).HasColumnType("DateTime").IsOptional(); //DateTime?    


            Property(c => c.ZmovExpurgado).HasMaxLength(2);

            HasOptional(p => p.CentroLogistico).WithMany(f => f.Zmovs).HasForeignKey(k => k.CentroLogisticoID);
            HasOptional(p => p.Classificacao).WithMany(f => f.Zmovs).HasForeignKey(k => k.ClassificacaoID);
            HasOptional(p => p.Material).WithMany(f => f.Zmovs).HasForeignKey(k => k.MaterialID);
            HasOptional(p => p.Ordem).WithMany(f => f.Zmovs).HasForeignKey(k => k.OrdemID);
            
        }
        
        //public virtual CentroLogistico CentroLogistico 
        //public virtual Classificacao Classificacao 
        //public virtual Material Material 
        //public virtual Ordem Ordem 
    }
}