using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            ToTable("Empresas");

            HasMany(f => f.Usuarios)
              .WithRequired()
              .HasForeignKey(m => m.EmpresaID);


            //HasMany(f => f.UsuariosAtuacoes)
            //  .WithOptional(u => u.EmpresasAtuacoes)
            //  .HasForeignKey(m => m.EmpresaAtuacao);

        }
        //public long EmpresaId { get; set; }
        //public string EmpresaNome { get; set; }
        //public virtual List<Usuario> Usuarios { get; set; }
        //public virtual List<Familia> Familias { get; set; }
        //public virtual List<Diretoria> Diretorias { get; set; }
        //public virtual List<Ceco> Cecos { get; set; }
        //public virtual List<BaseGiro> BaseGiros { get; set; }
        //public virtual List<PedidoDeCompra> PedidoDeCompras { get; set; }

    }
}