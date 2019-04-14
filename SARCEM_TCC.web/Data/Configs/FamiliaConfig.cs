using SARCEM_TCC.web.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{

    public class FamiliaConfig : EntityTypeConfiguration<Familia>
    {

        public FamiliaConfig()
        {
            ToTable("Familias");

            Property(f => f.UsuarioLogisticaID)
                .HasColumnType("varchar")
                .HasMaxLength(128);

            //Property(f => f.FamiliaSigla)
            //    .HasMaxLength(6);


        }
        //public int FamiliaId { get; set; }
        //public string  FamiliaNome { get; set; }
        //public string UsuarioLogisticaId { get; set; }
        //public long EmpresaId { get; set; }

        //public virtual Logistica UsuarioLogisticas { get; set; }
        //public virtual Empresa Empresa { get; set; }

        //public virtual List<Material> Materiais { get; set; }
    }
}