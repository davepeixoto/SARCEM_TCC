using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("AspNetUsers");

            HasKey(c => c.Id);

            Property(c => c.UserBR)
                .HasMaxLength(15)
                .IsRequired();

            Property(u => u.Id)
            .IsRequired()
            .HasMaxLength(128)
           ;

            Property(u => u.Email)
             .IsRequired()
             .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);


            HasRequired(p => p.Empresa).WithMany(f => f.Usuarios).HasForeignKey(k => k.EmpresaID);



            //HasRequired(c => c.Empresas)
            //    .WithMany(m => m.Usuarios)
            //    .HasForeignKey(f => f.EmpresaId);


            //Property(u => u.Discriminator)
            //    .IsRequired()
            //    .HasMaxLength(128)
            //    .HasColumnType("nvarchar") ;



        }

    }
}