using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public partial class BaseGiroConfig : EntityTypeConfiguration<BaseGiro>
    {
        public BaseGiroConfig()
        {
            ToTable("BaseGiros");
            HasKey(c => c.ID);


         Property(c=>c.ID                    ).HasColumnType("bigint");//long    
         Property(c=>c.EmpresaID             ).HasColumnType("bigint");//long?   
         Property(c=>c.CentroLogisticoID     ).HasColumnType("int").IsOptional();//int?    
         Property(c=>c.BaseGiroTipoCentro    ).HasColumnType("varchar").HasMaxLength(50);//string  
         Property(c=>c.MaterialID            ).HasColumnType("int");//int?    
         Property(c=>c.BaseGiroConsQtde      ).HasColumnType("money").IsOptional();//decimal?
         Property(c=>c.BaseGiroConsValor     ).HasColumnType("money").IsOptional();//decimal?
         Property(c=>c.BaseGiroEstqQtde      ).HasColumnType("money").IsOptional();//decimal?
         Property(c=>c.BaseGiroEstqValor     ).HasColumnType("money").IsOptional();//decimal?
         Property(c=>c.BaseGiroEquivalente   ).HasColumnType("int").IsOptional();//int?    
         Property(c=>c.BaseGiroPeriodo       ).HasColumnType("int").IsOptional();//int?    
         Property(c=>c.BaseGiroClass         ).HasColumnType("int").IsOptional();//int?    
         Property(c=>c.BaseGiroAdm           ).HasColumnType("varchar").HasMaxLength(5);//string  

            HasOptional(p => p.Empresa).WithMany(f => f.BaseGiros).HasForeignKey(k => k.EmpresaID);
            HasOptional(p => p.CentroLogistico).WithMany(f => f.BaseGiros).HasForeignKey(k => k.CentroLogisticoID);
            HasOptional(p => p.Material).WithMany(f => f.BaseGiros).HasForeignKey(k => k.MaterialID);


        /*
        public Empresa Empresa 
        public CentroLogistico CentroLogistico 
        public Material Material   */
    }
        

    }
}