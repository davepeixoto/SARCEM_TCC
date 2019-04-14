using SARCEM_TCC.web.Models.Domain.DataMass;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class AppiaConfig : EntityTypeConfiguration<Appia>
    {

        public AppiaConfig()
        {
            ToTable("Appias");
            HasKey(c => c.AppiaID);
                

        Property(a => a.AppiaID             ).HasColumnType("bigint");//long          
        Property(a => a.MaterialID          ).HasColumnType("int").IsOptional();//int?          
        Property(a => a.DiretoriaID         ).HasColumnType("int").IsOptional();//int?          
        Property(a => a.SubDiretoriaID      ).HasColumnType("int").IsOptional();//int?          
        Property(a => a.AppiaProjeto        ).HasColumnType("varchar").HasMaxLength(200);//string        
        Property(a => a.AppiaInfoAdicional  ).HasColumnType("varchar").HasMaxLength(200);//string        
        Property(a => a.AppiaResponsavel    ).HasColumnType("varchar").HasMaxLength(200);//string        
        Property(a => a.UsuarioClienteId    ).HasColumnType("varchar").HasMaxLength(128);//string        
        Property(a => a.AppiaQuantidade     ).HasColumnType("money").IsOptional();//decimal?      
        Property(a => a.AppiaAno            ).HasColumnType("int").IsOptional();//int?          
        Property(a => a.AppiaDataLanc       ).HasColumnType("datetime").IsOptional();//DateTime?    

            HasOptional(c => c.Material).WithMany(f => f.Appias).HasForeignKey(k => k.MaterialID);
            HasOptional(c => c.SubDiretoria).WithMany(f => f.Appias).HasForeignKey(k => k.SubDiretoriaID);
            HasOptional(c => c.Diretoria).WithMany(f => f.Appias).HasForeignKey(k => k.DiretoriaID);
            HasOptional(c => c.UsuarioClientes).WithMany(f => f.Appias).HasForeignKey(k => k.UsuarioClienteId);



            /*
        public virtual SubDiretoria SubDiretoria 
        public virtual Diretoria Diretoria 
        public virtual Material Material 
        public virtual UsuarioCliente UsuarioClientes */

    }

}
}